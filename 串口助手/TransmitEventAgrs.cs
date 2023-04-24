using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 串口助手
{
    //委托
    public delegate void TransmitData(byte[] data);

    public delegate void TransmitEventHandler(object sender, TransmitEventAgrs e);

    public class TransmitEventAgrs:EventArgs
    {

        
        public byte[] data{ get; set; }   
    }
}
