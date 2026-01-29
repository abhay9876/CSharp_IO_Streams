/*Filter Records from CSV
● Read a CSV file and filter students who have scored more than 80 marks.
● Print only the qualifying records.*/



using System;
using System.IO;

namespace CSV
{
    class FilterRecords
    {
        public static void FilterPerform()
        {
            try
            {
                using (StreamReader sr = new StreamReader("FilterRecords/Students.csv"))
                {
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        string[] column = line.Split(",");
                        int mark = Convert.ToInt32(column[3]);

                        if (mark > 80)
                        {

                            Console.WriteLine($"ID : {column[0]}  Name : {column[1]}  Age : {column[2]}   Mark : {column[3]}");
                        }
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