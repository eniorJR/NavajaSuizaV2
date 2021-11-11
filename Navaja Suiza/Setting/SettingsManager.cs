using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace Navaja_Suiza.Setting
{
    class SettingsManager
    {
        public static string MAIN_FOLDER = @"C:\Program Files (x86)\NavajaSuiza\Settings\";
        public static string AutoUpdate_Setting;
        public static string DisableAntiVace_Setting;
        public static string AutoLoggin_Setting;
        public static XmlTextReader SettingsFiles = null;
        public static void XMLManager()
        {
            if (File.Exists(MAIN_FOLDER + "Settings.xml"))
            {
                XMLReader();
            }
            else
            {
                XMLGenerator();
            }
        }
        private static void XMLGenerator()
        {
            if (!Directory.Exists(MAIN_FOLDER)) { 
                Directory.CreateDirectory(MAIN_FOLDER);
            }
            using (XmlWriter writer = XmlWriter.Create(MAIN_FOLDER + "Settings.xml"))
            {
                writer.WriteStartElement("Settings");
                writer.WriteElementString("AutoUpdate", "False");
                writer.WriteElementString("DisableAntiVac", "False");
                writer.WriteElementString("AutoLoggin", "False");
                writer.WriteEndElement();
                writer.Flush();
            }
        }
        public static void XMLEditor(string AutoUpdate, string DisableAntiVac, string AutoLoggin)
        {
            using (XmlWriter writer = new XmlTextWriter(MAIN_FOLDER + "Settings.xml", System.Text.Encoding.UTF8))
            {
                writer.WriteStartElement("Settings");
                writer.WriteElementString("AutoUpdate", AutoUpdate);
                writer.WriteElementString("DisableAntiVac", DisableAntiVac);
                writer.WriteElementString("AutoLoggin", AutoLoggin);
                writer.WriteEndElement();
                writer.Flush();
            }
        }
        private static void XMLReader()
        {
            try
            {

                // Load the reader with the data file and ignore all white space nodes.
                SettingsFiles = new XmlTextReader(MAIN_FOLDER + "Settings.xml");
                SettingsFiles.WhitespaceHandling = WhitespaceHandling.None;

                // Parse the file and display each of the nodes.
                while (SettingsFiles.Read())
                {
                    switch (SettingsFiles.Name)
                    {
                        case "AutoUpdate":
                            AutoUpdate_Setting = SettingsFiles.ReadString();
                            break;
                        case "DisableAntiVac":
                            DisableAntiVace_Setting = SettingsFiles.ReadString();
                            break;
                        case "AutoLoggin":
                            AutoLoggin_Setting = SettingsFiles.ReadString();
                            break;

                    }
                }
            }

            finally
            {
                if (SettingsFiles != null)
                    SettingsFiles.Close();
            }
            
        }

    }

   
}
