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
* FrmAbout.cs
*
* About Form for the Markdown Editor.
*
* Author: Jetson Black
* Date Created: 12/9/2024
* Last Modified by: Jetson Black
* Date Last Modified: 12/10/2024
* Assignment: Final A290 Project | Markdown Editor
* Part of: A290 Final Project
***********************************************************/
//============================================================
// Provides information about the author and basic Markdown formatting,
// and explains how the editor works. Matches formatting of main form.
//============================================================
namespace MarkDownManager
{
    public partial class FrmAbout : Form
    {
        public FrmAbout()
        {
            InitializeComponent();
            this.Load += FrmAbout_Load;
        }

        /// <summary>
        /// FrmAbout_Load: Sets the about text and applies dark mode formatting.
        /// </summary>
        private void FrmAbout_Load(object sender, EventArgs e)
        {
            LblAboutContent.Text = "Author: Jetson Black\n" +
                                   "Email: jetblack@iu.edu\n" +
                                   "GitHub: github.com/jetsonblack\n\n" +
                                   "Markdown is a lightweight markup language that you can use to add formatting elements to plaintext documents.\n" +
                                   "Basic formatting includes *italic*, **bold**, `inline code`, and # headers.\n" +
                                   "To create a header, start a line with one or more # characters. To italicize text, wrap it in asterisks. To bold, wrap in double asterisks.\n\n" +
                                   "This Markdown Editor lets you type Markdown on the left and see a live preview on the right.\n" +
                                   "You can use toolbar buttons or shortcuts, import/save files, toggle dark mode, and even use Vim commands.\n\n" +
                                   "Enjoy using this editor!";

            // Apply dark mode if enabled
            if (AppSettings.DarkModeEnabled)
            {
                this.BackColor = Color.FromArgb(40, 40, 40);
                this.ForeColor = Color.White;
                LblAboutContent.BackColor = Color.FromArgb(50, 50, 50);
                LblAboutContent.ForeColor = Color.White;
            }
            else
            {
                this.BackColor = SystemColors.Control;
                this.ForeColor = SystemColors.ControlText;
                LblAboutContent.BackColor = SystemColors.Control;
                LblAboutContent.ForeColor = SystemColors.ControlText;
            }
        }
    }
}
