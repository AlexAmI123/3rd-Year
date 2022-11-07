public class Memento
{
    string shape = "";

    //constructor
    public Memento(string shape)
    {
        this.shape = shape;
    }
    //getter
    public string getData()
    {
        return $"{this.shape}";
    }
    public override string ToString()
    {
        return $"{this.shape}";
    }
}