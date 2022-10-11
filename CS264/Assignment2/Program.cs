/*
Author: Alex Majka 20429324
System: Windows 11, VSCode 1.72.2
Version 1.0.0
*/


/*
PLAN:
1. Get user input in a loop
2. put input into a string
3. using a library make that string into a svg file Perhaps ASPOSE?
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
            bool rect = false;
            bool circ = false;
            bool elli = false;
            bool line = false;
            bool pline = false;
            bool poly = false;
            bool path = false;
            string cmdLine,again,coords,fill,stroke,strokeWidth;
            int x,y,width,height,r,cx,cy,rx,ry,x1,y1,x2,y2;

            //print info about program
            Console.WriteLine(@"This app will provide functionality to add shapes to a canvas and export to SVG	
        -rectangle x y width height fill stroke stroke-width           will add a rectangle to the canvas.
        -circle r cx cy fill stroke stroke-width                       will add a circle to the canvas.
        -ellipse rx ry cx cy fill stroke stroke-width                  will add a x to the canvas.
        -line x1 y1 x2 y2 stroke stroke-width                          will add a x to the canvas.
        -polyline x,y_x1,y1...xn_yn fill stroke stroke-width           will add a polyline to the canvas.   !USE UNDERSCORES!
        -polygon x,y_x1,y1...xn_yn fill stroke stroke-width            will add a polygon to the canvas.    !USE UNDERSCORES!
        -path mx1,y1_...xn_yn fill stroke stroke-width                 will add a path to the canvas.       !USE UNDERSCORES!
        ");

            //Getting input in a do while loop
            do
            {
                cmdLine = Console.ReadLine();

                Console.WriteLine("Would you like to insert another line ?(Enter Y for yes /Enter any other key to exit)");
                again = Console.ReadLine();
            } while (again == "Y");
            
            //Splitting the command line input and getting file path
            string[] cmdCont = cmdLine.Split(" ");
            
            //switch statements on what to do when certain input is made
            for(int n = 0; n < cmdCont.Length; n++)
            {
                switch(cmdCont[n])
                {
                    case "-rectangle":
                        rect = true;
                        //int x,y,width,height;
                        x = int.Parse(cmdCont[1]);
                        y = int.Parse(cmdCont[2]);
                        width = int.Parse(cmdCont[3]);
                        height = int.Parse(cmdCont[4]);
                        fill = cmdCont[5];
                        stroke = cmdCont[6];
                        strokeWidth = cmdCont[7];
                        break;
                    case "-circle":
                        circ = true;
                        //int r,cx,cy;
                        r = int.Parse(cmdCont[1]);
                        cx = int.Parse(cmdCont[2]);
                        cy = int.Parse(cmdCont[3]); 
                        fill = cmdCont[4];
                        stroke = cmdCont[5];
                        strokeWidth = cmdCont[6];
                        break;
                    case "-ellipse":
                        elli = true;
                        //int rx,ry,cx,cy;
                        rx = int.Parse(cmdCont[1]);
                        ry = int.Parse(cmdCont[2]);
                        cx = int.Parse(cmdCont[3]);
                        cy = int.Parse(cmdCont[4]);
                        fill = cmdCont[5];
                        stroke = cmdCont[6];
                        strokeWidth = cmdCont[7];
                        break;
                    case "-line":
                        line = true;
                        x1 = int.Parse(cmdCont[1]);
                        y1 = int.Parse(cmdCont[2]);
                        x2 = int.Parse(cmdCont[3]);
                        y2 = int.Parse(cmdCont[4]);
                        stroke = cmdCont[5];
                        strokeWidth = cmdCont[6];
                        break;
                    case "-polyline":
                        pline = true;
                        coords = cmdCont[1];
                        fill = cmdCont[2];
                        stroke = cmdCont[3];
                        strokeWidth = cmdCont[4];
                        break;
                    case "-polygon":
                        poly = true;
                        coords = cmdCont[1];
                        fill = cmdCont[2];
                        stroke = cmdCont[3];
                        strokeWidth = cmdCont[4];
                        break;
                    case "-path":
                        path = true;
                        coords = cmdCont[1];
                        fill = cmdCont[2];
                        stroke = cmdCont[3];
                        strokeWidth = cmdCont[4];
                        break;
                }
            }
        }
    }
}