/*
Author: Alex Majka 20429324
System: Windows 11, VSCode 1.72.2
*/
using System;
using System.IO;
// using Assignment1;

namespace Program
{
    class assignment1
    {
        public static void Main(String[]args)
        {
            //Declaring all necessary Elements
            string cmdLine, inputPath, outputFile;
            bool v = false;
            bool i = false;
            bool o = false;
            bool h = false;
            bool l = false;

            //Getting input
            cmdLine = Console.ReadLine();
            
            //Splitting the command line input and getting file path
            string[] cmdCont = cmdLine.Split(" ");
            outputFile = cmdCont[cmdCont.Length-1];
            inputPath = @"C:\test\" + cmdCont[cmdCont.Length-1];

            //if tabconv
            if(cmdCont[0] == "tabconv")
            {
                v = false;
                i = false;
                o = false;
                h = false;
                l = false;
            }

            //switch to choose from options
            for(int n = 0; n < cmdCont.Length; n++)
            {
                switch(cmdCont[n])
                {
                    case "-v":
                        v = true;break;
                    case "-i":
                        i = true;break;
                    case "-o":
                        o = true;break;
                    case "-h":
                        h = true;break;
                    case "-l":
                        l = true;break;
                }
            }

            //creating Table Converter to convert the file
            var converter = new Tabconv(inputPath, outputFile, v, i, o, h, l);
        }
    }
}