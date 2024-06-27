using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMI
{
    class Status
    {
        

        public int[] Status_analysis( string status_0)
        {
            int[] status =new int[16] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,0 };
            string b;
            
            b = Convert.ToString(Convert.ToInt32(status_0), 2);

            for (int i = 0; i < b.Length; i++)
            {

                status[b.Length - 1 - i] = Convert.ToInt32(b.Substring(i, 1));


            }
            return status;
        }

    }
}
