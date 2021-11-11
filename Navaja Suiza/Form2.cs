using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Windows.Forms;
using MetroSet_UI.Forms;
using System.Management;
using System.Net;
using System.Security.Principal;

namespace Navaja_Suiza
{
    public partial class Form2 : MetroSetForm
    {
        List<string> UNIQUE_CODE_GARANTEED = new List<string>();
        form1 f = new form1();

        //user information in separated srtings
        public static string PROFILE_ID;
        public static string PROFILE_NAME;
        public static string PROFILE_EXPIRE;

        public Form2()
        {
            InitializeComponent();
            pc_id();
            Acces(false);

        }
        private void button1_Click(object sender, EventArgs e)
        {
            Acces(true);
        }
        private async void Acces(bool login)
        {
           
            if (Setting.SettingsManager.AutoLoggin_Setting == "True" || login)
            {
                button1.Text = "Loading...";
                await Task.Delay(500);
                if (!(new WindowsPrincipal(WindowsIdentity.GetCurrent())).IsInRole(WindowsBuiltInRole.Administrator))
                {
                    MetroSetMessageBox.Show(this, "Run as administrator please", "Administrator permission", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    if (check_unique_code())
                    {
                        this.Visible = false;
                        f.Show();
                        var mainForm = Application.OpenForms.OfType<form1>().Single();
                        mainForm.set_profileInfo();

                    }
                    else
                    {
                        MetroSetMessageBox.Show(this, "Your system is not registed in our database.\nPlease, register your system.\nJoin here > https://discord.gg/vBmFMFN5SZ");
                    }
                }
            }
            button1.Text = "Acces";
        }
        private bool check_unique_code()
        {
            try
            {                
                ManagementClass mangnmt = new ManagementClass("Win32_LogicalDisk");
                ManagementObjectCollection mcol = mangnmt.GetInstances();
                string result = "";
                foreach (ManagementObject strt in mcol)
                {
                    result += Convert.ToString(strt["VolumeSerialNumber"]);
                }
                foreach (string i in UNIQUE_CODE_GARANTEED)
                {
                    string[] resultI = i.Replace('-', ' ').Split(' ');
                    if (resultI[0] == result)
                    {
                        
                        if (resultI[2] == "unlimited" || DateTime.Parse(resultI[2]) > DateTime.UtcNow)
                        {
                            PROFILE_ID = result;
                            PROFILE_NAME = resultI[1];
                            PROFILE_EXPIRE = resultI[2];
                            return true;
                        }
                        else
                        {
                            MetroSetMessageBox.Show(this,"Your service has expired.\n\nYour account expired in: " + resultI[2], "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return false;
                        }
                    }


                }
                return false;
            }
            catch(Exception err)
            {
                MetroSetMessageBox.Show(this,"Your WMI system is broken, please, reinstall the service or contact with support" + "\nError: " + err);
                return false;
            }
        }

        private void Id_label_Click(object sender, EventArgs e)
        {
            
        }
        private void pc_id()
        {
            String text = "";
            WebClient web = new WebClient();
            System.IO.Stream stream = web.OpenRead("https://phthisic-drawings.000webhostapp.com/allowed_UNIQUE_garanteed");
            using (System.IO.StreamReader reader = new System.IO.StreamReader(stream))
            {
                text = reader.ReadToEnd();
                string[] i = text.Split(' ');
                foreach (string a in i)
                {
                    UNIQUE_CODE_GARANTEED.Add(a);
                }
            }
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }
    }
}
