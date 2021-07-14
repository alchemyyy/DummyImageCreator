namespace DummyImageCreator
{
    partial class DummyImageCreator
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
            this.listBox_imageFileContents = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.button_ifcMoveUp = new System.Windows.Forms.Button();
            this.button_ifcMoveDown = new System.Windows.Forms.Button();
            this.button_ifcDelete = new System.Windows.Forms.Button();
            this.radioButton_fileFormatBinary = new System.Windows.Forms.RadioButton();
            this.radioButton_fileFormatIntelHex = new System.Windows.Forms.RadioButton();
            this.radioButton_FileFormatMotorolaHex = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button_SaveImagePattern = new System.Windows.Forms.Button();
            this.button_GenerateImage = new System.Windows.Forms.Button();
            this.button_ifcClone = new System.Windows.Forms.Button();
            this.button_ifcInsert = new System.Windows.Forms.Button();
            this.textBox_maxImageSize = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox_imageSaveName = new System.Windows.Forms.TextBox();
            this.button_ifcLoadSavedImage = new System.Windows.Forms.Button();
            this.button_ifcEdit = new System.Windows.Forms.Button();
            this.toolTip_imageCreator = new System.Windows.Forms.ToolTip(this.components);
            this.button_openAppFolder = new System.Windows.Forms.Button();
            this.button_reset = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // listBox_imageFileContents
            // 
            this.listBox_imageFileContents.FormattingEnabled = true;
            this.listBox_imageFileContents.Location = new System.Drawing.Point(15, 121);
            this.listBox_imageFileContents.Name = "listBox_imageFileContents";
            this.listBox_imageFileContents.Size = new System.Drawing.Size(262, 316);
            this.listBox_imageFileContents.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 105);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Image File Contents";
            // 
            // button_ifcMoveUp
            // 
            this.button_ifcMoveUp.Location = new System.Drawing.Point(283, 121);
            this.button_ifcMoveUp.Name = "button_ifcMoveUp";
            this.button_ifcMoveUp.Size = new System.Drawing.Size(123, 38);
            this.button_ifcMoveUp.TabIndex = 5;
            this.button_ifcMoveUp.Text = "Move Up";
            this.button_ifcMoveUp.UseVisualStyleBackColor = true;
            this.button_ifcMoveUp.Click += new System.EventHandler(this.button_ifcMoveUp_Click);
            // 
            // button_ifcMoveDown
            // 
            this.button_ifcMoveDown.Location = new System.Drawing.Point(283, 167);
            this.button_ifcMoveDown.Name = "button_ifcMoveDown";
            this.button_ifcMoveDown.Size = new System.Drawing.Size(123, 38);
            this.button_ifcMoveDown.TabIndex = 6;
            this.button_ifcMoveDown.Text = "Move Down";
            this.button_ifcMoveDown.UseVisualStyleBackColor = true;
            this.button_ifcMoveDown.Click += new System.EventHandler(this.button_ifcMoveDown_Click);
            // 
            // button_ifcDelete
            // 
            this.button_ifcDelete.Location = new System.Drawing.Point(282, 351);
            this.button_ifcDelete.Name = "button_ifcDelete";
            this.button_ifcDelete.Size = new System.Drawing.Size(123, 38);
            this.button_ifcDelete.TabIndex = 7;
            this.button_ifcDelete.Text = "Delete";
            this.button_ifcDelete.UseVisualStyleBackColor = true;
            this.button_ifcDelete.Click += new System.EventHandler(this.button_ifcDelete_Click);
            // 
            // radioButton_fileFormatBinary
            // 
            this.radioButton_fileFormatBinary.AutoSize = true;
            this.radioButton_fileFormatBinary.Checked = true;
            this.radioButton_fileFormatBinary.Location = new System.Drawing.Point(13, 19);
            this.radioButton_fileFormatBinary.Name = "radioButton_fileFormatBinary";
            this.radioButton_fileFormatBinary.Size = new System.Drawing.Size(54, 17);
            this.radioButton_fileFormatBinary.TabIndex = 8;
            this.radioButton_fileFormatBinary.TabStop = true;
            this.radioButton_fileFormatBinary.Text = "Binary";
            this.radioButton_fileFormatBinary.UseVisualStyleBackColor = true;
            this.radioButton_fileFormatBinary.CheckedChanged += new System.EventHandler(this.radioButton_fileFormatBinary_CheckedChanged);
            // 
            // radioButton_fileFormatIntelHex
            // 
            this.radioButton_fileFormatIntelHex.AutoSize = true;
            this.radioButton_fileFormatIntelHex.Location = new System.Drawing.Point(13, 42);
            this.radioButton_fileFormatIntelHex.Name = "radioButton_fileFormatIntelHex";
            this.radioButton_fileFormatIntelHex.Size = new System.Drawing.Size(67, 17);
            this.radioButton_fileFormatIntelHex.TabIndex = 9;
            this.radioButton_fileFormatIntelHex.Text = "Intel Hex";
            this.radioButton_fileFormatIntelHex.UseVisualStyleBackColor = true;
            this.radioButton_fileFormatIntelHex.CheckedChanged += new System.EventHandler(this.radioButton_fileFormatIntelHex_CheckedChanged);
            // 
            // radioButton_FileFormatMotorolaHex
            // 
            this.radioButton_FileFormatMotorolaHex.AutoSize = true;
            this.radioButton_FileFormatMotorolaHex.Location = new System.Drawing.Point(13, 65);
            this.radioButton_FileFormatMotorolaHex.Name = "radioButton_FileFormatMotorolaHex";
            this.radioButton_FileFormatMotorolaHex.Size = new System.Drawing.Size(88, 17);
            this.radioButton_FileFormatMotorolaHex.TabIndex = 10;
            this.radioButton_FileFormatMotorolaHex.Text = "Motorola Hex";
            this.radioButton_FileFormatMotorolaHex.UseVisualStyleBackColor = true;
            this.radioButton_FileFormatMotorolaHex.CheckedChanged += new System.EventHandler(this.radioButton_FileFormatMotorolaHex_CheckedChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.radioButton_fileFormatBinary);
            this.groupBox1.Controls.Add(this.radioButton_FileFormatMotorolaHex);
            this.groupBox1.Controls.Add(this.radioButton_fileFormatIntelHex);
            this.groupBox1.Location = new System.Drawing.Point(15, 443);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(122, 92);
            this.groupBox1.TabIndex = 11;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Save File As";
            // 
            // button_SaveImagePattern
            // 
            this.button_SaveImagePattern.Location = new System.Drawing.Point(283, 448);
            this.button_SaveImagePattern.Name = "button_SaveImagePattern";
            this.button_SaveImagePattern.Size = new System.Drawing.Size(123, 38);
            this.button_SaveImagePattern.TabIndex = 12;
            this.button_SaveImagePattern.Text = "Save Image Pattern";
            this.button_SaveImagePattern.UseVisualStyleBackColor = true;
            this.button_SaveImagePattern.Click += new System.EventHandler(this.button_SaveImagePattern_Click);
            // 
            // button_GenerateImage
            // 
            this.button_GenerateImage.Location = new System.Drawing.Point(154, 492);
            this.button_GenerateImage.Name = "button_GenerateImage";
            this.button_GenerateImage.Size = new System.Drawing.Size(123, 38);
            this.button_GenerateImage.TabIndex = 13;
            this.button_GenerateImage.Text = "*Generate";
            this.button_GenerateImage.UseVisualStyleBackColor = true;
            this.button_GenerateImage.Click += new System.EventHandler(this.button_GenerateImage_Click);
            // 
            // button_ifcClone
            // 
            this.button_ifcClone.Location = new System.Drawing.Point(283, 213);
            this.button_ifcClone.Name = "button_ifcClone";
            this.button_ifcClone.Size = new System.Drawing.Size(123, 38);
            this.button_ifcClone.TabIndex = 14;
            this.button_ifcClone.Text = "Clone";
            this.button_ifcClone.UseVisualStyleBackColor = true;
            this.button_ifcClone.Click += new System.EventHandler(this.button_ifcClone_Click);
            // 
            // button_ifcInsert
            // 
            this.button_ifcInsert.Location = new System.Drawing.Point(283, 305);
            this.button_ifcInsert.Name = "button_ifcInsert";
            this.button_ifcInsert.Size = new System.Drawing.Size(123, 38);
            this.button_ifcInsert.TabIndex = 15;
            this.button_ifcInsert.Text = "Insert (Add)";
            this.button_ifcInsert.UseVisualStyleBackColor = true;
            this.button_ifcInsert.Click += new System.EventHandler(this.button_ifcInsert_Click);
            // 
            // textBox_maxImageSize
            // 
            this.textBox_maxImageSize.Location = new System.Drawing.Point(10, 34);
            this.textBox_maxImageSize.Name = "textBox_maxImageSize";
            this.textBox_maxImageSize.Size = new System.Drawing.Size(396, 20);
            this.textBox_maxImageSize.TabIndex = 16;
            this.textBox_maxImageSize.TextChanged += new System.EventHandler(this.textBox_maxImageSize_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 18);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(368, 13);
            this.label2.TabIndex = 17;
            this.label2.Text = "Max Image Size (0h 0d 0k 0m 0g) (truncates at generation, can be left blank)";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 66);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(291, 13);
            this.label3.TabIndex = 19;
            this.label3.Text = "Image Save Name (leave blank to have one autogenerated)";
            // 
            // textBox_imageSaveName
            // 
            this.textBox_imageSaveName.Location = new System.Drawing.Point(10, 82);
            this.textBox_imageSaveName.Name = "textBox_imageSaveName";
            this.textBox_imageSaveName.Size = new System.Drawing.Size(396, 20);
            this.textBox_imageSaveName.TabIndex = 18;
            this.textBox_imageSaveName.TextChanged += new System.EventHandler(this.textBox_imageSaveName_TextChanged);
            // 
            // button_ifcLoadSavedImage
            // 
            this.button_ifcLoadSavedImage.Location = new System.Drawing.Point(154, 448);
            this.button_ifcLoadSavedImage.Name = "button_ifcLoadSavedImage";
            this.button_ifcLoadSavedImage.Size = new System.Drawing.Size(123, 38);
            this.button_ifcLoadSavedImage.TabIndex = 20;
            this.button_ifcLoadSavedImage.Text = "*Load Saved Pattern";
            this.button_ifcLoadSavedImage.UseVisualStyleBackColor = true;
            this.button_ifcLoadSavedImage.Click += new System.EventHandler(this.button_ifcLoadSavedImage_Click);
            // 
            // button_ifcEdit
            // 
            this.button_ifcEdit.Location = new System.Drawing.Point(283, 259);
            this.button_ifcEdit.Name = "button_ifcEdit";
            this.button_ifcEdit.Size = new System.Drawing.Size(123, 38);
            this.button_ifcEdit.TabIndex = 21;
            this.button_ifcEdit.Text = "Edit";
            this.button_ifcEdit.UseVisualStyleBackColor = true;
            this.button_ifcEdit.Click += new System.EventHandler(this.button_ifcEdit_Click);
            // 
            // button_openAppFolder
            // 
            this.button_openAppFolder.Location = new System.Drawing.Point(282, 492);
            this.button_openAppFolder.Name = "button_openAppFolder";
            this.button_openAppFolder.Size = new System.Drawing.Size(123, 38);
            this.button_openAppFolder.TabIndex = 22;
            this.button_openAppFolder.Text = "Open App Folder";
            this.button_openAppFolder.UseVisualStyleBackColor = true;
            this.button_openAppFolder.Click += new System.EventHandler(this.button_openAppFolder_Click);
            // 
            // button_reset
            // 
            this.button_reset.Location = new System.Drawing.Point(282, 399);
            this.button_reset.Name = "button_reset";
            this.button_reset.Size = new System.Drawing.Size(123, 38);
            this.button_reset.TabIndex = 23;
            this.button_reset.Text = "Reset* (Clear All)";
            this.button_reset.UseVisualStyleBackColor = true;
            this.button_reset.Click += new System.EventHandler(this.button_reset_Click);
            // 
            // DummyImageCreator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(417, 541);
            this.Controls.Add(this.button_reset);
            this.Controls.Add(this.button_openAppFolder);
            this.Controls.Add(this.button_ifcEdit);
            this.Controls.Add(this.button_ifcLoadSavedImage);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBox_imageSaveName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBox_maxImageSize);
            this.Controls.Add(this.button_ifcInsert);
            this.Controls.Add(this.button_ifcClone);
            this.Controls.Add(this.button_GenerateImage);
            this.Controls.Add(this.button_SaveImagePattern);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.button_ifcDelete);
            this.Controls.Add(this.button_ifcMoveDown);
            this.Controls.Add(this.button_ifcMoveUp);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.listBox_imageFileContents);
            this.MaximumSize = new System.Drawing.Size(433, 580);
            this.MinimumSize = new System.Drawing.Size(433, 580);
            this.Name = "DummyImageCreator";
            this.Text = "Dummy Image Creator Tool";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox listBox_imageFileContents;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button_ifcMoveUp;
        private System.Windows.Forms.Button button_ifcMoveDown;
        private System.Windows.Forms.Button button_ifcDelete;
        private System.Windows.Forms.RadioButton radioButton_fileFormatBinary;
        private System.Windows.Forms.RadioButton radioButton_fileFormatIntelHex;
        private System.Windows.Forms.RadioButton radioButton_FileFormatMotorolaHex;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button button_SaveImagePattern;
        private System.Windows.Forms.Button button_GenerateImage;
        private System.Windows.Forms.Button button_ifcClone;
        private System.Windows.Forms.Button button_ifcInsert;
        private System.Windows.Forms.TextBox textBox_maxImageSize;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox_imageSaveName;
        private System.Windows.Forms.Button button_ifcLoadSavedImage;
        private System.Windows.Forms.Button button_ifcEdit;
        private System.Windows.Forms.ToolTip toolTip_imageCreator;
        private System.Windows.Forms.Button button_openAppFolder;
        private System.Windows.Forms.Button button_reset;
    }
}

