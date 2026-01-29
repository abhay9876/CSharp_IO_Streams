/*Sort CSV Records by a Column
● Read a CSV file and sort the records by Salary in descending order.
● Print the top 5 highest-paid employees.
*/


using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using CsvHelper;


namespace SortRecords
{
    public class SortData
    {
        public static void Perform()
        {
            List<Employee> employees;
            using (var sr = new StreamReader("SortRecords/Employees.csv"))
            using (var csv = new CsvReader(sr, CultureInfo.InvariantCulture))
            {
                employees = csv.GetRecords<Employee>().ToList();
            }

            employees = employees.OrderByDescending((e) => e.Salary).ToList();

            var TopList = employees.Take(5).ToList();

            foreach (var emp in TopList)
            {
                Console.WriteLine(emp.Name);
            }
        }
    }
}