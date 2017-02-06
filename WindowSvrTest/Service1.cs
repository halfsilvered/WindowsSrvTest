using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;

namespace WindowSvrTest
{
    public partial class Service1 : ServiceBase
    {
        System.Timers.Timer timer1;  //计时器
        public Service1()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            timer1 = new System.Timers.Timer();
            timer1.Interval = 10000;  //设置计时器事件间隔执行时间
            timer1.Elapsed += new System.Timers.ElapsedEventHandler(TMStart1_Elapsed);
            timer1.Enabled = true;
        }

        protected override void OnStop()
        {
            using (System.IO.StreamWriter sw = new System.IO.StreamWriter("C:\\log.txt", true))
            {
                sw.WriteLine(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss ") + "Stop.");
            }
            this.timer1.Enabled = false;
        }

        private void TMStart1_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            //执行SQL语句或其他操作
            using (System.IO.StreamWriter sw = new System.IO.StreamWriter("C:\\" + 1 + "log.txt", true))
            {
                sw.WriteLine(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss ") + "Start.");
            }
        }
    }
}
