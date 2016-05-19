using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace SystemLabor2
{
    public class myWorker
    {
        private int _counter;
        public myWorker(ref int counter)
        {
            this._counter = counter;
          
        }
        public void doWork()
        {
            /* Без данной конструкции lock потоки получают возможность асинхронно изменять значение счетчика. 
             * Ключевое слово lock не позволит ни одному потоку войти в важный раздел кода в тот момент, 
             * когда в нем находится другой поток. При попытке входа другого потока в заблокированный код 
             * потребуется дождаться снятия блокировки объекта. Ключевое слово lock вызывает Enter в начале 
             * блока и Exit в конце блокa.  
            */
            lock (this)
            {
                for (int i = 0; i < 10; i++)
                    Console.WriteLine("Поток " + Thread.CurrentThread.ManagedThreadId + " увеличил счетчик. Счетчик равен " + _counter++);
            }
        }
    }
}
