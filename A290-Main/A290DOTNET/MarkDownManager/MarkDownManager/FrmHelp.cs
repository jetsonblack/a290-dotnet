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
* FrmHelp.cs
*
* Help Form for the Markdown Editor.
*
* Author: Jetson Black
* Date Created: 12/9/2024
* Last Modified by: Jetson Black
* Date Last Modified: Today
* Assignment: Final A290 Project | Markdown Editor
* Part of: A290 Final Project
***********************************************************/
//============================================================
// This form provides links to Markdown documentation sources,
// a detailed explanation of the editor's features, all keyboard
// shortcuts, options, and how Vim mode works.
// It should match formatting and adhere to dark mode as well.
//============================================================

namespace MarkDownManager
{
    public partial class FrmHelp : Form
    {
        public FrmHelp()
        {
            InitializeComponent();
            this.Load += FrmHelp_Load;
        }

        /// <summary>
        /// FrmHelp_Load: On load, fill in detailed help content and apply dark mode formatting.
        /// </summary>
        private void FrmHelp_Load(object sender, EventArgs e)
        {
            // Detailed help content
            LblHelpContent.Text = "Markdown Documentation:\n" +
                                  "- Official Markdown Guide: https://commonmark.org/help/\n" +
                                  "- Markdown on Wikipedia: https://en.wikipedia.org/wiki/Markdown\n\n" +
                                  "Editor Usage:\n" +
                                  "Type your markdown in the left textbox. The right panel shows a live preview.\n" +
                                  "You can apply formatting with buttons or keyboard shortcuts.\n" +
                                  "To import a file, use File > Import. To save, File > Save.\n" +
                                  "Dark Mode, Word Count, Word Wrap, and Vim Mode can be toggled in Options.\n\n" +
                                  "Keyboard Shortcuts:\n" +
                                  "Ctrl+B: Bold\nCtrl+I: Italic\nCtrl+U: Underline\nCtrl+5: Strike\nCtrl+H: Header\n" +
                                  "Ctrl+Z: Undo, Ctrl+Y or Ctrl+Shift+Z: Redo\nCtrl+S: Save\nCtrl+Q: Close mode\n" +
                                  "Ctrl+D: Cancel mode\nCtrl+R: Refresh preview\n\n" +
                                  "Options Explained:\n" +
                                  "- Dark Mode: Switches to a dark theme.\n" +
                                  "- Word Count: Shows word count label.\n" +
                                  "- (Line Numbers removed)\n" +
                                  "- Word Wrap: Wraps text in the editor.\n" +
                                  "- Vim Mode: Minimal UI and 'command mode' by pressing ':'.\n\n" +
                                  "Vim Mode Commands:\n" +
                                  ":wq -> Save\n:e -> Import\n:clear -> New Document\n:about -> About form\n" +
                                  ":options or :config -> Options form\n:help -> Help form\n:vim -> Exit Vim Mode\n\n" +
                                  "All changes adhere to Dark Mode. Enjoy customizing your editing experience!";

            // Apply dark mode if enabled
            if (AppSettings.DarkModeEnabled)
            {
                this.BackColor = Color.FromArgb(40, 40, 40);
                this.ForeColor = Color.White;
                LblHelpContent.BackColor = Color.FromArgb(50, 50, 50);
                LblHelpContent.ForeColor = Color.White;
            }
            else
            {
                this.BackColor = SystemColors.Control;
                this.ForeColor = SystemColors.ControlText;
                LblHelpContent.BackColor = SystemColors.Control;
                LblHelpContent.ForeColor = SystemColors.ControlText;
            }
        }
    }
}
