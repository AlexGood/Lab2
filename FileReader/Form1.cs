using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace FileReader
{
    public partial class Form1 : Form
    {
        private FileIO worker;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                this.listBox1.Items.Clear();
                Semaphore pool = new Semaphore(1, 1);
                worker = new FileIO() { Pool = pool, parent = this };
                Task writeTask = new Task(new Action(() => { worker.writeToFile(); }));
                Task readTask = new Task(new Action(() => { worker.readFromFile(); }));
                writeTask.Start();
                readTask.Start();
                button1.Enabled = false;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void insertValue(string val)
        {
            this.listBox1.Items.Add(val);
        }
        public void activateButton()
        {
            this.button1.Enabled = true;
        }
        public void SendMessage(string text)
        {
            MessageBox.Show(text);
        }

    }
}
