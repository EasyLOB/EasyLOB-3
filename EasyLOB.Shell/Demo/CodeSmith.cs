using EasyLOB.Library;
using System;

namespace EasyLOB.Shell
{
    partial class Program
    {

        private static void DemoCodeSmith()
        {
            Console.WriteLine("\nCodeSmith Demo\n");

            try
            {
                string word;
                string[] words;

                word = "AbcDefLookupText";
                Console.WriteLine(word);
                words = CodeSmithHelper.StringSplitPascalCase(word).Split(' ');
                foreach (string w in words)
                {
                    Console.WriteLine("  " + w);
                }

                word = "Abc1LookupText";
                Console.WriteLine(word);
                words = CodeSmithHelper.StringSplitPascalCase(word).Split(' ');
                foreach (string w in words)
                {
                    Console.WriteLine("  " + w);
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine("\n");
                Console.WriteLine(exception.ExceptionMessage());
            }
        }
    }
}
