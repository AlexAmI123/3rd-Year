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
        Console.WriteLine(@"
                                                        THIS IS YOUR SVG PREVIEW :)");
        Console.WriteLine();

        for (int i = 0; i < history.Count(); i++)
        {
            Console.WriteLine($"{history[i].ToString()}");
        }
    }
    //create .svg file from Memento
    public void CreateMomentoSVG()
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