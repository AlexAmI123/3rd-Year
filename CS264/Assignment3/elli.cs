public class Ellipse
{
    public int rx;
    public int ry;
    public int cx;
    public int cy;
    public string fill;
    public string stroke;
    public string strokeWidth;

    public Ellipse(int rx, int ry, int cx, int cy, string fill,string stroke, string strokeWidth)
    {
        this.rx = rx;
        this.ry = ry;
        this.cx = cx;
        this.cy = cy;
        this.fill = fill;
        this.stroke = stroke;
        this.strokeWidth = strokeWidth;
    }
    // public string printShape()
    // {
    //     string data = "<ellipse cx=\""+cx+"\" cy = \""+cy+"\"  rx = \""+rx+"\" ry = \""+ry+"\" style = \" fill : " + fill + " ; stroke : "+stroke+ " ; stroke-width : " + strokeWidth +"\" />";
    //     return data;
    // }

    public void printShape()
    {
        string data = "<ellipse cx=\""+cx+"\" cy = \""+cy+"\"  rx = \""+rx+"\" ry = \""+ry+"\" style = \" fill : " + fill + " ; stroke : "+stroke+ " ; stroke-width : " + strokeWidth +"\" />";
        Memento memento  = new Memento(data);
        Caretaker caretaker = new Caretaker();
        caretaker.addMemento(memento);
    }
}