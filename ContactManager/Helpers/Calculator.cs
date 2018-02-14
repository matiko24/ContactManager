using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactManager.Helpers
{
    public class Calculator
    {

        public int Add(params int[] liczba)
        {
            return liczba.Sum();
        }
    }
}
