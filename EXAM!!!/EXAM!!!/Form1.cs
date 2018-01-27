using NLog;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;


namespace EXAM___
{
    public static class Extensions : IComparable
    {
        public static void CompareTo(this ListBox.ObjectCollection lb, object d )
        {
            

            for (int i = 0; i < 4; i++)
            {

            }
        }
    }



    public delegate void myDEL();
    public partial class Form1 : Form, IComparable
    {
        MassiveClass MC;
        ListClass LC;
        int size;
        Random rand;
        private event myDEL addMethod1ByEvent;
        private event myDEL addMethod2ByEvent;
        int n=0,m=0;

        public void Sorting(object obj)
        {
            for (int i = 0; i < listBox1.Items.Count; i++)
            {
                listBox1.Items.CompareTo(listBox1.Items[i]);
            }
           

           
        }

        
       private Logger log;

        public void linkToMeth1() {
            Subscr1textBox1.Text = MC.method(size);
        }

        public void linkToMeth2()
        {         
            Subscr2textBox2.Text = MC.method(size,true);
        }

        private void Subscr2button_Click(object sender, EventArgs e)
        {
           
                AddToEvent2(linkToMeth2);
                addMethod2ByEvent();
        }

        private void Subscr1button_Click(object sender, EventArgs e)
        {
            AddToEvent1(linkToMeth1);
            addMethod1ByEvent();
        }
        public void AddToEvent1(myDEL methodize) {
            if (addMethod1ByEvent == null)
            {
                addMethod1ByEvent = new myDEL(methodize);
            }
            else
            {
                addMethod1ByEvent += methodize;
            }
        }
        public void AddToEvent2(myDEL methodize)
        {
            if (addMethod2ByEvent == null)
            {
                addMethod2ByEvent = new myDEL(methodize);
            }
            else
            {
                addMethod2ByEvent += methodize;
            }
          
        }

        public Form1()
        {
            InitializeComponent();
            rand = new Random();
            log = LogManager.GetCurrentClassLogger();
        }

        private void mSizebutton_Click(object sender, EventArgs e)
        {
            size = Convert.ToInt32(masSizetextBox.Text);
            MC = new MassiveClass(size);
            LC = new ListClass(size);
            n = rand.Next(5, 10);
            m = rand.Next(5, 10);
            for (int i = 0; i < n; i++)
            {
                listBox1.Items.Add("элемент массива " + MC.getItems(i));
            }
            for (int i = 0; i < m; i++)
            {
                listBox1.Items.Add("элемент списка " + LC.getItems(i));
            }
        }

        private void method1button_Click(object sender, EventArgs e)
        {                      
            meth1MAStextBox.Text = MC.method(size);
            meth1LISTtextBox.Text = LC.method(size);
        }

        private void method2button_Click(object sender, EventArgs e)
        {          
            meth2MAStextBox.Text = MC.method(size, true);
            meth2LISTtextBox.Text = LC.method(size, true);
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex != -1)
            {
                string selected =(string) listBox1.SelectedItem;
                string[] selectedS = selected.Split(' ');
                if (selectedS[1] == "массива")
                {
                    TESTtextBox.Text = "massive";
                }
                else if (selectedS[1] == "списка")
                {
                    TESTtextBox.Text = "list";
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
         if (addMethod1ByEvent != null)
            {
                addMethod1ByEvent = null;
            }     

//            UnsubscribeToEvent1(AfterUnsubscribelinkToMeth1);  no need
         
            log.Info("UNSUBSCRIBE!!!");
        }

        public void UnsubscribeToEvent1(myDEL methodize)
        {
                 
        }
        public void UnsubscribeToEvent2(myDEL methodize)
        {
            if (addMethod2ByEvent != null)
            {
                addMethod2ByEvent -= methodize;
            }  
        }

        private void Unsubscr2button2_Click(object sender, EventArgs e)
        {
            UnsubscribeToEvent2(linkToMeth2);
            addMethod2ByEvent();
        }

        public void AfterUnsubscribelinkToMeth1()
        {          
            UNsubscr1textBox1.Text = MC.method(size);
            log.Info("UNSUBSCRIBE!!!");
        }

        private void SAVEtoFILE_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                string fileName = saveFileDialog1.FileName;               
                using(FileStream fs = new FileStream(fileName,FileMode.Create)){
                    using (BufferedStream bs = new BufferedStream(fs))
                    {
                        byte[] info = new UTF8Encoding(true).GetBytes("имя класса: массив" + Environment.NewLine);
                        fs.Write(info, 0, info.Length);
                        for (int i = 0; i < n; i++)
                        {
                            info = new UTF8Encoding(true).GetBytes(listBox1.Items[i].ToString() + Environment.NewLine);
                            fs.Write(info, 0, info.Length);
                        }
                        info = new UTF8Encoding(true).GetBytes("результат 1 метода" + meth1MAStextBox.Text + Environment.NewLine);
                        fs.Write(info, 0, info.Length);

                    }
                }
               
            }
            log.Info("WRITTEN!!!");
        }

        public void errors()
        {
            try { }
            catch(LessThan10Exception ex) {
                MessageBox.Show(ex.Message, "less", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        

        
    }
}
