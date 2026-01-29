/*Write Data to a CSV File
● Create a CSV file with employee details (ID, Name, Department, Salary).
● Write at least 5 records to the file.*/

using System;
using System.IO;

namespace CSV
{
    class WriteData
    {
        public static void Perform()
        {
            try
            {
                using (StreamWriter sw = new StreamWriter("WriteData/Employees.csv"))
                {

                    while (true)
                    {
                        Console.WriteLine("Enter Id : ");
                        int id = int.Parse(Console.ReadLine());

                        Console.WriteLine("Enter Name : ");
                        string name = Console.ReadLine();


                        Console.WriteLine("Enter Department : ");
                        string dept = Console.ReadLine();

                        Console.WriteLine("Enter Salary : ");
                        double salary = double.Parse(Console.ReadLine());

                        sw.WriteLine($"{id},{name},{dept},{salary}");

                        Console.Write("Do you want to add another person ? (Y/N): ");

                        string choice = Console.ReadLine().ToUpper();

                        if (choice != "Y")
                            break;


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