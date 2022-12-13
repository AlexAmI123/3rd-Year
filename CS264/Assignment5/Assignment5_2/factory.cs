//Using Factory Method
class Factory
{
    public void GenerateShape(string[] cmdCont,List<string> canvas/*bool exit*/)
    {
        int x,y,width,height,r,cx,cy,rx,ry,x1,y1,x2,y2,z,n;
        string cmdLine,coords,fill,stroke,strokeWidth;
        switch(cmdCont[0])
        {
            case "-rectangle":
                //assigning values
                x = int.Parse(cmdCont[1]);
                y = int.Parse(cmdCont[2]);
                width = int.Parse(cmdCont[3]);
                height = int.Parse(cmdCont[4]);
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
                canvas.Add(cs.printShape());
                break;
            case "-circle":
                //assigning values
                r = int.Parse(cmdCont[1]);
                cx = int.Parse(cmdCont[2]);
                cy = int.Parse(cmdCont[3]); 
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
                canvas.Add(cs1.printShape());
                break;
            case "-ellipse":
                //assigning values
                rx = int.Parse(cmdCont[1]);
                ry = int.Parse(cmdCont[2]);
                cx = int.Parse(cmdCont[3]);
                cy = int.Parse(cmdCont[4]);
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
                canvas.Add(cs2.printShape());
                break;
            case "-line":
                //assigning values
                x1 = int.Parse(cmdCont[1]);
                y1 = int.Parse(cmdCont[2]);
                x2 = int.Parse(cmdCont[3]);
                y2 = int.Parse(cmdCont[4]);
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
                canvas.Add(cs3.printShape());
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
                canvas.Add(cs4.printShape());
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
                canvas.Add(cs5.printShape());
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
                canvas.Add(cs6.printShape());
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
            case "-update":
                switch(cmdCont[1])
                {
                    case "rectangle":
                    //assigning values
                    n = int.Parse(cmdCont[2]);
                    x = int.Parse(cmdCont[3]);
                    y = int.Parse(cmdCont[4]);
                    width = int.Parse(cmdCont[5]);
                    height = int.Parse(cmdCont[6]);
                    //if statements to see whether there should be default or user generated styling
                    if(cmdCont.Length > 7)
                    {
                        fill = cmdCont[7];
                    }
                    else
                    {
                        fill = "grey";
                    }
                    if(cmdCont.Length > 8)
                    {
                        stroke = cmdCont[8];
                    }
                    else
                    {
                        stroke = "black";
                    }
                    if(cmdCont.Length > 9)
                    {
                        strokeWidth = cmdCont[9];
                    }
                    else
                    {
                        strokeWidth = "5";
                    }
                    //creating shape and adding it to canvas back where it belongs.
                    Rectangle cs7 = new Rectangle(x,y,width,height,fill,stroke,strokeWidth);
                    canvas.RemoveAt(n);
                    canvas.Insert(n,cs7.printShape());
                    break;
                    
                    case "circle":
                    //assigning values
                    n = int.Parse(cmdCont[2]);
                    r = int.Parse(cmdCont[3]);
                    cx = int.Parse(cmdCont[4]);
                    cy = int.Parse(cmdCont[5]); 
                    //if statements to see whether there should be default or user generated styling
                    if(cmdCont.Length > 6)
                    {
                        fill = cmdCont[6];
                    }
                    else
                    {
                        fill = "grey";
                    }
                    if(cmdCont.Length > 7)
                    {
                        stroke = cmdCont[7];
                    }
                    else
                    {
                        stroke = "black";
                    }
                    if(cmdCont.Length > 8)
                    {
                        strokeWidth = cmdCont[8];
                    }
                    else
                    {
                        strokeWidth = "5";
                    }
                    //creating shape and adding it to canvas back where it belongs.
                    Circle cs8 = new Circle(cx,cy,r,fill,stroke,strokeWidth);
                    canvas.RemoveAt(n);
                    canvas.Insert(n,cs8.printShape());
                    break;
                    
                    case "ellipse":
                    //assigning values
                    n = int.Parse(cmdCont[2]);
                    rx = int.Parse(cmdCont[3]);
                    ry = int.Parse(cmdCont[4]);
                    cx = int.Parse(cmdCont[5]);
                    cy = int.Parse(cmdCont[6]);
                    //if statements to see whether there should be default or user generated styling
                    if(cmdCont.Length > 7)
                    {
                        fill = cmdCont[7];
                    }
                    else
                    {
                        fill = "grey";
                    }
                    if(cmdCont.Length > 8)
                    {
                        stroke = cmdCont[8];
                    }
                    else
                    {
                        stroke = "black";
                    }
                    if(cmdCont.Length > 9)
                    {
                        strokeWidth = cmdCont[9];
                    }
                    else
                    {
                        strokeWidth = "5";
                    }
                    //creating shape and adding it to canvas back where it belongs.
                    Ellipse cs9 = new Ellipse(rx,ry,cx,cy,fill,stroke,strokeWidth);
                    canvas.Insert(n,cs9.printShape());
                    break;
                    
                    case "line":
                    //assigning values
                    n = int.Parse(cmdCont[2]);
                    x1 = int.Parse(cmdCont[3]);
                    y1 = int.Parse(cmdCont[4]);
                    x2 = int.Parse(cmdCont[5]);
                    y2 = int.Parse(cmdCont[6]);
                    //if statements to see whether there should be default or user generated styling
                    if(cmdCont.Length > 7)
                    {
                        stroke = cmdCont[7];
                    }
                    else
                    {
                        stroke = "black";
                    }
                    if(cmdCont.Length > 8)
                    {
                        strokeWidth = cmdCont[8];
                    }
                    else
                    {
                        strokeWidth = "5";
                    }
                    //creating shape and adding it to canvas back where it belongs.
                    Line cs10 = new Line(x1,y1,x2,y2,stroke,strokeWidth);
                    canvas.RemoveAt(n);
                    canvas.Insert(n,cs10.printShape());
                    break;
                    
                    case "polyline":
                    //assigning values
                    n = int.Parse(cmdCont[2]);
                    coords = cmdCont[3];
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
                    //creating shape and adding it to canvas back where it belongs.
                    Polyline cs11 = new Polyline(coords,fill,stroke,strokeWidth);
                    canvas.Insert(n,cs11.printShape());
                    break;

                    case "polygon":
                    //assigning values
                    n = int.Parse(cmdCont[2]);
                    coords = cmdCont[3];
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
                    //creating shape and adding it to canvas back where it belongs.
                    Polygon cs12 = new Polygon(coords,fill,stroke,strokeWidth);
                    canvas.RemoveAt(n);
                    canvas.Insert(n,cs12.printShape());
                    break;

                    case "path":
                    //assigning values
                    n = int.Parse(cmdCont[2]);
                    coords = cmdCont[3];
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
                    //creating shape and adding it to canvas back where it belongs.
                    Path cs13 = new Path(coords,fill,stroke,strokeWidth);
                    canvas.RemoveAt(n);
                    canvas.Insert(n,cs13.printShape());
                    break;
                }
            break;  
            // case "-exit":
            //     exit = true;break;
        }
    }
}