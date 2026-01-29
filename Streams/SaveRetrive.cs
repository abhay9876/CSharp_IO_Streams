/*Serialization - Save and Retrieve an Object
Problem Statement: Design a C# program that allows a user to store
a list of employees in a file using Object Serialization and later retrieve
the data from the file.
Requirements: Create an Employee class with fields: id, name,
department, salary. Serialize the list of employees into a file
(BinaryFormatter / JSON Serialization). Deserialize and display the
employees from the file. Handle exceptions properly.
*/

using System;
using System.IO;
using System.Text.Json;

namespace Streams
{
    public class SaveRetrive
    {
        public void Operations()
        {
            try
            {
                List<Employee> list = new List<Employee>();

                Console.Write("Number of Employee :  ");
                int n = int.Parse(Console.ReadLine());

                for (int i = 0; i < n; i++)
                {
                    Employee e = new Employee();

                    Console.Write("Id: ");
                    e.Id = int.Parse(Console.ReadLine());

                    Console.Write("Name: ");
                    e.Name = Console.ReadLine();

                    Console.Write("Department: ");
                    e.Department = Console.ReadLine();

                    Console.Write("Salary: ");
                    e.Salary = double.Parse(Console.ReadLine());

                    list.Add(e);
                }

                // Serialize (Save)
                string json = JsonSerializer.Serialize(list);
                File.WriteAllText("employees.json", json);
                Console.WriteLine("Data Saved.");

                // Deserialize (Read)
                string data = File.ReadAllText("employees.json");
                List<Employee> newList = JsonSerializer.Deserialize<List<Employee>>(data);

                foreach (var emp in newList)
                {
                    Console.WriteLine($"{emp.Id}  {emp.Name}  {emp.Department}  {emp.Salary}");
                }
            }
            catch (IOException e)
            {
                Console.WriteLine("IOException : " + e.Message);
            }
        }
    }
}