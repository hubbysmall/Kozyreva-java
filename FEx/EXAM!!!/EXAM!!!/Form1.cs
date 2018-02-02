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
    


    public delegate string delFor1meth();
    public delegate string delFor2meth(int val);
    public partial class Form1 : Form
    {
       
        int size;
        Random rand;
        MassiveClass MC;
        ListClass LC;
        private event delFor1meth addMethod1ByEvent;
        private event delFor2meth addMethod2ByEvent;
        int n=0,m=0;
        List<Interface> listForLBox;

        public void Sorting(object obj)
        {
            for (int i = 0; i < listBox1.Items.Count; i++)
            {
              
            }
           

           
        }
   
       private Logger log;
        private void Subscr2button_Click(object sender, EventArgs e)
        {  
            if ( MC!=null){
 //               AddToEvent2(MC.method);
                AddToEvent2(listForLBox[listBox1.SelectedIndex].method);           
            }

            else
            {
 //               AddToEvent2(LC.method);
                AddToEvent2(listForLBox[listBox1.SelectedIndex].method);
            }
                
        }

        private void Subscr1button_Click(object sender, EventArgs e)
        {
            if (MC != null){
  //              AddToEvent1(MC.method);
                AddToEvent1(listForLBox[listBox1.SelectedIndex].method); 
            }


            else
            {
 //               AddToEvent1(LC.method);
                AddToEvent1(listForLBox[listBox1.SelectedIndex].method); 
            }
                
        //теперь любой вызов события приведет к вызову этого метода
        }
        public void AddToEvent1(delFor1meth methodize)
        {
            if (addMethod1ByEvent == null)
            {
                addMethod1ByEvent = new delFor1meth(methodize);
            }
            else
            {
                addMethod1ByEvent += methodize;
            }
        }
        public void AddToEvent2(delFor2meth methodize)
        {
            if (addMethod2ByEvent == null)
            {
                addMethod2ByEvent = new delFor2meth(methodize);
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
            n = rand.Next(5, 10);
            m = rand.Next(5, 10);           
            // не забыть про обычные MC LC  --- нет! методы применяются для m+n MC и LC в listbox
            listForLBox = new List<Interface>();
            for (int i = 0; i < n; i++)
            {
                MassiveClass MC1 = new MassiveClass(size); 
//                listBox1.Items.Add(MC);
                listForLBox.Add(MC1);
            }
            for (int i = 0; i < m; i++)
            {
                ListClass LC1 = new ListClass(size);
//                listBox1.Items.Add(LC);
                listForLBox.Add(LC1);
            }
            for (int i = 0; i < listForLBox.Count; i++)
            {
                
              listBox1.Items.Add(listForLBox[i]+""+i);
            }
            listForLBox.Sort();
           
        }

        private void method1button_Click(object sender, EventArgs e)
        {                      
//            meth1MAStextBox.Text = MC.method();
 //           meth1LISTtextBox.Text = LC.method();
            addMethod1ByEvent();
        }

        private void method2button_Click(object sender, EventArgs e)
        {          
 //           meth2MAStextBox.Text = MC.method(size);
//            meth2LISTtextBox.Text = LC.method(size);
            addMethod2ByEvent(size);
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            MC = null;
            LC = null;
            if (listBox1.SelectedIndex != -1)
            {
                
                string selected =(string) listBox1.SelectedItem;
                string[] selectedS = selected.Split('.');
                if (selectedS[1].StartsWith("MassiveClass"))
                {

                    TESTtextBox.Text = "massive" + selectedS[1][selectedS[1].Length - 1];
                    MC = listForLBox[listBox1.SelectedIndex] as MassiveClass;
                    string fr = "";
                }
                else if (selectedS[1].StartsWith("ListClass"))
                {
                    TESTtextBox.Text = "list" + listBox1.SelectedIndex;
                    LC = listForLBox[listBox1.SelectedIndex] as ListClass;
                    string r = "";
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
         if (addMethod1ByEvent != null)
            {
               addMethod1ByEvent = null;
                log.Info("UNSUBSCRIBE from event1!!!");
            }         
        }

        public void UnsubscribeToEvent1()
        {
                 
        }
        public void UnsubscribeToEvent2()
        {
            if (addMethod2ByEvent != null)
            {
                addMethod2ByEvent = null;
                log.Info("UNSUBSCRIBE from event2!!!");

            }  
        }

        private void Unsubscr2button2_Click(object sender, EventArgs e)
        {
            UnsubscribeToEvent2();     
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

        private void Sortbutton_Click(object sender, EventArgs e)
        {
            string f = "";
            listForLBox.Sort();
            string g = "";
            for (int i = 0; i < listForLBox.Count; i++)
            {

                listBox1.Items.Add(listForLBox[i] + "element " + i);
            }

        }

        

        
    }
}
