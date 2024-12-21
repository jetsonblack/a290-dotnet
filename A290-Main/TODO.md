# topics for MINI3 and JIT3

	1. Markdown
	2. File I/O and/or File Extensions
	3. Libraries

# Final Project Phase 2a, 2b
	

	2a) 35pts the story boards.
		Master Board, Shows all the possible forms in my application, and/or the changes in appearance that may come from my application.
			-Map out how to navigate the depths of each forms.
		Make sure to keep writing to a minimum, use drawings and design topics to show how the application works.
			-Don't need exact screen diagrams, (Writing and programmatic component will be handled in 2b)
		Detailed Story board for each form will be separated, with 2 per page.
			-Main Form, File i/o Form, Markdown Render Form, Options Form, Save Form, Markdown Tutorial Form..
			-Consult chatGPT for a full plan for this project, what is a reasonable thing to create?
			-MAX 2 STORYBOARDS PER SHEET, detailed Storyboards don't need to have navigation listed, instead having that fall upon the Master Story Board

	2b) 35pts written and printed out version that will handle 7-8 topics, make sure to format it as described in the assignment document
		Must Complete all topics regardless if they have any bearing on my final project, either stating that I does not have any bearing or explain how it does
# package install
	-Project -> Manage NuGet Packages..->   Lookup MarkDig Package

# HOMEWORK PROJ 3
	-Adjust The Tab Index of the Project
	-additional mathematical operations
		x^y, x is first number, operator ^, y is the second number
	-Use Iconics for Calculator Buttons

	use a String to take in the input from the user in the textbox, converting the Strings into Doubles or Integers. Based on that we will then calculate that value, 	convert that result into a String and then display that to a user.
	
	-Do input validation.
	//3 variables of the double type to hold input values as exact numerics
	// We also store the Result in the Double Type
	double dbleFirstNum = 0;
	double dbleSecondNum = 0;
	double dblResult = 0;
	
	//
	string strFirstNum = 0;
	string strSecondNum = 0;
	string strResult = 0;
	string strValidation = 0;

	double dbleNumCheck = 0;
	
	public bool isNum;

	For each Tet Field use the Leave and the MouseDown Event handlers.
	

	strFirstNum = TxtFirstNum.ToString()
	strValidation = strFirstNum
	
	
	
	if(strFirstNum.Equals("")
	{
		strFirstNum = "0";
		TxtFirstNum.Text = strFirstNum;
		extFirstNum.Lines.Initialize();
		MessageBox.Show(text: You fucked up nothing is in there);
		TxtFirstNum.Focus();
	}
	else
	{	
		bool isNum = double.TryParse(strValidation, out dblNumCheck);
		if (isNum)
		{
		dblFirstNum = double.Parse(strFirstNum);
		}
		else
		{
			TxtFirstNum.Text ="";
			strFirstNum = "";
			TextFirstNum.Lines.Initialize();
			MessageBox.Show(text: "That is not a number. Press Clear and Try Again");
		}
	}

	
	
	Solve Divide By Zero,
		- If the user has second number as '0', and clicks the divide event, have a message box prompt the user to change the second number.
	Prevent Exponential results with largest Numbers.
	Use Ico Files for header.

	Remove the ability to resize by setting min and max values of the window to be the same, remove the maximize button.
	
	Design Stuff:
	Flat, Colors, Vertical, 2 sections of operators, +, -, *, /, ^




---	
	# Day 2
	
### TODO for project,
	1. Create README which has notes on the project, any functions that I didn't get a chance to implement or path 	renames etc. 	(Make sure to have package installed with instructions on how to do so, is possible with the NuGET package manager)
	-I wanted to create a way to persist options through different sessions/instances
	-Create a Image handler for the MD editor
	-Create a toggle for GitHub MD vs normal MD
		
	
	2. Create a user guide in word that shows how to use the program effectively.	

### TODO for Homework 3
	# Create section Comments that explain what a section of code means and what it is responsible for.
	Mouse Event Handlers should be MouseDown
	

//removes the place holder text for the Text boxes
private void TxtFirstNum_MouseDown(object sender, MouseEventArgs e)
{
	TxtFirstNum.Text = "";
}
private void TxtSecondNum_MouseDown(object sender, MouseEventArgs e)
{
	TxtSecondNum.Text = "";
}

private void BtnCLear_Click(object sender, MouseEventArgs e)
{
	TxtFirstNum.Text = "0";
	...
	TxtFirstNum.Focus();
}



private void BtnAdd_Click(object sender, System.EventArgs e)
{
	dblResult = (dblFirstNum + dblSecondNum);
	strResult = dblResult.ToString();
	TxtResult.Text = strResult;
}
private void BtnSubtract_Click(object sender, System.EventArgs e)
{
	//The code will not reach this point unless the input is a validated as a double
	//Now we just need to add the two doubles and then put it into the result.
	dblResult = (dblFirstNum - dblSecondNum);
	strResult = dblResult.ToString();
	TxtResult.Text = strResult;
}



// Need to include 4 more operators, ^, logs, sin, cos, tan.
	-The important thing is to separate unary and binary operators (maybe use a label)
// Include validation in the divide function that prompts the user to change the second number if they have inputted 0
// experiment how to show multiplication with large numbers such that exponents are always used.

//since we have load events for the textboxs, we can return the form's focus to the first number tab index.
// design wise, make the program solarized dark compliant. https://ethanschoonover.com/solarized/ 
// do not allow the user to change the size of the calculator, max and min size should be the same.


private void FrmCalculator_Load(object sender, System.EventArgs e)
{
	TxtFirstNum.Text = "First Number";
	TxtSecondNum.Text = "Second Number";
}


Control the TabIndex of the Form, with 0 being what will be focused upon the loading of the form.


---


How to share data between two different forms
Look at the meeting guide for this content, useful for sending toggles from the Option Child Form to the Main Parent Form.


Child Form
public FrmOptions(string text)
{

}







