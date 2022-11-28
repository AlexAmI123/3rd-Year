public interface CommandInt
{
    void Execute();
    void Undo();
    void Redo();
    void PrintSVG();
    void CreateSVG();
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
        CommandHndlr add = new CommandHndlr();
        add.AddCMD(this);
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
    public override string ToString()
        {
            return $"{this.shape}";
        }
}

public class CommandHndlr
{
    private List<CommandInt> history = new List<CommandInt>();

    public void AddCMD(CommandInt command)
    {
        history.Add(command);
    }
    public void UndoCMD()
    {
        history[history.Count-1].Undo();
    }
    public void RedoCMD()
    {
        history[history.Count-1].Redo();
    }
    public void PrintSVGCMD()
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
    public void CreateSVGCMD()
    {
        using (StreamWriter sw = File.CreateText(@"output.svg"))
        {
            for (int i = 0; i < history.Count(); i++)
            {
                sw.WriteLine($"{history[i].ToString()}");
            }
        }
    }
}