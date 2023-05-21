using System;
using System.Threading;

namespace AutoReset
{
    class Program
    {
        const int THREADS_COUNT = 5;
        static void Main()
        {
            AutoResetEvent evnt = new AutoResetEvent(false);
            for (int i = 0; i < THREADS_COUNT; i++)
            {
                OneWhoWaits oww = new OneWhoWaits(evnt, (i + 1) * 500);
                Thread thread = new Thread(new ThreadStart(oww.PerformSomeTask));
                thread.Start();
            }
            Thread.Sleep(100);
            for (int i = 0; i < THREADS_COUNT; i++)
            {
                Console.WriteLine("\nPress [Enter] to signal the Reset" + "Event.");
            }
        }
    }

}
