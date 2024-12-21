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
* FrmPostFixCalculator.cs
*
* Main Form Handler for the Post Fix Calculator Project
*
* Author: Jetson Black
* Date Created: 12/5/2024
* Last Modified by: Jetson Black
* Date Last Modified: 12/10/2024
* Assignment: HOMEWORK 3
* Part of: A290 Homework 3 Project
***********************************************************/
namespace PostFixCalculator
{
    public partial class FrmPostFixCalculator : Form
    {
        public FrmPostFixCalculator()
        {
            InitializeComponent();
        }
        // Boolean to track if Radian mode is enabled
        private bool isRadianMode = true;

        // 3 variables of the double type to hold values as exact numerics,
        // We also store the Result in the Double Type
        double dbleFirstNum = 0;
        double dbleSecondNum = 0;
        double dbleResult = 0;

        // String variables utilized to carry data from the User Text Input,
        // We also include a validation string to be used in validation later,
        // we use a seperate string to keep data integrity.
        string strFirstNum = "0";
        string strSecondNum = "0";
        string strResult = "0";
        string strValidation = "0";

        // variables used in validation of doubles,
        // dbleNumCheck is used to validate against,
        // isNum is a boolean that flips based on validation result.
        double dbleNumCheck = 0;
        public bool isNum;

        // Enum to represent the last unary operation
        // We use this to store the last unary operation so the user does not
        // have to manually update the result when they toggle the Radian Mode 
        // Check Box
        private enum UnaryOperation
        {
            None,
            Sin,
            Cos,
            Tan
        }
        // Variable to store the last unary operation
        private UnaryOperation lastUnaryOperation = UnaryOperation.None;

        // Solarized Dark Colors taken from
        // https://ethanschoonover.com/solarized/ 
        Color base03 = ColorTranslator.FromHtml("#002b36");
        Color base02 = ColorTranslator.FromHtml("#073642");
        Color base01 = ColorTranslator.FromHtml("#586e75");
        Color base00 = ColorTranslator.FromHtml("#657b83");
        Color base0 = ColorTranslator.FromHtml("#839496");
        Color base1 = ColorTranslator.FromHtml("#93a1a1");
        Color yellow = ColorTranslator.FromHtml("#b58900");
        Color orange = ColorTranslator.FromHtml("#cb4b16");
        Color red = ColorTranslator.FromHtml("#dc322f");
        Color magenta = ColorTranslator.FromHtml("#d33682");
        Color violet = ColorTranslator.FromHtml("#6c71c4");
        Color blue = ColorTranslator.FromHtml("#268bd2");
        Color cyan = ColorTranslator.FromHtml("#2aa198");
        Color green = ColorTranslator.FromHtml("#859900");
        Color base3 = ColorTranslator.FromHtml("#fdf6e3");
        Color bgreen = ColorTranslator.FromHtml("#dcfc03");

        /**********************************************************
        * Initialization Section
        * Handles form load events and input initialization.
        * Last Edited 12/9/2024
        ***********************************************************/

        private void FrmPostFixCalculator_Load(object sender, EventArgs e)
        {
            // Loading of the Form inits this code block, here we populate the input text boxes
            // with placeholder text that is then removed upon user input.
            TxtFirstNum.Text = "First Number";
            TxtSecondNum.Text = "Second Number";

            // Design Aspects (color etc.)
           
            // Set Form Background
            this.BackColor = base03;

            // Set Textbox Background and Foreground Colors
            TxtFirstNum.BackColor = base02;
            TxtFirstNum.ForeColor = base3;

            TxtSecondNum.BackColor = base02;
            TxtSecondNum.ForeColor = base3;

            TxtResult.BackColor = base02;
            TxtResult.ForeColor = bgreen;

            // Set Button Colors
            BtnAdd.BackColor = base01;
            BtnAdd.ForeColor = base3;

            BtnSubt.BackColor = base01;
            BtnSubt.ForeColor = base3;

            BtnMult.BackColor = base01;
            BtnMult.ForeColor = base3;

            BtnDiv.BackColor = base01;
            BtnDiv.ForeColor = base3;

            BtnExp.BackColor = base01;
            BtnExp.ForeColor = base3;

            BtnSin.BackColor = base01;
            BtnSin.ForeColor = base3;

            BtnCos.BackColor = base01;
            BtnCos.ForeColor = base3;

            BtnTan.BackColor = base01;
            BtnTan.ForeColor = base3;

            BtnClear.BackColor = cyan;
            BtnClear.ForeColor = base3;

            BtnQuit.BackColor = orange;
            BtnQuit.ForeColor = base3;

            // Set Label Colors
            LblFirstNum.ForeColor = base3;
            LblSecondNum.ForeColor = base3;
            LblResult.ForeColor = base3;

            // Set Checkbox Color
            ChkRadianToggle.BackColor = base03;
            ChkRadianToggle.ForeColor = base0;

            // Set Label Colors (if you have labels)
            foreach (Control ctrl in this.Controls)
            {
                if (ctrl is Label)
                {
                    ctrl.ForeColor = base0;
                }
            }
        }

