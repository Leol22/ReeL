# ReeL
a lil esoteric language based on an expanding tape reel<br> <br>
ReeL has a looping tape reel, every "cell" contains one int value and a "mark" (we'll get to those later). As many languages, the tape has a pointer and you can only interact with the cell selected by it. You also have a stack to work with, just to facilitate the trasfer of data. <br>
The main "gimmick" of ReeL is that the tape has only one cell, BUT you can add/remove more with commands. <br>
You can also "mark" different cells with different numbers (every cell starts marked as "0"). I added this so you can "orient" the code better on the tape.<br>
To execute programs, place the .exe in a PATH folder, go in the command line and type "ReeL", the name of the program you want to execute and, optionally, the name of the file from where you take inputs. An example could be "ReeL test.txt inputs.txt" (i'm not familiar with command line but i'm pretty sure it's not case sensitive)
