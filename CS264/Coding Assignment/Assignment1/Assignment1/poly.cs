public class Polygon
{
    public string coords;
    public string fill;
    public string stroke;
    public string strokeWidth;
    public Polygon(string coords, string fill, string stroke, string strokeWidth)
    {
        this.coords = coords;
        this.fill = fill;
        this.stroke = stroke;
        this.strokeWidth = strokeWidth;
        printShape();
    }
    //add said shape to Memento
    public string printShape(/*Caretaker caretaker*/)
    {
        string data = "<polygon points = \""+coords.Replace("_"," ")+"\" style = \" fill : " + fill + " ; stroke : "+stroke+ " ; stroke-width : " + strokeWidth +"\" />";
        return data;
    }
}