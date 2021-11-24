using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;   //调用WINDOWS API函数时要用到
using Microsoft.Win32;  //写入注册表时要用到
namespace KeyBoardHookClass
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
   
        }


        KeyboardHookClass k_hook = new KeyboardHookClass();

        private void hook_KeyDown(object sender, KeyEventArgs e)
        {
            //判断按下的键（Alt + A）
            if (e.KeyValue == (int)Keys.A && (int)Control.ModifierKeys == (int)Keys.Alt)
            {
                System.Windows.Forms.MessageBox.Show("按下了指定快捷键组合");
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
          
            k_hook.KeyDownEvent += new KeyEventHandler(hook_KeyDown);//钩住键按下
            k_hook.Start();//安装键盘钩子
        }

        private void button2_Click(object sender, EventArgs e)
        {
            k_hook.KeyDownEvent += new KeyEventHandler(hook_KeyDown);//钩住键按下
            k_hook.Stop();//安装键盘钩子
        }
    }
}
