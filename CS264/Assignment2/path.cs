public class Path
{
    public string coords;
    public string fill;
    public string stroke;
    public string strokeWidth;
    public Path(string coords, string fill, string stroke, string strokeWidth)
    {
        this.coords = coords;
        this.fill = fill;
        this.stroke = stroke;
        this.strokeWidth = strokeWidth;
    }
    public string printShape()
    {
        string data = "<path d = \""+coords.Replace("_"," ")+"\" style = \" fill : " + fill + " ; stroke : "+stroke+ " ; stroke-width : " + strokeWidth +"\" />";
        return data;
    }
}