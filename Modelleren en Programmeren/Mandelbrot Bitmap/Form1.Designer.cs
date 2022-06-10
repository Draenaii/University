namespace Mandelbrot_Bitmap
{
    partial class Mandelbrot
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Mandelbrot));
            this.MandelbrotPanel = new System.Windows.Forms.Panel();
            this.LabelXCoord = new System.Windows.Forms.Label();
            this.LabelYCoord = new System.Windows.Forms.Label();
            this.textBoxXCoord = new System.Windows.Forms.TextBox();
            this.textBoxYCoord = new System.Windows.Forms.TextBox();
            this.textBoxScale = new System.Windows.Forms.TextBox();
            this.Scale = new System.Windows.Forms.Label();
            this.labelMaxMandelbrot = new System.Windows.Forms.Label();
            this.textBoxMaxMandelbrot = new System.Windows.Forms.TextBox();
            this.buttonReset = new System.Windows.Forms.Button();
            this.buttonStart = new System.Windows.Forms.Button();
            this.buttonSSBW = new System.Windows.Forms.Button();
            this.buttonSSCrazy = new System.Windows.Forms.Button();
            this.buttonSSElectric = new System.Windows.Forms.Button();
            this.buttonSSMatrix = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.buttonSSSolar = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.buttonCOSolar = new System.Windows.Forms.Button();
            this.buttonCOMatrix = new System.Windows.Forms.Button();
            this.buttonCOEelectric = new System.Windows.Forms.Button();
            this.buttonCOCrazy = new System.Windows.Forms.Button();
            this.buttonCOBW = new System.Windows.Forms.Button();
            this.comboBoxGreen = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.comboBoxRed = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.comboBoxBlue = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // MandelbrotPanel
            // 
            this.MandelbrotPanel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.MandelbrotPanel.Location = new System.Drawing.Point(23, 25);
            this.MandelbrotPanel.Margin = new System.Windows.Forms.Padding(2);
            this.MandelbrotPanel.Name = "MandelbrotPanel";
            this.MandelbrotPanel.Size = new System.Drawing.Size(400, 400);
            this.MandelbrotPanel.TabIndex = 0;
            this.MandelbrotPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.BitmapPaint);
            this.MandelbrotPanel.MouseClick += new System.Windows.Forms.MouseEventHandler(this.MandelbrotPanel_MouseClick);
            // 
            // LabelXCoord
            // 
            this.LabelXCoord.AutoSize = true;
            this.LabelXCoord.Location = new System.Drawing.Point(487, 50);
            this.LabelXCoord.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.LabelXCoord.Name = "LabelXCoord";
            this.LabelXCoord.Size = new System.Drawing.Size(68, 13);
            this.LabelXCoord.TabIndex = 1;
            this.LabelXCoord.Text = "X-Coordinate";
            // 
            // LabelYCoord
            // 
            this.LabelYCoord.AutoSize = true;
            this.LabelYCoord.Location = new System.Drawing.Point(484, 74);
            this.LabelYCoord.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.LabelYCoord.Name = "LabelYCoord";
            this.LabelYCoord.Size = new System.Drawing.Size(68, 13);
            this.LabelYCoord.TabIndex = 2;
            this.LabelYCoord.Text = "Y-Coordinate";
            // 
            // textBoxXCoord
            // 
            this.textBoxXCoord.Location = new System.Drawing.Point(559, 47);
            this.textBoxXCoord.Margin = new System.Windows.Forms.Padding(2);
            this.textBoxXCoord.Name = "textBoxXCoord";
            this.textBoxXCoord.Size = new System.Drawing.Size(166, 20);
            this.textBoxXCoord.TabIndex = 3;
            this.textBoxXCoord.Text = "0.000000";
            // 
            // textBoxYCoord
            // 
            this.textBoxYCoord.Location = new System.Drawing.Point(559, 71);
            this.textBoxYCoord.Margin = new System.Windows.Forms.Padding(2);
            this.textBoxYCoord.Name = "textBoxYCoord";
            this.textBoxYCoord.Size = new System.Drawing.Size(166, 20);
            this.textBoxYCoord.TabIndex = 4;
            this.textBoxYCoord.Text = "0.000000";
            // 
            // textBoxScale
            // 
            this.textBoxScale.Location = new System.Drawing.Point(559, 110);
            this.textBoxScale.Margin = new System.Windows.Forms.Padding(2);
            this.textBoxScale.Name = "textBoxScale";
            this.textBoxScale.Size = new System.Drawing.Size(166, 20);
            this.textBoxScale.TabIndex = 5;
            this.textBoxScale.Text = "100";
            // 
            // Scale
            // 
            this.Scale.AutoSize = true;
            this.Scale.Location = new System.Drawing.Point(507, 113);
            this.Scale.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.Scale.Name = "Scale";
            this.Scale.Size = new System.Drawing.Size(45, 13);
            this.Scale.TabIndex = 6;
            this.Scale.Text = "Zoom %";
            // 
            // labelMaxMandelbrot
            // 
            this.labelMaxMandelbrot.AutoSize = true;
            this.labelMaxMandelbrot.Location = new System.Drawing.Point(429, 141);
            this.labelMaxMandelbrot.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelMaxMandelbrot.Name = "labelMaxMandelbrot";
            this.labelMaxMandelbrot.Size = new System.Drawing.Size(123, 13);
            this.labelMaxMandelbrot.TabIndex = 7;
            this.labelMaxMandelbrot.Text = "Max Mandelbrot Number";
            // 
            // textBoxMaxMandelbrot
            // 
            this.textBoxMaxMandelbrot.Location = new System.Drawing.Point(559, 137);
            this.textBoxMaxMandelbrot.Margin = new System.Windows.Forms.Padding(2);
            this.textBoxMaxMandelbrot.Name = "textBoxMaxMandelbrot";
            this.textBoxMaxMandelbrot.Size = new System.Drawing.Size(71, 20);
            this.textBoxMaxMandelbrot.TabIndex = 8;
            this.textBoxMaxMandelbrot.Text = "100";
            // 
            // buttonReset
            // 
            this.buttonReset.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonReset.Location = new System.Drawing.Point(660, 189);
            this.buttonReset.Margin = new System.Windows.Forms.Padding(2);
            this.buttonReset.Name = "buttonReset";
            this.buttonReset.Size = new System.Drawing.Size(65, 44);
            this.buttonReset.TabIndex = 9;
            this.buttonReset.Text = "Reset";
            this.buttonReset.UseVisualStyleBackColor = true;
            this.buttonReset.Click += new System.EventHandler(this.buttonReset_Click);
            // 
            // buttonStart
            // 
            this.buttonStart.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonStart.Location = new System.Drawing.Point(559, 189);
            this.buttonStart.Margin = new System.Windows.Forms.Padding(2);
            this.buttonStart.Name = "buttonStart";
            this.buttonStart.Size = new System.Drawing.Size(68, 44);
            this.buttonStart.TabIndex = 10;
            this.buttonStart.Text = "Start";
            this.buttonStart.UseVisualStyleBackColor = true;
            this.buttonStart.Click += new System.EventHandler(this.buttonStart_Click);
            // 
            // buttonSSBW
            // 
            this.buttonSSBW.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonSSBW.Location = new System.Drawing.Point(605, 283);
            this.buttonSSBW.Name = "buttonSSBW";
            this.buttonSSBW.Size = new System.Drawing.Size(75, 52);
            this.buttonSSBW.TabIndex = 11;
            this.buttonSSBW.Text = "Tripping";
            this.buttonSSBW.UseVisualStyleBackColor = true;
            this.buttonSSBW.Click += new System.EventHandler(this.buttonSSBW_Click);
            // 
            // buttonSSCrazy
            // 
            this.buttonSSCrazy.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonSSCrazy.Location = new System.Drawing.Point(686, 283);
            this.buttonSSCrazy.Name = "buttonSSCrazy";
            this.buttonSSCrazy.Size = new System.Drawing.Size(75, 52);
            this.buttonSSCrazy.TabIndex = 12;
            this.buttonSSCrazy.Text = "Crazy";
            this.buttonSSCrazy.UseVisualStyleBackColor = true;
            this.buttonSSCrazy.Click += new System.EventHandler(this.buttonSSCrazy_Click);
            // 
            // buttonSSElectric
            // 
            this.buttonSSElectric.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonSSElectric.Location = new System.Drawing.Point(443, 283);
            this.buttonSSElectric.Name = "buttonSSElectric";
            this.buttonSSElectric.Size = new System.Drawing.Size(75, 52);
            this.buttonSSElectric.TabIndex = 13;
            this.buttonSSElectric.Text = "Electric";
            this.buttonSSElectric.UseVisualStyleBackColor = true;
            this.buttonSSElectric.Click += new System.EventHandler(this.buttonSSElectric_Click);
            // 
            // buttonSSMatrix
            // 
            this.buttonSSMatrix.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonSSMatrix.Location = new System.Drawing.Point(767, 283);
            this.buttonSSMatrix.Name = "buttonSSMatrix";
            this.buttonSSMatrix.Size = new System.Drawing.Size(74, 52);
            this.buttonSSMatrix.TabIndex = 14;
            this.buttonSSMatrix.Text = "Matrix";
            this.buttonSSMatrix.UseVisualStyleBackColor = true;
            this.buttonSSMatrix.Click += new System.EventHandler(this.buttonSSMatrix_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(582, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(166, 20);
            this.label1.TabIndex = 15;
            this.label1.Text = "Mandelbrot Options";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(582, 260);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(110, 20);
            this.label2.TabIndex = 16;
            this.label2.Text = "Screenshots";
            // 
            // buttonSSSolar
            // 
            this.buttonSSSolar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonSSSolar.Location = new System.Drawing.Point(524, 283);
            this.buttonSSSolar.Name = "buttonSSSolar";
            this.buttonSSSolar.Size = new System.Drawing.Size(75, 52);
            this.buttonSSSolar.TabIndex = 17;
            this.buttonSSSolar.Text = "Solar Flare";
            this.buttonSSSolar.UseVisualStyleBackColor = true;
            this.buttonSSSolar.Click += new System.EventHandler(this.buttonSSSolar_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(582, 352);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(128, 20);
            this.label3.TabIndex = 18;
            this.label3.Text = "Colour Options";
            // 
            // buttonCOSolar
            // 
            this.buttonCOSolar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonCOSolar.Location = new System.Drawing.Point(524, 375);
            this.buttonCOSolar.Name = "buttonCOSolar";
            this.buttonCOSolar.Size = new System.Drawing.Size(75, 52);
            this.buttonCOSolar.TabIndex = 23;
            this.buttonCOSolar.Text = "Solar";
            this.buttonCOSolar.UseVisualStyleBackColor = true;
            this.buttonCOSolar.Click += new System.EventHandler(this.buttonCOSolar_Click);
            // 
            // buttonCOMatrix
            // 
            this.buttonCOMatrix.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonCOMatrix.Location = new System.Drawing.Point(767, 375);
            this.buttonCOMatrix.Name = "buttonCOMatrix";
            this.buttonCOMatrix.Size = new System.Drawing.Size(74, 52);
            this.buttonCOMatrix.TabIndex = 22;
            this.buttonCOMatrix.Text = "Matrix";
            this.buttonCOMatrix.UseVisualStyleBackColor = true;
            this.buttonCOMatrix.Click += new System.EventHandler(this.buttonCOMatrix_Click);
            // 
            // buttonCOEelectric
            // 
            this.buttonCOEelectric.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonCOEelectric.Location = new System.Drawing.Point(443, 375);
            this.buttonCOEelectric.Name = "buttonCOEelectric";
            this.buttonCOEelectric.Size = new System.Drawing.Size(75, 52);
            this.buttonCOEelectric.TabIndex = 21;
            this.buttonCOEelectric.Text = "Electric";
            this.buttonCOEelectric.UseVisualStyleBackColor = true;
            this.buttonCOEelectric.Click += new System.EventHandler(this.buttonCOEelectric_Click);
            // 
            // buttonCOCrazy
            // 
            this.buttonCOCrazy.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonCOCrazy.Location = new System.Drawing.Point(686, 375);
            this.buttonCOCrazy.Name = "buttonCOCrazy";
            this.buttonCOCrazy.Size = new System.Drawing.Size(75, 52);
            this.buttonCOCrazy.TabIndex = 20;
            this.buttonCOCrazy.Text = "Crazy";
            this.buttonCOCrazy.UseVisualStyleBackColor = true;
            this.buttonCOCrazy.Click += new System.EventHandler(this.buttonCOCrazy_Click);
            // 
            // buttonCOBW
            // 
            this.buttonCOBW.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonCOBW.Location = new System.Drawing.Point(605, 375);
            this.buttonCOBW.Name = "buttonCOBW";
            this.buttonCOBW.Size = new System.Drawing.Size(75, 52);
            this.buttonCOBW.TabIndex = 19;
            this.buttonCOBW.Text = "Black and White";
            this.buttonCOBW.UseVisualStyleBackColor = true;
            this.buttonCOBW.Click += new System.EventHandler(this.buttonCOBW_Click);
            // 
            // comboBoxGreen
            // 
            this.comboBoxGreen.FormattingEnabled = true;
            this.comboBoxGreen.Items.AddRange(new object[] {
            "0",
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10"});
            this.comboBoxGreen.Location = new System.Drawing.Point(747, 92);
            this.comboBoxGreen.Name = "comboBoxGreen";
            this.comboBoxGreen.Size = new System.Drawing.Size(71, 21);
            this.comboBoxGreen.TabIndex = 29;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(764, 77);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(36, 13);
            this.label6.TabIndex = 28;
            this.label6.Text = "Green";
            // 
            // comboBoxRed
            // 
            this.comboBoxRed.FormattingEnabled = true;
            this.comboBoxRed.Items.AddRange(new object[] {
            "0",
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10"});
            this.comboBoxRed.Location = new System.Drawing.Point(747, 50);
            this.comboBoxRed.Name = "comboBoxRed";
            this.comboBoxRed.Size = new System.Drawing.Size(71, 21);
            this.comboBoxRed.TabIndex = 31;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(764, 34);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(27, 13);
            this.label7.TabIndex = 30;
            this.label7.Text = "Red";
            // 
            // comboBoxBlue
            // 
            this.comboBoxBlue.FormattingEnabled = true;
            this.comboBoxBlue.Items.AddRange(new object[] {
            "0",
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10"});
            this.comboBoxBlue.Location = new System.Drawing.Point(747, 137);
            this.comboBoxBlue.Name = "comboBoxBlue";
            this.comboBoxBlue.Size = new System.Drawing.Size(71, 21);
            this.comboBoxBlue.TabIndex = 33;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(764, 121);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(28, 13);
            this.label8.TabIndex = 32;
            this.label8.Text = "Blue";
            // 
            // Mandelbrot
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(853, 441);
            this.Controls.Add(this.comboBoxBlue);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.comboBoxRed);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.comboBoxGreen);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.buttonCOSolar);
            this.Controls.Add(this.buttonCOMatrix);
            this.Controls.Add(this.buttonCOEelectric);
            this.Controls.Add(this.buttonCOCrazy);
            this.Controls.Add(this.buttonCOBW);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.buttonSSSolar);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonSSMatrix);
            this.Controls.Add(this.buttonSSElectric);
            this.Controls.Add(this.buttonSSCrazy);
            this.Controls.Add(this.buttonSSBW);
            this.Controls.Add(this.buttonStart);
            this.Controls.Add(this.buttonReset);
            this.Controls.Add(this.textBoxMaxMandelbrot);
            this.Controls.Add(this.labelMaxMandelbrot);
            this.Controls.Add(this.Scale);
            this.Controls.Add(this.textBoxScale);
            this.Controls.Add(this.textBoxYCoord);
            this.Controls.Add(this.textBoxXCoord);
            this.Controls.Add(this.LabelYCoord);
            this.Controls.Add(this.LabelXCoord);
            this.Controls.Add(this.MandelbrotPanel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Mandelbrot";
            this.Text = "Mandelbrot";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel MandelbrotPanel;
        private System.Windows.Forms.Label LabelXCoord;
        private System.Windows.Forms.Label LabelYCoord;
        private System.Windows.Forms.TextBox textBoxXCoord;
        private System.Windows.Forms.TextBox textBoxYCoord;
        private System.Windows.Forms.TextBox textBoxScale;
        private System.Windows.Forms.Label Scale;
        private System.Windows.Forms.Label labelMaxMandelbrot;
        private System.Windows.Forms.TextBox textBoxMaxMandelbrot;
        private System.Windows.Forms.Button buttonReset;
        private System.Windows.Forms.Button buttonStart;
        private System.Windows.Forms.Button buttonSSBW;
        private System.Windows.Forms.Button buttonSSCrazy;
        private System.Windows.Forms.Button buttonSSElectric;
        private System.Windows.Forms.Button buttonSSMatrix;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button buttonSSSolar;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button buttonCOSolar;
        private System.Windows.Forms.Button buttonCOMatrix;
        private System.Windows.Forms.Button buttonCOEelectric;
        private System.Windows.Forms.Button buttonCOCrazy;
        private System.Windows.Forms.Button buttonCOBW;
        private System.Windows.Forms.ComboBox comboBoxGreen;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox comboBoxRed;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox comboBoxBlue;
        private System.Windows.Forms.Label label8;
    }
}

