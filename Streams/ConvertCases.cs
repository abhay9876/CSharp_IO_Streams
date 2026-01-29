/*Filter Streams - Convert Uppercase to Lowercase
Problem Statement: Create a program that reads a text file and
writes its contents into another file, converting all uppercase letters to
lowercase.
Requirements: Use StreamReader and StreamWriter. Use
BufferedStream for efficiency. Handle character encoding issues.*/


using System;
using System.IO;
using System.Text;

namespace Streams
{
    public class ConvertCases
    {
        public void Perform()
        {

            string inputFile = "Demo.txt";
            string outputFile = "Demo1.txt";

            try
            {
                using (FileStream fsRead = new FileStream(inputFile, FileMode.Open, FileAccess.Read))
                using (BufferedStream bsRead = new BufferedStream(fsRead))
                using (StreamReader reader = new StreamReader(bsRead, Encoding.UTF8))

                using (FileStream fsWrite = new FileStream(outputFile, FileMode.Create, FileAccess.Write))
                using (BufferedStream bsWrite = new BufferedStream(fsWrite))
                using (StreamWriter writer = new StreamWriter(bsWrite, Encoding.UTF8))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        writer.WriteLine(line.ToLower());
                    }
                }

                Console.WriteLine("File successfully converted to lowercase.");

            }
            catch (IOException e)
            {
                Console.WriteLine("IOException : " + e.Message);
            }
        }
    }
}
