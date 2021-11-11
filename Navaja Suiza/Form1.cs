using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using MetroSet_UI.Forms;
using System.Net;
using System.Reflection;

namespace Navaja_Suiza
{
    public partial class form1 : MetroSetForm
    {
        // VARIABLE DECLARATION
        public static string MAIN_FOLDER = @"C:\Program Files (x86)\NavajaSuiza\";
        string DLL_INJECTION;
        public static string EXE_FOLDER = System.IO.Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + @"\";
        public string PROGRAM_VERSION = "0.61";
        public static bool DISABLE_ANTIVAC = false;
        public string NEWEST_PROGRAM_VERSION = "Server Error";
        public form1()
        {
            SettingsCheaker();
            InitializeComponent();
            check_changelog();
        }
        public void set_profileInfo()
        {
            check_version();
            label23.Text = Form2.PROFILE_ID;
            label24.Text = Form2.PROFILE_NAME;
            label26.Text = Form2.PROFILE_EXPIRE;
        }
        public void check_version()
        {
            try
            {
                WebClient web = new WebClient();System.IO.Stream stream = web.OpenRead("https://phthisic-drawings.000webhostapp.com/version");
                using (System.IO.StreamReader reader = new System.IO.StreamReader(stream)){string text = reader.ReadToEnd(); NEWEST_PROGRAM_VERSION = text; label10.Text = "Your version: v" + PROGRAM_VERSION + " \nNewest version: v" + NEWEST_PROGRAM_VERSION; label5.Text = "v " + PROGRAM_VERSION;}
                if (PROGRAM_VERSION != NEWEST_PROGRAM_VERSION) { label21.Visible = true; MetroSetMessageBox.Show(this,"New version found!\nPlease, update this program\n\nGo to Settings and update the program.", "Program outdate", MessageBoxButtons.OK, MessageBoxIcon.Error); } else { label21.Visible = false; }
            }
            catch { MetroSetMessageBox.Show(this,"Server connection error, please, wait or try later...","Server error"); }
        }

