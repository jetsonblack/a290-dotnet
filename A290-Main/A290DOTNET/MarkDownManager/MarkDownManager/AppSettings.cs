using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/**********************************************************
* AppSettings.cs
*
* App Settings are managed in this separate class file.
* In a production setting this might be given a json or xml
* file to have options persist sessions but this will work
* for now.
*
* Author: Jetson Black
* Date Created: 12/9/2024
* Last Modified by: Jetson Black
* Date Last Modified: 12/10/2024
* Assignment: Final A290 Project | Markdown Editor
* Part of: A290 Final Project
***********************************************************/

//============================================================
// This class holds static boolean properties to represent the
// current state of the application's settings such as Dark Mode,
// Word Count, Line Numbers, Word Wrap, and Vim Mode.
//
// No file-based persistence is used; all data is in-memory.
//
// Fields:
// - DarkModeEnabled: Toggles dark theme
// - WordCountEnabled: Toggles word count display
// - LineNumbersEnabled: Toggles line number display in editor
// - WordWrapEnabled: Toggles word wrapping in the textbox
// - VimModeEnabled: Toggles Vim-style editing mode
//============================================================

namespace MarkDownManager
{
    public static class AppSettings
    {
        // Dark Mode Setting
        public static bool DarkModeEnabled { get; set; } = false;

        // Word Count Display Setting
        public static bool WordCountEnabled { get; set; } = false;

        // Line Numbers Display Setting
        //public static bool LineNumbersEnabled { get; set; } = false;
        // Was unable to get this to work, will implement possibly later

        // Word Wrap Setting
        public static bool WordWrapEnabled { get; set; } = false;

        // Vim Mode Setting
        public static bool VimModeEnabled { get; set; } = false;
    }
}
