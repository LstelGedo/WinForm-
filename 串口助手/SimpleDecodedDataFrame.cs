using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;

namespace 串口助手
{
    public class SimpleDecodedDataFrame : DecodedData
    {

        private bool isHeadRecive = false;
        private byte frameLenth;
        private bool frameCheckOk = false;

        public override byte[] decodeDataFrame(Queue<byte> bufferQueue)
        {

            //具体实现算法解析数据 并返回帧或空
            //首先判断是否位空
            if (isHeadRecive == false)
            {
                foreach (byte item in bufferQueue.ToArray())
                {
                    if (item != 0x7f)
                    {
                        //出列
                        bufferQueue.Dequeue();
                        Console.WriteLine("not 0x7f,Dequeue !!");
                    }
                    else
                    {
                        //get 0x7f from bufferQueue
                        isHeadRecive = true;
                        Console.WriteLine("0x7f is recived !!");
                        break;
                    }
                }
            }
            //在数据帧头存在的时候就判断长度
            if (isHeadRecive == true)
            {
                //判断有数据帧长度
                if (bufferQueue.Count >= 2)
                {
                    Console.WriteLine(DateTime.Now.ToLongTimeString());
                    Console.WriteLine($"show the data in bufferQueue{Transform.ToHexString(bufferQueue.ToArray())}");
                    Console.WriteLine($"frame lenth ={String.Format("{0:X2}", bufferQueue.ToArray()[1])}");
                    frameLenth = bufferQueue.ToArray()[1];

                    //一帧完整的数据长度判断，不代表数据是正确的
                    if (bufferQueue.Count >= 1 + 1 + frameLenth + 2)
                    {
                        byte[] frameBuffer = new byte[1 + 1 + frameLenth + 2];

                        //将buff数组从第0位拷贝到framebuff的第0位开始-数据长度邓毅frameBuffer的长度
                        Array.Copy(bufferQueue.ToArray(), 0, frameBuffer, 0, frameBuffer.Length);

                        //数据校验
                        if (crc_chech(frameBuffer))
                        {
                            Console.WriteLine("frame is check ok,pick it");
                            frameCheckOk = true;
                        }
                        else
                        {
                            // 无效数据
                            Console.WriteLine("bad frame, drop it");
                            for (int i = 0; i < 1 + 1 + frameLenth + 2; i++)
                            {
                                bufferQueue.Dequeue();
                            }
                        }
                        if (frameCheckOk)
                        {

                            frameCheckOk = false;
                            return frameBuffer;
                        }


                     }
                 }
             }
             //throw new NotImplementedException();
             return null;
            

        }
        //解析帧
        private bool crc_chech(byte[] frameBuffer)
        {
            /*
                大端模式:是指数据的高字节保存在内容的低地址中，
                    而数据的低字节保存在内存的高地址中，这样的存储模式有点儿类
                类似于吧数据当做字符串处理顺序：地址由小向大增加而数据从高位往
            低位放：这和我们阅读习惯一致。

                小端模式：是指数据的高字节保存在内存的高地址中，
            而数据的低字节保存在内存的低地址中，这种存储模式将地址的高低和数据位权
            有效的结合起来，高地址部分权高，低地址部分权低。
             */

            bool ret = false;

            byte[] temp = new byte[frameBuffer.Length - 2];
            Array.Copy(frameBuffer, 0, temp, 0, temp.Length);
            byte[] crcdata = DataCheck.DataCrc16_Ccitt(temp, DataCheck.BigOrLittle.BigEndian);
            if (crcdata[0] == frameBuffer[frameBuffer.Length - 2] &&
                crcdata[1] == frameBuffer[frameBuffer.Length - 1])
            {
                // check ok
                ret = true;
            }

            return ret;
        }
    }
}
