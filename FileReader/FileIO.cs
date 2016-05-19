using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.IO;

namespace FileReader
{
    public class FileIO
    {
        public Semaphore Pool{ get; set; }
        public Form1 parent { get; set; }
        private StreamReader sr;
        private StreamWriter sw;
        public void readFromFile()
        {
            try
            {
                Pool.WaitOne();
                sr = new StreamReader("myfile.txt");
                String line;
                parent.Invoke(new Action(() => { parent.SendMessage("Началось чтение из файла"); }));
                while ((line = sr.ReadLine()) != null)
                {
                    parent.Invoke(new Action(() =>
                    {
                        parent.insertValue(line);
                    }));
                    Thread.Sleep(100);
                }
                parent.Invoke(new Action(() =>
                {
                    parent.activateButton();
                }));
            }
            catch(Exception ex)
            {
                throw ex;
            }
            finally 
            {
                sr.Close();
                Pool.Release();
            }
        }

        public void writeToFile()
        {
            try
            {
                Pool.WaitOne();
                sw = new StreamWriter("myfile.txt", false);
                parent.Invoke(new Action(() => { parent.SendMessage("Началась запись в файл"); }));
                for(int i=1; i<=10; i++)
                {
                    sw.WriteLine(i);
                    Thread.Sleep(500);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                sw.Close();
                Pool.Release();
            }
        }
    }
}
