public class Memento
{
    string shape = "";

    //constructor
    public Memento(string shape)
    {
        this.shape = shape;
    }
    public override string ToString()
    {
        return $"{this.shape}";
    }
}