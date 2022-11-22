public class Rectangle
{
    public int x;
    public int y;
    public int width;
    public int height;
    public string fill;
    public string stroke;
    public string strokeWidth;
    public Rectangle(int x, int y, int width, int height, string fill, string stroke, string strokeWidth)
    {
        this.x = x;
        this.y = y;
        this.width = width;
        this.height = height;
        this.fill = fill;
        this.stroke = stroke;
        this.strokeWidth = strokeWidth;
    }
    //add said shape to Memento
    public void printShape(/*Caretaker caretaker*/)
    {
        // string data = "<rect x = \""+ x +"\" y = \""+ y+"\" width = \""+width+"\" height = \""+ height +"\" style = \" fill : " + fill + " ; stroke : "+stroke+ " ; stroke-width : " + strokeWidth +"\" />";
        // Memento memento  = new Memento(data);
        // caretaker.addMemento(memento);
    }
}