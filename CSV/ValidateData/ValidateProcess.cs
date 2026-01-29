/*Validate CSV Data Before Processing
● Ensure that the "Email" column follows a valid email format using regex.
● Ensure that "Phone Numbers" contain exactly 10 digits.
● Print any invalid rows with an error message.*/

using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text.RegularExpressions;
using CsvHelper;


namespace ValidateData
{
    public class ValidateProcess
    {
        public static void Validate()
        {
            List<Candidate> candidates;
            using (var sr = new StreamReader("ValidateData/Details.csv"))
            using (var csv = new CsvReader(sr, CultureInfo.InvariantCulture))
            {
                candidates = csv.GetRecords<Candidate>().ToList();
            }

            string emailPattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
            string phonePattern = @"^\d{10}$";


            foreach (var emp in candidates)
            {
                bool emailValid = Regex.IsMatch(emp.Email, emailPattern);
                bool phoneValid = Regex.IsMatch(emp.Phone, phonePattern);

                if (!emailValid || !phoneValid)
                {
                    Console.WriteLine($"Name : {emp.Name}");

                    if (!emailValid)
                        Console.WriteLine($" Invalid Email : {emp.Email}");

                    if (!phoneValid)
                        Console.WriteLine($" Invalid Phone : {emp.Phone}");

                    Console.WriteLine("----------------------------------");
                }
            }
        }
    }
}