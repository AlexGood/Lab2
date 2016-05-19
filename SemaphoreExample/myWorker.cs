using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace SemaphoreExample
{
    public class myWorker
    {
        private Semaphore _pool;
        private int _counter;
        public myWorker(ref int counter, Semaphore pool)
        {
            this._counter = counter;
            this._pool = pool;
        }

        /* В данном примере у семафора есть максимально два синхронно работающих потока. Методом WaitOne 
         * он уменьшает количество счетчика на 1, а Release увеличивает его на 1. Если внутренний счетчик
         * семафора равен 0, то потоки больше не могут войти в помеченную область. В данной программе 
         * 10 раз инкрементировать счетчик может только два потока одновременно. Третий же будет ждать, пока 
         * хотя бы один не закончит работу. 
         * 
         * */
        public void doWork()
        {
            _pool.WaitOne();
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine("Поток " + Thread.CurrentThread.ManagedThreadId + " отработал. Значение счетчика =" + _counter++);
                Thread.Sleep(500);
            }
            _pool.Release(1);
        }
    }
}
