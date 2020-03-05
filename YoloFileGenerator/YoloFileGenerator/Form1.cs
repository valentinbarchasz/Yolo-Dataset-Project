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
            comboBoxTypeOfScript.SelectedIndex = 0;
            comboBoxYoloModel.SelectedIndex = 0;
            InitializeToolTipText();

        }

        private void InitializeToolTipText()
        {
            toolTip1.SetToolTip(this.labelBatchCount, "The GPU will process batch/subdivision number of images at any time, but the full batch or iteration would be complete only after all the 64 (as set above) images are processed.");
            toolTip1.SetToolTip(this.labelSubdivisions, "The GPU will process batch/subdivision number of images at any time, but the full batch or iteration would be complete only after all the 64 (as set above) images are processed.");
            toolTip1.SetToolTip(this.textBoxSubdivision, "The GPU will process batch/subdivision number of images at any time, but the full batch or iteration would be complete only after all the 64 (as set above) images are processed.");
            toolTip1.SetToolTip(this.textBoxBatchCount, "The GPU will process batch/subdivision number of images at any time, but the full batch or iteration would be complete only after all the 64 (as set above) images are processed.");
            toolTip1.SetToolTip(this.textBoxNetworkWidth, "network size (width), so every image will be resized to the network size during Training and Detection");
            toolTip1.SetToolTip(this.labelNetWidth, "network size (width), so every image will be resized to the network size during Training and Detection");
            toolTip1.SetToolTip(this.textBoxNetworkHeight, "network size (Height), so every image will be resized to the network size during Training and Detection");
            toolTip1.SetToolTip(this.labelNetHeight, "network size (Height), so every image will be resized to the network size during Training and Detection");

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
                    new System.IO.StreamWriter(fdialog.SelectedPath + "../train.txt", false))
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
                    new System.IO.StreamWriter(fdialog.SelectedPath + "../val.txt", false))
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
                           new System.IO.StreamWriter(path, false))
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
                           new System.IO.StreamWriter(path, false))
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
                        createDataFile(dataFilePath);
                    }
                    else
                    {
                        Directory.CreateDirectory(darknetFolderPath + "\\Darknet\\data\\"+textBoxDataSetName.Text + "\\");
                        createNamesFile(nameFilePath);
                        createDataFile(dataFilePath);
                    }
                    //On vient recuperer toutes les options de configuration de training
                    int batchCount = Convert.ToInt32(textBoxBatchCount.Text);
                    int subdivision = Convert.ToInt32(textBoxSubdivision.Text);
                    int maxBatch = 2000;
                    string learningRate = textBoxLearningRate.Text;
                    double learningrate = 0;
                    int steps80 = 1600;
                    int steps90 = 1800;
                    int netSizeWidth = 416;
                    int netSizeHeight = 416;
                    int channels = 3;           //By default use RGB Images
                    bool randomizeResolution = checkBoxRandomResolution.Checked;
                    bool distinguishLeftRightObj = checkBoxFlip.Checked;
                    bool trainSmallObject = checkBoxTrainSmallObjects.Checked;
                    bool trainLotOfObj = checkBoxTrainLotObj.Checked;
                    int filters = (int)Math.Min((numericUpDownNumberOfClasses.Value + 5) * 3,255);
                    bool useYoloTiny = false;
                    bool useStandardYoloV3 = false;
                    if (learningRate.Contains('.'))
                    {
                        learningrate=Convert.ToDouble(learningRate.Replace('.', ','));
                    }
                    else
                    {
                        learningrate = Convert.ToDouble(learningRate);
                    }

                    if(checkBoxStepsAuto.Checked)
                    {
                        steps80 = (int)(0.8 * maxBatch);
                        steps90 = (int)(0.9 * maxBatch);
                    }
                    else
                    {
                        string[] strTab = textBoxSteps.Text.Split(',');
                        steps80 = Convert.ToInt32(strTab[0]);
                        steps90 = Convert.ToInt32(strTab[1]);
                    }
                    netSizeWidth = Convert.ToInt32(textBoxNetworkWidth.Text);
                    netSizeHeight = Convert.ToInt32(textBoxNetworkHeight.Text);
                    
                    if(checkBoxBatchAuto.Checked)
                    {
                        maxBatch = (int)numericUpDownNumberOfClasses.Value * 2000;
                    }
                    else
                    {
                        maxBatch = Convert.ToInt32(textBoxMaxBatch.Text);
                    }

                    string modelDefaultCfgPath = @"../../DefaultCFGFiles/yolov3.cfg";
                    //On vient lire le fichier model en fonction de la selection
                    switch (comboBoxYoloModel.SelectedText)
                    {
                        case "YoloV3": modelDefaultCfgPath = @"../../DefaultCFGFiles/yolov3.cfg"; useYoloTiny = false; useStandardYoloV3 = true; break;
                        case "YoloV3-Tiny": modelDefaultCfgPath = @"../../DefaultCFGFiles/yolov3-tiny.cfg"; useYoloTiny = true; break;
                        case "YoloV3-Tiny-PRN": modelDefaultCfgPath = @"../../DefaultCFGFiles/yolov3.cfg"; useYoloTiny = true; break;
                        case "YoloV3-SPP": modelDefaultCfgPath = @"../../DefaultCFGFiles/yolov3-spp.cfg"; useYoloTiny = false; break;
                        case "csresnext50-panet-spp": modelDefaultCfgPath = @"../../DefaultCFGFiles/yolov3.cfg"; break;
                    }
                    StreamReader defaultConfigFileStream = new StreamReader(modelDefaultCfgPath);
                    List<string> cfgFileLineList = new List<string>();
                    string line;
                    //On copie la totalité du fichier cfg
                    while((line=defaultConfigFileStream.ReadLine())!=null)
                    {
                        cfgFileLineList.Add(line);
                    }

                    //On modifie le fichier original
                    cfgFileLineList[3-1] = "batch= " + batchCount.ToString();
                    cfgFileLineList[4 - 1] = "subdivisions= " + subdivision.ToString();
                    cfgFileLineList[10 - 1] = "channels=" + channels.ToString();
                    cfgFileLineList[20 - 1] = "max_batches= " + maxBatch.ToString();
                    cfgFileLineList[22 - 1] = "steps=" + steps80.ToString()+" "+ steps90.ToString();
                    cfgFileLineList[8 - 1] = "width=" + netSizeWidth.ToString();
                    cfgFileLineList[9 - 1] = "height=" + netSizeWidth.ToString();
                    cfgFileLineList[17 - 1] = (distinguishLeftRightObj) ? "flip=" : "";

                    //Modifie Filters and classes for each Yolo Layer
                    if (!useYoloTiny)
                    {
                        if (useStandardYoloV3)
                        {
                            //Layer 1
                            cfgFileLineList[603 - 1] = "filters=" + filters.ToString();
                            cfgFileLineList[610 - 1] = "classes=" + numericUpDownNumberOfClasses.Value.ToString();
                            //Layer 2
                            cfgFileLineList[689 - 1] = "filters=" + filters.ToString();
                            cfgFileLineList[696 - 1] = "classes=" + numericUpDownNumberOfClasses.Value.ToString();
                            //Layer 3
                            cfgFileLineList[776 - 1] = "filters=" + filters.ToString();
                            cfgFileLineList[783 - 1] = "classes=" + numericUpDownNumberOfClasses.Value.ToString();

                            if (trainSmallObject)
                            {
                                cfgFileLineList[717 - 1] = "strides=4";     //Original : strides=2
                                cfgFileLineList[720 - 1] = "layers = -1, 11";     //Original layers = -1, 36
                            }
                            cfgFileLineList[788 - 1] = "random=" + ((randomizeResolution) ? "1" : "0");
                            if (trainLotOfObj)
                            {
                                cfgFileLineList[789 - 1] = "max=200";
                            }
                        }
                    }
                    else
                    {
                        //Layer 1
                        cfgFileLineList[127 - 1] = "filters=" + filters.ToString();
                        cfgFileLineList[135 - 1] = "classes=" + numericUpDownNumberOfClasses.Value.ToString();
                        //Layer 2
                        cfgFileLineList[171 - 1] = "filters=" + filters.ToString();
                        cfgFileLineList[177 - 1] = "classes=" + numericUpDownNumberOfClasses.Value.ToString();

                        if (trainSmallObject)
                        {
                            cfgFileLineList[154 - 1] = "strides=4";     //Original : strides=2
                            cfgFileLineList[157 - 1] = "layers = -1, 2";     //Original layers = -1, 8
                        }
                        cfgFileLineList[182 - 1] = "random=" + ((randomizeResolution) ? "1" : "0");
                        if (trainLotOfObj)
                        {
                            cfgFileLineList[183 - 1] = "max=200";
                        }
                    }

                    if (Directory.Exists(darknetFolderPath + "\\Darknet\\cfg\\" ))
                    {

                    }
                    else
                    {
                        Directory.CreateDirectory(darknetFolderPath + "\\Darknet\\cfg\\" );
                    }

                    //On creer le fichier et ecrit son contenu
                    using (System.IO.StreamWriter file =
                                  new System.IO.StreamWriter(darknetFolderPath + "\\Darknet\\cfg\\"+ textBoxDataSetName.Text+".cfg", false))
                    {
                        foreach(string lne in cfgFileLineList)
                        {
                            file.WriteLine(lne);
                        }
                    }
                }
            }
        }


        private void buttonGenCmdFile_Click(object sender, EventArgs e)
        {
            string cmdPathFile=null;
            string cmdLineScript=null;
            string mode="test";
            bool useAbsolutePath = false; ;
            if(radioButtonCurrentConfig.Checked)
            {
                cmdPathFile = darknetFolderPath + "\\Darknet\\script\\" + textBoxDataSetName.Text+".cmd";
                useAbsolutePath = false;
            }
            else
            {
                SaveFileDialog dial = new SaveFileDialog();
                dial.Filter = "CMD file|*.cmd";
                var result = dial.ShowDialog();
                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(dial.FileName))
                    cmdPathFile = dial.FileName;
                useAbsolutePath = true;
            }
            double treshold=0.25;
            if(!string.IsNullOrWhiteSpace(textBoxDetectTreshold.Text))
            {
                if(textBoxDetectTreshold.Text.Contains('.'))
                {
                    treshold = Convert.ToDouble(textBoxDetectTreshold.Text.Replace('.',','));
                }
                else
                {
                    treshold = Convert.ToDouble(textBoxDetectTreshold.Text);
                }
                
            }
            string outputFileName=null;
            if (checkBoxExport.Checked)
            {
                outputFileName = textBoxOutputFileName.Text;
            }
            int gpuNum = (radioButtonGPU0.Checked) ? 0 : 1;
            string inputOpt = "-i";
            if (radioButtonUseInputFile.Checked)
            {
                inputOpt = "-i";
                if (!string.IsNullOrEmpty(inputFilePath))
                {
                    if (inputFilePath.Contains(".jpg") || inputFilePath.Contains(".png"))
                    {
                        mode = "test";
                    }
                    else if (inputFilePath.Contains(".avi") || inputFilePath.Contains(".mp4"))
                    {
                        mode = "demo";
                    }
                }

            }
            else
            {
                inputOpt = "-c";
                mode = "demo";
            }

            bool multiGPUTrain = checkBoxTrainWithMultiGPU.Checked;
            int gpuTrainCount =(int) numericUpDownTrainGPUCount.Value;
            switch(comboBoxTypeOfScript.SelectedIndex)
            {
                case 0://Training Script
                    mode = "train";
                    if (!string.IsNullOrEmpty(dataFilePath))
                    {
                        if (!string.IsNullOrWhiteSpace(weightsFilePath))
                        {
                            cmdLineScript = MakeCommandLine(useAbsolutePath, mode, dataFilePath, inputOpt, inputFilePath,
                                                            weightsFilePath, "cfg\\" + textBoxDataSetName.Text + ".cfg", treshold, gpuNum, outputFileName, multiGPUTrain, gpuTrainCount);
                        }
                        else
                        {
                            var result = MessageBox.Show("Erreur, Must Select Weights File Before generate .cmd File");

                        }
                    }
                    else
                    {
                        if (radioButtonCurrentConfig.Checked)
                        {
                            var result = MessageBox.Show("Erreur, Must Generate Config File Before generate .cmd File");
                        }
                        else
                        {
                            OpenFileDialog dial = new OpenFileDialog();
                            dial.Filter = "Data File|*.data";
                            var result = dial.ShowDialog();

                            if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(dial.FileName))
                            {
                                dataFilePath = dial.FileName;
                            }
                        }
                    }
                    break;
                case 1://Image/Video detector
                    if (!string.IsNullOrEmpty(dataFilePath))
                    {
                        if (!string.IsNullOrWhiteSpace(weightsFilePath))
                        {
                            cmdLineScript = MakeCommandLine(useAbsolutePath, mode, dataFilePath, inputOpt, inputFilePath,
                                                            weightsFilePath, "cfg\\" + textBoxDataSetName.Text + ".cfg", treshold, gpuNum, outputFileName, multiGPUTrain, gpuTrainCount);
                        }
                        else
                        {
                            var result = MessageBox.Show("Erreur, Must Select Weights File Before generate .cmd File");

                        }
                    }
                    else
                    {
                        if (radioButtonCurrentConfig.Checked)
                        {
                            var result = MessageBox.Show("Erreur, Must Generate Config File Before generate .cmd File");
                        }
                        else
                        {
                            OpenFileDialog dial = new OpenFileDialog();
                            dial.Filter = "Data File|*.data";
                            var result = dial.ShowDialog();

                            if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(dial.FileName))
                            {
                                dataFilePath = dial.FileName;
                            }
                        }
                    }
                    break;
            }
            if (!useAbsolutePath)
            {
                //On verifie si le dossier script existe
                if (Directory.Exists(darknetFolderPath + "\\Darknet\\script\\"))
                {

                }
                else
                {
                    Directory.CreateDirectory(darknetFolderPath + "\\Darknet\\script\\");

                }
            }
            if(!string.IsNullOrWhiteSpace(cmdPathFile))
            {
                //On creer le fichier et ecrit la ligne de commande
                using (System.IO.StreamWriter file =
                              new System.IO.StreamWriter(cmdPathFile, false))
                {
                    if (!string.IsNullOrWhiteSpace(cmdLineScript))
                    {
                        file.WriteLine(cmdLineScript);
                        file.WriteLine();
                        file.WriteLine("pause");
                    }
                    
                }
            }
            
        }

        public string MakeCommandLine(bool useAbsolutePath,string mode, string dataFilePath, string inputOpt, string inputFilePath, 
                                        string weightFilPath, string cfgFilePath, double treshold, int gpuNum, string outputFilename, bool multiGPUTrain, int GPUTrainCount)
        {
            string lineScript=null;
            if (useAbsolutePath)
            {
                lineScript = "..\\darknet.exe detector " + mode;
                lineScript += " " + dataFilePath + " " + cfgFilePath +
                       " " + weightFilPath;
                if (mode == "train")
                {
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
                    lineScript +=" " + inputOpt + " " + gpuNum;
                    if (inputOpt != "-c")
                    {
                        lineScript += " -tresh " + treshold.ToString("F2").Replace(',', '.');
                        lineScript += " " + inputFilePath + " -ext_output";
                        if (outputFilename != null)
                            lineScript += " -out_filename " + outputFilename;
                    }
                }
            }
            else
            {

                string inputFileName = null; 
                string weightFileName= weightFilPath.Substring(weightFilPath.LastIndexOf('\\')).Remove(0, 1);
                string dataFileName = dataFilePath.Substring(dataFilePath.LastIndexOf('\\')).Remove(0, 1);
                 
                lineScript = "..\\darknet.exe detector ";
                lineScript += mode;
                lineScript += " " + "data\\" + dataFileName + " " + cfgFilePath +
                                           " Weights\\" + weightFileName;
                if (mode == "train")
                {
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
                    inputFileName= inputFilePath.Substring(inputFilePath.LastIndexOf('\\')).Remove(0, 1);
                    lineScript += " " + inputOpt + " " + gpuNum;
                    if (inputOpt != "-c")
                    {
                        lineScript+= " -tresh " + treshold.ToString("F2").Replace(',','.');
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
            dial.Filter = "Weights File|*.weights";
            var result=dial.ShowDialog();
            
            if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(dial.FileName))
            {
                weightsFilePath = dial.FileName;
                labelWeightFilePath.Text = "Weights File:" + weightsFilePath;
            }
        }

        string inputFilePath;
        private void buttonOpenFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog dial = new OpenFileDialog();
            dial.Filter = "Images Files|*.jpg;*.png" +
             "|Video Files|*.avi;*.mp4";
            var result = dial.ShowDialog();
            
            if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(dial.FileName))
            {
                inputFilePath = dial.FileName;
                labelInputFile.Text = "Input File: " + inputFilePath;
            }
        }
    }
}
