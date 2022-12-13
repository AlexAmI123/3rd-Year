public class CreateSVG
{
    public List<string> canvas;

    public CreateSVG(List<string> canvas)
    {
        this.canvas = canvas;

         using (StreamWriter sw = File.CreateText(@"output.svg"))
         {
            foreach(string s in canvas)
            {
                sw.WriteLine(s);
            }
         }
    }
}