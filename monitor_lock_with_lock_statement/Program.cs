/*
 * C# Program to Illustrate the Use of Monitor Lock with Lock Statement
 */
using System;
using System.IO;
using System.Threading;

namespace monitor_lock_with_lock_statement
{
    class Program
    {
        static object locker = new object();
        static void ThreadMain()
        {
            Thread.Sleep(800);    // Simulate Some work
            WriteToFile();
        }

        static void WriteToFile()
        {
            String ThreadName = Thread.CurrentThread.Name;
            Console.WriteLine("{0} USING LOCKS", ThreadName);
            Monitor.Enter(locker);
            try
            {
                using (StreamWriter sw = new StreamWriter(@"D:\srip\sri.txt", true))
                {
                    sw.WriteLine(ThreadName);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                Monitor.Exit(locker);
                Console.WriteLine("{0} Releasing LOCKS", ThreadName);
            }
        }

        static void Main(string[] args)
        {
            for (int i = 0; i < 3; i++)
            {
                Thread thread = new Thread(new ThreadStart(ThreadMain));
                thread.Name = String.Concat("Thread - ", i);
                thread.Start();

            }
            Console.Read();
        }
    }
}
