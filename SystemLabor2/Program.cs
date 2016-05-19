using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemLabor2
{
    class Program
    {
        static void Main(string[] args)
        {
            int Counter = 1;
            myWorker mw1 = new myWorker(ref Counter);
            Action act = new Action(()=>{
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
