namespace DummyImageCreator
{
    partial class ImageGenerator
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
            this.richTextBox_log = new System.Windows.Forms.RichTextBox();
            this.button_abort = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // richTextBox_log
            // 
            this.richTextBox_log.Location = new System.Drawing.Point(4, 9);
            this.richTextBox_log.Name = "richTextBox_log";
            this.richTextBox_log.Size = new System.Drawing.Size(428, 548);
            this.richTextBox_log.TabIndex = 0;
            this.richTextBox_log.Text = "";
            // 
            // button_abort
            // 
            this.button_abort.Location = new System.Drawing.Point(4, 563);
            this.button_abort.Name = "button_abort";
            this.button_abort.Size = new System.Drawing.Size(427, 37);
            this.button_abort.TabIndex = 1;
            this.button_abort.UseVisualStyleBackColor = true;
            this.button_abort.Click += new System.EventHandler(this.button_abort_Click);
            // 
            // ImageGenerator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(443, 605);
            this.Controls.Add(this.button_abort);
            this.Controls.Add(this.richTextBox_log);
            this.Name = "ImageGenerator";
            this.Text = "ImageGenerator";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ImageGenerator_FormClosing);
            this.Load += new System.EventHandler(this.ImageGenerator_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox richTextBox_log;
        private System.Windows.Forms.Button button_abort;
    }
}