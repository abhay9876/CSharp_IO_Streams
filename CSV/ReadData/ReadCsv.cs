
/*Read a CSV File and Print Data
● Read a CSV file containing student details (ID, Name, Age, Marks).
● Print each record in a structured format.*/


using System;
using System.IO;

namespace CSV
{
    class ReadCsv
    {
        public static void Perform()
        {
            try
            {
                using (StreamReader sr = new StreamReader("ReadData/Student.csv"))
                {
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        string[] column = line.Split(",");

                        Console.WriteLine($"ID : {column[0]}  Name : {column[1]}  Age : {column[2]}   Mark : {column[3]}");
                    }
                }
            }
            catch (IOException e)
            {
                Console.WriteLine("IO Exception : " + e.Message);
            }
        }
    }
}