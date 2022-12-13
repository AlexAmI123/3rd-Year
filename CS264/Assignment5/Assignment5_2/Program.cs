/*
Author: Alex Majka 20429324
System: Windows 11, VSCode 1.72.2
Version 1.0.0


METHOD USED: FACTORY METHOD
THIS IS ASSIGNMENT 2 EDITED AS ASSIGNMENT 5 (COMMAND PATTERN)
*/

/*
REFERENCES:
https://www.newthinktank.com/2012/09/command-design-pattern-tutorial/
https://refactoring.guru/design-patterns/command/csharp/example
John Keating's week 9 demo files for Factory Design
*/


using System;
using System.IO;
namespace Program
{
    class assignment1
    {
        public static void Main(String[]args)
        {
            //Declaring all variables
            List<string> canvas = new List<string>();
            List<string> cmdLog = new List<string>();
            string cmdLine,coords,fill,stroke,strokeWidth;
            int x,y,width,height,r,cx,cy,rx,ry,x1,y1,x2,y2,z,n;
            bool exit = false;

            //Adding starting header in the canvas list
            canvas.Add("<svg viewBox=\"0 0 1920 1080\" xmlns=\"http://www.w3.org/2000/svg\">");

            //Getting input in a do while loop
            do
            {
                //clear console to make it look cleaner
                Console.Clear();
                
                //print contents of canvas so far
                Console.WriteLine(@"
                                                        THIS IS YOUR SVG PREVIEW :)");
                Console.WriteLine();
                foreach(string s in canvas)
                {
                    Console.WriteLine(s);
                }
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
                -editZ z n                                                     will edit the z value of nth shape added, z is desired z value.
                -delete n                                                      will delete the nth shape, if you want to delete random, type r instead of n.
                -update shape n xyz                                            will update shape of given type, the shape is the nth shape input
                                                                               add parameters for corresponding shape you wish to have.
                                                                               If the z indexes before n were changed, this will affect the n value.
                                                                               It is the same as the Z index.
                -exit                                                          will stop taking input. And export to .SVG file.

                                                        ALL STYLING INPUTS ARE OPTIONAL, IF NOT USED, THE DEFAULTS ARE GREY, BLACK AND 5.
                ");


                //read in next line
                cmdLine = Console.ReadLine();

                //Splitting the command line input and getting file path
                string[] cmdCont = cmdLine.Split(" ");
                
                //initiate factory and generate shape
                Factory factory = new Factory();
                if(cmdCont[0]!= "-exit")
                {
                    factory.GenerateShape(cmdCont,canvas);
                }
                else
                {
                    exit = true;
                }
                // Factory factory = new Factory();
                // factory.GenerateShape(cmdCont,canvas,redoList),exit;
            }while (exit != true);
            //ending the canvas list
            canvas.Add("</svg>");

            //create output file
            CreateSVG cf = new CreateSVG(canvas);

            
        }
    }
}