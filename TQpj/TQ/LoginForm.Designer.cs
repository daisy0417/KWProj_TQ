namespace TQ
{
    partial class LoginForm
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
            this.ServerTxtBox = new System.Windows.Forms.TextBox();
            this.nameTxtBox = new System.Windows.Forms.TextBox();
            this.IpLabel = new System.Windows.Forms.Label();
            this.nameLabel = new System.Windows.Forms.Label();
            this.loginBtn = new MetroSet_UI.Controls.MetroSetButton();
            this.label1 = new System.Windows.Forms.Label();
            this.titleLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // ServerTxtBox
            // 
            this.ServerTxtBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ServerTxtBox.Font = new System.Drawing.Font("한컴 말랑말랑 Bold", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.ServerTxtBox.ForeColor = System.Drawing.SystemColors.Highlight;
            this.ServerTxtBox.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.ServerTxtBox.Location = new System.Drawing.Point(291, 406);
            this.ServerTxtBox.Name = "ServerTxtBox";
            this.ServerTxtBox.Size = new System.Drawing.Size(486, 46);
            this.ServerTxtBox.TabIndex = 16;
            this.ServerTxtBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ServerTxtBox_KeyPress);
            // 
            // nameTxtBox
            // 
            this.nameTxtBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.nameTxtBox.Font = new System.Drawing.Font("한컴 말랑말랑 Bold", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.nameTxtBox.ForeColor = System.Drawing.SystemColors.Highlight;
            this.nameTxtBox.Location = new System.Drawing.Point(291, 271);
            this.nameTxtBox.Name = "nameTxtBox";
            this.nameTxtBox.Size = new System.Drawing.Size(486, 46);
            this.nameTxtBox.TabIndex = 15;
            // 
            // IpLabel
            // 
            this.IpLabel.AutoSize = true;
            this.IpLabel.Font = new System.Drawing.Font("한컴 말랑말랑 Regular", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.IpLabel.Location = new System.Drawing.Point(283, 368);
            this.IpLabel.Name = "IpLabel";
            this.IpLabel.Size = new System.Drawing.Size(88, 35);
            this.IpLabel.TabIndex = 14;
            this.IpLabel.Text = "서버IP";
            // 
            // nameLabel
            // 
            this.nameLabel.AutoSize = true;
            this.nameLabel.Font = new System.Drawing.Font("한컴 말랑말랑 Regular", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.nameLabel.Location = new System.Drawing.Point(283, 231);
            this.nameLabel.Name = "nameLabel";
            this.nameLabel.Size = new System.Drawing.Size(61, 35);
            this.nameLabel.TabIndex = 10;
            this.nameLabel.Text = "이름";
            // 
            // loginBtn
            // 
            this.loginBtn.DisabledBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(65)))), ((int)(((byte)(177)))), ((int)(((byte)(225)))));
            this.loginBtn.DisabledBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(65)))), ((int)(((byte)(177)))), ((int)(((byte)(225)))));
            this.loginBtn.DisabledForeColor = System.Drawing.Color.Gray;
            this.loginBtn.Font = new System.Drawing.Font("한컴 말랑말랑 Regular", 20F);
            this.loginBtn.HoverBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(207)))), ((int)(((byte)(255)))));
            this.loginBtn.HoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(207)))), ((int)(((byte)(255)))));
            this.loginBtn.HoverTextColor = System.Drawing.Color.White;
            this.loginBtn.IsDerivedStyle = true;
            this.loginBtn.Location = new System.Drawing.Point(356, 523);
            this.loginBtn.Name = "loginBtn";
            this.loginBtn.NormalBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(177)))), ((int)(((byte)(225)))));
            this.loginBtn.NormalColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(177)))), ((int)(((byte)(225)))));
            this.loginBtn.NormalTextColor = System.Drawing.Color.White;
            this.loginBtn.PressBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(147)))), ((int)(((byte)(195)))));
            this.loginBtn.PressColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(147)))), ((int)(((byte)(195)))));
            this.loginBtn.PressTextColor = System.Drawing.Color.White;
            this.loginBtn.Size = new System.Drawing.Size(355, 65);
            this.loginBtn.Style = MetroSet_UI.Enums.Style.Light;
            this.loginBtn.StyleManager = null;
            this.loginBtn.TabIndex = 13;
            this.loginBtn.Text = "로그인";
            this.loginBtn.ThemeAuthor = "Narwin";
            this.loginBtn.ThemeName = "MetroLite";
            this.loginBtn.Click += new System.EventHandler(this.loginBtn_Click);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("한컴 말랑말랑 Regular", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label1.Location = new System.Drawing.Point(249, 160);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(555, 47);
            this.label1.TabIndex = 12;
            this.label1.Text = "이름과 접속할 IP를 입력해주세요";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // titleLabel
            // 
            this.titleLabel.Font = new System.Drawing.Font("한컴 말랑말랑 Bold", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.titleLabel.ForeColor = System.Drawing.SystemColors.ControlText;
            this.titleLabel.Location = new System.Drawing.Point(333, 60);
            this.titleLabel.Name = "titleLabel";
            this.titleLabel.Size = new System.Drawing.Size(378, 97);
            this.titleLabel.TabIndex = 11;
            this.titleLabel.Text = "로그인";
            this.titleLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // LoginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(1024, 630);
            this.Controls.Add(this.ServerTxtBox);
            this.Controls.Add(this.nameTxtBox);
            this.Controls.Add(this.IpLabel);
            this.Controls.Add(this.nameLabel);
            this.Controls.Add(this.loginBtn);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.titleLabel);
            this.Name = "LoginForm";
            this.Load += new System.EventHandler(this.LoginForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox ServerTxtBox;
        private System.Windows.Forms.TextBox nameTxtBox;
        private System.Windows.Forms.Label IpLabel;
        private System.Windows.Forms.Label nameLabel;
        private MetroSet_UI.Controls.MetroSetButton loginBtn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label titleLabel;
    }
}