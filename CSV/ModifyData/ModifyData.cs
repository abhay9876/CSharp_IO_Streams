/*Modify a CSV File (Update a Value)
● Read a CSV file and increase the salary of employees from the "IT" department by
10%.
● Save the updated records back to a new CSV file.*/


using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using CsvHelper;

namespace ModifyData
{
    class ModifingData
    {
        public static void Perform()
        {
            List<Employee> employees;

            try
            {
                using (var sr = new StreamReader("ModifyData/Employees.csv"))
                using (var csv = new CsvReader(sr, CultureInfo.InvariantCulture))
                {
                    employees = csv.GetRecords<Employee>().ToList();
                }

                foreach (var v in employees)
                {
                    if (v.Department == "IT")
                    {
                        v.Salary = v.Salary + (v.Salary * 0.10);
                    }
                }

                using (var sr = new StreamWriter("ModifyData/Employees.csv"))
                using (var csv = new CsvWriter(sr, CultureInfo.InvariantCulture))
                {
                    csv.WriteRecords(employees);
                    Console.WriteLine("Data Modified....");
                }


            }
            catch (IOException e)
            {
                Console.WriteLine(" IO error occurred : " + e.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(" Unexpected error occurred: " + ex.Message);
            }


        }
    }
}