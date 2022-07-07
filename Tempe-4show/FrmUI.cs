using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Net;
using System.Net.Sockets;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace Tempe_4show
{
    public partial class FrmUI : Form
    {
        public FrmUI()
        {
            InitializeComponent();
        }

        private readonly UdpClient recvClient = new UdpClient(new IPEndPoint(IPAddress.Any, 2000));//接收IP端口
        private void RecvMsg()
        {
            while (1 == 1)
            {
                IPEndPoint remoteHost = null;
                byte[] recvByte = recvClient.Receive(ref remoteHost);
                string msg = Encoding.UTF8.GetString(recvByte);
                string str = msg.Substring(0, 2);
                int index = int.Parse(str);

                switch (str)
                {
                    case "00":
                        //软件
                        SetTextValue(msg, label5, label6, pictureBox1, pictureBox2);
                        break;
                    case "01":
                        //机械
                        SetTextValue(msg, label12, label11, pictureBox8, pictureBox7);
                        break;
                    case "02":
                        //硬件
                        SetTextValue(msg, label10, label9, pictureBox6, pictureBox5);
                        break;
                    case "03":
                        //会议
                        SetTextValue(msg, label8, label7, pictureBox4, pictureBox3);
                        break;
                    default:
                        break;
                }
            }
        }

        private void SetTextValue(string msg, Label labelA, Label labelB, PictureBox pt, PictureBox ph)
        {
            labelA.Text = msg.Substring(2, 4) + "°C";
            labelB.Text = msg.Substring(7, 4) + " H";
            float tmp = float.Parse(msg.Substring(2, 4));
            float hum = float.Parse(msg.Substring(7, 4));
            if (tmp <= 25) pt.Image = Properties.Resources.therA;
            else if (tmp <= 27) pt.Image = Properties.Resources.therB;
            else pt.Image = Properties.Resources.therC;

            if (hum <= 50) ph.Image = Properties.Resources.waterA;
            else if (hum <= 60) ph.Image = Properties.Resources.waterB;
            else ph.Image = Properties.Resources.waterC;
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            CheckForIllegalCrossThreadCalls = false;
            Thread recvThread = new Thread(RecvMsg);
            recvThread.IsBackground = true;
            recvThread.Start();
        }

        #region 窗体移动
        [DllImport("user32.dll")]
        public static extern bool ReleaseCapture();
        [DllImport("user32.dll")]
        public static extern bool SendMessage(IntPtr hwnd, int wMsg, int wParam, int lParam);
        public const int WM_SYSCOMMAND = 0x0112;
        public const int SC_MOVE = 0xF010;
        public const int HTCAPTION = 0x0002;
        private void panelTop_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, WM_SYSCOMMAND, SC_MOVE + HTCAPTION, 0);
        }

        private void panelContent_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, WM_SYSCOMMAND, SC_MOVE + HTCAPTION, 0);
        }

        #endregion

        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
