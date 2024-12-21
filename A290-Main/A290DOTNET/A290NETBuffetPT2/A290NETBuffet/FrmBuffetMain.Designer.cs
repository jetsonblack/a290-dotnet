namespace A290NETBuffet
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmBuffetMain));
            this.BtnSelectPicture = new System.Windows.Forms.Button();
            this.BtnQuit = new System.Windows.Forms.Button();
            this.OfdSelectPicture = new System.Windows.Forms.OpenFileDialog();
            this.BtnDrawBorder = new System.Windows.Forms.Button();
            this.LblX = new System.Windows.Forms.Label();
            this.LblY = new System.Windows.Forms.Label();
            this.BtnOptions = new System.Windows.Forms.Button();
            this.BtnShrink = new System.Windows.Forms.Button();
            this.BtnEnlarge = new System.Windows.Forms.Button();
            this.PicShowPicture = new System.Windows.Forms.PictureBox();
            this.ChkPropmtExit = new System.Windows.Forms.CheckBox();
            this.BtnCollections = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.PicShowPicture)).BeginInit();
            this.SuspendLayout();
            // 
            // BtnSelectPicture
            // 
            this.BtnSelectPicture.BackColor = System.Drawing.Color.SeaGreen;
            this.BtnSelectPicture.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnSelectPicture.ForeColor = System.Drawing.Color.MintCream;
            this.BtnSelectPicture.Location = new System.Drawing.Point(675, 12);
            this.BtnSelectPicture.Name = "BtnSelectPicture";
            this.BtnSelectPicture.Size = new System.Drawing.Size(95, 27);
            this.BtnSelectPicture.TabIndex = 0;
            this.BtnSelectPicture.Text = "Select Picture";
            this.BtnSelectPicture.UseVisualStyleBackColor = false;
            this.BtnSelectPicture.Click += new System.EventHandler(this.BtnSelectPicture_Click);
            // 
            // BtnQuit
            // 
            this.BtnQuit.BackColor = System.Drawing.Color.Maroon;
            this.BtnQuit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnQuit.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.BtnQuit.ForeColor = System.Drawing.Color.White;
            this.BtnQuit.Location = new System.Drawing.Point(675, 46);
            this.BtnQuit.Name = "BtnQuit";
            this.BtnQuit.Size = new System.Drawing.Size(95, 27);
            this.BtnQuit.TabIndex = 1;
            this.BtnQuit.Text = "Quit";
            this.BtnQuit.UseVisualStyleBackColor = false;
            this.BtnQuit.Click += new System.EventHandler(this.BtnQuit_Click);
            // 
            // OfdSelectPicture
            // 
            this.OfdSelectPicture.FileName = " ";
            this.OfdSelectPicture.Filter = "JPEG|*.JPG;*.JPEG|PNG|*.PNG|Windows Bitmaps|*.BMP|Image Files|*.JPG;*.JPEG;*.PNG;" +
    "*.BMP";
            this.OfdSelectPicture.Title = "Select Picture";
            // 
            // BtnDrawBorder
            // 
            this.BtnDrawBorder.BackColor = System.Drawing.Color.RoyalBlue;
            this.BtnDrawBorder.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnDrawBorder.ForeColor = System.Drawing.Color.White;
            this.BtnDrawBorder.Location = new System.Drawing.Point(675, 81);
            this.BtnDrawBorder.Name = "BtnDrawBorder";
            this.BtnDrawBorder.Size = new System.Drawing.Size(95, 27);
            this.BtnDrawBorder.TabIndex = 5;
            this.BtnDrawBorder.Text = "Draw Border";
            this.BtnDrawBorder.UseVisualStyleBackColor = false;
            this.BtnDrawBorder.Click += new System.EventHandler(this.BtnDrawBorder_Click);
            // 
            // LblX
            // 
            this.LblX.AutoSize = true;
            this.LblX.Location = new System.Drawing.Point(670, 277);
            this.LblX.Name = "LblX";
            this.LblX.Size = new System.Drawing.Size(19, 15);
            this.LblX.TabIndex = 6;
            this.LblX.Text = "X:";
            // 
            // LblY
            // 
            this.LblY.AutoSize = true;
            this.LblY.Location = new System.Drawing.Point(670, 312);
            this.LblY.Name = "LblY";
            this.LblY.Size = new System.Drawing.Size(19, 15);
            this.LblY.TabIndex = 7;
            this.LblY.Text = "Y:";
            // 
            // BtnOptions
            // 
            this.BtnOptions.BackColor = System.Drawing.Color.Orchid;
            this.BtnOptions.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnOptions.ForeColor = System.Drawing.Color.White;
            this.BtnOptions.Location = new System.Drawing.Point(675, 114);
            this.BtnOptions.Name = "BtnOptions";
            this.BtnOptions.Size = new System.Drawing.Size(95, 25);
            this.BtnOptions.TabIndex = 8;
            this.BtnOptions.Text = "Options";
            this.BtnOptions.UseVisualStyleBackColor = false;
            this.BtnOptions.Click += new System.EventHandler(this.BtnOptions_Click);
            // 
            // BtnShrink
            // 
            this.BtnShrink.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnShrink.Image = global::A290NETBuffet.Properties.Resources.smallshrink;
            this.BtnShrink.Location = new System.Drawing.Point(740, 660);
            this.BtnShrink.Name = "BtnShrink";
            this.BtnShrink.Size = new System.Drawing.Size(32, 32);
            this.BtnShrink.TabIndex = 4;
            this.BtnShrink.UseVisualStyleBackColor = true;
            this.BtnShrink.Click += new System.EventHandler(this.BtnShrink_Click);
            // 
            // BtnEnlarge
            // 
            this.BtnEnlarge.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnEnlarge.Image = global::A290NETBuffet.Properties.Resources.smallexpand;
            this.BtnEnlarge.Location = new System.Drawing.Point(740, 622);
            this.BtnEnlarge.Name = "BtnEnlarge";
            this.BtnEnlarge.Size = new System.Drawing.Size(32, 32);
            this.BtnEnlarge.TabIndex = 3;
            this.BtnEnlarge.UseVisualStyleBackColor = true;
            this.BtnEnlarge.Click += new System.EventHandler(this.BtnEnlarge_Click);
            // 
            // PicShowPicture
            // 
            this.PicShowPicture.Location = new System.Drawing.Point(10, 12);
            this.PicShowPicture.Name = "PicShowPicture";
            this.PicShowPicture.Size = new System.Drawing.Size(625, 680);
            this.PicShowPicture.TabIndex = 2;
            this.PicShowPicture.TabStop = false;
            this.PicShowPicture.MouseLeave += new System.EventHandler(this.PicShowPIcture_MouseLeave);
            this.PicShowPicture.MouseMove += new System.Windows.Forms.MouseEventHandler(this.PicShowPIcture_MouseMove);
            // 
            // ChkPropmtExit
            // 
            this.ChkPropmtExit.AutoSize = true;
            this.ChkPropmtExit.Location = new System.Drawing.Point(674, 176);
            this.ChkPropmtExit.Name = "ChkPropmtExit";
            this.ChkPropmtExit.Size = new System.Drawing.Size(98, 19);
            this.ChkPropmtExit.TabIndex = 9;
            this.ChkPropmtExit.Text = "Ask To Exit?";
            this.ChkPropmtExit.UseVisualStyleBackColor = true;
            this.ChkPropmtExit.CheckedChanged += new System.EventHandler(this.ChkPropmtExit_CheckedChanged);
            // 
            // BtnCollections
            // 
            this.BtnCollections.BackColor = System.Drawing.Color.Orchid;
            this.BtnCollections.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnCollections.ForeColor = System.Drawing.Color.White;
            this.BtnCollections.Location = new System.Drawing.Point(675, 145);
            this.BtnCollections.Name = "BtnCollections";
            this.BtnCollections.Size = new System.Drawing.Size(95, 25);
            this.BtnCollections.TabIndex = 10;
            this.BtnCollections.Text = "Collections";
            this.BtnCollections.UseVisualStyleBackColor = false;
            this.BtnCollections.Click += new System.EventHandler(this.BtnCollections_Click);
            // 
            // FrmBuffetMain
            // 
            this.AcceptButton = this.BtnSelectPicture;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.CancelButton = this.BtnQuit;
            this.ClientSize = new System.Drawing.Size(784, 705);
            this.Controls.Add(this.BtnCollections);
            this.Controls.Add(this.ChkPropmtExit);
            this.Controls.Add(this.BtnOptions);
            this.Controls.Add(this.LblY);
            this.Controls.Add(this.LblX);
            this.Controls.Add(this.BtnDrawBorder);
            this.Controls.Add(this.BtnShrink);
            this.Controls.Add(this.BtnEnlarge);
            this.Controls.Add(this.PicShowPicture);
            this.Controls.Add(this.BtnQuit);
            this.Controls.Add(this.BtnSelectPicture);
            this.Font = new System.Drawing.Font("Cascadia Code", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmBuffetMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Buffet Photo Viewer";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmBuffetMain_FormClosing);
            this.Load += new System.EventHandler(this.FrmBuffetMain_Load);
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
        private System.Windows.Forms.Button BtnOptions;
        private System.Windows.Forms.CheckBox ChkPropmtExit;
        private System.Windows.Forms.Button BtnCollections;
    }
}

