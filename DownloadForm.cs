﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class DownloadForm : Form
    {

        private string url;
        private string programName;
        private WebClient client = new WebClient();


        public DownloadForm(string url, string programName)
        {
            InitializeComponent();
            this.url = url;
            this.programName = programName;
            lblTitle.Text = "Downloading " + programName;

            btnCancel.FlatAppearance.MouseOverBackColor = Color.FromArgb(70, 0, 0, 0);
            btnCancel.FlatAppearance.MouseDownBackColor = Color.FromArgb(150, 0, 0, 0);
            
        }

        private void startDownload(string url)
        {
            Thread thread = new Thread(() =>
            {
                client.DownloadProgressChanged += new DownloadProgressChangedEventHandler(client_DownloadProgressChanged);
                client.DownloadFileCompleted += new AsyncCompletedEventHandler(client_DownloadFileCompleted);
                client.DownloadFileAsync(new Uri(url), Path.GetTempPath() + programName + ".exe");
            });
            thread.Start();
        }

        void client_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            this.BeginInvoke((MethodInvoker)delegate
            {
                double bytesIn = double.Parse(e.BytesReceived.ToString());
                double totalBytes = double.Parse(e.TotalBytesToReceive.ToString());
                double percentage = bytesIn / totalBytes * 100;
                label1.Text = "Downloaded " + e.BytesReceived / 1000 + " kb of " + e.TotalBytesToReceive / 1000 + " kb";
                lblTitle.Text = "Downloading " + programName + "... " + Math.Truncate(percentage).ToString() + "%";
                progressBar1.Value = int.Parse(Math.Truncate(percentage).ToString());
            });
        }
        void client_DownloadFileCompleted(object sender, AsyncCompletedEventArgs e)
        {
            this.BeginInvoke((MethodInvoker)delegate
            {
                label1.Text = "Download completed";

                switch (programName)
                {
                    case "Malwarebytes":
                        Process mbam;
                        mbam = Process.Start(Path.GetTempPath() + programName + ".exe", "/silent");
                        while (!mbam.HasExited)
                        {
                            Thread.Sleep(250);
                        }
                        Process.Start("C:\\Program Files (x86)\\Malwarebytes Anti-Malware\\mbam.exe");
                        break;

                    case "Malwarebytes 1.75":
                        label1.Text = "Installing...";
                        Process p;
                        p = Process.Start(Path.GetTempPath() + programName + ".exe", "/silent");
                        while (!p.HasExited)
                        {
                            label1.Text = "Updating...";
                            Thread.Sleep(250);
                        }
                        p = Process.Start("C:\\Program Files (x86)\\Malwarebytes' Anti-Malware\\mbam.exe", "/update");
                        while (!p.HasExited)
                        {
                            label1.Text = "Starting quick scan...";
                            Thread.Sleep(250);
                        }
                        p = Process.Start("C:\\Program Files (x86)\\Malwarebytes' Anti-Malware\\mbam.exe", "/quickscan");
                        break;

                    case "Sentinel Driver Removal":
                        // haspdinst (Sentinel removal) must be run with a command
                        Process.Start(Path.GetTempPath() + programName + ".exe", "-purge");
                        break;

                    case "UVK Portable":
                        string path = Path.GetTempPath() + @"tuneup.uvksr";
                        CopyResource("WindowsFormsApplication1.Resources.malware-tuneup.uvksr", path);
                        Process.Start(Path.GetTempPath() + programName + ".exe", "-ImportSr \"" + path + "\"");
                        break;

                    case "HitmanPro":
                        Process.Start(Path.GetTempPath() + programName + ".exe", "/scan");
                        break;

                    case "update":
                        Process.Start(Path.GetTempPath() + programName + ".exe");
                        Application.Exit();
                        break;

                    default:
                        Process.Start(Path.GetTempPath() + programName + ".exe");
                        break;
                }

                this.Dispose();
            });
        }

        private void DownloadForm_Load(object sender, EventArgs e)
        {
            startDownload(url);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            client.CancelAsync();
            label1.Text = @"Cancelling...";
            Thread.Sleep(500);
            this.Close();
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

    }
}
