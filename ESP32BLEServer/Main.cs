using ESP32BLEServer.Services;
using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ESP32BLEServer
{
    public partial class Main : Form
    {
        private BLEService bleService;
        private CryptoCurrencyService cryptoCurrencyService;

        public Main()
        {
            bleService = new BLEService();
            cryptoCurrencyService = new CryptoCurrencyService();
            InitializeComponent();
        }

        private async Task<string> GenerateCommand()
        {
            string txt = txtCommand.Text;
            if (chkTime.Checked)
            {
                txt = txt.Replace("@time", DateTime.Now.ToString("HH:mm"));
            }
            if (chkBtcUsd.Checked)
            {
                txt = txt.Replace("@btc", (await cryptoCurrencyService.Get("BTC", "USD")).ToString());
            }
            if (chkBtcUsd.Checked)
            {
                txt = txt.Replace("@eth", (await cryptoCurrencyService.Get("ETH", "USD")).ToString());
            }
            return txt;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            ulong addr = (ulong)bleAddress.Value;
            Task.Run(async () => await bleService.SendToDevice(addr, GenerateCommand()));
        }

        private async void AutoUpdateTask()
        {
            ulong addr = (ulong)bleAddress.Value;
            while (chkAutoUpdate.Checked)
            {
                var start = DateTime.Now;
                await bleService.SendToDevice(addr, GenerateCommand());
                var wait = DateTime.Now.Add(TimeSpan.FromSeconds(60 - DateTime.Now.Second)) - start;
                Debug.WriteLine("Sleep for {0}", wait);
                Thread.Sleep(wait);
            }
        }

        private void chkAutoUpdate_CheckedChanged(object sender, EventArgs e)
        {
            if (chkAutoUpdate.Checked)
            {
                groupAddr.Enabled = false;
                groupCommandTemplate.Enabled = false;
                groupDataSource.Enabled = false;
                btnUpdate.Enabled = false;
                Task.Run(AutoUpdateTask);
            }
            else
            {
                groupAddr.Enabled = true;
                groupCommandTemplate.Enabled = true;
                groupDataSource.Enabled = true;
                btnUpdate.Enabled = true;
            }
        }

        private void notifyIcon_Click(object sender, EventArgs e)
        {
            Show();
            WindowState = FormWindowState.Normal;
        }

        private void Main_Resize(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Minimized)
            {
                Hide();
            }
        }
    }
}
