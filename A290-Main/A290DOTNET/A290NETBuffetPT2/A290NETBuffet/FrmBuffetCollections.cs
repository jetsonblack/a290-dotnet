using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
/**********************************************************
* FrmBuffetCollections.cs
*
* Collections Form Handler for the A290 Buffet Project
*
* Author: Jetson Black
* Date Created: 11/18/2024
* Last Modified by: Jetson Black
* Date Last Modified: 11/21/2024
* Assignment: A290 Buffet Homework 2
* Part of: A290 Buffet Proj 2
***********************************************************/
/**********************************************************
 * All Buttons are distinct in Someway Shape or Form!
 * 1. All Buttons are using the Flat Type, which is
 *    Consistant across my Program (With Custom Border Colors)
 * 2. Each uses unique Background Colors that
 *    Loosely correlate to the button's function
 * 3. All Buttons with a actual Function Have the Olbique Bold
 *    Font Styling on Them
 ***********************************************************/

namespace A290NETBuffet
{
    public partial class FrmBuffetCollections : Form
    {
        public FrmBuffetCollections()
        {
            InitializeComponent();
        }

        private void BtnShowNames_Click(object sender, EventArgs e)
        {// Handles the Click Event on 'BtnShowNames', which loops through
         // The Control Collection and Pops a message to the User which states
         // The name of the Control we are currently over
            for (int intindex = 0; intindex < Controls.Count; intindex++)
            { // Loops through the Controls Collection
                
                // Create a Message Box that Has the Control Number, and the
                // Name of the Control to show the user.
                MessageBox.Show("Control #" + intindex.ToString() +
                    " has the name " + Controls[intindex].Name);
            }

        }

        private void BtnCollectionsQuit_Click(object sender, EventArgs e)
        { // Event Handler For When the 'Quit' Button is Clicked
            Close(); // Allows for a more elequent way to exit the program, instead of the more archaic 'Red X' in the top right
        }

        private void ChkIMGBG_CheckedChanged(object sender, EventArgs e)
        {
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
                }
            }
        }

        private void BtnGist_Click(object sender, EventArgs e)
        { // Handles Clicks on the 'Click This Button' Gist Button
            try
            {   // Simple Try Catch to try and open the user's Browser for a change to see the
                // Cool MD gist I Made. (Also in README.txt)
                // Specify the which URL to open (my gist in this case)
                string url = "https://gist.github.com/jetsonblack/ec0564e12480c1c60fd52c3f9f908bcd";

                // Open the URL in the user's default web browser
                System.Diagnostics.Process.Start(new ProcessStartInfo
                {
                    FileName = url,
                    UseShellExecute = true // Ensures the default browser is used
                });
            }
            catch (Exception ex)
            {
                // Show an error message if something goes wrong
                MessageBox.Show($"Error opening URL: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
