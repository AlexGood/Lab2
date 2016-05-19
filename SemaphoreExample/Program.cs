using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace SemaphoreExample
{
    class Program
    {
        static void Main(string[] args)
        {
            //два потока свободны. два максимум
            Semaphore pool = new Semaphore(2, 2);
            int Counter = 1;
            //объекты передаются по ссылке, в отличии от int 
            myWorker mw1 = new myWorker(ref Counter, pool);
            Action act = new Action(() =>
            {
                mw1.doWork();
            });
            Task task1 = new Task(act);
            Task task2 = new Task(act);
            Task task3 = new Task(act);
            task1.Start();
            task2.Start();
            task3.Start();
            Console.ReadLine();
        }
    }
}
