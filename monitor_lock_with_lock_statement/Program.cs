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
    }
}
