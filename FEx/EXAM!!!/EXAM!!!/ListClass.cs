using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EXAM___
{
    class ListClass : Interface, IComparable
    {
        public int getMaxnumberInMas()
        {
            return this.list.Max();

        }
        public int CompareTo(object obj)
        {
            if (obj is ListClass)
            {
                var LC = obj as ListClass;
                return this.getMaxnumberInMas().CompareTo(LC.getMaxnumberInMas());
            }
            else if (obj is MassiveClass)
            {
                var LC = obj as MassiveClass;
                return this.getMaxnumberInMas().CompareTo(LC.getMaxnumberInMas());
            }
            else throw new Exception("Unable to compare");
        }
        protected List<int>list;

        public int getItems(int i)
        {
            return list[i];
        }

        public ListClass(int mSize)
        {
            Random rand = new Random();
            if (mSize < 10)
            {
                mSize = rand.Next(10, 20);
            }
            list = new List<int>(mSize);
            for (int i = 0; i < mSize; i++)
            {
                list.Add(rand.Next(1, 100));
            }
        }

        public string method()
        {
            int count = 0;
            for (int i = 0; i < list.Count; i++)
            {
                if (24 % list[i] == 0)
                {
                    count++;
                }
            }
            return "" + count;
        }
        public string method(int value)
        {
            int count = 0;
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i] > 0 && value % list[i] == 0)
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
                return list[index];
            }
        }
    }
}
