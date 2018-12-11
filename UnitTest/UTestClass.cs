using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTest
{
    class UTestClass
    {
        int number;
        int NumberPlusFive
        {
            get => number + 5;
            set => number = value;
        }

        void DoNothing()
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
