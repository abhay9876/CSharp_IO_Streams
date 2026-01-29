/*Merge Two CSV Files
● You have two CSV files:
○ students1.csv (contains ID, Name, Age)
○ students2.csv (contains ID, Marks, Grade)
● Merge both files based on ID and create a new file containing all details.
*/


using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text.RegularExpressions;
using CsvHelper;


namespace MergeFiles
{
    public class MergedFiles
    {
        public static void Merge()
        {
            List<Student1> list1;
            List<Student2> list2;


            using (var reader = new StreamReader("MergeFiles/Student1.csv"))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                list1 = csv.GetRecords<Student1>().ToList();
            }


            using (var reader = new StreamReader("MergeFiles/Student2.csv"))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                list2 = csv.GetRecords<Student2>().ToList();
            }

            List<MergeStudent> mergedList = new List<MergeStudent>();

            foreach (var s1 in list1)
            {
                foreach (var s2 in list2)
                {
                    if (s1.Id == s2.Id)
                    {
                        MergeStudent ms = new MergeStudent
                        {
                            Id = s1.Id,
                            Name = s1.Name,
                            Age = s1.Age,
                            Marks = s2.Marks,
                            Grade = s2.Grade
                        };

                        mergedList.Add(ms);
                        break;
                    }
                }
            }

            using (var writer = new StreamWriter("MergeFiles/MergeStudent.csv"))
            using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
            {
                csv.WriteRecords(mergedList);
            }


        }
    }
}
