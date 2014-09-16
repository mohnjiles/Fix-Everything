using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Configuration;

using Microsoft.Win32;
using System.Net;
using System.Threading;


using WindowsFormsApplication1.Properties;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        private const string RESOURCE_DIR = "WindowsFormsApplication1.Resources.";
        private const string WIN_UPDATE_FIX = RESOURCE_DIR + "WinUpdateFix-06.11.14.bat";
        private const string SENTINEL_REMOVE = RESOURCE_DIR + "haspdinst.exe";
        private const string CD_DVD_FIX = RESOURCE_DIR + "CDDVDWin8.meta.diagcab";
        private const string MCPR = RESOURCE_DIR + "MCPR.exe";
        private const string AUTORUNS = RESOURCE_DIR + "autoruns.exe";
        private const string OFFICE_2010_REMOVE = RESOURCE_DIR + "Office_2010_Remove.msi";
        private const string OFFICE_2013_REMOVE = RESOURCE_DIR + "Office 2013 Removal.diagcab";
        private const string PRINTER_FIX = RESOURCE_DIR + "Printer fix.bat";
        private const string SOUND_FIX = RESOURCE_DIR + "soundfix.bat";
        private const string WIN_8_1_ADMIN_FIX = RESOURCE_DIR + "win81adminfix.bat";
        private const string REMOVE_NORTON = RESOURCE_DIR + "Norton_Removal_Tool.exe";
        private const string AVAST = RESOURCE_DIR + "Ninite Avast Installer.exe";
        private const string CHROME = RESOURCE_DIR + "Ninite Chrome Installer.exe";
        private const string FIREFOX = RESOURCE_DIR + "Ninite Firefox Installer.exe";
        private const string ITUNES = RESOURCE_DIR + "Ninite iTunes Installer.exe";
        private const string JAVA = RESOURCE_DIR + "Ninite Java Installer.exe";
        private const string LIBRE_OFFICE = RESOURCE_DIR + "Ninite LibreOffice Installer.exe";
        private const string OPEN_OFFICE = RESOURCE_DIR + "Ninite OpenOffice Installer.exe";
        private const string SUPER = RESOURCE_DIR + "Ninite Super Installer.exe";
        private const string THUNDERBIRD = RESOURCE_DIR + "Ninite Thunderbird Installer.exe";
        private const string VLC = RESOURCE_DIR + "Ninite VLC Installer.exe";
        private const string MALWAREBYTES = RESOURCE_DIR + "Ninite Malwarebytes Installer.exe";
        private const string APPS = RESOURCE_DIR + "apps.diagcab";
        private const string CCLEANER = RESOURCE_DIR + "ccsetup417_slim.exe";
        private const string RESET_IE = RESOURCE_DIR + "Reset-Ie-Default.ps1";
        private const string RESET_IE_BAT = RESOURCE_DIR + "fix_ie.bat";
        private const string RESET_FF = RESOURCE_DIR + "fix_firefox.bat";
        private const string RESET_CHROME = RESOURCE_DIR + "fix_chrome.bat";
        private const string FIX_PC_SETTINGS = RESOURCE_DIR + "fix_pcsettings.bat";
        private const int CURRENT_VERSION = 12;




        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Set up button mouseover / mousedown colors
            button1.FlatAppearance.MouseOverBackColor = Color.FromArgb(70, 0, 0, 0);
            button1.FlatAppearance.MouseDownBackColor = Color.FromArgb(150, 0, 0, 0);
            button2.FlatAppearance.MouseOverBackColor = Color.FromArgb(70, 0, 0, 0);
            button2.FlatAppearance.MouseDownBackColor = Color.FromArgb(150, 0, 0, 0);
            btnDvd.FlatAppearance.MouseOverBackColor = Color.FromArgb(70, 0, 0, 0);
            btnDvd.FlatAppearance.MouseDownBackColor = Color.FromArgb(150, 0, 0, 0);
            btnClearPrintQueue.FlatAppearance.MouseOverBackColor = Color.FromArgb(70, 0, 0, 0);
            btnClearPrintQueue.FlatAppearance.MouseDownBackColor = Color.FromArgb(150, 0, 0, 0);
            btnSoundFix.FlatAppearance.MouseOverBackColor = Color.FromArgb(70, 0, 0, 0);
            btnSoundFix.FlatAppearance.MouseDownBackColor = Color.FromArgb(150, 0, 0, 0);
            btnAdminUpdateFix.FlatAppearance.MouseOverBackColor = Color.FromArgb(70, 0, 0, 0);
            btnAdminUpdateFix.FlatAppearance.MouseDownBackColor = Color.FromArgb(150, 0, 0, 0);
            btnRemoveMcAfee.FlatAppearance.MouseOverBackColor = Color.FromArgb(70, 0, 0, 0);
            btnRemoveMcAfee.FlatAppearance.MouseDownBackColor = Color.FromArgb(150, 0, 0, 0);
            btnRemoveNorton.FlatAppearance.MouseOverBackColor = Color.FromArgb(70, 0, 0, 0);
            btnRemoveNorton.FlatAppearance.MouseDownBackColor = Color.FromArgb(150, 0, 0, 0);
            btnOffice2010.FlatAppearance.MouseOverBackColor = Color.FromArgb(70, 0, 0, 0);
            btnOffice2010.FlatAppearance.MouseDownBackColor = Color.FromArgb(150, 0, 0, 0);
            btnOffice2013.FlatAppearance.MouseOverBackColor = Color.FromArgb(70, 0, 0, 0);
            btnOffice2013.FlatAppearance.MouseDownBackColor = Color.FromArgb(150, 0, 0, 0);
            btnAutoruns.FlatAppearance.MouseOverBackColor = Color.FromArgb(70, 0, 0, 0);
            btnAutoruns.FlatAppearance.MouseDownBackColor = Color.FromArgb(150, 0, 0, 0);
            btnAvast.FlatAppearance.MouseOverBackColor = Color.FromArgb(70, 0, 0, 0);
            btnAvast.FlatAppearance.MouseDownBackColor = Color.FromArgb(150, 0, 0, 0);
            btnChrome.FlatAppearance.MouseOverBackColor = Color.FromArgb(70, 0, 0, 0);
            btnChrome.FlatAppearance.MouseDownBackColor = Color.FromArgb(150, 0, 0, 0);
            btnFirefox.FlatAppearance.MouseOverBackColor = Color.FromArgb(70, 0, 0, 0);
            btnFirefox.FlatAppearance.MouseDownBackColor = Color.FromArgb(150, 0, 0, 0);
            btnITunes.FlatAppearance.MouseOverBackColor = Color.FromArgb(70, 0, 0, 0);
            btnITunes.FlatAppearance.MouseDownBackColor = Color.FromArgb(150, 0, 0, 0);
            btnJava.FlatAppearance.MouseOverBackColor = Color.FromArgb(70, 0, 0, 0);
            btnJava.FlatAppearance.MouseDownBackColor = Color.FromArgb(150, 0, 0, 0);
            btnLibre.FlatAppearance.MouseOverBackColor = Color.FromArgb(70, 0, 0, 0);
            btnLibre.FlatAppearance.MouseDownBackColor = Color.FromArgb(150, 0, 0, 0);
            btnOpenOffice.FlatAppearance.MouseOverBackColor = Color.FromArgb(70, 0, 0, 0);
            btnOpenOffice.FlatAppearance.MouseDownBackColor = Color.FromArgb(150, 0, 0, 0);
            btnSuper.FlatAppearance.MouseOverBackColor = Color.FromArgb(70, 0, 0, 0);
            btnSuper.FlatAppearance.MouseDownBackColor = Color.FromArgb(150, 0, 0, 0);
            btnThunderbird.FlatAppearance.MouseOverBackColor = Color.FromArgb(70, 0, 0, 0);
            btnThunderbird.FlatAppearance.MouseDownBackColor = Color.FromArgb(150, 0, 0, 0);
            btnVlc.FlatAppearance.MouseOverBackColor = Color.FromArgb(70, 0, 0, 0);
            btnVlc.FlatAppearance.MouseDownBackColor = Color.FromArgb(150, 0, 0, 0);
            btnMalwarebytes.FlatAppearance.MouseOverBackColor = Color.FromArgb(70, 0, 0, 0);
            btnMalwarebytes.FlatAppearance.MouseDownBackColor = Color.FromArgb(150, 0, 0, 0);
            btnApps.FlatAppearance.MouseOverBackColor = Color.FromArgb(70, 0, 0, 0);
            btnApps.FlatAppearance.MouseDownBackColor = Color.FromArgb(150, 0, 0, 0);
            btnCcleaner.FlatAppearance.MouseOverBackColor = Color.FromArgb(70, 0, 0, 0);
            btnCcleaner.FlatAppearance.MouseDownBackColor = Color.FromArgb(150, 0, 0, 0);
            btnResetIe.FlatAppearance.MouseOverBackColor = Color.FromArgb(70, 0, 0, 0);
            btnResetIe.FlatAppearance.MouseDownBackColor = Color.FromArgb(150, 0, 0, 0);
            btnResetFirefox.FlatAppearance.MouseOverBackColor = Color.FromArgb(70, 0, 0, 0);
            btnResetFirefox.FlatAppearance.MouseDownBackColor = Color.FromArgb(150, 0, 0, 0);
            btnResetChrome.FlatAppearance.MouseOverBackColor = Color.FromArgb(70, 0, 0, 0);
            btnResetChrome.FlatAppearance.MouseDownBackColor = Color.FromArgb(150, 0, 0, 0);
            btnScans.FlatAppearance.MouseOverBackColor = Color.FromArgb(70, 0, 0, 0);
            btnScans.FlatAppearance.MouseDownBackColor = Color.FromArgb(150, 0, 0, 0);
            btnHitman32.FlatAppearance.MouseOverBackColor = Color.FromArgb(70, 0, 0, 0);
            btnHitman32.FlatAppearance.MouseDownBackColor = Color.FromArgb(150, 0, 0, 0);
            btnHitman64.FlatAppearance.MouseOverBackColor = Color.FromArgb(70, 0, 0, 0);
            btnHitman64.FlatAppearance.MouseDownBackColor = Color.FromArgb(150, 0, 0, 0);
            btnAdwcleaner.FlatAppearance.MouseOverBackColor = Color.FromArgb(70, 0, 0, 0);
            btnAdwcleaner.FlatAppearance.MouseDownBackColor = Color.FromArgb(150, 0, 0, 0);
            btnMalwarebytesOld.FlatAppearance.MouseOverBackColor = Color.FromArgb(70, 0, 0, 0);
            btnMalwarebytesOld.FlatAppearance.MouseDownBackColor = Color.FromArgb(150, 0, 0, 0);
            btnIobit.FlatAppearance.MouseOverBackColor = Color.FromArgb(70, 0, 0, 0);
            btnIobit.FlatAppearance.MouseDownBackColor = Color.FromArgb(150, 0, 0, 0);
            btnRevo.FlatAppearance.MouseOverBackColor = Color.FromArgb(70, 0, 0, 0);
            btnRevo.FlatAppearance.MouseDownBackColor = Color.FromArgb(150, 0, 0, 0);
            btnRemoveTrend.FlatAppearance.MouseOverBackColor = Color.FromArgb(70, 0, 0, 0);
            btnRemoveTrend.FlatAppearance.MouseDownBackColor = Color.FromArgb(150, 0, 0, 0);
            btnUvk.FlatAppearance.MouseOverBackColor = Color.FromArgb(70, 0, 0, 0);
            btnUvk.FlatAppearance.MouseDownBackColor = Color.FromArgb(150, 0, 0, 0);
            btnRefreshReset.FlatAppearance.MouseOverBackColor = Color.FromArgb(70, 0, 0, 0);
            btnRefreshReset.FlatAppearance.MouseDownBackColor = Color.FromArgb(150, 0, 0, 0);
            btnPcSettings.FlatAppearance.MouseOverBackColor = Color.FromArgb(70, 0, 0, 0);
            btnPcSettings.FlatAppearance.MouseDownBackColor = Color.FromArgb(150, 0, 0, 0);
            btnHp.FlatAppearance.MouseOverBackColor = Color.FromArgb(70, 0, 0, 0);
            btnHp.FlatAppearance.MouseDownBackColor = Color.FromArgb(150, 0, 0, 0);
            btnKodak.FlatAppearance.MouseOverBackColor = Color.FromArgb(70, 0, 0, 0);
            btnKodak.FlatAppearance.MouseDownBackColor = Color.FromArgb(150, 0, 0, 0);
            btnOffice2010Dl.FlatAppearance.MouseOverBackColor = Color.FromArgb(70, 0, 0, 0);
            btnOffice2010Dl.FlatAppearance.MouseDownBackColor = Color.FromArgb(150, 0, 0, 0);
            btnOffice2013Dl.FlatAppearance.MouseOverBackColor = Color.FromArgb(70, 0, 0, 0);
            btnOffice2013Dl.FlatAppearance.MouseDownBackColor = Color.FromArgb(150, 0, 0, 0);
            btnPrntScanDoc.FlatAppearance.MouseOverBackColor = Color.FromArgb(70, 0, 0, 0);
            btnPrntScanDoc.FlatAppearance.MouseDownBackColor = Color.FromArgb(150, 0, 0, 0);
            btnTrendMicro.FlatAppearance.MouseOverBackColor = Color.FromArgb(70, 0, 0, 0);
            btnTrendMicro.FlatAppearance.MouseDownBackColor = Color.FromArgb(150, 0, 0, 0);
            btnMcAfee.FlatAppearance.MouseOverBackColor = Color.FromArgb(70, 0, 0, 0);
            btnMcAfee.FlatAppearance.MouseDownBackColor = Color.FromArgb(150, 0, 0, 0);

            if (!File.Exists("FixEverything.exe.config"))
            {
                createConfig();
            }

            // Check for updated version
            WebClient client = new WebClient();
            Stream stream = client.OpenRead("http://callme.cloudapp.net/version.txt");
            StreamReader reader = new StreamReader(stream);
            string version = reader.ReadToEnd();
            int serverVersion = Convert.ToInt16(version);
            if (CURRENT_VERSION < serverVersion)
            {
                try
                {
                    DialogResult result = MessageBox.Show("New version of Fix Everything is available. Download now?", "New version available", MessageBoxButtons.YesNo);
                    if (result == DialogResult.Yes)
                    {
                        DownloadForm dlForm = new DownloadForm("http://callme.cloudapp.net/updater.exe", "update");
                        dlForm.StartPosition = FormStartPosition.CenterParent;
                        dlForm.ShowDialog(this);
                    }
                }
                catch (Win32Exception ex)
                {
                    MessageBox.Show("Error!", "Error checking for updates, check your internet connection", MessageBoxButtons.OK);
                }
            }

            // Check settings for what's already been done
            var appSettings = ConfigurationManager.AppSettings;

            if (appSettings.Count != 0)
            {
                foreach (var key in appSettings.AllKeys)
                {
                    switch (key)
                    {
                        case "WinUpdate":
                            if (appSettings[key] == "true")
                            {
                                button1.ForeColor = Color.Green;
                            }
                            break;
                        case "haspdinst":
                            if (appSettings[key] == "true")
                            {
                                button2.ForeColor = Color.Green;
                            }
                            break;
                        case "dvd":
                            if (appSettings[key] == "true")
                            {
                                btnDvd.ForeColor = Color.Green;
                            }
                            break;
                        case "printqueue":
                            if (appSettings[key] == "true")
                            {
                                btnClearPrintQueue.ForeColor = Color.Green;
                            }
                            break;
                        case "soundfix":
                            if (appSettings[key] == "true")
                            {
                                btnSoundFix.ForeColor = Color.Green;
                            }
                            break;
                        case "adminfix":
                            if (appSettings[key] == "true")
                            {
                                btnAdminUpdateFix.ForeColor = Color.Green;
                            }
                            break;
                        case "appsfix":
                            if (appSettings[key] == "true")
                            {
                                btnApps.ForeColor = Color.Green;
                            }
                            break;
                        case "fixpcsettings":
                            if (appSettings[key] == "true")
                            {
                                btnPcSettings.ForeColor = Color.Green;
                            }
                            break;
                        case "hitmanpro64":
                            if (appSettings[key] == "true")
                            {
                                btnHitman64.ForeColor = Color.Green;
                            }
                            break;
                        case "hitmanpro32":
                            if (appSettings[key] == "true")
                            {
                                btnHitman32.ForeColor = Color.Green;
                            }
                            break;
                        case "malwarebytes20":
                            if (appSettings[key] == "true")
                            {
                                btnMalwarebytes.ForeColor = Color.Green;
                            }
                            break;
                        case "malwarebytes175":
                            if (appSettings[key] == "true")
                            {
                                btnMalwarebytesOld.ForeColor = Color.Green;
                            }
                            break;
                        case "super":
                            if (appSettings[key] == "true")
                            {
                                btnSuper.ForeColor = Color.Green;
                            }
                            break;
                        case "adwcleaner":
                            if (appSettings[key] == "true")
                            {
                                btnAdwcleaner.ForeColor = Color.Green;
                            }
                            break;
                        case "iobit":
                            if (appSettings[key] == "true")
                            {
                                btnIobit.ForeColor = Color.Green;
                            }
                            break;
                        case "revo":
                            if (appSettings[key] == "true")
                            {
                                btnRevo.ForeColor = Color.Green;
                            }
                            break;
                        case "uvk":
                            if (appSettings[key] == "true")
                            {
                                btnUvk.ForeColor = Color.Green;
                            }
                            break;
                        case "ccleaner":
                            if (appSettings[key] == "true")
                            {
                                btnCcleaner.ForeColor = Color.Green;
                            }
                            break;
                        case "office2013dl":
                            if (appSettings[key] == "true")
                            {
                                btnOffice2013Dl.ForeColor = Color.Green;
                            }
                            break;
                        case "office2013":
                            if (appSettings[key] == "true")
                            {
                                btnOffice2013.ForeColor = Color.Green;
                            }
                            break;
                        case "office2010dl":
                            if (appSettings[key] == "true")
                            {
                                btnOffice2010Dl.ForeColor = Color.Green;
                            }
                            break;
                        case "office2010":
                            if (appSettings[key] == "true")
                            {
                                btnOffice2010.ForeColor = Color.Green;
                            }
                            break;
                        case "hppiw":
                            if (appSettings[key] == "true")
                            {
                                btnHp.ForeColor = Color.Green;
                            }
                            break;
                        case "kodak":
                            if (appSettings[key] == "true")
                            {
                                btnKodak.ForeColor = Color.Green;
                            }
                            break;
                        case "printscandoc":
                            if (appSettings[key] == "true")
                            {
                                btnPrntScanDoc.ForeColor = Color.Green;
                            }
                            break;
                        case "trendmicrodl":
                            if (appSettings[key] == "true")
                            {
                                btnTrendMicro.ForeColor = Color.Green;
                            }
                            break;
                        case "removetrend":
                            if (appSettings[key] == "true")
                            {
                                btnRemoveTrend.ForeColor = Color.Green;
                            }
                            break;
                        case "mcafee":
                            if (appSettings[key] == "true")
                            {
                                btnMcAfee.ForeColor = Color.Green;
                            }
                            break;
                        case "removemcafee":
                            if (appSettings[key] == "true")
                            {
                                btnRemoveMcAfee.ForeColor = Color.Green;
                            }
                            break;
                        case "removenorton":
                            if (appSettings[key] == "true")
                            {
                                btnRemoveNorton.ForeColor = Color.Green;
                            }
                            break;
                        case "resetie":
                            if (appSettings[key] == "true")
                            {
                                btnResetIe.ForeColor = Color.Green;
                            }
                            break;
                        case "resetchrome":
                            if (appSettings[key] == "true")
                            {
                                btnResetChrome.ForeColor = Color.Green;
                            }
                            break;
                        case "resetfirefox":
                            if (appSettings[key] == "true")
                            {
                                btnResetFirefox.ForeColor = Color.Green;
                            }
                            break;
                        case "refreshreset":
                            if (appSettings[key] == "true")
                            {
                                btnRefreshReset.ForeColor = Color.Green;
                            }
                            break;
                        case "autoruns":
                            if (appSettings[key] == "true")
                            {
                                btnAutoruns.ForeColor = Color.Green;
                            }
                            break;
                        case "scans":
                            if (appSettings[key] == "true")
                            {
                                btnScans.ForeColor = Color.Green;
                            }
                            break;
                        default:
                            break;
                    }
                }
            }
        }


        private void button1_Click(object sender, EventArgs e)
        {

            if (Form.ModifierKeys == Keys.Control)
            {
                ((Button)sender).ForeColor = Color.White;
                AddUpdateAppSettings("WinUpdate", "false");
            }
            else
            {

                ((Button)sender).ForeColor = Color.Green;
                AddUpdateAppSettings("WinUpdate", "true");

                var assembly = Assembly.GetExecutingAssembly();
                var resourceName = "WindowsFormsApplication1.Resources.WinUpdateFix-06.11.14.bat";

                using (Stream stream = assembly.GetManifestResourceStream(resourceName))
                using (StreamReader reader = new StreamReader(stream))
                {
                    string result = reader.ReadToEnd();
                    File.WriteAllText(Path.GetTempPath() + @"winupdate.bat", result);
                }

                Process.Start(Path.GetTempPath() + @"winupdate.bat");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
            if (Form.ModifierKeys == Keys.Control)
            {
                ((Button)sender).ForeColor = Color.White;
                AddUpdateAppSettings("haspdinst", "false");
            }
            else
            {
                ((Button)sender).ForeColor = Color.Green;
                AddUpdateAppSettings("haspdinst", "true");

                DownloadForm dlForm = new DownloadForm("http://callme.cloudapp.net/haspdinst.exe", "Sentinel Driver Removal");
                dlForm.StartPosition = FormStartPosition.CenterParent;
                dlForm.ShowDialog(this);
            }
        }

        private void btnDvd_Click(object sender, EventArgs e)
        {

            if (Form.ModifierKeys == Keys.Control)
            {
                ((Button)sender).ForeColor = Color.White;
                AddUpdateAppSettings("dvd", "false");
            }
            else
            {
                ((Button)sender).ForeColor = Color.Green;
                AddUpdateAppSettings("dvd", "true");

                string path = Path.GetTempPath() + @"cddvdfix.diagcab";
                CopyResource(CD_DVD_FIX, path);
                Process.Start(path);
            }
        }

        private void btnClearPrintQueue_Click(object sender, EventArgs e)
        {

            if (Form.ModifierKeys == Keys.Control)
            {
                ((Button)sender).ForeColor = Color.White;
                AddUpdateAppSettings("printqueue", "false");
            }
            else
            {
                ((Button)sender).ForeColor = Color.Green;
                AddUpdateAppSettings("printqueue", "true");

                string path = Path.GetTempPath() + @"printerfix.bat";
                CopyResource(PRINTER_FIX, path);
                Process.Start(path);
            }
        }

        private void btnOffice2010_Click(object sender, EventArgs e)
        {

            if (Form.ModifierKeys == Keys.Control)
            {
                ((Button)sender).ForeColor = Color.White;
                AddUpdateAppSettings("office2010", "false");
            }
            else
            {
                ((Button)sender).ForeColor = Color.Green;
                AddUpdateAppSettings("office2010", "true");

                DownloadForm dlForm = new DownloadForm("http://191.238.32.68/Office_2010_Remove.msi", "Office 2010 Removal Tool");
                dlForm.StartPosition = FormStartPosition.CenterParent;
                dlForm.ShowDialog(this);
            }
        }

        private void btnOffice2013_Click(object sender, EventArgs e)
        {

            if (Form.ModifierKeys == Keys.Control)
            {
                ((Button)sender).ForeColor = Color.White;
                AddUpdateAppSettings("office2013", "false");
            }
            else
            {
                ((Button)sender).ForeColor = Color.Green;
                AddUpdateAppSettings("office2013", "true");

                DownloadForm dlForm = new DownloadForm("http://go.microsoft.com/?linkid=9815935", "Office 2013 Removal Tool");
                dlForm.StartPosition = FormStartPosition.CenterParent;
                dlForm.ShowDialog(this);
            }
        }

        private void btnSoundFix_Click(object sender, EventArgs e)
        {
            
            if (Form.ModifierKeys == Keys.Control)
            {
                ((Button)sender).ForeColor = Color.White;
                AddUpdateAppSettings("soundfix", "false");
            }
            else
            {
                ((Button)sender).ForeColor = Color.Green;
                AddUpdateAppSettings("soundfix", "true");

                string path = Path.GetTempPath() + @"soundfix.bat";
                CopyResource(SOUND_FIX, path);
                Process.Start(path);
            }
        }

        private void btnAdminUpdateFix_Click(object sender, EventArgs e)
        {

            if (Form.ModifierKeys == Keys.Control)
            {
                ((Button)sender).ForeColor = Color.White;
                AddUpdateAppSettings("adminfix", "false");
            }
            else
            {
                ((Button)sender).ForeColor = Color.Green;
                AddUpdateAppSettings("adminfix", "true");

                string path = Path.GetTempPath() + @"win81updatefix.bat";
                CopyResource(WIN_8_1_ADMIN_FIX, path);
                Process.Start(path);
            }
        }

        private void btnVlc_Click(object sender, EventArgs e)
        {

            if (Form.ModifierKeys == Keys.Control)
            {
                ((Button)sender).ForeColor = Color.White;
            }
            else
            {
                ((Button)sender).ForeColor = Color.Green;
                string path = Path.GetTempPath() + @"vlc.exe";
                CopyResource(VLC, path);
                Process.Start(path);
            }
        }

        private void btnThunderbird_Click(object sender, EventArgs e)
        {

            if (Form.ModifierKeys == Keys.Control)
            {
                ((Button)sender).ForeColor = Color.White;
            }
            else
            {
                ((Button)sender).ForeColor = Color.Green;
                string path = Path.GetTempPath() + @"thunderbird.exe";
                CopyResource(THUNDERBIRD, path);
                Process.Start(path);
            }
        }

        private void btnSuper_Click(object sender, EventArgs e)
        {

            if (Form.ModifierKeys == Keys.Control)
            {
                ((Button)sender).ForeColor = Color.White;
            }
            else
            {
                ((Button)sender).ForeColor = Color.Green;
                string path = Path.GetTempPath() + @"super.exe";
                CopyResource(SUPER, path);
                Process.Start(path);
            }
        }

        private void btnOpenOffice_Click(object sender, EventArgs e)
        {

            if (Form.ModifierKeys == Keys.Control)
            {
                ((Button)sender).ForeColor = Color.White;
            }
            else
            {
                ((Button)sender).ForeColor = Color.Green;
                string path = Path.GetTempPath() + @"openoffice.exe";
                CopyResource(OPEN_OFFICE, path);
                Process.Start(path);
            }
        }

        private void btnLibre_Click(object sender, EventArgs e)
        {

            if (Form.ModifierKeys == Keys.Control)
            {
                ((Button)sender).ForeColor = Color.White;
            }
            else
            {
                ((Button)sender).ForeColor = Color.Green;
                string path = Path.GetTempPath() + @"libreoffice.exe";
                CopyResource(LIBRE_OFFICE, path);
                Process.Start(path);
            }
        }

        private void btnJava_Click(object sender, EventArgs e)
        {

            if (Form.ModifierKeys == Keys.Control)
            {
                ((Button)sender).ForeColor = Color.White;
            }
            else
            {
                ((Button)sender).ForeColor = Color.Green;
                string path = Path.GetTempPath() + @"java.exe";
                CopyResource(JAVA, path);
                Process.Start(path);
            }
        }

        private void btnITunes_Click(object sender, EventArgs e)
        {

            if (Form.ModifierKeys == Keys.Control)
            {
                ((Button)sender).ForeColor = Color.White;
            }
            else
            {
                ((Button)sender).ForeColor = Color.Green;
                string path = Path.GetTempPath() + @"itunes.exe";
                CopyResource(ITUNES, path);
                Process.Start(path);
            }
        }

        private void btnFirefox_Click(object sender, EventArgs e)
        {
            if (Form.ModifierKeys == Keys.Control)
            {
                ((Button)sender).ForeColor = Color.White;
            }
            else
            {
                ((Button)sender).ForeColor = Color.Green;
                string path = Path.GetTempPath() + @"firefox.exe";
                CopyResource(FIREFOX, path);
                Process.Start(path);
            }
        }

        private void btnChrome_Click(object sender, EventArgs e)
        {
            if (Form.ModifierKeys == Keys.Control)
            {
                ((Button)sender).ForeColor = Color.White;
            }
            else
            {
                ((Button)sender).ForeColor = Color.Green;
                string path = Path.GetTempPath() + @"chrome.exe";
                CopyResource(CHROME, path);
                Process.Start(path);
            }
        }

        private void btnAvast_Click(object sender, EventArgs e)
        {
            if (Form.ModifierKeys == Keys.Control)
            {
                ((Button)sender).ForeColor = Color.White;
            }
            else
            {
                ((Button)sender).ForeColor = Color.Green;
                string path = Path.GetTempPath() + @"avast.exe";
                CopyResource(AVAST, path);
                Process.Start(path);
            }
        }

        private void btnApps_Click(object sender, EventArgs e)
        {
            if (Form.ModifierKeys == Keys.Control)
            {
                ((Button)sender).ForeColor = Color.White;
                AddUpdateAppSettings("appsfix", "false");
            }
            else
            {
                ((Button)sender).ForeColor = Color.Green;
                AddUpdateAppSettings("appsfix", "true");

                string path = Path.GetTempPath() + @"apps.diagcab";
                CopyResource(APPS, path);
                Process.Start(path);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (Form.ModifierKeys == Keys.Control)
            {
                ((Button)sender).ForeColor = Color.White;
                AddUpdateAppSettings("resetie", "false");
            }
            else
            {
                ((Button)sender).ForeColor = Color.Green;
                AddUpdateAppSettings("resetie", "true");

                string psPath = Path.GetTempPath() + @"reset-ie.ps1";
                CopyResource(RESET_IE, psPath);

                string batPath = Path.GetTempPath() + @"fix_ie.bat";
                CopyResource(RESET_IE_BAT, batPath);

                Process.Start(batPath);

            }
        }

        private void btnResetChrome_Click(object sender, EventArgs e)
        {
            if (Form.ModifierKeys == Keys.Control)
            {
                ((Button)sender).ForeColor = Color.White;
                AddUpdateAppSettings("resetchrome", "false");
            }
            else
            {
                ((Button)sender).ForeColor = Color.Green;
                AddUpdateAppSettings("resetchrome", "true");

                string path = Path.GetTempPath() + @"reset_chrome.bat";
                CopyResource(RESET_CHROME, path);
                Process.Start(path);
            }
        }

        private void btnResetFirefox_Click(object sender, EventArgs e)
        {
            if (Form.ModifierKeys == Keys.Control)
            {
                ((Button)sender).ForeColor = Color.White;
                AddUpdateAppSettings("resetfirefox", "false");
            }
            else
            {
                ((Button)sender).ForeColor = Color.Green;
                AddUpdateAppSettings("resetfirefox", "true");

                string path = Path.GetTempPath() + @"reset_firefox.bat";
                CopyResource(RESET_FF, path);
                Process.Start(path);
            }
        }

        private void btnScans_Click(object sender, EventArgs e)
        {
            if (Form.ModifierKeys == Keys.Control)
            {
                ((Button)sender).ForeColor = Color.White;
                AddUpdateAppSettings("scans", "false");
            }
            else
            {
                ((Button)sender).ForeColor = Color.Green;
                AddUpdateAppSettings("scans", "true");

                ScansPopup scansPopup = new ScansPopup();
                scansPopup.StartPosition = FormStartPosition.CenterParent;
                scansPopup.ShowDialog(this);
            }
        }

        private void btnHitman64_Click(object sender, EventArgs e)
        {
            if (Form.ModifierKeys == Keys.Control)
            {
                ((Button)sender).ForeColor = Color.White;
                AddUpdateAppSettings("hitmanpro64", "false");
            }
            else
            {
                ((Button)sender).ForeColor = Color.Green;
                AddUpdateAppSettings("hitmanpro64", "true");

                DownloadForm dlForm = new DownloadForm("http://dl.surfright.nl/HitmanPro_x64.exe", "HitmanPro");
                dlForm.StartPosition = FormStartPosition.CenterParent;
                dlForm.ShowDialog(this);
            }
        }

        private void btnHitman32_Click(object sender, EventArgs e)
        {
            if (Form.ModifierKeys == Keys.Control)
            {
                ((Button)sender).ForeColor = Color.White;
                AddUpdateAppSettings("hitmanpro32", "false");
            }
            else
            {
                ((Button)sender).ForeColor = Color.Green;
                AddUpdateAppSettings("hitmanpro32", "true");

                DownloadForm dlForm = new DownloadForm("http://dl.surfright.nl/HitmanPro.exe", "HitmanPro");
                dlForm.StartPosition = FormStartPosition.CenterParent;
                dlForm.ShowDialog(this);
            }
        }

        private void btnAdwcleaner_Click(object sender, EventArgs e)
        {
            if (Form.ModifierKeys == Keys.Control)
            {
                ((Button)sender).ForeColor = Color.White;
                AddUpdateAppSettings("adwcleaner", "false");
            }
            else
            {
                ((Button)sender).ForeColor = Color.Green;
                AddUpdateAppSettings("adwcleaner", "true");

                DownloadForm dlForm = new DownloadForm("http://callme.cloudapp.net/adwcleaner_3.306.exe", "AdwCleaner");
                dlForm.StartPosition = FormStartPosition.CenterParent;
                dlForm.ShowDialog(this);
            }
        }

        private void btnMalwarebytes_Click_1(object sender, EventArgs e)
        {
            if (Form.ModifierKeys == Keys.Control)
            {
                ((Button)sender).ForeColor = Color.White;
                AddUpdateAppSettings("malwarebytes20", "false");

            }
            else
            {
                ((Button)sender).ForeColor = Color.Green;
                AddUpdateAppSettings("malwarebytes20", "true");

                DownloadForm dlForm = new DownloadForm("http://downloads.malwarebytes.org/file/mbam/", "Malwarebytes");
                dlForm.StartPosition = FormStartPosition.CenterParent;
                dlForm.ShowDialog(this);
            }
        }

        private void btnSuper_Click_1(object sender, EventArgs e)
        {
            if (Form.ModifierKeys == Keys.Control)
            {
                ((Button)sender).ForeColor = Color.White;
                AddUpdateAppSettings("super", "false");
            }
            else
            {
                ((Button)sender).ForeColor = Color.Green;
                AddUpdateAppSettings("super", "true");

                string path = Path.GetTempPath() + @"super.exe";
                CopyResource(SUPER, path);
                Process.Start(path);
            }
        }

        private void btnMalwarebytesOld_Click(object sender, EventArgs e)
        {
            if (Form.ModifierKeys == Keys.Control)
            {
                ((Button)sender).ForeColor = Color.White;
                AddUpdateAppSettings("malwarebytes175", "false");
            }
            else
            {
                ((Button)sender).ForeColor = Color.Green;
                AddUpdateAppSettings("malwarebytes175", "true");

                DownloadForm dlForm = new DownloadForm("http://callme.cloudapp.net/mbam-setup-1.75.0.1300.exe", "Malwarebytes 1.75");
                dlForm.StartPosition = FormStartPosition.CenterParent;
                dlForm.ShowDialog(this);
            }
        }

        private void btnIobit_Click(object sender, EventArgs e)
        {
            if (Form.ModifierKeys == Keys.Control)
            {
                ((Button)sender).ForeColor = Color.White;
                AddUpdateAppSettings("iobit", "false");
            }
            else
            {
                ((Button)sender).ForeColor = Color.Green;
                AddUpdateAppSettings("iobit", "true");

                DownloadForm dlForm = new DownloadForm("http://callme.cloudapp.net/iobituninstaller338.exe", "IObit Uninstaller");
                dlForm.StartPosition = FormStartPosition.CenterParent;
                dlForm.ShowDialog(this);
            }
        }

        private void btnRevo_Click(object sender, EventArgs e)
        {
            if (Form.ModifierKeys == Keys.Control)
            {
                ((Button)sender).ForeColor = Color.White;
                AddUpdateAppSettings("revo", "false");
            }
            else
            {
                ((Button)sender).ForeColor = Color.Green;
                AddUpdateAppSettings("revo", "true");

                DownloadForm dlForm = new DownloadForm("http://www.revouninstaller.com/download-professional-version.php", "Revo Uninstaller");
                dlForm.StartPosition = FormStartPosition.CenterParent;
                dlForm.ShowDialog(this);
            }
        }

        private void btnUvk_Click(object sender, EventArgs e)
        {
            if (Form.ModifierKeys == Keys.Control)
            {
                ((Button)sender).ForeColor = Color.White;
                AddUpdateAppSettings("uvk", "false");
            }
            else
            {
                ((Button)sender).ForeColor = Color.Green;
                AddUpdateAppSettings("uvk", "true");

                DownloadForm dlForm = new DownloadForm("http://191.238.32.68/uvkportable.exe", "UVK Portable");
                dlForm.StartPosition = FormStartPosition.CenterParent;
                dlForm.ShowDialog(this);
            }
        }

        private void CopyResource(string resourceName, string file)
        {
            using (Stream resource = GetType().Assembly
                                              .GetManifestResourceStream(resourceName))
            {
                if (resource == null)
                {
                    throw new ArgumentException("No such resource", "resourceName");
                }
                using (Stream output = File.OpenWrite(file))
                {
                    resource.CopyTo(output);
                }
            }
        }


        private void btnRefreshReset_Click(object sender, EventArgs e)
        {
            if (Form.ModifierKeys == Keys.Control)
            {
                ((Button)sender).ForeColor = Color.White;
                AddUpdateAppSettings("refreshreset", "false");
            }
            else
            {
                ((Button)sender).ForeColor = Color.Green;
                AddUpdateAppSettings("refreshreset", "true");

                PasswordForm pwForm = new PasswordForm();
                pwForm.StartPosition = FormStartPosition.CenterParent;
                pwForm.ShowDialog(this);
            }
        }

        private void btnCcleaner_Click_1(object sender, EventArgs e)
        {
            if (Form.ModifierKeys == Keys.Control)
            {
                ((Button)sender).ForeColor = Color.White;
                AddUpdateAppSettings("ccleaner", "false");
            }
            else
            {
                ((Button)sender).ForeColor = Color.Green;
                AddUpdateAppSettings("ccleaner", "true");

                DownloadForm dlForm = new DownloadForm("http://www.piriform.com/ccleaner/download/slim/downloadfile", "CCleaner");
                dlForm.StartPosition = FormStartPosition.CenterParent;
                dlForm.ShowDialog(this);
            }
        }

        private void btnPcSettings_Click_1(object sender, EventArgs e)
        {
            if (Form.ModifierKeys == Keys.Control)
            {
                ((Button)sender).ForeColor = Color.White;
                AddUpdateAppSettings("fixpcsettings", "false");
            }
            else
            {
                ((Button)sender).ForeColor = Color.Green;
                AddUpdateAppSettings("fixpcsettings", "true");

                string path = Path.GetTempPath() + @"fix_pcsettings.bat";
                CopyResource(FIX_PC_SETTINGS, path);
                Process.Start(path);
            }
        }

        private void btnHp_Click_1(object sender, EventArgs e)
        {
            if (Form.ModifierKeys == Keys.Control)
            {
                ((Button)sender).ForeColor = Color.White;
                AddUpdateAppSettings("hppiw", "false");
            }
            else
            {
                ((Button)sender).ForeColor = Color.Green;
                AddUpdateAppSettings("hppiw", "true");

                DownloadForm dlForm = new DownloadForm("http://ftp.hp.com/pub/softlib/software12/COL50403/mp-122330-1/hppiw.exe", "HP Printer Install Wizard");
                dlForm.StartPosition = FormStartPosition.CenterParent;
                dlForm.ShowDialog(this);
            }
        }

        private void btnKodak_Click(object sender, EventArgs e)
        {
            if (Form.ModifierKeys == Keys.Control)
            {
                ((Button)sender).ForeColor = Color.White;
                AddUpdateAppSettings("kodak", "false");
            }
            else
            {
                ((Button)sender).ForeColor = Color.Green;
                AddUpdateAppSettings("kodak", "true");

                DownloadForm dlForm = new DownloadForm("http://download.kodak.com/digital/software/inkjet/v7_8/Bits/webdownload/aio_install.exe", "Kodak Printer Installer");
                dlForm.StartPosition = FormStartPosition.CenterParent;
                dlForm.ShowDialog(this);
            }
        }

        private void btnPrntScanDoc_Click(object sender, EventArgs e)
        {
            if (Form.ModifierKeys == Keys.Control)
            {
                ((Button)sender).ForeColor = Color.White;
                AddUpdateAppSettings("printscandoc", "false");
            }
            else
            {
                ((Button)sender).ForeColor = Color.Green;
                AddUpdateAppSettings("printscandoc", "true");

                DownloadForm dlForm = new DownloadForm("http://ftp.hp.com/pub/softlib/software12/COL50849/mp-135113-1/HPPSdr.exe", "HP Print and Scan Doctor");
                dlForm.StartPosition = FormStartPosition.CenterParent;
                dlForm.ShowDialog(this);

            }
        }

        private void btnTrendMicro_Click(object sender, EventArgs e)
        {
            if (Form.ModifierKeys == Keys.Control)
            {
                ((Button)sender).ForeColor = Color.White;
                AddUpdateAppSettings("trendmicrodl", "false");
            }
            else
            {
                ((Button)sender).ForeColor = Color.Green;
                AddUpdateAppSettings("trendmicrodl", "true");

                DownloadForm dlForm = new DownloadForm("https://ovet3w.dm2302.livefilestore.com/y2mB9DbPX-hOKYIyBKxzK3zgFiknYprTbDduCe65cMOmEUjMoIoxbJY8t2cp07Td3ro8bzW9lLGoLQ5TqIl56p0QNBwsvzM5EsDpmN90NkBm4HaJI5pDyTvGrIsRO0OVXmg/TrendMicro_TTi_7.0_TAV_Downloader.exe?download&psid=1", "Trend Micro");
                dlForm.StartPosition = FormStartPosition.CenterParent;
                dlForm.ShowDialog(this);
            }
        }

        private void btnRemoveTrend_Click_1(object sender, EventArgs e)
        {
            if (Form.ModifierKeys == Keys.Control)
            {
                ((Button)sender).ForeColor = Color.White;
                AddUpdateAppSettings("removetrend", "false");
            }
            else
            {
                ((Button)sender).ForeColor = Color.Green;
                AddUpdateAppSettings("removetrend", "true");

                DownloadForm dlForm = new DownloadForm("http://solutionfile.trendmicro.com/solutionfile/Titanium-2014/" +
                    "Ti_70_win_global_en_Uninstall_hfb0001.exe",
                    "Trend Micro Removal Tool");
                dlForm.StartPosition = FormStartPosition.CenterParent;
                dlForm.ShowDialog(this);
            }

        }

        private void btnRemoveNorton_Click_1(object sender, EventArgs e)
        {
            if (Form.ModifierKeys == Keys.Control)
            {
                ((Button)sender).ForeColor = Color.White;
                AddUpdateAppSettings("removenorton", "false");
            }
            else
            {
                ((Button)sender).ForeColor = Color.Green;
                AddUpdateAppSettings("removenorton", "true");

                string path = Path.GetTempPath() + @"removenorton.exe";
                CopyResource(REMOVE_NORTON, path);
                Process.Start(path);
            }
        }

        private void btnRemoveMcAfee_Click(object sender, EventArgs e)
        {
            if (Form.ModifierKeys == Keys.Control)
            {
                ((Button)sender).ForeColor = Color.White;
                AddUpdateAppSettings("removemcafee", "false");
            }
            else
            {
                ((Button)sender).ForeColor = Color.Green;
                AddUpdateAppSettings("removemcafee", "true");

                DownloadForm dlForm = new DownloadForm("http://download.mcafee.com/products/licensed/cust_support_patches/MCPR.exe", "McAfee Removal Tool");
                dlForm.StartPosition = FormStartPosition.CenterParent;
                dlForm.ShowDialog(this);
            }
        }

        private void btnMcAfee_Click(object sender, EventArgs e)
        {
            if (Form.ModifierKeys == Keys.Control)
            {
                ((Button)sender).ForeColor = Color.White;
                AddUpdateAppSettings("mcafee", "false");
            }
            else
            {
                ((Button)sender).ForeColor = Color.Green;
                AddUpdateAppSettings("mcafee", "true");

                DownloadForm dlForm = new DownloadForm("https://qpi8jg.dm2302.livefilestore.com/y2myG-nkRe04nlFtqbfyNaWxZBlDMIaUnsf6ajMC8MbqRGIUeeIjEgtACXRvW_UZLhuWzwqI5MXCFxzF1qrb3Smt4aOYgP9usJR90M2X2khWOFWw0OTH_fvhCAbQo9JcwDW/MCAfeesetup.exe?download&psid=1", "McAfee");
                dlForm.StartPosition = FormStartPosition.CenterParent;
                dlForm.ShowDialog(this);
            }

        }

        private void btnAutoruns_Click(object sender, EventArgs e)
        {
            if (Form.ModifierKeys == Keys.Control)
            {
                ((Button)sender).ForeColor = Color.White;
                AddUpdateAppSettings("autoruns", "false");
            }
            else
            {
                ((Button)sender).ForeColor = Color.Green;
                AddUpdateAppSettings("autoruns", "true");

                string path = Path.GetTempPath() + @"autoruns.exe";
                CopyResource(AUTORUNS, path);
                Process.Start(path);
            }
        }

        private void btnOffice2013Dl_Click(object sender, EventArgs e)
        {
            if (Form.ModifierKeys == Keys.Control)
            {
                ((Button)sender).ForeColor = Color.White;
                AddUpdateAppSettings("office2013dl", "false");
            }
            else
            {
                ((Button)sender).ForeColor = Color.Green;
                AddUpdateAppSettings("office2013dl", "true");

                Process.Start("https://downloadoffice.getmicrosoftkey.com/");
            }
        }

        private void btnOffice2010Dl_Click(object sender, EventArgs e)
        {
            if (Form.ModifierKeys == Keys.Control)
            {
                ((Button)sender).ForeColor = Color.White;
                AddUpdateAppSettings("office2010dl", "false");
            }
            else
            {
                ((Button)sender).ForeColor = Color.Green;
                AddUpdateAppSettings("office2010dl", "true");

                Process.Start("https://www2.downloadoffice2010.microsoft.com/usa/registerkey.aspx?culture=EN-US&ref=backup&country_id=US");
            }
        }

        private void createConfig()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("<?xml version=\"1.0\" encoding=\"utf-8\" ?>");
            sb.AppendLine("<configuration>");
            sb.AppendLine("</configuration>");

            string loc = Assembly.GetEntryAssembly().Location;
            System.IO.File.WriteAllText(String.Concat(loc, ".config"), sb.ToString());
        }

        static void AddUpdateAppSettings(string key, string value)
        {
            try
            {
                var configFile = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                var settings = configFile.AppSettings.Settings;
                if (settings[key] == null)
                {
                    settings.Add(key, value);
                }
                else
                {
                    settings[key].Value = value;
                }
                configFile.Save(ConfigurationSaveMode.Modified);
                ConfigurationManager.RefreshSection(configFile.AppSettings.SectionInformation.Name);
            }
            catch (ConfigurationErrorsException)
            {
                Console.WriteLine("Error writing app settings");
            }
        }
    }
}
