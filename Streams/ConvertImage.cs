/*ByteArray Stream - Convert Image to ByteArray
Problem Statement: Write a C# program that converts an image file
into a byte array and then writes it back to another image file.
Requirements: Use MemoryStream to handle byte arrays. Verify that the
new file is identical to the original image. Handle IOException.*/

using System;
using System.IO;

namespace Streams
{
    public class ConvertImage
    {
        public void Operation()
        {
            string sourceImage = "input.jpg";
            string outputImage = "output.jpg";
            try
            {
                byte[] imageBytes = File.ReadAllBytes(sourceImage);

                using (MemoryStream ms = new MemoryStream(imageBytes))
                {
                    File.WriteAllBytes(outputImage, ms.ToArray());
                }

                FileInfo source = new FileInfo(sourceImage);
                FileInfo output = new FileInfo(outputImage);

                if (source.Length == output.Length)
                {
                    Console.WriteLine("Matched...");
                }
                else
                {
                    Console.WriteLine("Mismatched...");
                }
            }
            catch (IOException e)
            {
                Console.WriteLine("IOException : " + e.Message);
            }
        }
    }
}