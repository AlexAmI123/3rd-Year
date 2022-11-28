public class Line
{
    public int x1;
    public int y1;
    public int x2;
    public int y2;
    public string stroke;
    public string strokeWidth;
    public Line(int x1, int y1, int x2, int y2, string stroke, string strokeWidth)
    {
        this.x1 = x1;
        this.y1 = y1;
        this.x2 = x2;
        this.y2 = y2;
        this.stroke = stroke;
        this.strokeWidth = strokeWidth;
    }
    //add said shape to Memento
    public void printShape(/*Caretaker caretaker*/)
    {
        string data = "<line x1 = \""+x1+"\" y1 = \""+y1+"\" x2 = \""+x2+"\" y2 = \""+y2+"\" style = \"stroke : "+stroke+ " ; stroke-width : " + strokeWidth +"\" />";
        Commands command = new Commands(data);
        command.Execute();
    }
}