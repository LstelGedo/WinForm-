namespace 串口助手
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.label1 = new System.Windows.Forms.Label();
            this.reclve_rtb = new System.Windows.Forms.RichTextBox();
            this.port_cbb = new System.Windows.Forms.ComboBox();
            this.send_rtb = new System.Windows.Forms.RichTextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.open_btn = new System.Windows.Forms.Button();
            this.DTR_chb = new System.Windows.Forms.CheckBox();
            this.RTS_chb = new System.Windows.Forms.CheckBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.stopbit_cbb = new System.Windows.Forms.ComboBox();
            this.databit_cbb = new System.Windows.Forms.ComboBox();
            this.check_cbb = new System.Windows.Forms.ComboBox();
            this.baud_cdd = new System.Windows.Forms.ComboBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.xzlj_btn = new System.Windows.Forms.Button();
            this.reciveflie_txb = new System.Windows.Forms.TextBox();
            this.bcsj_btn = new System.Windows.Forms.Button();
            this.stop_btn = new System.Windows.Forms.Button();
            this.clear_btn = new System.Windows.Forms.Button();
            this.recuvehex_chb = new System.Windows.Forms.CheckBox();
            this.auticlear_chb = new System.Windows.Forms.CheckBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.autotimer_txb = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.dkwj_btn = new System.Windows.Forms.Button();
            this.fswj_btn = new System.Windows.Forms.Button();
            this.sendfile_txb = new System.Windows.Forms.TextBox();
            this.autosend_chb = new System.Windows.Forms.CheckBox();
            this.sendhex_chb = new System.Windows.Forms.CheckBox();
            this.sendclear_btn = new System.Windows.Forms.Button();
            this.send_btn = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.state_tssl = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel3 = new System.Windows.Forms.ToolStripStatusLabel();
            this.sencount_tssl = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel5 = new System.Windows.Forms.ToolStripStatusLabel();
            this.recivecount_tssl = new System.Windows.Forms.ToolStripStatusLabel();
            this.cleancount_tssl = new System.Windows.Forms.ToolStripStatusLabel();
            this.serialPort1 = new System.IO.Ports.SerialPort(this.components);
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(23, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "端口号";
            // 
            // reclve_rtb
            // 
            this.reclve_rtb.Dock = System.Windows.Forms.DockStyle.Fill;
            this.reclve_rtb.Location = new System.Drawing.Point(3, 17);
            this.reclve_rtb.Name = "reclve_rtb";
            this.reclve_rtb.Size = new System.Drawing.Size(397, 409);
            this.reclve_rtb.TabIndex = 3;
            this.reclve_rtb.Text = "";
            // 
            // port_cbb
            // 
            this.port_cbb.FormattingEnabled = true;
            this.port_cbb.Location = new System.Drawing.Point(96, 16);
            this.port_cbb.Name = "port_cbb";
            this.port_cbb.Size = new System.Drawing.Size(145, 20);
            this.port_cbb.TabIndex = 1;
            // 
            // send_rtb
            // 
            this.send_rtb.Dock = System.Windows.Forms.DockStyle.Fill;
            this.send_rtb.Location = new System.Drawing.Point(3, 17);
            this.send_rtb.Name = "send_rtb";
            this.send_rtb.Size = new System.Drawing.Size(397, 153);
            this.send_rtb.TabIndex = 6;
            this.send_rtb.Text = "";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.open_btn);
            this.groupBox1.Controls.Add(this.DTR_chb);
            this.groupBox1.Controls.Add(this.RTS_chb);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.stopbit_cbb);
            this.groupBox1.Controls.Add(this.databit_cbb);
            this.groupBox1.Controls.Add(this.check_cbb);
            this.groupBox1.Controls.Add(this.baud_cdd);
            this.groupBox1.Controls.Add(this.port_cbb);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(257, 258);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "串口配置";
            // 
            // open_btn
            // 
            this.open_btn.Location = new System.Drawing.Point(96, 195);
            this.open_btn.Name = "open_btn";
            this.open_btn.Size = new System.Drawing.Size(145, 47);
            this.open_btn.TabIndex = 13;
            this.open_btn.Text = "启动串口";
            this.open_btn.UseVisualStyleBackColor = true;
            this.open_btn.Click += new System.EventHandler(this.open_btn_Click);
            // 
            // DTR_chb
            // 
            this.DTR_chb.AutoSize = true;
            this.DTR_chb.Location = new System.Drawing.Point(23, 226);
            this.DTR_chb.Name = "DTR_chb";
            this.DTR_chb.Size = new System.Drawing.Size(42, 16);
            this.DTR_chb.TabIndex = 11;
            this.DTR_chb.Text = "DTR";
            this.DTR_chb.UseVisualStyleBackColor = true;
            // 
            // RTS_chb
            // 
            this.RTS_chb.AutoSize = true;
            this.RTS_chb.Location = new System.Drawing.Point(23, 195);
            this.RTS_chb.Name = "RTS_chb";
            this.RTS_chb.Size = new System.Drawing.Size(42, 16);
            this.RTS_chb.TabIndex = 10;
            this.RTS_chb.Text = "RTS";
            this.RTS_chb.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(23, 163);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(41, 12);
            this.label6.TabIndex = 9;
            this.label6.Text = "停止位";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(23, 127);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 12);
            this.label5.TabIndex = 8;
            this.label5.Text = "数据位";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(23, 90);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 12);
            this.label4.TabIndex = 7;
            this.label4.Text = "校验位";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(23, 55);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 12);
            this.label3.TabIndex = 6;
            this.label3.Text = "波特率";
            // 
            // stopbit_cbb
            // 
            this.stopbit_cbb.FormattingEnabled = true;
            this.stopbit_cbb.Items.AddRange(new object[] {
            "1",
            "1.5",
            "2"});
            this.stopbit_cbb.Location = new System.Drawing.Point(96, 160);
            this.stopbit_cbb.Name = "stopbit_cbb";
            this.stopbit_cbb.Size = new System.Drawing.Size(145, 20);
            this.stopbit_cbb.TabIndex = 5;
            // 
            // databit_cbb
            // 
            this.databit_cbb.FormattingEnabled = true;
            this.databit_cbb.Items.AddRange(new object[] {
            "5",
            "6",
            "7",
            "8"});
            this.databit_cbb.Location = new System.Drawing.Point(96, 124);
            this.databit_cbb.Name = "databit_cbb";
            this.databit_cbb.Size = new System.Drawing.Size(145, 20);
            this.databit_cbb.TabIndex = 4;
            // 
            // check_cbb
            // 
            this.check_cbb.FormattingEnabled = true;
            this.check_cbb.Items.AddRange(new object[] {
            "NONE",
            "ODD",
            "EVEN"});
            this.check_cbb.Location = new System.Drawing.Point(96, 88);
            this.check_cbb.Name = "check_cbb";
            this.check_cbb.Size = new System.Drawing.Size(145, 20);
            this.check_cbb.TabIndex = 3;
            // 
            // baud_cdd
            // 
            this.baud_cdd.FormattingEnabled = true;
            this.baud_cdd.Items.AddRange(new object[] {
            "4800",
            "9600",
            "115200"});
            this.baud_cdd.Location = new System.Drawing.Point(96, 52);
            this.baud_cdd.Name = "baud_cdd";
            this.baud_cdd.Size = new System.Drawing.Size(145, 20);
            this.baud_cdd.TabIndex = 2;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.xzlj_btn);
            this.groupBox2.Controls.Add(this.reciveflie_txb);
            this.groupBox2.Controls.Add(this.bcsj_btn);
            this.groupBox2.Controls.Add(this.stop_btn);
            this.groupBox2.Controls.Add(this.clear_btn);
            this.groupBox2.Controls.Add(this.recuvehex_chb);
            this.groupBox2.Controls.Add(this.auticlear_chb);
            this.groupBox2.Location = new System.Drawing.Point(12, 276);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(257, 165);
            this.groupBox2.TabIndex = 8;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "接收配置";
            // 
            // xzlj_btn
            // 
            this.xzlj_btn.Location = new System.Drawing.Point(19, 90);
            this.xzlj_btn.Name = "xzlj_btn";
            this.xzlj_btn.Size = new System.Drawing.Size(101, 23);
            this.xzlj_btn.TabIndex = 20;
            this.xzlj_btn.Text = "选择路径";
            this.xzlj_btn.UseVisualStyleBackColor = true;
            // 
            // reciveflie_txb
            // 
            this.reciveflie_txb.Location = new System.Drawing.Point(19, 122);
            this.reciveflie_txb.Name = "reciveflie_txb";
            this.reciveflie_txb.Size = new System.Drawing.Size(221, 21);
            this.reciveflie_txb.TabIndex = 19;
            // 
            // bcsj_btn
            // 
            this.bcsj_btn.Location = new System.Drawing.Point(132, 90);
            this.bcsj_btn.Name = "bcsj_btn";
            this.bcsj_btn.Size = new System.Drawing.Size(108, 23);
            this.bcsj_btn.TabIndex = 17;
            this.bcsj_btn.Text = "保存数据";
            this.bcsj_btn.UseVisualStyleBackColor = true;
            // 
            // stop_btn
            // 
            this.stop_btn.Location = new System.Drawing.Point(132, 56);
            this.stop_btn.Name = "stop_btn";
            this.stop_btn.Size = new System.Drawing.Size(108, 23);
            this.stop_btn.TabIndex = 16;
            this.stop_btn.Text = "暂停";
            this.stop_btn.UseVisualStyleBackColor = true;
            this.stop_btn.Click += new System.EventHandler(this.stop_btn_Click);
            // 
            // clear_btn
            // 
            this.clear_btn.Location = new System.Drawing.Point(133, 21);
            this.clear_btn.Name = "clear_btn";
            this.clear_btn.Size = new System.Drawing.Size(108, 23);
            this.clear_btn.TabIndex = 5;
            this.clear_btn.Text = "手动清空";
            this.clear_btn.UseVisualStyleBackColor = true;
            this.clear_btn.Click += new System.EventHandler(this.clear_btn_Click);
            // 
            // recuvehex_chb
            // 
            this.recuvehex_chb.AutoSize = true;
            this.recuvehex_chb.Location = new System.Drawing.Point(23, 60);
            this.recuvehex_chb.Name = "recuvehex_chb";
            this.recuvehex_chb.Size = new System.Drawing.Size(72, 16);
            this.recuvehex_chb.TabIndex = 15;
            this.recuvehex_chb.Text = "十六进制";
            this.recuvehex_chb.UseVisualStyleBackColor = true;
            this.recuvehex_chb.CheckedChanged += new System.EventHandler(this.recuvehex_chb_CheckedChanged);
            // 
            // auticlear_chb
            // 
            this.auticlear_chb.AutoSize = true;
            this.auticlear_chb.Location = new System.Drawing.Point(23, 25);
            this.auticlear_chb.Name = "auticlear_chb";
            this.auticlear_chb.Size = new System.Drawing.Size(72, 16);
            this.auticlear_chb.TabIndex = 14;
            this.auticlear_chb.Text = "自动清空";
            this.auticlear_chb.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.autotimer_txb);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Controls.Add(this.dkwj_btn);
            this.groupBox3.Controls.Add(this.fswj_btn);
            this.groupBox3.Controls.Add(this.sendfile_txb);
            this.groupBox3.Controls.Add(this.autosend_chb);
            this.groupBox3.Controls.Add(this.sendhex_chb);
            this.groupBox3.Controls.Add(this.sendclear_btn);
            this.groupBox3.Controls.Add(this.send_btn);
            this.groupBox3.Location = new System.Drawing.Point(12, 447);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(257, 173);
            this.groupBox3.TabIndex = 9;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "发送配置";
            // 
            // autotimer_txb
            // 
            this.autotimer_txb.Location = new System.Drawing.Point(130, 142);
            this.autotimer_txb.Name = "autotimer_txb";
            this.autotimer_txb.Size = new System.Drawing.Size(110, 21);
            this.autotimer_txb.TabIndex = 28;
            this.autotimer_txb.Text = "1000";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(17, 147);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(107, 12);
            this.label2.TabIndex = 14;
            this.label2.Text = "自动发送周期(ms):";
            // 
            // dkwj_btn
            // 
            this.dkwj_btn.Location = new System.Drawing.Point(17, 83);
            this.dkwj_btn.Name = "dkwj_btn";
            this.dkwj_btn.Size = new System.Drawing.Size(101, 23);
            this.dkwj_btn.TabIndex = 27;
            this.dkwj_btn.Text = "打开文件";
            this.dkwj_btn.UseVisualStyleBackColor = true;
            // 
            // fswj_btn
            // 
            this.fswj_btn.Location = new System.Drawing.Point(130, 83);
            this.fswj_btn.Name = "fswj_btn";
            this.fswj_btn.Size = new System.Drawing.Size(108, 23);
            this.fswj_btn.TabIndex = 25;
            this.fswj_btn.Text = "发送文件";
            this.fswj_btn.UseVisualStyleBackColor = true;
            // 
            // sendfile_txb
            // 
            this.sendfile_txb.Location = new System.Drawing.Point(17, 115);
            this.sendfile_txb.Name = "sendfile_txb";
            this.sendfile_txb.Size = new System.Drawing.Size(221, 21);
            this.sendfile_txb.TabIndex = 26;
            // 
            // autosend_chb
            // 
            this.autosend_chb.AutoSize = true;
            this.autosend_chb.Location = new System.Drawing.Point(21, 18);
            this.autosend_chb.Name = "autosend_chb";
            this.autosend_chb.Size = new System.Drawing.Size(72, 16);
            this.autosend_chb.TabIndex = 22;
            this.autosend_chb.Text = "自动发送";
            this.autosend_chb.UseVisualStyleBackColor = true;
            // 
            // sendhex_chb
            // 
            this.sendhex_chb.AutoSize = true;
            this.sendhex_chb.Location = new System.Drawing.Point(21, 53);
            this.sendhex_chb.Name = "sendhex_chb";
            this.sendhex_chb.Size = new System.Drawing.Size(72, 16);
            this.sendhex_chb.TabIndex = 23;
            this.sendhex_chb.Text = "十六进制";
            this.sendhex_chb.UseVisualStyleBackColor = true;
            // 
            // sendclear_btn
            // 
            this.sendclear_btn.Location = new System.Drawing.Point(130, 49);
            this.sendclear_btn.Name = "sendclear_btn";
            this.sendclear_btn.Size = new System.Drawing.Size(108, 23);
            this.sendclear_btn.TabIndex = 24;
            this.sendclear_btn.Text = "清空发送";
            this.sendclear_btn.UseVisualStyleBackColor = true;
            // 
            // send_btn
            // 
            this.send_btn.Location = new System.Drawing.Point(131, 14);
            this.send_btn.Name = "send_btn";
            this.send_btn.Size = new System.Drawing.Size(108, 23);
            this.send_btn.TabIndex = 21;
            this.send_btn.Text = "手动发送";
            this.send_btn.UseVisualStyleBackColor = true;
            this.send_btn.Click += new System.EventHandler(this.send_btn_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.reclve_rtb);
            this.groupBox4.Location = new System.Drawing.Point(281, 12);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(403, 429);
            this.groupBox4.TabIndex = 8;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "接收区";
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.send_rtb);
            this.groupBox5.Location = new System.Drawing.Point(281, 447);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(403, 173);
            this.groupBox5.TabIndex = 10;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "发送区";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.state_tssl,
            this.toolStripStatusLabel3,
            this.sencount_tssl,
            this.toolStripStatusLabel5,
            this.recivecount_tssl,
            this.cleancount_tssl});
            this.statusStrip1.Location = new System.Drawing.Point(0, 619);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(694, 32);
            this.statusStrip1.TabIndex = 11;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Margin = new System.Windows.Forms.Padding(10, 3, 0, 2);
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(35, 27);
            this.toolStripStatusLabel1.Text = "状态:";
            // 
            // state_tssl
            // 
            this.state_tssl.AutoSize = false;
            this.state_tssl.Margin = new System.Windows.Forms.Padding(30, 3, 0, 2);
            this.state_tssl.Name = "state_tssl";
            this.state_tssl.Size = new System.Drawing.Size(150, 27);
            this.state_tssl.Text = " 初始化正常";
            // 
            // toolStripStatusLabel3
            // 
            this.toolStripStatusLabel3.Margin = new System.Windows.Forms.Padding(30, 3, 0, 2);
            this.toolStripStatusLabel3.Name = "toolStripStatusLabel3";
            this.toolStripStatusLabel3.Size = new System.Drawing.Size(59, 27);
            this.toolStripStatusLabel3.Text = "发送次数:";
            // 
            // sencount_tssl
            // 
            this.sencount_tssl.AutoSize = false;
            this.sencount_tssl.Name = "sencount_tssl";
            this.sencount_tssl.Padding = new System.Windows.Forms.Padding(10, 0, 0, 100);
            this.sencount_tssl.Size = new System.Drawing.Size(25, 27);
            this.sencount_tssl.Text = "0";
            // 
            // toolStripStatusLabel5
            // 
            this.toolStripStatusLabel5.Margin = new System.Windows.Forms.Padding(50, 3, 10, 2);
            this.toolStripStatusLabel5.Name = "toolStripStatusLabel5";
            this.toolStripStatusLabel5.Size = new System.Drawing.Size(59, 27);
            this.toolStripStatusLabel5.Text = "接收次数:";
            // 
            // recivecount_tssl
            // 
            this.recivecount_tssl.Name = "recivecount_tssl";
            this.recivecount_tssl.Size = new System.Drawing.Size(15, 27);
            this.recivecount_tssl.Text = "0";
            // 
            // cleancount_tssl
            // 
            this.cleancount_tssl.Margin = new System.Windows.Forms.Padding(40, 3, 0, 2);
            this.cleancount_tssl.Name = "cleancount_tssl";
            this.cleancount_tssl.Size = new System.Drawing.Size(56, 27);
            this.cleancount_tssl.Text = "清空计数";
            // 
            // serialPort1
            // 
            this.serialPort1.PortName = "COM3";
            this.serialPort1.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.serialPort1_DataReceived);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(694, 651);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(710, 690);
            this.MinimumSize = new System.Drawing.Size(710, 690);
            this.Name = "Form1";
            this.Text = "串口模拟";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RichTextBox reclve_rtb;
        private System.Windows.Forms.ComboBox port_cbb;
        private System.Windows.Forms.RichTextBox send_rtb;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.CheckBox RTS_chb;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox stopbit_cbb;
        private System.Windows.Forms.ComboBox databit_cbb;
        private System.Windows.Forms.ComboBox check_cbb;
        private System.Windows.Forms.ComboBox baud_cdd;
        private System.Windows.Forms.CheckBox DTR_chb;
        private System.Windows.Forms.Button open_btn;
        private System.Windows.Forms.Button xzlj_btn;
        private System.Windows.Forms.TextBox reciveflie_txb;
        private System.Windows.Forms.Button bcsj_btn;
        private System.Windows.Forms.Button stop_btn;
        private System.Windows.Forms.Button clear_btn;
        private System.Windows.Forms.CheckBox recuvehex_chb;
        private System.Windows.Forms.CheckBox auticlear_chb;
        private System.Windows.Forms.TextBox autotimer_txb;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button dkwj_btn;
        private System.Windows.Forms.Button fswj_btn;
        private System.Windows.Forms.TextBox sendfile_txb;
        private System.Windows.Forms.CheckBox autosend_chb;
        private System.Windows.Forms.CheckBox sendhex_chb;
        private System.Windows.Forms.Button sendclear_btn;
        private System.Windows.Forms.Button send_btn;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel state_tssl;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel3;
        private System.Windows.Forms.ToolStripStatusLabel sencount_tssl;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel5;
        private System.Windows.Forms.ToolStripStatusLabel recivecount_tssl;
        private System.Windows.Forms.ToolStripStatusLabel cleancount_tssl;
        private System.IO.Ports.SerialPort serialPort1;
    }
}

