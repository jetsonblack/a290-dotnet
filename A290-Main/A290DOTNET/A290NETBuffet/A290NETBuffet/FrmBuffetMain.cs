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
* Main Form Handler for the A290 Buffet Project
*
* Author: Jetson Black
* Date Created: 10/28/2024
* Last Modified by: Jetson Black
* Date Last Modified: 11/13/2024
* Assignment: A290 Buffet
* Part of: A290 Buffet Proj 1
***********************************************************/


/**********************************************************
* Design Changes Made
* 1. Changed the Default Font of the Form to Cascadia Code
* 2. Added Tool Tips to the Select Picture and the Quit Button
* 3. Changed Color and Font Color of the Select Picture Button
* 4. Changed Color and Font Color of the Quit Button
* 5. Changed Color and Font Color of the Draw Border Button
* 6. Changed Location of X/Y Cord Labels on Resize
* 7. Added Accept and Cancel Buttons (Select Picture, Quit)
* 8. Set a Default Directory (Photos) for the OpenFileDialogue
*   8a. This is referenced in the code @ Line 88
* 9. Various Changes to FrmBuffetMain, like window init location
*    and The title Text to 'Buffet Photo Viewer' and Icon Update
* 10. Added Dynamic Cursor that changes depending on what item
*     a user is hovering over, meaning that the pointer changes
*     to a hand when over a button.
* 11. Wrote a quick conditional to only allow a border to be drawn
*     if there is a picture in the picture box, preventing some 
*     graphical issues
***********************************************************/


namespace A290NETBuffet
{
    public partial class FrmBuffetMain : Form
    {
        public FrmBuffetMain()
            // Initalizes the Form and sets up some simple additional styling
        {
            InitializeComponent();
            ToolTip toolTip = new ToolTip();
            toolTip.SetToolTip(BtnSelectPicture, "Click to select an image file");
            toolTip.SetToolTip(BtnQuit, "Exit the application");

            // Calculate minimum height for the form, calculated by taking the hieghts of all combined controls, and then add spacing
            int controlHeight = BtnSelectPicture.Height + BtnQuit.Height + BtnDrawBorder.Height + BtnEnlarge.Height + BtnShrink.Height;
            int verticalSpacing = 10 * 4; // Spacing between each control, 10px for 4 Controls
            int minHeight = controlHeight + verticalSpacing + 100;

            // Calculate minimum width based on Template button width
            int minWidth = BtnQuit.Width + 300;

            // Set minimum size for the form
            this.MinimumSize = new Size(minWidth, minHeight);
        }        
        private void FrmBuffetMain_Load(object sender, EventArgs e)
        {
            LblX.Text = "";
            LblY.Text = "";
            // Anchor the PictureBox to all sides to resize with the form
            PicShowPicture.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;

            // Anchor each control to it's respective area
            BtnSelectPicture.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            BtnQuit.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            BtnEnlarge.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            BtnShrink.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            BtnDrawBorder.Anchor = AnchorStyles.Top | AnchorStyles.Right;

        }

        private void BtnSelectPicture_Click(object sender, EventArgs e)
        // Event Handler for when the Select Picture Button is Clicked
        {
            OfdSelectPicture.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);
            // Sets the default OpenFileDialogue Directory to the Photos Directory of the User's Machine
            if (OfdSelectPicture.ShowDialog() == DialogResult.OK)
            // Validity Check of the OpenFileDialogue Result
            {
                PicShowPicture.Image = Image.FromFile(OfdSelectPicture.FileName);
                // Grabs the Image from the File Selected in the OpenFileDialogue
                PicShowPicture.SizeMode = PictureBoxSizeMode.Zoom;
                // Sets the PictureBox to scale the image to fit within the control while maintaining the image's aspect ratio
                Text = string.Concat("A290 Buffet (" + OfdSelectPicture.FileName + ") ");
            }
        }
        private void BtnQuit_Click(object sender, EventArgs e)
        // Event Handler for when Quit Button is clicked
        {
            Close();
            // Allows for a more elequent way to exit the program, instead of the more archaic 'Red X' in the top right
        }

        private void BtnEnlarge_Click(object sender, EventArgs e)
        // Event Handler for when Enlarge Button is clicked
        {
            // Button that increases or 'Enlarges' the form size by incriments of 20px
            Width = Width + 20;
            Height = Height + 20;
        }

