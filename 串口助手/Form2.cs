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

        private void button1_Click(object sender, EventArgs e)
        {
            useForlSend?.Invoke(Encoding.GetEncoding("gb2312").GetBytes(textBox1.Text));
        }
    }
}
