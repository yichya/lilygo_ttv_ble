# lilygo_ttv_ble

Use WinRT BLE API to communicate with ESP32 (LilyGo TTV here for example)

## Usage

1. flash latest micropython to LilyGo TTV
2. use `ampy` or webrepl to upload all `.py` files in `device` folder to TTV
3. reboot TTV and you'll see a message about BLE address
4. compile and run ESP32BLEServer
5. use the address from step 3 to start communication
