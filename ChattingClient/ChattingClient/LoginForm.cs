using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Diagnostics;

namespace ChattingClient
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {

        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            if (textBoxID.Text.Trim().Length <= 0 )
            {
                MessageBox.Show("아이디를 정확히 입력해주세요.", "알림", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (textBoxPW.Text.Trim().Length <= 0)
            {
                MessageBox.Show("비밀번호를 정확히 입력해주세요.", "알림", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            DataTable dt = DbConnection.ExcuProcedure(string.Format("proc_LoginCheck '{0}','{1}'", textBoxID.Text.Trim(), textBoxPW.Text.Trim()));

            if (dt != null)
            {
                if (dt.Columns.Contains("msg") && dt.Rows.Count > 0)
                {
                   MessageBox.Show(dt.Rows[0]["msg"].ToString(), "알림", MessageBoxButtons.OK, MessageBoxIcon.Information);
                   return;
                }
                else if (dt.Columns.Contains("NickName"))
                {
                    ClsUser.GetInstance().NickName = dt.Rows[0]["NickName"].ToString();
                    MessageBox.Show("로그인 성공", "알림", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = System.Windows.Forms.DialogResult.OK;
                    this.Close();
                }
            }
        }

      

    }
}
