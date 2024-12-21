
README.txt - Checklist for A290 Buffet Project 2
Jetson Black
jetblack@iu.edu
Created and Last Edited on:  11/21/2024

Main Buffet Form
1. [✔] Ensure all original functions from Project 1 work correctly.
2. [✔] Add an “Options” button that creates a modeless child form with specified properties.
3. [✔] Add a “Collection” button that creates another modeless child form with specified properties.
4. [✔] Ensure the border adjusts size with the main form when resized (if implemented in Project 1, verify functionality).
5. [✔] Ensure the PictureBox maintains the proper aspect ratio of the image.
6. [✔] Add a “Confirm on Exit” control with functionality as shown in the class example.

Updated to fix the border issue seen on Project 1, However Found that Project 1 was not able to open PNG or other image types,
However this functionality was present in the original iteration, as a drop down menu with PNG and other image types was present 
in the OpenFileDialog. I am unsure about what this Original Issue is refering to.


Options Child Form
1. [✔] Set a non-default background color.
2. [✔] Include a background image.
3. [✔] Adjust Form properties:
   - Simplified border.
   - No maximize/minimize window controls.
   - Appropriate text label and StartPosition.
4. [✔] Add an “OK” button and a “Cancel” button with proper event attachments (AcceptButton and CancelButton).
5. [✔] Add a “UserName:” Label with a properly located TextBox initialized with sample text.
6. [✔] Customize visual properties of all controls to match the overall project design strategy.
7. [✔] Include a GroupBox with:
   - Four controls for changing background color, including a default reset option.
   - Clear textual and visual clues for each control's function.
   - Distinctly visible controls and border under any background color.
8. [✔] Add a ComboBox with:
   - At least five options, one of which is “default.”
   - Border-changing functionality for each option.
   - MessageBox confirmation for color choices.
   - Retention of current background color with border changes.
   - Reset option for returning the form to its original appearance.

Directions are somewhat Vague on how to include a background image alongside changing the background color
So I created a simple Checkbox shown as 'IMG Background?' which allows the user to toggle a resourced
whitebackground.jpg that is also included in the zip folder.


Collection Child Form
1. [✔] Set a non-default background color.
2. [✔] Include a background image.
3. [✔] Adjust Form properties:
   - Simplified border.
   - No maximize/minimize window controls.
   - Appropriate label and StartPosition.
4. [✔] Add a “Quit” button linked to both AcceptButton and CancelButton.
5. [✔] Include a “Show Control Names” button displaying control names and numbers in a MessageBox.
6. [✔] Add at least six controls (button and text box mix) with proper titles, names, and some text content:
   - Alter at least one property (besides Name, Location, Size, and Text) for each control.
	-Outlined in Comments

Directions are somewhat Vague on how to include a background image alongside changing the background color
So I created a simple Checkbox shown as 'IMG Background?' which allows the user to toggle a resourced
whitebackground.jpg that is also included in the zip folder.


General Requirements
1. [✔] Ensure all code files are thoroughly commented:
   - Name and project details at the top of each file.
   - Comments for all property alterations and design choices.
2. [✔] Verify consistent design and appearance across all forms and controls.
3. [✔] Test the project for correct functionality.

Submission Requirements
1. [✔] ZIP the project folder into a *.zip file (use WinZip or compatible tools; no *.7z or other formats).
2. [✔] Test the ZIP file for correct extraction before submission.

