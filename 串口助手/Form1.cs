using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 串口助手
{
    public partial class Form1 : Form
    {
        //启动\关闭按钮
        private bool isOpen = false;

        //用于暂停接收
        private bool isRxShow = true;

        //缓存区用户编码转换
        private List<byte> reciveBuffer = new List<byte>();

        //定义接收管理器
        private List<byte>sendBuffer = new List<byte>();

        private int reciveCount = 0;

        //用于数据帧接收
        private Queue<byte> bufferQueue = null;

        //用于帧头数据
        private bool isHeadRecive = false;

        //用于缓存帧长度
        private int frameLenth = 0;

        //发送计数
        private int sendCount = 0;

        //委托
        public TransmitData TransmitData;

        public event TransmitEventHandler TransmitData2;

        public DecodedDataContext ddc;

        public string strRead { get; private set; }

        public Form1()
        {
            this.StartPosition = FormStartPosition.CenterScreen;
            
            InitializeComponent();


            //CheckForIllegalCrossThreadCalls取消线程安全保护
            Control.CheckForIllegalCrossThreadCalls = false;
            
        }

        //页面加载事件
        private void Form1_Load(object sender, EventArgs e)
        {
            serialLoad();

            //实例化
            bufferQueue = new Queue<byte>();

            Form2 fr2 = new Form2();

            //接收数据委托窗体2 ReciveData 执行显示
          //  TransmitData = fr2.ReciveData;
            TransmitData2 += new TransmitEventHandler(fr2.ReciveData2);

            //窗体2发送委托窗体1 sendBytes 执行发送
            //fr2.useForlSend += sendBytes;

            //接收数据事件窗体2 ReciveData执行显示
            fr2.useForm1send2 += new TransmitEventHandler(sendbytes2);
            //fr2.Show();

            //数据解析
            ddc = new DecodedDataContext(new SimpleDecodedDataFrame());

        }

        private void sendbytes2(object sender, TransmitEventAgrs e)
        {
            serialPort1.Write(e.data, 0, e.data.Length);
            sendCount += e.data.Length;
            sencount_tssl.Text = sendCount.ToString();
        }

        //子页面委托方法
        private void sendBytes(byte[] data)
        {
            serialPort1.Write(data, 0, data.Length);
            sendCount += data.Length;
            sencount_tssl.Text = sendCount.ToString();
        }


        //打开串口
        private void open_btn_Click(object sender, EventArgs e)
        {
            try
            {
                //判断是否打开
                if (serialPort1.IsOpen == false)
                {
                    serialPort1.PortName = port_cbb.Text;
                    serialPort1.BaudRate = Convert.ToInt32(baud_cdd.Text);
                    serialPort1.DataBits = Convert.ToInt32(databit_cbb.Text);

                    switch (check_cbb.SelectedIndex) 
                    {
                        case 0:
                            serialPort1.Parity = Parity.None;
                            break;

                        case 1:
                            serialPort1.Parity = Parity.Odd;
                            break;

                        case 2:
                            serialPort1.Parity = Parity.Even;
                            break;
                        
                        
                        default:
                            serialPort1.Parity = Parity.None;
                            break;
                    }


                    switch (stopbit_cbb.SelectedIndex)
                    {
                        case 0:
                            serialPort1.StopBits = StopBits.One;
                            break;

                        case 1:
                            serialPort1.StopBits = StopBits.OnePointFive;
                            break;

                        case 2:
                            serialPort1.StopBits = StopBits.Two;
                            break;

                        default:
                            serialPort1.StopBits = ~StopBits.One;
                            break;
                    }

                    //启动串口
                    serialPort1.Open();
                    
                    //按钮状态
                    isOpen = true;
                    open_btn.Text = "关闭串口";
                    
                    MessageBox.Show("端口号:" + serialPort1.PortName + "启动完成");

                }
                else
                {
                    serialPort1.Close();
                    isOpen = false;
                    MessageBox.Show("端口号:" + serialPort1.PortName + "已经关闭");
                    open_btn.Text = "启动串口";

                }                
            }
            catch (Exception ex)
            {
                
                MessageBox.Show(ex.ToString()+serialPort1.PortName.ToString());
            }
        }


        //启动项
        private void serialLoad()
        {

            //获取计算机支持的编码格式
            EncodingInfo[] encodingInfos = Encoding.GetEncodings();


            //本地注册表编辑器地址（虚拟串口）：计算机\HKEY_LOCAL_MACCHINE\HARDWARE\DEVICEMAP\SERIALCOMM
            //获取端口号：注册列表中获取信息
            //继承注册列表Registry
            RegistryKey keyCom = Registry.LocalMachine.OpenSubKey(@"Hardware\DeviceMap\SerialComm");

            string[] sSubKeys = keyCom.GetValueNames();

            port_cbb.Items.Clear();

            foreach (var sValue in sSubKeys) 
            {
                string portName = (string)keyCom.GetValue(sValue);
                port_cbb.Items.Add(portName);
            }


            //默认显示
            //排序方式默认0开始
            //端口号
            this.port_cbb.SelectedIndex = 0;

            //波特率
            this.baud_cdd.SelectedIndex = 1;

            //校验位
            this.check_cbb.SelectedIndex = 0;

            //数据位
            this.databit_cbb.SelectedIndex = 3;

            //停止位
            this.stopbit_cbb.SelectedIndex = 0;
        }


        private void sendData() 
        {
            //将serialPort的内容发送出去
            serialPort1.Write(sendBuffer.ToArray(),0,sendBuffer.Count);
            sendCount += sendBuffer.Count;
            recivecount_tssl.Text = sendCount.ToString();

        }

        //手动发送
        private void send_btn_Click(object sender, EventArgs e)
        {

            //发送是判断串口是否启动serialPort.IsOpne
            if (serialPort1.IsOpen == false)
            {                
                MessageBox.Show("请打开串口在发送数据");
                return;
            }


            //判断发送的数据是否为空
            if (this.send_rtb.Text != "")
            {
                //serialPort1.Write(send_rtb.Text);
                Console.WriteLine(Transform.ToHexString(sendBuffer.ToArray()));
                sendData();
            }
            else 
            {
                MessageBox.Show("请输入要发送的数据");
            }
        }

        private void serialPort1_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            if (isRxShow == false)
            {
                MessageBox.Show("对方已暂停接收，无法发送");
                return;
            }

            //读取所有的数据ReadExisting();
            //string dataRecive = serialPort1.ReadExisting();
            //添加数据
            //reclve_rtb.AppendText(dataRecive);

            //将串口数据读取出来
            byte[] dataTemp = new byte[serialPort1.BytesToRead];
            serialPort1.Read(dataTemp,0, dataTemp.Length);

            //读取到数据后转换到List中（缓存区）
            reciveBuffer.AddRange(dataTemp);

            //记录长度（用于更新记录接收记录）
            reciveCount += dataTemp.Length;


            
            //委托-用于将主页面的内容委托到子页面
            //  ?. 如果taansmintData  != null就执行
            //TransmitData?.Invoke(dataTemp);

            //TransmitData2?.Invoke(this, new TransmitEventAgrs { data = dataTemp });


            //异步线程更新
            this.Invoke(new EventHandler(delegate 
            {

                //更新接收次数
                recivecount_tssl.Text = reciveCount.ToString();


                //判断是否勾选数据帧接收
                if (startData_chb.Checked == false)
                {
                    //判断是否是16进制
                    if (!recuvehex_chb.Checked)
                    {
                        //获取字符串string
                        string str = Encoding.GetEncoding("gb2312").GetString(dataTemp);

                        // 0x00 -> \0 结束 不会显示

                        //转译
                        str = str.Replace("\0", "\\0");

                        reclve_rtb.AppendText(str);

                        //方法一致二选一
                        //reclve_rtb.AppendText(Encoding.GetEncoding("gb2312").GetString(dataTemp).Replace("\0", "\\0"));
                    }
                    else
                    {
                        //当16进制是选中的姿态下
                        //将接收到的dataTemp转换到16进制
                        reclve_rtb.AppendText(Transform.ToHexString(dataTemp, " "));


                    }
                }

                else
                {
                    //解析数据  queue
                    //将dataTemp的数据处方到队列中
                    foreach (byte item in dataTemp)
                    {
                        //入列
                        bufferQueue.Enqueue(item);
                    }

                    //获取帧数据
                    byte[] frameData = ddc.getDataFrames(bufferQueue);
                    if (frameData != null)
                    {
                        Console.WriteLine($"show the data in frameData{Transform.ToHexString(frameData)}");
                        data_txb.Text = Transform.ToHexString(frameData);
                        data1_txb.Text = String.Format("{0:X2}", frameData[2]);
                        data2_txb.Text = String.Format("{0:X2}", frameData[3]);
                        data3_txb.Text = String.Format("{0:X2}", frameData[4]);
                        data4_txb.Text = String.Format("{0:X2}", frameData[5]);

                        for (int i = 0; i < frameData.Length; i++)
                        {
                            bufferQueue.Dequeue();

                        }   
                    }
#if old
                    //解析获取帧头
                    //判断是否存在帧头数据
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
                            if (bufferQueue.Count >=1+1+frameLenth +2)
                            {
                                byte[] frameBuffer = new byte[1 + 1 + frameLenth + 2];

                                //将buff数组从第0位拷贝到framebuff的第0位开始-数据长度邓毅frameBuffer的长度
                                Array.Copy(bufferQueue.ToArray(), 0, frameBuffer, 0, frameBuffer.Length);

                                //数据校验
                                if (crc_chech(frameBuffer))
                                {
                                    Console.WriteLine("frame is check ok,pick it");
                                    data_txb.Text = Transform.ToHexString(frameBuffer);
                                    data1_txb.Text = String.Format("{0:X2}", frameBuffer[2]);
                                    data2_txb.Text = String.Format("{0:X2}", frameBuffer[3]);
                                    data3_txb.Text = String.Format("{0:X2}", frameBuffer[4]);
                                    data4_txb.Text = String.Format("{0:X2}", frameBuffer[5]);
                                }
                                else
                                {
                                    //无效数据直接跳过-提示
                                    Console.WriteLine("bad frame,drop it");
                                }

                                for (int i = 0; i < 1+frameLenth+2; i++) 
                                {
                                    bufferQueue.Dequeue();
                                    
                                }
                                isHeadRecive = false;
                            }

                        }
                        
                        //长度不正确的时候继续接收数据

                    }
#endif


                }



            }));


            //MessageBox.Show("端口号："+serialPort1.PortName+"已发送数据："+dataRecive);
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





        //暂停
        private void stop_btn_Click(object sender, EventArgs e)
        {
            if (isRxShow == true)
            {
                isRxShow = false;
                stop_btn.Text = "取消暂停";
            }
            else
            {
                isRxShow = true;
                stop_btn.Text = "暂停";
            }
        }

        private void recuvehex_chb_CheckedChanged(object sender, EventArgs e)
        {

            //判断接收框是否为空
            if (reclve_rtb.Text == "")
            {
                return;
            }

            //当选中的时候转换成16进制
            if (recuvehex_chb.Checked)
            {
                //从reciveBuffer提取数据
                reclve_rtb.Text = Transform.ToHexString(reciveBuffer.ToArray()," ");
            }
            else
            {
                reclve_rtb.Text = Encoding.GetEncoding("gb2312").GetString(reciveBuffer.ToArray()).Replace("\0","\\0");
            }


        }

        //手动清空
        private void clear_btn_Click(object sender, EventArgs e)
        {
            MessageBoxButtons messbutton = MessageBoxButtons.OKCancel;
            DialogResult dr = MessageBox.Show("系统提示：确认要清空吗？", "手动清空",messbutton);
            if (dr == DialogResult.OK)
            {
                //清空缓存区
                reciveBuffer.Clear();

                //清空计数器
                recivecount_tssl.Text = "0";

                reciveCount = 0;

                reclve_rtb.Text = "";
            }
        }


        //自动清空
        private void auticlear_chb_CheckedChanged(object sender, EventArgs e)
        {
            //判断是否选中状态
            if (autosend_chb.Checked)
            {
                timer1.Stop();
            }
            else
            {
                
                timer1.Start();
            }
        }


        //Timer计时事件
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (reclve_rtb.Text.Length > 4096)
            {
                reciveBuffer.Clear();
                reclve_rtb.Text = "";
            }
        }



        //发送框-离开焦点事件
        private void send_rtb_Leave(object sender, EventArgs e)
        {

            //判断是否选中16进制格式
            if (sendhex_chb.CheckState == CheckState.Checked)
            {
                if (DataEncoding.IsHexString(send_rtb.Text.Replace(" ","")))
                {
                    sendBuffer.Clear();

                    //将send_rtb的数据转换为16进制保存到sendBuffer里
                    sendBuffer.AddRange(Transform.ToBytes(send_rtb.Text.Replace(" ","")));

                }
                else
                {
                    MessageBox.Show("请输入正确的十六进制数据！");
                    send_rtb.Select();
                }
            }
            else
            {
                sendBuffer.Clear();
                sendBuffer.AddRange(Encoding.GetEncoding("gb2312").GetBytes(send_rtb.Text));

            }

        }

        //发送框-文本改变
        private void send_rtb_TextChanged(object sender, EventArgs e)
        {
             //十六进制切换，会出现问题，这个问题接收0x00 转换

        }


        //发送16进制-勾选框
        private void sendhex_chb_CheckedChanged(object sender, EventArgs e)
        {
            //如果发生框等于空的时候就停止
            if (send_rtb.Text == "")
            {
                return;
            }


            //判断发送的16进制框是否勾选
            if (sendhex_chb.Checked == true)
            {
                //将缓存区的数据发送过去 每个字符用空格隔开
                send_rtb.Text = Transform.ToHexString(sendBuffer.ToArray()," ");
            }
            else
            {
                send_rtb.Text = Encoding.GetEncoding("gb2312").GetString(sendBuffer.ToArray()).Replace("\0","\\0");
            }
        }

        //清空发送
        private void sendclear_btn_Click(object sender, EventArgs e)
        {
            sendBuffer.Clear();
            send_rtb.Text = "0";
            sendCount = 0;
            recivecount_tssl.Text = "0";
        }

        private void label9_Click(object sender, EventArgs e)
        {

        }
        



        //自动发送
        private void autosend_chb_CheckedChanged(object sender, EventArgs e)
        {
            //串口未打开
            if(serialPort1.IsOpen == false && autosend_chb.CheckState == CheckState.Checked) 
            {
                autosend_chb.CheckState = CheckState.Unchecked;
                if (timer2 != null)
                {
                    timer2.Enabled = false;
                    timer2.Stop();
                    timer2 = null;
                }

                MessageBox.Show("发送失败，串口未打开");
                return;
            }

            //串口打开
            if (serialPort1.IsOpen == true && autosend_chb.CheckState == CheckState.Checked)
            {
                if (send_rtb.Text == "")
                {
                    auticlear_chb.Checked = true;
                    MessageBox.Show("请先输入要发送的内容","警告");
                    return;
                }

                string auto = autotimer_txb.Text.ToString();
                int Box = Convert.ToInt32(auto);

                if (Box < 1000)
                {
                    autotimer_txb.Text = "1000";
                    MessageBox.Show("自动发送数据的周期范围是60-1000毫秒", "警告");
                    autosend_chb.Checked = true;
                    return;
                }

                //定时发生
                autotimer_txb.Enabled = false;
                send_btn.Enabled = false;
                int i = Convert.ToInt32(autotimer_txb.Text);
                if (i < 10 || i > 60 * 1000)
                {
                    i = 1000;
                    autotimer_txb.Text = "1000";
                    MessageBox.Show("自动发送数据的周期范围是10-60000毫秒", "警告");
                }
                timer2.Interval = i;
                timer2.Start();

            }
            else
            {
                send_btn.Enabled = true;
                autotimer_txb.Enabled = true;
                if (timer2 != null)
                {
                    timer2.Stop();
                    //timer2 = null;
                }
            }
        }

        //定时器2
        private void timer2_Tick(object sender, EventArgs e)
        {
            //如果发送的数据不为空，则接收
            if (this.send_rtb.Text != "" && serialPort1.IsOpen)
            {
                Console.WriteLine(Transform.ToHexString(sendBuffer.ToArray()));
                sendData();
            }
            else
            {
                //输出到状态 栏
                state_tssl.Text = "请先输入发送的数据!";
                //Console.WriteLine("请先输入在发送数据");
            }
        }

        //清空计数
        private void cleancount_tssl_Click(object sender, EventArgs e)
        {
            //清空发送
            sendBuffer.Clear();
            sendCount = 0;
            sencount_tssl.Text = "0";


            //清空接收
            reciveBuffer.Clear();
            reclve_rtb.Text = "";
            recivecount_tssl.Text = "0";
        }


        //DTR发送格式
        private void DTR_chb_CheckedChanged(object sender, EventArgs e)
        {
            if (DTR_chb.CheckState == CheckState.Checked)
            {
                serialPort1.DtrEnable = true;
            }
            else
            {
                serialPort1.DtrEnable = false;
            }
        }
        //RTS发送格式
        private void RTS_chb_CheckedChanged(object sender, EventArgs e)
        {
            if (RTS_chb.CheckState == CheckState.Checked)
            {
                serialPort1.RtsEnable = true;
            }
            else
            {
                serialPort1.RtsEnable = false;
            }
        }
        


        //选择路径 
        private void xzlj_btn_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbDialog = new FolderBrowserDialog();
            if (fbDialog.ShowDialog() == DialogResult.OK)
            {
                reciveflie_txb.Text = fbDialog.SelectedPath;
            }
        }

        //保存数据
        private void bcsj_btn_Click(object sender, EventArgs e)
        {
            if (reclve_rtb.Text == "") return;
           
            //文件名
            string fileName = reciveflie_txb.Text+"\\"+DateTime.Now.ToString("yyyyMMddhhmmss")+".txt";

            //数据流
            //fileName路径
            StreamWriter sw = new StreamWriter(fileName);

            //将接收框的内容写到txt里
            sw.Write(reclve_rtb.Text);

            //输出
            sw.Flush();
            sw.Close();
            MessageBox.Show("保存成功");
        }

        /// <summary>
        /// 加载文本到发送框
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        //打开文件
        private void dkwj_btn_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofDialog = new OpenFileDialog();

            ofDialog.Title = "请选择文件";

            //格式过滤
            ofDialog.Filter = "文本文件(*.txt)|*.txt";

            //路径记录，下次打开的时候默认回到上一次路径
            ofDialog.RestoreDirectory = true;
            if (ofDialog.ShowDialog() == DialogResult.OK)
            {
                string fileName = ofDialog.FileName;

                //显示到文本框
                sendfile_txb.Text = fileName;
                StreamReader sr = new StreamReader(fileName, Encoding.GetEncoding("gb2312"));
                
                //读取
                strRead = sr.ReadToEnd();
                send_rtb.Text = strRead;
                sr.Close();
            }
        }
        
       
        private void fswj_btn_Click(object sender, EventArgs e)
        {
            if (strRead == "")
            {
                MessageBox.Show("请先选择文件!!");
                return;
            }

            //发送数据
            try
            {
                //数据长度控制
                byte[] data = Encoding.GetEncoding("gb2312").GetBytes(strRead);
                sendCount += data.Length;
                sencount_tssl.Text = sendCount.ToString();

                //win窗口能发送最大的数据
                int pagenum = data.Length / 4096;
                int remaind = data.Length % 4096;
                for (int i = 0; i < pagenum; i++)
                {
                    serialPort1.Write(data, (i * 4096), 4096);
                    //延时
                    Thread.Sleep(10);
                }

                //如果还有数据就继续发送
                if (remaind >0)
                {
                    serialPort1.Write(data,(pagenum * 4096), remaind);
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show("发送数据失败" + ex.Message.ToString(),"错误消息");
            }
        }
    }
}
