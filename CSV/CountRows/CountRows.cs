/*Read and Count Rows in a CSV File
● Read a CSV file and count the number of records (excluding the header row).*/


using System;
using System.IO;

namespace CSV
{
    class CountRows
    {
        public static void Perform()
        {

            try
            {
                int count = 0;
                using (StreamReader sr = new StreamReader("CountRows/Data.csv"))
                {
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        count++;
                    }
                }

                Console.WriteLine(" Total rows : " + count);
            }
            catch (IOException e)
            {
                Console.WriteLine("IO Exception : " + e.Message);
            }
        }
    }
}