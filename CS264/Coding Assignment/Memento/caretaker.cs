public class Caretaker
{
    //Mementos for history and redo list
    List<Memento> history = new List<Memento>();
    //When something is undone, add to this list of undone things
    List<Memento> redoList = new List<Memento>();

    //add memento to history
    public void addMemento(Memento shape)
    {
        history.Add(shape);
    }
    //undo last action
    public void undo()
    {
        int i = history.Count() - 1;
        Memento temp = history[i];
        redoList.Add(temp);
        history.RemoveAt(i);
    }
    //redo action that was undone
    public void redo()
    {
        int i = redoList.Count() - 1;
        Memento temp = redoList[i];
        history.Add(temp);
        redoList.RemoveAt(i);
    }
    //memento preview
    public void printMemento()
    {
        //clear console to make it look cleaner
        Console.Clear();

        //print contents of canvas so far
        Console.WriteLine();
        Console.WriteLine();

        for (int i = 0; i < history.Count(); i++)
        {
            Console.WriteLine($"{history[i].ToString()}");
        }
    }
    //create .svg file from Memento
    public void CreateMomentoSVG(string name)
    {
        using (StreamWriter sw = File.CreateText(name))
        {
            for (int i = 0; i < history.Count(); i++)
            {
                sw.WriteLine($"{history[i].ToString()}");
            }
        }
    }
    //Remove 
    public void Remove(int ind)
    {
        var temp = history[ind];
        redoList.Add(temp);
        history.RemoveAt(ind);
    }
    //moveup
    public void MoveUp(string type, int val, int ind)
    {
        Memento temp = history[ind];
        string temp2 ="";
        redoList.Add(temp);

        int len = temp.ToString().Length-2;
        string t = temp.ToString();
        temp2 = t[0..len];
        
        if(temp2.Contains("transform"))
        {
            len = temp.ToString().Length-4;
            temp2 = t[0..len];
            temp2 += " translate("+ -val +")\" />";
        }
        else
        {
            temp2 += "transform = \"translate(0,"+ -val +")\" />";
        }
        Memento T2 = new Memento(temp2);
        history[ind] = T2;
    }
    //movedown
    public void MoveDown(string type, int val, int ind)
    {
        Memento temp = history[ind];
        string temp2 ="";
        redoList.Add(temp);

        int len = temp.ToString().Length-2;
        string t = temp.ToString();
        temp2 = t[0..len];
        
        if(temp2.Contains("transform"))
        {
            len = temp.ToString().Length-4;
            temp2 = t[0..len];
            temp2 += " translate("+ val +")\" />";
        }
        else
        {
            temp2 += "transform = \"translate(0,"+ val +")\" />";
        }
        Memento T2 = new Memento(temp2);
        history[ind] = T2;
    }
    //moveleft
    public void MoveLeft(string type, int val, int ind)
    {
        Memento temp = history[ind];
        string temp2 ="";
        redoList.Add(temp);

        int len = temp.ToString().Length-2;
        string t = temp.ToString();
        temp2 = t[0..len];
        
        if(temp2.Contains("transform"))
        {
            len = temp.ToString().Length-4;
            temp2 = t[0..len];
            temp2 += " translate("+ -val +")\" />";
        }
        else
        {
            temp2 += "transform = \"translate("+ -val +")\" />";
        }
        Memento T2 = new Memento(temp2);
        history[ind] = T2;
    }
    //moveright
    public void MoveRight(string type, int val, int ind)
    {
        Memento temp = history[ind];
        string temp2 ="";
        redoList.Add(temp);

        int len = temp.ToString().Length-2;
        string t = temp.ToString();
        temp2 = t[0..len];
        
        if(temp2.Contains("transform"))
        {
            len = temp.ToString().Length-4;
            temp2 = t[0..len];
            temp2 += " translate("+ val +")\" />";
        }
        else
        {
            temp2 += "transform = \"translate("+ val +")\" />";
        }
        Memento T2 = new Memento(temp2);
        history[ind] = T2;
    }
    //rotate
    public void Rotate(string type,string dir, int val, int ind)
    {
        Memento temp = history[ind];
        string temp2 = "";
        redoList.Add(temp);

        int len = temp.ToString().Length-2;
        string t = temp.ToString();

        if(dir == "anticlockwise")
        {
            val = 0-val;
        }

        string[] tsplit = t.Split("\"");
        
        if(type == "left-eye"||type == "right-eye")
        {
            int cx = int.Parse(tsplit[1]);
            int cy = int.Parse(tsplit[3]);
            
            len = t.Length-2;
            temp2 = t[0..len];

            if(temp2.Contains("transform"))
            {
                len = temp.ToString().Length-4;
                temp2 = t[0..len];
                temp2 += " rotate("+ val +","+cx + "," +cy + ")\" />";
            }
            else
            {
                temp2 += "transform = \"rotate("+ val +","+ cx+ "," +cy + ")\" />";
            }
            Memento T2 = new Memento(temp2);
            history[ind] = T2;
        }
        else
        {
            int x1 = int.Parse(tsplit[1]);
            int x2 = int.Parse(tsplit[5]);
            int y1 = int.Parse(tsplit[3]);
            int y2 = int.Parse(tsplit[7]);

            int midx;
            int midy;

            if(x1 > x2)
            {
                midx = x2+(x1-x2)*1/2;
            }
            else
            {
                midx = x1+(x2-x1)*1/2;
            }

            if(y1 > y2)
            {
                midy = y2+(y1-y2)*1/2;
            }
            else
            {
                midy = y1+(y2-y1)*1/2;
            }

            len = temp.ToString().Length-2;
            temp2 = t[0..len];

            if(temp2.Contains("transform"))
            {
                len = t.ToString().Length-4;
                temp2 = t[0..len];
                temp2 += " rotate("+ val +","+midx + "," +midy + ")\" />";
            }
            else
            {
                temp2 += "transform = \"rotate("+ val +","+ midx+ "," +midy + ")\" />";
            }
            Memento T2 = new Memento(temp2);
            history[ind] = T2;
        }
    }
    //style
    public void Style(string type ,string val, int ind)
    {
        Memento temp = history[ind];
        String temp2 = "";
        redoList.Add(temp);

        String[] tsplit = temp.ToString().Split("\"");

        if(val == "A")
        {
            if(type == "left-eye"||type == "right-eye")
            {
                tsplit[7] = "fill : red ; stroke : black ; stroke-width : 10";
                temp2 = string.Join("\"", tsplit);
            }
            else
            {
                tsplit[9] = "fill : red ; stroke : red ; stroke-width : 30";
                temp2 = string.Join("\"", tsplit);
            }
        }
        else if(val == "B")
        {
            if(type == "left-eye"||type == "right-eye")
            {
                tsplit[7] = "fill : gray ; stroke : black ; stroke-width : 10";
                temp2 = string.Join("\"", tsplit);
            }
            else
            {
                tsplit[9] = "fill : gray ; stroke : gray ; stroke-width : 30";
                temp2 = string.Join("\"", tsplit);
            }
        }
        else if(val == "C")
        {
            if(type == "left-eye"||type == "right-eye")
            {
                tsplit[7] = "fill : green ; stroke : black ; stroke-width : 10";
                temp2 = string.Join("\"", tsplit);
            }
            else
            {
                tsplit[9] = "fill : green ; stroke : black ; stroke-width : 30";
                temp2 = string.Join("\"", tsplit);
            }
        }
        Memento T2 = new Memento(temp2);
        history[ind] = T2;
    }
}