using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace practicum_3
{
    class Program
    {
        static void Main(string[] args)
        {
            String path = @"C:\Users\Redou\source\repos\practicum3\randomtext.txt";

            foreach (String word in GetWords(path, s => s.StartsWith("a")))
            { 
                Console.WriteLine(word);
            }
            
            // "both" en "quince" gaan fout? En een whitespace?
        }

        public static IEnumerable<string> GetWords(String path, Func<String, Boolean> startsWithFunction)
        {
            // De tekst binnen de meegegeven file
            String text = null;

            try
            {
                // Het uitlezen van alle tekst binnen de meegegeven file
                text = System.IO.File.ReadAllText(path);
            }
            catch (Exception e)
            {
                Console.WriteLine("File not found on path: " + path, e);
            }

            // Splitten op whitespace, komma, punt, puntkomma
            String[] woorden = text.Split(new Char[] { ',', '.', ';', ' ' }, StringSplitOptions.RemoveEmptyEntries);

            // Nog niet helemaal duidelijk hoe dit nou precies werkt
            Array.Sort(woorden, (x, y) => x.Length.CompareTo(y.Length));

            foreach (String word in woorden)
            {
                if (startsWithFunction(word))
                {
                    yield return word;
                }
            }
        }
    }
}
