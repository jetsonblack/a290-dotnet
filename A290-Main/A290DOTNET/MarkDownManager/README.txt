MarkJet README.txt
Jetson Black
jetblack@iu.edu

Important Notes For Startup
-First use Visual Studio 2022
-I tested this on the lab computers and did not have any issues however I will include package management instructions
	1. Once in the solution navigate to the project section of the menu ribbon, on the given drop down navigate to `Manage NuGet Packages...`
	2. Once the Manager has loaded, navigate to the installed tab and see if `MarkDig` by Alexandre Mutel is Installed.
		a. If Markdig is installed you are all set! Skip step 3-5.
		b. If Markdig is not installed you must manually install it, move on to step 3.
	3. To install Markdig move back to the browse tab of the NuGet Manager and Search for `MarkDig` Click on the One titled `MarkDig by xoofx`
	4. On the Right Side of the your screen you should see a panel that prompts you to install the package 
		**NOTE IF THE BUTTON SAYS UNINSTALL YOU ALREADY HAVE THE PACKAGE INSTALLED AND CAN SAFELY MOVE ON**
	5. Once the package is installed the program should run correctly.



Things I wanted to implement but didn't have time to.
	1. I wanted to implement a Line Number System natively to the editor however I could not get it to function with a scrolling textbox
	2. I wanted to implement a dynamic resizing algorithim that would dynamically move controls on the form given resize events however I could not get this completed in the alloted time
		a. Due to this there are some remenants of programatic resizing attempts such as having events subscribed to in the .cs file instead of the designer.cs file.
	3. If I better understood how to completely overhaul native Windows/Microsoft design principles I would have liked to completely overhaul the native styling

General Notes:
	1. Attached throughout the code is comments sourcing certain fixes and behaviors that I encountered
	2. A lot of Helper Functions are used throughout this program, attempted to explain using comments
	3. I have left in a some debugging commands as comments if you want to see them
	4. I used a AppSettings.cs Class to handle option toggles in a single instance however, in production I would use a file on disk to have
	   options persist through different instances.
	

I really enjoyed making this project and with some polishing and time I believe I could make it production ready, so if you have any issues that are glaring please email them to me
at jetblack@iu.edu so I can keep them in mind when refactoring for production.
