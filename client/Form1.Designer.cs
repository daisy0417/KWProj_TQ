namespace ClientProgram
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.title_label = new System.Windows.Forms.Label();
            this.metroSetControlBox1 = new MetroSet_UI.Controls.MetroSetControlBox();
            this.midTitle_label = new System.Windows.Forms.Label();
            this.mainLogin_btn = new MetroSet_UI.Controls.MetroSetButton();
            this.login_panel = new System.Windows.Forms.Panel();
            this.login_btn = new MetroSet_UI.Controls.MetroSetButton();
            this.ip_label = new System.Windows.Forms.Label();
            this.name_label = new System.Windows.Forms.Label();
            this.tbUsername = new System.Windows.Forms.TextBox();
            this.tbPassword = new System.Windows.Forms.TextBox();
            this.btnSignIn = new System.Windows.Forms.Button();
            this.btnSignUp = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.mainTitle_label = new System.Windows.Forms.Label();
            this.gameStart_panel = new System.Windows.Forms.Panel();
            this.gameStart_btn = new MetroSet_UI.Controls.MetroSetButton();
            this.logout_btn = new MetroSet_UI.Controls.MetroSetButton();
            this.label3 = new System.Windows.Forms.Label();
            this.welcom_label = new System.Windows.Forms.Label();
            this.roomList_panel = new System.Windows.Forms.Panel();
            this.comein_label = new System.Windows.Forms.Label();
            this.roomPeople_label = new System.Windows.Forms.Label();
            this.btnRoomCreate = new MetroSet_UI.Controls.MetroSetButton();
            this.tbRoomCount = new System.Windows.Forms.TextBox();
            this.makeRoom_btn = new MetroSet_UI.Controls.MetroSetButton();
            this.btnOutRoom = new MetroSet_UI.Controls.MetroSetButton();
            this.btnJoinRoom = new MetroSet_UI.Controls.MetroSetButton();
            this.tbRefreshRoomList = new MetroSet_UI.Controls.MetroSetButton();
            this.tbRoomList = new System.Windows.Forms.TextBox();
            this.tbRoomName = new System.Windows.Forms.TextBox();
            this.roomName_label = new System.Windows.Forms.Label();
            this.login_panel.SuspendLayout();
            this.gameStart_panel.SuspendLayout();
            this.roomList_panel.SuspendLayout();
            this.SuspendLayout();
            // 
            // title_label
            // 
            this.title_label.AutoSize = true;
            this.title_label.Font = new System.Drawing.Font("한컴 말랑말랑 Bold", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.title_label.ForeColor = System.Drawing.SystemColors.Highlight;
            this.title_label.Location = new System.Drawing.Point(353, 115);
            this.title_label.Name = "title_label";
            this.title_label.Size = new System.Drawing.Size(358, 77);
            this.title_label.TabIndex = 0;
            this.title_label.Text = "스무고개 게임";
            this.title_label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // metroSetControlBox1
            // 
            this.metroSetControlBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.metroSetControlBox1.CloseHoverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(183)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.metroSetControlBox1.CloseHoverForeColor = System.Drawing.Color.White;
            this.metroSetControlBox1.CloseNormalForeColor = System.Drawing.Color.Gray;
            this.metroSetControlBox1.DisabledForeColor = System.Drawing.Color.DimGray;
            this.metroSetControlBox1.IsDerivedStyle = true;
            this.metroSetControlBox1.Location = new System.Drawing.Point(919, 12);
            this.metroSetControlBox1.MaximizeBox = true;
            this.metroSetControlBox1.MaximizeHoverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(238)))), ((int)(((byte)(238)))));
            this.metroSetControlBox1.MaximizeHoverForeColor = System.Drawing.Color.Gray;
            this.metroSetControlBox1.MaximizeNormalForeColor = System.Drawing.Color.Gray;
            this.metroSetControlBox1.MinimizeBox = true;
            this.metroSetControlBox1.MinimizeHoverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(238)))), ((int)(((byte)(238)))));
            this.metroSetControlBox1.MinimizeHoverForeColor = System.Drawing.Color.Gray;
            this.metroSetControlBox1.MinimizeNormalForeColor = System.Drawing.Color.Gray;
            this.metroSetControlBox1.Name = "metroSetControlBox1";
            this.metroSetControlBox1.Size = new System.Drawing.Size(100, 25);
            this.metroSetControlBox1.Style = MetroSet_UI.Enums.Style.Light;
            this.metroSetControlBox1.StyleManager = null;
            this.metroSetControlBox1.TabIndex = 1;
            this.metroSetControlBox1.Text = "metroSetControlBox1";
            this.metroSetControlBox1.ThemeAuthor = "Narwin";
            this.metroSetControlBox1.ThemeName = "MetroLite";
            // 
            // midTitle_label
            // 
            this.midTitle_label.AutoSize = true;
            this.midTitle_label.Font = new System.Drawing.Font("한컴 말랑말랑 Regular", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.midTitle_label.Location = new System.Drawing.Point(297, 253);
            this.midTitle_label.Name = "midTitle_label";
            this.midTitle_label.Size = new System.Drawing.Size(482, 38);
            this.midTitle_label.TabIndex = 2;
            this.midTitle_label.Text = "게임을 시작하려면 먼저 로그인해주세요";
            this.midTitle_label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // mainLogin_btn
            // 
            this.mainLogin_btn.DisabledBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(65)))), ((int)(((byte)(177)))), ((int)(((byte)(225)))));
            this.mainLogin_btn.DisabledBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(65)))), ((int)(((byte)(177)))), ((int)(((byte)(225)))));
            this.mainLogin_btn.DisabledForeColor = System.Drawing.Color.Gray;
            this.mainLogin_btn.Font = new System.Drawing.Font("한컴 말랑말랑 Bold", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.mainLogin_btn.HoverBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(207)))), ((int)(((byte)(255)))));
            this.mainLogin_btn.HoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(207)))), ((int)(((byte)(255)))));
            this.mainLogin_btn.HoverTextColor = System.Drawing.Color.White;
            this.mainLogin_btn.IsDerivedStyle = true;
            this.mainLogin_btn.Location = new System.Drawing.Point(365, 389);
            this.mainLogin_btn.Name = "mainLogin_btn";
            this.mainLogin_btn.NormalBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(177)))), ((int)(((byte)(225)))));
            this.mainLogin_btn.NormalColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(177)))), ((int)(((byte)(225)))));
            this.mainLogin_btn.NormalTextColor = System.Drawing.Color.White;
            this.mainLogin_btn.PressBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(147)))), ((int)(((byte)(195)))));
            this.mainLogin_btn.PressColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(147)))), ((int)(((byte)(195)))));
            this.mainLogin_btn.PressTextColor = System.Drawing.Color.White;
            this.mainLogin_btn.Size = new System.Drawing.Size(346, 92);
            this.mainLogin_btn.Style = MetroSet_UI.Enums.Style.Light;
            this.mainLogin_btn.StyleManager = null;
            this.mainLogin_btn.TabIndex = 3;
            this.mainLogin_btn.Text = "로그인";
            this.mainLogin_btn.ThemeAuthor = "Narwin";
            this.mainLogin_btn.ThemeName = "MetroLite";
            this.mainLogin_btn.Click += new System.EventHandler(this.mainLogin_btn_Click);
            // 
            // login_panel
            // 
            this.login_panel.Controls.Add(this.login_btn);
            this.login_panel.Controls.Add(this.ip_label);
            this.login_panel.Controls.Add(this.name_label);
            this.login_panel.Controls.Add(this.tbUsername);
            this.login_panel.Controls.Add(this.tbPassword);
            this.login_panel.Controls.Add(this.btnSignIn);
            this.login_panel.Controls.Add(this.btnSignUp);
            this.login_panel.Controls.Add(this.label2);
            this.login_panel.Controls.Add(this.label1);
            this.login_panel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.login_panel.Location = new System.Drawing.Point(20, 60);
            this.login_panel.Name = "login_panel";
            this.login_panel.Size = new System.Drawing.Size(984, 550);
            this.login_panel.TabIndex = 4;
            this.login_panel.Visible = false;
            // 
            // login_btn
            // 
            this.login_btn.DisabledBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(65)))), ((int)(((byte)(177)))), ((int)(((byte)(225)))));
            this.login_btn.DisabledBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(65)))), ((int)(((byte)(177)))), ((int)(((byte)(225)))));
            this.login_btn.DisabledForeColor = System.Drawing.Color.Gray;
            this.login_btn.Font = new System.Drawing.Font("한컴 말랑말랑 Regular", 28F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.login_btn.HoverBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(207)))), ((int)(((byte)(255)))));
            this.login_btn.HoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(207)))), ((int)(((byte)(255)))));
            this.login_btn.HoverTextColor = System.Drawing.Color.White;
            this.login_btn.IsDerivedStyle = true;
            this.login_btn.Location = new System.Drawing.Point(409, 427);
            this.login_btn.Name = "login_btn";
            this.login_btn.NormalBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(177)))), ((int)(((byte)(225)))));
            this.login_btn.NormalColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(177)))), ((int)(((byte)(225)))));
            this.login_btn.NormalTextColor = System.Drawing.Color.White;
            this.login_btn.PressBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(147)))), ((int)(((byte)(195)))));
            this.login_btn.PressColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(147)))), ((int)(((byte)(195)))));
            this.login_btn.PressTextColor = System.Drawing.Color.White;
            this.login_btn.Size = new System.Drawing.Size(239, 69);
            this.login_btn.Style = MetroSet_UI.Enums.Style.Light;
            this.login_btn.StyleManager = null;
            this.login_btn.TabIndex = 28;
            this.login_btn.Text = "로그인";
            this.login_btn.ThemeAuthor = "Narwin";
            this.login_btn.ThemeName = "MetroLite";
            this.login_btn.Click += new System.EventHandler(this.login_btn_Click);
            // 
            // ip_label
            // 
            this.ip_label.AutoSize = true;
            this.ip_label.Font = new System.Drawing.Font("한컴 말랑말랑 Regular", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ip_label.Location = new System.Drawing.Point(282, 312);
            this.ip_label.Name = "ip_label";
            this.ip_label.Size = new System.Drawing.Size(40, 35);
            this.ip_label.TabIndex = 27;
            this.ip_label.Text = "IP";
            // 
            // name_label
            // 
            this.name_label.AutoSize = true;
            this.name_label.Font = new System.Drawing.Font("한컴 말랑말랑 Regular", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.name_label.Location = new System.Drawing.Point(282, 206);
            this.name_label.Name = "name_label";
            this.name_label.Size = new System.Drawing.Size(61, 35);
            this.name_label.TabIndex = 26;
            this.name_label.Text = "이름";
            // 
            // tbUsername
            // 
            this.tbUsername.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbUsername.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.tbUsername.Font = new System.Drawing.Font("한컴 말랑말랑 Bold", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.tbUsername.ForeColor = System.Drawing.SystemColors.Highlight;
            this.tbUsername.Location = new System.Drawing.Point(284, 243);
            this.tbUsername.Margin = new System.Windows.Forms.Padding(4);
            this.tbUsername.Name = "tbUsername";
            this.tbUsername.Size = new System.Drawing.Size(493, 42);
            this.tbUsername.TabIndex = 22;
            // 
            // tbPassword
            // 
            this.tbPassword.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbPassword.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.tbPassword.Font = new System.Drawing.Font("한컴 말랑말랑 Bold", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.tbPassword.ForeColor = System.Drawing.SystemColors.Highlight;
            this.tbPassword.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.tbPassword.Location = new System.Drawing.Point(284, 349);
            this.tbPassword.Margin = new System.Windows.Forms.Padding(4);
            this.tbPassword.Name = "tbPassword";
            this.tbPassword.Size = new System.Drawing.Size(493, 42);
            this.tbPassword.TabIndex = 23;
            // 
            // btnSignIn
            // 
            this.btnSignIn.Location = new System.Drawing.Point(856, 29);
            this.btnSignIn.Margin = new System.Windows.Forms.Padding(4);
            this.btnSignIn.Name = "btnSignIn";
            this.btnSignIn.Size = new System.Drawing.Size(96, 31);
            this.btnSignIn.TabIndex = 25;
            this.btnSignIn.Text = "로그인";
            this.btnSignIn.UseVisualStyleBackColor = true;
            this.btnSignIn.Click += new System.EventHandler(this.btnSignIn_Click);
            // 
            // btnSignUp
            // 
            this.btnSignUp.Location = new System.Drawing.Point(856, 85);
            this.btnSignUp.Margin = new System.Windows.Forms.Padding(4);
            this.btnSignUp.Name = "btnSignUp";
            this.btnSignUp.Size = new System.Drawing.Size(96, 31);
            this.btnSignUp.TabIndex = 24;
            this.btnSignUp.Text = "회원가입";
            this.btnSignUp.UseVisualStyleBackColor = true;
            this.btnSignUp.Click += new System.EventHandler(this.btnSignUp_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("한컴 말랑말랑 Bold", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(284, 121);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(465, 38);
            this.label2.TabIndex = 1;
            this.label2.Text = "이름과 접속할 서버 IP를 입력해주세요";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("한컴 말랑말랑 Bold", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.ForeColor = System.Drawing.SystemColors.Highlight;
            this.label1.Location = new System.Drawing.Point(398, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(232, 77);
            this.label1.TabIndex = 0;
            this.label1.Text = "LOGIN";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // mainTitle_label
            // 
            this.mainTitle_label.AutoSize = true;
            this.mainTitle_label.Font = new System.Drawing.Font("한컴 말랑말랑 Bold", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.mainTitle_label.ForeColor = System.Drawing.SystemColors.Highlight;
            this.mainTitle_label.Location = new System.Drawing.Point(20, 24);
            this.mainTitle_label.Name = "mainTitle_label";
            this.mainTitle_label.Size = new System.Drawing.Size(162, 35);
            this.mainTitle_label.TabIndex = 6;
            this.mainTitle_label.Text = "스무고개 게임";
            this.mainTitle_label.Visible = false;
            // 
            // gameStart_panel
            // 
            this.gameStart_panel.Controls.Add(this.gameStart_btn);
            this.gameStart_panel.Controls.Add(this.logout_btn);
            this.gameStart_panel.Controls.Add(this.label3);
            this.gameStart_panel.Controls.Add(this.welcom_label);
            this.gameStart_panel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gameStart_panel.Font = new System.Drawing.Font("한컴 말랑말랑 Bold", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.gameStart_panel.Location = new System.Drawing.Point(20, 60);
            this.gameStart_panel.Name = "gameStart_panel";
            this.gameStart_panel.Size = new System.Drawing.Size(984, 550);
            this.gameStart_panel.TabIndex = 7;
            this.gameStart_panel.Visible = false;
            // 
            // gameStart_btn
            // 
            this.gameStart_btn.DisabledBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(65)))), ((int)(((byte)(177)))), ((int)(((byte)(225)))));
            this.gameStart_btn.DisabledBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(65)))), ((int)(((byte)(177)))), ((int)(((byte)(225)))));
            this.gameStart_btn.DisabledForeColor = System.Drawing.Color.Gray;
            this.gameStart_btn.Font = new System.Drawing.Font("한컴 말랑말랑 Bold", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.gameStart_btn.HoverBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(207)))), ((int)(((byte)(255)))));
            this.gameStart_btn.HoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(207)))), ((int)(((byte)(255)))));
            this.gameStart_btn.HoverTextColor = System.Drawing.Color.White;
            this.gameStart_btn.IsDerivedStyle = true;
            this.gameStart_btn.Location = new System.Drawing.Point(302, 398);
            this.gameStart_btn.Name = "gameStart_btn";
            this.gameStart_btn.NormalBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(177)))), ((int)(((byte)(225)))));
            this.gameStart_btn.NormalColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(177)))), ((int)(((byte)(225)))));
            this.gameStart_btn.NormalTextColor = System.Drawing.Color.White;
            this.gameStart_btn.PressBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(147)))), ((int)(((byte)(195)))));
            this.gameStart_btn.PressColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(147)))), ((int)(((byte)(195)))));
            this.gameStart_btn.PressTextColor = System.Drawing.Color.White;
            this.gameStart_btn.Size = new System.Drawing.Size(457, 65);
            this.gameStart_btn.Style = MetroSet_UI.Enums.Style.Light;
            this.gameStart_btn.StyleManager = null;
            this.gameStart_btn.TabIndex = 3;
            this.gameStart_btn.Text = "게임 시작하기";
            this.gameStart_btn.ThemeAuthor = "Narwin";
            this.gameStart_btn.ThemeName = "MetroLite";
            this.gameStart_btn.Click += new System.EventHandler(this.gameStart_btn_Click);
            // 
            // logout_btn
            // 
            this.logout_btn.DisabledBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(65)))), ((int)(((byte)(177)))), ((int)(((byte)(225)))));
            this.logout_btn.DisabledBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(65)))), ((int)(((byte)(177)))), ((int)(((byte)(225)))));
            this.logout_btn.DisabledForeColor = System.Drawing.Color.Gray;
            this.logout_btn.Font = new System.Drawing.Font("한컴 말랑말랑 Bold", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.logout_btn.HoverBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(207)))), ((int)(((byte)(255)))));
            this.logout_btn.HoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(207)))), ((int)(((byte)(255)))));
            this.logout_btn.HoverTextColor = System.Drawing.Color.White;
            this.logout_btn.IsDerivedStyle = true;
            this.logout_btn.Location = new System.Drawing.Point(302, 300);
            this.logout_btn.Name = "logout_btn";
            this.logout_btn.NormalBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(177)))), ((int)(((byte)(225)))));
            this.logout_btn.NormalColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(177)))), ((int)(((byte)(225)))));
            this.logout_btn.NormalTextColor = System.Drawing.Color.White;
            this.logout_btn.PressBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(147)))), ((int)(((byte)(195)))));
            this.logout_btn.PressColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(147)))), ((int)(((byte)(195)))));
            this.logout_btn.PressTextColor = System.Drawing.Color.White;
            this.logout_btn.Size = new System.Drawing.Size(457, 65);
            this.logout_btn.Style = MetroSet_UI.Enums.Style.Light;
            this.logout_btn.StyleManager = null;
            this.logout_btn.TabIndex = 2;
            this.logout_btn.Text = "로그아웃";
            this.logout_btn.ThemeAuthor = "Narwin";
            this.logout_btn.ThemeName = "MetroLite";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("한컴 말랑말랑 Bold", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label3.ForeColor = System.Drawing.SystemColors.Highlight;
            this.label3.Location = new System.Drawing.Point(333, 39);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(358, 77);
            this.label3.TabIndex = 0;
            this.label3.Text = "스무고개 게임";
            // 
            // welcom_label
            // 
            this.welcom_label.AutoSize = true;
            this.welcom_label.Font = new System.Drawing.Font("한컴 말랑말랑 Bold", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.welcom_label.Location = new System.Drawing.Point(405, 172);
            this.welcom_label.Name = "welcom_label";
            this.welcom_label.Size = new System.Drawing.Size(0, 36);
            this.welcom_label.TabIndex = 1;
            this.welcom_label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // roomList_panel
            // 
            this.roomList_panel.Controls.Add(this.comein_label);
            this.roomList_panel.Controls.Add(this.roomPeople_label);
            this.roomList_panel.Controls.Add(this.btnRoomCreate);
            this.roomList_panel.Controls.Add(this.tbRoomCount);
            this.roomList_panel.Controls.Add(this.makeRoom_btn);
            this.roomList_panel.Controls.Add(this.btnOutRoom);
            this.roomList_panel.Controls.Add(this.btnJoinRoom);
            this.roomList_panel.Controls.Add(this.tbRefreshRoomList);
            this.roomList_panel.Controls.Add(this.tbRoomList);
            this.roomList_panel.Controls.Add(this.tbRoomName);
            this.roomList_panel.Controls.Add(this.roomName_label);
            this.roomList_panel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.roomList_panel.Location = new System.Drawing.Point(20, 60);
            this.roomList_panel.Name = "roomList_panel";
            this.roomList_panel.Size = new System.Drawing.Size(984, 550);
            this.roomList_panel.TabIndex = 8;
            this.roomList_panel.Visible = false;
            this.roomList_panel.VisibleChanged += new System.EventHandler(this.roomList_panel_VisibleChanged);
            // 
            // comein_label
            // 
            this.comein_label.AutoSize = true;
            this.comein_label.Font = new System.Drawing.Font("한컴 말랑말랑 Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.comein_label.Location = new System.Drawing.Point(817, 31);
            this.comein_label.Name = "comein_label";
            this.comein_label.Size = new System.Drawing.Size(0, 26);
            this.comein_label.TabIndex = 34;
            this.comein_label.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // roomPeople_label
            // 
            this.roomPeople_label.AutoSize = true;
            this.roomPeople_label.Font = new System.Drawing.Font("한컴 말랑말랑 Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.roomPeople_label.Location = new System.Drawing.Point(804, 271);
            this.roomPeople_label.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.roomPeople_label.Name = "roomPeople_label";
            this.roomPeople_label.Size = new System.Drawing.Size(89, 26);
            this.roomPeople_label.TabIndex = 33;
            this.roomPeople_label.Text = "최대 정원";
            this.roomPeople_label.Visible = false;
            // 
            // btnRoomCreate
            // 
            this.btnRoomCreate.DisabledBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(65)))), ((int)(((byte)(177)))), ((int)(((byte)(225)))));
            this.btnRoomCreate.DisabledBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(65)))), ((int)(((byte)(177)))), ((int)(((byte)(225)))));
            this.btnRoomCreate.DisabledForeColor = System.Drawing.Color.Gray;
            this.btnRoomCreate.Font = new System.Drawing.Font("한컴 말랑말랑 Bold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnRoomCreate.HoverBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(207)))), ((int)(((byte)(255)))));
            this.btnRoomCreate.HoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(207)))), ((int)(((byte)(255)))));
            this.btnRoomCreate.HoverTextColor = System.Drawing.Color.White;
            this.btnRoomCreate.IsDerivedStyle = true;
            this.btnRoomCreate.Location = new System.Drawing.Point(804, 343);
            this.btnRoomCreate.Name = "btnRoomCreate";
            this.btnRoomCreate.NormalBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(177)))), ((int)(((byte)(225)))));
            this.btnRoomCreate.NormalColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(177)))), ((int)(((byte)(225)))));
            this.btnRoomCreate.NormalTextColor = System.Drawing.Color.White;
            this.btnRoomCreate.PressBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(147)))), ((int)(((byte)(195)))));
            this.btnRoomCreate.PressColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(147)))), ((int)(((byte)(195)))));
            this.btnRoomCreate.PressTextColor = System.Drawing.Color.White;
            this.btnRoomCreate.Size = new System.Drawing.Size(156, 32);
            this.btnRoomCreate.Style = MetroSet_UI.Enums.Style.Light;
            this.btnRoomCreate.StyleManager = null;
            this.btnRoomCreate.TabIndex = 32;
            this.btnRoomCreate.Text = "생성하기";
            this.btnRoomCreate.ThemeAuthor = "Narwin";
            this.btnRoomCreate.ThemeName = "MetroLite";
            this.btnRoomCreate.Visible = false;
            this.btnRoomCreate.Click += new System.EventHandler(this.btnRoomCreate_Click);
            // 
            // tbRoomCount
            // 
            this.tbRoomCount.Font = new System.Drawing.Font("한컴 말랑말랑 Bold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.tbRoomCount.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.tbRoomCount.Location = new System.Drawing.Point(804, 301);
            this.tbRoomCount.Margin = new System.Windows.Forms.Padding(4);
            this.tbRoomCount.Name = "tbRoomCount";
            this.tbRoomCount.Size = new System.Drawing.Size(156, 33);
            this.tbRoomCount.TabIndex = 31;
            this.tbRoomCount.Visible = false;
            // 
            // makeRoom_btn
            // 
            this.makeRoom_btn.DisabledBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(65)))), ((int)(((byte)(177)))), ((int)(((byte)(225)))));
            this.makeRoom_btn.DisabledBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(65)))), ((int)(((byte)(177)))), ((int)(((byte)(225)))));
            this.makeRoom_btn.DisabledForeColor = System.Drawing.Color.Gray;
            this.makeRoom_btn.Font = new System.Drawing.Font("한컴 말랑말랑 Bold", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.makeRoom_btn.HoverBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(207)))), ((int)(((byte)(255)))));
            this.makeRoom_btn.HoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(207)))), ((int)(((byte)(255)))));
            this.makeRoom_btn.HoverTextColor = System.Drawing.Color.White;
            this.makeRoom_btn.IsDerivedStyle = true;
            this.makeRoom_btn.Location = new System.Drawing.Point(804, 95);
            this.makeRoom_btn.Name = "makeRoom_btn";
            this.makeRoom_btn.NormalBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(177)))), ((int)(((byte)(225)))));
            this.makeRoom_btn.NormalColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(177)))), ((int)(((byte)(225)))));
            this.makeRoom_btn.NormalTextColor = System.Drawing.Color.White;
            this.makeRoom_btn.PressBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(147)))), ((int)(((byte)(195)))));
            this.makeRoom_btn.PressColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(147)))), ((int)(((byte)(195)))));
            this.makeRoom_btn.PressTextColor = System.Drawing.Color.White;
            this.makeRoom_btn.Size = new System.Drawing.Size(156, 49);
            this.makeRoom_btn.Style = MetroSet_UI.Enums.Style.Light;
            this.makeRoom_btn.StyleManager = null;
            this.makeRoom_btn.TabIndex = 30;
            this.makeRoom_btn.Text = "방 만들기";
            this.makeRoom_btn.ThemeAuthor = "Narwin";
            this.makeRoom_btn.ThemeName = "MetroLite";
            this.makeRoom_btn.Click += new System.EventHandler(this.makeRoom_btn_Click);
            // 
            // btnOutRoom
            // 
            this.btnOutRoom.DisabledBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(65)))), ((int)(((byte)(177)))), ((int)(((byte)(225)))));
            this.btnOutRoom.DisabledBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(65)))), ((int)(((byte)(177)))), ((int)(((byte)(225)))));
            this.btnOutRoom.DisabledForeColor = System.Drawing.Color.Gray;
            this.btnOutRoom.Font = new System.Drawing.Font("한컴 말랑말랑 Bold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnOutRoom.HoverBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(207)))), ((int)(((byte)(255)))));
            this.btnOutRoom.HoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(207)))), ((int)(((byte)(255)))));
            this.btnOutRoom.HoverTextColor = System.Drawing.Color.White;
            this.btnOutRoom.IsDerivedStyle = true;
            this.btnOutRoom.Location = new System.Drawing.Point(804, 487);
            this.btnOutRoom.Name = "btnOutRoom";
            this.btnOutRoom.NormalBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(177)))), ((int)(((byte)(225)))));
            this.btnOutRoom.NormalColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(177)))), ((int)(((byte)(225)))));
            this.btnOutRoom.NormalTextColor = System.Drawing.Color.White;
            this.btnOutRoom.PressBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(147)))), ((int)(((byte)(195)))));
            this.btnOutRoom.PressColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(147)))), ((int)(((byte)(195)))));
            this.btnOutRoom.PressTextColor = System.Drawing.Color.White;
            this.btnOutRoom.Size = new System.Drawing.Size(156, 32);
            this.btnOutRoom.Style = MetroSet_UI.Enums.Style.Light;
            this.btnOutRoom.StyleManager = null;
            this.btnOutRoom.TabIndex = 29;
            this.btnOutRoom.Text = "퇴장하기";
            this.btnOutRoom.ThemeAuthor = "Narwin";
            this.btnOutRoom.ThemeName = "MetroLite";
            this.btnOutRoom.Click += new System.EventHandler(this.btnOutRoom_Click);
            // 
            // btnJoinRoom
            // 
            this.btnJoinRoom.DisabledBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(65)))), ((int)(((byte)(177)))), ((int)(((byte)(225)))));
            this.btnJoinRoom.DisabledBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(65)))), ((int)(((byte)(177)))), ((int)(((byte)(225)))));
            this.btnJoinRoom.DisabledForeColor = System.Drawing.Color.Gray;
            this.btnJoinRoom.Font = new System.Drawing.Font("한컴 말랑말랑 Bold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnJoinRoom.HoverBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(207)))), ((int)(((byte)(255)))));
            this.btnJoinRoom.HoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(207)))), ((int)(((byte)(255)))));
            this.btnJoinRoom.HoverTextColor = System.Drawing.Color.White;
            this.btnJoinRoom.IsDerivedStyle = true;
            this.btnJoinRoom.Location = new System.Drawing.Point(804, 443);
            this.btnJoinRoom.Name = "btnJoinRoom";
            this.btnJoinRoom.NormalBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(177)))), ((int)(((byte)(225)))));
            this.btnJoinRoom.NormalColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(177)))), ((int)(((byte)(225)))));
            this.btnJoinRoom.NormalTextColor = System.Drawing.Color.White;
            this.btnJoinRoom.PressBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(147)))), ((int)(((byte)(195)))));
            this.btnJoinRoom.PressColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(147)))), ((int)(((byte)(195)))));
            this.btnJoinRoom.PressTextColor = System.Drawing.Color.White;
            this.btnJoinRoom.Size = new System.Drawing.Size(156, 32);
            this.btnJoinRoom.Style = MetroSet_UI.Enums.Style.Light;
            this.btnJoinRoom.StyleManager = null;
            this.btnJoinRoom.TabIndex = 28;
            this.btnJoinRoom.Text = "입장하기";
            this.btnJoinRoom.ThemeAuthor = "Narwin";
            this.btnJoinRoom.ThemeName = "MetroLite";
            this.btnJoinRoom.Click += new System.EventHandler(this.btnJoinRoom_Click);
            // 
            // tbRefreshRoomList
            // 
            this.tbRefreshRoomList.DisabledBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(65)))), ((int)(((byte)(177)))), ((int)(((byte)(225)))));
            this.tbRefreshRoomList.DisabledBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(65)))), ((int)(((byte)(177)))), ((int)(((byte)(225)))));
            this.tbRefreshRoomList.DisabledForeColor = System.Drawing.Color.Gray;
            this.tbRefreshRoomList.Font = new System.Drawing.Font("한컴 말랑말랑 Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.tbRefreshRoomList.HoverBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(207)))), ((int)(((byte)(255)))));
            this.tbRefreshRoomList.HoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(207)))), ((int)(((byte)(255)))));
            this.tbRefreshRoomList.HoverTextColor = System.Drawing.Color.White;
            this.tbRefreshRoomList.IsDerivedStyle = true;
            this.tbRefreshRoomList.Location = new System.Drawing.Point(24, 51);
            this.tbRefreshRoomList.Name = "tbRefreshRoomList";
            this.tbRefreshRoomList.NormalBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(177)))), ((int)(((byte)(225)))));
            this.tbRefreshRoomList.NormalColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(177)))), ((int)(((byte)(225)))));
            this.tbRefreshRoomList.NormalTextColor = System.Drawing.Color.White;
            this.tbRefreshRoomList.PressBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(147)))), ((int)(((byte)(195)))));
            this.tbRefreshRoomList.PressColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(147)))), ((int)(((byte)(195)))));
            this.tbRefreshRoomList.PressTextColor = System.Drawing.Color.White;
            this.tbRefreshRoomList.Size = new System.Drawing.Size(109, 32);
            this.tbRefreshRoomList.Style = MetroSet_UI.Enums.Style.Light;
            this.tbRefreshRoomList.StyleManager = null;
            this.tbRefreshRoomList.TabIndex = 27;
            this.tbRefreshRoomList.Text = "새로고침";
            this.tbRefreshRoomList.ThemeAuthor = "Narwin";
            this.tbRefreshRoomList.ThemeName = "MetroLite";
            this.tbRefreshRoomList.Click += new System.EventHandler(this.btnRefreshRoomList_Click);
            // 
            // tbRoomList
            // 
            this.tbRoomList.BackColor = System.Drawing.SystemColors.HighlightText;
            this.tbRoomList.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbRoomList.Location = new System.Drawing.Point(24, 95);
            this.tbRoomList.Margin = new System.Windows.Forms.Padding(4);
            this.tbRoomList.Multiline = true;
            this.tbRoomList.Name = "tbRoomList";
            this.tbRoomList.ReadOnly = true;
            this.tbRoomList.Size = new System.Drawing.Size(734, 424);
            this.tbRoomList.TabIndex = 7;
            // 
            // tbRoomName
            // 
            this.tbRoomName.Font = new System.Drawing.Font("한컴 말랑말랑 Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.tbRoomName.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.tbRoomName.Location = new System.Drawing.Point(804, 211);
            this.tbRoomName.Margin = new System.Windows.Forms.Padding(4);
            this.tbRoomName.Name = "tbRoomName";
            this.tbRoomName.Size = new System.Drawing.Size(156, 33);
            this.tbRoomName.TabIndex = 25;
            // 
            // roomName_label
            // 
            this.roomName_label.AutoSize = true;
            this.roomName_label.Font = new System.Drawing.Font("한컴 말랑말랑 Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.roomName_label.Location = new System.Drawing.Point(804, 182);
            this.roomName_label.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.roomName_label.Name = "roomName_label";
            this.roomName_label.Size = new System.Drawing.Size(70, 26);
            this.roomName_label.TabIndex = 24;
            this.roomName_label.Text = "방 이름";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1024, 630);
            this.ControlBox = false;
            this.Controls.Add(this.roomList_panel);
            this.Controls.Add(this.gameStart_panel);
            this.Controls.Add(this.mainTitle_label);
            this.Controls.Add(this.login_panel);
            this.Controls.Add(this.mainLogin_btn);
            this.Controls.Add(this.midTitle_label);
            this.Controls.Add(this.metroSetControlBox1);
            this.Controls.Add(this.title_label);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.login_panel.ResumeLayout(false);
            this.login_panel.PerformLayout();
            this.gameStart_panel.ResumeLayout(false);
            this.gameStart_panel.PerformLayout();
            this.roomList_panel.ResumeLayout(false);
            this.roomList_panel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label title_label;
        private MetroSet_UI.Controls.MetroSetControlBox metroSetControlBox1;
        private Label midTitle_label;
        private MetroSet_UI.Controls.MetroSetButton mainLogin_btn;
        private Panel login_panel;
        private Label label2;
        private Label label1;
        private MetroSet_UI.Controls.MetroSetButton login_btn;
        private Label ip_label;
        private Label name_label;
        private TextBox tbUsername;
        private TextBox tbPassword;
        private Button btnSignIn;
        private Button btnSignUp;
        private Label mainTitle_label;
        private Panel gameStart_panel;
        private Label label3;
        private MetroSet_UI.Controls.MetroSetButton logout_btn;
        private Label welcom_label;
        private MetroSet_UI.Controls.MetroSetButton gameStart_btn;
        private Panel roomList_panel;
        private Label comein_label;
        private Label roomPeople_label;
        private MetroSet_UI.Controls.MetroSetButton btnRoomCreate;
        private TextBox tbRoomCount;
        private MetroSet_UI.Controls.MetroSetButton makeRoom_btn;
        private MetroSet_UI.Controls.MetroSetButton btnOutRoom;
        private MetroSet_UI.Controls.MetroSetButton btnJoinRoom;
        private MetroSet_UI.Controls.MetroSetButton tbRefreshRoomList;
        private TextBox tbRoomList;
        private TextBox tbRoomName;
        private Label roomName_label;
    }
}