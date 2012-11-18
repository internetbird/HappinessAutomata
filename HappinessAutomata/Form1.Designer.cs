namespace HappinessAutomata
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lblAverageHappiness = new System.Windows.Forms.Label();
            this.lblCurrHappiness = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.lblGenerationNum = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtNumOfWomen = new System.Windows.Forms.TextBox();
            this.btnRunAutomata = new System.Windows.Forms.Button();
            this.btnGenerateBoard = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtNumOfMen = new System.Windows.Forms.TextBox();
            this.txtBoardSize = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cmbNumOfGenerations = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.cmbMaxCharDiff = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cmbEnableMemory = new System.Windows.Forms.ComboBox();
            this.cmbNeighbourhoodRadius = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.splitContainer1.Panel1.Controls.Add(this.groupBox2);
            this.splitContainer1.Panel1.Controls.Add(this.label3);
            this.splitContainer1.Panel1.Controls.Add(this.txtNumOfWomen);
            this.splitContainer1.Panel1.Controls.Add(this.btnRunAutomata);
            this.splitContainer1.Panel1.Controls.Add(this.btnGenerateBoard);
            this.splitContainer1.Panel1.Controls.Add(this.label2);
            this.splitContainer1.Panel1.Controls.Add(this.label1);
            this.splitContainer1.Panel1.Controls.Add(this.txtNumOfMen);
            this.splitContainer1.Panel1.Controls.Add(this.txtBoardSize);
            this.splitContainer1.Panel1.Controls.Add(this.groupBox1);
            this.splitContainer1.Size = new System.Drawing.Size(906, 746);
            this.splitContainer1.SplitterDistance = 143;
            this.splitContainer1.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lblAverageHappiness);
            this.groupBox2.Controls.Add(this.lblCurrHappiness);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.lblGenerationNum);
            this.groupBox2.Location = new System.Drawing.Point(473, 6);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(251, 123);
            this.groupBox2.TabIndex = 10;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Automata Status";
            // 
            // lblAverageHappiness
            // 
            this.lblAverageHappiness.AutoSize = true;
            this.lblAverageHappiness.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.lblAverageHappiness.Location = new System.Drawing.Point(142, 81);
            this.lblAverageHappiness.Name = "lblAverageHappiness";
            this.lblAverageHappiness.Size = new System.Drawing.Size(0, 17);
            this.lblAverageHappiness.TabIndex = 12;
            // 
            // lblCurrHappiness
            // 
            this.lblCurrHappiness.AutoSize = true;
            this.lblCurrHappiness.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.lblCurrHappiness.Location = new System.Drawing.Point(136, 54);
            this.lblCurrHappiness.Name = "lblCurrHappiness";
            this.lblCurrHappiness.Size = new System.Drawing.Size(0, 17);
            this.lblCurrHappiness.TabIndex = 11;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(7, 82);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(134, 13);
            this.label9.TabIndex = 10;
            this.label9.Text = "Average Happiness Score:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 55);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(128, 13);
            this.label8.TabIndex = 1;
            this.label8.Text = "Current Happiness Score:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(7, 28);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(87, 13);
            this.label7.TabIndex = 0;
            this.label7.Text = "Generation Num:";
            // 
            // lblGenerationNum
            // 
            this.lblGenerationNum.AutoSize = true;
            this.lblGenerationNum.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.lblGenerationNum.Location = new System.Drawing.Point(96, 26);
            this.lblGenerationNum.Name = "lblGenerationNum";
            this.lblGenerationNum.Size = new System.Drawing.Size(0, 17);
            this.lblGenerationNum.TabIndex = 9;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(174, 32);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(12, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "/";
            // 
            // txtNumOfWomen
            // 
            this.txtNumOfWomen.Location = new System.Drawing.Point(188, 28);
            this.txtNumOfWomen.Name = "txtNumOfWomen";
            this.txtNumOfWomen.Size = new System.Drawing.Size(27, 20);
            this.txtNumOfWomen.TabIndex = 6;
            this.txtNumOfWomen.Text = "50";
            // 
            // btnRunAutomata
            // 
            this.btnRunAutomata.Enabled = false;
            this.btnRunAutomata.Location = new System.Drawing.Point(746, 77);
            this.btnRunAutomata.Name = "btnRunAutomata";
            this.btnRunAutomata.Size = new System.Drawing.Size(124, 36);
            this.btnRunAutomata.TabIndex = 5;
            this.btnRunAutomata.Text = "Run Automata";
            this.btnRunAutomata.UseVisualStyleBackColor = true;
            this.btnRunAutomata.Click += new System.EventHandler(this.btnRunAutomata_Click);
            // 
            // btnGenerateBoard
            // 
            this.btnGenerateBoard.Location = new System.Drawing.Point(746, 32);
            this.btnGenerateBoard.Name = "btnGenerateBoard";
            this.btnGenerateBoard.Size = new System.Drawing.Size(124, 39);
            this.btnGenerateBoard.TabIndex = 0;
            this.btnGenerateBoard.Text = "Generate Board";
            this.btnGenerateBoard.UseVisualStyleBackColor = true;
            this.btnGenerateBoard.Click += new System.EventHandler(this.btnGenerateBoard_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 31);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(112, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Num Of Men/Women:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(98, 63);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(30, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Size:";
            // 
            // txtNumOfMen
            // 
            this.txtNumOfMen.Location = new System.Drawing.Point(145, 28);
            this.txtNumOfMen.Name = "txtNumOfMen";
            this.txtNumOfMen.Size = new System.Drawing.Size(27, 20);
            this.txtNumOfMen.TabIndex = 3;
            this.txtNumOfMen.Text = "50";
            // 
            // txtBoardSize
            // 
            this.txtBoardSize.Location = new System.Drawing.Point(145, 59);
            this.txtBoardSize.Name = "txtBoardSize";
            this.txtBoardSize.Size = new System.Drawing.Size(70, 20);
            this.txtBoardSize.TabIndex = 1;
            this.txtBoardSize.Text = "20";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cmbNumOfGenerations);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.cmbMaxCharDiff);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.cmbEnableMemory);
            this.groupBox1.Controls.Add(this.cmbNeighbourhoodRadius);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Location = new System.Drawing.Point(12, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(449, 125);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Automata Settings";
            // 
            // cmbNumOfGenerations
            // 
            this.cmbNumOfGenerations.FormattingEnabled = true;
            this.cmbNumOfGenerations.Items.AddRange(new object[] {
            "50",
            "60",
            "70",
            "80",
            "90",
            "100"});
            this.cmbNumOfGenerations.Location = new System.Drawing.Point(324, 84);
            this.cmbNumOfGenerations.Name = "cmbNumOfGenerations";
            this.cmbNumOfGenerations.Size = new System.Drawing.Size(101, 21);
            this.cmbNumOfGenerations.TabIndex = 13;
            this.cmbNumOfGenerations.Text = "50";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(212, 87);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(106, 13);
            this.label10.TabIndex = 12;
            this.label10.Text = "Num Of Generations:";
            // 
            // cmbMaxCharDiff
            // 
            this.cmbMaxCharDiff.FormattingEnabled = true;
            this.cmbMaxCharDiff.Items.AddRange(new object[] {
            "10",
            "20",
            "30",
            "40",
            "50",
            "100"});
            this.cmbMaxCharDiff.Location = new System.Drawing.Point(324, 52);
            this.cmbMaxCharDiff.Name = "cmbMaxCharDiff";
            this.cmbMaxCharDiff.Size = new System.Drawing.Size(101, 21);
            this.cmbMaxCharDiff.TabIndex = 11;
            this.cmbMaxCharDiff.Text = "10";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(220, 57);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(98, 13);
            this.label6.TabIndex = 10;
            this.label6.Text = "Max Character Diff:";
            // 
            // cmbEnableMemory
            // 
            this.cmbEnableMemory.FormattingEnabled = true;
            this.cmbEnableMemory.Items.AddRange(new object[] {
            "No",
            "Yes"});
            this.cmbEnableMemory.Location = new System.Drawing.Point(323, 20);
            this.cmbEnableMemory.Name = "cmbEnableMemory";
            this.cmbEnableMemory.Size = new System.Drawing.Size(102, 21);
            this.cmbEnableMemory.TabIndex = 9;
            this.cmbEnableMemory.Text = "No";
            // 
            // cmbNeighbourhoodRadius
            // 
            this.cmbNeighbourhoodRadius.FormattingEnabled = true;
            this.cmbNeighbourhoodRadius.Items.AddRange(new object[] {
            "1",
            "2"});
            this.cmbNeighbourhoodRadius.Location = new System.Drawing.Point(133, 84);
            this.cmbNeighbourhoodRadius.Name = "cmbNeighbourhoodRadius";
            this.cmbNeighbourhoodRadius.Size = new System.Drawing.Size(70, 21);
            this.cmbNeighbourhoodRadius.TabIndex = 6;
            this.cmbNeighbourhoodRadius.Text = "1";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(232, 24);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(83, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Enable Memory:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(5, 87);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(119, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Neighbourhood Radius:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(906, 746);
            this.Controls.Add(this.splitContainer1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "Happiness Automata";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Button btnGenerateBoard;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtNumOfMen;
        private System.Windows.Forms.TextBox txtBoardSize;
        private System.Windows.Forms.Button btnRunAutomata;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtNumOfWomen;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblGenerationNum;
        private System.Windows.Forms.ComboBox cmbMaxCharDiff;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cmbEnableMemory;
        private System.Windows.Forms.ComboBox cmbNeighbourhoodRadius;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label lblAverageHappiness;
        private System.Windows.Forms.Label lblCurrHappiness;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox cmbNumOfGenerations;

    }
}

