using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ChattingClient
{
    public partial class SingUpForm : Form
    {
        private bool bSameCheck = false;

        public SingUpForm()
        {
            InitializeComponent();
        }

        private void SingUpForm_Load(object sender, EventArgs e)
        {

        }

        //중복체크
        private void button_SameCheck_Click(object sender, EventArgs e)
        {
            if (textBoxID.Text.Trim().Length <= 0)
            {
                MessageBox.Show("아이디를 입력 해주세요", "알림", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }




            bSameCheck = true;
        }

        //등록
        private void buttonSignUp_Click(object sender, EventArgs e)
        {
            if (textBoxID.Text.Trim().Length <= 0)
            {
                MessageBox.Show("아이디를 입력 해주세요", "알림", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (!bSameCheck)
            {
                MessageBox.Show("중복검사를 먼저 해주세요", "알림", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (textBoxPW.Text.Trim().Length <= 0)
            {
                MessageBox.Show("패스워드를 입력 해주세요", "알림", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (textBoxPW_Check.Text.Trim().Length <= 0)
            {
                MessageBox.Show("패스워드를 입력 해주세요", "알림", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (textBoxNickName.Text.Trim().Length <= 0)
            {
                MessageBox.Show("닉네임을 입력 해주세요", "알림", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (textBoxPW.Text.Trim() != textBoxPW_Check.Text.Trim())
            {
                MessageBox.Show("패스워드가 일치하지 않습니다.", "알림", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }



        }


    }
}