        private void TxtFirstNum_MouseDown(object sender, MouseEventArgs e)
        // Event Handler is called when the user clicks on the First Number Textbox
        {
            TxtFirstNum.Text = "";
            // Removes the placeholder text for mouse oriented users
            TxtFirstNum.ForeColor = base0;
        }

        private void TxtSecondNum_MouseDown(object sender, MouseEventArgs e)
        // Event Handler is called when the user clicks on the Second Number Textbox
        {
            TxtFirstNum.Text = "";
            // Removes the placeholder text for mouse oriented users
            TxtFirstNum.ForeColor = base0;
        }

        /**********************************************************
        * Text Input Section
        * Handles user input validation for the First and Second Number text boxes.
        * Last Edited 12/9/2024
        ***********************************************************/

        private void TxtFirstNum_Leave(object sender, EventArgs e)
        // This event handler is triggered when the User's `focus` leaves
        // The Text Box, meaning either the user tabbed or clicked away.
        {
            // Here we take the text input of the user, and conver that into a string
            // we then match that string to our validation string that we use later
            strFirstNum = TxtFirstNum.Text.ToString();
            strValidation = strFirstNum;

            if (strFirstNum.Equals(""))
            {
                // If the string is equal to nothing (i.e "", meaning no input),
                // We update the Text box to have 0 in it and then alert the user to 
                // Their invalid input using a Error message box.
                strFirstNum = "0";
                TxtFirstNum.Text = strFirstNum;
                TxtFirstNum.Lines.Initialize();
                MessageBox.Show("UH OH!!! There is nothing in your First Number! Try again", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                TxtFirstNum.Focus(); 
            }
            else
            {
                // If the input is NOT empty, we then move on to validation of content
                // Here we assign the boolean `isNum` to be the true/false result of a
                // parse attempt on the user input, here we use the validation string to
                // preserve data integrety
                bool isNum = double.TryParse(strValidation, out dbleNumCheck);
                
                if (isNum)
                {
                    // if the input is a valid double, we then set our double First Number variable
                    // to equal the user input
                    dbleFirstNum = double.Parse(strFirstNum);
                }
                else
                {
                    // if the input is not a valid double, then we reset the text of the textbox and alert
                    // the user to their invalid input using a error message box
                    TxtFirstNum.Text = "";
                    strFirstNum = "";
                    TxtFirstNum.Lines.Initialize();
                    MessageBox.Show("That is not a number. Press CLEAR and Try Again", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void TxtSecondNum_Leave(object sender, EventArgs e)
        // This event handler is triggered when the User's `focus` leaves
        // The Text Box, meaning either the user tabbed or clicked away.
        {
            // Here we take the text input of the user, and conver that into a string
            // we then match that string to our validation string that we use later
            strSecondNum = TxtSecondNum.Text.ToString();
            strValidation = strSecondNum;
            if(strSecondNum.Equals(""))
            {
                // If the string is equal to nothing (i.e "", meaning no input),
                // We update the Text box to have 0 in it and then alert the user to 
                // Their invalid input using a Error message box.
                strSecondNum = "0";
                TxtSecondNum.Text = strSecondNum;
                TxtSecondNum.Lines.Initialize();
                MessageBox.Show("UH OH!!! There is nothing in your Second Number! Try again", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                TxtSecondNum.Focus();
            }
            else
            {
                // If the input is NOT empty, we then move on to validation of content
                // Here we assign the boolean `isNum` to be the true/false result of a
                // parse attempt on the user input, here we use the validation string to
                // preserve data integrety
                bool isNum = double.TryParse(strValidation, out dbleNumCheck);
                if (isNum)
                {
                    // if the input is a valid double, we then set our double Second Number variable
                    // to equal the user input.
                    dbleSecondNum = double.Parse(strSecondNum);
                }
                else
                {
                    // if the input is not a valid double, then we reset the text of the textbox and alert
                    // the user to their invalid input using a error message box
                    TxtSecondNum.Text = "";
                    strSecondNum = "";
                    TxtSecondNum.Lines.Initialize();
                    MessageBox.Show("That is not a number. Press CLEAR and Try Again", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        /**********************************************************
        * Misc/Auxillary Event Section
        * Handles auxiliary operations like clearing inputs and quitting the application.
        * Last Edited 12/9/2024
        ***********************************************************/

        private void BtnClear_Click(object sender, EventArgs e)
        // Event Handler for when the Clear Buttons is Clicked,
        {
            // Resets the Text Boxes and sets user 'focus' back to the
            // first number textbox.
            TxtFirstNum.Text = "0";
            TxtSecondNum.Text = "0";
            TxtResult.Text = "";
            TxtFirstNum.Focus();
        }

        private void BtnQuit_Click(object sender, EventArgs e)
        // Event handler for when the Quit Button is clicked.
        {
            Close();
            // Allows for a more elequent way to exit the program, instead of the more archaic 'Red X' in the top right
        }

        /**********************************************************
        * Binary Operator Event Section
        * Handles binary operations: addition, subtraction, multiplication, 
        * division, and exponentiation.
        * Last Edited 12/9/2024
        ***********************************************************/

        private void BtnAdd_Click(object sender, EventArgs e)
        // Event handler for when the Add Button is clicked.
        {
            // The code will not reach this point unless the input is a validated as a double
            // Now we just need to add the two doubles and then put it into the result.
            // ADDITION OCCURS HERE
            dbleResult = (dbleFirstNum + dbleSecondNum);
            strResult = dbleResult.ToString();
            TxtResult.Text = strResult;
        }

        private void BtnSubt_Click(object sender, EventArgs e)
        // Event handler for when the Substraction Button is clicked.
        {
            // The code will not reach this point unless the input is a validated as a double
            // Now we just need to add the two doubles and then put it into the result.
            // SUBTRACTION OCCURS HERE
            dbleResult = (dbleFirstNum - dbleSecondNum);
            strResult = dbleResult.ToString();
            TxtResult.Text = strResult;
        }

        private void BtnMult_Click(object sender, EventArgs e)
        // Event handler for when the Multiplication Button is clicked.
        {
            // The code will not reach this point unless the input is a validated as a double
            // Now we just need to add the two doubles and then put it into the result.
            // MULTIPLICATION OCCURS HERE
            dbleResult = (dbleFirstNum * dbleSecondNum);
            strResult = dbleResult.ToString();
            TxtResult.Text = strResult;
        }

        private void BtnDiv_Click(object sender, EventArgs e)
        // Event handler for when the Division Button is clicked.
        {
            // The code will not reach this point unless the input is a validated as a double
            // Now we just need to add the two doubles and then put it into the result.
            // DIVISION OCCURS HERE
            // We also validate User input to ensure that we don't have a divide by 0 error.
            if (dbleSecondNum == 0)
            {
                MessageBox.Show("Division by zero is not allowed. Please enter a non-zero value for the second number.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                TxtSecondNum.Focus();
            }
            else
            {
                // Perform division if the second number is not zero
                dbleResult = (dbleFirstNum / dbleSecondNum);
                strResult = dbleResult.ToString();
                TxtResult.Text = strResult;
            }
        }
        private void BtnExp_Click(object sender, EventArgs e)
        // Event handler for when the Exponential Button is clicked.
        {
            // The code will not reach this point unless the input is a validated as a double
            // Now we just need to add the two doubles and then put it into the result.
            // EXPONENTIALS ARE CALCULATED HERE
            try
            {
                // Calculate the exponential result
                dbleResult = Math.Pow(dbleFirstNum, dbleSecondNum);

                // Check if the result is infinity
                if (double.IsInfinity(dbleResult))
                {
                    throw new OverflowException("The result is too large to be represented as a double.");
                }

                // Display the result
                strResult = dbleResult.ToString();
                TxtResult.Text = strResult;
            }
            catch (OverflowException ex)
            {
                // Show an error message for large results
                MessageBox.Show(ex.Message, "Overflow Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                TxtResult.Text = "Error";
            }
        }

        /**********************************************************
        * Unary Operator Event Section
        * Handles unary operations: sine, cosine, and tangent calculations.
        * Last Edited 12/9/2024
        ***********************************************************/

        private void BtnSin_Click(object sender, EventArgs e)
        // Event handler for when the Sine Button is clicked.
        {
            // The code will not reach this point unless the input is validated as a double.
            // Calculate the sine of the first number (in radians) and update the result.
            // SIN OPERATION OCCURS HERE
            
            lastUnaryOperation = UnaryOperation.Sin; // update the last unary operation

            // Convert the input to radians if Degree mode is selected
            double input = isRadianMode ? dbleFirstNum : dbleFirstNum * (Math.PI / 180.0);

            // Calculate the sine of the input and update the result
            dbleResult = Math.Sin(input);
            strResult = dbleResult.ToString();
            TxtResult.Text = strResult;
        }

        private void BtnCos_Click(object sender, EventArgs e)
        // Event handler for when the Cosine Button is clicked.
        {
            // The code will not reach this point unless the input is validated as a double.
            // Calculate the cosine of the first number (in radians) and update the result.
            // COS OPERATION OCCURS HERE

            lastUnaryOperation = UnaryOperation.Cos; // update the last unary operation

            // Convert the input to radians if Degree mode is selected
            double input = isRadianMode ? dbleFirstNum : dbleFirstNum * (Math.PI / 180.0);
            
            // Calculate the cosine of the input and update the result
            dbleResult = Math.Cos(input);
            strResult = dbleResult.ToString();
            TxtResult.Text = strResult;
        }

        private void BtnTan_Click(object sender, EventArgs e)
        {
            // The code will not reach this point unless the input is validated as a double.
            // Validate that the first number does not produce an undefined tangent (e.g., odd multiples of π/2).
            // TAN OPERATION OCCURS HERE

            lastUnaryOperation = UnaryOperation.Tan; // update the last unary operation

            // Convert the input to radians if Degree mode is selected
            double input = isRadianMode ? dbleFirstNum : dbleFirstNum * (Math.PI / 180.0);

            // Check for undefined tangent values (odd multiples of π/2)
            double piOverTwo = Math.PI / 2;
            if (Math.Abs(input % Math.PI) == piOverTwo)
            {
                MessageBox.Show("Tangent is undefined for this input. Please enter a different value.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                TxtFirstNum.Focus();
            }
            else
            {
                // Calculate the tangent of the input and update the result
                dbleResult = Math.Tan(input);
                strResult = dbleResult.ToString();
                TxtResult.Text = strResult;
            }
        }

        private void ChkRadianToggle_CheckedChanged(object sender, EventArgs e)
        {
            // Toggle the mode based on the CheckBox state
            isRadianMode = ChkRadianToggle.Checked;

            // Update the CheckBox text to reflect the current mode
            if (isRadianMode)
            {
                ChkRadianToggle.Text = "Radian Mode (Uncheck for Degrees)";
            }
            else
            {
                ChkRadianToggle.Text = "Degree Mode (Uncheck for Radian)";
            }

            // Recalculate the result based on the last unary operation
            switch (lastUnaryOperation)
            {
                case UnaryOperation.Sin:
                    BtnSin_Click(sender, e);
                    break;
                case UnaryOperation.Cos:
                    BtnCos_Click(sender, e);
                    break;
                case UnaryOperation.Tan:
                    BtnTan_Click(sender, e);
                    break;
                default:
                    break;
            }
        }
    }
}
