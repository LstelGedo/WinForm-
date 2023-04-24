using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 串口助手
{
    public class MobusDecodedDataFrame : DecodedData
    {
        public override byte[] decodeDataFrame(Queue<byte> buffer)
        {
            //modbus的实现

            //throw new NotImplementedException();
            return null;
        }
    }
}
