using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 串口助手
{
    public partial class Form1 : Form
    {
        private bool isOpen = false;
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
                serialPort1.Write(send_rtb.Text);
            }
            else 
            {
                MessageBox.Show("请输入要发送的数据");
            }
        }

        private void serialPort1_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            //读取所有的数据ReadExisting()
            string dataRecive = serialPort1.ReadExisting();

            //添加数据
            reclve_rtb.AppendText(dataRecive);

            MessageBox.Show("端口号："+serialPort1.PortName+"已发送数据："+dataRecive);
        }
    }
}
