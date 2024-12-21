using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
/**********************************************************
* FrmBuffetMain.cs
*
* Main Form Handler.
*
* Author: Jetson Black
* Date Created: 10/28/2024
* Last Modified by: Jetson Black
* Date Last Modified: 11/11/2024
* Assignment: A290 Buffet
* Part of: A290
***********************************************************/

namespace A290Buffet

{
    public partial class FrmBuffetMain : Form
    {
        public FrmBuffetMain()
        {
            InitializeComponent();
            this.BackColor = ColorTranslator.FromHtml("#002b36"); ;
            this.Opacity = 0.95;

            ToolTip toolTip = new ToolTip();
            toolTip.SetToolTip(BtnSelectPicture, "Click to select an image file");
            toolTip.SetToolTip(BtnQuit, "Exit the application");

            // Calculate minimum height
            int controlHeight = BtnSelectPicture.Height + BtnQuit.Height + BtnDrawBorder.Height + BtnEnlarge.Height + BtnShrink.Height;
            int verticalSpacing = 10 * 4; // Spacing between each control
            int minHeight = controlHeight + verticalSpacing + 100;

            // Calculate minimum width based on Quit button
            int minWidth = BtnQuit.Width + 300;

            // Set minimum size for the form
            this.MinimumSize = new Size(minWidth, minHeight);

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LblX.Text = "";
            LblY.Text = "";
            // Anchor the PictureBox to all sides to resize with the form
            PicShowPicture.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;

            //Anchor buttons to specific locations(e.g., bottom - right or bottom - left)
            BtnSelectPicture.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            BtnQuit.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            BtnEnlarge.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            BtnShrink.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            BtnDrawBorder.Anchor = AnchorStyles.Top | AnchorStyles.Right;

            BtnSelectPicture.BackColor = ColorTranslator.FromHtml("#859900");
            BtnSelectPicture.ForeColor = ColorTranslator.FromHtml("#fdf6e3");
            BtnQuit.BackColor = ColorTranslator.FromHtml("#dc322f");
            BtnQuit.ForeColor = ColorTranslator.FromHtml("#fdf6e3");
            LblX.Font = new Font("Arial", 10, FontStyle.Italic);
            LblY.Font = new Font("Arial", 10, FontStyle.Italic);
            BtnSelectPicture.FlatStyle = FlatStyle.Flat;
            BtnSelectPicture.FlatAppearance.BorderColor = Color.DarkGreen;
            BtnSelectPicture.FlatAppearance.BorderSize = 1;
            PicShowPicture.Cursor = Cursors.Hand;
        }

        private void BtnSelectPicture_Click(object sender, EventArgs e)
        {
            if (OfdSelectPicture.ShowDialog() == DialogResult.OK)
            {
                PicShowPicture.Image = Image.FromFile(OfdSelectPicture.FileName); // Load the picture into the Box  
                PicShowPicture.SizeMode = PictureBoxSizeMode.Zoom; // Maintain aspect ratio within PictureBox
                Text = string.Concat("A290 Buffet(" + OfdSelectPicture.FileName + ")"); // show the name of the file in the Form's title
            }
        }
        private void PicShowPicture_Click(object sender, EventArgs e)
        {
            this.PicShowPicture.SizeMode = PictureBoxSizeMode.Zoom;
            System.Diagnostics.Debug.WriteLine("PicShowPicture Clicked");
        }

        private void BtnQuit_Click(object sender, EventArgs e)
        {
            Close(); // Exits the Application in a clearly defined intenral method instead of simply using the Red 'X'
        }

        private void BtnEnlarge_Click(object sender, EventArgs e)
        {
            Width = Width + 20;
            Height = Height + 20;
        }

        private void BtnShrink_Click(object sender, EventArgs e)
        {
            Width = Width - 20;
            Height = Height - 20;
        }

        private void BtnDrawBorder_Click(object sender, EventArgs e)
        {
            Graphics ObjDrawBorder = null;
            ObjDrawBorder = CreateGraphics();
            ObjDrawBorder.Clear(SystemColors.Control);
            ObjDrawBorder.DrawRectangle(Pens.Blue,
                PicShowPicture.Left -1, PicShowPicture.Top -1,
                width: PicShowPicture.Width + 1, height: PicShowPicture.Height + 1);
        }

        private void PicShowPicture_MouseMove(object sender, MouseEventArgs e)
        {
            LblX.Text = "X: " + e.X.ToString();
            LblY.Text = "Y: " + e.Y.ToString();

        }

        private void PicShowPicture_MouseLeave(object sender, EventArgs e)
        {
            LblX.Text = "";
            LblY.Text = "";
        }

        private void FrmBuffetMain_Resize(object sender, EventArgs e)
        {
            // Padding for the PictureBox and labels to keep them away from edges
            int padding = 20;

            // Calculate the available space for the PictureBox, leaving room for controls on the right
            int availableWidth = this.ClientSize.Width - BtnSelectPicture.Width - (2 * padding);
            int availableHeight = this.ClientSize.Height - (2 * padding);

            // Set the PictureBox size while maintaining the aspect ratio if needed
            PicShowPicture.Size = new Size(availableWidth, availableHeight);
            PicShowPicture.Location = new Point(padding, padding);

            // Right-side positioning for other buttons
            int buttonRightEdge = this.ClientSize.Width - padding;

            BtnSelectPicture.Location = new Point(buttonRightEdge - BtnSelectPicture.Width, padding);
            BtnQuit.Location = new Point(buttonRightEdge - BtnQuit.Width, BtnSelectPicture.Bottom + 10);
            BtnDrawBorder.Location = new Point(buttonRightEdge - BtnDrawBorder.Width, BtnQuit.Bottom + 10);

            // Position Enlarge and Shrink buttons at the bottom-right of the form
            int bottomMargin = 20;
            BtnShrink.Location = new Point(buttonRightEdge - BtnShrink.Width, this.ClientSize.Height - BtnShrink.Height - bottomMargin);
            BtnEnlarge.Location = new Point(buttonRightEdge - BtnEnlarge.Width, BtnShrink.Top - BtnEnlarge.Height - 10);

            // Position the X and Y labels near the bottom-left corner
            LblX.Location = new Point(padding, this.ClientSize.Height - LblX.Height - bottomMargin);
            LblY.Location = new Point(LblX.Right + 30, this.ClientSize.Height - LblY.Height - bottomMargin);

            // Redraw the border if there's an image
            if (PicShowPicture.Image != null)
            {
                using (Graphics ObjDrawBorder = CreateGraphics())
                {
                    ObjDrawBorder.Clear(SystemColors.Control);
                    ObjDrawBorder.DrawRectangle(Pens.Blue,
                        PicShowPicture.Left - 1, PicShowPicture.Top - 1,
                        PicShowPicture.Width + 1, PicShowPicture.Height + 1);
                }
            }
        }
    }
}
