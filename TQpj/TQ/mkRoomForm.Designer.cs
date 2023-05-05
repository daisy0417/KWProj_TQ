namespace TQ
{
    partial class mkRoomForm
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
            this.peopleTxtBox = new System.Windows.Forms.TextBox();
            this.roomTxtBox = new System.Windows.Forms.TextBox();
            this.IpLabel = new System.Windows.Forms.Label();
            this.mkRoomBtn = new MetroSet_UI.Controls.MetroSetButton();
            this.label1 = new System.Windows.Forms.Label();
            this.roomTitLabel = new System.Windows.Forms.Label();
            this.roomLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // peopleTxtBox
            // 
            this.peopleTxtBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.peopleTxtBox.Font = new System.Drawing.Font("한컴 말랑말랑 Bold", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.peopleTxtBox.ForeColor = System.Drawing.SystemColors.Highlight;
            this.peopleTxtBox.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.peopleTxtBox.Location = new System.Drawing.Point(311, 406);
            this.peopleTxtBox.Name = "peopleTxtBox";
            this.peopleTxtBox.Size = new System.Drawing.Size(486, 46);
            this.peopleTxtBox.TabIndex = 22;
            this.peopleTxtBox.TextChanged += new System.EventHandler(this.peopleTxtBox_TextChanged);
            this.peopleTxtBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.peopleTxtBox_KeyPress);
            // 
            // roomTxtBox
            // 
            this.roomTxtBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.roomTxtBox.Font = new System.Drawing.Font("한컴 말랑말랑 Bold", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.roomTxtBox.ForeColor = System.Drawing.SystemColors.Highlight;
            this.roomTxtBox.Location = new System.Drawing.Point(311, 271);
            this.roomTxtBox.Name = "roomTxtBox";
            this.roomTxtBox.Size = new System.Drawing.Size(486, 46);
            this.roomTxtBox.TabIndex = 21;
            // 
            // IpLabel
            // 
            this.IpLabel.AutoSize = true;
            this.IpLabel.Font = new System.Drawing.Font("한컴 말랑말랑 Regular", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.IpLabel.Location = new System.Drawing.Point(303, 368);
            this.IpLabel.Name = "IpLabel";
            this.IpLabel.Size = new System.Drawing.Size(172, 35);
            this.IpLabel.TabIndex = 20;
            this.IpLabel.Text = "최대 접속 인원";
            // 
            // mkRoomBtn
            // 
            this.mkRoomBtn.DisabledBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(65)))), ((int)(((byte)(177)))), ((int)(((byte)(225)))));
            this.mkRoomBtn.DisabledBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(65)))), ((int)(((byte)(177)))), ((int)(((byte)(225)))));
            this.mkRoomBtn.DisabledForeColor = System.Drawing.Color.Gray;
            this.mkRoomBtn.Font = new System.Drawing.Font("한컴 말랑말랑 Regular", 20F);
            this.mkRoomBtn.HoverBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(207)))), ((int)(((byte)(255)))));
            this.mkRoomBtn.HoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(207)))), ((int)(((byte)(255)))));
            this.mkRoomBtn.HoverTextColor = System.Drawing.Color.White;
            this.mkRoomBtn.IsDerivedStyle = true;
            this.mkRoomBtn.Location = new System.Drawing.Point(376, 523);
            this.mkRoomBtn.Name = "mkRoomBtn";
            this.mkRoomBtn.NormalBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(177)))), ((int)(((byte)(225)))));
            this.mkRoomBtn.NormalColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(177)))), ((int)(((byte)(225)))));
            this.mkRoomBtn.NormalTextColor = System.Drawing.Color.White;
            this.mkRoomBtn.PressBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(147)))), ((int)(((byte)(195)))));
            this.mkRoomBtn.PressColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(147)))), ((int)(((byte)(195)))));
            this.mkRoomBtn.PressTextColor = System.Drawing.Color.White;
            this.mkRoomBtn.Size = new System.Drawing.Size(355, 65);
            this.mkRoomBtn.Style = MetroSet_UI.Enums.Style.Light;
            this.mkRoomBtn.StyleManager = null;
            this.mkRoomBtn.TabIndex = 19;
            this.mkRoomBtn.Text = "방 만들기";
            this.mkRoomBtn.ThemeAuthor = "Narwin";
            this.mkRoomBtn.ThemeName = "MetroLite";
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("한컴 말랑말랑 Regular", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label1.Location = new System.Drawing.Point(269, 160);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(555, 47);
            this.label1.TabIndex = 18;
            this.label1.Text = "생성할 방 이름과 최대 접속 인원을 입력하세요";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // roomTitLabel
            // 
            this.roomTitLabel.Font = new System.Drawing.Font("한컴 말랑말랑 Bold", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.roomTitLabel.ForeColor = System.Drawing.SystemColors.ControlText;
            this.roomTitLabel.Location = new System.Drawing.Point(353, 60);
            this.roomTitLabel.Name = "roomTitLabel";
            this.roomTitLabel.Size = new System.Drawing.Size(378, 97);
            this.roomTitLabel.TabIndex = 17;
            this.roomTitLabel.Text = "방 만들기";
            this.roomTitLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // roomLabel
            // 
            this.roomLabel.AutoSize = true;
            this.roomLabel.Font = new System.Drawing.Font("한컴 말랑말랑 Regular", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.roomLabel.Location = new System.Drawing.Point(305, 233);
            this.roomLabel.Name = "roomLabel";
            this.roomLabel.Size = new System.Drawing.Size(93, 35);
            this.roomLabel.TabIndex = 23;
            this.roomLabel.Text = "방 이름";
            // 
            // mkRoomForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1024, 630);
            this.Controls.Add(this.roomLabel);
            this.Controls.Add(this.peopleTxtBox);
            this.Controls.Add(this.roomTxtBox);
            this.Controls.Add(this.IpLabel);
            this.Controls.Add(this.mkRoomBtn);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.roomTitLabel);
            this.Name = "mkRoomForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox peopleTxtBox;
        private System.Windows.Forms.TextBox roomTxtBox;
        private System.Windows.Forms.Label IpLabel;
        private MetroSet_UI.Controls.MetroSetButton mkRoomBtn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label roomTitLabel;
        private System.Windows.Forms.Label roomLabel;
    }
}