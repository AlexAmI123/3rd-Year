//reveiver class
public class Canvas
{
    private List<String> history = new List<String>();
    private List<String> redoList = new List<String>();
    //add method
    public void add(String shape)
    {
        history.Add(shape);
    }
    //undo method
    public void undo()
    {
        int i = history.Count() - 1;
        var temp = history[i];
        redoList.Add(temp);
        history.RemoveAt(i);
    }
    //redo method
    public void redo()
    {
        int i = redoList.Count() - 1;
        var temp = redoList[i];
        history.Add(temp);
        redoList.RemoveAt(i);
    }
    //display svg preview
    public void printSVG()
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
    //create to file
    public void CreateSVG()
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