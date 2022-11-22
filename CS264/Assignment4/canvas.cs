public class Canvas
{
    private List<String> history = new List<String>();
    private List<String> redoList = new List<String>();
    public void add(String shape)
    {
        history.Add(shape);
    }
    public void undo()
    {
        int i = history.Count() - 1;
        var temp = history[i];
        redoList.Add(temp);
        history.RemoveAt(i);
    }
    public void redo()
    {
        int i = redoList.Count() - 1;
        var temp = redoList[i];
        history.Add(temp);
        redoList.RemoveAt(i);
    }
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
    public void CreateSVG()
    {

    }
}