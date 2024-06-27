using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMI
{
    class Function
    {
        

        public double Byte2value(byte[] bytes)
        {
            double value = 0;
            //byte[] temp =new byte[1]{ 0x00}; 


            //temp[0]= bytes[(int)i + 6];
            value = (bytes[6]) * 1 + value;
            value = (bytes[7]) * 256 + value;
            value = (bytes[8]) * 256 * 256 + value;
            value = (bytes[9]) * 256 * 256 * 256 + value;

            return value;
        }


        public byte[] Value2byte(int Value)
        {
            byte[] Temp= new byte[4] {  0x00, 0x00, 0x00, 0x00 };



            Temp[0] = (byte)(Value & 0xff);
            Temp[1] = (byte)((Value & 0xff00) >> 8);
            Temp[2] = (byte)((Value & 0xff0000) >> 16);
            Temp[3] = (byte)((Value & 0xff000000) >> 24);

            return Temp;


        }
    }
}
