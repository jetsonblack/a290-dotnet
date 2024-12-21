using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Markdig;
using System.IO;

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

namespace MarkDownManager
{
    public partial class FrmMainMarkdown : Form
    {
        //============================================================
        // FIELDS AND CONSTANTS
        //============================================================
        // These fields maintain application state such as undo/redo history,
        // placeholder text properties, active formatting modes, and the currently
        // opened or saved file path.

        private Stack<string> undoStack = new Stack<string>(); // Stores previous text states for Undo
        private Stack<string> redoStack = new Stack<string>(); // Stores undone states for Redo
        private string lastText = string.Empty;                // Tracks the last known text state

        private readonly string placeholderText = "# Start typing your Markdown here...";
        private readonly Color placeholderColor = Color.Gray;
        private readonly Color textColor = Color.Black;

        // Boolean flags to track if a formatting mode (like bold) is currently active
        private bool isBoldMode = false;
        private bool isItalicMode = false;
        private bool isUnderlineMode = false;
        private bool isStrikeMode = false;
        private bool isHeaderMode = false;

        // Stores the start positions of text typed after activating a mode
        private int boldStartPos = -1;
        private int italicStartPos = -1;
        private int underlineStartPos = -1;
        private int strikeStartPos = -1;
        private int headerStartPos = -1;

        private string currentFilePath = null; // Path of the currently opened/saved file

        private Label lblVimMode;
        private StatusStrip statusStrip;
        private ToolStripStatusLabel wordCountLabel;

        //============================================================
        // CONSTRUCTOR AND INITIAL SETUP
        //============================================================
        // This section sets up the form, initializes components,
        // and hooks up all the event handlers for controls and the form itself.

        public FrmMainMarkdown()
        {
            InitializeComponent();

            // Subscribe all event handlers here, ensuring no duplication from Designer
            this.Load += FrmMainMarkdown_Load;
            this.KeyDown += FrmMainMarkdown_KeyDown;

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
        }

        private void FrmMainMarkdown_Load(object sender, EventArgs e)
        {
            // When the form loads, we set up the initial UI state:
            // - Placeholder text and colors
            // - Enable KeyPreview so form-level shortcuts can work
            // - Clear the web browser preview initially
            // - Allow the TextBox to accept TAB characters
            TxtUserMarkdown.Text = placeholderText;
            TxtUserMarkdown.ForeColor = placeholderColor;
            this.KeyPreview = true;
            WBMarkdown.DocumentText = string.Empty;
            TxtUserMarkdown.AcceptsTab = true;
        }

        //============================================================
        // FILE OPERATIONS (CREATE, IMPORT, SAVE)
        //============================================================
        // This section handles creating a new document, importing
        // an existing Markdown file, and saving the current document.
        // If no file path is known, save will prompt the user for a location.

        private void BtnCreate_Click(object sender, EventArgs e)
        {
            // Clears the current text, resets preview to empty.
            TxtUserMarkdown.Clear();
            WBMarkdown.DocumentText = string.Empty;
        }