        private void BtnShrink_Click(object sender, EventArgs e)
        // Event Handler for when Shrink Button is clicked
        {
            // Button that decreases or 'Shrinks' the form size by incriments of 20px
            Width = Width - 20;
            Height = Height - 20;
        }

        private void BtnDrawBorder_Click(object sender, EventArgs e)
        // Event Handler for when Draw Border Button is clicked
        {
            if (PicShowPicture.Image == null) 
                // Only Allow for a Border to be drawn if there is a image in the picture box
            {
                MessageBox.Show("Error: No image loaded in the PictureBox.\nAdd a image to be able to draw a border", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return; // Exit the method if there is no image
            }
            using (Graphics ObjDrawBorder = CreateGraphics()) 
            // Creates the Graphics Object used in drawing the border
            {
                ObjDrawBorder.Clear(SystemColors.Control);
                // clears the forms graphical area, setting it back to default
                using (Pen borderPen = new Pen(Color.Crimson, 2))
                // initalizes a pen with crimson color with a stroke width of '2' to use for our border
                {
                    ObjDrawBorder.DrawRectangle(borderPen, PicShowPicture.Left - 1, PicShowPicture.Top - 1,
                        PicShowPicture.Width + 1, PicShowPicture.Height + 1);
                    // Draws the border with a 1px offset to ensure visability
                }
            }
        }

        private void PicShowPIcture_MouseMove(object sender, MouseEventArgs e)
        // Event Handler for when the mouse moves over PicShowPicture
        {
            LblX.Text = "X: " + e.X.ToString();
            LblY.Text = "Y: " + e.Y.ToString();
            // Updates LblX and LblY with the current X and Y coordinates of the mouse pointer within PicShowPicture
        }

        private void PicShowPIcture_MouseLeave(object sender, EventArgs e)
        // Event Handler for when the mouse leaves PicShowPicture
        {
            LblX.Text = "";
            LblY.Text = "";
            // Clears LblX and LblY when the mouse pointer is no longer within PicShowPicture
        }

        private void FrmBuffetMain_Resize(object sender, EventArgs e)
        // Event Handler for when the form is resized
        {

            if (PicShowPicture.Image != null)
            {
                using (Graphics ObjDrawBorder = CreateGraphics())
                // Creates a Graphics object for drawing directly on the form during resize
                // This Block redraws the border using the same steps as the 'BtnDrawBorder_Click' handler
                // thus ensuring that whenever the form is resized the border moves with the resized picture box
                {
                    ObjDrawBorder.Clear(SystemColors.Control);
                    using (Pen borderPen = new Pen(Color.Blue, 2))
                    {
                        ObjDrawBorder.DrawRectangle(borderPen,
                            PicShowPicture.Left - 1, PicShowPicture.Top - 1,
                            PicShowPicture.Width + 1, PicShowPicture.Height + 1);
                    }
                }
            }

            int padding = 20;
            // Updates padding space between controls and form edges

            
            int availWidth = this.ClientSize.Width - BtnSelectPicture.Width - (padding * 2);
            int availHeight = this.ClientSize.Height - (padding * 2);
            // Recalculates the Available Width and Available Height of the resized form

            PicShowPicture.Size = new Size(availWidth-10, availHeight-10);
            PicShowPicture.Location = new Point(padding, padding);
            // Updates the Picture Box to maintain it's sizing within the resized form


            int buttonRightEdge = this.ClientSize.Width - padding;
            BtnSelectPicture.Location = new Point(buttonRightEdge - BtnSelectPicture.Width, padding);
            BtnQuit.Location = new Point(buttonRightEdge - BtnQuit.Width, BtnSelectPicture.Bottom + 10);
            BtnDrawBorder.Location = new Point(buttonRightEdge - BtnDrawBorder.Width, BtnQuit.Bottom + 10);
            int bottomMargin = 20;
            BtnShrink.Location = new Point(buttonRightEdge - BtnShrink.Width, this.ClientSize.Height - BtnShrink.Height - bottomMargin);
            BtnEnlarge.Location = new Point(buttonRightEdge - BtnEnlarge.Width, BtnShrink.Top - BtnEnlarge.Height - 10);
            // The above block updates the locations of the controls based on the calculations derived from the resizing of the form



            LblX.Location = new Point(padding, this.ClientSize.Height - LblX.Height - bottomMargin);
            LblY.Location = new Point(LblX.Right + 50, this.ClientSize.Height - LblY.Height - bottomMargin);
            // moves the Labels depending on the resizing of the form, having LblY be dependant on LblX's location

            
        }
    }
}
