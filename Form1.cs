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
        private const string CCLEANER = RESOURCE_DIR + "ccsetup416_slim.exe";
        private const string RESET_IE = RESOURCE_DIR + "Reset-Ie-Default.ps1";
        private const string RESET_IE_BAT = RESOURCE_DIR + "fix_ie.bat";
        private const string RESET_FF = RESOURCE_DIR + "fix_firefox.bat";
        private const string RESET_CHROME = RESOURCE_DIR + "fix_chrome.bat";
        private const int CURRENT_VERSION = 9;

       


        public Form1()
        {
            InitializeComponent();

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
        }


        private void button1_Click(object sender, EventArgs e)
        {
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

        private void button2_Click(object sender, EventArgs e)
        {
            DownloadForm dlForm = new DownloadForm("http://callme.cloudapp.net/haspdinst.exe", "Sentinel Driver Removal");
            dlForm.StartPosition = FormStartPosition.CenterParent;
            dlForm.ShowDialog(this);
        }

        private void btnDvd_Click(object sender, EventArgs e)
        {
            string path = Path.GetTempPath() + @"cddvdfix.diagcab";
            CopyResource(CD_DVD_FIX, path);
            Process.Start(path);
        }

        private void btnClearPrintQueue_Click(object sender, EventArgs e)
        {
            string path = Path.GetTempPath() + @"printerfix.bat";
            CopyResource(PRINTER_FIX, path);
            Process.Start(path);
        }

        private void btnRemoveMcAfee_Click(object sender, EventArgs e)
        {
            DownloadForm dlForm = new DownloadForm("http://download.mcafee.com/products/licensed/cust_support_patches/MCPR.exe", "McAfee Removal Tool");
            dlForm.StartPosition = FormStartPosition.CenterParent;
            dlForm.ShowDialog(this);
        }

        private void btnAutoruns_Click(object sender, EventArgs e)
        {
            string path = Path.GetTempPath() + @"autoruns.exe";
            CopyResource(AUTORUNS, path);
            Process.Start(path);
        }

        private void btnOffice2010_Click(object sender, EventArgs e)
        {
            string path = Path.GetTempPath() + @"office2010remove.msi";
            CopyResource(OFFICE_2010_REMOVE, path);
            Process.Start(path);
        }

        private void btnOffice2013_Click(object sender, EventArgs e)
        {
            string path = Path.GetTempPath() + @"office2013remove.diagcab";
            CopyResource(OFFICE_2013_REMOVE, path);
            Process.Start(path);
        }

        private void btnSoundFix_Click(object sender, EventArgs e)
        {
            string path = Path.GetTempPath() + @"soundfix.bat";
            CopyResource(SOUND_FIX, path);
            Process.Start(path);
        }

        private void btnAdminUpdateFix_Click(object sender, EventArgs e)
        {
            string path = Path.GetTempPath() + @"win81updatefix.bat";
            CopyResource(WIN_8_1_ADMIN_FIX, path);
            Process.Start(path);
        }

        private void btnRemoveNorton_Click(object sender, EventArgs e)
        {
            string path = Path.GetTempPath() + @"removenorton.exe";
            CopyResource(REMOVE_NORTON, path);
            Process.Start(path);
        }

        private void btnVlc_Click(object sender, EventArgs e)
        {
            string path = Path.GetTempPath() + @"vlc.exe";
            CopyResource(VLC, path);
            Process.Start(path);
        }

        private void btnThunderbird_Click(object sender, EventArgs e)
        {
            string path = Path.GetTempPath() + @"thunderbird.exe";
            CopyResource(THUNDERBIRD, path);
            Process.Start(path);
        }

        private void btnSuper_Click(object sender, EventArgs e)
        {
            string path = Path.GetTempPath() + @"super.exe";
            CopyResource(SUPER, path);
            Process.Start(path);
        }

        private void btnOpenOffice_Click(object sender, EventArgs e)
        {
            string path = Path.GetTempPath() + @"openoffice.exe";
            CopyResource(OPEN_OFFICE, path);
            Process.Start(path);
        }

        private void btnLibre_Click(object sender, EventArgs e)
        {
            string path = Path.GetTempPath() + @"libreoffice.exe";
            CopyResource(LIBRE_OFFICE, path);
            Process.Start(path);
        }

        private void btnJava_Click(object sender, EventArgs e)
        {
            string path = Path.GetTempPath() + @"java.exe";
            CopyResource(JAVA, path);
            Process.Start(path);
        }

        private void btnITunes_Click(object sender, EventArgs e)
        {
            string path = Path.GetTempPath() + @"itunes.exe";
            CopyResource(ITUNES, path);
            Process.Start(path);
        }

        private void btnFirefox_Click(object sender, EventArgs e)
        {
            string path = Path.GetTempPath() + @"firefox.exe";
            CopyResource(FIREFOX, path);
            Process.Start(path);
        }

        private void btnChrome_Click(object sender, EventArgs e)
        {
            string path = Path.GetTempPath() + @"chrome.exe";
            CopyResource(CHROME, path);
            Process.Start(path);
        }

        private void btnAvast_Click(object sender, EventArgs e)
        {
            string path = Path.GetTempPath() + @"avast.exe";
            CopyResource(AVAST, path);
            Process.Start(path);
        }

        private void btnApps_Click(object sender, EventArgs e)
        {
            string path = Path.GetTempPath() + @"apps.diagcab";
            CopyResource(APPS, path);
            Process.Start(path);
        }

        private void btnCcleaner_Click(object sender, EventArgs e)
        {
            string path = Path.GetTempPath() + @"ccleaner.exe";
            CopyResource(CCLEANER, path);
            Process.Start(path);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string psPath = Path.GetTempPath() + @"reset-ie.ps1";
            CopyResource(RESET_IE, psPath);

            string batPath = Path.GetTempPath() + @"fix_ie.bat";
            CopyResource(RESET_IE_BAT, batPath);

            Process.Start(batPath);
            
        }

        private void btnResetChrome_Click(object sender, EventArgs e)
        {
            string path = Path.GetTempPath() + @"reset_chrome.bat";
            CopyResource(RESET_CHROME, path);
            Process.Start(path);
        }

        private void btnResetFirefox_Click(object sender, EventArgs e)
        {
            string path = Path.GetTempPath() + @"reset_firefox.bat";
            CopyResource(RESET_FF, path);
            Process.Start(path);
        }

        private void btnScans_Click(object sender, EventArgs e)
        {
            ScansPopup scansPopup = new ScansPopup();
            scansPopup.StartPosition = FormStartPosition.CenterParent;
            scansPopup.ShowDialog(this);
        }

        private void btnHitman64_Click(object sender, EventArgs e)
        {
            DownloadForm dlForm = new DownloadForm("http://dl.surfright.nl/HitmanPro_x64.exe", "HitmanPro");
            dlForm.StartPosition = FormStartPosition.CenterParent;
            dlForm.ShowDialog(this);
        }

        private void btnHitman32_Click(object sender, EventArgs e)
        {
            DownloadForm dlForm = new DownloadForm("http://dl.surfright.nl/HitmanPro.exe", "HitmanPro");
            dlForm.StartPosition = FormStartPosition.CenterParent;
            dlForm.ShowDialog(this);
        }

        private void btnAdwcleaner_Click(object sender, EventArgs e)
        {
            DownloadForm dlForm = new DownloadForm("http://callme.cloudapp.net/adwcleaner_3.306.exe", "AdwCleaner");
            dlForm.StartPosition = FormStartPosition.CenterParent;
            dlForm.ShowDialog(this);
        }

        private void btnMalwarebytes_Click_1(object sender, EventArgs e)
        {
            DownloadForm dlForm = new DownloadForm("http://downloads.malwarebytes.org/file/mbam/", "Malwarebytes");
            dlForm.StartPosition = FormStartPosition.CenterParent;
            dlForm.ShowDialog(this);
        }

        private void btnSuper_Click_1(object sender, EventArgs e)
        {
            string path = Path.GetTempPath() + @"super.exe";
            CopyResource(SUPER, path);
            Process.Start(path);
        }

        private void btnMalwarebytesOld_Click(object sender, EventArgs e)
        {
            DownloadForm dlForm = new DownloadForm("http://callme.cloudapp.net/mbam-setup-1.75.0.1300.exe", "Malwarebytes 1.75");
            dlForm.StartPosition = FormStartPosition.CenterParent;
            dlForm.ShowDialog(this);
        }

        private void btnIobit_Click(object sender, EventArgs e)
        {
            DownloadForm dlForm = new DownloadForm("http://callme.cloudapp.net/iobituninstaller338.exe", "IObit Uninstaller");

            dlForm.StartPosition = FormStartPosition.CenterParent;
            dlForm.ShowDialog(this);
        }

        private void btnRevo_Click(object sender, EventArgs e)
        {
            DownloadForm dlForm = new DownloadForm("http://www.revouninstaller.com/download-professional-version.php", "Revo Uninstaller");
            dlForm.StartPosition = FormStartPosition.CenterParent;
            dlForm.ShowDialog(this);
        }

        private void btnRemoveTrend_Click(object sender, EventArgs e)
        {
            DownloadForm dlForm = new DownloadForm("http://solutionfile.trendmicro.com/solutionfile/Titanium-2014/" + 
                "Ti_70_win_global_en_Uninstall_hfb0001.exe",
                "Trend Micro Removal Tool");
            dlForm.StartPosition = FormStartPosition.CenterParent;
            dlForm.ShowDialog(this);
        }

        private void btnUvk_Click(object sender, EventArgs e)
        {
            DownloadForm dlForm = new DownloadForm("http://callme.cloudapp.net/uvkportable.exe", "UVK Portable");
            dlForm.StartPosition = FormStartPosition.CenterParent;
            dlForm.ShowDialog(this);
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

        private void Form1_Load(object sender, EventArgs e)
        {
            WebClient client = new WebClient();
            Stream stream = client.OpenRead("http://callme.cloudapp.net/version.txt");
            StreamReader reader = new StreamReader(stream);
            string version = reader.ReadToEnd();
            int serverVersion = Convert.ToInt16(version);
            if (CURRENT_VERSION < serverVersion)
            {
                DialogResult result = MessageBox.Show("New version of Fix Everything is available. Download now?", "New version available", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    DownloadForm dlForm = new DownloadForm("http://callme.cloudapp.net/updater.exe", "update");
                    dlForm.StartPosition = FormStartPosition.CenterParent;
                    dlForm.ShowDialog(this);
                }
            }
        }
      
    }
}
