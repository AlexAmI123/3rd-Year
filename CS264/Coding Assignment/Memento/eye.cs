public class Eye
{
    public int cx;
    public int cy;
    public int r;
    public string fill;
    public string stroke;
    public string strokeWidth;

    public Eye(int cx,int cy, int r, string fill,string stroke, string strokeWidth)
    {
        this.cx = cx;
        this.cy = cy;
        this.r = r;
        this.fill = fill;
        this.stroke = stroke;
        this.strokeWidth = strokeWidth;
    }
    //add said shape
    public void printShape(Caretaker caretaker)
    {
        string data = "<circle cx = \"" + cx + "\" cy = \"" + cy + "\" r = \"" + r + "\" style = \" fill : " + fill + " ; stroke : "+stroke+ " ; stroke-width : " + strokeWidth +"\" />";
        Memento memento  = new Memento(data);
        caretaker.addMemento(memento);
    }
}