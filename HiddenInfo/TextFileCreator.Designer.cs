namespace HiddenInfo
{
    partial class TextFileCreator
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TextFileCreator));
            this.lcd = new System.Windows.Forms.TextBox();
            this.discard_exitButton = new System.Windows.Forms.Button();
            this.save_exitButton = new System.Windows.Forms.Button();
            this.saveButton_backlight = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.saveButton_backlight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // lcd
            // 
            this.lcd.BackColor = System.Drawing.SystemColors.InfoText;
            this.lcd.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lcd.ForeColor = System.Drawing.SystemColors.Menu;
            this.lcd.Location = new System.Drawing.Point(56, 130);
            this.lcd.Multiline = true;
            this.lcd.Name = "lcd";
            this.lcd.Size = new System.Drawing.Size(690, 366);
            this.lcd.TabIndex = 2;
            // 
            // discard_exitButton
            // 
            this.discard_exitButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("discard_exitButton.BackgroundImage")));
            this.discard_exitButton.Location = new System.Drawing.Point(459, 519);
            this.discard_exitButton.Name = "discard_exitButton";
            this.discard_exitButton.Size = new System.Drawing.Size(255, 75);
            this.discard_exitButton.TabIndex = 4;
            this.discard_exitButton.UseVisualStyleBackColor = true;
            this.discard_exitButton.Click += new System.EventHandler(this.discard_exitButton_Click);
            // 
            // save_exitButton
            // 
            this.save_exitButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("save_exitButton.BackgroundImage")));
            this.save_exitButton.Location = new System.Drawing.Point(96, 519);
            this.save_exitButton.Name = "save_exitButton";
            this.save_exitButton.Size = new System.Drawing.Size(255, 75);
            this.save_exitButton.TabIndex = 5;
            this.save_exitButton.UseVisualStyleBackColor = true;
            this.save_exitButton.Click += new System.EventHandler(this.save_exitButton_Click);
            // 
            // saveButton_backlight
            // 
            this.saveButton_backlight.BackColor = System.Drawing.Color.Green;
            this.saveButton_backlight.Location = new System.Drawing.Point(92, 514);
            this.saveButton_backlight.Name = "saveButton_backlight";
            this.saveButton_backlight.Size = new System.Drawing.Size(265, 85);
            this.saveButton_backlight.TabIndex = 46;
            this.saveButton_backlight.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Green;
            this.pictureBox1.Location = new System.Drawing.Point(454, 514);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(265, 85);
            this.pictureBox1.TabIndex = 47;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox2.BackgroundImage")));
            this.pictureBox2.Location = new System.Drawing.Point(179, 30);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(450, 75);
            this.pictureBox2.TabIndex = 48;
            this.pictureBox2.TabStop = false;
            // 
            // TextFileCreator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(808, 624);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.save_exitButton);
            this.Controls.Add(this.discard_exitButton);
            this.Controls.Add(this.lcd);
            this.Controls.Add(this.saveButton_backlight);
            this.Controls.Add(this.pictureBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "TextFileCreator";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "HiddenInfo - Bitmap Encryption & Decryption.";
            ((System.ComponentModel.ISupportInitialize)(this.saveButton_backlight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox lcd;
        private System.Windows.Forms.Button discard_exitButton;
        private System.Windows.Forms.Button save_exitButton;
        private System.Windows.Forms.PictureBox saveButton_backlight;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
    }
}