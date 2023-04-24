using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 串口助手
{
    public partial class Form2 : Form
    {
        //委托
        public TransmitData useForlSend;


        public event TransmitEventHandler useForm1send2;




        public Form2()
        {
            InitializeComponent();
        }

        //创建接收方法
        public void ReciveData(byte[] dataTemp) 
        {
            string str = Encoding.GetEncoding("gb2312").GetString(dataTemp);
            str = str.Replace("\0","\\0");

            richTextBox1.AppendText(str);
        }




        internal void ReciveData2(object sender, TransmitEventAgrs e)
        {
            string str = Encoding.GetEncoding("gb2312").GetString(e.data);

            MessageBox.Show(str);
        }




        private void button1_Click(object sender, EventArgs e)
        {
            byte[] dataTemp = Encoding.GetEncoding("gb2312").GetBytes(textBox1.Text);
            useForlSend?.Invoke(dataTemp);
            useForm1send2.Invoke(this,new TransmitEventAgrs { data = dataTemp}); 
        }
    }
}
