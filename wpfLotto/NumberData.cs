using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wpfLotto
{
    public  class NumberData
    {
        private int num_1;
        private int num_2;

        public NumberData()
        {

        }

        public NumberData(int num_1)
        {
            this.num_1 = num_1;
        }

        public int _num_1
        {
            get { return num_1; }
            set { num_1 = value; }
        }

        public int _num_2
        {
            get { return num_2; }
            set { num_2 = value; }
        }

        //public int GetNum_1()
        //{
        //    return num_1;
        //}

        //public void SetNum_1(int _num_1)
        //{
        //    num_1 = _num_1;
        //}

        //public int GetNum_2()
        //{
        //    return num_2;
        //}

        //public void SetNum_2(int _num_2)
        //{
        //    num_2 = _num_2;
        //}
    }
}
