namespace MarkDownManager
{
    partial class FrmMainMarkdown
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMainMarkdown));
            this.WBMarkdown = new System.Windows.Forms.WebBrowser();
            this.TxtUserMarkdown = new System.Windows.Forms.TextBox();
            this.BtnCreate = new System.Windows.Forms.Button();
            this.BtnImport = new System.Windows.Forms.Button();
            this.BtnSave = new System.Windows.Forms.Button();
            this.BtnAbout = new System.Windows.Forms.Button();
            this.BtnOptions = new System.Windows.Forms.Button();
            this.BtnQuit = new System.Windows.Forms.Button();
            this.GrpBMDcontrols = new System.Windows.Forms.GroupBox();
            this.BtnMDStrike = new System.Windows.Forms.Button();
            this.BtnMDUnderline = new System.Windows.Forms.Button();
            this.BtnMDItalic = new System.Windows.Forms.Button();
            this.BtnMDHeader = new System.Windows.Forms.Button();
            this.BtnMDBold = new System.Windows.Forms.Button();
            this.LblWordCount = new System.Windows.Forms.Label();
            this.PnlLineNumbers = new System.Windows.Forms.Panel();
            this.TxtCommand = new System.Windows.Forms.TextBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.createToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.importToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.quitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.GrpBMDcontrols.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // WBMarkdown
            // 
            this.WBMarkdown.Dock = System.Windows.Forms.DockStyle.Right;
            this.WBMarkdown.Location = new System.Drawing.Point(564, 24);
            this.WBMarkdown.Margin = new System.Windows.Forms.Padding(10);
            this.WBMarkdown.MinimumSize = new System.Drawing.Size(20, 20);
            this.WBMarkdown.Name = "WBMarkdown";
            this.WBMarkdown.Size = new System.Drawing.Size(700, 737);
            this.WBMarkdown.TabIndex = 0;
            // 
            // TxtUserMarkdown
            // 
            this.TxtUserMarkdown.Font = new System.Drawing.Font("Nirmala UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtUserMarkdown.Location = new System.Drawing.Point(169, 24);
            this.TxtUserMarkdown.Multiline = true;
            this.TxtUserMarkdown.Name = "TxtUserMarkdown";
            this.TxtUserMarkdown.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.TxtUserMarkdown.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.TxtUserMarkdown.Size = new System.Drawing.Size(389, 651);
            this.TxtUserMarkdown.TabIndex = 1;
            this.TxtUserMarkdown.WordWrap = false;
            // 
            // BtnCreate
            // 
            this.BtnCreate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnCreate.Location = new System.Drawing.Point(12, 41);
            this.BtnCreate.Name = "BtnCreate";
            this.BtnCreate.Size = new System.Drawing.Size(127, 33);
            this.BtnCreate.TabIndex = 2;
            this.BtnCreate.Text = "Create";
            this.BtnCreate.UseVisualStyleBackColor = true;
            // 
            // BtnImport
            // 
            this.BtnImport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnImport.Location = new System.Drawing.Point(12, 80);
            this.BtnImport.Name = "BtnImport";
            this.BtnImport.Size = new System.Drawing.Size(127, 33);
            this.BtnImport.TabIndex = 3;
            this.BtnImport.Text = "Import";
            this.BtnImport.UseVisualStyleBackColor = true;
            // 
            // BtnSave
            // 
            this.BtnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnSave.Location = new System.Drawing.Point(12, 119);
            this.BtnSave.Name = "BtnSave";
            this.BtnSave.Size = new System.Drawing.Size(127, 33);
            this.BtnSave.TabIndex = 4;
            this.BtnSave.Text = "Save";
            this.BtnSave.UseVisualStyleBackColor = true;
            // 
            // BtnAbout
            // 
            this.BtnAbout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnAbout.Location = new System.Drawing.Point(12, 549);
            this.BtnAbout.Name = "BtnAbout";
            this.BtnAbout.Size = new System.Drawing.Size(127, 33);
            this.BtnAbout.TabIndex = 5;
            this.BtnAbout.Text = "About";
            this.BtnAbout.UseVisualStyleBackColor = true;
            // 
            // BtnOptions
            // 
            this.BtnOptions.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnOptions.Location = new System.Drawing.Point(12, 588);
            this.BtnOptions.Name = "BtnOptions";
            this.BtnOptions.Size = new System.Drawing.Size(127, 33);
            this.BtnOptions.TabIndex = 6;
            this.BtnOptions.Text = "Options";
            this.BtnOptions.UseVisualStyleBackColor = true;
            // 
            // BtnQuit
            // 
            this.BtnQuit.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.BtnQuit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnQuit.Location = new System.Drawing.Point(12, 627);
            this.BtnQuit.Name = "BtnQuit";
            this.BtnQuit.Size = new System.Drawing.Size(127, 33);
            this.BtnQuit.TabIndex = 7;
            this.BtnQuit.Text = "Quit";
            this.BtnQuit.UseVisualStyleBackColor = true;
            // 
            // GrpBMDcontrols
            // 
            this.GrpBMDcontrols.Controls.Add(this.BtnMDStrike);
            this.GrpBMDcontrols.Controls.Add(this.BtnMDUnderline);
            this.GrpBMDcontrols.Controls.Add(this.BtnMDItalic);
            this.GrpBMDcontrols.Controls.Add(this.BtnMDHeader);
            this.GrpBMDcontrols.Controls.Add(this.BtnMDBold);
            this.GrpBMDcontrols.Location = new System.Drawing.Point(159, 693);
            this.GrpBMDcontrols.Name = "GrpBMDcontrols";
            this.GrpBMDcontrols.Size = new System.Drawing.Size(399, 105);
            this.GrpBMDcontrols.TabIndex = 8;
            this.GrpBMDcontrols.TabStop = false;
            this.GrpBMDcontrols.Text = "Controls";
            // 
            // BtnMDStrike
            // 
            this.BtnMDStrike.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnMDStrike.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Strikeout, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnMDStrike.Location = new System.Drawing.Point(305, 19);
            this.BtnMDStrike.Name = "BtnMDStrike";
            this.BtnMDStrike.Size = new System.Drawing.Size(65, 25);
            this.BtnMDStrike.TabIndex = 4;
            this.BtnMDStrike.Text = "Strike";
            this.BtnMDStrike.UseVisualStyleBackColor = true;
            // 
            // BtnMDUnderline
            // 
            this.BtnMDUnderline.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnMDUnderline.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnMDUnderline.Location = new System.Drawing.Point(234, 19);
            this.BtnMDUnderline.Name = "BtnMDUnderline";
            this.BtnMDUnderline.Size = new System.Drawing.Size(65, 25);
            this.BtnMDUnderline.TabIndex = 3;
            this.BtnMDUnderline.Text = "Underline";
            this.BtnMDUnderline.UseVisualStyleBackColor = true;
            // 
            // BtnMDItalic
            // 
            this.BtnMDItalic.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnMDItalic.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnMDItalic.Location = new System.Drawing.Point(163, 19);
            this.BtnMDItalic.Name = "BtnMDItalic";
            this.BtnMDItalic.Size = new System.Drawing.Size(65, 25);
            this.BtnMDItalic.TabIndex = 2;
            this.BtnMDItalic.Text = "Italic";
            this.BtnMDItalic.UseVisualStyleBackColor = true;
            // 
            // BtnMDHeader
            // 
            this.BtnMDHeader.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnMDHeader.Location = new System.Drawing.Point(21, 19);
            this.BtnMDHeader.Name = "BtnMDHeader";
            this.BtnMDHeader.Size = new System.Drawing.Size(65, 25);
            this.BtnMDHeader.TabIndex = 1;
            this.BtnMDHeader.Text = "HEADER";
            this.BtnMDHeader.UseVisualStyleBackColor = true;
            // 
            // BtnMDBold
            // 
            this.BtnMDBold.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnMDBold.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnMDBold.Location = new System.Drawing.Point(92, 19);
            this.BtnMDBold.Name = "BtnMDBold";
            this.BtnMDBold.Size = new System.Drawing.Size(65, 25);
            this.BtnMDBold.TabIndex = 0;
            this.BtnMDBold.Text = "Bold";
            this.BtnMDBold.UseVisualStyleBackColor = true;
            // 
            // LblWordCount
            // 
            this.LblWordCount.AutoSize = true;
            this.LblWordCount.BackColor = System.Drawing.Color.Transparent;
            this.LblWordCount.Location = new System.Drawing.Point(166, 678);
            this.LblWordCount.Name = "LblWordCount";
            this.LblWordCount.Size = new System.Drawing.Size(0, 13);
            this.LblWordCount.TabIndex = 9;
            // 
            // PnlLineNumbers
            // 
            this.PnlLineNumbers.Location = new System.Drawing.Point(145, 24);
            this.PnlLineNumbers.Name = "PnlLineNumbers";
            this.PnlLineNumbers.Size = new System.Drawing.Size(21, 647);
            this.PnlLineNumbers.TabIndex = 10;
            // 
            // TxtCommand
            // 
            this.TxtCommand.Location = new System.Drawing.Point(169, 671);
            this.TxtCommand.Name = "TxtCommand";
            this.TxtCommand.Size = new System.Drawing.Size(389, 20);
            this.TxtCommand.TabIndex = 11;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.optionsToolStripMenuItem,
            this.aboutToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1264, 24);
            this.menuStrip1.TabIndex = 12;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.createToolStripMenuItem,
            this.importToolStripMenuItem,
            this.saveToolStripMenuItem,
            this.quitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // createToolStripMenuItem
            // 
            this.createToolStripMenuItem.Name = "createToolStripMenuItem";
            this.createToolStripMenuItem.Size = new System.Drawing.Size(110, 22);
            this.createToolStripMenuItem.Text = "Create";
            // 
            // importToolStripMenuItem
            // 
            this.importToolStripMenuItem.Name = "importToolStripMenuItem";
            this.importToolStripMenuItem.Size = new System.Drawing.Size(110, 22);
            this.importToolStripMenuItem.Text = "Import";
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(110, 22);
            this.saveToolStripMenuItem.Text = "Save";
            // 
            // quitToolStripMenuItem
            // 
            this.quitToolStripMenuItem.Name = "quitToolStripMenuItem";
            this.quitToolStripMenuItem.Size = new System.Drawing.Size(110, 22);
            this.quitToolStripMenuItem.Text = "Quit";
            // 
            // optionsToolStripMenuItem
            // 
            this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
            this.optionsToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.optionsToolStripMenuItem.Text = "Options";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(52, 20);
            this.aboutToolStripMenuItem.Text = "About";
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // FrmMainMarkdown
            // 
            this.AcceptButton = this.BtnCreate;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.BtnQuit;
            this.ClientSize = new System.Drawing.Size(1264, 761);
            this.Controls.Add(this.TxtCommand);
            this.Controls.Add(this.PnlLineNumbers);
            this.Controls.Add(this.LblWordCount);
            this.Controls.Add(this.GrpBMDcontrols);
            this.Controls.Add(this.BtnQuit);
            this.Controls.Add(this.BtnOptions);
            this.Controls.Add(this.BtnAbout);
            this.Controls.Add(this.BtnSave);
            this.Controls.Add(this.BtnImport);
            this.Controls.Add(this.BtnCreate);
            this.Controls.Add(this.TxtUserMarkdown);
            this.Controls.Add(this.WBMarkdown);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(1280, 800);
            this.MinimumSize = new System.Drawing.Size(1280, 800);
            this.Name = "FrmMainMarkdown";
            this.Text = "Mark.JET";
            this.GrpBMDcontrols.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.WebBrowser WBMarkdown;
        private System.Windows.Forms.TextBox TxtUserMarkdown;
        private System.Windows.Forms.Button BtnCreate;
        private System.Windows.Forms.Button BtnImport;
        private System.Windows.Forms.Button BtnSave;
        private System.Windows.Forms.Button BtnAbout;
        private System.Windows.Forms.Button BtnOptions;
        private System.Windows.Forms.Button BtnQuit;
        private System.Windows.Forms.GroupBox GrpBMDcontrols;
        private System.Windows.Forms.Button BtnMDStrike;
        private System.Windows.Forms.Button BtnMDUnderline;
        private System.Windows.Forms.Button BtnMDItalic;
        private System.Windows.Forms.Button BtnMDHeader;
        private System.Windows.Forms.Button BtnMDBold;
        private System.Windows.Forms.Label LblWordCount;
        private System.Windows.Forms.Panel PnlLineNumbers;
        private System.Windows.Forms.TextBox TxtCommand;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem optionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem createToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem importToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem quitToolStripMenuItem;
    }
}

