/*
Author: Alex Majka 20429324
System: Windows 11, VSCode 1.72.1
Version 1.0.0
*/

/*
MEMENTO PATTERN
*/

using System;
using System.Linq;
using System.IO;
namespace Program
{
    class MementoAssignment
    {
        public static Caretaker caretaker = new Caretaker();
        public static List<string> redoList = new List<string>();
        public static List<string> commands = new List<string>();
        public static void Main(String[]args)
        {
            //Declaring all variables
            string cmdLine;
            List<string> canvas = new List<string>();
            bool quit = false;

            //Adding starting header in the canvas list
            Memento canvasSize = new Memento("<svg viewBox=\"0 0 1920 1080\" xmlns=\"http://www.w3.org/2000/svg\">");
            caretaker.addMemento(canvasSize);

            Memento Ycirc = new Memento("<circle cx = \"960\" cy = \"540\" r = \"500\" style = \" fill : yellow ; stroke : black ; stroke-width : 10\" />");
            caretaker.addMemento(Ycirc);

            //Getting input in a do while loop
            do
            {
                //read in next line
                cmdLine = Console.ReadLine();

                //Splitting the command line input and getting file path
                string[] cmdCont = cmdLine.Split(" ");
                
                //switch statements on what to do when certain input is made
                switch(cmdCont[0])
                {
                    case "add":
                        if(cmdCont[1].Equals("left-eye"))
                        {
                            //creating eye and adding it to canvas
                            Eye le = new Eye(780,400,50,"black","black", "10");
                            le.printShape(caretaker);
                            commands.Add("left-eye");
                        }
                        else if(cmdCont[1].Equals("right-eye"))
                        {
                            //creating eye and adding it to canvas
                            Eye re = new Eye(1140,400,50,"black","black", "10");
                            re.printShape(caretaker);
                            commands.Add("right-eye");
                        }
                        else if(cmdCont[1].Equals("left-brow"))
                        {
                            //creating brow and adding it to canvas
                            Brow lb = new Brow(730,310,830,310,"black", "15");
                            lb.printShape(caretaker);
                            commands.Add("left-brow");
                        }
                        else if(cmdCont[1].Equals("right-brow"))
                        {
                            //creating brow and adding it to canvas
                            Brow rb = new Brow(1090,310,1190,310,"black", "15");
                            rb.printShape(caretaker);
                            commands.Add("right-brow");
                        }
                        else if(cmdCont[1].Equals("mouth"))
                        {
                            //creating mouthw and adding it to canvas
                            Mouth m = new Mouth(800,750,1120,750,"black", "30");
                            m.printShape(caretaker);
                            commands.Add("mouth");
                        }
                        break;
                    case "remove":
                        if(cmdCont[1].Equals("left-eye"))
                        {
                            for(int i = 0; i < commands.Count; i++)
                            {
                                if(commands[i] == "left-eye")
                                {
                                    int ind = i+2;
                                    caretaker.Remove(ind);
                                    commands.RemoveAt(i);
                                }
                            }
                        }
                        else if(cmdCont[1].Equals("right-eye"))
                        {
                            for(int i = 0; i < commands.Count; i++)
                            {
                                if(commands[i] == "right-eye")
                                {
                                    int ind = i+2;
                                    caretaker.Remove(ind);
                                    commands.RemoveAt(i);
                                }
                            }
                        }
                        else if(cmdCont[1].Equals("left-brow"))
                        {
                            for(int i = 0; i < commands.Count; i++)
                            {
                                if(commands[i] == "left-brow")
                                {
                                    int ind = i+2;
                                    caretaker.Remove(ind);
                                    commands.RemoveAt(i);
                                }
                            }
                        }
                        else if(cmdCont[1].Equals("right-brow"))
                        {
                            for(int i = 0; i < commands.Count; i++)
                            {
                                if(commands[i] == "right-brow")
                                {
                                    int ind = i+2;
                                    caretaker.Remove(ind);
                                    commands.RemoveAt(i);
                                }
                            }
                        }
                        else if(cmdCont[1].Equals("mouth"))
                        {
                            for(int i = 0; i < commands.Count; i++)
                            {
                                if(commands[i] == "mouth")
                                {
                                    int ind = i+2;
                                    caretaker.Remove(ind);
                                    commands.RemoveAt(i);
                                }
                            }
                        }
                        break;
                    case "move":
                        if(cmdCont[1].Equals("left-eye"))
                        {
                            if(cmdCont[2].Equals("up"))
                            {
                                for(int i = 0; i < commands.Count; i++)
                                {
                                    if(commands[i] == "left-eye")
                                    {
                                        int ind = i+2;
                                        caretaker.MoveUp("left-eye", int.Parse(cmdCont[3]) ,ind);
                                    }
                                }
                            }
                            else if(cmdCont[2].Equals("down"))
                            {
                                for(int i = 0; i < commands.Count; i++)
                                {
                                    if(commands[i] == "left-eye")
                                    {
                                        int ind = i+2;
                                        caretaker.MoveDown("left-eye", int.Parse(cmdCont[3]) ,ind);
                                    }
                                }
                            }
                            else if(cmdCont[2].Equals("left"))
                            {
                                for(int i = 0; i < commands.Count; i++)
                                {
                                    if(commands[i] == "left-eye")
                                    {
                                        int ind = i+2;
                                        caretaker.MoveLeft("left-eye", int.Parse(cmdCont[3]) ,ind);
                                    }
                                }
                            }
                            else if(cmdCont[2].Equals("right"))
                            {
                                for(int i = 0; i < commands.Count; i++)
                                {
                                    if(commands[i] == "left-eye")
                                    {
                                        int ind = i+2;
                                        caretaker.MoveRight("left-eye", int.Parse(cmdCont[3]) ,ind);
                                    }
                                }
                            }
                        }
                        else if(cmdCont[1].Equals("right-eye"))
                        {
                            if(cmdCont[2].Equals("up"))
                            {
                                for(int i = 0; i < commands.Count; i++)
                                {
                                    if(commands[i] == "right-eye")
                                    {
                                        int ind = i+2;
                                        caretaker.MoveUp("right-eye", int.Parse(cmdCont[3]) ,ind);
                                    }
                                }
                            }
                            else if(cmdCont[2].Equals("down"))
                            {
                                for(int i = 0; i < commands.Count; i++)
                                {
                                    if(commands[i] == "right-eye")
                                    {
                                        int ind = i+2;
                                        caretaker.MoveDown("right-eye", int.Parse(cmdCont[3]) ,ind);
                                    }
                                }
                            }
                            else if(cmdCont[2].Equals("left"))
                            {
                                for(int i = 0; i < commands.Count; i++)
                                {
                                    if(commands[i] == "right-eye")
                                    {
                                        int ind = i+2;
                                        caretaker.MoveLeft("right-eye", int.Parse(cmdCont[3]) ,ind);
                                    }
                                }
                            }
                            else if(cmdCont[2].Equals("right"))
                            {
                                for(int i = 0; i < commands.Count; i++)
                                {
                                    if(commands[i] == "right-eye")
                                    {
                                        int ind = i+2;
                                        caretaker.MoveRight("right-eye", int.Parse(cmdCont[3]) ,ind);
                                    }
                                }
                            }
                        }
                        else if(cmdCont[1].Equals("left-brow"))
                        {
                            if(cmdCont[2].Equals("up"))
                            {
                                for(int i = 0; i < commands.Count; i++)
                                {
                                    if(commands[i] == "left-brow")
                                    {
                                        int ind = i+2;
                                        caretaker.MoveUp("left-brow", int.Parse(cmdCont[3]) ,ind);
                                    }
                                }
                            }
                            else if(cmdCont[2].Equals("down"))
                            {
                                for(int i = 0; i < commands.Count; i++)
                                {
                                    if(commands[i] == "left-brow")
                                    {
                                        int ind = i+2;
                                        caretaker.MoveDown("left-brow", int.Parse(cmdCont[3]) ,ind);
                                    }
                                }
                            }
                            else if(cmdCont[2].Equals("left"))
                            {
                                for(int i = 0; i < commands.Count; i++)
                                {
                                    if(commands[i] == "left-brow")
                                    {
                                        int ind = i+2;
                                        caretaker.MoveLeft("left-brow", int.Parse(cmdCont[3]) ,ind);
                                    }
                                }
                            }
                            else if(cmdCont[2].Equals("right"))
                            {
                                for(int i = 0; i < commands.Count; i++)
                                {
                                    if(commands[i] == "left-brow")
                                    {
                                        int ind = i+2;
                                        caretaker.MoveRight("left-brow", int.Parse(cmdCont[3]) ,ind);
                                    }
                                }
                            }
                        }
                        else if(cmdCont[1].Equals("right-brow"))
                        {
                            if(cmdCont[2].Equals("up"))
                            {
                                for(int i = 0; i < commands.Count; i++)
                                {
                                    if(commands[i] == "right-brow")
                                    {
                                        int ind = i+2;
                                        caretaker.MoveUp("right-brow", int.Parse(cmdCont[3]) ,ind);
                                    }
                                }
                            }
                            else if(cmdCont[2].Equals("down"))
                            {
                                for(int i = 0; i < commands.Count; i++)
                                {
                                    if(commands[i] == "right-brow")
                                    {
                                        int ind = i+2;
                                        caretaker.MoveDown("right-brow", int.Parse(cmdCont[3]) ,ind);
                                    }
                                }
                            }
                            else if(cmdCont[2].Equals("left"))
                            {
                                for(int i = 0; i < commands.Count; i++)
                                {
                                    if(commands[i] == "right-brow")
                                    {
                                        int ind = i+2;
                                        caretaker.MoveLeft("right-brow", int.Parse(cmdCont[3]) ,ind);
                                    }
                                }
                            }
                            else if(cmdCont[2].Equals("right"))
                            {
                                for(int i = 0; i < commands.Count; i++)
                                {
                                    if(commands[i] == "right-brow")
                                    {
                                        int ind = i+2;
                                        caretaker.MoveRight("right-brow", int.Parse(cmdCont[3]) ,ind);
                                    }
                                }
                            }
                        }
                        else if(cmdCont[1].Equals("mouth"))
                        {
                            if(cmdCont[2].Equals("up"))
                            {
                                for(int i = 0; i < commands.Count; i++)
                                {
                                    if(commands[i] == "mouth")
                                    {
                                        int ind = i+2;
                                        caretaker.MoveUp("mouth", int.Parse(cmdCont[3]) ,ind);
                                    }
                                }
                            }
                            else if(cmdCont[2].Equals("down"))
                            {
                                for(int i = 0; i < commands.Count; i++)
                                {
                                    if(commands[i] == "mouth")
                                    {
                                        int ind = i+2;
                                        caretaker.MoveDown("mouth", int.Parse(cmdCont[3]) ,ind);
                                    }
                                }
                            }
                            else if(cmdCont[2].Equals("left"))
                            {
                                for(int i = 0; i < commands.Count; i++)
                                {
                                    if(commands[i] == "mouth")
                                    {
                                        int ind = i+2;
                                        caretaker.MoveLeft("mouth", int.Parse(cmdCont[3]) ,ind);
                                    }
                                }
                            }
                            else if(cmdCont[2].Equals("right"))
                            {
                                for(int i = 0; i < commands.Count; i++)
                                {
                                    if(commands[i] == "mouth")
                                    {
                                        int ind = i+2;
                                        caretaker.MoveRight("mouth", int.Parse(cmdCont[3]) ,ind);
                                    }
                                }
                            }
                        }
                        break;
                    case "rotate":
                        if(cmdCont[1].Equals("left-eye"))
                        {
                            for(int i = 0; i < commands.Count; i++)
                            {
                                if(commands[i] == "left-eye")
                                {
                                    int ind2 = i+2;
                                    caretaker.Rotate(cmdCont[1], cmdCont[2], int.Parse(cmdCont[3]) ,ind2);
                                }
                            }
                        }
                        else if(cmdCont[1].Equals("right-eye"))
                        {
                            for(int i = 0; i < commands.Count; i++)
                            {
                                if(commands[i] == "right-eye")
                                {
                                    int ind2 = i+2;
                                    caretaker.Rotate(cmdCont[1], cmdCont[2], int.Parse(cmdCont[3]) ,ind2);
                                }
                            }
                        }
                        else if(cmdCont[1].Equals("left-brow"))
                        {
                            for(int i = 0; i < commands.Count; i++)
                            {
                                if(commands[i] == "left-brow")
                                {
                                    int ind2 = i+2;
                                    caretaker.Rotate(cmdCont[1], cmdCont[2], int.Parse(cmdCont[3]) ,ind2);
                                }
                            }
                        }
                        else if(cmdCont[1].Equals("right-brow"))
                        {
                            for(int i = 0; i < commands.Count; i++)
                            {
                                if(commands[i] == "right-brow")
                                {
                                    int ind2 = i+2;
                                    caretaker.Rotate(cmdCont[1], cmdCont[2], int.Parse(cmdCont[3]) ,ind2);
                                }
                            }
                        }
                        else if(cmdCont[1].Equals("mouth"))
                        {
                            for(int i = 0; i < commands.Count; i++)
                            {
                                if(commands[i] == "mouth")
                                {
                                    int ind2 = i+2;
                                    caretaker.Rotate(cmdCont[1], cmdCont[2], int.Parse(cmdCont[3]) ,ind2);
                                }
                            }
                        }
                        break;
                    case "style":
                        if(cmdCont[1].Equals("left-eye"))
                        {
                            for(int i = 0; i < commands.Count; i++)
                            {
                                if(commands[i] == "left-eye")
                                {
                                    int ind2 = i+2;
                                    caretaker.Style(cmdCont[1], cmdCont[2], ind2);
                                }
                            }
                        }
                        else if(cmdCont[1].Equals("right-eye"))
                        {
                            for(int i = 0; i < commands.Count; i++)
                            {
                                if(commands[i] == "right")
                                {
                                    int ind2 = i+2;
                                    caretaker.Style(cmdCont[1], cmdCont[2], ind2);
                                }
                            }
                        }
                        else if(cmdCont[1].Equals("left-brow"))
                        {
                            for(int i = 0; i < commands.Count; i++)
                            {
                                if(commands[i] == "left-brow")
                                {
                                    int ind2 = i+2;
                                    caretaker.Style(cmdCont[1], cmdCont[2], ind2);
                                }
                            }
                        }
                        else if(cmdCont[1].Equals("right-brow"))
                        {
                            for(int i = 0; i < commands.Count; i++)
                            {
                                if(commands[i] == "right-brow")
                                {
                                    int ind2 = i+2;
                                    caretaker.Style(cmdCont[1], cmdCont[2], ind2);
                                }
                            }
                        }
                        else if(cmdCont[1].Equals("mouth"))
                        {
                            for(int i = 0; i < commands.Count; i++)
                            {
                                if(commands[i] == "mouth")
                                {
                                    int ind2 = i+2;
                                    caretaker.Style(cmdCont[1], cmdCont[2], ind2);
                                }
                            }
                        }
                        break;
                    case "save":
                        //ending the canvas list
                        Memento end = new Memento("</svg>");
                        caretaker.addMemento(end);

                        //create output file
                        caretaker.CreateMomentoSVG(cmdCont[1]);
                        break;
                    case "draw":
                        //clearing console
                        Console.Clear();
                        //printing the svg preview
                        caretaker.printMemento();
                        Console.WriteLine("</svg>");

                        //add space within the console to make it cleaner
                        Console.WriteLine();
                        Console.WriteLine();
                        break;
                    case "undo":
                        caretaker.undo();
                        break;
                    case "redo":
                        caretaker.redo();
                        break; 
                    case "help":
                        //clearing console
                        Console.Clear();
                        //print info about program
                Console.WriteLine(@"
                add	     { left-eye | right-eye | left-brow | right-brow | mouth }
                remove	 { left-eye | right-eye	| left-brow | right-brow | mouth }
                move	 { left-eye | right-eye	| left-brow | right-brow | mouth } { up | down | left | right } value
                rotate	 { left-eye | right-eye	| left-brow | right-brow | mouth } { clockwise | anticlockwise } degrees
                style	 { left-eye | right-eye | left-brow | right-brow | mouth } { A | B | C }
                save	 { <file> }
                draw
                undo
                redo
                help
                quit
                ");break;
                    case "quit":
                        quit = true;break;
                }
            }while (quit != true);
        }
    }
}