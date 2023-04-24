using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace 串口助手
{
    public class DecodedDataContext
    {
        private DecodedData dd;

        public DecodedDataContext(DecodedData dd)
        {
            this.dd = dd;
        }

        public byte[] getDataFrames(Queue<byte> bufferQueue)
        {
            return dd.decodeDataFrame(bufferQueue);
        }
    }
}
