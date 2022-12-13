//Using Factory Method
class Factory
{
    public void GenerateShape(string[] cmdCont,List<string> canvas, List<string> redoList/*bool exit*/)
    {
        int x,y,width,height,r,cx,cy,rx,ry,x1,y1,x2,y2,z,n;
        string cmdLine,coords,fill,stroke,strokeWidth;
        switch(cmdCont[0])
        {
            //switch statements on what to do when certain input is made
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
                AddCMD c0 = new AddCMD(cs.printShape(),canvas);
                c0.Execute();
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
                AddCMD c1 = new AddCMD(cs1.printShape(), canvas);
                c1.Execute();
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
                AddCMD c2 = new AddCMD(cs2.printShape(),canvas);
                c2.Execute();
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
                AddCMD c3 = new AddCMD(cs3.printShape(),canvas);
                c3.Execute();
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
                AddCMD c4 = new AddCMD(cs4.printShape(),canvas);
                c4.Execute();
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
                AddCMD c5 = new AddCMD(cs5.printShape(),canvas);
                c5.Execute();
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
                AddCMD c6 = new AddCMD(cs6.printShape(),canvas);
                c6.Execute();
                break;
            case "-undo":
                UndoCMD undo = new UndoCMD(canvas, redoList);
                undo.Execute();
                break;
            case "-redo":
                RedoCMD redo = new RedoCMD(canvas, redoList);
                redo.Execute();
                break; 
            // case "-exit":
            //     exit = true;break;
        }
    }
}