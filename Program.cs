
string path = @$"./{args[0]}";
string[] ins = { };
bool intype=false;
if (args.Length > 1) {ins=File.ReadAllLines(@$"./{args[1]}");intype = true; }
string[] code = File.ReadAllLines(path);
int step = 0;
int pointer = 0;
int inpointer = 0;
bool active = true;
bool mode=false;
bool test=false;
List<int> tape = new();
List<int> stack = new();
List<int> marks= new();
int instep = 0;
tape.Add(0);
marks.Add(0);
int v;
void search(int left) {
    int adding = left / Math.Abs(left);
    left = Math.Abs(left);
    while (left > 0)
    {
        step += adding;
        if (step == -1) { step = code.Length - 1; }
        if (step == code.Length) { step = 0; }
        if (code[step] == "###") { left--; }
    }

}

while (active)
{
    if (code[step][0] == '/' || code[step].Length<3) { }
    else {
        v = 0;
        if (code[step].Length > 4) { v = int.Parse(code[step].Substring(4, code[step].Length - 4)); }
        string command = code[step].Substring(0, 3);
        switch (command)
        {
            //TAPE
            case "mrk":
                marks[pointer] = v;
                break;
            case "end":
                active = false;
                break;
            case "flp":
                tape[pointer] = tape[pointer] * -1;
                break;
            case "t>>":
                pointer++;
                break;
            case "t<<":
                pointer--;
                break;
            case "t++":
                tape[pointer]++;
                break;
            case "t--":
                tape[pointer]--;
                break;
            case "plc":
                tape.Insert(pointer, 0);
                marks.Insert(pointer, 0);
                break;
            case "rem":
                if (tape.Count > 1) { tape.RemoveAt(pointer); marks.RemoveAt(pointer); }
                break;
            //IO
            case "mod":
                if (mode) { mode = false; }
                else { mode = true; }
                break;
            case "inp":
                if (intype)
                {
                    if (mode)
                    {
                        tape[pointer] = (byte)ins[inpointer][instep];
                        instep++;
                        if (instep == ins[inpointer].Length) {instep=0;inpointer++; }
                    }
                    else
                    {
                        if (instep > 0) { instep = 0;inpointer++; }
                        tape[pointer] = int.Parse(ins[inpointer]);
                        inpointer++;
                    }
                    if (inpointer == ins.Length) { inpointer = 0; }

                }
                else
                {
                    if (mode)
                    {
                        tape[pointer] = (byte)Console.ReadLine()[0] ;
                    }
                    else
                    {
                        tape[pointer] = int.Parse(Console.ReadLine());
                    }
                }
                break;
            case "out":
                if (mode)
                {
                    Console.WriteLine((char)(tape[pointer]));

                }
                else
                {
                    Console.WriteLine(tape[pointer]);

                }
                break;
            //tape-stack
            case "grb":
                stack.Add(tape[pointer]);
                tape[pointer] = 0; 
            break;
            case "add":
                stack[stack.Count - 1] += tape[pointer];
                tape[pointer] = 0;
            break;
            case "put":
                tape[pointer] = stack[stack.Count - 1];
                stack.RemoveAt(stack.Count - 1);
            break;
            case "len":
                tape[pointer] = stack.Count;
            break;
            //conditionals
            //stack
            case "dup":
                stack.Add(stack[stack.Count - 1]);
            break;
            case "bak":
                stack.Insert(0, stack[stack.Count - 1]);
                stack.RemoveAt(stack.Count - 1);
            break;
            case "nil":
                stack.RemoveAt(stack.Count - 1);
            break;
            //conditionals
            case "ift":
                if (tape[pointer] == v) { test=true; }
                else { test=false; }
                break;
            case "ifm":
                if (marks[pointer] == v) { test = true; }
                else { test = false; }
                break;
            case "ajp":
                search(v);
                break;
            case "fjp":
                if (!test) {search(v);}
                break;
            case "tjp":
                if (test) { search(v);}
                break;
            //default
            default:
                break;

        }
    }
    if (pointer == tape.Count) { pointer = 0; }
    if (pointer < 0) { pointer = tape.Count - 1; }
    step++;
    if (step == code.Length) { step = 0; }
}