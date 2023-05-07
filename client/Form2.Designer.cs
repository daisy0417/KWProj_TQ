namespace ClientProgram
{
    partial class Form2
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
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnSend = new System.Windows.Forms.Button();
            this.tbMessage = new System.Windows.Forms.TextBox();
            this.tbRoomChat = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnOutRoom2 = new System.Windows.Forms.Button();
            this.btnJoinRoom2 = new System.Windows.Forms.Button();
            this.tbRoomList2 = new System.Windows.Forms.TextBox();
            this.btnRoomCreate2 = new System.Windows.Forms.Button();
            this.tbRoomCount2 = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.tbRoomName2 = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.btnRefreshRoomList2 = new System.Windows.Forms.Button();
            this.btnSignIn = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.tbUsername = new System.Windows.Forms.TextBox();
            this.tbPassword = new System.Windows.Forms.TextBox();
            this.btnSignUp = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.btnConnect = new System.Windows.Forms.Button();
            this.btnViewRoomNum = new System.Windows.Forms.Button();
            this.btnChangeRoomNum = new System.Windows.Forms.Button();
            this.tbRoomNum = new System.Windows.Forms.TextBox();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnSend);
            this.groupBox2.Controls.Add(this.tbMessage);
            this.groupBox2.Controls.Add(this.tbRoomChat);
            this.groupBox2.Location = new System.Drawing.Point(382, 33);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox2.Size = new System.Drawing.Size(60, 78);
            this.groupBox2.TabIndex = 23;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "방 채팅";
            // 
            // btnSend
            // 
            this.btnSend.Location = new System.Drawing.Point(265, 261);
            this.btnSend.Margin = new System.Windows.Forms.Padding(4);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(96, 31);
            this.btnSend.TabIndex = 2;
            this.btnSend.Text = "Send";
            this.btnSend.UseVisualStyleBackColor = true;
            // 
            // tbMessage
            // 
            this.tbMessage.Location = new System.Drawing.Point(8, 263);
            this.tbMessage.Margin = new System.Windows.Forms.Padding(4);
            this.tbMessage.Name = "tbMessage";
            this.tbMessage.Size = new System.Drawing.Size(248, 27);
            this.tbMessage.TabIndex = 1;
            // 
            // tbRoomChat
            // 
            this.tbRoomChat.BackColor = System.Drawing.SystemColors.HighlightText;
            this.tbRoomChat.Location = new System.Drawing.Point(8, 25);
            this.tbRoomChat.Margin = new System.Windows.Forms.Padding(4);
            this.tbRoomChat.Multiline = true;
            this.tbRoomChat.Name = "tbRoomChat";
            this.tbRoomChat.ReadOnly = true;
            this.tbRoomChat.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbRoomChat.Size = new System.Drawing.Size(352, 228);
            this.tbRoomChat.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnOutRoom2);
            this.groupBox1.Controls.Add(this.btnJoinRoom2);
            this.groupBox1.Controls.Add(this.tbRoomList2);
            this.groupBox1.Controls.Add(this.btnRoomCreate2);
            this.groupBox1.Controls.Add(this.tbRoomCount2);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.tbRoomName2);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.btnRefreshRoomList2);
            this.groupBox1.Location = new System.Drawing.Point(462, 21);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(401, 371);
            this.groupBox1.TabIndex = 22;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "방 목록";
            // 
            // btnOutRoom2
            // 
            this.btnOutRoom2.Location = new System.Drawing.Point(172, 263);
            this.btnOutRoom2.Margin = new System.Windows.Forms.Padding(4);
            this.btnOutRoom2.Name = "btnOutRoom2";
            this.btnOutRoom2.Size = new System.Drawing.Size(129, 31);
            this.btnOutRoom2.TabIndex = 9;
            this.btnOutRoom2.Text = "방 나가기";
            this.btnOutRoom2.UseVisualStyleBackColor = true;
            // 
            // btnJoinRoom2
            // 
            this.btnJoinRoom2.Location = new System.Drawing.Point(172, 224);
            this.btnJoinRoom2.Margin = new System.Windows.Forms.Padding(4);
            this.btnJoinRoom2.Name = "btnJoinRoom2";
            this.btnJoinRoom2.Size = new System.Drawing.Size(129, 31);
            this.btnJoinRoom2.TabIndex = 8;
            this.btnJoinRoom2.Text = "방 참가";
            this.btnJoinRoom2.UseVisualStyleBackColor = true;
            // 
            // tbRoomList2
            // 
            this.tbRoomList2.BackColor = System.Drawing.SystemColors.HighlightText;
            this.tbRoomList2.Location = new System.Drawing.Point(4, 25);
            this.tbRoomList2.Margin = new System.Windows.Forms.Padding(4);
            this.tbRoomList2.Multiline = true;
            this.tbRoomList2.Name = "tbRoomList2";
            this.tbRoomList2.ReadOnly = true;
            this.tbRoomList2.Size = new System.Drawing.Size(160, 267);
            this.tbRoomList2.TabIndex = 7;
            // 
            // btnRoomCreate2
            // 
            this.btnRoomCreate2.Location = new System.Drawing.Point(172, 185);
            this.btnRoomCreate2.Margin = new System.Windows.Forms.Padding(4);
            this.btnRoomCreate2.Name = "btnRoomCreate2";
            this.btnRoomCreate2.Size = new System.Drawing.Size(129, 31);
            this.btnRoomCreate2.TabIndex = 6;
            this.btnRoomCreate2.Text = "방 생성";
            this.btnRoomCreate2.UseVisualStyleBackColor = true;
            // 
            // tbRoomCount2
            // 
            this.tbRoomCount2.Location = new System.Drawing.Point(172, 147);
            this.tbRoomCount2.Margin = new System.Windows.Forms.Padding(4);
            this.tbRoomCount2.Name = "tbRoomCount2";
            this.tbRoomCount2.Size = new System.Drawing.Size(127, 27);
            this.tbRoomCount2.TabIndex = 5;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(173, 124);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(59, 20);
            this.label7.TabIndex = 4;
            this.label7.Text = "방 정원";
            // 
            // tbRoomName2
            // 
            this.tbRoomName2.Location = new System.Drawing.Point(172, 88);
            this.tbRoomName2.Margin = new System.Windows.Forms.Padding(4);
            this.tbRoomName2.Name = "tbRoomName2";
            this.tbRoomName2.Size = new System.Drawing.Size(127, 27);
            this.tbRoomName2.TabIndex = 3;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(176, 65);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(59, 20);
            this.label6.TabIndex = 2;
            this.label6.Text = "방 이름";
            // 
            // btnRefreshRoomList2
            // 
            this.btnRefreshRoomList2.Location = new System.Drawing.Point(175, 29);
            this.btnRefreshRoomList2.Margin = new System.Windows.Forms.Padding(4);
            this.btnRefreshRoomList2.Name = "btnRefreshRoomList2";
            this.btnRefreshRoomList2.Size = new System.Drawing.Size(126, 31);
            this.btnRefreshRoomList2.TabIndex = 1;
            this.btnRefreshRoomList2.Text = "새로고침";
            this.btnRefreshRoomList2.UseVisualStyleBackColor = true;
            // 
            // btnSignIn
            // 
            this.btnSignIn.Location = new System.Drawing.Point(149, 28);
            this.btnSignIn.Margin = new System.Windows.Forms.Padding(4);
            this.btnSignIn.Name = "btnSignIn";
            this.btnSignIn.Size = new System.Drawing.Size(96, 31);
            this.btnSignIn.TabIndex = 21;
            this.btnSignIn.Text = "로그인";
            this.btnSignIn.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(617, 28);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(0, 20);
            this.label3.TabIndex = 20;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.tbUsername);
            this.groupBox3.Controls.Add(this.tbPassword);
            this.groupBox3.Controls.Add(this.btnSignUp);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Location = new System.Drawing.Point(10, 24);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox3.Size = new System.Drawing.Size(121, 44);
            this.groupBox3.TabIndex = 24;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "로그인";
            // 
            // tbUsername
            // 
            this.tbUsername.Location = new System.Drawing.Point(89, 29);
            this.tbUsername.Margin = new System.Windows.Forms.Padding(4);
            this.tbUsername.Name = "tbUsername";
            this.tbUsername.Size = new System.Drawing.Size(187, 27);
            this.tbUsername.TabIndex = 12;
            // 
            // tbPassword
            // 
            this.tbPassword.Location = new System.Drawing.Point(89, 76);
            this.tbPassword.Margin = new System.Windows.Forms.Padding(4);
            this.tbPassword.Name = "tbPassword";
            this.tbPassword.Size = new System.Drawing.Size(187, 27);
            this.tbPassword.TabIndex = 13;
            // 
            // btnSignUp
            // 
            this.btnSignUp.Location = new System.Drawing.Point(284, 76);
            this.btnSignUp.Margin = new System.Windows.Forms.Padding(4);
            this.btnSignUp.Name = "btnSignUp";
            this.btnSignUp.Size = new System.Drawing.Size(96, 31);
            this.btnSignUp.TabIndex = 15;
            this.btnSignUp.Text = "회원가입";
            this.btnSignUp.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 34);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(88, 20);
            this.label4.TabIndex = 10;
            this.label4.Text = "username : ";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(11, 82);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(85, 20);
            this.label5.TabIndex = 11;
            this.label5.Text = "password : ";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.btnConnect);
            this.groupBox4.Controls.Add(this.btnViewRoomNum);
            this.groupBox4.Controls.Add(this.btnChangeRoomNum);
            this.groupBox4.Controls.Add(this.tbRoomNum);
            this.groupBox4.Location = new System.Drawing.Point(270, 24);
            this.groupBox4.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox4.Size = new System.Drawing.Size(74, 51);
            this.groupBox4.TabIndex = 25;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "테스트";
            // 
            // btnConnect
            // 
            this.btnConnect.Location = new System.Drawing.Point(8, 55);
            this.btnConnect.Margin = new System.Windows.Forms.Padding(4);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(96, 71);
            this.btnConnect.TabIndex = 5;
            this.btnConnect.Text = "서버 연결";
            this.btnConnect.UseVisualStyleBackColor = true;
            // 
            // btnViewRoomNum
            // 
            this.btnViewRoomNum.Location = new System.Drawing.Point(163, 56);
            this.btnViewRoomNum.Margin = new System.Windows.Forms.Padding(4);
            this.btnViewRoomNum.Name = "btnViewRoomNum";
            this.btnViewRoomNum.Size = new System.Drawing.Size(116, 31);
            this.btnViewRoomNum.TabIndex = 6;
            this.btnViewRoomNum.Text = "방 번호 조회";
            this.btnViewRoomNum.UseVisualStyleBackColor = true;
            // 
            // btnChangeRoomNum
            // 
            this.btnChangeRoomNum.Location = new System.Drawing.Point(163, 95);
            this.btnChangeRoomNum.Margin = new System.Windows.Forms.Padding(4);
            this.btnChangeRoomNum.Name = "btnChangeRoomNum";
            this.btnChangeRoomNum.Size = new System.Drawing.Size(116, 31);
            this.btnChangeRoomNum.TabIndex = 9;
            this.btnChangeRoomNum.Text = "방 번호 변경";
            this.btnChangeRoomNum.UseVisualStyleBackColor = true;
            // 
            // tbRoomNum
            // 
            this.tbRoomNum.Location = new System.Drawing.Point(163, 17);
            this.tbRoomNum.Margin = new System.Windows.Forms.Padding(4);
            this.tbRoomNum.Name = "tbRoomNum";
            this.tbRoomNum.Size = new System.Drawing.Size(115, 27);
            this.tbRoomNum.TabIndex = 8;
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1067, 558);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnSignIn);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox4);
            this.Name = "Form2";
            this.Text = "x";
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GroupBox groupBox2;
        private Button btnSend;
        private TextBox tbMessage;
        private TextBox tbRoomChat;
        private GroupBox groupBox1;
        private Button btnOutRoom2;
        private Button btnJoinRoom2;
        private TextBox tbRoomList2;
        private Button btnRoomCreate2;
        private TextBox tbRoomCount2;
        private Label label7;
        private TextBox tbRoomName2;
        private Label label6;
        private Button btnRefreshRoomList2;
        private Button btnSignIn;
        private Label label3;
        private GroupBox groupBox3;
        private TextBox tbUsername;
        private TextBox tbPassword;
        private Button btnSignUp;
        private Label label4;
        private Label label5;
        private GroupBox groupBox4;
        private Button btnConnect;
        private Button btnViewRoomNum;
        private Button btnChangeRoomNum;
        private TextBox tbRoomNum;
    }
}