public interface CommandInt
{
    void Execute();
}

public class Commands: CommandInt
{
    string shape;

    //constructor
    public Commands(string shape)
    {
        this.shape = shape;
    }
    //execute method
    public void Execute()
    {

    }
    //undo method
    public void Undo()
    {
        Console.WriteLine("Undoing Command..");
    }
    //redo method
    public void Redo()
    {
        Console.WriteLine("Redoing Command..");
    }
    //display svg preview
    public void PrintSVG()
    {
        Console.WriteLine("Printing SVG..");
    }
    //create to file
    public void CreateSVG()
    {
        Console.WriteLine("Creating SVG file..");   
    }
    //remove from canvas
    public void RemoveSVG()
    {
        Console.WriteLine("Removing from SVG file..");   
    }
    //move commands
    public void MoveUp()
    {
        Console.WriteLine("Moving Up..");   
    }
    public void MoveDown()
    {
        Console.WriteLine("Moving Down.."); 
    }
    public void MoveLeft()
    {
        Console.WriteLine("Moving Left.."); 
    }
    public void MoveRight()
    {
        Console.WriteLine("Moving Right.."); 
    }
    public override string ToString()
    {
        return $"{this.shape}";
    }
}

public class AddCMD: CommandInt
{
    public List<String> history;
    public List<String> redoList;
    public string shape;

    public AddCMD(String shape, List<string> history)
    {
        this.shape = shape;
        this.history = history;
    }
    public void Execute()
    {
        history.Add(shape);
    }
}
public class UndoCMD: CommandInt
{
    public List<String> history;
    public List<String> redoList;

    public UndoCMD(List<string> history, List<string> redoList)
    {
        this.history = history;
        this.redoList = redoList;
    }
    public void Execute()
    {
        int i = history.Count() - 1;
        var temp = history[i];
        redoList.Add(temp);
        history.RemoveAt(i);
    }
}
public class RedoCMD: CommandInt
{
    public List<String> history;
    public List<String> redoList;

    public RedoCMD(List<string> history, List<string> redoList)
    {
        this.history = history;
        this.redoList = redoList;
    }
    public void Execute()
    {
        int i = redoList.Count() - 1;
        var temp = redoList[i];
        history.Add(temp);
        redoList.RemoveAt(i);
    }
}
public class PrintSVGCMD: CommandInt
{
    public List<String> history;

    public PrintSVGCMD(List<string> history)
    {
        this.history = history;
    }
    public void Execute()
    {
        //clear console to make it look cleaner
        Console.Clear();

        //print contents of canvas so far
        Console.WriteLine(@"
                                                        THIS IS YOUR SVG PREVIEW :)");
        Console.WriteLine();

        for (int i = 0; i < history.Count(); i++)
        {
            Console.WriteLine($"{history[i].ToString()}");
        }
    }
}
public class CreateSVGCMD: CommandInt
{
    public List<String> history;
    public String name;
    public CreateSVGCMD(List<string> history, string name)
    {
        this.history = history;
        this.name = name;
    }
    public void Execute()
    {
        using (StreamWriter sw = File.CreateText(name))
        {
            for (int i = 0; i < history.Count(); i++)
            {
                sw.WriteLine($"{history[i].ToString()}");
            }
        }
    }
}
public class RemoveCMD: CommandInt
{
    public List<String> history;
    public List<String> redoList;
    public int ind;
    public RemoveCMD(List<string> history, List<string> redoList, int ind)
    {
        this.history = history;
        this.redoList = redoList;
        this.ind = ind;
    }
    public void Execute()
    {
        var temp = history[ind];
        redoList.Add(temp);
        history.RemoveAt(ind);
    }
}
public class MoveUp: CommandInt
{
    public List<String> history;
    public List<String> redoList;
    public int ind;
    public int val;
    public string type;
    public MoveUp(List<string> history, List<string> redoList, string type, int val, int ind)
    {
        this.history = history;
        this.redoList = redoList;
        this.type = type;
        this.ind = ind;
        this.val = val;
    }
    public void Execute()
    {
        string temp = history[ind];
        string temp2 = "";
        redoList.Add(temp);

        if(type == "left-eye"||type =="right-eye")
        {
            int len = temp.Length-2;
            temp2 = temp[0..len];
            
            temp2 += "transform = \"translate(0,"+ -val +")\">";
        }
        else if(type == "left-brow"||type =="right-brow"||type =="mouth")
        {
            int len = temp.Length-2;
            temp2 = temp[0..len];
            
            temp2 += "transform = \"translate(0,"+ -val +")\">";
        }
        history[ind] = temp2;
    }
}
public class MoveDown: CommandInt
{
    public List<String> history;
    public List<String> redoList;
    public int ind;
    public int val;
    public string type;
    public MoveDown(List<string> history, List<string> redoList, string type, int val, int ind)
    {
        this.history = history;
        this.redoList = redoList;
        this.type = type;
        this.ind = ind;
        this.val = val;
    }
    public void Execute()
    {
        string temp = history[ind];
        string temp2 = "";
        redoList.Add(temp);

        if(type == "left-eye"||type =="right-eye")
        {
            int len = temp.Length-2;
            temp2 = temp[0..len];
            
            temp2 += "transform = \"translate(0,"+ val +")\">";
        }
        else if(type == "left-brow"||type =="right-brow"||type =="mouth")
        {
            int len = temp.Length-2;
            temp2 = temp[0..len];
            
            temp2 += "transform = \"translate(0,"+ val +")\">";
        }
        history[ind] = temp2;
    }
}
public class MoveLeft: CommandInt
{
    public List<String> history;
    public List<String> redoList;
    public int ind;
    public int val;
    public string type;
    public MoveLeft(List<string> history, List<string> redoList, string type, int val, int ind)
    {
        this.history = history;
        this.redoList = redoList;
        this.type = type;
        this.ind = ind;
        this.val = val;
    }
    public void Execute()
    {
        string temp = history[ind];
        string temp2 = "";
        redoList.Add(temp);

        if(type == "left-eye"||type =="right-eye")
        {
            int len = temp.Length-2;
            temp2 = temp[0..len];
            
            temp2 += "transform = \"translate("+ -val +")\">";
        }
        else if(type == "left-brow"||type =="right-brow"||type =="mouth")
        {
            int len = temp.Length-2;
            temp2 = temp[0..len];
            
            temp2 += "transform = \"translate("+ -val +")\">";
        }
        history[ind] = temp2;
    }
}
public class MoveRight: CommandInt
{
    public List<String> history;
    public List<String> redoList;
    public int ind;
    public int val;
    public string type;
    public MoveRight(List<string> history, List<string> redoList, string type, int val, int ind)
    {
        this.history = history;
        this.redoList = redoList;
        this.type = type;
        this.ind = ind;
        this.val = val;
    }
    public void Execute()
    {
        string temp = history[ind];
        string temp2 = "";
        redoList.Add(temp);

        if(type == "left-eye"||type =="right-eye")
        {
            int len = temp.Length-2;
            temp2 = temp[0..len];
            
            temp2 += "transform = \"translate("+ val +")\">";
        }
        else if(type == "left-brow"||type =="right-brow"||type =="mouth")
        {
            int len = temp.Length-2;
            temp2 = temp[0..len];
            
            temp2 += "transform = \"translate("+ val +")\">";
        }
        history[ind] = temp2;
    }
}