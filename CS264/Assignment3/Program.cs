﻿/*
Author: Alex Majka 20429324
System: Windows 11, VSCode 1.72.2
Version 1.0.0
*/

using System;
using System.Linq;
using System.IO;
namespace Program
{
    class assignment3
    {
        public static Caretaker caretaker = new Caretaker();
        public static void Main(String[]args)
        {
            //Declaring all variables
            List<string> canvas = new List<string>();
            //List<string> cmdLog = new List<string>();
            string cmdLine,coords,fill,stroke,strokeWidth;
            int x,y,width,height,r,cx,cy,rx,ry,x1,y1,x2,y2,z,n;
            bool exit = false;

            //Adding starting header in the canvas list
            //canvas.Add("<svg viewBox=\"0 0 1920 1080\" xmlns=\"http://www.w3.org/2000/svg\">");
            //Originator originator = new Originator("<svg viewBox=\"0 0 1920 1080\" xmlns=\"http://www.w3.org/2000/svg\">");
            //Caretaker caretaker = new Caretaker(originator);

            // public Caretaker caretaker = new Caretaker();
            Memento canvasSize = new Memento("<svg viewBox=\"0 0 1920 1080\" xmlns=\"http://www.w3.org/2000/svg\">");
            caretaker.addMemento(canvasSize);


            //Getting input in a do while loop
            do
            {
                caretaker.printMemento();
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
                -undo                                                          Will undo to the previous state.
                -redo                                                          Will redo the last step that was undone.
                -exit                                                          Will stop taking input and export to .SVG file.

                                                        ALL STYLING INPUTS ARE OPTIONAL, IF NOT USED, THE DEFAULTS ARE GREY, BLACK AND 5.
                                                                Also to add a random sized & placed shape, do -<shape command> r
                                                                This command works for all except path, polygon and polyline.
                                                                E.g -rectangle r
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
                        case "-rectangle":
                            //assigning values
                            if(cmdCont.Length >= 4)
                            {
                                x = int.Parse(cmdCont[1]);
                                y = int.Parse(cmdCont[2]);
                                width = int.Parse(cmdCont[3]);
                                height = int.Parse(cmdCont[4]);
                            }
                            else
                            {
                                Random rd = new Random();
                                x = rd.Next(0,1920);
                                y = rd.Next(0,1080);
                                width = rd.Next(1,1600);
                                height = rd.Next(1,800);;
                            }    
                            //if statements to see whether there should be default or user generated styling
                            if(cmdCont.Length > 5)
                            {
                                fill = cmdCont[5];
                            }
                            else
                            {
                                fill = "grey";
                            }
                            if(cmdCont.Length > 6)
                            {
                                stroke = cmdCont[6];
                            }
                            else
                            {
                                stroke = "black";
                            }
                            if(cmdCont.Length > 7)
                            {
                                strokeWidth = cmdCont[7];
                            }
                            else
                            {
                                strokeWidth = "5";
                            }
                            //creating shape and adding it to canvas
                            Rectangle cs = new Rectangle(x,y,width,height,fill,stroke,strokeWidth);
                            //canvas.Add(cs.printShape());
                            cs.printShape(caretaker);
                            break;
                        case "-circle":
                            //assigning values
                            if(cmdCont.Length >=3)
                            {
                                r = int.Parse(cmdCont[1]);
                                cx = int.Parse(cmdCont[2]);
                                cy = int.Parse(cmdCont[3]); 
                            }
                            else
                            {
                                Random rd = new Random();
                                r = rd.Next(1,1600);
                                cx = rd.Next(1,1920);
                                cy = rd.Next(1,1080); 
                            }
                            //if statements to see whether there should be default or user generated styling
                            if(cmdCont.Length > 4)
                            {
                                fill = cmdCont[4];
                            }
                            else
                            {
                                fill = "grey";
                            }
                            if(cmdCont.Length > 5)
                            {
                                stroke = cmdCont[5];
                            }
                            else
                            {
                                stroke = "black";
                            }
                            if(cmdCont.Length > 6)
                            {
                                strokeWidth = cmdCont[6];
                            }
                            else
                            {
                                strokeWidth = "5";
                            }
                            //creating shape and adding it to canvas
                            Circle cs1 = new Circle(cx,cy,r,fill,stroke,strokeWidth);
                            // canvas.Add(cs1.printShape());
                            cs1.printShape(caretaker);
                            break;
                        case "-ellipse":
                            //assigning values
                            if(cmdCont.Length >= 4)
                            {
                                rx = int.Parse(cmdCont[1]);
                                ry = int.Parse(cmdCont[2]);
                                cx = int.Parse(cmdCont[3]);
                                cy = int.Parse(cmdCont[4]);
                            }
                            else
                            {
                                Random rd = new Random();
                                rx = rd.Next(1,1600);
                                ry = rd.Next(1,800);
                                cx = rd.Next(0,1920);
                                cy = rd.Next(0,1080);
                            }
                            //if statements to see whether there should be default or user generated styling
                            if(cmdCont.Length > 5)
                            {
                                fill = cmdCont[5];
                            }
                            else
                            {
                                fill = "grey";
                            }
                            if(cmdCont.Length > 6)
                            {
                                stroke = cmdCont[6];
                            }
                            else
                            {
                                stroke = "black";
                            }
                            if(cmdCont.Length > 7)
                            {
                                strokeWidth = cmdCont[7];
                            }
                            else
                            {
                                strokeWidth = "5";
                            }
                            //creating shape and adding it to canvas
                            Ellipse cs2 = new Ellipse(rx,ry,cx,cy,fill,stroke,strokeWidth);
                            //canvas.Add(cs2.printShape());
                            cs2.printShape(caretaker);
                            break;
                        case "-line":
                            //assigning values
                            if(cmdCont.Length >=4)
                            {
                                x1 = int.Parse(cmdCont[1]);
                                y1 = int.Parse(cmdCont[2]);
                                x2 = int.Parse(cmdCont[3]);
                                y2 = int.Parse(cmdCont[4]);
                            }
                            else
                            {
                                Random rd = new Random();
                                x1 = rd.Next(0,1920);
                                y1 = rd.Next(0,1080);
                                x2 = rd.Next(0,1920);
                                y2 = rd.Next(0,1080);
                            }
                            //if statements to see whether there should be default or user generated styling
                            if(cmdCont.Length > 5)
                            {
                                stroke = cmdCont[5];
                            }
                            else
                            {
                                stroke = "black";
                            }
                            if(cmdCont.Length > 6)
                            {
                                strokeWidth = cmdCont[6];
                            }
                            else
                            {
                                strokeWidth = "5";
                            }
                            //creating shape and adding it to canvas
                            Line cs3 = new Line(x1,y1,x2,y2,stroke,strokeWidth);
                            //canvas.Add(cs3.printShape());
                            cs3.printShape(caretaker);
                            break;
                        case "-polyline":
                            //assigning values
                            coords = cmdCont[1];
                            //if statements to see whether there should be default or user generated styling
                            if(cmdCont.Length > 2)
                            {
                                fill = cmdCont[2];
                            }
                            else
                            {
                                fill = "grey";
                            }
                            if(cmdCont.Length > 3)
                            {
                                stroke = cmdCont[3];
                            }
                            else
                            {
                                stroke = "black";
                            }
                            if(cmdCont.Length > 4)
                            {
                                strokeWidth = cmdCont[4];
                            }
                            else
                            {
                                strokeWidth = "5";
                            }
                            //creating shape and adding it to canvas
                            Polyline cs4 = new Polyline(coords,fill,stroke,strokeWidth);
                            //canvas.Add(cs4.printShape());
                            cs4.printShape(caretaker);
                            break;
                        case "-polygon":
                            //assigning values
                            coords = cmdCont[1];
                            //if statements to see whether there should be default or user generated styling
                            if(cmdCont.Length > 2)
                            {
                                fill = cmdCont[2];
                            }
                            else
                            {
                                fill = "grey";
                            }
                            if(cmdCont.Length > 3)
                            {
                                stroke = cmdCont[3];
                            }
                            else
                            {
                                stroke = "black";
                            }
                            if(cmdCont.Length > 4)
                            {
                                strokeWidth = cmdCont[4];
                            }
                            else
                            {
                                strokeWidth = "5";
                            }
                            //creating shape and adding it to canvas
                            Polygon cs5 = new Polygon(coords,fill,stroke,strokeWidth);
                            //canvas.Add(cs5.printShape());
                            cs5.printShape(caretaker);
                            break;
                        case "-path":
                            //assigning values
                            coords = cmdCont[1];   
                            //if statements to see whether there should be default or user generated styling
                            if(cmdCont.Length > 2)
                            {
                                fill = cmdCont[2];
                            }
                            else
                            {
                                fill = "grey";
                            }
                            if(cmdCont.Length > 3)
                            {
                                stroke = cmdCont[3];
                            }
                            else
                            {
                                stroke = "black";
                            }
                            if(cmdCont.Length > 4)
                            {
                                strokeWidth = cmdCont[4];
                            }
                            else
                            {
                                strokeWidth = "5";
                            }
                            //creating shape and adding it to canvas
                            Path cs6 = new Path(coords,fill,stroke,strokeWidth);
                            //canvas.Add(cs6.printShape());
                            cs6.printShape(caretaker);
                            break;
                        case "-editZ":
                            //assigning values
                            z = int.Parse(cmdCont[1]);
                            n = int.Parse(cmdCont[2]);
                            //editing shape z index and adding it to canvas
                            //make temp string
                            string temp = canvas.ElementAt(n);
                            //removing the temp string
                            canvas.RemoveAt(n);
                            //adding temp string at desired z index
                            canvas.Insert(z,temp);
                            break;
                        case "-delete":
                            //if deleting random, get random and removeat
                            if(cmdCont[1] == "r")
                            {
                                Random rd = new Random();
                                n = rd.Next(1,canvas.Count);
                                canvas.RemoveAt(n);
                            }
                            //else remove at n
                            else
                            {
                                n = int.Parse(cmdCont[1]);
                                canvas.RemoveAt(n);
                            }
                            break;
                        // case "-update":
                        //     switch(cmdCont[1])
                        //     {
                        //         case "rectangle":
                        //         //assigning values
                        //         n = int.Parse(cmdCont[2]);
                        //         x = int.Parse(cmdCont[3]);
                        //         y = int.Parse(cmdCont[4]);
                        //         width = int.Parse(cmdCont[5]);
                        //         height = int.Parse(cmdCont[6]);
                        //         //if statements to see whether there should be default or user generated styling
                        //         if(cmdCont.Length > 7)
                        //         {
                        //             fill = cmdCont[7];
                        //         }
                        //         else
                        //         {
                        //             fill = "grey";
                        //         }
                        //         if(cmdCont.Length > 8)
                        //         {
                        //             stroke = cmdCont[8];
                        //         }
                        //         else
                        //         {
                        //             stroke = "black";
                        //         }
                        //         if(cmdCont.Length > 9)
                        //         {
                        //             strokeWidth = cmdCont[9];
                        //         }
                        //         else
                        //         {
                        //             strokeWidth = "5";
                        //         }
                        //         //creating shape and adding it to canvas back where it belongs.
                        //         Rectangle cs7 = new Rectangle(x,y,width,height,fill,stroke,strokeWidth);
                        //         canvas.RemoveAt(n);
                        //         canvas.Insert(n,cs7.printShape());
                        //         break;
                                
                        //         case "circle":
                        //         //assigning values
                        //         n = int.Parse(cmdCont[2]);
                        //         r = int.Parse(cmdCont[3]);
                        //         cx = int.Parse(cmdCont[4]);
                        //         cy = int.Parse(cmdCont[5]); 
                        //         //if statements to see whether there should be default or user generated styling
                        //         if(cmdCont.Length > 6)
                        //         {
                        //             fill = cmdCont[6];
                        //         }
                        //         else
                        //         {
                        //             fill = "grey";
                        //         }
                        //         if(cmdCont.Length > 7)
                        //         {
                        //             stroke = cmdCont[7];
                        //         }
                        //         else
                        //         {
                        //             stroke = "black";
                        //         }
                        //         if(cmdCont.Length > 8)
                        //         {
                        //             strokeWidth = cmdCont[8];
                        //         }
                        //         else
                        //         {
                        //             strokeWidth = "5";
                        //         }
                        //         //creating shape and adding it to canvas back where it belongs.
                        //         Circle cs8 = new Circle(cx,cy,r,fill,stroke,strokeWidth);
                        //         canvas.RemoveAt(n);
                        //         // canvas.Insert(n,cs8.printShape());
                        //         break;
                                
                        //         case "ellipse":
                        //         //assigning values
                        //         n = int.Parse(cmdCont[2]);
                        //         rx = int.Parse(cmdCont[3]);
                        //         ry = int.Parse(cmdCont[4]);
                        //         cx = int.Parse(cmdCont[5]);
                        //         cy = int.Parse(cmdCont[6]);
                        //         //if statements to see whether there should be default or user generated styling
                        //         if(cmdCont.Length > 7)
                        //         {
                        //             fill = cmdCont[7];
                        //         }
                        //         else
                        //         {
                        //             fill = "grey";
                        //         }
                        //         if(cmdCont.Length > 8)
                        //         {
                        //             stroke = cmdCont[8];
                        //         }
                        //         else
                        //         {
                        //             stroke = "black";
                        //         }
                        //         if(cmdCont.Length > 9)
                        //         {
                        //             strokeWidth = cmdCont[9];
                        //         }
                        //         else
                        //         {
                        //             strokeWidth = "5";
                        //         }
                        //         //creating shape and adding it to canvas back where it belongs.
                        //         Ellipse cs9 = new Ellipse(rx,ry,cx,cy,fill,stroke,strokeWidth);
                        //         //canvas.Insert(n,cs9.printShape());
                        //         break;
                                
                        //         case "line":
                        //         //assigning values
                        //         n = int.Parse(cmdCont[2]);
                        //         x1 = int.Parse(cmdCont[3]);
                        //         y1 = int.Parse(cmdCont[4]);
                        //         x2 = int.Parse(cmdCont[5]);
                        //         y2 = int.Parse(cmdCont[6]);
                        //         //if statements to see whether there should be default or user generated styling
                        //         if(cmdCont.Length > 7)
                        //         {
                        //             stroke = cmdCont[7];
                        //         }
                        //         else
                        //         {
                        //             stroke = "black";
                        //         }
                        //         if(cmdCont.Length > 8)
                        //         {
                        //             strokeWidth = cmdCont[8];
                        //         }
                        //         else
                        //         {
                        //             strokeWidth = "5";
                        //         }
                        //         //creating shape and adding it to canvas back where it belongs.
                        //         Line cs10 = new Line(x1,y1,x2,y2,stroke,strokeWidth);
                        //         canvas.RemoveAt(n);
                        //         canvas.Insert(n,cs10.printShape());
                        //         break;
                                
                        //         case "polyline":
                        //         //assigning values
                        //         n = int.Parse(cmdCont[2]);
                        //         coords = cmdCont[3];
                        //         //if statements to see whether there should be default or user generated styling
                        //         if(cmdCont.Length > 4)
                        //         {
                        //             fill = cmdCont[4];
                        //         }
                        //         else
                        //         {
                        //             fill = "grey";
                        //         }
                        //         if(cmdCont.Length > 5)
                        //         {
                        //             stroke = cmdCont[5];
                        //         }
                        //         else
                        //         {
                        //             stroke = "black";
                        //         }
                        //         if(cmdCont.Length > 6)
                        //         {
                        //             strokeWidth = cmdCont[6];
                        //         }
                        //         else
                        //         {
                        //             strokeWidth = "5";
                        //         }
                        //         //creating shape and adding it to canvas back where it belongs.
                        //         Polyline cs11 = new Polyline(coords,fill,stroke,strokeWidth);
                        //         canvas.Insert(n,cs11.printShape());
                        //         break;

                        //         case "polygon":
                        //         //assigning values
                        //         n = int.Parse(cmdCont[2]);
                        //         coords = cmdCont[3];
                        //         //if statements to see whether there should be default or user generated styling
                        //         if(cmdCont.Length > 4)
                        //         {
                        //             fill = cmdCont[4];
                        //         }
                        //         else
                        //         {
                        //             fill = "grey";
                        //         }
                        //         if(cmdCont.Length > 5)
                        //         {
                        //             stroke = cmdCont[5];
                        //         }
                        //         else
                        //         {
                        //             stroke = "black";
                        //         }
                        //         if(cmdCont.Length > 6)
                        //         {
                        //             strokeWidth = cmdCont[6];
                        //         }
                        //         else
                        //         {
                        //             strokeWidth = "5";
                        //         }
                        //         //creating shape and adding it to canvas back where it belongs.
                        //         Polygon cs12 = new Polygon(coords,fill,stroke,strokeWidth);
                        //         canvas.RemoveAt(n);
                        //         canvas.Insert(n,cs12.printShape());
                        //         break;

                        //         case "path":
                        //         //assigning values
                        //         n = int.Parse(cmdCont[2]);
                        //         coords = cmdCont[3];
                        //         //if statements to see whether there should be default or user generated styling
                        //         if(cmdCont.Length > 4)
                        //         {
                        //             fill = cmdCont[4];
                        //         }
                        //         else
                        //         {
                        //             fill = "grey";
                        //         }
                        //         if(cmdCont.Length > 5)
                        //         {
                        //             stroke = cmdCont[5];
                        //         }
                        //         else
                        //         {
                        //             stroke = "black";
                        //         }
                        //         if(cmdCont.Length > 6)
                        //         {
                        //             strokeWidth = cmdCont[6];
                        //         }
                        //         else
                        //         {
                        //             strokeWidth = "5";
                        //         }
                        //         //creating shape and adding it to canvas back where it belongs.
                        //         Path cs13 = new Path(coords,fill,stroke,strokeWidth);
                        //         canvas.RemoveAt(n);
                        //         canvas.Insert(n,cs13.printShape());
                        //         break;
                        //     }
                        break; 
                        case "-undo":
                            break;
                        case "-redo":
                            break; 
                        case "-exit":
                            exit = true;break;
                    }
                }
            }while (exit != true);
            //ending the canvas list
            Memento canvasEnd = new Memento("</svg>");
            caretaker.addMemento(canvasEnd);

            //create output file
            CreateSVG cf = new CreateSVG(canvas);
        }
    }
}