        public void gameselector(string game)
        {
            switch (game)
            {
                case ("osiris"):
                    label19.Text = "Osiris CS:GO";
                    label17.Text = "Legit";
                    label4.Text = "Undetectable";
                    label4.ForeColor = System.Drawing.Color.Green;
                    DLL_INJECTION = "osiris.dll";
                    break;
                case ("pandora"):
                    label19.Text = "Supermacy CS:GO";
                    label17.Text = "Brute";
                    label4.Text = "Undetectable";
                    label4.ForeColor = System.Drawing.Color.Green;
                    DLL_INJECTION = "Supermacy.dll";
                    break;
                case ("Sensum"):
                    label19.Text = "Navaja Suiza CS:GO";
                    label17.Text = "Brute/Legit";
                    label4.Text = "Undetectable";
                    label4.ForeColor = System.Drawing.Color.Green;
                    DLL_INJECTION = "csgosimple.dll";
                    break;
                case ("fatality"):
                    label19.Text = "Saphine CS:GO";
                    label17.Text = "Brute";
                    label4.Text = "At your own risk (Crashing)";
                    label4.ForeColor = System.Drawing.Color.Orange;
                    DLL_INJECTION = "lugi3g.dll";
                    break;
                case ("Legendware"):
                    label19.Text = "Legend Ware CS:GO";
                    label17.Text = "Brute";
                    label4.Text = "Undetectable";
                    label4.ForeColor = System.Drawing.Color.Green;
                    DLL_INJECTION = "shonax.dll";//"LegendWare.dll";
                    break;
                case ("tweex"):
                    label19.Text = "NavajaRage CS:GO";
                    label17.Text = "Brute";
                    label4.Text = "Undetectable";
                    label4.ForeColor = System.Drawing.Color.Green;
                    DLL_INJECTION = "dll.dll";
                    break;
                default:

                    break;
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void juegos_panel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void game_csgo_Click(object sender, EventArgs e)
        {
            gameselector("osiris");
            metroSetLabel4.Text = "Osiris > Counter-Strike: Global Offensive";
        }

        private void game_cod_Click(object sender, EventArgs e)
        {
            gameselector("pandora");
            metroSetLabel4.Text = "Supermacy > Counter-Strike: Global...";
        }

        private void game_mine_Click(object sender, EventArgs e)
        {
            gameselector("Sensum");
            metroSetLabel4.Text = "Sensum > Counter-Strike: Global Offensive";
        }

        private void game_lol_Click(object sender, EventArgs e)
        {
            gameselector("fatality");
            metroSetLabel4.Text = "Saphine > Counter-Strike: Global Offensive";
        }

        private void Menu_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void metroSetLabel4_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

            MetroSetMessageBox.Show(this, "➜You are going to inject an external program into the game.\n➜Understand that this could lead to crashes, errors, or bans.\n➜The injection process may take a few minutes for your protection and that of the program.\n\nPress OK to start the injection.", "Injecting...", MessageBoxButtons.OK, MessageBoxIcon.Information);
            if (DLL_INJECTION != null)
            {
                injection.MainInjection(DLL_INJECTION);
            }
        }


        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            if (NEWEST_PROGRAM_VERSION == PROGRAM_VERSION) 
            {
                MetroSetMessageBox.Show(this,"You'r in the last version.", "Information Message", MessageBoxButtons.OK,MessageBoxIcon.Information);
            }
            else
            {
                try
                {
                    if (File.Exists(EXE_FOLDER + "Updater.exe"))
                    {
                        Process.Start(EXE_FOLDER + "Updater.exe");
                        Application.Exit();
                    }
                    else
                    {
                        MetroSetMessageBox.Show(this,"Updater not found \n Please, reinstall program or contact with support center.", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch
                {
                    MetroSetMessageBox.Show(this, "Updater not found \n Please, reinstall program or contact with support center.", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void metroSetSwitch6_SwitchedChanged(object sender)
        {
            Setting.SettingsManager.XMLEditor(metroSetSwitch6.Switched.ToString(), metroSetSwitch5.Switched.ToString(), metroSetSwitch1.Switched.ToString());
        }

        private void label21_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label23_Click(object sender, EventArgs e)
        {

        }

        private void label24_Click(object sender, EventArgs e)
        {

        }

        private void label26_Click(object sender, EventArgs e)
        {

        }
        private void close_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button7_Click_1(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }


        private void button5_Click(object sender, EventArgs e)
        {
            
            gameselector("Legendware");
            metroSetLabel4.Text = "Legendware > Counter-Strike: Global...   ";
        }


        private void label19_Click(object sender, EventArgs e)
        {

        }

        private void label17_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            gameselector("tweex");
            metroSetLabel4.Text = "Legendware > Counter-Strike: Global...   ";
        }

        private void metroSetSwitch5_SwitchedChanged(object sender)
        {
            DISABLE_ANTIVAC = metroSetSwitch5.Switched;
            Setting.SettingsManager.XMLEditor(metroSetSwitch6.Switched.ToString(), metroSetSwitch5.Switched.ToString(), metroSetSwitch1.Switched.ToString());

        }



       public async void SettingsCheaker()
        {
            Navaja_Suiza.Setting.SettingsManager.XMLManager();
            await Task.Delay(1000);
            if (Setting.SettingsManager.AutoUpdate_Setting == "True")
            {
                metroSetSwitch6.Switched = true;
                try
                {
                    if (File.Exists(EXE_FOLDER + "Updater.exe") && PROGRAM_VERSION != NEWEST_PROGRAM_VERSION)
                    {
                        Process.Start(EXE_FOLDER + "Updater.exe");
                        Application.Exit();
                    }
                }
                catch
                {
                    MetroSetMessageBox.Show(this, "Updater not found \n Please, reinstall program or contact with support center.", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            if (Setting.SettingsManager.DisableAntiVace_Setting == "True")
            {
                DISABLE_ANTIVAC = true;
                metroSetSwitch5.Switched = true;
            }
            if (Setting.SettingsManager.AutoLoggin_Setting == "True")
            {
                metroSetSwitch1.Switched = true;
            }
        }

        private void metroSetSwitch1_SwitchedChanged(object sender)
        {
            Setting.SettingsManager.XMLEditor(metroSetSwitch6.Switched.ToString(), metroSetSwitch5.Switched.ToString(), metroSetSwitch1.Switched.ToString());
        }
        public void check_changelog()
        {
            try
            {
                WebClient web = new WebClient();
                System.IO.Stream stream = web.OpenRead("https://phthisic-drawings.000webhostapp.com/changelog");
                using (System.IO.StreamReader reader = new System.IO.StreamReader(stream))
                {

                    string[] text = reader.ReadToEnd().Split('\n');
                    metroSetListBox1.AddItems(text);
                }
            }
            catch { metroSetListBox1.AddItem("Server connection error..."); }
        }

        private void ajustes_panel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label25_Click(object sender, EventArgs e)
        {

        }

        private void metroSetListBox1_SelectedIndexChanged(object sender)
        {

        }
    }
}


//Corbel Light; style=Bold 25,75pt // 32; 32; 32