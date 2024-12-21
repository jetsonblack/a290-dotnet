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
* FrmBuffetOptions.cs
*
* Options Form Handler for the A290 Buffet Project
*
* Author: Jetson Black
* Date Created: 11/18/2024
* Last Modified by: Jetson Black
* Date Last Modified: 11/21/2024
* Assignment: A290 Buffet Homework 2
* Part of: A290 Buffet Proj 2
***********************************************************/

namespace A290NETBuffet
{
    public partial class FrmBuffetOptions : Form
    {
        // Variable to Store the Current Border Color Defaults to LightGray,
        // allows for persistance When Changing Background Color
        private Color _borderColor = Color.LightGray;
        // Variable to Store the Current Background Color Defaults to LightGray,
        // allows for persistance When Changing Border Color
        private Color _lastBackgroundColor = Color.LightGray;
        public FrmBuffetOptions()
        {
            InitializeComponent();
        }

        private void BtnOk_Click(object sender, EventArgs e)
        { // Event Handler For When the 'OK' Button is Clicked
            Close(); // Allows for a more elequent way to exit the program, instead of the more archaic 'Red X' in the top right
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        { // Event Handler For When the 'Cancel' Button is Clicked
            Close(); // Allows for a more elequent way to exit the program, instead of the more archaic 'Red X' in the top right
        }

        private void OptBackgroundDefault_CheckedChanged(object sender, EventArgs e)
        { // Event Handler For When The 'Default' Radio Button is Toggled
            if (OptBackgroundDefault.Checked)
            { // A simple Check to ensure the correct event is checked
                _lastBackgroundColor = Color.LightGray; // Update the stored color
                BackColor = _lastBackgroundColor; // Update the Background Color to what the lastBackgroundColor was set as
                DrawBorder(); // Redraw the Border to Ensure it persists.
            }
        }

        private void OptBackgroundWhite_CheckedChanged(object sender, EventArgs e)
        { // Event Handler For When The 'White' Radio Button is Toggled
            if (OptBackgroundWhite.Checked)
            { // A simple Check to ensure the correct event is checked
                _lastBackgroundColor = Color.White; // Update the stored color
                BackColor = _lastBackgroundColor; // Update the Background Color to what the lastBackgroundColor was set as
                DrawBorder(); // Redraw the Border to Ensure it persists.
            }
        }

        private void OptBackgroundBlue_CheckedChanged(object sender, EventArgs e)
        {// Event Handler For When The 'Blue' Radio Button is Toggled
            if (OptBackgroundBlue.Checked)
            { // A simple Check to ensure the correct event is checked
                _lastBackgroundColor = Color.Blue; // Update the stored color
                BackColor = _lastBackgroundColor; // Update the Background Color to what the lastBackgroundColor was set as
                DrawBorder(); // Redraw the Border to Ensure it persists.
            } 
        }

        private void OptBackgroundGreen_CheckedChanged(object sender, EventArgs e)
        {// Event Handler For When The 'Green' Radio Button is Toggled
            if (OptBackgroundGreen.Checked)
            { // A simple Check to ensure the correct event is checked
                _lastBackgroundColor = Color.Green; // Update the stored color
                BackColor = _lastBackgroundColor; // Update the Background Color to what the lastBackgroundColor was set as
                DrawBorder(); // Redraw the Border to Ensure it persists.
            }
        }

        private void CboBorderColors_SelectedIndexChanged(object sender, EventArgs e)
        {
            // This event handler is triggered whenever the selected index in the drop-down combo box (CboBorderColors) changes.
            // The user's selection determines the color of the form's border.
            switch (CboBorderColors.Text)
            {
                // Case for when "Yellow" is selected
                case "Yellow":
                    MessageBox.Show("Yellow Was Chosen"); // Notify the user of the chosen color
                    _borderColor = Color.Yellow;         // Update the border color variable
                    break;

                // Case for when "Cyan" is selected
                case "Cyan":
                    MessageBox.Show("Cyan Was Chosen");
                    _borderColor = Color.Cyan;
                    break;

                // Case for when "Blue" is selected
                case "Blue":
                    MessageBox.Show("Blue Was Chosen");
                    _borderColor = Color.Blue;
                    break;

                // Case for when "Red" is selected
                case "Red":
                    MessageBox.Show("Red Was Chosen");
                    _borderColor = Color.Red;
                    break;

                // Case for when "Magenta" is selected
                case "Magenta":
                    MessageBox.Show("Magenta Was Chosen");
                    _borderColor = Color.Magenta;
                    break;

                // Default case for any unrecognized selection (including empty or invalid input)
                default:
                    MessageBox.Show("Back to the Default");
                    _borderColor = Color.LightGray; // Revert to the default border color
                    break;
            }

            // Redraw the form's border to reflect the new color
            DrawBorder();
        }
        private void DrawBorder()
        {
            // This function is responsible for drawing the border around the form using the currently selected border color (_borderColor).
            // It uses the Graphics object associated with the form to draw a rectangle representing the border.

            using (Graphics graphics = CreateGraphics()) // Obtain the Graphics object for the form
            using (Pen borderPen = new Pen(_borderColor, 2)) // Create a pen with the selected color and a thickness of 2 pixels
            {
                // Draw a rectangle around the edges of the form
                // The rectangle's coordinates are slightly inset (1, 1) to avoid overlapping the form's edges.
                // The width and height are adjusted to fit within the form's bounds.
                graphics.DrawRectangle(borderPen, 1, 1, 382, 359);
            }
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            // This method overrides the default OnPaint behavior to ensure the border is always drawn
            // whenever the form repaints itself (e.g., due to resizing, minimizing, or maximizing).

            base.OnPaint(e); // Call the base class's OnPaint method to handle default painting behavior

            // Explicitly call DrawBorder to ensure the border appears correctly after a repaint
            DrawBorder();
        }

        private void ChkIMGBG_CheckedChanged(object sender, EventArgs e)
        {
            // This event handler toggles the background of the form between an image and a solid color
            // based on the state of the "Image Background" checkbox (ChkIMGBG).

            if (ChkIMGBG.Checked) // Check if the checkbox is checked
            {
                // If the checkbox is checked, set an image as the form's background.
                try
                {
                    BackgroundImage = Properties.Resources.whitebackground; // Load the image resource as the background
                    BackgroundImageLayout = ImageLayout.Stretch; // Set how the image is displayed (stretched to fit the form)

                    // Options for BackgroundImageLayout:
                    // - Tile: Repeats the image to fill the form.
                    // - Center: Centers the image without resizing.
                    // - Stretch: Stretches the image to fill the form.
                    // - Zoom: Resizes the image proportionally to fit the form.
                    // - None: Displays the image at its original size.
                }
                catch (Exception ex) // Handle any errors that occur while loading the image
                {
                    // Show an error message if the image cannot be loaded
                    MessageBox.Show($"Error loading image: {ex.Message}");

                    // Uncheck the checkbox to indicate that the operation failed
                    ChkIMGBG.Checked = false;
                }
            }
            else // If the checkbox is unchecked
            {
                // Remove the image and revert the form's background to the last selected solid color.
                BackgroundImage = null; // Clear the background image
                BackColor = _lastBackgroundColor; // Restore the previously selected background color
            }

            // Redraw the border to ensure it appears correctly with the new background setting.
            DrawBorder();
        }
    }
}
