public class ellipse
{
    public int rx;
    public int ry;
    public int cx;
    public int cy;
    public string fill;
    public string stroke;
    public string strokeWidth;

    public ellipse(int rx, int ry, int cx, int cy, string fill,string stroke, string strokeWidth)
    {
        this.rx = rx;
        this.ry = ry;
        this.cx = cx;
        this.cy = cy;
        this.fill = fill;
        this.stroke = stroke;
        this.strokeWidth = strokeWidth;
    }
}