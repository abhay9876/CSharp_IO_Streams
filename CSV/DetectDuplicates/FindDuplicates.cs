/*Detect Duplicates in a CSV File
● Read a CSV file and detect duplicate entries based on the ID column.
● Print all duplicate records.
*/


using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using CsvHelper;

namespace DetectDuplicate
{
    class FindDuplicate
    {
        public static void Find()
        {
            try
            {
                List<Student> students;
                using (var reader = new StreamReader("DetectDuplicates/Students.csv"))
                using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
                {
                    students = csv.GetRecords<Student>().ToList();
                }


                var duplicates = students
                    .GroupBy(s => s.Id)
                    .Where(g => g.Count() > 1)
                    .SelectMany(g => g);

                Console.WriteLine("Duplicate Records :");

                foreach (var s in duplicates)
                {
                    Console.WriteLine($"Id: {s.Id}, Name: {s.Name}, Age: {s.Age}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error : " + ex.Message);
            }
        }
    }
}
