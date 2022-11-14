using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net.Sockets;
using System.Threading;

namespace ChattingClient
{
    public partial class FormChat : Form
    {
        ClsUser user = ClsUser.GetInstance();
        TcpClient clientSocket = new TcpClient(); // 소켓
        NetworkStream stream = default(NetworkStream);
        string message = string.Empty;

        public FormChat()
        {
            InitializeComponent();
        }

        private void FormChat_Load(object sender, EventArgs e)
        {
            try
            {
                clientSocket.Connect("127.0.0.1", 9999); // 접속 IP 및 포트
                stream = clientSocket.GetStream();
            }
            catch (Exception ex)
            {
                MessageBox.Show("서버가 실행중이 아닙니다.", "연결실패", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }

            message = " 채팅 서버에 연결 되었습니다.";
            DisplayText(message);

            byte[] buffer = Encoding.Unicode.GetBytes(string.Format("{0}$",user.NickName));
            stream.Write(buffer, 0, buffer.Length);
            stream.Flush();

            Thread t_handler = new Thread(GetMessage);
            t_handler.IsBackground = true;
            t_handler.Start();
        }

        private void GetMessage() // 메세지 받기
        {
            while (true)
            {
                stream = clientSocket.GetStream();
                int BUFFERSIZE = clientSocket.ReceiveBufferSize;
                byte[] buffer = new byte[BUFFERSIZE];
                int bytes = stream.Read(buffer, 0, buffer.Length);

                string message = Encoding.Unicode.GetString(buffer, 0, bytes);
                DisplayText(message);
            }
        }

        private void DisplayText(string text) // Server에 메세지 출력
        {
            if (textBoxLog.InvokeRequired)
            {
                textBoxLog.BeginInvoke(new MethodInvoker(delegate
                    {
                        textBoxLog.AppendText(text + Environment.NewLine);
                    }));
            }
            else
                textBoxLog.AppendText(text + Environment.NewLine);
        }

        // 메세지 보내기 
        private void btnSend_Click(object sender, EventArgs e)
        {
            if (stream != null)
            {
                textBoxMsg.Focus();
                byte[] buffer = Encoding.Unicode.GetBytes(textBoxMsg + "$");
                stream.Write(buffer, 0, buffer.Length);
                stream.Flush();
                textBoxMsg.Text = "";
            }
        }

        private void textBoxMsg_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                btnSend.PerformClick();
        }

        private void FormChat_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (stream != null)
            {
                byte[] buffer = Encoding.Unicode.GetBytes("leaveChat" + "$");
                stream.Write(buffer, 0, buffer.Length);
                stream.Flush();
            }
            Application.ExitThread();
            Environment.Exit(0);
        }

    }
}
