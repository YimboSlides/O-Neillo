# O'Neillo Game

## Description
This project was created as part of my assignment for my first year at uni as a degree apprentice. The program is a version of the board game 'Othello'. 

It incorporates many elements of programming covered in my first year module, including the use of classes, windows forms, comments and conventions; none of which I have applied to a project of this size before.


## Components
The project incorporates a class, known as 'GameboardImageArray', which was developed by my lecturers to support students who
did not feel confident enough to develop parts of the code responsible for rendering the GUI. This class, in addition to the images supplied for the tiles and playing pieces, and the images for the order-of-play arrow are the only elements of my project that are not my own work.

## Installation
A recurring issue I have identified is that sometimes the program is unable to run due to the fact that the .resx files have the mark of web. To solve this issue, after downloading the .zip folder for this project right click it and select Properties. From here, check the box marked 'Unblock', and then extract the files. The project should now work properly.

All necessary files for this project are contained in this zipped folder. The only additional requirements for this project are that the Newtonsoft library is installed, which is necessary for the saving games function. 

To install, refer to the following link (https://learn.microsoft.com/en-us/nuget/quickstart/install-and-use-a-package-in-visual-studio), and read the steps under the sub heading 'Add the Newtonsoft.Json NuGet package'.

In addition, since this project uses WinForms, it must be run on a device with Windows installed - Mac devices will not work.