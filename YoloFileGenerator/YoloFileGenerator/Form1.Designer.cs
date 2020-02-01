namespace YoloFileGenerator
{
    partial class Form1
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.buttonOpenFolder = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBoxScanFolder = new System.Windows.Forms.GroupBox();
            this.buttonValOpenFolder = new System.Windows.Forms.Button();
            this.labelValFolderPath = new System.Windows.Forms.Label();
            this.labelFolderToScan = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.buttonGenerateFromNumber = new System.Windows.Forms.Button();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.labelStop = new System.Windows.Forms.Label();
            this.numericUpDownStart = new System.Windows.Forms.NumericUpDown();
            this.labelStartNumber = new System.Windows.Forms.Label();
            this.groupBoxGenConfigFiles = new System.Windows.Forms.GroupBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.numericUpDownNumberOfClasses = new System.Windows.Forms.NumericUpDown();
            this.textBoxDataSetName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBoxTrainingConfig = new System.Windows.Forms.GroupBox();
            this.labelDarknetFolderPath = new System.Windows.Forms.Label();
            this.buttonOpenProjectLocation = new System.Windows.Forms.Button();
            this.buttonGenerateConfigFiles = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBoxScanFolder.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownStart)).BeginInit();
            this.groupBoxGenConfigFiles.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownNumberOfClasses)).BeginInit();
            this.groupBoxTrainingConfig.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonOpenFolder
            // 
            this.buttonOpenFolder.Location = new System.Drawing.Point(447, 19);
            this.buttonOpenFolder.Name = "buttonOpenFolder";
            this.buttonOpenFolder.Size = new System.Drawing.Size(75, 23);
            this.buttonOpenFolder.TabIndex = 0;
            this.buttonOpenFolder.Text = "Open folder";
            this.buttonOpenFolder.UseVisualStyleBackColor = true;
            this.buttonOpenFolder.Click += new System.EventHandler(this.buttonOpenFolder_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.groupBoxScanFolder);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Location = new System.Drawing.Point(758, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(541, 254);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Generate \"train.txt\" \"Val.txt\" from image folder";
            // 
            // groupBoxScanFolder
            // 
            this.groupBoxScanFolder.Controls.Add(this.buttonValOpenFolder);
            this.groupBoxScanFolder.Controls.Add(this.labelValFolderPath);
            this.groupBoxScanFolder.Controls.Add(this.labelFolderToScan);
            this.groupBoxScanFolder.Controls.Add(this.buttonOpenFolder);
            this.groupBoxScanFolder.Location = new System.Drawing.Point(7, 20);
            this.groupBoxScanFolder.Name = "groupBoxScanFolder";
            this.groupBoxScanFolder.Size = new System.Drawing.Size(528, 132);
            this.groupBoxScanFolder.TabIndex = 1;
            this.groupBoxScanFolder.TabStop = false;
            this.groupBoxScanFolder.Text = "Scan Folder";
            // 
            // buttonValOpenFolder
            // 
            this.buttonValOpenFolder.Location = new System.Drawing.Point(447, 44);
            this.buttonValOpenFolder.Name = "buttonValOpenFolder";
            this.buttonValOpenFolder.Size = new System.Drawing.Size(75, 23);
            this.buttonValOpenFolder.TabIndex = 3;
            this.buttonValOpenFolder.Text = "Open folder";
            this.buttonValOpenFolder.UseVisualStyleBackColor = true;
            this.buttonValOpenFolder.Click += new System.EventHandler(this.buttonValOpenFolder_Click);
            // 
            // labelValFolderPath
            // 
            this.labelValFolderPath.AutoSize = true;
            this.labelValFolderPath.Location = new System.Drawing.Point(6, 49);
            this.labelValFolderPath.Name = "labelValFolderPath";
            this.labelValFolderPath.Size = new System.Drawing.Size(78, 13);
            this.labelValFolderPath.TabIndex = 2;
            this.labelValFolderPath.Text = "Val folder path:";
            // 
            // labelFolderToScan
            // 
            this.labelFolderToScan.AutoSize = true;
            this.labelFolderToScan.Location = new System.Drawing.Point(6, 24);
            this.labelFolderToScan.Name = "labelFolderToScan";
            this.labelFolderToScan.Size = new System.Drawing.Size(88, 13);
            this.labelFolderToScan.TabIndex = 1;
            this.labelFolderToScan.Text = "Train folder Path:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.buttonGenerateFromNumber);
            this.groupBox2.Controls.Add(this.numericUpDown1);
            this.groupBox2.Controls.Add(this.labelStop);
            this.groupBox2.Controls.Add(this.numericUpDownStart);
            this.groupBox2.Controls.Add(this.labelStartNumber);
            this.groupBox2.Location = new System.Drawing.Point(6, 158);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(523, 90);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Generate from number";
            // 
            // buttonGenerateFromNumber
            // 
            this.buttonGenerateFromNumber.Location = new System.Drawing.Point(167, 61);
            this.buttonGenerateFromNumber.Name = "buttonGenerateFromNumber";
            this.buttonGenerateFromNumber.Size = new System.Drawing.Size(75, 23);
            this.buttonGenerateFromNumber.TabIndex = 4;
            this.buttonGenerateFromNumber.Text = "Generate";
            this.buttonGenerateFromNumber.UseVisualStyleBackColor = true;
            this.buttonGenerateFromNumber.Click += new System.EventHandler(this.buttonGenerateFromNumber_Click);
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(178, 16);
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(77, 20);
            this.numericUpDown1.TabIndex = 3;
            // 
            // labelStop
            // 
            this.labelStop.AutoSize = true;
            this.labelStop.Location = new System.Drawing.Point(140, 19);
            this.labelStop.Name = "labelStop";
            this.labelStop.Size = new System.Drawing.Size(32, 13);
            this.labelStop.TabIndex = 2;
            this.labelStop.Text = "Stop:";
            // 
            // numericUpDownStart
            // 
            this.numericUpDownStart.Location = new System.Drawing.Point(45, 16);
            this.numericUpDownStart.Name = "numericUpDownStart";
            this.numericUpDownStart.Size = new System.Drawing.Size(77, 20);
            this.numericUpDownStart.TabIndex = 1;
            // 
            // labelStartNumber
            // 
            this.labelStartNumber.AutoSize = true;
            this.labelStartNumber.Location = new System.Drawing.Point(7, 20);
            this.labelStartNumber.Name = "labelStartNumber";
            this.labelStartNumber.Size = new System.Drawing.Size(32, 13);
            this.labelStartNumber.TabIndex = 0;
            this.labelStartNumber.Text = "Start:";
            // 
            // groupBoxGenConfigFiles
            // 
            this.groupBoxGenConfigFiles.Controls.Add(this.buttonGenerateConfigFiles);
            this.groupBoxGenConfigFiles.Controls.Add(this.buttonOpenProjectLocation);
            this.groupBoxGenConfigFiles.Controls.Add(this.labelDarknetFolderPath);
            this.groupBoxGenConfigFiles.Controls.Add(this.groupBoxTrainingConfig);
            this.groupBoxGenConfigFiles.Controls.Add(this.dataGridView1);
            this.groupBoxGenConfigFiles.Controls.Add(this.label2);
            this.groupBoxGenConfigFiles.Controls.Add(this.numericUpDownNumberOfClasses);
            this.groupBoxGenConfigFiles.Controls.Add(this.textBoxDataSetName);
            this.groupBoxGenConfigFiles.Controls.Add(this.label1);
            this.groupBoxGenConfigFiles.Location = new System.Drawing.Point(13, 12);
            this.groupBoxGenConfigFiles.Name = "groupBoxGenConfigFiles";
            this.groupBoxGenConfigFiles.Size = new System.Drawing.Size(739, 634);
            this.groupBoxGenConfigFiles.TabIndex = 2;
            this.groupBoxGenConfigFiles.TabStop = false;
            this.groupBoxGenConfigFiles.Text = "Generate config files";
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(473, 19);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(253, 214);
            this.dataGridView1.TabIndex = 4;
            this.dataGridView1.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellEndEdit);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(302, 30);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(98, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Number of Classes:";
            // 
            // numericUpDownNumberOfClasses
            // 
            this.numericUpDownNumberOfClasses.Location = new System.Drawing.Point(406, 28);
            this.numericUpDownNumberOfClasses.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numericUpDownNumberOfClasses.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownNumberOfClasses.Name = "numericUpDownNumberOfClasses";
            this.numericUpDownNumberOfClasses.Size = new System.Drawing.Size(61, 20);
            this.numericUpDownNumberOfClasses.TabIndex = 2;
            this.numericUpDownNumberOfClasses.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownNumberOfClasses.ValueChanged += new System.EventHandler(this.numericUpDownNumberOfClasses_ValueChanged);
            // 
            // textBoxDataSetName
            // 
            this.textBoxDataSetName.Location = new System.Drawing.Point(93, 27);
            this.textBoxDataSetName.Name = "textBoxDataSetName";
            this.textBoxDataSetName.Size = new System.Drawing.Size(164, 20);
            this.textBoxDataSetName.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "DataSet Name:";
            // 
            // groupBoxTrainingConfig
            // 
            this.groupBoxTrainingConfig.Controls.Add(this.label5);
            this.groupBoxTrainingConfig.Controls.Add(this.label4);
            this.groupBoxTrainingConfig.Controls.Add(this.label3);
            this.groupBoxTrainingConfig.Location = new System.Drawing.Point(7, 239);
            this.groupBoxTrainingConfig.Name = "groupBoxTrainingConfig";
            this.groupBoxTrainingConfig.Size = new System.Drawing.Size(726, 351);
            this.groupBoxTrainingConfig.TabIndex = 5;
            this.groupBoxTrainingConfig.TabStop = false;
            this.groupBoxTrainingConfig.Text = "Training configuration";
            // 
            // labelDarknetFolderPath
            // 
            this.labelDarknetFolderPath.AutoSize = true;
            this.labelDarknetFolderPath.Location = new System.Drawing.Point(7, 64);
            this.labelDarknetFolderPath.Name = "labelDarknetFolderPath";
            this.labelDarknetFolderPath.Size = new System.Drawing.Size(179, 13);
            this.labelDarknetFolderPath.TabIndex = 6;
            this.labelDarknetFolderPath.Text = "Path where to create Darknet folder:";
            // 
            // buttonOpenProjectLocation
            // 
            this.buttonOpenProjectLocation.Location = new System.Drawing.Point(392, 59);
            this.buttonOpenProjectLocation.Name = "buttonOpenProjectLocation";
            this.buttonOpenProjectLocation.Size = new System.Drawing.Size(75, 23);
            this.buttonOpenProjectLocation.TabIndex = 7;
            this.buttonOpenProjectLocation.Text = "Save folder";
            this.buttonOpenProjectLocation.UseVisualStyleBackColor = true;
            this.buttonOpenProjectLocation.Click += new System.EventHandler(this.buttonOpenProjectLocation_Click);
            // 
            // buttonGenerateConfigFiles
            // 
            this.buttonGenerateConfigFiles.Location = new System.Drawing.Point(584, 596);
            this.buttonGenerateConfigFiles.Name = "buttonGenerateConfigFiles";
            this.buttonGenerateConfigFiles.Size = new System.Drawing.Size(142, 32);
            this.buttonGenerateConfigFiles.TabIndex = 8;
            this.buttonGenerateConfigFiles.Text = "Generate Config Files";
            this.buttonGenerateConfigFiles.UseVisualStyleBackColor = true;
            this.buttonGenerateConfigFiles.Click += new System.EventHandler(this.buttonGenerateConfigFiles_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Location = new System.Drawing.Point(758, 273);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(541, 373);
            this.groupBox3.TabIndex = 3;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Generate .cmd File";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 22);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(69, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Batch Count:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(7, 49);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(99, 13);
            this.label4.TabIndex = 1;
            this.label4.Text = "Subdivisions count:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(7, 75);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(61, 13);
            this.label5.TabIndex = 2;
            this.label5.Text = "Max Batch:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1311, 658);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBoxGenConfigFiles);
            this.Controls.Add(this.groupBox1);
            this.Name = "Form1";
            this.Text = "USTV Yolo file gen";
            this.groupBox1.ResumeLayout(false);
            this.groupBoxScanFolder.ResumeLayout(false);
            this.groupBoxScanFolder.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownStart)).EndInit();
            this.groupBoxGenConfigFiles.ResumeLayout(false);
            this.groupBoxGenConfigFiles.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownNumberOfClasses)).EndInit();
            this.groupBoxTrainingConfig.ResumeLayout(false);
            this.groupBoxTrainingConfig.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonOpenFolder;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button buttonGenerateFromNumber;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.Label labelStop;
        private System.Windows.Forms.NumericUpDown numericUpDownStart;
        private System.Windows.Forms.Label labelStartNumber;
        private System.Windows.Forms.GroupBox groupBoxScanFolder;
        private System.Windows.Forms.Label labelFolderToScan;
        private System.Windows.Forms.Button buttonValOpenFolder;
        private System.Windows.Forms.Label labelValFolderPath;
        private System.Windows.Forms.GroupBox groupBoxGenConfigFiles;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown numericUpDownNumberOfClasses;
        private System.Windows.Forms.TextBox textBoxDataSetName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.GroupBox groupBoxTrainingConfig;
        private System.Windows.Forms.Button buttonOpenProjectLocation;
        private System.Windows.Forms.Label labelDarknetFolderPath;
        private System.Windows.Forms.Button buttonGenerateConfigFiles;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
    }
}

