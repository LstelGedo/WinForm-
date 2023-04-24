using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 串口助手
{
    public abstract class DecodedData
    {
        public abstract byte[] decodeDataFrame(Queue<byte>buffer);

    }
}
