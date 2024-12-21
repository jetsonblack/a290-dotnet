namespace A290NETBuffet
{
    partial class FrmBuffetOptions
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmBuffetOptions));
            this.BtnOk = new System.Windows.Forms.Button();
            this.BtnCancel = new System.Windows.Forms.Button();
            this.LblUserName = new System.Windows.Forms.Label();
            this.TxtUserName = new System.Windows.Forms.TextBox();
            this.GrpDefaultBackgroundColor = new System.Windows.Forms.GroupBox();
            this.ChkIMGBG = new System.Windows.Forms.CheckBox();
            this.OptBackgroundDefault = new System.Windows.Forms.RadioButton();
            this.OptBackgroundGreen = new System.Windows.Forms.RadioButton();
            this.OptBackgroundBlue = new System.Windows.Forms.RadioButton();
            this.OptBackgroundWhite = new System.Windows.Forms.RadioButton();
            this.CboBorderColors = new System.Windows.Forms.ComboBox();
            this.GrpDefaultBackgroundColor.SuspendLayout();
            this.SuspendLayout();
            // 
            // BtnOk
            // 
            this.BtnOk.BackColor = System.Drawing.Color.SeaGreen;
            this.BtnOk.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnOk.FlatAppearance.BorderColor = System.Drawing.Color.SeaGreen;
            this.BtnOk.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnOk.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnOk.ForeColor = System.Drawing.Color.MintCream;
            this.BtnOk.Location = new System.Drawing.Point(285, 20);
            this.BtnOk.Name = "BtnOk";
            this.BtnOk.Size = new System.Drawing.Size(95, 25);
            this.BtnOk.TabIndex = 0;
            this.BtnOk.Text = "Ok";
            this.BtnOk.UseVisualStyleBackColor = false;
            this.BtnOk.Click += new System.EventHandler(this.BtnOk_Click);
            // 
            // BtnCancel
            // 
            this.BtnCancel.BackColor = System.Drawing.Color.LemonChiffon;
            this.BtnCancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.BtnCancel.FlatAppearance.BorderColor = System.Drawing.Color.LemonChiffon;
            this.BtnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnCancel.ForeColor = System.Drawing.Color.Black;
            this.BtnCancel.Location = new System.Drawing.Point(285, 51);
            this.BtnCancel.Name = "BtnCancel";
            this.BtnCancel.Size = new System.Drawing.Size(95, 25);
            this.BtnCancel.TabIndex = 1;
            this.BtnCancel.Text = "Cancel";
            this.BtnCancel.UseVisualStyleBackColor = false;
            this.BtnCancel.Click += new System.EventHandler(this.BtnCancel_Click);
            // 
            // LblUserName
            // 
            this.LblUserName.AutoSize = true;
            this.LblUserName.Location = new System.Drawing.Point(13, 20);
            this.LblUserName.Name = "LblUserName";
            this.LblUserName.Size = new System.Drawing.Size(63, 13);
            this.LblUserName.TabIndex = 2;
            this.LblUserName.Text = "User Name:";
            // 
            // TxtUserName
            // 
            this.TxtUserName.Location = new System.Drawing.Point(82, 17);
            this.TxtUserName.Multiline = true;
            this.TxtUserName.Name = "TxtUserName";
            this.TxtUserName.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.TxtUserName.Size = new System.Drawing.Size(120, 30);
            this.TxtUserName.TabIndex = 3;
            this.TxtUserName.Text = "This is Just Some Sample Text";
            // 
            // GrpDefaultBackgroundColor
            // 
            this.GrpDefaultBackgroundColor.Controls.Add(this.ChkIMGBG);
            this.GrpDefaultBackgroundColor.Controls.Add(this.OptBackgroundDefault);
            this.GrpDefaultBackgroundColor.Controls.Add(this.OptBackgroundGreen);
            this.GrpDefaultBackgroundColor.Controls.Add(this.OptBackgroundBlue);
            this.GrpDefaultBackgroundColor.Controls.Add(this.OptBackgroundWhite);
            this.GrpDefaultBackgroundColor.Location = new System.Drawing.Point(82, 82);
            this.GrpDefaultBackgroundColor.Name = "GrpDefaultBackgroundColor";
            this.GrpDefaultBackgroundColor.Size = new System.Drawing.Size(227, 100);
            this.GrpDefaultBackgroundColor.TabIndex = 4;
            this.GrpDefaultBackgroundColor.TabStop = false;
            this.GrpDefaultBackgroundColor.Text = "Buffet Options Default Background Color";
            // 
            // ChkIMGBG
            // 
            this.ChkIMGBG.AutoSize = true;
            this.ChkIMGBG.Location = new System.Drawing.Point(108, 77);
            this.ChkIMGBG.Name = "ChkIMGBG";
            this.ChkIMGBG.Size = new System.Drawing.Size(113, 17);
            this.ChkIMGBG.TabIndex = 10;
            this.ChkIMGBG.Text = "IMG Background?";
            this.ChkIMGBG.UseVisualStyleBackColor = true;
            this.ChkIMGBG.CheckedChanged += new System.EventHandler(this.ChkIMGBG_CheckedChanged);
            // 
            // OptBackgroundDefault
            // 
            this.OptBackgroundDefault.AutoSize = true;
            this.OptBackgroundDefault.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.OptBackgroundDefault.Location = new System.Drawing.Point(70, 19);
            this.OptBackgroundDefault.Name = "OptBackgroundDefault";
            this.OptBackgroundDefault.Size = new System.Drawing.Size(66, 17);
            this.OptBackgroundDefault.TabIndex = 3;
            this.OptBackgroundDefault.TabStop = true;
            this.OptBackgroundDefault.Text = "Default";
            this.OptBackgroundDefault.UseVisualStyleBackColor = true;
            this.OptBackgroundDefault.CheckedChanged += new System.EventHandler(this.OptBackgroundDefault_CheckedChanged);
            // 
            // OptBackgroundGreen
            // 
            this.OptBackgroundGreen.AutoSize = true;
            this.OptBackgroundGreen.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.OptBackgroundGreen.Location = new System.Drawing.Point(70, 42);
            this.OptBackgroundGreen.Name = "OptBackgroundGreen";
            this.OptBackgroundGreen.Size = new System.Drawing.Size(59, 17);
            this.OptBackgroundGreen.TabIndex = 2;
            this.OptBackgroundGreen.TabStop = true;
            this.OptBackgroundGreen.Text = "Green";
            this.OptBackgroundGreen.UseVisualStyleBackColor = true;
            this.OptBackgroundGreen.CheckedChanged += new System.EventHandler(this.OptBackgroundGreen_CheckedChanged);
            // 
            // OptBackgroundBlue
            // 
            this.OptBackgroundBlue.AutoSize = true;
            this.OptBackgroundBlue.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.OptBackgroundBlue.Location = new System.Drawing.Point(6, 42);
            this.OptBackgroundBlue.Name = "OptBackgroundBlue";
            this.OptBackgroundBlue.Size = new System.Drawing.Size(50, 17);
            this.OptBackgroundBlue.TabIndex = 1;
            this.OptBackgroundBlue.TabStop = true;
            this.OptBackgroundBlue.Text = "Blue";
            this.OptBackgroundBlue.UseVisualStyleBackColor = true;
            this.OptBackgroundBlue.CheckedChanged += new System.EventHandler(this.OptBackgroundBlue_CheckedChanged);
            // 
            // OptBackgroundWhite
            // 
            this.OptBackgroundWhite.AutoSize = true;
            this.OptBackgroundWhite.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.OptBackgroundWhite.Location = new System.Drawing.Point(6, 19);
            this.OptBackgroundWhite.Name = "OptBackgroundWhite";
            this.OptBackgroundWhite.Size = new System.Drawing.Size(58, 17);
            this.OptBackgroundWhite.TabIndex = 0;
            this.OptBackgroundWhite.TabStop = true;
            this.OptBackgroundWhite.Text = "White";
            this.OptBackgroundWhite.UseVisualStyleBackColor = true;
            this.OptBackgroundWhite.CheckedChanged += new System.EventHandler(this.OptBackgroundWhite_CheckedChanged);
            // 
            // CboBorderColors
            // 
            this.CboBorderColors.FormattingEnabled = true;
            this.CboBorderColors.Items.AddRange(new object[] {
            "Default",
            "Yellow",
            "Cyan",
            "Blue",
            "Red",
            "Magenta"});
            this.CboBorderColors.Location = new System.Drawing.Point(129, 188);
            this.CboBorderColors.Name = "CboBorderColors";
            this.CboBorderColors.Size = new System.Drawing.Size(121, 21);
            this.CboBorderColors.TabIndex = 5;
            this.CboBorderColors.Text = "Border Colors";
            this.CboBorderColors.SelectedIndexChanged += new System.EventHandler(this.CboBorderColors_SelectedIndexChanged);
            // 
            // FrmBuffetOptions
            // 
            this.AcceptButton = this.BtnOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightGray;
            this.CancelButton = this.BtnCancel;
            this.ClientSize = new System.Drawing.Size(384, 361);
            this.Controls.Add(this.CboBorderColors);
            this.Controls.Add(this.GrpDefaultBackgroundColor);
            this.Controls.Add(this.TxtUserName);
            this.Controls.Add(this.LblUserName);
            this.Controls.Add(this.BtnCancel);
            this.Controls.Add(this.BtnOk);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmBuffetOptions";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Options";
            this.GrpDefaultBackgroundColor.ResumeLayout(false);
            this.GrpDefaultBackgroundColor.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button BtnOk;
        private System.Windows.Forms.Button BtnCancel;
        private System.Windows.Forms.Label LblUserName;
        private System.Windows.Forms.TextBox TxtUserName;
        private System.Windows.Forms.GroupBox GrpDefaultBackgroundColor;
        private System.Windows.Forms.ComboBox CboBorderColors;
        private System.Windows.Forms.RadioButton OptBackgroundDefault;
        private System.Windows.Forms.RadioButton OptBackgroundGreen;
        private System.Windows.Forms.RadioButton OptBackgroundBlue;
        private System.Windows.Forms.RadioButton OptBackgroundWhite;
        private System.Windows.Forms.CheckBox ChkIMGBG;
    }
}