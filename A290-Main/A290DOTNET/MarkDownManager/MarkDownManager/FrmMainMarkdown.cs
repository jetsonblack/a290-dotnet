using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Markdig;
using System.Runtime.InteropServices;

/**********************************************************
* FrmMainMarkdown.cs
*
* Main Form Handler for the Markdown Editor. This form allows
* the user to type Markdown text and see a live preview of
* the rendered HTML using the Markdig library. Users can
* also import, save, and manage formatting modes such as
* bold, italic, headers, underline, and strike-through.
*
* Author: Jetson Black
* Date Created: 12/9/2024
* Last Modified by: Jetson Black
* Date Last Modified: 12/10/2024
* Assignment: Final A290 Project | Markdown Editor
* Part of: A290 Final Project
***********************************************************/

//============================================================
// The FrmMainMarkdown class manages the main editing form.
// It supports reading and writing Markdown files, applying
// various formatting modes, showing live previews using Markdig,
// toggling dark mode and word wrap, and enabling/disabling a Vim
// command mode to control the editor via Vim-like commands.
//============================================================

namespace MarkDownManager
{
    public partial class FrmMainMarkdown : Form
    {
        //============================================================
        // FIELDS AND CONSTANTS
        //============================================================
        // Undo/Redo stacks to support reverting text changes
        // Simply Pop/Push Actions off of the Stack depending on Undo/Redo
        private Stack<string> undoStack = new Stack<string>();
        private Stack<string> redoStack = new Stack<string>();

        // Holds the last known text state for undo/redo
        private string lastText = string.Empty;

        // Placeholder text details
        private readonly string placeholderText = "# Start typing your Markdown here...";
        private readonly Color placeholderColor = Color.Gray;
        private readonly Color textColor = Color.Black;

        // Mode flags for markdown formatting
        private bool isBoldMode = false;
        private bool isItalicMode = false;
        private bool isUnderlineMode = false;
        private bool isStrikeMode = false;
        private bool isHeaderMode = false;

        // Track start positions for various formatting modes
        private int boldStartPos = -1;
        private int italicStartPos = -1;
        private int underlineStartPos = -1;
        private int strikeStartPos = -1;
        private int headerStartPos = -1;

        // Tracks currently opened/saved file path
        // This is used for Quick Saving.
        private string currentFilePath = null;

        //============================================================
        // CONSTRUCTOR
        //============================================================
        // FrmMainMarkdown: Creates a new instance of the main form.
        // No input parameters.
        // No assumptions.
        // No return value.
        public FrmMainMarkdown()
        {
            InitializeComponent();

            // Set event handlers for form and controls
            this.Load += FrmMainMarkdown_Load;
            this.KeyDown += FrmMainMarkdown_KeyDown;
            // Programatically Subscribe to Event Handlers mainly to avoid Visual Studio Being Weird with attachments.
            // https://learn.microsoft.com/en-us/dotnet/csharp/programming-guide/events/how-to-subscribe-to-and-unsubscribe-from-events
            TxtUserMarkdown.TextChanged += TxtUserMarkdown_TextChanged;
            TxtUserMarkdown.Enter += TxtUserMarkdown_Enter;
            TxtUserMarkdown.Leave += TxtUserMarkdown_Leave;
            TxtUserMarkdown.KeyDown += TxtUserMarkdown_KeyDown;

            BtnCreate.Click += BtnCreate_Click;
            BtnImport.Click += BtnImport_Click;
            BtnSave.Click += BtnSave_Click;
            BtnAbout.Click += BtnAbout_Click;
            BtnOptions.Click += BtnOptions_Click;
            BtnQuit.Click += BtnQuit_Click;

            BtnMDHeader.Click += BtnMDHeader_Click;
            BtnMDBold.Click += BtnMDBold_Click;
            BtnMDItalic.Click += BtnMDItalic_Click;
            BtnMDUnderline.Click += BtnMDUnderline_Click;
            BtnMDStrike.Click += BtnMDStrike_Click;

            WBMarkdown.DocumentCompleted += WBMarkdown_DocumentCompleted;

            TxtCommand.KeyDown += TxtCommand_KeyDown;
            TxtCommand.PreviewKeyDown += TxtCommand_PreviewKeyDown;
            // Handles Event subscription for toolbar drop down menu, basically redirecting their events to our buttons for them to handle it.
            fileToolStripMenuItem.DropDownItems["createToolStripMenuItem"].Click += (s, e) => BtnCreate.PerformClick();
            fileToolStripMenuItem.DropDownItems["importToolStripMenuItem"].Click += (s, e) => BtnImport.PerformClick();
            fileToolStripMenuItem.DropDownItems["saveToolStripMenuItem"].Click += (s, e) => BtnSave.PerformClick();
            fileToolStripMenuItem.DropDownItems["quitToolStripMenuItem"].Click += (s, e) => BtnQuit.PerformClick();

            optionsToolStripMenuItem.Click += (s, e) => BtnOptions.PerformClick();
            aboutToolStripMenuItem.Click += (s, e) => BtnAbout.PerformClick();
            helpToolStripMenuItem.Click += (s, e) => ShowHelpForm();
        }

