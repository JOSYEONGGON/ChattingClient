namespace ChattingClient
{
    partial class SingUpForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.buttonSignUp = new System.Windows.Forms.Button();
            this.labelPW = new System.Windows.Forms.Label();
            this.labelID = new System.Windows.Forms.Label();
            this.textBoxPW = new System.Windows.Forms.TextBox();
            this.textBoxID = new System.Windows.Forms.TextBox();
            this.textBoxPW_Check = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.button_SameCheck = new System.Windows.Forms.Button();
            this.textBoxNickName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // buttonSignUp
            // 
            this.buttonSignUp.Location = new System.Drawing.Point(24, 134);
            this.buttonSignUp.Name = "buttonSignUp";
            this.buttonSignUp.Size = new System.Drawing.Size(361, 32);
            this.buttonSignUp.TabIndex = 4;
            this.buttonSignUp.Text = "등 록";
            this.buttonSignUp.UseVisualStyleBackColor = true;
            this.buttonSignUp.Click += new System.EventHandler(this.buttonSignUp_Click);
            // 
            // labelPW
            // 
            this.labelPW.AutoSize = true;
            this.labelPW.Location = new System.Drawing.Point(47, 42);
            this.labelPW.Name = "labelPW";
            this.labelPW.Size = new System.Drawing.Size(53, 12);
            this.labelPW.TabIndex = 3;
            this.labelPW.Text = "패스워드";
            // 
            // labelID
            // 
            this.labelID.AutoSize = true;
            this.labelID.Location = new System.Drawing.Point(59, 9);
            this.labelID.Name = "labelID";
            this.labelID.Size = new System.Drawing.Size(41, 12);
            this.labelID.TabIndex = 5;
            this.labelID.Text = "아이디";
            // 
            // textBoxPW
            // 
            this.textBoxPW.Location = new System.Drawing.Point(106, 39);
            this.textBoxPW.Name = "textBoxPW";
            this.textBoxPW.PasswordChar = '*';
            this.textBoxPW.Size = new System.Drawing.Size(194, 21);
            this.textBoxPW.TabIndex = 1;
            // 
            // textBoxID
            // 
            this.textBoxID.Location = new System.Drawing.Point(106, 6);
            this.textBoxID.Name = "textBoxID";
            this.textBoxID.Size = new System.Drawing.Size(194, 21);
            this.textBoxID.TabIndex = 0;
            this.textBoxID.TextChanged += new System.EventHandler(this.textBoxID_TextChanged);
            // 
            // textBoxPW_Check
            // 
            this.textBoxPW_Check.Location = new System.Drawing.Point(106, 72);
            this.textBoxPW_Check.Name = "textBoxPW_Check";
            this.textBoxPW_Check.PasswordChar = '*';
            this.textBoxPW_Check.Size = new System.Drawing.Size(194, 21);
            this.textBoxPW_Check.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 76);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 12);
            this.label1.TabIndex = 3;
            this.label1.Text = "패스워드 확인";
            // 
            // button_SameCheck
            // 
            this.button_SameCheck.Location = new System.Drawing.Point(305, 6);
            this.button_SameCheck.Name = "button_SameCheck";
            this.button_SameCheck.Size = new System.Drawing.Size(80, 20);
            this.button_SameCheck.TabIndex = 5;
            this.button_SameCheck.Text = "중복체크";
            this.button_SameCheck.UseVisualStyleBackColor = true;
            this.button_SameCheck.Click += new System.EventHandler(this.button_SameCheck_Click);
            // 
            // textBoxNickName
            // 
            this.textBoxNickName.Location = new System.Drawing.Point(106, 102);
            this.textBoxNickName.Name = "textBoxNickName";
            this.textBoxNickName.Size = new System.Drawing.Size(194, 21);
            this.textBoxNickName.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(59, 105);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 5;
            this.label2.Text = "닉네임";
            // 
            // SingUpForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(407, 174);
            this.Controls.Add(this.button_SameCheck);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.labelPW);
            this.Controls.Add(this.textBoxPW_Check);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.labelID);
            this.Controls.Add(this.textBoxNickName);
            this.Controls.Add(this.textBoxPW);
            this.Controls.Add(this.textBoxID);
            this.Controls.Add(this.buttonSignUp);
            this.Name = "SingUpForm";
            this.Text = "회원가입";
            this.Load += new System.EventHandler(this.SingUpForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonSignUp;
        private System.Windows.Forms.Label labelPW;
        private System.Windows.Forms.Label labelID;
        private System.Windows.Forms.TextBox textBoxPW;
        private System.Windows.Forms.TextBox textBoxID;
        private System.Windows.Forms.TextBox textBoxPW_Check;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button_SameCheck;
        private System.Windows.Forms.TextBox textBoxNickName;
        private System.Windows.Forms.Label label2;
    }
}