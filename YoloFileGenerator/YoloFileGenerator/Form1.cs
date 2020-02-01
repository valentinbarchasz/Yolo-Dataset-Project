using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace YoloFileGenerator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void buttonGenerateFromNumber_Click(object sender, EventArgs e)
        {

        }

        private void buttonOpenFolder_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fdialog = new FolderBrowserDialog();
            var results=fdialog.ShowDialog();
            if(results == DialogResult.OK && !string.IsNullOrWhiteSpace(fdialog.SelectedPath))
            {
                labelFolderToScan.Text = "Path: " + fdialog.SelectedPath;

                using (System.IO.StreamWriter file =
                    new System.IO.StreamWriter(fdialog.SelectedPath + "/train.txt", true))
                {
                    
                    foreach (string filePath in Directory.GetFiles(fdialog.SelectedPath))
                    {
                        if(filePath.Contains(".jpg"))
                            file.WriteLine(filePath);
                    }
                }
            }
            
        }

        private void buttonValOpenFolder_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fdialog = new FolderBrowserDialog();
            var results = fdialog.ShowDialog();
            if (results == DialogResult.OK && !string.IsNullOrWhiteSpace(fdialog.SelectedPath))
            {
                labelFolderToScan.Text = "Path: " + fdialog.SelectedPath;

                using (System.IO.StreamWriter file =
                    new System.IO.StreamWriter(fdialog.SelectedPath + "/val.txt", true))
                {

                    foreach (string filePath in Directory.GetFiles(fdialog.SelectedPath))
                    {
                        if (filePath.Contains(".jpg"))
                            file.WriteLine(filePath);
                    }
                }
            }
        }
    }
}
