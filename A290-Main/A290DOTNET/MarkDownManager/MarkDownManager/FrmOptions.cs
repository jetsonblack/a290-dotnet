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
* FrmOptions.cs
*
* Options Form Handler for the Markdown Editor. 
*
* Author: Jetson Black
* Date Created: 12/9/2024
* Last Modified by: Jetson Black
* Date Last Modified: 12/10/2024
* Assignment: Final A290 Project | Markdown Editor
* Part of: A290 Final Project
***********************************************************/

//============================================================
// This form provides various checkboxes and buttons allowing
// the user to modify application settings: Dark Mode, Word Count,
// Line Numbers, Word Wrap, and Vim Mode. The user can apply changes
// or cancel out.
//============================================================

namespace MarkDownManager
{
    public partial class FrmOptions : Form
    {
        public FrmOptions()
        {
            InitializeComponent();
            // Assigning event handlers programmatically
            this.Load += FrmOptions_Load;
            BtnApply.Click += BtnApply_Click;
            BtnCancel.Click += BtnCancel_Click;
        }

        //============================================================
        // EVENT HANDLERS - FORM LOAD
        //============================================================
        /// <summary>
        /// FrmOptions_Load: Occurs when the Options form loads.  
        /// It sets the checkboxes to reflect the current AppSettings.
        /// </summary>
        private void FrmOptions_Load(object sender, EventArgs e)
        {
            // Load current settings from AppSettings into the checkbox states
            ChkDarkMode.Checked = AppSettings.DarkModeEnabled;
            ChkWordCount.Checked = AppSettings.WordCountEnabled;
            //ChkLineNumbers.Checked = AppSettings.LineNumbersEnabled;
            // Was unable to get this to work, will implement possibly later
            ChkWordWrap.Checked = AppSettings.WordWrapEnabled;
            ChkVimMode.Checked = AppSettings.VimModeEnabled;
        }

        //============================================================
        // EVENT HANDLERS - APPLY BUTTON
        //============================================================
        /// <summary>
        /// BtnApply_Click: Occurs when the Apply button is clicked.
        /// Saves the current checkbox states to AppSettings and closes form with OK result.
        /// </summary>
        private void BtnApply_Click(object sender, EventArgs e)
        {
            // Save current states to AppSettings
            AppSettings.DarkModeEnabled = ChkDarkMode.Checked;
            AppSettings.WordCountEnabled = ChkWordCount.Checked;
            //AppSettings.LineNumbersEnabled = ChkLineNumbers.Checked;
            // Was unable to get this to work, will implement possibly later
            AppSettings.WordWrapEnabled = ChkWordWrap.Checked;
            AppSettings.VimModeEnabled = ChkVimMode.Checked;

            // Return DialogResult.OK to indicate changes applied
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        //============================================================
        // EVENT HANDLERS - CANCEL BUTTON
        //============================================================
        /// <summary>
        /// BtnCancel_Click: Occurs when the Cancel button is clicked.
        /// Asks user if they're sure about canceling, and if yes, closes the form discarding changes.
        /// </summary>
        private void BtnCancel_Click(object sender, EventArgs e)
        {
            // Confirm cancel action
            var result = MessageBox.Show("Are you sure you want to cancel and discard changes?",
                             "Cancel Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                // Just close without applying changes
                this.DialogResult = DialogResult.Cancel;
                this.Close();
            }
        }
    }
}
