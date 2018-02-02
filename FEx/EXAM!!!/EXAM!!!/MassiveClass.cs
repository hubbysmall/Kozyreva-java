using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EXAM___
{
    class MassiveClass: Interface, IComparable
    {
        public int getMaxnumberInMas()
        {
            return this.mas.Max();
            
        }
        public int CompareTo(object obj)
        {
            if (obj is MassiveClass)
            {
                var MC = obj as MassiveClass;
                return this.getMaxnumberInMas().CompareTo(MC.getMaxnumberInMas());
            }
            else if (obj is ListClass)
            {
                var LC = obj as ListClass;
                return this.getMaxnumberInMas().CompareTo(LC.getMaxnumberInMas());
            }
            else throw new Exception("Unable to compare");               
        }
        protected int[] mas;

        public void likeEventMeth1(string s)
        {

        }

        public int getItems(int i){
            return mas[i];
        }

        public MassiveClass(int mSize)
        {
            if (mSize < 10)
            {
                throw new LessThan10Exception();
            }
            Random rand = new Random();
            if (mSize < 10)
            {
                mSize = rand.Next(10, 20);
            }
            mas = new int[mSize];
            for (int i = 0; i < mas.Length; i++)
            {
                mas[i] = rand.Next(1, 100);
            }
        }

        public string method()
        {          
            int count = 0;
            for (int i = 0; i < mas.Length; i++)
            {
                if (24 % mas[i] == 0)
                {
                    count++;
                }
            }
            return "" + count;
        }
       public string method(int value)
        {         
            int count = 0;
            for (int i = 0; i < mas.Length; i++)
            {
                if (mas[i] > 0 && value % mas[i] == 0)
                {
                    count++;
                }
            }
            return "" + count;
        }
        public int this[int index]
        {
            get
            {
                return mas[index];
            }
        }
    }
}
