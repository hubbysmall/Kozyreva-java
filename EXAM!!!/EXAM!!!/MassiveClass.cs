using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EXAM___
{
    class MassiveClass: Interface
    {
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

        public string method(int mSize)
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
       public string method(int mSize, bool second)
        {         
            int count = 0;
            for (int i = 0; i < mas.Length; i++)
            {
                if (mas[i] > 0 && mSize % mas[i] == 0)
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
