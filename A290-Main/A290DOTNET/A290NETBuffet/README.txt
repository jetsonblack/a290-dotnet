1. Base Windows Form ✔
2. PictureBox Window ✔
3. Select File Button with Filters for at least 3 Recognized Image File Formats ✔
	Note: Includes JPG, PNG, BMP and general Images Filter that looks for all 3
4. Quit Button and Implementation ✔
5. Draw Border Button and Implementation ✔
6. Enlarge and Shrink Buttons with iconographic labels ✔
7. X/Y Labels Including Hiding when out of Picture Box ✔
8. Modifications to keep controls anchored alongside ensuring that controls cannot be
   Hidden on accident. Border Rectangle is draw dynamically alonside the PictureBox's
   Resizing ✔
9. The Image selected for the Picture Box is displayed in its entirety ✔
10. A total of 11 changes were made in regards to the design and properities of 
    visible items, listed at the top of the document and below ✔
			
			10✔s /10 possible

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

Comments are included in the document, explaining details without being
redundant, inline comments are listed below their referenced line.



