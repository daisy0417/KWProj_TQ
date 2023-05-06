namespace TQ
{
    partial class GameStartForm
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
            this.gameStartBtn = new MetroSet_UI.Controls.MetroSetButton();
            this.logoutBtn = new MetroSet_UI.Controls.MetroSetButton();
            this.titleLabel = new System.Windows.Forms.Label();
            this.txtBox1 = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // gameStartBtn
            // 
            this.gameStartBtn.DisabledBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(65)))), ((int)(((byte)(177)))), ((int)(((byte)(225)))));
            this.gameStartBtn.DisabledBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(65)))), ((int)(((byte)(177)))), ((int)(((byte)(225)))));
            this.gameStartBtn.DisabledForeColor = System.Drawing.Color.Gray;
            this.gameStartBtn.Font = new System.Drawing.Font("한컴 말랑말랑 Regular", 20F);
            this.gameStartBtn.HoverBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(207)))), ((int)(((byte)(255)))));
            this.gameStartBtn.HoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(207)))), ((int)(((byte)(255)))));
            this.gameStartBtn.HoverTextColor = System.Drawing.Color.White;
            this.gameStartBtn.IsDerivedStyle = true;
            this.gameStartBtn.Location = new System.Drawing.Point(332, 479);
            this.gameStartBtn.Name = "gameStartBtn";
            this.gameStartBtn.NormalBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(177)))), ((int)(((byte)(225)))));
            this.gameStartBtn.NormalColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(177)))), ((int)(((byte)(225)))));
            this.gameStartBtn.NormalTextColor = System.Drawing.Color.White;
            this.gameStartBtn.PressBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(147)))), ((int)(((byte)(195)))));
            this.gameStartBtn.PressColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(147)))), ((int)(((byte)(195)))));
            this.gameStartBtn.PressTextColor = System.Drawing.Color.White;
            this.gameStartBtn.Size = new System.Drawing.Size(355, 65);
            this.gameStartBtn.Style = MetroSet_UI.Enums.Style.Light;
            this.gameStartBtn.StyleManager = null;
            this.gameStartBtn.TabIndex = 11;
            this.gameStartBtn.Text = "게임 시작하기";
            this.gameStartBtn.ThemeAuthor = "Narwin";
            this.gameStartBtn.ThemeName = "MetroLite";
            this.gameStartBtn.Click += new System.EventHandler(this.gameStartBtn_Click);
            // 
            // logoutBtn
            // 
            this.logoutBtn.DisabledBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(65)))), ((int)(((byte)(177)))), ((int)(((byte)(225)))));
            this.logoutBtn.DisabledBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(65)))), ((int)(((byte)(177)))), ((int)(((byte)(225)))));
            this.logoutBtn.DisabledForeColor = System.Drawing.Color.Gray;
            this.logoutBtn.Font = new System.Drawing.Font("한컴 말랑말랑 Regular", 20F);
            this.logoutBtn.HoverBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(207)))), ((int)(((byte)(255)))));
            this.logoutBtn.HoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(207)))), ((int)(((byte)(255)))));
            this.logoutBtn.HoverTextColor = System.Drawing.Color.White;
            this.logoutBtn.IsDerivedStyle = true;
            this.logoutBtn.Location = new System.Drawing.Point(332, 381);
            this.logoutBtn.Name = "logoutBtn";
            this.logoutBtn.NormalBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(177)))), ((int)(((byte)(225)))));
            this.logoutBtn.NormalColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(177)))), ((int)(((byte)(225)))));
            this.logoutBtn.NormalTextColor = System.Drawing.Color.White;
            this.logoutBtn.PressBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(147)))), ((int)(((byte)(195)))));
            this.logoutBtn.PressColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(147)))), ((int)(((byte)(195)))));
            this.logoutBtn.PressTextColor = System.Drawing.Color.White;
            this.logoutBtn.Size = new System.Drawing.Size(355, 65);
            this.logoutBtn.Style = MetroSet_UI.Enums.Style.Light;
            this.logoutBtn.StyleManager = null;
            this.logoutBtn.TabIndex = 10;
            this.logoutBtn.Text = "로그아웃";
            this.logoutBtn.ThemeAuthor = "Narwin";
            this.logoutBtn.ThemeName = "MetroLite";
            // 
            // titleLabel
            // 
            this.titleLabel.Font = new System.Drawing.Font("한컴 말랑말랑 Bold", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.titleLabel.ForeColor = System.Drawing.SystemColors.ControlText;
            this.titleLabel.Location = new System.Drawing.Point(319, 86);
            this.titleLabel.Name = "titleLabel";
            this.titleLabel.Size = new System.Drawing.Size(378, 97);
            this.titleLabel.TabIndex = 8;
            this.titleLabel.Text = "스무고개 게임";
            this.titleLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtBox1
            // 
            this.txtBox1.BackColor = System.Drawing.SystemColors.Window;
            this.txtBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtBox1.Font = new System.Drawing.Font("한컴 말랑말랑 Regular", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txtBox1.Location = new System.Drawing.Point(280, 249);
            this.txtBox1.Name = "txtBox1";
            this.txtBox1.ReadOnly = true;
            this.txtBox1.Size = new System.Drawing.Size(475, 35);
            this.txtBox1.TabIndex = 12;
            this.txtBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // GameStartForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1024, 630);
            this.Controls.Add(this.txtBox1);
            this.Controls.Add(this.gameStartBtn);
            this.Controls.Add(this.logoutBtn);
            this.Controls.Add(this.titleLabel);
            this.Name = "GameStartForm";
            this.Load += new System.EventHandler(this.GameStartForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MetroSet_UI.Controls.MetroSetButton gameStartBtn;
        private MetroSet_UI.Controls.MetroSetButton logoutBtn;
        private System.Windows.Forms.Label titleLabel;
        private System.Windows.Forms.TextBox txtBox1;
    }
}