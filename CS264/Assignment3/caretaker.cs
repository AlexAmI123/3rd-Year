public class Caretaker
{
    //Mementos for history and redo list
    List<Memento> history = new List<Memento>();
    //When something is undone, add to this list
    List<Memento> redoList = new List<Memento>();
    private Originator originator = null;

    // public Caretaker(Originator originator)
    // {
    //     this.originator = originator;
    // }

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
    public string getMemento(int i)
    {
        string s = history[i].ToString();//access list at index i
        Console.WriteLine(s);
        return s;
    }
    public void printMemento()
    {
        for (int i = 0; i < history.Count(); i++)
        {
            Console.WriteLine($"{history[i].ToString()}");
        }
    }
}