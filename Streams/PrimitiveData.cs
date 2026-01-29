/*Data Streams - Store and Retrieve Primitive Data
Problem Statement: Write a C# program that stores student details
(roll number, name, GPA) in a binary file and retrieves it later.
Requirements: Use BinaryWriter to write primitive data. Use
BinaryReader to read data. Ensure proper closing of resources.*/

using System;
using System.IO;

namespace Streams
{
    public class PrimitiveData
    {
        public void Perform()
        {
            Console.WriteLine("Enter Roll No. : ");
            string roll = Console.ReadLine();

            Console.WriteLine("Enter Name : ");
            string name = Console.ReadLine();

            Console.WriteLine("Enter GPA : ");
            double gpa = Convert.ToDouble(Console.ReadLine());

            using (FileStream fs = new FileStream("Detail.bin", FileMode.Create))
            using (BinaryWriter bw = new BinaryWriter(fs))
            {
                bw.Write(name);
                bw.Write(roll);
                bw.Write(gpa);
            }


            using (FileStream fs = new FileStream("Detail.bin", FileMode.Open))
            using (BinaryReader br = new BinaryReader(fs))
            {
                string Name = br.ReadString();
                string Roll = br.ReadString();
                double GPA = br.ReadDouble();


                Console.WriteLine($"Name : {Name}  Roll : {Roll}  GPA : {GPA}");
            }




        }
    }
}