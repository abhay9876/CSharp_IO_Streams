/*Read a Large File Line by Line
 Problem Statement: Develop a C# program that efficiently reads a
large text file (500MB+) line by line and prints only lines containing the
word "error".
Requirements: Use StreamReader for efficient reading. Read line-by-line
instead of loading the entire file. Display only lines containing "error"
(case insensitive).*/

using System;
using System.IO;

namespace Streams
{
    class LargeFile
    {
        public void ReadPerform()
        {
            try
            {

                using (FileStream fs = new FileStream("Large.txt", FileMode.Open, FileAccess.Read))
                using (StreamReader sr = new StreamReader(fs))
                {
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        if (line.Contains("error"))
                        {
                            Console.WriteLine(line);
                        }
                    }
                }
            }
            catch (IOException e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}