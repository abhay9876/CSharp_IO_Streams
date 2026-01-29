/*Convert CSV Data into C# Objects
● Read a CSV file and convert each row into a Student Java object.
● Store the objects in a List<Student> and print them.
*/


using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using CsvHelper;

namespace DataToObject
{
    class ConvertData
    {
        public static void Convert()
        {
            List<Student> students;

            try
            {
                using (var sr = new StreamReader("DataToObject/Students.csv"))
                using (var csv = new CsvReader(sr, CultureInfo.InvariantCulture))
                {
                    students = csv.GetRecords<Student>().ToList();
                }

                foreach (var s in students)
                {
                    Console.WriteLine(s);
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