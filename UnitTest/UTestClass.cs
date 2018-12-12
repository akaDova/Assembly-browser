using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTest
{
    class UTestClass
    {
        public int number = 5;
        public int NumberPlusFive
        {
            get => number + 5;
            set => number = value;
        }

        public void DoNothing()
        {

        }

        public override string ToString()
        {
            return base.ToString();
        }

        private bool Check()
        {
            return number == NumberPlusFive;
        }
    }
}
