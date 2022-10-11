
namespace Program
{
    class Tabconv 
    {
        //declaring all elements
        private string inputFile, outputFile;
        private bool v,i,o,h,l;
        public string[][] array_table;

        public Tabconv(string inputFile, string outputFile, bool v, bool i, bool o, bool h, bool l)
        {
            //using this to make managing the commands easier within the code
            this.v = v;
            this.i = i;
            this.o = o;
            this.h = h;
            this.l = l;

            this.inputFile = inputFile;
            this.outputFile = outputFile;

            //if statements to decide what to print out into the command line
            if(i)
            {
                    Console.WriteLine("tabconv version is 1.0.0");
                    Console.WriteLine("author : Alex Majka 20429324");
                    Console.WriteLine(".Net version 6.0");
            }
            if(o)
            {
                
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
    }
}