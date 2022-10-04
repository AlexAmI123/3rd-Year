
namespace Program
{
    class Tabconv 
    {
        //declaring all elements
        private string inputPath, outputFile;
        private bool v,i,o,h,l;
        public string[][] array_table;

        public Tabconv(string inputPath, string outputFile, bool v, bool i, bool o, bool h, bool l)
        {
            //using this to make managing the commands easier within the code
            this.v = v;
            this.i = i;
            this.o = o;
            this.h = h;
            this.l = l;

            this.inputPath = inputPath;
            this.outputFile = outputFile;

            //if statements to decide what to print out into the command line(i,o,h,l)
            if(i)
            {
                    Console.WriteLine("tabconv version is 1.0.0");
                    Console.WriteLine("author : Alex Majka 20429324");
                    Console.WriteLine(".Net version 6.0");
            }
            if(o)
            {
                ToArray(inputPath);
                ToOutput(outputFile);
            }
            if(h)
            {
                Console.WriteLine(@"This	app	will	provide	funcConality	to	convert	between	different	markup	 formats	 for	 tabular	data,	 for	example,	it	will	convert	between	CSV	 (Comma	Separated	Values),	MD	 (Markdown),	 JSON	 (JavaScript	Object	NotaCon,	and	HTML-TABLE	 (HTML	<table>	element)	 formats.CLI	(command-line	interface)	user	interface	along	the	lines	for	the	following:	
    tabconv		-v	-i	<file.ext>	-o	<file.ext>	
        -v,	—verbose	 	 	 	 Verbose	mode	(debugging	output	to	STDOUT)	
        -o	<file>,	—output=<file>	 Output	file	specified	by	<file>	
        -l,	—list-formats	 	 	 List	formats	
        -h,	—help		 	 	 	 Show	usage	message	
        -i,	—info		 	 	 	 Show	version	information		
    <.ext>	will	be	one	of	[.html	|	.md	|	.csv	|	.json]	");
            }
            if(l)
            {
                Console.WriteLine("Formats:");
                Console.WriteLine(".csv");
                Console.WriteLine(".html");
                Console.WriteLine(".md");
                Console.WriteLine(".json");
            }
        }
        //method to call to convert to string array
        public void ToArray(String inputPath)
        {
            String [] type = inputPath.Split(".");
            switch(type[1])
            {
                case "csv":
                    array_table = fromCSV(inputPath);break;
                case "html":
                    array_table = fromHTML(inputPath);break;
                case "md":
                    array_table = fromMD(inputPath);break;
                case "json":
                    array_table = fromJSON(inputPath);break;
                default:break;
            }
        }

        //method to call to convert string array to desired format
        public void ToOutput(string outputFile)
        {
            string [] type = outputFile.Split(".");
            switch(type[1])
            {
                case "csv":
                    toCSV(outputFile);break;
                case "html":
                    toHTML(outputFile);break;
                case "md":
                    toMD(outputFile);break;
                case "json":
                    toJSON(outputFile);break;
                default:break;
            }
        }

        //----------------------------------------------------------------------------------------------------------------
        //Methods to convert to string array
        //convert from csv
        public string[][] fromCSV(string inputPath)
        {
            if(v)
            {
                Console.WriteLine("Reading CSV file & converting to array :)");
            }
            StreamReader sr = new StreamReader(inputPath);
            //for every line of the file
            var lines = new List<string[]>();
            //while there is another line
            while(!sr.EndOfStream){
                //split where ","
                string[] lbl = sr.ReadLine().Split(",");
                //for each string in the split strings, replace "\" with ""(blank)
                foreach(string s in lbl){
                    s.Replace("\"", "");
                }
                //add to lines List
                lines.Add(lbl);
            }
            //return finished array
            return lines.ToArray();
        }
        //convert from html
        public string[][] fromHTML(string inputPath)
        {
            if(v)
            {
                Console.WriteLine("Reading HTML file & converting to array :)");
            }
            // StreamReader sr = new StreamReader(inputFile);
            // var lines = new List<string[]>();
            HtmlAgilityPack.HtmlDocument htmlDoc = new HtmlAgilityPack.HtmlDocument();
            htmlDoc.Load(inputPath);
            
            // var query = from table in htmlDoc.DocumentNode.SelectNodes("//table")
            // where table.Descendants("tr").Count() > 1 //make sure there are rows other than header row
            // from row in table.SelectNodes(".//tr[position()>1]") //skip the header row
            // from cell in row.SelectNodes("./td") 
            // from header in table.SelectNodes(".//tr[1]/th") //select the header row cells which is the first tr
            // select new
            // {
            //   Table = table.Id,
            //   Row = row.InnerText,
            //   Header = header.InnerText,
            //   CellText = cell.InnerText
            // };
            
        }
        //convert from md
        public string[][] fromMD(string inputPath)
        {
            if(v)
            {
                Console.WriteLine("Reading MD file & converting to array :)");
            }
            StreamReader sr = new StreamReader(inputPath);
            //for every line of the file
        }
        //convert from json
        public string[][] fromJSON(string inputPath)
        {
            if(v)
            {
                Console.WriteLine("Reading JSON file & converting to array :)");
            }
            StreamReader sr = new StreamReader(inputPath);
            //for every line of the file
        }
        //----------------------------------------------------------------------------------------------------------------
        //Methods to convert to desired format
        //convert to csv
        public string[][] toCSV(string inputPath)
        {
            if(v)
            {
                Console.WriteLine("Converting to CSV file :)");
            }
            
        }
        //convert to html
        public string[][] toHTML(string inputPath)
        {
            if(v)
            {
                Console.WriteLine("Converting to HTML file :)");
            }
            
        }
        //convert to md
        public string[][] toMD(string inputPath)
        {
            if(v)
            {
                Console.WriteLine("Converting to MD file :)");
            }
            
        }
        //convert to json
        public string[][] toJSON(string inputPath)
        {
            if(v)
            {
                Console.WriteLine("Converting to JSON file :)");
            }
            
        }
    }
}