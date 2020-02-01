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
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.labelStartNumber = new System.Windows.Forms.Label();
            this.numericUpDownStart = new System.Windows.Forms.NumericUpDown();
            this.labelStop = new System.Windows.Forms.Label();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.buttonGenerateFromNumber = new System.Windows.Forms.Button();
            this.groupBoxScanFolder = new System.Windows.Forms.GroupBox();
            this.labelFolderToScan = new System.Windows.Forms.Label();
            this.labelValFolderPath = new System.Windows.Forms.Label();
            this.buttonValOpenFolder = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownStart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.groupBoxScanFolder.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonOpenFolder
            // 
            this.buttonOpenFolder.Location = new System.Drawing.Point(333, 19);
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
            this.groupBox1.Location = new System.Drawing.Point(361, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(427, 254);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Generate \"train.txt\" \"Val.txt\"";
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
            this.groupBox2.Size = new System.Drawing.Size(415, 90);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Generate from number";
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
            // numericUpDownStart
            // 
            this.numericUpDownStart.Location = new System.Drawing.Point(45, 16);
            this.numericUpDownStart.Name = "numericUpDownStart";
            this.numericUpDownStart.Size = new System.Drawing.Size(77, 20);
            this.numericUpDownStart.TabIndex = 1;
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
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(178, 16);
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(77, 20);
            this.numericUpDown1.TabIndex = 3;
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
            // groupBoxScanFolder
            // 
            this.groupBoxScanFolder.Controls.Add(this.buttonValOpenFolder);
            this.groupBoxScanFolder.Controls.Add(this.labelValFolderPath);
            this.groupBoxScanFolder.Controls.Add(this.labelFolderToScan);
            this.groupBoxScanFolder.Controls.Add(this.buttonOpenFolder);
            this.groupBoxScanFolder.Location = new System.Drawing.Point(7, 20);
            this.groupBoxScanFolder.Name = "groupBoxScanFolder";
            this.groupBoxScanFolder.Size = new System.Drawing.Size(414, 132);
            this.groupBoxScanFolder.TabIndex = 1;
            this.groupBoxScanFolder.TabStop = false;
            this.groupBoxScanFolder.Text = "Scan Folder";
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
            // labelValFolderPath
            // 
            this.labelValFolderPath.AutoSize = true;
            this.labelValFolderPath.Location = new System.Drawing.Point(6, 49);
            this.labelValFolderPath.Name = "labelValFolderPath";
            this.labelValFolderPath.Size = new System.Drawing.Size(78, 13);
            this.labelValFolderPath.TabIndex = 2;
            this.labelValFolderPath.Text = "Val folder path:";
            // 
            // buttonValOpenFolder
            // 
            this.buttonValOpenFolder.Location = new System.Drawing.Point(333, 44);
            this.buttonValOpenFolder.Name = "buttonValOpenFolder";
            this.buttonValOpenFolder.Size = new System.Drawing.Size(75, 23);
            this.buttonValOpenFolder.TabIndex = 3;
            this.buttonValOpenFolder.Text = "Open folder";
            this.buttonValOpenFolder.UseVisualStyleBackColor = true;
            this.buttonValOpenFolder.Click += new System.EventHandler(this.buttonValOpenFolder_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.groupBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownStart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.groupBoxScanFolder.ResumeLayout(false);
            this.groupBoxScanFolder.PerformLayout();
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
    }
}

