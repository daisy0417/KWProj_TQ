namespace client
{
    partial class MainForm
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.main_title_label = new System.Windows.Forms.Label();
            this.metroSetControlBox1 = new MetroSet_UI.Controls.MetroSetControlBox();
            this.main_midTitle_label = new System.Windows.Forms.Label();
            this.main_login_btn = new MetroSet_UI.Controls.MetroSetButton();
            this.panel1_login = new System.Windows.Forms.Panel();
            this.p1_gameStart_btn = new MetroSet_UI.Controls.MetroSetButton();
            this.p1_1_ip_panel = new System.Windows.Forms.Panel();
            this.p1_ip_label = new System.Windows.Forms.Label();
            this.p1_ip_tbx = new System.Windows.Forms.TextBox();
            this.p1_connect_btn = new MetroSet_UI.Controls.MetroSetButton();
            this.p1_login_btn = new MetroSet_UI.Controls.MetroSetButton();
            this.p1_pw_tbx = new System.Windows.Forms.TextBox();
            this.p1_username_tbx = new System.Windows.Forms.TextBox();
            this.p1_pw_label = new System.Windows.Forms.Label();
            this.p1_userName_label = new System.Windows.Forms.Label();
            this.p1_title_label = new System.Windows.Forms.Label();
            this.panel1_login.SuspendLayout();
            this.p1_1_ip_panel.SuspendLayout();
            this.SuspendLayout();
            // 
            // main_title_label
            // 
            this.main_title_label.AutoSize = true;
            this.main_title_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 40F);
            this.main_title_label.ForeColor = System.Drawing.SystemColors.Highlight;
            this.main_title_label.Location = new System.Drawing.Point(296, 87);
            this.main_title_label.Name = "main_title_label";
            this.main_title_label.Size = new System.Drawing.Size(317, 63);
            this.main_title_label.TabIndex = 0;
            this.main_title_label.Text = "스무고개 게임";
            // 
            // metroSetControlBox1
            // 
            this.metroSetControlBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.metroSetControlBox1.CloseHoverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(183)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.metroSetControlBox1.CloseHoverForeColor = System.Drawing.Color.White;
            this.metroSetControlBox1.CloseNormalForeColor = System.Drawing.Color.Gray;
            this.metroSetControlBox1.DisabledForeColor = System.Drawing.Color.DimGray;
            this.metroSetControlBox1.IsDerivedStyle = true;
            this.metroSetControlBox1.Location = new System.Drawing.Point(788, 13);
            this.metroSetControlBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
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
            // main_midTitle_label
            // 
            this.main_midTitle_label.AutoSize = true;
            this.main_midTitle_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.main_midTitle_label.Location = new System.Drawing.Point(284, 189);
            this.main_midTitle_label.Name = "main_midTitle_label";
            this.main_midTitle_label.Size = new System.Drawing.Size(319, 26);
            this.main_midTitle_label.TabIndex = 2;
            this.main_midTitle_label.Text = "게임을 시작하려면 먼저 로그인해주세요";
            // 
            // main_login_btn
            // 
            this.main_login_btn.DisabledBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(65)))), ((int)(((byte)(177)))), ((int)(((byte)(225)))));
            this.main_login_btn.DisabledBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(65)))), ((int)(((byte)(177)))), ((int)(((byte)(225)))));
            this.main_login_btn.DisabledForeColor = System.Drawing.Color.Gray;
            this.main_login_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F);
            this.main_login_btn.HoverBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(207)))), ((int)(((byte)(255)))));
            this.main_login_btn.HoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(207)))), ((int)(((byte)(255)))));
            this.main_login_btn.HoverTextColor = System.Drawing.Color.White;
            this.main_login_btn.IsDerivedStyle = true;
            this.main_login_btn.Location = new System.Drawing.Point(315, 314);
            this.main_login_btn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.main_login_btn.Name = "main_login_btn";
            this.main_login_btn.NormalBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(177)))), ((int)(((byte)(225)))));
            this.main_login_btn.NormalColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(177)))), ((int)(((byte)(225)))));
            this.main_login_btn.NormalTextColor = System.Drawing.Color.White;
            this.main_login_btn.PressBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(147)))), ((int)(((byte)(195)))));
            this.main_login_btn.PressColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(147)))), ((int)(((byte)(195)))));
            this.main_login_btn.PressTextColor = System.Drawing.Color.White;
            this.main_login_btn.Size = new System.Drawing.Size(301, 58);
            this.main_login_btn.Style = MetroSet_UI.Enums.Style.Light;
            this.main_login_btn.StyleManager = null;
            this.main_login_btn.TabIndex = 3;
            this.main_login_btn.Text = "로그인하기";
            this.main_login_btn.ThemeAuthor = "Narwin";
            this.main_login_btn.ThemeName = "MetroLite";
            this.main_login_btn.Click += new System.EventHandler(this.main_login_btn_Click);
            // 
            // panel1_login
            // 
            this.panel1_login.Controls.Add(this.p1_gameStart_btn);
            this.panel1_login.Controls.Add(this.p1_1_ip_panel);
            this.panel1_login.Controls.Add(this.p1_connect_btn);
            this.panel1_login.Controls.Add(this.p1_login_btn);
            this.panel1_login.Controls.Add(this.p1_pw_tbx);
            this.panel1_login.Controls.Add(this.p1_username_tbx);
            this.panel1_login.Controls.Add(this.p1_pw_label);
            this.panel1_login.Controls.Add(this.p1_userName_label);
            this.panel1_login.Controls.Add(this.p1_title_label);
            this.panel1_login.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1_login.Font = new System.Drawing.Font("굴림", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.panel1_login.Location = new System.Drawing.Point(16, 38);
            this.panel1_login.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel1_login.Name = "panel1_login";
            this.panel1_login.Size = new System.Drawing.Size(864, 453);
            this.panel1_login.TabIndex = 4;
            this.panel1_login.Visible = false;
            // 
            // p1_gameStart_btn
            // 
            this.p1_gameStart_btn.DisabledBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(65)))), ((int)(((byte)(177)))), ((int)(((byte)(225)))));
            this.p1_gameStart_btn.DisabledBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(65)))), ((int)(((byte)(177)))), ((int)(((byte)(225)))));
            this.p1_gameStart_btn.DisabledForeColor = System.Drawing.Color.Gray;
            this.p1_gameStart_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F);
            this.p1_gameStart_btn.HoverBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(207)))), ((int)(((byte)(255)))));
            this.p1_gameStart_btn.HoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(207)))), ((int)(((byte)(255)))));
            this.p1_gameStart_btn.HoverTextColor = System.Drawing.Color.White;
            this.p1_gameStart_btn.IsDerivedStyle = true;
            this.p1_gameStart_btn.Location = new System.Drawing.Point(353, 325);
            this.p1_gameStart_btn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.p1_gameStart_btn.Name = "p1_gameStart_btn";
            this.p1_gameStart_btn.NormalBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(177)))), ((int)(((byte)(225)))));
            this.p1_gameStart_btn.NormalColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(177)))), ((int)(((byte)(225)))));
            this.p1_gameStart_btn.NormalTextColor = System.Drawing.Color.White;
            this.p1_gameStart_btn.PressBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(147)))), ((int)(((byte)(195)))));
            this.p1_gameStart_btn.PressColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(147)))), ((int)(((byte)(195)))));
            this.p1_gameStart_btn.PressTextColor = System.Drawing.Color.White;
            this.p1_gameStart_btn.Size = new System.Drawing.Size(185, 47);
            this.p1_gameStart_btn.Style = MetroSet_UI.Enums.Style.Light;
            this.p1_gameStart_btn.StyleManager = null;
            this.p1_gameStart_btn.TabIndex = 14;
            this.p1_gameStart_btn.Text = "게임 시작하기";
            this.p1_gameStart_btn.ThemeAuthor = "Narwin";
            this.p1_gameStart_btn.ThemeName = "MetroLite";
            this.p1_gameStart_btn.Visible = false;
            // 
            // p1_1_ip_panel
            // 
            this.p1_1_ip_panel.Controls.Add(this.p1_ip_label);
            this.p1_1_ip_panel.Controls.Add(this.p1_ip_tbx);
            this.p1_1_ip_panel.Location = new System.Drawing.Point(210, 79);
            this.p1_1_ip_panel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.p1_1_ip_panel.Name = "p1_1_ip_panel";
            this.p1_1_ip_panel.Size = new System.Drawing.Size(511, 241);
            this.p1_1_ip_panel.TabIndex = 5;
            this.p1_1_ip_panel.Visible = false;
            // 
            // p1_ip_label
            // 
            this.p1_ip_label.AutoSize = true;
            this.p1_ip_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.p1_ip_label.Location = new System.Drawing.Point(82, 62);
            this.p1_ip_label.Name = "p1_ip_label";
            this.p1_ip_label.Size = new System.Drawing.Size(33, 26);
            this.p1_ip_label.TabIndex = 13;
            this.p1_ip_label.Text = "IP";
            this.p1_ip_label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // p1_ip_tbx
            // 
            this.p1_ip_tbx.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.p1_ip_tbx.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.p1_ip_tbx.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.p1_ip_tbx.Location = new System.Drawing.Point(81, 94);
            this.p1_ip_tbx.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.p1_ip_tbx.Name = "p1_ip_tbx";
            this.p1_ip_tbx.Size = new System.Drawing.Size(316, 32);
            this.p1_ip_tbx.TabIndex = 12;
            this.p1_ip_tbx.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.p1_ip_tbx_KeyPress);
            // 
            // p1_connect_btn
            // 
            this.p1_connect_btn.DisabledBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(65)))), ((int)(((byte)(177)))), ((int)(((byte)(225)))));
            this.p1_connect_btn.DisabledBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(65)))), ((int)(((byte)(177)))), ((int)(((byte)(225)))));
            this.p1_connect_btn.DisabledForeColor = System.Drawing.Color.Gray;
            this.p1_connect_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F);
            this.p1_connect_btn.HoverBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(207)))), ((int)(((byte)(255)))));
            this.p1_connect_btn.HoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(207)))), ((int)(((byte)(255)))));
            this.p1_connect_btn.HoverTextColor = System.Drawing.Color.White;
            this.p1_connect_btn.IsDerivedStyle = true;
            this.p1_connect_btn.Location = new System.Drawing.Point(353, 325);
            this.p1_connect_btn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.p1_connect_btn.Name = "p1_connect_btn";
            this.p1_connect_btn.NormalBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(177)))), ((int)(((byte)(225)))));
            this.p1_connect_btn.NormalColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(177)))), ((int)(((byte)(225)))));
            this.p1_connect_btn.NormalTextColor = System.Drawing.Color.White;
            this.p1_connect_btn.PressBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(147)))), ((int)(((byte)(195)))));
            this.p1_connect_btn.PressColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(147)))), ((int)(((byte)(195)))));
            this.p1_connect_btn.PressTextColor = System.Drawing.Color.White;
            this.p1_connect_btn.Size = new System.Drawing.Size(185, 47);
            this.p1_connect_btn.Style = MetroSet_UI.Enums.Style.Light;
            this.p1_connect_btn.StyleManager = null;
            this.p1_connect_btn.TabIndex = 13;
            this.p1_connect_btn.Text = "연결하기";
            this.p1_connect_btn.ThemeAuthor = "Narwin";
            this.p1_connect_btn.ThemeName = "MetroLite";
            this.p1_connect_btn.Visible = false;
            this.p1_connect_btn.Click += new System.EventHandler(this.p1_connect_btn_Click);
            // 
            // p1_login_btn
            // 
            this.p1_login_btn.DisabledBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(65)))), ((int)(((byte)(177)))), ((int)(((byte)(225)))));
            this.p1_login_btn.DisabledBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(65)))), ((int)(((byte)(177)))), ((int)(((byte)(225)))));
            this.p1_login_btn.DisabledForeColor = System.Drawing.Color.Gray;
            this.p1_login_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F);
            this.p1_login_btn.HoverBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(207)))), ((int)(((byte)(255)))));
            this.p1_login_btn.HoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(207)))), ((int)(((byte)(255)))));
            this.p1_login_btn.HoverTextColor = System.Drawing.Color.White;
            this.p1_login_btn.IsDerivedStyle = true;
            this.p1_login_btn.Location = new System.Drawing.Point(353, 325);
            this.p1_login_btn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.p1_login_btn.Name = "p1_login_btn";
            this.p1_login_btn.NormalBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(177)))), ((int)(((byte)(225)))));
            this.p1_login_btn.NormalColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(177)))), ((int)(((byte)(225)))));
            this.p1_login_btn.NormalTextColor = System.Drawing.Color.White;
            this.p1_login_btn.PressBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(147)))), ((int)(((byte)(195)))));
            this.p1_login_btn.PressColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(147)))), ((int)(((byte)(195)))));
            this.p1_login_btn.PressTextColor = System.Drawing.Color.White;
            this.p1_login_btn.Size = new System.Drawing.Size(185, 47);
            this.p1_login_btn.Style = MetroSet_UI.Enums.Style.Light;
            this.p1_login_btn.StyleManager = null;
            this.p1_login_btn.TabIndex = 12;
            this.p1_login_btn.Text = "로그인";
            this.p1_login_btn.ThemeAuthor = "Narwin";
            this.p1_login_btn.ThemeName = "MetroLite";
            this.p1_login_btn.Click += new System.EventHandler(this.p1_login_btn_Click);
            // 
            // p1_pw_tbx
            // 
            this.p1_pw_tbx.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.p1_pw_tbx.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.p1_pw_tbx.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.p1_pw_tbx.Location = new System.Drawing.Point(282, 239);
            this.p1_pw_tbx.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.p1_pw_tbx.Name = "p1_pw_tbx";
            this.p1_pw_tbx.Size = new System.Drawing.Size(316, 32);
            this.p1_pw_tbx.TabIndex = 11;
            this.p1_pw_tbx.UseSystemPasswordChar = true;
            // 
            // p1_username_tbx
            // 
            this.p1_username_tbx.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.p1_username_tbx.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.p1_username_tbx.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.p1_username_tbx.Location = new System.Drawing.Point(282, 154);
            this.p1_username_tbx.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.p1_username_tbx.Name = "p1_username_tbx";
            this.p1_username_tbx.Size = new System.Drawing.Size(316, 32);
            this.p1_username_tbx.TabIndex = 10;
            // 
            // p1_pw_label
            // 
            this.p1_pw_label.AutoSize = true;
            this.p1_pw_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.p1_pw_label.Location = new System.Drawing.Point(276, 209);
            this.p1_pw_label.Name = "p1_pw_label";
            this.p1_pw_label.Size = new System.Drawing.Size(108, 26);
            this.p1_pw_label.TabIndex = 9;
            this.p1_pw_label.Text = "Password";
            this.p1_pw_label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // p1_userName_label
            // 
            this.p1_userName_label.AutoSize = true;
            this.p1_userName_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.p1_userName_label.Location = new System.Drawing.Point(277, 122);
            this.p1_userName_label.Name = "p1_userName_label";
            this.p1_userName_label.Size = new System.Drawing.Size(113, 26);
            this.p1_userName_label.TabIndex = 8;
            this.p1_userName_label.Text = "Username";
            this.p1_userName_label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // p1_title_label
            // 
            this.p1_title_label.AutoSize = true;
            this.p1_title_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 40F);
            this.p1_title_label.ForeColor = System.Drawing.SystemColors.Highlight;
            this.p1_title_label.Location = new System.Drawing.Point(328, 9);
            this.p1_title_label.Name = "p1_title_label";
            this.p1_title_label.Size = new System.Drawing.Size(195, 63);
            this.p1_title_label.TabIndex = 0;
            this.p1_title_label.Text = "LOGIN";
            this.p1_title_label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(896, 504);
            this.ControlBox = false;
            this.Controls.Add(this.panel1_login);
            this.Controls.Add(this.main_login_btn);
            this.Controls.Add(this.main_midTitle_label);
            this.Controls.Add(this.metroSetControlBox1);
            this.Controls.Add(this.main_title_label);
            this.Name = "MainForm";
            this.Padding = new System.Windows.Forms.Padding(16, 38, 16, 13);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.panel1_login.ResumeLayout(false);
            this.panel1_login.PerformLayout();
            this.p1_1_ip_panel.ResumeLayout(false);
            this.p1_1_ip_panel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label main_title_label;
        private MetroSet_UI.Controls.MetroSetControlBox metroSetControlBox1;
        private System.Windows.Forms.Label main_midTitle_label;
        private MetroSet_UI.Controls.MetroSetButton main_login_btn;
        private System.Windows.Forms.Panel panel1_login;
        private System.Windows.Forms.Label p1_title_label;
        private System.Windows.Forms.Label p1_pw_label;
        private System.Windows.Forms.Label p1_userName_label;
        private MetroSet_UI.Controls.MetroSetButton p1_login_btn;
        private System.Windows.Forms.TextBox p1_pw_tbx;
        private System.Windows.Forms.TextBox p1_username_tbx;
        private MetroSet_UI.Controls.MetroSetButton p1_connect_btn;
        private System.Windows.Forms.Panel p1_1_ip_panel;
        private System.Windows.Forms.Label p1_ip_label;
        private System.Windows.Forms.TextBox p1_ip_tbx;
        private MetroSet_UI.Controls.MetroSetButton p1_gameStart_btn;
    }
}

