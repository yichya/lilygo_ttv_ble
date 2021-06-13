using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Windows.Devices.Bluetooth;
using Windows.Devices.Bluetooth.GenericAttributeProfile;
using Windows.Storage.Streams;


namespace ESP32BLEServer.Services
{
    class BLEService
    {
        private readonly System.Guid UARTServiceGuid = System.Guid.Parse("6E400001-B5A3-F393-E0A9-E50E24DCCA9E");
        private readonly System.Guid UARTCharacteristicTxGuid = System.Guid.Parse("6E400002-B5A3-F393-E0A9-E50E24DCCA9E");

        private static IBuffer String2Buffer(string str)
        {
            using (InMemoryRandomAccessStream memoryStream = new InMemoryRandomAccessStream())
            {
                using (DataWriter dataWriter = new DataWriter(memoryStream))
                {
                    dataWriter.WriteString(str);
                    return dataWriter.DetachBuffer();
                }
            }
        }

        public async Task<string> SendToDevice(ulong deviceId, Task<string> payload)
        {
            var bluetoothLeDevice = await BluetoothLEDevice.FromBluetoothAddressAsync(deviceId);
            if (bluetoothLeDevice == null)
            {
                return "";
            }

            Debug.WriteLine("RequestAccessAsync");
            try
            {
                var requestAccessResponse = await bluetoothLeDevice.RequestAccessAsync();
                Debug.WriteLine(string.Format("RequestAccessAsync {0}", requestAccessResponse));
            }
            catch (Exception ex)
            {
                Debug.WriteLine("RequestAccessAsync failed {0}", ex.Message);
                bluetoothLeDevice.Dispose();
                return "";
            }

            Debug.WriteLine("Device connection status {0}, try GetGattServicesForUuidAsync Uncached", bluetoothLeDevice.ConnectionStatus);
            GattDeviceService service;
            try
            {
                var services = await bluetoothLeDevice.GetGattServicesForUuidAsync(UARTServiceGuid, BluetoothCacheMode.Uncached);
                if (services.Status != GattCommunicationStatus.Success)
                {
                    Debug.WriteLine("GetGattServicesForUuidAsync failed {0}", services.Status, services.Services.Count);
                    bluetoothLeDevice.Dispose();
                    return "";
                }
                if (services.Services.Count != 1)
                {
                    Debug.WriteLine("GetGattServicesForUuidAsync unexpected servicesCount = {1}", services.Services.Count);
                    bluetoothLeDevice.Dispose();
                    return "";
                }
                service = services.Services[0];
            }
            catch (Exception ex)
            {
                Debug.WriteLine(string.Format("GetGattServicesForUuidAsync failed {0}", ex.Message));
                bluetoothLeDevice.Dispose();
                return "";
            }

            Debug.WriteLine("Enumerating Characteristics");
            GattCharacteristic characteristic;
            try
            {
                var characteristicList = await service.GetCharacteristicsForUuidAsync(UARTCharacteristicTxGuid, BluetoothCacheMode.Uncached);
                if (characteristicList.Characteristics.Count != 1)
                {
                    Debug.WriteLine("GetCharacteristics failed {0}, characteristics count = {1}", characteristicList.Status, characteristicList.Characteristics.Count);
                    service.Dispose();
                    bluetoothLeDevice.Dispose();
                    return "";
                }
                characteristic = characteristicList.Characteristics[0];
            }
            catch (Exception ex)
            {
                Debug.WriteLine("GetCharacteristics failed {0}", ex.Message);
                service.Dispose();
                bluetoothLeDevice.Dispose();
                return "";
            }

            Debug.WriteLine("CharacteristicFirst {0}, trying WriteValueAsync", characteristic.Uuid);
            try
            {
                var result = await payload;
                var f = await characteristic.WriteValueAsync(String2Buffer(await payload));
                return f.ToString();
            }
            catch (Exception ex)
            {
                Debug.WriteLine("WriteValueAsync Failed {0}", ex.HResult);
                return "";
            }
            finally
            {
                Debug.WriteLine("Cleaning up");
                service.Dispose();
                bluetoothLeDevice.Dispose();
            }
        }
    }
}
