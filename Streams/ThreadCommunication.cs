/*Piped Streams - Inter-Thread Communication
 Problem Statement: Implement a C# program where one thread
writes data into a PipeStream and another thread reads data from it.
Requirements: Use two threads for reading and writing. Synchronize
properly to prevent data loss. Handle IOException.*/


using System;
using System.IO;
using System.IO.Pipes;
using System.Threading;

namespace Streams
{
    public class ThreadCommunication
    {
        public void Operations()
        {
            try
            {
                var server = new AnonymousPipeServerStream(PipeDirection.Out);
                var client = new AnonymousPipeClientStream(PipeDirection.In, server.ClientSafePipeHandle);

                Thread write = new Thread(() =>
                {
                    using (StreamWriter sw = new StreamWriter(server))
                    {
                        sw.AutoFlush = true;

                        sw.WriteLine("Hello , Good Morning");
                        sw.WriteLine("Hello , Good Evening");


                    }
                });

                Thread read = new Thread(() =>
                {
                    using (StreamReader sr = new StreamReader(client))
                    {
                        string line;
                        while ((line = sr.ReadLine()) != null)
                        {
                            Console.WriteLine(line);
                        }
                    }
                });

                write.Start();
                read.Start();

                write.Join(); // Wait until write thread finish
                read.Join(); // wait until read thread finish


            }
            catch (IOException e)
            {
                Console.WriteLine("IOException : " + e.Message);
            }
        }
    }
}