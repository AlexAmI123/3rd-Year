public class Polyline
{
    public string coords;
    public string fill;
    public string stroke;
    public string strokeWidth;
    public Polyline(string coords, string fill, string stroke, string strokeWidth)
    {
        this.coords = coords;
        this.fill = fill;
        this.stroke = stroke;
        this.strokeWidth = strokeWidth;
    }
    // public string printShape()
    // {
    //     string data = "<polyline points = \""+coords.Replace("_"," ")+"\" style = \" fill : " + fill + " ; stroke : "+stroke+ " ; stroke-width : " + strokeWidth +"\" />";
    //     return data;
    // }

    public void printShape(Caretaker caretaker)
    {
        string data = "<polyline points = \""+coords.Replace("_"," ")+"\" style = \" fill : " + fill + " ; stroke : "+stroke+ " ; stroke-width : " + strokeWidth +"\" />";
        Memento memento  = new Memento(data);
        caretaker.addMemento(memento);
    }
}