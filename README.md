# ReeL
a lil esoteric language based on an expanding tape reel<br> <br>
ReeL has a looping tape reel, every "cell" contains one int value and a "mark" (we'll get to those later). As many languages, the tape has a pointer and you can only interact with the cell selected by it (named "active cell"). You also have a stack to work with, just to facilitate the trasfer of data. <br>
The main "gimmick" of ReeL is that the tape has only one cell, BUT you can add/remove more with commands. <br>
You can also "mark" different cells with different numbers (every cell starts marked as "0"). I added this so you can "orient" the code better on the tape.<br>
To execute programs, place the .exe in a PATH folder, go in the command line and type "ReeL", the name of the program you want to execute and, optionally, the name of the file from where you take inputs. An example could be "ReeL test.txt inputs.txt" (i'm not familiar with command line but i'm pretty sure it's not case sensitive)
<h1>COMMAND LIST</h1>
All commands are 3 letters and sometimes an argument, represented by [V]. I've spaced out some commands for readability purposes. Comments are any line that starts with "/".
<table>
  <tr>
    <th>COMMAND</th>
    <th>USE</th>
  </tr>
  <tr>
    <th>inp</th>
    <th>takes an input and places it in the active tape cell</th>
  </tr>
    <tr>
    <th>t++</th>
    <th>increments the active cell by 1</th>
  </tr>
    <tr>
    <th>t - -</th>
    <th>decrements the active cell by 1</th>
  </tr>
    <tr>
    <th>flp</th>
    <th>flips the active cell, from positive to negative and vice-versa</th>
  </tr>
    <tr>
    <th>mrk [V]</th>
    <th>marks the active cell as [V]</th>
  </tr>
    <tr>
    <th>t<<</th>
    <th>decrements the pointer by 1 (think of it as < in brainfuck)</th>
  </tr>
    <tr>
    <th>t>></th>
    <th>increments the pointer by 1 (like > in brainfuck)</th>
  </tr>
    <tr>
    <th>plc</th>
    <th>will add one new cell to the tape (with a value and mark of 0), pushing the active cell forward and becoming the new active cell</th>
  </tr>
    <tr>
    <th>rem</th>
    <th>will remove one cell from the tape, it changes the tape in the exact opposite way of "plc" (the active cell is removed and every cell after it is moved back)</th>
  </tr>
    <tr>
    <th>grb</th>
    <th>will add the value of the active cell on top of the stack, and leave the active cell as 0</th>
  </tr>
    <tr>
    <th>add</th>
    <th>will add the value of the active cell to the value on top of the stack, and leave the active cell as 0</th>
  </tr>
    <tr>
    <th>put</th>
    <th>will move the top value of the stack to the active cell</th>
  </tr>
    <tr>
    <th>len</th>
    <th>will set the active cell to the lenght of the stack</th>
  </tr>
    <tr>
    <th>dup</th>
    <th>will duplicate the top value of the stack, like in concatenative programming</th>
  </tr>
    <tr>
    <th>nil</th>
    <th>will remove the top value of the stack, like "pop" in concatenative programming</th>
  </tr>
    <tr>
    <th>bak</th>
    <th>will move the top value of the stack to the bottom of the stack</th>
  </tr>
    <tr>
    <th>out</th>
    <th>will output the active cell's value</th>
  </tr>
    <tr>
    <th>mode</th>
    <th>will switch the input/output mode from numbers to ascci and back (default is numbers)</th>
  </tr>
    <tr>
    <th>###</th>
    <th>does nothing on its own, serves as a landing point for jumps</th>
  </tr>
    <tr>
    <th>ajp [V]</th>
    <th>will jump [V] marks forward, if [V] is negative it will jump backwards. if it reaches the beginning/end of the file, it will wrap around. For example, if [V] is 1, it will jump to the first mark it encounters moving forward. </th>
  </tr>
    <tr>
    <th>ift [V]</th>
    <th>if the active cell has a value of [V], it will result true, otherwise false. (does nothing on it's own, is needed for conditional jumps)</th>
  </tr>
    <tr>
    <th>ifm [V]</th>
    <th>if the active cell has a mark of [V], it will result true, otherwise false. (does nothing on it's own, is needed for conditional jumps).</th>
  </tr>
    <tr>
    <th>tjp</th>
    <th>acts the same as "ajp", but will only jump if the last test performed was true</th>
  </tr>
    <tr>
    <th>fjp</th>
    <th>acts the same as "ajp", but only if the last test was false</th>
  </tr>
    <tr>
    <th>end</th>
    <th>ends the program when executed (reaching eof will loop the program)</th>
  </tr>
</table>
