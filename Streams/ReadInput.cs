/*Read User Input from Console
 Problem Statement: Write a program that asks the user for their
name, age, and favorite programming language, then saves this
information into a file.
Requirements: Use StreamReader for console input. Use StreamWriter
to write the data into a file. Handle exceptions properly.     */


using System;
using System.IO;

namespace Streams
{
    public class ReadInput
    {
        public void Perform()
        {
            try
            {
                string data;
                string filePath = @"Demo.txt";

                FileStream fileStream = new FileStream(filePath, FileMode.Create, FileAccess.Write);

                using (StreamWriter sr1 = new StreamWriter(fileStream))
                {
                    Console.WriteLine("Enter Name : ");
                    string name = Console.ReadLine();
                    Console.WriteLine("Enter Age : ");
                    int age = int.Parse(Console.ReadLine());
                    Console.WriteLine("Enter Language : ");
                    string language = Console.ReadLine();
                    sr1.Write("Name : " + name + " ");
                    sr1.Write("Age : " + age + " ");
                    sr1.Write("Language : " + language);
                    Console.WriteLine("Write Operation Performed...");

                }

            }
            catch (IOException e)
            {
                Console.WriteLine("IOException : " + e.Message);
            }
        }
    }
}