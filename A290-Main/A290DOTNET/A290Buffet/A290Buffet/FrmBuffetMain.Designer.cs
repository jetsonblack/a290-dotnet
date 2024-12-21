//A20-Buffet FrmBuffetMain
//Primary form for A290 Buffet Project
//Created by: Jetson Black
//Date Created: 11/04/2024
//Lasted Edited: 11/04/2024
// Last modifed by: Jetson Black
//Part of Proj: 1



namespace A290Buffet
{
    partial class FrmBuffetMain
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
            this.BtnSelectPicture = new System.Windows.Forms.Button();
            this.BtnQuit = new System.Windows.Forms.Button();
            this.PicShowPicture = new System.Windows.Forms.PictureBox();
            this.OfdSelectPicture = new System.Windows.Forms.OpenFileDialog();
            this.BtnEnlarge = new System.Windows.Forms.Button();
            this.BtnShrink = new System.Windows.Forms.Button();
            this.BtnDrawBorder = new System.Windows.Forms.Button();
            this.LblX = new System.Windows.Forms.Label();
            this.LblY = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.PicShowPicture)).BeginInit();
            this.SuspendLayout();
            // 
            // BtnSelectPicture
            // 
            this.BtnSelectPicture.Location = new System.Drawing.Point(675, 10);
            this.BtnSelectPicture.Name = "BtnSelectPicture";
            this.BtnSelectPicture.Size = new System.Drawing.Size(95, 23);
            this.BtnSelectPicture.TabIndex = 0;
            this.BtnSelectPicture.Text = "Select Picture";
            this.BtnSelectPicture.UseVisualStyleBackColor = true;
            this.BtnSelectPicture.Click += new System.EventHandler(this.BtnSelectPicture_Click);
            // 
            // BtnQuit
            // 
            this.BtnQuit.Location = new System.Drawing.Point(675, 40);
            this.BtnQuit.Name = "BtnQuit";
            this.BtnQuit.Size = new System.Drawing.Size(95, 23);
            this.BtnQuit.TabIndex = 1;
            this.BtnQuit.Text = "Quit";
            this.BtnQuit.UseVisualStyleBackColor = true;
            this.BtnQuit.Click += new System.EventHandler(this.BtnQuit_Click);
            // 
            // PicShowPicture
            // 
            this.PicShowPicture.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PicShowPicture.Location = new System.Drawing.Point(10, 10);
            this.PicShowPicture.Name = "PicShowPicture";
            this.PicShowPicture.Size = new System.Drawing.Size(625, 590);
            this.PicShowPicture.TabIndex = 2;
            this.PicShowPicture.TabStop = false;
            this.PicShowPicture.Click += new System.EventHandler(this.PicShowPicture_Click);
            this.PicShowPicture.MouseLeave += new System.EventHandler(this.PicShowPicture_MouseLeave);
            this.PicShowPicture.MouseMove += new System.Windows.Forms.MouseEventHandler(this.PicShowPicture_MouseMove);
            // 
            // OfdSelectPicture
            // 
            this.OfdSelectPicture.Filter = "Windows Bitmaps|*.BMP|JPEG|*.JPG";
            this.OfdSelectPicture.Title = "Select Picture... pretty please";
            // 
            // BtnEnlarge
            // 
            this.BtnEnlarge.Location = new System.Drawing.Point(750, 540);
            this.BtnEnlarge.Name = "BtnEnlarge";
            this.BtnEnlarge.Size = new System.Drawing.Size(23, 23);
            this.BtnEnlarge.TabIndex = 3;
            this.BtnEnlarge.Text = "v";
            this.BtnEnlarge.UseVisualStyleBackColor = true;
            this.BtnEnlarge.Click += new System.EventHandler(this.BtnEnlarge_Click);
            // 
            // BtnShrink
            // 
            this.BtnShrink.Location = new System.Drawing.Point(750, 570);
            this.BtnShrink.Name = "BtnShrink";
            this.BtnShrink.Size = new System.Drawing.Size(23, 23);
            this.BtnShrink.TabIndex = 4;
            this.BtnShrink.Text = "^";
            this.BtnShrink.UseVisualStyleBackColor = true;
            this.BtnShrink.Click += new System.EventHandler(this.BtnShrink_Click);
            // 
            // BtnDrawBorder
            // 
            this.BtnDrawBorder.Location = new System.Drawing.Point(675, 70);
            this.BtnDrawBorder.Name = "BtnDrawBorder";
            this.BtnDrawBorder.Size = new System.Drawing.Size(95, 25);
            this.BtnDrawBorder.TabIndex = 5;
            this.BtnDrawBorder.Text = "Draw Border";
            this.BtnDrawBorder.UseVisualStyleBackColor = true;
            this.BtnDrawBorder.Click += new System.EventHandler(this.BtnDrawBorder_Click);
            // 
            // LblX
            // 
            this.LblX.AutoSize = true;
            this.LblX.Location = new System.Drawing.Point(670, 240);
            this.LblX.Name = "LblX";
            this.LblX.Size = new System.Drawing.Size(14, 13);
            this.LblX.TabIndex = 8;
            this.LblX.Text = "X";
            // 
            // LblY
            // 
            this.LblY.AutoSize = true;
            this.LblY.Location = new System.Drawing.Point(670, 270);
            this.LblY.Name = "LblY";
            this.LblY.Size = new System.Drawing.Size(14, 13);
            this.LblY.TabIndex = 9;
            this.LblY.Text = "Y";
            // 
            // FrmBuffetMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 611);
            this.Controls.Add(this.LblY);
            this.Controls.Add(this.LblX);
            this.Controls.Add(this.BtnDrawBorder);
            this.Controls.Add(this.BtnShrink);
            this.Controls.Add(this.BtnEnlarge);
            this.Controls.Add(this.PicShowPicture);
            this.Controls.Add(this.BtnQuit);
            this.Controls.Add(this.BtnSelectPicture);
            this.Name = "FrmBuffetMain";
            this.Text = "A290 Buffet";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Resize += new System.EventHandler(this.FrmBuffetMain_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.PicShowPicture)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button BtnSelectPicture;
        private System.Windows.Forms.Button BtnQuit;
        private System.Windows.Forms.PictureBox PicShowPicture;
        private System.Windows.Forms.OpenFileDialog OfdSelectPicture;
        private System.Windows.Forms.Button BtnEnlarge;
        private System.Windows.Forms.Button BtnShrink;
        private System.Windows.Forms.Button BtnDrawBorder;
        private System.Windows.Forms.Label LblX;
        private System.Windows.Forms.Label LblY;
    }
}