        private void BtnImport_Click(object sender, EventArgs e)
        {
            // Allows user to select a Markdown file and load it into the editor
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Markdown Files (*.md)|*.md|All Files (*.*)|*.*";
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    // Load file content into the TextBox and remember the file path
                    TxtUserMarkdown.Text = File.ReadAllText(openFileDialog.FileName);
                    currentFilePath = openFileDialog.FileName;
                    UpdatePreview(); // Re-render preview after loading new text
                }
            }
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            // Attempts to save the current document to a known path,
            // or prompts user if no path is known.
            SaveFileWithPromptIfNeeded();
        }

        private void SaveFileWithPromptIfNeeded()
        {
            // If we do not have a known file path, open a SaveFileDialog.
            // Otherwise, save directly to the known file.
            if (string.IsNullOrEmpty(currentFilePath))
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
            {
                File.WriteAllText(currentFilePath, TxtUserMarkdown.Text);
            }
        }

        //============================================================
        // APP NAVIGATION & OPTIONS (ABOUT, OPTIONS, QUIT)
        //============================================================
        // These are simple navigational or informational actions.
        // About and Options currently have commented-out code for future dialogs.
        // Quit checks user confirmation before closing the application.

        private void BtnAbout_Click(object sender, EventArgs e)
        {
            // Potential future About dialog
            //FrmAbout aboutForm = new FrmAbout();
            //aboutForm.ShowDialog();
        }

        private void BtnOptions_Click(object sender, EventArgs e)
        {
            // Potential future Options dialog
            //FrmOptions optionsForm = new FrmOptions();
            //optionsForm.ShowDialog();
        }

        private void BtnQuit_Click(object sender, EventArgs e)
        {
            // Confirm if user wants to quit before closing the application
            if (MessageBox.Show("Are you sure you want to quit?", "Confirm Quit", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        //============================================================
        // MODE TOGGLING (HEADER, BOLD, ITALIC, UNDERLINE, STRIKE)
        //============================================================
        // Each of these buttons toggles or applies a Markdown formatting mode.
        // If text is selected, the mode is immediately applied to that text.
        // If no text is selected, we "toggle" the mode so that future typed text
        // gets the formatting applied when the mode is turned off or changed.

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

        private void HandleToggleMode(string mode)
        {
            // If user selected text, apply mode formatting immediately.
            // Otherwise, set the mode to be applied to future typed text.
            var selectionLength = TxtUserMarkdown.SelectionLength;
            if (selectionLength > 0)
            {
                // Apply the selected mode directly to highlighted text
                string selectedText = TxtUserMarkdown.SelectedText;
                string replacedText = ApplyMarkdown(mode, selectedText);
                ReplaceSelectedText(replacedText);
            }
            else
            {
                // Toggle the mode for future typing
                ToggleMode(mode);
            }

            // Always update the preview after formatting changes
            UpdatePreview();
        }

        private void ToggleMode(string mode)
        {
            // Turn off all highlight indicators before switching mode
            ResetModeIndicators();

            // Check the requested mode and either activate or finalize it
            // If we were already in that mode, finalize and turn it off.
            // If not, activate it and store the starting position.
            switch (mode)
            {
                case "bold":
                    if (isBoldMode)
                    {
                        ApplyModeToTypedText("bold");
                        isBoldMode = false;
                        boldStartPos = -1;
                    }
                    else
                    {
                        isBoldMode = true;
                        boldStartPos = TxtUserMarkdown.SelectionStart;
                        BtnMDBold.BackColor = Color.Yellow; // Highlight active mode
                    }
                    break;

                case "italic":
                    if (isItalicMode)
                    {
                        ApplyModeToTypedText("italic");
                        isItalicMode = false;
                        italicStartPos = -1;
                    }
                    else
                    {
                        isItalicMode = true;
                        italicStartPos = TxtUserMarkdown.SelectionStart;
                        BtnMDItalic.BackColor = Color.Yellow;
                    }
                    break;

                case "underline":
                    if (isUnderlineMode)
                    {
                        ApplyModeToTypedText("underline");
                        isUnderlineMode = false;
                        underlineStartPos = -1;
                    }
                    else
                    {
                        isUnderlineMode = true;
                        underlineStartPos = TxtUserMarkdown.SelectionStart;
                        BtnMDUnderline.BackColor = Color.Yellow;
                    }
                    break;

                case "strike":
                    if (isStrikeMode)
                    {
                        ApplyModeToTypedText("strike");
                        isStrikeMode = false;
                        strikeStartPos = -1;
                    }
                    else
                    {
                        isStrikeMode = true;
                        strikeStartPos = TxtUserMarkdown.SelectionStart;
                        BtnMDStrike.BackColor = Color.Yellow;
                    }
                    break;

                case "header":
                    if (isHeaderMode)
                    {
                        ApplyModeToTypedText("header");
                        isHeaderMode = false;
                        headerStartPos = -1;
                    }
                    else
                    {
                        isHeaderMode = true;
                        headerStartPos = TxtUserMarkdown.SelectionStart;
                        BtnMDHeader.BackColor = Color.Yellow;
                    }
                    break;
            }
        }

        //============================================================
        // APPLYING MARKDOWN MODES
        //============================================================
        // These methods handle the actual insertion of markdown symbols
        // (e.g., ** for bold, * for italic, # for header) around the text.
        // They are used when finalizing a mode and applying it to all text
        // typed since the mode was activated, or when applying formatting
        // to selected text immediately.

        private void ApplyModeToTypedText(string mode)
        {
            int startPos = GetStartPosForMode(mode);
            if (startPos < 0 || startPos > TxtUserMarkdown.TextLength) return;

            // Calculate how much text was typed since mode activation
            int length = TxtUserMarkdown.SelectionStart - startPos;
            if (length <= 0)
            {
                // No text typed, just reset indicators and do nothing
                ResetModeIndicators();
                return;
            }

            // Extract the substring that needs formatting
            string substring = TxtUserMarkdown.Text.Substring(startPos, length);

            // Normalize line endings so we can apply formatting line by line
            string normalized = substring.Replace("\r\n", "\n").Replace("\r", "\n");

            // Format each line according to the mode
            string replaced = ApplyMarkdownToLines(mode, normalized);

            // Replace the typed text with its formatted version
            TxtUserMarkdown.Select(startPos, length);
            ReplaceSelectedText(replaced);

            // Move cursor to the end of the newly formatted text
            TxtUserMarkdown.SelectionStart = startPos + replaced.Length;
            TxtUserMarkdown.SelectionLength = 0;

            ResetModeIndicators();
        }

        private int GetStartPosForMode(string mode)
        {
            // Returns the stored starting position for the requested mode
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

        private string ApplyMarkdownToLines(string mode, string text)
        {
            // Splits the text by line and applies formatting to each non-empty line
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
                    // If line is empty, leave it as is
                    lines[i] = line;
                }
            }
            return string.Join(Environment.NewLine, lines);
        }

        private string ApplyMarkdown(string mode, string input)
        {
            // Given a mode and an input string, return the Markdown formatted text.
            // Note: For underline, we use an HTML tag since Markdown doesn't support underline natively.
            switch (mode)
            {
                case "bold":
                    return $"**{input}**";
                case "italic":
                    return $"*{input}*";
                case "underline":
                    return $"<u>{input}</u>";
                case "strike":
                    return $"~~{input}~~";
                case "header":
                    return $"# {input}";
                default:
                    return input;
            }
        }

        private void ReplaceSelectedText(string newText)
        {
            // Replaces currently selected text in the textbox with the given newText
            int selStart = TxtUserMarkdown.SelectionStart;
            TxtUserMarkdown.SelectedText = newText;
            TxtUserMarkdown.SelectionStart = selStart + newText.Length;
            TxtUserMarkdown.SelectionLength = 0;
        }

        //============================================================
        // PREVIEW UPDATE AND RENDERING
        //============================================================
        // Every time text changes or formatting is applied, we update
        // the HTML preview on the right. We use Markdig to convert
        // Markdown to HTML, then display it in a WebBrowser control.

        private void UpdatePreview()
        {
            // Build a pipeline with chosen extensions and convert Markdown to HTML
            var pipeline = new MarkdownPipelineBuilder()
                .UseAdvancedExtensions()
                .UseSoftlineBreakAsHardlineBreak()
                .Build();

            // Convert the current markdown text to HTML
            string html = Markdig.Markdown.ToHtml(TxtUserMarkdown.Text, pipeline);

            // Display the HTML in the web browser preview
            WBMarkdown.DocumentText = html;
        }

        private void WBMarkdown_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            // Once the browser finishes loading the HTML, scroll to the bottom.
            // This helps ensure the user sees the most recent changes if text grows large.
            if (WBMarkdown.Document != null && WBMarkdown.Document.Body != null)
            {
                WBMarkdown.Document.Window.ScrollTo(0, WBMarkdown.Document.Body.ScrollRectangle.Height);
            }
        }

        //============================================================
        // TEXTBOX EVENTS (TEXT CHANGES, PLACEHOLDER MANAGEMENT)
        //============================================================
        // These events handle dynamic changes to the textbox,
        // including updating the preview on changes, and managing
        // placeholder text when the textbox is empty or focused.

        private void TxtUserMarkdown_TextChanged(object sender, EventArgs e)
        {
            // Don't process placeholder text changes as real input
            if (TxtUserMarkdown.Focused && TxtUserMarkdown.ForeColor == placeholderColor)
                return;

            // If text actually changed, push the old state onto the undo stack
            if (TxtUserMarkdown.Text != lastText)
            {
                undoStack.Push(lastText);
                lastText = TxtUserMarkdown.Text;
            }

            // Re-render preview to reflect changes
            UpdatePreview();
        }

        private void TxtUserMarkdown_Enter(object sender, EventArgs e)
        {
            // When the user focuses the textbox, if we currently have placeholder text,
            // clear it and set the text color to normal so the user can start typing.
            if (TxtUserMarkdown.Text == placeholderText && TxtUserMarkdown.ForeColor == placeholderColor)
            {
                TxtUserMarkdown.Text = "";
                TxtUserMarkdown.ForeColor = textColor;
            }
        }

        private void TxtUserMarkdown_Leave(object sender, EventArgs e)
        {
            // If the user leaves the textbox and it's empty, restore the placeholder text.
            if (string.IsNullOrWhiteSpace(TxtUserMarkdown.Text))
            {
                TxtUserMarkdown.Text = placeholderText;
                TxtUserMarkdown.ForeColor = placeholderColor;
            }
        }

        //============================================================
        // KEYBOARD SHORTCUTS (TEXTBOX-LEVEL)
        //============================================================
        // Handles shortcuts that apply when the textbox is focused.
        // E.g., Ctrl+B toggles bold mode, Ctrl+Backspace deletes a word, etc.

        private void TxtUserMarkdown_KeyDown(object sender, KeyEventArgs e)
        {
            // Check for various Ctrl combinations that apply formatting modes or handle special actions.
            if (e.Control && e.KeyCode == Keys.B)
            {
                // Ctrl+B toggles bold mode
                HandleToggleMode("bold");
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
            else if (e.Control && e.KeyCode == Keys.I)
            {
                // Ctrl+I toggles italic mode
                HandleToggleMode("italic");
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
            else if (e.Control && e.KeyCode == Keys.U)
            {
                // Ctrl+U toggles underline mode
                HandleToggleMode("underline");
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
            else if (e.Control && e.KeyCode == Keys.D5)
            {
                // Ctrl+5 toggles strikethrough mode
                HandleToggleMode("strike");
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
            else if (e.Control && e.KeyCode == Keys.Back)
            {
                // Ctrl+Backspace deletes the previous word
                HandleCtrlBackspace();
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
            else if (e.Control && e.KeyCode == Keys.H)
            {
                // Ctrl+H toggles header mode
                HandleToggleMode("header");
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
            else if (!e.Control && !e.Shift && !e.Alt && e.KeyCode == Keys.Tab)
            {
                // Pressing Tab inserts a tab character instead of changing focus
                int cursorPos = TxtUserMarkdown.SelectionStart;
                TxtUserMarkdown.Text = TxtUserMarkdown.Text.Insert(cursorPos, "\t");
                TxtUserMarkdown.SelectionStart = cursorPos + 1;
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }

        private void HandleCtrlBackspace()
        {
            // This method deletes the previous word when Ctrl+Backspace is pressed
            int pos = TxtUserMarkdown.SelectionStart;
            if (pos == 0) return;

            string text = TxtUserMarkdown.Text;
            int end = pos - 1;

            // Move left over any trailing spaces
            while (end >= 0 && char.IsWhiteSpace(text[end]))
                end--;

            // If we run out of text, nothing to delete
            if (end < 0) return;

            // Find the start of the previous word
            int start = end;
            while (start >= 0 && !char.IsWhiteSpace(text[start]))
                start--;

            start++;

            // Delete the word found
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
        // Handles shortcuts that work even when the textbox is not focused.
        // Example: Ctrl+S for saving, Ctrl+Z for undo, Ctrl+Y for redo, etc.

        private void FrmMainMarkdown_KeyDown(object sender, KeyEventArgs e)
        {
            // Check global keyboard shortcuts:
            // Ctrl+S (Save), Ctrl+Z (Undo), Ctrl+Y (Redo), Ctrl+Q (Close Mode),
            // Ctrl+D (Cancel Mode), Ctrl+R (Refresh Preview), Ctrl+Shift+Z (Redo)

            if (e.Control && e.KeyCode == Keys.S)
            {
                SaveFileWithPromptIfNeeded();
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
            else if (e.Control && e.Shift && e.KeyCode == Keys.Z)
            {
                Redo();
                e.Handled = true;
            }
            else if (e.Control && e.KeyCode == Keys.Z)
            {
                Undo();
                e.Handled = true;
            }
            else if (e.Control && e.KeyCode == Keys.Y)
            {
                Redo();
                e.Handled = true;
            }
            else if (e.Control && e.KeyCode == Keys.Q)
            {
                CloseAnyActiveMode();
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
            else if (e.Control && e.KeyCode == Keys.D)
            {
                CancelAnyActiveMode();
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
            else if (e.Control && e.KeyCode == Keys.R)
            {
                RefreshProgram();
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }

        //============================================================
        // UNDO/REDO FUNCTIONALITY
        //============================================================
        // These methods implement Undo/Redo similar to most text editors.
        // Undo pops a previous state from the undoStack,
        // Redo re-applies a state that was undone.

        private void Undo()
        {
            if (undoStack.Count > 0)
            {
                redoStack.Push(lastText);      // Store current state for Redo
                lastText = undoStack.Pop();    // Revert to previous state
                TxtUserMarkdown.Text = lastText;
            }
        }

        private void Redo()
        {
            if (redoStack.Count > 0)
            {
                undoStack.Push(lastText);      // Current state goes into Undo stack
                lastText = redoStack.Pop();    // Take the previously undone state
                TxtUserMarkdown.Text = lastText;
            }
        }

        //============================================================
        // MODE CLOSING AND REFRESHING
        //============================================================
        // If the user presses CTRL+Q, we finalize and close any active mode,
        // applying the formatting. CTRL+D cancels the mode without applying.
        // RefreshProgram clears and re-renders the preview, helping unfreeze if needed.

        private void CloseAnyActiveMode()
        {
            // This method checks each mode and if active,
            // finalizes it by applying formatting to typed text.

            if (isBoldMode)
            {
                ApplyModeToTypedText("bold");
                isBoldMode = false;
                boldStartPos = -1;
                ResetModeIndicators();
            }
            else if (isItalicMode)
            {
                ApplyModeToTypedText("italic");
                isItalicMode = false;
                italicStartPos = -1;
                ResetModeIndicators();
            }
            else if (isUnderlineMode)
            {
                ApplyModeToTypedText("underline");
                isUnderlineMode = false;
                underlineStartPos = -1;
                ResetModeIndicators();
            }
            else if (isStrikeMode)
            {
                ApplyModeToTypedText("strike");
                isStrikeMode = false;
                strikeStartPos = -1;
                ResetModeIndicators();
            }
            else if (isHeaderMode)
            {
                ApplyModeToTypedText("header");
                isHeaderMode = false;
                headerStartPos = -1;
                ResetModeIndicators();
            }
        }

        private void CancelAnyActiveMode()
        {
            // Cancels any active formatting mode without applying any formatting.
            // Simply resets all mode flags and positions.
            if (isBoldMode) { isBoldMode = false; boldStartPos = -1; }
            if (isItalicMode) { isItalicMode = false; italicStartPos = -1; }
            if (isUnderlineMode) { isUnderlineMode = false; underlineStartPos = -1; }
            if (isStrikeMode) { isStrikeMode = false; strikeStartPos = -1; }
            if (isHeaderMode) { isHeaderMode = false; headerStartPos = -1; }

            ResetModeIndicators();
        }

        private void RefreshProgram()
        {
            // Clears the current preview and re-renders it.
            // Useful if the renderer appears stuck or frozen.
            WBMarkdown.DocumentText = "";
            UpdatePreview();
        }

        //============================================================
        // UI HELPER METHODS
        //============================================================
        // These methods help maintain a consistent UI state,
        // like resetting mode indicators after applying a mode.

        private void ResetModeIndicators()
        {
            // Restore default button colors, indicating no active mode
            BtnMDBold.UseVisualStyleBackColor = true;
            BtnMDItalic.UseVisualStyleBackColor = true;
            BtnMDUnderline.UseVisualStyleBackColor = true;
            BtnMDStrike.UseVisualStyleBackColor = true;
            BtnMDHeader.UseVisualStyleBackColor = true;
        }
    }
}
