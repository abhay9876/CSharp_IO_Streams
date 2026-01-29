/*Buffered Streams - Efficient File Copy
 Problem Statement: Create a C# program that copies a large file
(e.g., 100MB) from one location to another using Buffered Streams
(BufferedStream). Compare the performance with normal file streams.
Requirements: Read and write in chunks of 4 KB (4096 bytes). Use
Stopwatch to measure execution time. Compare execution time with
unbuffered streams.*/


using System;
using System.IO;

namespace Streams
{
    public class ReadWrite
    {
        public void Operations()
        {
            try
            {
                string data;
                string filePath = @"Demo.txt";
                string filePath1 = @"Demo1.txt";

                using (FileStream fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read))

                using (StreamReader sr = new StreamReader(fileStream))
                {
                    data = sr.ReadToEnd();
                }

                using (FileStream fileStream1 = new FileStream(filePath1, FileMode.Create, FileAccess.Write))

                using (StreamWriter sr1 = new StreamWriter(fileStream1))
                {
                    sr1.Write(data);
                }

            }
            catch (IOException e)
            {
                Console.WriteLine("IOException : " + e.Message);
            }
        }
    }
}