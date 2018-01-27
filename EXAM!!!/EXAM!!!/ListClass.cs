using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EXAM___
{
    class ListClass : Interface
    {
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

        public string method(int mSize)
        {
            int count = 0;
            for (int i = 0; i < mSize; i++)
            {
                if (24 % list[i] == 0)
                {
                    count++;
                }
            }
            return "" + count;
        }
        public string method(int mSize, bool second)
        {
            int count = 0;
            for (int i = 0; i < mSize; i++)
            {
                if (list[i] > 0 && mSize % list[i] == 0)
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
