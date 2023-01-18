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

            //Getting input in a do while loop
            do
            {
                //printing the svg preview
                PrintSVGCMD cmdDisp = new PrintSVGCMD(canvas);
                cmdDisp.Execute();
                Console.WriteLine("</svg>");

                //add space within the console to make it cleaner
                Console.WriteLine();
                Console.WriteLine();
                
                //print info about program
                Console.WriteLine(@"
                add	     { left-eye | right-eye	| left-brow	| right-brow | mouth }
	            remove	 { left-eye | right-eye	| left-brow	| right-brow | mouth }
	            move	 { left-eye | right-eye	| left-brow	| right-brow | mouth } { up | down	| left | right }	value
                rotate	 { left-eye | right-eye	| left-brow	| right-brow | mouth } { clockwise | anticlockwise } degrees
                style	 { left-eye | right-eye | left-brow | right-brow | mouth } { A | B | C }
                save	 { <file> }
                draw
                undo
                redo
                help
                quit
                ");


                //read in next line
                cmdLine = Console.ReadLine();

                //Splitting the command line input and getting file path
                string[] cmdCont = cmdLine.Split(" ");
                
                //switch statements on what to do when certain input is made
                for(int j = 0; j < cmdCont.Length; j++)
                {
                    switch(cmdCont[j])
                    {
                        case "add":
                            if(cmdCont[2] == "{ left-eye }")
                            String canvasEnd1 = "</svg>";
                            AddCMD addEnd1 = new AddCMD(canvasEnd1, canvas);
                            break;
                        case "remove":
                            break;
                        case "move":
                            break;
                        case "rotate":
                            break;
                        case "style":
                            break;
                        case "save":
                            break;
                        case "draw":
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
                            Console.WriteLine(@"
                add	     {	left-eye	|		right-eye	|	left-brow	|	right-brow	|	mouth	}
	            remove	 {	left-eye	|		right-eye	|	left-brow	|	right-brow	|	mouth	}
	            move	 {	left-eye	|		right-eye	|	left-brow	|	right-brow	|	mouth	}	{up	|	down	|	left	|	right	}	value
                rotate	 {	left-eye	|		right-eye	|	left-brow	|	right-brow	|	mouth	}	{	clockwise	|	anticlockwise	}	degrees
                style	 {left-eye|right-eye|left-brow|right-brow|mouth} {A|B|C}
                save	 {<file>}
                draw
                undo
                redo
                help
                quit
                ");break;
                        case "quit":
                            quit = true;break;
                    }
                }
            }while (quit != true);
            //ending the canvas list
            String canvasEnd = "</svg>";
            AddCMD addEnd = new AddCMD(canvasEnd, canvas);
            addEnd.Execute();

            //create output file
            CreateSVGCMD createFile = new CreateSVGCMD(canvas);
            createFile.Execute();
        }
    }
}