using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 抽奖
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            btn_stop.Enabled = false;
        }
        private string[] names = new string[] { "张三", "李四", "王五", "小叶", "依波", "晨濡", "寻巧", "寄波", "晓山", "秋灵" };//抽奖数据
        private bool IsGoOn = true;
        private async void btn_start_Click(object sender, EventArgs e)
        {
            btn_stop.Enabled = true;
            btn_start.Enabled = false;
            lbl_name1.Text = "00";
            IsGoOn = true;
            TaskFactory taskFactory = new TaskFactory();
            List<Task> Tasklist = new List<Task>();
            foreach (Control item in this.Controls)
            {                  
                Task task = taskFactory.StartNew(() =>
                 {
                     while (IsGoOn)
                     {
                         ProcessLable(item);
                     }
                 });
                await task;
                              
            }
        }
        public List<string> GetUIname()
        {
            List<string> UIname = new List<string>();
            foreach (Control item in this.Controls)
            {
                if (item.Name.Contains("name"))
                {
                    UIname.Add(item.Text);
                }
            }
            return UIname;
        }
        private static readonly object UIName = new object();
        public void ProcessLable(Control item)
        {
            if (item.Name.Contains("name"))
            {
                int number = Randmhelper.GetNumber(0, 10);
                string name = names[number];
                lock (UIName)
                {
                    List<string> UIname = GetUIname();
                    if (UIname.Contains(name))
                    {
                        return;
                    }
                    UpdateUI(item, name);
                }
            }
        }
        public void UpdateUI(Control item, string name)
        {
            if (item.InvokeRequired)
            {
                this.Invoke(new Action(() =>
                {
                    item.Text = name;
                }));
            }
            else
            {
                item.Text = name;
            }
        }

        private void btn_stop_Click(object sender, EventArgs e)
        {
            IsGoOn = false;
            btn_start.Enabled = true;
            //btn_stop.Enabled = false;

        }
    }
}