        //============================================================
        // FORM LOAD
        //============================================================
        // FrmMainMarkdown_Load sets up initial UI conditions, placeholder text,
        // and applies user settings such as word wrap and Vim mode.
        //
        // sender: the form itself
        // e: event arguments, not used
        // Assumptions: Form and controls are properly initialized.
        // Guarantees: The UI and settings are applied before user interaction.
        private void FrmMainMarkdown_Load(object sender, EventArgs e)
        {
            // Set placeholder and initial conditions
            TxtUserMarkdown.Text = placeholderText;
            TxtUserMarkdown.ForeColor = placeholderColor;

            // Enable form-level key event handling for some keyboard shortcuts we use later
            this.KeyPreview = true;
            WBMarkdown.DocumentText = string.Empty;

            // Allow tab/enter in main textbox, this simply allows the textbox to behave like a textfield.
            TxtUserMarkdown.AcceptsTab = true;
            TxtUserMarkdown.AcceptsReturn = true;

            // Configure command textbox for Vim mode, done programitcally simply to avoid VStudios weird behaviors.
            TxtCommand.AcceptsReturn = false;
            TxtCommand.Multiline = false;
            TxtCommand.ShortcutsEnabled = false;
            
            // Upon Load we refresh everything to a 0 state
            UpdateWordCount();
            ApplyAllSettings();
        }

        //============================================================
        // FILE OPERATIONS (CREATE, IMPORT, SAVE)
        //============================================================
        // BtnCreate_Click clears the current document and starts a new one.
        // sender: BtnCreate button
        // e: event arguments, not used
        // Assumptions: None
        // Guarantees: The main text and preview are cleared.
        private void BtnCreate_Click(object sender, EventArgs e)
        {
            TxtUserMarkdown.Clear();
            WBMarkdown.DocumentText = string.Empty;
        }

