namespace MarkDownManager
{
    partial class FrmOptions
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmOptions));
            this.ChkDarkMode = new System.Windows.Forms.CheckBox();
            this.BtnApply = new System.Windows.Forms.Button();
            this.BtnCancel = new System.Windows.Forms.Button();
            this.ChkWordCount = new System.Windows.Forms.CheckBox();
            this.ChkWordWrap = new System.Windows.Forms.CheckBox();
            this.ChkVimMode = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // ChkDarkMode
            // 
            this.ChkDarkMode.AutoSize = true;
            this.ChkDarkMode.Location = new System.Drawing.Point(12, 12);
            this.ChkDarkMode.Name = "ChkDarkMode";
            this.ChkDarkMode.Size = new System.Drawing.Size(84, 19);
            this.ChkDarkMode.TabIndex = 0;
            this.ChkDarkMode.Text = "Dark Mode";
            this.ChkDarkMode.UseVisualStyleBackColor = true;
            // 
            // BtnApply
            // 
            this.BtnApply.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.BtnApply.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnApply.Location = new System.Drawing.Point(5, 126);
            this.BtnApply.Name = "BtnApply";
            this.BtnApply.Size = new System.Drawing.Size(75, 28);
            this.BtnApply.TabIndex = 1;
            this.BtnApply.Text = "Apply";
            this.BtnApply.UseVisualStyleBackColor = true;
            // 
            // BtnCancel
            // 
            this.BtnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.BtnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnCancel.Location = new System.Drawing.Point(86, 126);
            this.BtnCancel.Name = "BtnCancel";
            this.BtnCancel.Size = new System.Drawing.Size(75, 28);
            this.BtnCancel.TabIndex = 2;
            this.BtnCancel.Text = "Cancel";
            this.BtnCancel.UseVisualStyleBackColor = true;
            // 
            // ChkWordCount
            // 
            this.ChkWordCount.AutoSize = true;
            this.ChkWordCount.Location = new System.Drawing.Point(12, 37);
            this.ChkWordCount.Name = "ChkWordCount";
            this.ChkWordCount.Size = new System.Drawing.Size(91, 19);
            this.ChkWordCount.TabIndex = 3;
            this.ChkWordCount.Text = "Word Count";
            this.ChkWordCount.UseVisualStyleBackColor = true;
            // 
            // ChkWordWrap
            // 
            this.ChkWordWrap.AutoSize = true;
            this.ChkWordWrap.Location = new System.Drawing.Point(12, 62);
            this.ChkWordWrap.Name = "ChkWordWrap";
            this.ChkWordWrap.Size = new System.Drawing.Size(86, 19);
            this.ChkWordWrap.TabIndex = 5;
            this.ChkWordWrap.Text = "Word Wrap";
            this.ChkWordWrap.UseVisualStyleBackColor = true;
            // 
            // ChkVimMode
            // 
            this.ChkVimMode.AutoSize = true;
            this.ChkVimMode.Location = new System.Drawing.Point(12, 87);
            this.ChkVimMode.Name = "ChkVimMode";
            this.ChkVimMode.Size = new System.Drawing.Size(81, 19);
            this.ChkVimMode.TabIndex = 6;
            this.ChkVimMode.Text = "Vim Mode";
            this.ChkVimMode.UseVisualStyleBackColor = true;
            // 
            // FrmOptions
            // 
            this.AcceptButton = this.BtnApply;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.BtnCancel;
            this.ClientSize = new System.Drawing.Size(202, 179);
            this.Controls.Add(this.ChkVimMode);
            this.Controls.Add(this.ChkWordWrap);
            this.Controls.Add(this.ChkWordCount);
            this.Controls.Add(this.BtnCancel);
            this.Controls.Add(this.BtnApply);
            this.Controls.Add(this.ChkDarkMode);
            this.Font = new System.Drawing.Font("Nirmala UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(218, 218);
            this.MinimumSize = new System.Drawing.Size(218, 218);
            this.Name = "FrmOptions";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Options";
            this.Load += new System.EventHandler(this.FrmOptions_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.CheckBox ChkDarkMode;
        private System.Windows.Forms.Button BtnApply;
        private System.Windows.Forms.Button BtnCancel;
        internal System.Windows.Forms.CheckBox ChkWordCount;
        internal System.Windows.Forms.CheckBox ChkWordWrap;
        internal System.Windows.Forms.CheckBox ChkVimMode;
    }
}