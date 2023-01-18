/*
Author: Alex Majka 20429324
System: Windows 11, VSCode 1.73.0
Version 1.0.0
*/

/*
REFERENCES:
*/

using System;
using System.Linq;
using System.IO;
namespace Program
{
    class assignment1
    {
        public static List<string> canvas = new List<string>();
        public static List<string> redoList = new List<string>();
        public static List<string> commands = new List<string>();
        public static void Main(String[]args)
        {
            //Declaring all variables
            string cmdLine,coords,fill,stroke,strokeWidth;
            int x,y,width,height,r,cx,cy,rx,ry,x1,y1,x2,y2,z,n;
            bool quit = false;

            //Adding starting header in the canvas list
            String canvasSize = "<svg viewBox=\"0 0 1920 1080\" xmlns=\"http://www.w3.org/2000/svg\">";
            AddCMD add = new AddCMD(canvasSize, canvas);
            add.Execute();

            //Adding the main face to emoji
            String Ycirc = "<circle cx = \"960\" cy = \"540\" r = \"500\" style = \" fill : yellow ; stroke : black ; stroke-width : 10\" />";
            AddCMD add1 = new AddCMD(Ycirc, canvas);
            add1.Execute();

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
                            AddCMD c0 = new AddCMD(le.printShape(),canvas);
                            c0.Execute();
                            commands.Add("left-eye");
                        }
                        else if(cmdCont[1].Equals("right-eye"))
                        {
                            //creating eye and adding it to canvas
                            Eye re = new Eye(1140,400,50,"black","black", "10");
                            AddCMD c1 = new AddCMD(re.printShape(),canvas);
                            c1.Execute();
                            commands.Add("right-eye");
                        }
                        else if(cmdCont[1].Equals("left-brow"))
                        {
                            //creating brow and adding it to canvas
                            Brow lb = new Brow(730,310,830,310,"black", "15");
                            AddCMD c2 = new AddCMD(lb.printShape(),canvas);
                            c2.Execute();
                            commands.Add("left-brow");
                        }
                        else if(cmdCont[1].Equals("right-brow"))
                        {
                            //creating brow and adding it to canvas
                            Brow rb = new Brow(1090,310,1190,310,"black", "15");
                            AddCMD c3 = new AddCMD(rb.printShape(),canvas);
                            c3.Execute();
                            commands.Add("right-brow");
                        }
                        else if(cmdCont[1].Equals("mouth"))
                        {
                            //creating mouthw and adding it to canvas
                            Brow rb = new Brow(800,750,1120,750,"black", "30");
                            AddCMD c3 = new AddCMD(rb.printShape(),canvas);
                            c3.Execute();
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
                                    RemoveCMD r0 = new RemoveCMD(canvas, redoList, ind);
                                    r0.Execute();
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
                                    RemoveCMD r1 = new RemoveCMD(canvas, redoList, ind);
                                    r1.Execute();
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
                                    RemoveCMD r2 = new RemoveCMD(canvas, redoList, ind);
                                    r2.Execute();
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
                                    RemoveCMD r3 = new RemoveCMD(canvas, redoList, ind);
                                    r3.Execute();
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
                                    RemoveCMD r4 = new RemoveCMD(canvas, redoList, ind);
                                    r4.Execute();
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
                                        MoveUp m0 = new MoveUp(canvas, redoList, "left-eye", int.Parse(cmdCont[3]) ,ind);
                                        m0.Execute();
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
                                        MoveDown m1 = new MoveDown(canvas, redoList, "left-eye", int.Parse(cmdCont[3]) ,ind);
                                        m1.Execute();
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
                                        MoveLeft m2 = new MoveLeft(canvas, redoList, "left-eye", int.Parse(cmdCont[3]) ,ind);
                                        m2.Execute();
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
                                        MoveRight m3 = new MoveRight(canvas, redoList, "left-eye", int.Parse(cmdCont[3]) ,ind);
                                        m3.Execute();
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
                                        MoveUp m4 = new MoveUp(canvas, redoList, "right-eye", int.Parse(cmdCont[3]) ,ind);
                                        m4.Execute();
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
                                        MoveDown m5 = new MoveDown(canvas, redoList, "right-eye", int.Parse(cmdCont[3]) ,ind);
                                        m5.Execute();
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
                                        MoveLeft m6 = new MoveLeft(canvas, redoList, "right-eye", int.Parse(cmdCont[3]) ,ind);
                                        m6.Execute();
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
                                        MoveRight m7 = new MoveRight(canvas, redoList, "right-eye", int.Parse(cmdCont[3]) ,ind);
                                        m7.Execute();
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
                                        MoveUp m8 = new MoveUp(canvas, redoList, "left-brow", int.Parse(cmdCont[3]) ,ind);
                                        m8.Execute();
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
                                        MoveDown m9 = new MoveDown(canvas, redoList, "left-brow", int.Parse(cmdCont[3]) ,ind);
                                        m9.Execute();
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
                                        MoveLeft m10 = new MoveLeft(canvas, redoList, "left-brow", int.Parse(cmdCont[3]) ,ind);
                                        m10.Execute();
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
                                        MoveRight m11 = new MoveRight(canvas, redoList, "left-brow", int.Parse(cmdCont[3]) ,ind);
                                        m11.Execute();
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
                                        MoveUp m12 = new MoveUp(canvas, redoList, "right-brow", int.Parse(cmdCont[3]) ,ind);
                                        m12.Execute();
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
                                        MoveDown m13 = new MoveDown(canvas, redoList, "right-brow", int.Parse(cmdCont[3]) ,ind);
                                        m13.Execute();
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
                                        MoveLeft m14 = new MoveLeft(canvas, redoList, "right-brow", int.Parse(cmdCont[3]) ,ind);
                                        m14.Execute();
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
                                        MoveRight m15 = new MoveRight(canvas, redoList, "right-brow", int.Parse(cmdCont[3]) ,ind);
                                        m15.Execute();
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
                                        MoveUp m16 = new MoveUp(canvas, redoList, "mouth", int.Parse(cmdCont[3]) ,ind);
                                        m16.Execute();
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
                                        MoveDown m17 = new MoveDown(canvas, redoList, "mouth", int.Parse(cmdCont[3]) ,ind);
                                        m17.Execute();
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
                                        MoveLeft m18 = new MoveLeft(canvas, redoList, "mouth", int.Parse(cmdCont[3]) ,ind);
                                        m18.Execute();
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
                                        MoveRight m19 = new MoveRight(canvas, redoList, "mouth", int.Parse(cmdCont[3]) ,ind);
                                        m19.Execute();
                                    }
                                }
                            }
                        }
                        break;
                    case "rotate":
                        if(cmdCont[1].Equals("left-eye"))
                        {
                            if(cmdCont[2].Equals("clockwise"))
                            {

                            }
                            else if(cmdCont[2].Equals("anticlockwise"))
                            {

                            }
                        }
                        else if(cmdCont[1].Equals("right-eye"))
                        {
                            if(cmdCont[2].Equals("clockwise"))
                            {

                            }
                            else if(cmdCont[2].Equals("anticlockwise"))
                            {

                            }
                        }
                        else if(cmdCont[1].Equals("left-brow"))
                        {
                            if(cmdCont[2].Equals("clockwise"))
                            {

                            }
                            else if(cmdCont[2].Equals("anticlockwise"))
                            {

                            }
                        }
                        else if(cmdCont[1].Equals("right-brow"))
                        {
                            if(cmdCont[2].Equals("clockwise"))
                            {

                            }
                            else if(cmdCont[2].Equals("anticlockwise"))
                            {

                            }
                        }
                        else if(cmdCont[1].Equals("mouth"))
                        {
                            if(cmdCont[2].Equals("clockwise"))
                            {

                            }
                            else if(cmdCont[2].Equals("anticlockwise"))
                            {

                            }
                        }
                        break;
                    case "style":
                        if(cmdCont[1].Equals("left-eye"))
                        {
                            if(cmdCont[2].Equals("A"))
                            {

                            }
                            else if(cmdCont[2].Equals("B"))
                            {

                            }
                            else if(cmdCont[2].Equals("C"))
                            {

                            }
                        }
                        else if(cmdCont[1].Equals("right-eye"))
                        {
                            if(cmdCont[2].Equals("A"))
                            {

                            }
                            else if(cmdCont[2].Equals("B"))
                            {

                            }
                            else if(cmdCont[2].Equals("C"))
                            {

                            }
                        }
                        else if(cmdCont[1].Equals("left-brow"))
                        {
                            if(cmdCont[2].Equals("A"))
                            {

                            }
                            else if(cmdCont[2].Equals("B"))
                            {

                            }
                            else if(cmdCont[2].Equals("C"))
                            {

                            }
                        }
                        else if(cmdCont[1].Equals("right-brow"))
                        {
                            if(cmdCont[2].Equals("A"))
                            {

                            }
                            else if(cmdCont[2].Equals("B"))
                            {

                            }
                            else if(cmdCont[2].Equals("C"))
                            {

                            }
                        }
                        else if(cmdCont[1].Equals("mouth"))
                        {
                            if(cmdCont[2].Equals("A"))
                            {

                            }
                            else if(cmdCont[2].Equals("B"))
                            {

                            }
                            else if(cmdCont[2].Equals("C"))
                            {

                            }
                        }
                        break;
                    case "save":
                        //ending the canvas list
                        String canvasEnd = "</svg>";
                        AddCMD addEnd = new AddCMD(canvasEnd, canvas);
                        addEnd.Execute();

                        //create output file
                        CreateSVGCMD createFile = new CreateSVGCMD(canvas,cmdCont[1]);
                        createFile.Execute();
                        break;
                    case "draw":
                        //clearing console
                        Console.Clear();
                        //printing the svg preview
                        PrintSVGCMD cmdDisp = new PrintSVGCMD(canvas);
                        cmdDisp.Execute();
                        Console.WriteLine("</svg>");

                        //add space within the console to make it cleaner
                        Console.WriteLine();
                        Console.WriteLine();
                        break;
                    case "undo":
                        UndoCMD undo = new UndoCMD(canvas, redoList);
                        undo.Execute();
                        break;
                    case "redo":
                        RedoCMD redo = new RedoCMD(canvas, redoList);
                        redo.Execute();
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