public abstract class Command
{
    public abstract void add();
    public abstract void undo();
    public abstract void redo();
    public abstract void printSVG();
    public abstract void CreateSVG();
}