        // BtnImport_Click lets the user select a markdown file to load.
        // sender: BtnImport button
        // e: event arguments, not used
        // Assumptions: User picks a valid file or cancels
        // Guarantees: If a file is chosen, its contents load into TxtUserMarkdown.
        private void BtnImport_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                // Filters for File Types
                openFileDialog.Filter = "Markdown Files (*.md)|*.md|All Files (*.*)|*.*";
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    TxtUserMarkdown.Text = File.ReadAllText(openFileDialog.FileName);
                    currentFilePath = openFileDialog.FileName;
                    UpdatePreview();
                }
            }
        }

        // BtnSave_Click saves the current document. If no file path exists, prompts the user.
        // sender: BtnSave button
        // e: event arguments, not used
        // Assumptions: None
        // Guarantees: Current text is saved to disk if possible.
        private void BtnSave_Click(object sender, EventArgs e)
        {
            SaveFileWithPromptIfNeeded(); // Extend out to helper function, helps with quick saving with CTRL+S
        }

        // SaveFileWithPromptIfNeeded checks if current file path is known.
        // If not, shows a SaveFileDialog, else saves directly.
        // No parameters.
        // Assumptions: TxtUserMarkdown contains the current text.
        // Guarantees: The text is saved to a file chosen by the user.
        private void SaveFileWithPromptIfNeeded()
        {
            if (string.IsNullOrEmpty(currentFilePath)) // If no File Path Exists, we use the dialog
            {
                using (SaveFileDialog saveFileDialog = new SaveFileDialog())
                {
                    saveFileDialog.Filter = "Markdown Files (*.md)|*.md|All Files (*.*)|*.*";
                    if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        currentFilePath = saveFileDialog.FileName;
                        File.WriteAllText(currentFilePath, TxtUserMarkdown.Text);
                    }
                }
            }
            else
            { // If a file does already exist we simply save to it
                File.WriteAllText(currentFilePath, TxtUserMarkdown.Text);
            }
        }

        // BtnAbout_Click shows an About dialog.
        // sender: BtnAbout button
        // e: event arguments, not used
        // Assumptions: FrmAbout exists
        // Guarantees: About dialog is displayed.
        private void BtnAbout_Click(object sender, EventArgs e)
        {
            ShowAboutForm();
        }

        // BtnOptions_Click shows the Options dialog, reapplies settings afterwards.
        // sender: BtnOptions button
        // e: event arguments, not used
        // Assumptions: FrmOptions exists
        // Guarantees: Options form shown, then settings applied.
        private void BtnOptions_Click(object sender, EventArgs e)
        {
            using (FrmOptions optionsForm = new FrmOptions())
            {
                var result = optionsForm.ShowDialog();
                ApplyAllSettings();
                UpdatePreview();
                UpdateElementColors(AppSettings.DarkModeEnabled); // Checks and Applys Darkmode colors if needed
            }
        }

        // BtnQuit_Click prompts the user to quit. If yes, the application exits.
        // sender: BtnQuit button
        // e: event arguments, not used
        // Assumptions: None
        // Guarantees: If user agrees, application closes.
        private void BtnQuit_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to quit?", "Confirm Quit", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        //============================================================
        // MODE TOGGLING (HEADER, BOLD, ITALIC, UNDERLINE, STRIKE)
        //============================================================
        // Each of these button click handlers toggles a respective formatting mode or applies it to selected text.

        private void BtnMDHeader_Click(object sender, EventArgs e)
        {
            HandleToggleMode("header");
        }

        private void BtnMDBold_Click(object sender, EventArgs e)
        {
            HandleToggleMode("bold");
        }

        private void BtnMDItalic_Click(object sender, EventArgs e)
        {
            HandleToggleMode("italic");
        }

        private void BtnMDUnderline_Click(object sender, EventArgs e)
        {
            HandleToggleMode("underline");
        }

        private void BtnMDStrike_Click(object sender, EventArgs e)
        {
            HandleToggleMode("strike");
        }

        // HandleToggleMode checks selection. If text is selected, applies mode immediately.
        // Otherwise, activates mode for future text input.
        //
        // mode: string name of the mode ("bold", "italic", etc.)
        // Assumptions: mode is valid
        // Guarantees: Mode is either applied to selected text or toggled on.
        private void HandleToggleMode(string mode)
        {
            var selectionLength = TxtUserMarkdown.SelectionLength; // Get the length of Current Selection
            if (selectionLength > 0) // If it is more than 0, something is selected so we set the selected text to the markdown mode.
            {
                string selectedText = TxtUserMarkdown.SelectedText;
                string replacedText = ApplyMarkdown(mode, selectedText);
                ReplaceSelectedText(replacedText);
            }
            else // if there is not any text selected then we enter the toggled `mode`
            {
                ToggleMode(mode);
            }
            UpdatePreview();
        }

        // ToggleMode either starts or ends a formatting mode by tracking positions and changing button colors.
        //
        // mode: name of the mode to toggle
        // Assumptions: mode is a recognized mode name
        // Guarantees: The indicated mode state is toggled, start position recorded.
	// Colors from https://ethanschoonover.com/solarized/
        private void ToggleMode(string mode)
        {
            ResetModeIndicators(); // Just to clean up previous Mode Toggles if needed.
            switch (mode)
            {
                // Switch case for each mode in supported in the Markdown Editor.
                case "bold":
                    if (isBoldMode)      
                    {
                        // If we are in a mode Already (Meaning that we toggled into it earlier), upon other call we know the user is trying to exit the mode
                        // Thus we exit the mode and apply the markdown to all the text the user typed since entering the mode (hence boldStartPos)
                        ApplyModeToTypedText("bold");
                        isBoldMode = false; boldStartPos = -1;
                    }
                    else
                    {
                        isBoldMode = true; boldStartPos = TxtUserMarkdown.SelectionStart;
                        BtnMDBold.BackColor = ColorTranslator.FromHtml("#859900");
                        BtnMDBold.ForeColor = ColorTranslator.FromHtml("#fdf6e3");
                    }
                    break;

                case "italic":
                    if (isItalicMode)
                    {
                        // If we are in a mode Already (Meaning that we toggled into it earlier), upon other call we know the user is trying to exit the mode
                        // Thus we exit the mode and apply the markdown to all the text the user typed since entering the mode (hence italicStartPos)
                        ApplyModeToTypedText("italic");
                        isItalicMode = false; italicStartPos = -1;
                    }
                    else
                    {
                        isItalicMode = true; italicStartPos = TxtUserMarkdown.SelectionStart;
                        BtnMDItalic.BackColor = ColorTranslator.FromHtml("#859900");
                        BtnMDItalic.ForeColor = ColorTranslator.FromHtml("#fdf6e3");
                    }
                    break;

                case "underline":
                    if (isUnderlineMode)
                    {
                        // If we are in a mode Already (Meaning that we toggled into it earlier), upon other call we know the user is trying to exit the mode
                        // Thus we exit the mode and apply the markdown to all the text the user typed since entering the mode (hence underlineStartPos)
                        ApplyModeToTypedText("underline");
                        isUnderlineMode = false; underlineStartPos = -1;
                    }
                    else
                    {
                        isUnderlineMode = true; underlineStartPos = TxtUserMarkdown.SelectionStart;
                        BtnMDUnderline.BackColor = ColorTranslator.FromHtml("#859900");
                        BtnMDUnderline.ForeColor = ColorTranslator.FromHtml("#fdf6e3");
                    }
                    break;

                case "strike":
                    if (isStrikeMode)
                    {
                        // If we are in a mode Already (Meaning that we toggled into it earlier), upon other call we know the user is trying to exit the mode
                        // Thus we exit the mode and apply the markdown to all the text the user typed since entering the mode (hence strikeStartPos)
                        ApplyModeToTypedText("strike");
                        isStrikeMode = false; strikeStartPos = -1;
                    }
                    else
                    {
                        isStrikeMode = true; strikeStartPos = TxtUserMarkdown.SelectionStart;
                        BtnMDStrike.BackColor = ColorTranslator.FromHtml("#859900");
                        BtnMDStrike.ForeColor = ColorTranslator.FromHtml("#fdf6e3");
                    }
                    break;

                case "header":
                    if (isHeaderMode)
                    {
                        // If we are in a mode Already (Meaning that we toggled into it earlier), upon other call we know the user is trying to exit the mode
                        // Thus we exit the mode and apply the markdown to all the text the user typed since entering the mode (hence headerStartPos)
                        ApplyModeToTypedText("header");
                        isHeaderMode = false; headerStartPos = -1;
                    }
                    else
                    {
                        isHeaderMode = true; headerStartPos = TxtUserMarkdown.SelectionStart;
                        BtnMDHeader.BackColor = ColorTranslator.FromHtml("#859900");
                        BtnMDHeader.ForeColor = ColorTranslator.FromHtml("#fdf6e3");
                    }
                    break;
            }
        }

        //============================================================
        // APPLYING MARKDOWN MODES
        //============================================================
        // ApplyModeToTypedText applies formatting to text typed since the mode was activated.
        //
        // mode: name of the markdown mode to apply
        // Assumptions: start positions are recorded properly
        // Guarantees: The affected text is replaced with properly formatted markdown.
        private void ApplyModeToTypedText(string mode)
        {
            int startPos = GetStartPosForMode(mode); // Simple Getter for the StartPos of the given mode
            if (startPos < 0 || startPos > TxtUserMarkdown.TextLength) return; // if the start pos is less than 0 or greater than the length of the text we return

            int length = TxtUserMarkdown.SelectionStart - startPos; // we get the length of the user text
            if (length <= 0)
            {
                ResetModeIndicators();
                return;
            }

            string substring = TxtUserMarkdown.Text.Substring(startPos, length); // substring out the from the starting position to the length of the user text
            string normalized = substring.Replace("\r\n", "\n").Replace("\r", "\n"); // normalize the text by replaceing all new line and return characters
            string replaced = ApplyMarkdownToLines(mode, normalized);  // Apply the mode's markdown to the normalized text

            TxtUserMarkdown.Select(startPos, length);
            ReplaceSelectedText(replaced);

            TxtUserMarkdown.SelectionStart = startPos + replaced.Length;
            TxtUserMarkdown.SelectionLength = 0;
            ResetModeIndicators();
        }

        // GetStartPosForMode retrieves the stored start position for a given mode.
        //
        // mode: the mode name
        // Assumptions: mode is valid
        // Guarantees: returns a start position or -1 if mode not found.
        private int GetStartPosForMode(string mode)
        {
            switch (mode)
            {
                case "bold": return boldStartPos;
                case "italic": return italicStartPos;
                case "underline": return underlineStartPos;
                case "strike": return strikeStartPos;
                case "header": return headerStartPos;
                default: return -1;
            }
        }

        // ApplyMarkdownToLines applies the chosen markdown mode to each non-empty line of given text.
        //
        // mode: the mode name
        // text: the text to apply mode to
        // Assumptions: mode is valid
        // Guarantees: returns text with mode applied line-by-line.
        private string ApplyMarkdownToLines(string mode, string text)
        {
            // This handles how Markdown jumps from line to line, thus we split the text along newline characters
            var lines = text.Split('\n'); 
            for (int i = 0; i < lines.Length; i++)
            {
                string line = lines[i].TrimEnd();
                if (!string.IsNullOrWhiteSpace(line))
                {
                    lines[i] = ApplyMarkdown(mode, line);
                }
                else
                {
                    lines[i] = line;
                }
            }
            return string.Join(Environment.NewLine, lines);
        }

        // ApplyMarkdown returns the input line wrapped with the appropriate markdown syntax.
        //
        // mode: mode name (e.g., "bold", "italic")
        // input: the text to wrap
        // Assumptions: mode is valid
        // Guarantees: returns text wrapped in markdown tags
        private string ApplyMarkdown(string mode, string input)
        {
            switch (mode)
            {
                case "bold": return $"**{input}**";
                case "italic": return $"*{input}*";
                case "underline": return $"<u>{input}</u>";
                case "strike": return $"~~{input}~~";
                case "header": return $"# {input}";
                default: return input;
            }
        }

        // ReplaceSelectedText replaces the currently selected text in TxtUserMarkdown with newText.
        //
        // newText: the text to insert in place of selection
        // Assumptions: A selection is made or selection length can be zero.
        // Guarantees: The selected range is replaced with newText.
        private void ReplaceSelectedText(string newText)
        {
            int selStart = TxtUserMarkdown.SelectionStart;
            TxtUserMarkdown.SelectedText = newText;
            TxtUserMarkdown.SelectionStart = selStart + newText.Length;
            TxtUserMarkdown.SelectionLength = 0;
        }

        //============================================================
        // PREVIEW UPDATE AND RENDERING
        //============================================================
        // UpdatePreview converts the markdown in TxtUserMarkdown to HTML and displays it in WBMarkdown.
        //
        // No parameters.
        // Assumptions: TxtUserMarkdown contains markdown text.
        // Guarantees: The preview browser shows the rendered HTML.

        // Source for HTML styling:
        // https://learn.microsoft.com/en-us/dotnet/desktop/winforms/controls/how-to-change-styles-on-an-element-in-the-managed-html-document-object-model?view=netframeworkdesktop-4.8
        // https://www.webdevtutor.net/blog/c-sharp-wpf-webview2

        // We handle dark mode toggles to the web-browser here as without it, the web browser reverts to its default coloring upon being updated.
        private void UpdatePreview()
        {
            var pipeline = new MarkdownPipelineBuilder()
                .UseAdvancedExtensions()
                .UseSoftlineBreakAsHardlineBreak()
                .Build();

            string rawHtml = Markdig.Markdown.ToHtml(TxtUserMarkdown.Text, pipeline);
            // This string is gives the styling for our Web Browser with color variables that are toggled via the state of AppSettings.DarkModeEnabled.
            string htmlTemplate = $@"
<html>
<head>
    <style>
        body {{
            background-color: {(AppSettings.DarkModeEnabled ? "#404040" : "#ffffff")};
            color: {(AppSettings.DarkModeEnabled ? "#f0f0f0" : "#000000")};
            font-family: Arial, sans-serif;
            margin: 10px;
        }}
    </style>
</head>
<body>
    {rawHtml}
</body>
</html>";

            WBMarkdown.DocumentText = htmlTemplate;
            UpdateElementColors(AppSettings.DarkModeEnabled);
        }

        // WBMarkdown_DocumentCompleted is triggered when the web browser finishes loading the preview.
        // It can scroll to bottom if desired.
        //
        // sender: WBMarkdown control
        // e: event arguments with document details
        // Assumptions: Document and Body are accessible.
        // Guarantees: The preview may scroll to show the full rendered content.


        // https://learn.microsoft.com/en-us/dotnet/api/system.windows.forms.webbrowser.documentcompleted?view=windowsdesktop-9.0
        private void WBMarkdown_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            if (WBMarkdown.Document != null && WBMarkdown.Document.Body != null)
            {
                WBMarkdown.Document.Window.ScrollTo(0, WBMarkdown.Document.Body.ScrollRectangle.Height);
            }
        }

        //============================================================
        // TEXTBOX EVENTS (TEXT CHANGES, PLACEHOLDER MANAGEMENT)
        //============================================================
        // TxtUserMarkdown_TextChanged updates preview and word count when the text changes.
        //
        // sender: TxtUserMarkdown
        // e: event arguments
        // Assumptions: None
        // Guarantees: Preview and word count updated after each text change.
        private void TxtUserMarkdown_TextChanged(object sender, EventArgs e)
        {
            if (TxtUserMarkdown.Focused && TxtUserMarkdown.ForeColor == placeholderColor)
                return;

            if (TxtUserMarkdown.Text != lastText)
            {
                undoStack.Push(lastText);
                lastText = TxtUserMarkdown.Text;
            }

            UpdatePreview(); 
            UpdateWordCount();
        }

        // TxtUserMarkdown_Enter removes the placeholder if the textbox is focused and placeholder is visible.
        //
        // sender: TxtUserMarkdown
        // e: event arguments
        // Assumptions: None
        // Guarantees: Placeholder removed if active.
        private void TxtUserMarkdown_Enter(object sender, EventArgs e)
        {
            if (TxtUserMarkdown.Text == placeholderText && TxtUserMarkdown.ForeColor == placeholderColor)
            {
                TxtUserMarkdown.Text = "";
                TxtUserMarkdown.ForeColor = textColor;
            }
        }

        // TxtUserMarkdown_Leave restores placeholder if textbox is empty upon losing focus.
        //
        // sender: TxtUserMarkdown
        // e: event arguments
        // Assumptions: None
        // Guarantees: Placeholder shown if no user text.
        private void TxtUserMarkdown_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(TxtUserMarkdown.Text))
            {
                TxtUserMarkdown.Text = placeholderText;
                TxtUserMarkdown.ForeColor = placeholderColor;
            }
        }

        //============================================================
        // KEYBOARD SHORTCUTS (TEXTBOX-LEVEL)
        //============================================================
        // TxtUserMarkdown_KeyDown handles shortcuts and Vim mode ':' entry.
        //
        // sender: TxtUserMarkdown
        // e: KeyEventArgs representing the key pressed
        // Assumptions: VimMode might be enabled.
        // Guarantees: If VimMode and Shift+; is pressed, command mode is entered.


        // Source for Vim Commands https://vim.rtorr.com/
        private void TxtUserMarkdown_KeyDown(object sender, KeyEventArgs e)
        {
            // If Vim mode is on and user presses Shift+;, enter Vim command mode
            if (AppSettings.VimModeEnabled && !e.Control && !e.Alt && e.Shift && e.KeyCode == Keys.OemSemicolon)
            {
                // Enter Vim command mode
                TxtCommand.Text = "";
                TxtCommand.Visible = true;
                TxtCommand.BringToFront();
                TxtCommand.Focus();
                TxtCommand.SelectionStart = TxtCommand.Text.Length;
                e.Handled = true;
                e.SuppressKeyPress = true;
                return;
            }

            // Handle various Ctrl shortcuts for formatting
            if (e.Control && e.KeyCode == Keys.B) { HandleToggleMode("bold"); e.Handled = true; e.SuppressKeyPress = true; }
            else if (e.Control && e.KeyCode == Keys.I) { HandleToggleMode("italic"); e.Handled = true; e.SuppressKeyPress = true; }
            else if (e.Control && e.KeyCode == Keys.U) { HandleToggleMode("underline"); e.Handled = true; e.SuppressKeyPress = true; }
            else if (e.Control && e.KeyCode == Keys.D5) { HandleToggleMode("strike"); e.Handled = true; e.SuppressKeyPress = true; }
            else if (e.Control && e.KeyCode == Keys.Back) { HandleCtrlBackspace(); e.Handled = true; e.SuppressKeyPress = true; }
            else if (e.Control && e.KeyCode == Keys.H) { HandleToggleMode("header"); e.Handled = true; e.SuppressKeyPress = true; }
            else if (!e.Control && !e.Shift && !e.Alt && e.KeyCode == Keys.Tab)
            {
                // some help from here https://stackoverflow.com/questions/14362563/inserting-a-tab-space-into-a-textbox
                // Text Box doesn't like Tab being inserted.
                // Insert a tab character into the text
                int cursorPos = TxtUserMarkdown.SelectionStart;
                TxtUserMarkdown.Text = TxtUserMarkdown.Text.Insert(cursorPos, "\t");
                TxtUserMarkdown.SelectionStart = cursorPos + 1;
                e.Handled = true; e.SuppressKeyPress = true;
            }
        }

        // HandleCtrlBackspace deletes the previous word in the textbox.
        //
        // No parameters.
        // Assumptions: TxtUserMarkdown is focused.
        // Guarantees: The previous word is removed if any.

        // Github Issue that describes CTRL+BACKSPACE not working on multiline TextBoxes
        // https://github.com/dotnet/winforms/issues/259
        // The only Way I saw the handle it was to log the previous word recorded and directly update the Textbox
        private void HandleCtrlBackspace()
        {
            int pos = TxtUserMarkdown.SelectionStart; // Get the Position
            if (pos == 0) return;

            string text = TxtUserMarkdown.Text; // Get the Text from the Text box
            int end = pos - 1; // Calculate the End Position
            while (end >= 0 && char.IsWhiteSpace(text[end])) 
                end--;
            if (end < 0) return;
            int start = end;
            while (start >= 0 && !char.IsWhiteSpace(text[start]))
                start--;
            start++;
            int lengthToRemove = pos - start;
            if (lengthToRemove > 0)
            {
                TxtUserMarkdown.Select(start, lengthToRemove);
                TxtUserMarkdown.SelectedText = "";
                TxtUserMarkdown.SelectionStart = start;
            }
        }

        //============================================================
        // KEYBOARD SHORTCUTS (GLOBAL FORM-LEVEL)
        //============================================================
        // FrmMainMarkdown_KeyDown handles global shortcuts like Ctrl+S (save), Ctrl+Z (undo), etc.
        //
        // sender: Form
        // e: KeyEventArgs
        // Assumptions: Form has KeyPreview = true.
        // Guarantees: Appropriate action taken for recognized shortcuts.
        private void FrmMainMarkdown_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.S) { SaveFileWithPromptIfNeeded(); e.Handled = true; e.SuppressKeyPress = true; }
            else if (e.Control && e.Shift && e.KeyCode == Keys.Z) { Redo(); e.Handled = true; }
            else if (e.Control && e.KeyCode == Keys.Z) { Undo(); e.Handled = true; }
            else if (e.Control && e.KeyCode == Keys.Y) { Redo(); e.Handled = true; }
            else if (e.Control && e.KeyCode == Keys.Q) { CloseAnyActiveMode(); e.Handled = true; e.SuppressKeyPress = true; }
            else if (e.Control && e.KeyCode == Keys.D) { CancelAnyActiveMode(); e.Handled = true; e.SuppressKeyPress = true; }
            else if (e.Control && e.KeyCode == Keys.R) { RefreshProgram(); e.Handled = true; e.SuppressKeyPress = true; }
        }

        //============================================================
        // UNDO/REDO FUNCTIONALITY
        //============================================================
        // Undo reverts to a previous text state if available.
        //
        // No parameters.
        // Assumptions: undoStack contains previous states.
        // Guarantees: If possible, text is reverted.
        private void Undo()
        {
            if (undoStack.Count > 0)
            {
                redoStack.Push(lastText);
                lastText = undoStack.Pop();
                TxtUserMarkdown.Text = lastText;
            }
        }

        // Redo re-applies an undone text state if available.
        //
        // No parameters.
        // Assumptions: redoStack contains future states.
        // Guarantees: If possible, text is restored to a later state.
        private void Redo()
        {
            if (redoStack.Count > 0)
            {
                undoStack.Push(lastText);
                lastText = redoStack.Pop();
                TxtUserMarkdown.Text = lastText;
            }
        }

        //============================================================
        // MODE CLOSING AND REFRESHING
        //============================================================
        // CloseAnyActiveMode finalizes any active formatting mode if text was typed.
        //
        // No parameters.
        // Assumptions: Mode flags and start positions tracked properly.
        // Guarantees: If mode was active, it is applied and turned off.
        private void CloseAnyActiveMode()
        {
            // Use this for the Univseral Mode Closer keybind
            if (isBoldMode) { ApplyModeToTypedText("bold"); isBoldMode = false; boldStartPos = -1; ResetModeIndicators(); }
            else if (isItalicMode) { ApplyModeToTypedText("italic"); isItalicMode = false; italicStartPos = -1; ResetModeIndicators(); }
            else if (isUnderlineMode) { ApplyModeToTypedText("underline"); isUnderlineMode = false; underlineStartPos = -1; ResetModeIndicators(); }
            else if (isStrikeMode) { ApplyModeToTypedText("strike"); isStrikeMode = false; strikeStartPos = -1; ResetModeIndicators(); }
            else if (isHeaderMode) { ApplyModeToTypedText("header"); isHeaderMode = false; headerStartPos = -1; ResetModeIndicators(); }
        }

        // CancelAnyActiveMode turns off all modes without applying formatting.
        //
        // No parameters.
        // Assumptions: None
        // Guarantees: All modes are off, indicators reset.
        private void CancelAnyActiveMode()
        {
            // Use this for the Cancel Mode keybind
            if (isBoldMode) { isBoldMode = false; boldStartPos = -1; }
            if (isItalicMode) { isItalicMode = false; italicStartPos = -1; }
            if (isUnderlineMode) { isUnderlineMode = false; underlineStartPos = -1; }
            if (isStrikeMode) { isStrikeMode = false; strikeStartPos = -1; }
            if (isHeaderMode) { isHeaderMode = false; headerStartPos = -1; }
            ResetModeIndicators();
        }

        // RefreshProgram clears the preview and forces a re-render.
        //
        // No parameters.
        // Assumptions: None
        // Guarantees: The preview is cleared and then re-updated.
        private void RefreshProgram()
        {
            WBMarkdown.DocumentText = "";
            UpdatePreview();
        }

        //============================================================
        // UI HELPER METHODS
        //============================================================
        // ResetModeIndicators resets formatting mode buttons to default colors.
        //
        // No parameters.
        // Assumptions: Buttons exist.
        // Guarantees: Buttons reflect no active modes.
        private void ResetModeIndicators()
        {
            Color defaultBackColor = AppSettings.DarkModeEnabled ? Color.FromArgb(60, 60, 60) : SystemColors.Control;
            Color defaultForeColor = AppSettings.DarkModeEnabled ? Color.White : SystemColors.ControlText;

            BtnMDBold.BackColor = defaultBackColor;
            BtnMDBold.ForeColor = defaultForeColor;
            BtnMDItalic.BackColor = defaultBackColor;
            BtnMDItalic.ForeColor = defaultForeColor;
            BtnMDUnderline.BackColor = defaultBackColor;
            BtnMDUnderline.ForeColor = defaultForeColor;
            BtnMDStrike.BackColor = defaultBackColor;
            BtnMDStrike.ForeColor = defaultForeColor;
            BtnMDHeader.BackColor = defaultBackColor;
            BtnMDHeader.ForeColor = defaultForeColor;
        }

        // UpdateElementColors adjusts UI colors for dark or light mode.
        //
        // isDarkMode: true if dark mode is enabled
        // Assumptions: Controls exist
        // Guarantees: Colors updated to reflect chosen mode.
        public void UpdateElementColors(bool isDarkMode)
        {
            // We loop through all the Controls in the given Form, if we then select certain controls to apply color formating to 
            // Based on the option selection status from AppSettings.cs
            this.BackColor = isDarkMode ? Color.FromArgb(40, 40, 40) : SystemColors.Control;
            foreach (Control control in this.Controls)
            {
                if (control == WBMarkdown || control == TxtCommand || control == menuStrip1)
                    continue; // Skip these controls from color changes

                control.BackColor = isDarkMode ? Color.FromArgb(60, 60, 60) : SystemColors.Control; // if in darkmode use Color.FromArgb(60, 60, 60, else use Control.
                control.ForeColor = isDarkMode ? Color.White : SystemColors.ControlText;
            }

            TxtUserMarkdown.BackColor = isDarkMode ? Color.FromArgb(50, 50, 50) : Color.White;
            TxtUserMarkdown.ForeColor = isDarkMode ? Color.White : Color.Black;

            TxtCommand.BackColor = isDarkMode ? Color.FromArgb(50, 50, 50) : Color.White;
            TxtCommand.ForeColor = isDarkMode ? Color.White : Color.Black;
        }

        // UpdateWordCount updates the displayed word count if enabled.
        //
        // No parameters.
        // Assumptions: AppSettings.WordCountEnabled is accessible
        // Guarantees: Word count label updated or hidden.
        private void UpdateWordCount()
        {
            if (AppSettings.WordCountEnabled) // If the setting is enabled
            {
                // grab the length of a array were each index is a word in the textbox with removed empty indexes.
                int wordCount = TxtUserMarkdown.Text.Split(new char[] { ' ', '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries).Length;
                LblWordCount.Text = $"Word Count {wordCount}";
                LblWordCount.Visible = true;
            }
            else
            {
                LblWordCount.Visible = false;
            }
        }

        //============================================================
        // WORD WRAP AND OTHER SETTINGS
        //============================================================
        // ApplyAllSettings applies user-defined settings such as word wrap, vim mode, etc.
        //
        // No parameters.
        // Assumptions: AppSettings fields are accessible and valid.
        // Guarantees: Settings applied to UI and controls.
        private void ApplyAllSettings()
        {
            TxtUserMarkdown.WordWrap = AppSettings.WordWrapEnabled;
            ApplyVimMode();
        }

        // ApplyVimMode shows or hides UI elements based on Vim mode setting.
        //
        // No parameters.
        // Assumptions: AppSettings.VimModeEnabled is set properly.
        // Guarantees: UI updated to reflect Vim mode state.
        private void ApplyVimMode()
        {
            if (AppSettings.VimModeEnabled)
            { // Hide all Elements not defined in Vim Mode
                menuStrip1.Visible = false;
                GrpBMDcontrols.Visible = false;
                BtnCreate.Visible = false;
                BtnImport.Visible = false;
                BtnSave.Visible = false;
                BtnAbout.Visible = false;
                BtnOptions.Visible = false;
                BtnQuit.Visible = false;
                TxtCommand.Visible = false;
            }
            else
            { // If not in vim mode, keep default behavior
                menuStrip1.Visible = true;
                GrpBMDcontrols.Visible = true;
                BtnCreate.Visible = true;
                BtnImport.Visible = true;
                BtnSave.Visible = true;
                BtnAbout.Visible = true;
                BtnOptions.Visible = true;
                BtnQuit.Visible = true;
                TxtCommand.Visible = false;
            }
        }

        //============================================================
        // VIM COMMANDS HANDLING
        //============================================================
        // TxtCommand_PreviewKeyDown ensures Enter and Escape keys trigger KeyDown by marking them as input keys.
        //
        // sender: TxtCommand
        // e: PreviewKeyDownEventArgs with key info
        // Assumptions: TxtCommand is focused when entering commands.
        // Guarantees: Enter and Escape will raise KeyDown.


        // Source https://stackoverflow.com/questions/1460170/what-are-wpf-preview-events
        // Had to use this since for some reason KeyDown did not like recognizing Enter and Escape.
        private void TxtCommand_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Escape)
            {
                e.IsInputKey = true;
            }
        }

        // TxtCommand_KeyDown processes Vim commands when Enter is pressed, cancels on Escape.
        //
        // sender: TxtCommand
        // e: KeyEventArgs with the pressed key
        // Assumptions: Vim mode command entry is triggered properly.
        // Guarantees: Commands are executed if recognized.
        private void TxtCommand_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) // If the user sends a enter in the command Text box -> send contents of command box
            {
                string cmd = TxtCommand.Text.Trim();
                ProcessVimCommand(cmd);
                TxtCommand.Visible = false;
                TxtUserMarkdown.Focus();
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
            else if (e.KeyCode == Keys.Escape) // if the user sends a enter in the command text box -> leave the command box
            {
                TxtCommand.Visible = false;
                TxtUserMarkdown.Focus();
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }

        // ProcessVimCommand executes Vim style commands like :wq, :e, :clear, etc.
        //
        // cmd: the command string (e.g., ":wq")
        // Assumptions: cmd is well-formed and starts with ':'
        // Guarantees: Executes command if recognized; shows debug if not.
        private void ProcessVimCommand(string cmd)
        {
            //MessageBox.Show("DEBUG: Processing Vim command: " + cmd);

            if (cmd == ":wq")
            {
                //MessageBox.Show("DEBUG: Executing :wq (Save)");
                SaveFileWithPromptIfNeeded();
            }
            else if (cmd == ":e")
            {
                //MessageBox.Show("DEBUG: Executing :e (Import)");
                BtnImport.PerformClick();
            }
            else if (cmd == ":clear")
            {
                //MessageBox.Show("DEBUG: Executing :clear (New Document)");
                BtnCreate.PerformClick();
            }
            else if (cmd == ":about")
            {
                //MessageBox.Show("DEBUG: Executing :about (Show About)");
                ShowAboutForm();
            }
            else if (cmd == ":config" || cmd == ":options")
            {
                //MessageBox.Show("DEBUG: Executing :options/:config (Show Options)");
                BtnOptions.PerformClick();
            }
            else if (cmd == ":help")
            {
                //MessageBox.Show("DEBUG: Executing :help (Show Help)");
                ShowHelpForm();
            }
            else if (cmd == ":vim")
            {
                //MessageBox.Show("DEBUG: Executing :vim (Exit Vim Mode)");
                AppSettings.VimModeEnabled = false;
                ApplyAllSettings();
                UpdatePreview();
            }
            else
            {
                //MessageBox.Show("DEBUG: Command not recognized: " + cmd);
            }
        }

        //============================================================
        // ABOUT AND HELP FORMS
        //============================================================
        // ShowAboutForm displays the About dialog.
        //
        // No parameters.
        // Assumptions: FrmAbout form is available.
        // Guarantees: About form is shown modally.
        private void ShowAboutForm()
        {
            FrmAbout about = new FrmAbout();
            about.ShowDialog();
        }

        // ShowHelpForm displays the Help dialog.
        //
        // No parameters.
        // Assumptions: FrmHelp form is available.
        // Guarantees: Help form is shown modally.
        private void ShowHelpForm()
        {
            FrmHelp help = new FrmHelp();
            help.ShowDialog();
        }

    }
}
