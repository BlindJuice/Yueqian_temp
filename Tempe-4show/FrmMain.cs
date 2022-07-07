using System;
using System.Drawing;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace Tempe_4show
{
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            InitializeComponent();

            CheckForIllegalCrossThreadCalls = false;
            Thread recvThread = new Thread(RecvMsg)
            {
                IsBackground = true
            };
            recvThread.Start();
        }

        private readonly UdpClient recvClient = new UdpClient(new IPEndPoint(IPAddress.Any, 2000));//接收IP端口
        private void RecvMsg()
        {
            while (1 == 1)
            {
                IPEndPoint remoteHost = null;
                byte[] recvByte = recvClient.Receive(ref remoteHost);
                string msg = Encoding.UTF8.GetString(recvByte);

                string index = msg.Substring(0, 2);
                switch (index)
                {
                    case "00":
                        SetInfo(msg, uiTextBox1, uiTextBox2);
                        break;
                    case "01":
                        SetInfo(msg, uiTextBox5, uiTextBox6);
                        break;
                    case "02":
                        SetInfo(msg, uiTextBox3, uiTextBox4);
                        break;
                    case "03":
                        SetInfo(msg, uiTextBox7, uiTextBox8);
                        break;
                    default:
                        break;
                }
            }
        }

        private void SetInfo(string msg, Sunny.UI.UIScrollingText ctl, Sunny.UI.UIScrollingText ctlH)
        {
            int temp = Convert.ToInt32(msg.Substring(2, 2));        //温度
            int hum = Convert.ToInt32(msg.Substring(7, 2));         //湿度
            if ((temp <= 26)
                || (temp <= 27 && hum <= 65) 
                || (temp <= 28 && hum <= 55) 
                || (temp <= 29 && hum <= 45) 
                || (temp <= 30 && hum <= 35))
                ctl.FillColor = Color.GreenYellow; 
            else ctl.FillColor = Color.Red; 

            ctl.Text = msg.Substring(2, 4) + "°C";
            ctlH.Text = msg.Substring(7, 4) + " H";
        }
    }
}
