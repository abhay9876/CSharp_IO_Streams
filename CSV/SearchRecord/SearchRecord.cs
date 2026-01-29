/*Search for a Record in CSV
● Read an employees.csv file and search for an employee by name.
● Print their department and salary.*/


using System;
using System.IO;

namespace CSV
{
    class SerachRecord
    {
        public static void Search()
        {
            try
            {
                using (StreamReader sr = new StreamReader("SearchRecord/Employees.csv"))
                {
                    Console.WriteLine("Enter Name to search in record : ");
                    string name = Console.ReadLine();
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        if (line.Contains(name))
                        {
                            string[] column = line.Split(",");

                            Console.WriteLine($"ID : {column[0]}  Name : {column[1]}  Department : {column[2]}   Salary : {column[3]}");
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