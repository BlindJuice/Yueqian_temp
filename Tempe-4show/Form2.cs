using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Net.Sockets;
using System.Net;
using System.Threading;

 


namespace Tempe_4show
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            CheckForIllegalCrossThreadCalls = false;
            Thread recvThread = new Thread(RecvMsg);
            recvThread.IsBackground = true;
            recvThread.Start();
        }

        UdpClient client = new UdpClient();

        System.Net.IPHostEntry hostIP = System.Net.Dns.GetHostEntry(Environment.MachineName);

        private UdpClient recvClient = new UdpClient(new IPEndPoint(IPAddress.Any, 2000));//接收IP端口
        //private UdpClient recvClient = new UdpClient(new IPEndPoint(IPAddress.Parse("172,16,255,255"), 2000));//接收IP端口
        private void RecvMsg()
        {
            while (1 == 1)
            {
                IPEndPoint remoteHost = null;
                byte[] recvByte = recvClient.Receive(ref remoteHost);
                string msg = Encoding.UTF8.GetString(recvByte);
                //uiLedLabel2.Text = msg.Substring(2,4)+ "";
                int num ,hum  ;     // num温度  hum湿度
                int num1,hum1 ;
                int num2,hum2 ;
                int num3,hum3 ;
                 

                if (msg.Substring(0, 2) == "00")
                {
                    uiTextBox1.Text = msg.Substring(2, 4) + "°C";

                    hum = Convert.ToInt32(msg.Substring(7, 2));
                    num = Convert.ToInt32(msg.Substring(2, 2));
                    if (num <= 26) { uiTextBox1.FillColor = Color.GreenYellow; }
                    else if (num <= 27 && hum <= 65) { uiTextBox1.FillColor = Color.GreenYellow; }
                    else if (num <= 28 && hum <= 55) { uiTextBox1.FillColor = Color.GreenYellow; }
                    else if (num <= 29 && hum <= 45) { uiTextBox1.FillColor = Color.GreenYellow; }
                    else if (num <= 30 && hum <= 35) { uiTextBox1.FillColor = Color.GreenYellow; }
                    else { uiTextBox1.FillColor = Color.Red; }

                    uiTextBox2.Text = msg.Substring(7, 4) + " H";
                }

                if (msg.Substring(0, 2) == "02")
                {
                    uiTextBox3.Text = msg.Substring(2, 4) + "°C";

                    hum1 = Convert.ToInt32(msg.Substring(7, 2));
                    num1 = Convert.ToInt32(msg.Substring(2, 2));
                    if (num1 <= 26) { uiTextBox3.FillColor = Color.GreenYellow; }
                    else if (num1 <= 27 && hum1 <= 65) { uiTextBox3.FillColor = Color.GreenYellow; }
                    else if (num1 <= 28 && hum1 <= 55) { uiTextBox3.FillColor = Color.GreenYellow; }
                    else if (num1 <= 29 && hum1 <= 45) { uiTextBox3.FillColor = Color.GreenYellow; }
                    else if (num1 <= 30 && hum1 <= 35) { uiTextBox3.FillColor = Color.GreenYellow; }
                    else { uiTextBox3.FillColor = Color.Red; }


                    uiTextBox4.Text = msg.Substring(7, 4) + " H";
                }
                if (msg.Substring(0, 2) == "01")
                {
                    uiTextBox5.Text = msg.Substring(2, 4) + "°C";

                    hum2 = Convert.ToInt32(msg.Substring(7, 2));
                    num2 = Convert.ToInt32(msg.Substring(2, 2));
                    if (num2 <= 26) { uiTextBox5.FillColor = Color.GreenYellow; }
                    else if (num2 <= 27 && hum2 <= 65) { uiTextBox5.FillColor = Color.GreenYellow; }
                    else if (num2 <= 28 && hum2 <= 55) { uiTextBox5.FillColor = Color.GreenYellow; }
                    else if (num2 <= 29 && hum2 <= 45) { uiTextBox5.FillColor = Color.GreenYellow; }
                    else if (num2 <= 30 && hum2 <= 35) { uiTextBox5.FillColor = Color.GreenYellow; }
                    else { uiTextBox5.FillColor = Color.Red; }


                    uiTextBox6.Text = msg.Substring(7, 4) + " H";
                }
                if (msg.Substring(0, 2) == "03")
                {
                    uiTextBox7.Text = msg.Substring(2, 4) + "°C";

                    hum3 = Convert.ToInt32(msg.Substring(7, 2));
                    num3 = Convert.ToInt32(msg.Substring(2, 2));
                    if (num3 <= 26) { uiTextBox7.FillColor = Color.GreenYellow; }
                    else if (num3 <= 27 && hum3 <= 65) { uiTextBox7.FillColor = Color.GreenYellow; }
                    else if (num3 <= 28 && hum3 <= 55) { uiTextBox7.FillColor = Color.GreenYellow; }
                    else if (num3 <= 29 && hum3 <= 45) { uiTextBox7.FillColor = Color.GreenYellow; }
                    else if (num3 <= 30 && hum3 <= 35) { uiTextBox7.FillColor = Color.GreenYellow; }
                    else { uiTextBox7.FillColor = Color.Red; }


                    uiTextBox8.Text = msg.Substring(7, 4) + " H";
                }
            }
        }


        private void uiTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void uiTextBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void uiTextBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void uiTextBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void uiTextBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void uiTextBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void uiTextBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void uiTextBox8_TextChanged(object sender, EventArgs e)
        {

        }

        private void uiLine1_Click(object sender, EventArgs e)
        {

        }
    }
}
