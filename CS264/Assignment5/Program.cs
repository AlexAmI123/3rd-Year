/*
Author: Alex Majka 20429324
System: Windows 11, VSCode 1.73.1
Version 1.0.0


METHOD USED: FACTORY METHOD
THIS IS ASSIGNMENT 4 EDITED AS ASSIGNMENT 5 (COMMAND PATTERN)
*/

/*
REFERENCES:
https://www.newthinktank.com/2012/09/command-design-pattern-tutorial/
https://refactoring.guru/design-patterns/command/csharp/example
John Keating's week 9 demo files for Factory Design
*/

using System;
using System.Linq;
using System.IO;
namespace Program
{
    class assignment5
    {
        //public static Caretaker caretaker = new Caretaker();
        public static List<string> canvas = new List<string>();
        public static List<string> redoList = new List<string>();
        public static string cmdLine;
        public static bool exit = false;
        public static void Main(String[]args)
        {
            //Declaring all variables
            //List<string> canvas = new List<string>();
            string cmdLine,coords,fill,stroke,strokeWidth;
            int x,y,width,height,r,cx,cy,rx,ry,x1,y1,x2,y2,z,n;

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
                                                        This app will provide functionality to add shapes to a canvas and export to SVG	
                
                -rectangle x y width height fill stroke stroke-width           will add a rectangle to the canvas.
                -circle r cx cy fill stroke stroke-width                       will add a circle to the canvas.
                -ellipse rx ry cx cy fill stroke stroke-width                  will add a x to the canvas.
                -line x1 y1 x2 y2 stroke stroke-width                          will add a x to the canvas.
                -polyline x,y_x1,y1...xn_yn fill stroke stroke-width           will add a polyline to the canvas.   !USE UNDERSCORES!
                -polygon x,y_x1,y1...xn_yn fill stroke stroke-width            will add a polygon to the canvas.    !USE UNDERSCORES!
                -path mx1,y1_...xn_yn fill stroke stroke-width                 will add a path to the canvas.       !USE UNDERSCORES!
                -undo                                                          Will undo to the previous state.
                -redo                                                          Will redo the last step that was undone.
                -exit                                                          Will stop taking input and export to .SVG file.

                                                        ALL STYLING INPUTS ARE OPTIONAL, IF NOT USED, THE DEFAULTS ARE GREY, BLACK AND 5.
                                                        Also to add a random sized & placed shape, do -<shape command> r e.g
                                                        Random size command works for all shapes except path, polygon and polyline.
                                                        E.g -rectangle r
                ");

                //read in next line
                cmdLine = Console.ReadLine();

                //Splitting the command line input and getting file path
                string[] cmdCont = cmdLine.Split(" ");

                //initiate factory and generate shape
                Factory factory = new Factory();
                if(cmdCont[0]!= "-exit")
                {
                    factory.GenerateShape(cmdCont,canvas,redoList);
                }
                else
                {
                    exit = true;
                }
                // Factory factory = new Factory();
                // factory.GenerateShape(cmdCont,canvas,redoList),exit;
            }while (exit != true);

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