namespace A290BUFFPT2
{
    partial class FrmCollections
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
            this.BtnShowNames = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // BtnShowNames
            // 
            this.BtnShowNames.Location = new System.Drawing.Point(225, 70);
            this.BtnShowNames.Name = "BtnShowNames";
            this.BtnShowNames.Size = new System.Drawing.Size(150, 23);
            this.BtnShowNames.TabIndex = 0;
            this.BtnShowNames.Text = "Show Control Names";
            this.BtnShowNames.UseVisualStyleBackColor = true;
            this.BtnShowNames.Click += new System.EventHandler(this.BtnShowNames_Click);
            // 
            // FrmCollections
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 561);
            this.Controls.Add(this.BtnShowNames);
            this.Name = "FrmCollections";
            this.Text = "Collections";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button BtnShowNames;
    }
}

