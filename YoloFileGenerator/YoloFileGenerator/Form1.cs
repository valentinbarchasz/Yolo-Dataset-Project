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
        List<Classes> classesList = new List<Classes>();
        public Form1()
        {
            InitializeComponent();
            dataGridView1.ColumnCount = 2;
            dataGridView1.RowCount = 1;
            dataGridView1.Columns[0].Name = "Index";
            dataGridView1.Columns[1].Name = "Classe Name";
            string[] row = { (numericUpDownNumberOfClasses.Value-1).ToString(), "" };
            dataGridView1.Rows.Clear();
            dataGridView1.Rows.Add(row);
            dataGridView1.RowHeadersVisible = false;
            classesList.Add(new Classes() { index = 0, name = "" });
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
                    new System.IO.StreamWriter(fdialog.SelectedPath + "../train.txt", true))
                {
                    
                    foreach (string filePath in Directory.GetFiles(fdialog.SelectedPath))
                    {
                        if(filePath.Contains(".jpg")|| filePath.Contains(".png"))
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
                    new System.IO.StreamWriter(fdialog.SelectedPath + "../val.txt", true))
                {

                    foreach (string filePath in Directory.GetFiles(fdialog.SelectedPath))
                    {
                        if (filePath.Contains(".jpg") || filePath.Contains(".png"))
                            file.WriteLine(filePath);
                    }
                }
            }
        }

        int classCount = 1;
        private void numericUpDownNumberOfClasses_ValueChanged(object sender, EventArgs e)
        {
            if(numericUpDownNumberOfClasses.Value>classesList.Count)
            {
                string[] row = { (numericUpDownNumberOfClasses.Value-1).ToString(), ""};
                dataGridView1.Rows.Add(row);
                classesList.Add(new Classes() { index = (int)numericUpDownNumberOfClasses.Value - 1, name = "" });
            }
            else
            {
                dataGridView1.Rows.RemoveAt(dataGridView1.Rows.Count - 2);
                classesList.RemoveAt((int)numericUpDownNumberOfClasses.Value);
            }
        }
        int toto=0;

        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if(classesList.Count>e.RowIndex)
            {
                classesList[e.RowIndex].name = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            }
        }

        string darknetFolderPath = null;
        private void buttonOpenProjectLocation_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fdialog = new FolderBrowserDialog();
            var results = fdialog.ShowDialog();
            if (results == DialogResult.OK && !string.IsNullOrWhiteSpace(fdialog.SelectedPath))
            {
                labelDarknetFolderPath.Text = "Path where to create Darknet folder: " + fdialog.SelectedPath;

                darknetFolderPath =fdialog.SelectedPath;
            }
        }
        private void createNamesFile(string path)
        {
            using (System.IO.StreamWriter file =
                           new System.IO.StreamWriter(path, true))
            {

                foreach (Classes cls in classesList)
                {
                    if (!string.IsNullOrWhiteSpace(cls.name))
                        file.WriteLine(cls.name);
                }
            }

        }

        private void createDataFile(string path)
        {
            using (System.IO.StreamWriter file =
                           new System.IO.StreamWriter(path, true))
            {
                file.WriteLine("classes= "+classesList.Count.ToString());
                file.WriteLine("train = data\\" + textBoxDataSetName.Text + "\\train.txt");
                file.WriteLine("valid = data\\" + textBoxDataSetName.Text + "\\val.txt");
                file.WriteLine("names = data\\" + textBoxDataSetName.Text +"\\"+ textBoxDataSetName.Text+ ".names");
                file.WriteLine("backup = backup\\" + textBoxDataSetName.Text);
            }

        }

        private void buttonGenerateConfigFiles_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(darknetFolderPath))
            {
                if (!string.IsNullOrWhiteSpace(textBoxDataSetName.Text))
                {
                    string nameFilePath = darknetFolderPath + "\\Darknet\\data\\" + textBoxDataSetName.Text+"\\"+textBoxDataSetName.Text + ".names";
                    string dataFilePath = darknetFolderPath + "\\Darknet\\data\\" + textBoxDataSetName.Text + "\\"+textBoxDataSetName.Text + ".data";
                    if (Directory.Exists(darknetFolderPath + "\\Darknet\\data\\"+ textBoxDataSetName.Text + "\\"))
                    {
                        createNamesFile(nameFilePath);
                    }
                    else
                    {
                        Directory.CreateDirectory(darknetFolderPath + "\\Darknet\\data\\"+textBoxDataSetName.Text + "\\");
                        createNamesFile(nameFilePath);
                        createDataFile(dataFilePath);
                    }
                }
            }
        }
    }
}
