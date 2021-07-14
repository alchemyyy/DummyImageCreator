namespace DummyImageCreator
{
    partial class RegionMaker
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
            this.components = new System.ComponentModel.Container();
            this.textBox_startAddress = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox_endAddress = new System.Windows.Forms.TextBox();
            this.checkBox_startAtClosestBoundary = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label8 = new System.Windows.Forms.Label();
            this.numericUpDown_checkerboardSize = new System.Windows.Forms.NumericUpDown();
            this.checkBox_checkerboard = new System.Windows.Forms.CheckBox();
            this.radioButton_patternTypeUserDefinedFile = new System.Windows.Forms.RadioButton();
            this.radioButton_patternTypeUserDefined = new System.Windows.Forms.RadioButton();
            this.radioButton_patternTypeRepeat = new System.Windows.Forms.RadioButton();
            this.radioButton_patternTypeRandom = new System.Windows.Forms.RadioButton();
            this.button_save = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox_length = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.richTextBox_userDefinedData = new System.Windows.Forms.RichTextBox();
            this.textBox_userDefinedFileLocation = new System.Windows.Forms.TextBox();
            this.button_browseForUserDefinedFile = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.toolTip_regionMaker = new System.Windows.Forms.ToolTip(this.components);
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_checkerboardSize)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBox_startAddress
            // 
            this.textBox_startAddress.Location = new System.Drawing.Point(12, 32);
            this.textBox_startAddress.Name = "textBox_startAddress";
            this.textBox_startAddress.Size = new System.Drawing.Size(184, 20);
            this.textBox_startAddress.TabIndex = 0;
            this.textBox_startAddress.KeyUp += new System.Windows.Forms.KeyEventHandler(this.textBox_startAddress_KeyUp);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(141, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Start Index (0h 0d 0k 0m 0g)";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(213, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(138, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "End Index (0h 0d 0k 0m 0g)";
            // 
            // textBox_endAddress
            // 
            this.textBox_endAddress.Location = new System.Drawing.Point(213, 32);
            this.textBox_endAddress.Name = "textBox_endAddress";
            this.textBox_endAddress.Size = new System.Drawing.Size(181, 20);
            this.textBox_endAddress.TabIndex = 2;
            this.textBox_endAddress.KeyUp += new System.Windows.Forms.KeyEventHandler(this.textBox_endAddress_KeyUp);
            // 
            // checkBox_startAtClosestBoundary
            // 
            this.checkBox_startAtClosestBoundary.AutoSize = true;
            this.checkBox_startAtClosestBoundary.Location = new System.Drawing.Point(12, 58);
            this.checkBox_startAtClosestBoundary.Name = "checkBox_startAtClosestBoundary";
            this.checkBox_startAtClosestBoundary.Size = new System.Drawing.Size(143, 17);
            this.checkBox_startAtClosestBoundary.TabIndex = 4;
            this.checkBox_startAtClosestBoundary.Text = "Start at closest boundary";
            this.checkBox_startAtClosestBoundary.UseVisualStyleBackColor = true;
            this.checkBox_startAtClosestBoundary.CheckedChanged += new System.EventHandler(this.checkBox_startAtClosestBoundary_CheckedChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.numericUpDown_checkerboardSize);
            this.groupBox1.Controls.Add(this.checkBox_checkerboard);
            this.groupBox1.Controls.Add(this.radioButton_patternTypeUserDefinedFile);
            this.groupBox1.Controls.Add(this.radioButton_patternTypeUserDefined);
            this.groupBox1.Controls.Add(this.radioButton_patternTypeRepeat);
            this.groupBox1.Controls.Add(this.radioButton_patternTypeRandom);
            this.groupBox1.Location = new System.Drawing.Point(12, 81);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(184, 182);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Pattern Type";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 158);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(30, 13);
            this.label8.TabIndex = 15;
            this.label8.Text = "Size:";
            // 
            // numericUpDown_checkerboardSize
            // 
            this.numericUpDown_checkerboardSize.Increment = new decimal(new int[] {
            5,
            0,
            0,
            65536});
            this.numericUpDown_checkerboardSize.Location = new System.Drawing.Point(42, 156);
            this.numericUpDown_checkerboardSize.Maximum = new decimal(new int[] {
            -1,
            -1,
            -1,
            0});
            this.numericUpDown_checkerboardSize.Name = "numericUpDown_checkerboardSize";
            this.numericUpDown_checkerboardSize.Size = new System.Drawing.Size(136, 20);
            this.numericUpDown_checkerboardSize.TabIndex = 16;
            // 
            // checkBox_checkerboard
            // 
            this.checkBox_checkerboard.AutoSize = true;
            this.checkBox_checkerboard.Location = new System.Drawing.Point(6, 133);
            this.checkBox_checkerboard.Name = "checkBox_checkerboard";
            this.checkBox_checkerboard.Size = new System.Drawing.Size(93, 17);
            this.checkBox_checkerboard.TabIndex = 15;
            this.checkBox_checkerboard.Text = "Checkerboard";
            this.checkBox_checkerboard.UseVisualStyleBackColor = true;
            this.checkBox_checkerboard.CheckedChanged += new System.EventHandler(this.checkBox_checkerboard_CheckedChanged);
            // 
            // radioButton_patternTypeUserDefinedFile
            // 
            this.radioButton_patternTypeUserDefinedFile.AutoSize = true;
            this.radioButton_patternTypeUserDefinedFile.Location = new System.Drawing.Point(6, 96);
            this.radioButton_patternTypeUserDefinedFile.Name = "radioButton_patternTypeUserDefinedFile";
            this.radioButton_patternTypeUserDefinedFile.Size = new System.Drawing.Size(106, 17);
            this.radioButton_patternTypeUserDefinedFile.TabIndex = 7;
            this.radioButton_patternTypeUserDefinedFile.Text = "User-Defined File";
            this.radioButton_patternTypeUserDefinedFile.UseVisualStyleBackColor = true;
            // 
            // radioButton_patternTypeUserDefined
            // 
            this.radioButton_patternTypeUserDefined.AutoSize = true;
            this.radioButton_patternTypeUserDefined.Location = new System.Drawing.Point(6, 73);
            this.radioButton_patternTypeUserDefined.Name = "radioButton_patternTypeUserDefined";
            this.radioButton_patternTypeUserDefined.Size = new System.Drawing.Size(87, 17);
            this.radioButton_patternTypeUserDefined.TabIndex = 6;
            this.radioButton_patternTypeUserDefined.Text = "User-Defined";
            this.radioButton_patternTypeUserDefined.UseVisualStyleBackColor = true;
            // 
            // radioButton_patternTypeRepeat
            // 
            this.radioButton_patternTypeRepeat.AutoSize = true;
            this.radioButton_patternTypeRepeat.Location = new System.Drawing.Point(6, 50);
            this.radioButton_patternTypeRepeat.Name = "radioButton_patternTypeRepeat";
            this.radioButton_patternTypeRepeat.Size = new System.Drawing.Size(102, 17);
            this.radioButton_patternTypeRepeat.TabIndex = 4;
            this.radioButton_patternTypeRepeat.Text = "Repeat (00 - FF)";
            this.radioButton_patternTypeRepeat.UseVisualStyleBackColor = true;
            // 
            // radioButton_patternTypeRandom
            // 
            this.radioButton_patternTypeRandom.AutoSize = true;
            this.radioButton_patternTypeRandom.Checked = true;
            this.radioButton_patternTypeRandom.Location = new System.Drawing.Point(6, 26);
            this.radioButton_patternTypeRandom.Name = "radioButton_patternTypeRandom";
            this.radioButton_patternTypeRandom.Size = new System.Drawing.Size(134, 17);
            this.radioButton_patternTypeRandom.TabIndex = 2;
            this.radioButton_patternTypeRandom.TabStop = true;
            this.radioButton_patternTypeRandom.Text = "Random (WELL19937)";
            this.radioButton_patternTypeRandom.UseVisualStyleBackColor = true;
            // 
            // button_save
            // 
            this.button_save.Location = new System.Drawing.Point(213, 116);
            this.button_save.Name = "button_save";
            this.button_save.Size = new System.Drawing.Size(181, 47);
            this.button_save.TabIndex = 7;
            this.button_save.Text = "Save";
            this.button_save.UseVisualStyleBackColor = true;
            this.button_save.Click += new System.EventHandler(this.button_save_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(213, 59);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(123, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Length (0h 0d 0k 0m 0g)";
            // 
            // textBox_length
            // 
            this.textBox_length.Location = new System.Drawing.Point(213, 75);
            this.textBox_length.Name = "textBox_length";
            this.textBox_length.Size = new System.Drawing.Size(181, 20);
            this.textBox_length.TabIndex = 8;
            this.textBox_length.KeyUp += new System.Windows.Forms.KeyEventHandler(this.textBox_length_KeyUp);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(247, 98);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(150, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "*Use either endAddr or Length";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.richTextBox_userDefinedData);
            this.groupBox2.Controls.Add(this.textBox_userDefinedFileLocation);
            this.groupBox2.Location = new System.Drawing.Point(9, 269);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(385, 182);
            this.groupBox2.TabIndex = 11;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "User-Defined Data (Provide either byte-style text (00 12 14 A3 etc.)) or a file";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(3, 141);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(67, 13);
            this.label5.TabIndex = 12;
            this.label5.Text = "File Location";
            // 
            // richTextBox_userDefinedData
            // 
            this.richTextBox_userDefinedData.Font = new System.Drawing.Font("Lucida Console", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.richTextBox_userDefinedData.Location = new System.Drawing.Point(3, 19);
            this.richTextBox_userDefinedData.Name = "richTextBox_userDefinedData";
            this.richTextBox_userDefinedData.Size = new System.Drawing.Size(372, 119);
            this.richTextBox_userDefinedData.TabIndex = 1;
            this.richTextBox_userDefinedData.Text = "";
            this.richTextBox_userDefinedData.TextChanged += new System.EventHandler(this.richTextBox_userDefinedData_TextChanged);
            // 
            // textBox_userDefinedFileLocation
            // 
            this.textBox_userDefinedFileLocation.Location = new System.Drawing.Point(6, 157);
            this.textBox_userDefinedFileLocation.Name = "textBox_userDefinedFileLocation";
            this.textBox_userDefinedFileLocation.Size = new System.Drawing.Size(370, 20);
            this.textBox_userDefinedFileLocation.TabIndex = 0;
            this.textBox_userDefinedFileLocation.TextChanged += new System.EventHandler(this.textBox_userDefinedFileLocation_TextChanged);
            // 
            // button_browseForUserDefinedFile
            // 
            this.button_browseForUserDefinedFile.Location = new System.Drawing.Point(213, 169);
            this.button_browseForUserDefinedFile.Name = "button_browseForUserDefinedFile";
            this.button_browseForUserDefinedFile.Size = new System.Drawing.Size(181, 47);
            this.button_browseForUserDefinedFile.TabIndex = 12;
            this.button_browseForUserDefinedFile.Text = "Browse For User-Defined File";
            this.button_browseForUserDefinedFile.UseVisualStyleBackColor = true;
            this.button_browseForUserDefinedFile.Click += new System.EventHandler(this.button_browseForUserDefinedFile_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(220, 226);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(165, 13);
            this.label6.TabIndex = 13;
            this.label6.Text = "*all patterns/data will be repeated";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(223, 239);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(110, 13);
            this.label7.TabIndex = 14;
            this.label7.Text = "until the region is filled";
            // 
            // RegionMaker
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(406, 457);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.button_browseForUserDefinedFile);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBox_length);
            this.Controls.Add(this.button_save);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.checkBox_startAtClosestBoundary);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBox_endAddress);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox_startAddress);
            this.MaximumSize = new System.Drawing.Size(422, 496);
            this.MinimumSize = new System.Drawing.Size(422, 496);
            this.Name = "RegionMaker";
            this.Text = "RegionMaker";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_checkerboardSize)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox_startAddress;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox_endAddress;
        private System.Windows.Forms.CheckBox checkBox_startAtClosestBoundary;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton radioButton_patternTypeRandom;
        private System.Windows.Forms.RadioButton radioButton_patternTypeUserDefined;
        private System.Windows.Forms.RadioButton radioButton_patternTypeRepeat;
        private System.Windows.Forms.Button button_save;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox_length;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.RichTextBox richTextBox_userDefinedData;
        private System.Windows.Forms.TextBox textBox_userDefinedFileLocation;
        private System.Windows.Forms.Button button_browseForUserDefinedFile;
        private System.Windows.Forms.RadioButton radioButton_patternTypeUserDefinedFile;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.NumericUpDown numericUpDown_checkerboardSize;
        private System.Windows.Forms.CheckBox checkBox_checkerboard;
        private System.Windows.Forms.ToolTip toolTip_regionMaker;
    }
}