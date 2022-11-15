public class Memento
{
    string shape = "";

    //constructor
    public Memento(string shape)
    {
        this.shape = shape;
    }
    //getter
    // public string getData()
    // {
    //     return $"{this.shape}";
    // }
    //get value of shape as string
    public override string ToString()
    {
        return $"{this.shape}";
    }
}