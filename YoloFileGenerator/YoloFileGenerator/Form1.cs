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
        string dataFilePath;
        string nameFilePath;
        private void buttonGenerateConfigFiles_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(darknetFolderPath))
            {
                if (!string.IsNullOrWhiteSpace(textBoxDataSetName.Text))
                {
                    nameFilePath = darknetFolderPath + "\\Darknet\\data\\" + textBoxDataSetName.Text+"\\"+textBoxDataSetName.Text + ".names";
                    dataFilePath = darknetFolderPath + "\\Darknet\\data\\" + textBoxDataSetName.Text + "\\"+textBoxDataSetName.Text + ".data";
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


        private void buttonGenCmdFile_Click(object sender, EventArgs e)
        {
            string cmdPathFile;
            string cmdLineScript;
            string mode;
            bool useAbsolutePath = false; ;
            if(radioButtonCurrentConfig.Checked)
            {
                cmdPathFile = darknetFolderPath + "\\Darknet\\script\\" + textBoxDataSetName.Text+".cmd";
                useAbsolutePath = false;
            }
            else
            {
                useAbsolutePath = true;
            }
            double treshold=0.25;
            if(!string.IsNullOrWhiteSpace(textBoxDetectTreshold.Text))
            {
                treshold = Convert.ToDouble(textBoxDetectTreshold.Text);
            }
            string outputFileName=null;
            if (checkBoxExport.Checked)
            {
                outputFileName = textBoxOutputFileName.Text;
            }
            int gpuNum = (radioButtonGPU0.Checked) ? 0 : 1;
            string inputOpt = "-i";
            if (radioButtonUseInputFile.Checked)
                inputOpt = "-i";
            else
                inputOpt = "-c";

            bool multiGPUTrain = checkBoxTrainWithMultiGPU.Checked;
            int gpuTrainCount = numericUpDownTrainGPUCount.Value;
            switch(comboBoxTypeOfScript.SelectedIndex)
            {
                case 0://Training Script
                    break;
                case 1://Image detector
                    if (!string.IsNullOrEmpty(inputFilePath))
                    {
                        if (inputFilePath.Contains(".jpg") || inputFilePath.Contains(".png"))
                        {
                            mode = "test";
                            if (!string.IsNullOrEmpty(dataFilePath))
                            {
                                if (!string.IsNullOrWhiteSpace(weightsFilePath))
                                {
                                    cmdLineScript = MakeCommandLine(useAbsolutePath,mode, dataFilePath, inputOpt, inputFilePath, 
                                                                    weightsFilePath, "cfg\\" + textBoxDataSetName.Text + ".cfg", treshold, gpuNum, outputFileName, multiGPUTrain, gpuTrainCount);
                                }
                            }
                        }

                    }
                    break;
            }
        }

        public string MakeCommandLine(bool useAbsolutePath,string mode, string dataFilePath, string inputOpt, string inputFilePath, 
                                        string weightFilPathe, string cfgFileName, double treshold, int gpuNum, string outputFilename, bool multiGPUTrain, int GPUTrainCount)
        {
            string lineScript=null;
            if (useAbsolutePath)
            {
                lineScript = "..\\darknet.exe detector " + mode + " " + dataFilePath + " " + cfgFileName +
                                           " "+ weightFilPathe + " " + inputOpt + " " + gpuNum + " -tresh" + treshold.ToString("F2") + inputFilePath + " -ext_output";
            }
            else
            {

                string inputFileName=inputFilePath.Substring(inputFilePath.LastIndexOf('\\'));
                string weightFileName= weightFilPathe.Substring(weightFilPathe.LastIndexOf('\\'));
                string dataFileName = dataFilePath.Substring(dataFilePath.LastIndexOf('\\'));

                lineScript = "..\\darknet.exe detector ";
                lineScript += mode;
                if (mode == "training")
                {
                    lineScript+= " " + "data\\" + dataFileName + " " + cfgFileName +
                                           "Weights\\" + weightFileName;
                    if (multiGPUTrain)
                    {
                        lineScript += " -gpus 0";
                        if (GPUTrainCount > 3)
                            lineScript += ",1,2,3";
                        else if (GPUTrainCount > 2)
                            lineScript += ",1,2";
                        else if (GPUTrainCount > 1)
                            lineScript += ",1";
                    }
                }
                else
                {
                    lineScript +=" " + "data\\" + dataFileName + " " + cfgFileName +
                                           "Weights\\" + weightFileName + " " + inputOpt + " " + gpuNum;
                    if (inputOpt != "-c")
                    {
                        lineScript+= " -tresh" + treshold.ToString("F2");
                        lineScript += " " + inputFilePath + " -ext_output";
                        if (outputFilename != null)
                            lineScript += " -out_filename " + outputFilename;
                    }

                }
            } 

            return lineScript;
        }
        string weightsFilePath;
        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog dial = new OpenFileDialog();
            var result=dial.ShowDialog();
            if(result == DialogResult.OK && string.IsNullOrWhiteSpace(dial.FileName))
            {
                weightsFilePath = dial.FileName;
            }
        }
        string inputFilePath;
        private void buttonOpenFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog dial = new OpenFileDialog();
            var result = dial.ShowDialog();
            if (result == DialogResult.OK && string.IsNullOrWhiteSpace(dial.FileName))
            {
                inputFilePath = dial.FileName;
            }
        }
    }
}
