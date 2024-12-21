namespace PostFixCalculator
{
    partial class FrmPostFixCalculator
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmPostFixCalculator));
            this.TxtFirstNum = new System.Windows.Forms.TextBox();
            this.TxtSecondNum = new System.Windows.Forms.TextBox();
            this.TxtResult = new System.Windows.Forms.TextBox();
            this.BtnAdd = new System.Windows.Forms.Button();
            this.BtnSubt = new System.Windows.Forms.Button();
            this.BtnMult = new System.Windows.Forms.Button();
            this.BtnDiv = new System.Windows.Forms.Button();
            this.BtnClear = new System.Windows.Forms.Button();
            this.BtnQuit = new System.Windows.Forms.Button();
            this.LblFirstNum = new System.Windows.Forms.Label();
            this.LblSecondNum = new System.Windows.Forms.Label();
            this.LblResult = new System.Windows.Forms.Label();
            this.BtnExp = new System.Windows.Forms.Button();
            this.LblBinary = new System.Windows.Forms.Label();
            this.BtnSin = new System.Windows.Forms.Button();
            this.BtnCos = new System.Windows.Forms.Button();
            this.BtnTan = new System.Windows.Forms.Button();
            this.LblUnary = new System.Windows.Forms.Label();
            this.ChkRadianToggle = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // TxtFirstNum
            // 
            this.TxtFirstNum.Location = new System.Drawing.Point(106, 90);
            this.TxtFirstNum.Name = "TxtFirstNum";
            this.TxtFirstNum.Size = new System.Drawing.Size(183, 22);
            this.TxtFirstNum.TabIndex = 0;
            this.TxtFirstNum.Leave += new System.EventHandler(this.TxtFirstNum_Leave);
            this.TxtFirstNum.MouseDown += new System.Windows.Forms.MouseEventHandler(this.TxtFirstNum_MouseDown);
            // 
            // TxtSecondNum
            // 
            this.TxtSecondNum.Location = new System.Drawing.Point(108, 260);
            this.TxtSecondNum.Name = "TxtSecondNum";
            this.TxtSecondNum.Size = new System.Drawing.Size(181, 22);
            this.TxtSecondNum.TabIndex = 1;
            this.TxtSecondNum.Leave += new System.EventHandler(this.TxtSecondNum_Leave);
            this.TxtSecondNum.MouseDown += new System.Windows.Forms.MouseEventHandler(this.TxtSecondNum_MouseDown);
            // 
            // TxtResult
            // 
            this.TxtResult.Location = new System.Drawing.Point(106, 444);
            this.TxtResult.Name = "TxtResult";
            this.TxtResult.Size = new System.Drawing.Size(183, 22);
            this.TxtResult.TabIndex = 2;
            // 
            // BtnAdd
            // 
            this.BtnAdd.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnAdd.Location = new System.Drawing.Point(95, 340);
            this.BtnAdd.Name = "BtnAdd";
            this.BtnAdd.Size = new System.Drawing.Size(35, 35);
            this.BtnAdd.TabIndex = 3;
            this.BtnAdd.Text = "+";
            this.BtnAdd.UseVisualStyleBackColor = true;
            this.BtnAdd.Click += new System.EventHandler(this.BtnAdd_Click);
            // 
            // BtnSubt
            // 
            this.BtnSubt.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnSubt.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnSubt.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnSubt.Location = new System.Drawing.Point(136, 340);
            this.BtnSubt.Name = "BtnSubt";
            this.BtnSubt.Size = new System.Drawing.Size(35, 35);
            this.BtnSubt.TabIndex = 4;
            this.BtnSubt.Text = "-";
            this.BtnSubt.UseVisualStyleBackColor = true;
            this.BtnSubt.Click += new System.EventHandler(this.BtnSubt_Click);
            // 
            // BtnMult
            // 
            this.BtnMult.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnMult.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnMult.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnMult.Location = new System.Drawing.Point(178, 340);
            this.BtnMult.Name = "BtnMult";
            this.BtnMult.Size = new System.Drawing.Size(35, 35);
            this.BtnMult.TabIndex = 5;
            this.BtnMult.Text = "*";
            this.BtnMult.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.BtnMult.UseVisualStyleBackColor = true;
            this.BtnMult.Click += new System.EventHandler(this.BtnMult_Click);
            // 
            // BtnDiv
            // 
            this.BtnDiv.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnDiv.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnDiv.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnDiv.Location = new System.Drawing.Point(219, 340);
            this.BtnDiv.Name = "BtnDiv";
            this.BtnDiv.Size = new System.Drawing.Size(35, 35);
            this.BtnDiv.TabIndex = 6;
            this.BtnDiv.Text = "/";
            this.BtnDiv.UseVisualStyleBackColor = true;
            this.BtnDiv.Click += new System.EventHandler(this.BtnDiv_Click);
            // 
            // BtnClear
            // 
            this.BtnClear.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnClear.FlatAppearance.BorderSize = 0;
            this.BtnClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnClear.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnClear.Location = new System.Drawing.Point(246, 470);
            this.BtnClear.Name = "BtnClear";
            this.BtnClear.Size = new System.Drawing.Size(43, 20);
            this.BtnClear.TabIndex = 7;
            this.BtnClear.Text = "AC";
            this.BtnClear.UseVisualStyleBackColor = true;
            this.BtnClear.Click += new System.EventHandler(this.BtnClear_Click);
            // 
            // BtnQuit
            // 
            this.BtnQuit.CausesValidation = false;
            this.BtnQuit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnQuit.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.BtnQuit.FlatAppearance.BorderColor = System.Drawing.Color.LightGray;
            this.BtnQuit.FlatAppearance.BorderSize = 0;
            this.BtnQuit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnQuit.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnQuit.Location = new System.Drawing.Point(318, 524);
            this.BtnQuit.Name = "BtnQuit";
            this.BtnQuit.Size = new System.Drawing.Size(54, 25);
            this.BtnQuit.TabIndex = 8;
            this.BtnQuit.Text = "Quit";
            this.BtnQuit.UseVisualStyleBackColor = true;
            this.BtnQuit.Click += new System.EventHandler(this.BtnQuit_Click);
            // 
            // LblFirstNum
            // 
            this.LblFirstNum.AutoSize = true;
            this.LblFirstNum.Font = new System.Drawing.Font("Nirmala UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblFirstNum.Location = new System.Drawing.Point(144, 67);
            this.LblFirstNum.Name = "LblFirstNum";
            this.LblFirstNum.Size = new System.Drawing.Size(102, 21);
            this.LblFirstNum.TabIndex = 9;
            this.LblFirstNum.Text = "First Number";
            // 
            // LblSecondNum
            // 
            this.LblSecondNum.AutoSize = true;
            this.LblSecondNum.Font = new System.Drawing.Font("Nirmala UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblSecondNum.Location = new System.Drawing.Point(133, 237);
            this.LblSecondNum.Name = "LblSecondNum";
            this.LblSecondNum.Size = new System.Drawing.Size(123, 21);
            this.LblSecondNum.TabIndex = 10;
            this.LblSecondNum.Text = "Second Number";
            // 
            // LblResult
            // 
            this.LblResult.AutoSize = true;
            this.LblResult.Font = new System.Drawing.Font("Nirmala UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblResult.Location = new System.Drawing.Point(169, 421);
            this.LblResult.Name = "LblResult";
            this.LblResult.Size = new System.Drawing.Size(53, 21);
            this.LblResult.TabIndex = 11;
            this.LblResult.Text = "Result";
            // 
            // BtnExp
            // 
            this.BtnExp.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnExp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnExp.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnExp.Location = new System.Drawing.Point(260, 340);
            this.BtnExp.Name = "BtnExp";
            this.BtnExp.Size = new System.Drawing.Size(35, 35);
            this.BtnExp.TabIndex = 12;
            this.BtnExp.Text = "^";
            this.BtnExp.UseVisualStyleBackColor = true;
            this.BtnExp.Click += new System.EventHandler(this.BtnExp_Click);
            // 
            // LblBinary
            // 
            this.LblBinary.AutoSize = true;
            this.LblBinary.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblBinary.Location = new System.Drawing.Point(150, 319);
            this.LblBinary.Name = "LblBinary";
            this.LblBinary.Size = new System.Drawing.Size(98, 15);
            this.LblBinary.TabIndex = 13;
            this.LblBinary.Text = "Binary Operators";
            // 
            // BtnSin
            // 
            this.BtnSin.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnSin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnSin.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnSin.Location = new System.Drawing.Point(130, 135);
            this.BtnSin.Name = "BtnSin";
            this.BtnSin.Size = new System.Drawing.Size(43, 29);
            this.BtnSin.TabIndex = 14;
            this.BtnSin.Text = "Sin";
            this.BtnSin.UseVisualStyleBackColor = true;
            this.BtnSin.Click += new System.EventHandler(this.BtnSin_Click);
            // 
            // BtnCos
            // 
            this.BtnCos.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnCos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnCos.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnCos.Location = new System.Drawing.Point(179, 135);
            this.BtnCos.Name = "BtnCos";
            this.BtnCos.Size = new System.Drawing.Size(45, 29);
            this.BtnCos.TabIndex = 15;
            this.BtnCos.Text = "Cos";
            this.BtnCos.UseVisualStyleBackColor = true;
            this.BtnCos.Click += new System.EventHandler(this.BtnCos_Click);
            // 
            // BtnTan
            // 
            this.BtnTan.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnTan.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnTan.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnTan.Location = new System.Drawing.Point(230, 135);
            this.BtnTan.Name = "BtnTan";
            this.BtnTan.Size = new System.Drawing.Size(41, 29);
            this.BtnTan.TabIndex = 16;
            this.BtnTan.Text = "Tan";
            this.BtnTan.UseVisualStyleBackColor = true;
            this.BtnTan.Click += new System.EventHandler(this.BtnTan_Click);
            // 
            // LblUnary
            // 
            this.LblUnary.AutoSize = true;
            this.LblUnary.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblUnary.Location = new System.Drawing.Point(150, 117);
            this.LblUnary.Name = "LblUnary";
            this.LblUnary.Size = new System.Drawing.Size(96, 15);
            this.LblUnary.TabIndex = 17;
            this.LblUnary.Text = "Unary Operators";
            // 
            // ChkRadianToggle
            // 
            this.ChkRadianToggle.AutoSize = true;
            this.ChkRadianToggle.Checked = true;
            this.ChkRadianToggle.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ChkRadianToggle.Location = new System.Drawing.Point(106, 165);
            this.ChkRadianToggle.Name = "ChkRadianToggle";
            this.ChkRadianToggle.Size = new System.Drawing.Size(211, 17);
            this.ChkRadianToggle.TabIndex = 18;
            this.ChkRadianToggle.Text = "Radian Mode (Uncheck for Degrees)";
            this.ChkRadianToggle.UseVisualStyleBackColor = true;
            this.ChkRadianToggle.CheckedChanged += new System.EventHandler(this.ChkRadianToggle_CheckedChanged);
            // 
            // FrmPostFixCalculator
            // 
            this.AcceptButton = this.BtnClear;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.CancelButton = this.BtnQuit;
            this.ClientSize = new System.Drawing.Size(384, 561);
            this.Controls.Add(this.ChkRadianToggle);
            this.Controls.Add(this.LblUnary);
            this.Controls.Add(this.BtnTan);
            this.Controls.Add(this.BtnCos);
            this.Controls.Add(this.BtnSin);
            this.Controls.Add(this.LblBinary);
            this.Controls.Add(this.BtnExp);
            this.Controls.Add(this.LblResult);
            this.Controls.Add(this.LblSecondNum);
            this.Controls.Add(this.LblFirstNum);
            this.Controls.Add(this.BtnQuit);
            this.Controls.Add(this.BtnClear);
            this.Controls.Add(this.BtnDiv);
            this.Controls.Add(this.BtnMult);
            this.Controls.Add(this.BtnSubt);
            this.Controls.Add(this.BtnAdd);
            this.Controls.Add(this.TxtResult);
            this.Controls.Add(this.TxtSecondNum);
            this.Controls.Add(this.TxtFirstNum);
            this.Font = new System.Drawing.Font("Nirmala UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(400, 600);
            this.MinimumSize = new System.Drawing.Size(400, 600);
            this.Name = "FrmPostFixCalculator";
            this.Opacity = 0.95D;
            this.Text = "Post Fix Calculator";
            this.Load += new System.EventHandler(this.FrmPostFixCalculator_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox TxtFirstNum;
        private System.Windows.Forms.TextBox TxtSecondNum;
        private System.Windows.Forms.TextBox TxtResult;
        private System.Windows.Forms.Button BtnAdd;
        private System.Windows.Forms.Button BtnSubt;
        private System.Windows.Forms.Button BtnMult;
        private System.Windows.Forms.Button BtnDiv;
        private System.Windows.Forms.Button BtnClear;
        private System.Windows.Forms.Button BtnQuit;
        private System.Windows.Forms.Label LblFirstNum;
        private System.Windows.Forms.Label LblSecondNum;
        private System.Windows.Forms.Label LblResult;
        private System.Windows.Forms.Button BtnExp;
        private System.Windows.Forms.Label LblBinary;
        private System.Windows.Forms.Button BtnSin;
        private System.Windows.Forms.Button BtnCos;
        private System.Windows.Forms.Button BtnTan;
        private System.Windows.Forms.Label LblUnary;
        private System.Windows.Forms.CheckBox ChkRadianToggle;
    }
}

