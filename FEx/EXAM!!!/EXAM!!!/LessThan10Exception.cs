using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EXAM___
{
    class LessThan10Exception: Exception
    {
        public LessThan10Exception() : base("Less than 10") { }
    }
}
