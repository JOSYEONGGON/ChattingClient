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
        private bool m_bSameCheck = false;

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

            DbConnection.AddParam("@UserID", textBoxID.Text.Trim());
            DbReturnInfo retInfo = DbConnection.ExcuProcedure("proc_SameIdCheck");

            if (retInfo.nReturn > 0)
            {
                MessageBox.Show("중복된 아이디 입니다.", "알림", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("사용가능한 아이디 입니다.", "알림", MessageBoxButtons.OK, MessageBoxIcon.Information);
                m_bSameCheck = true;
                button_SameCheck.Enabled = false;
            }
        }

        //등록
        private void buttonSignUp_Click(object sender, EventArgs e)
        {
            if (textBoxID.Text.Trim().Length <= 0)
            {
                MessageBox.Show("아이디를 입력 해주세요", "알림", MessageBoxButtons.OK, MessageBoxIcon.Information);
                textBoxID.Focus();
                return;
            }

            if (!m_bSameCheck)
            {
                MessageBox.Show("중복검사를 먼저 해주세요", "알림", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (textBoxPW.Text.Trim().Length <= 0)
            {
                MessageBox.Show("패스워드를 입력 해주세요", "알림", MessageBoxButtons.OK, MessageBoxIcon.Information);
                textBoxPW.Focus();
                return;
            }

            if (textBoxPW_Check.Text.Trim().Length <= 0)
            {
                MessageBox.Show("패스워드를 입력 해주세요", "알림", MessageBoxButtons.OK, MessageBoxIcon.Information);
                textBoxPW_Check.Focus();
                return;
            }

            if (textBoxNickName.Text.Trim().Length <= 0)
            {
                MessageBox.Show("닉네임을 입력 해주세요", "알림", MessageBoxButtons.OK, MessageBoxIcon.Information);
                textBoxNickName.Focus();
                return;
            }

            if (textBoxPW.Text.Trim() != textBoxPW_Check.Text.Trim())
            {
                MessageBox.Show("패스워드가 일치하지 않습니다.", "알림", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            DbConnection.AddParam("@UserID",textBoxID.Text.Trim());
            DbConnection.AddParam("@UserPW",textBoxPW.Text.Trim());
            DbConnection.AddParam("@NickName",textBoxNickName.Text.Trim());

            DbReturnInfo retInfo = DbConnection.ExcuProcedure("proc_SineUp");

            if (retInfo.nReturn == 1)
            {
                MessageBox.Show("등록 완료", "알림", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
        }

        private void textBoxID_TextChanged(object sender, EventArgs e)
        {
            m_bSameCheck = false;
            button_SameCheck.Enabled = true;
        }


    }
}
