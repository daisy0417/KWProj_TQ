namespace TQ
{
    partial class roomListForm
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
            this.mkRoomBtn = new MetroSet_UI.Controls.MetroSetButton();
            this.titleLabel = new System.Windows.Forms.Label();
            this.btnRoomCreate = new System.Windows.Forms.Panel();
            this.btnOutRoom = new System.Windows.Forms.Button();
            this.btnJoinRoom = new System.Windows.Forms.Button();
            this.btnCreateRoom = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnRefreshRoomList = new System.Windows.Forms.Button();
            this.tbRoomCount = new System.Windows.Forms.TextBox();
            this.tbRoomName = new System.Windows.Forms.TextBox();
            this.tbRoomList = new System.Windows.Forms.TextBox();
            this.btnRoomCreate.SuspendLayout();
            this.SuspendLayout();
            // 
            // mkRoomBtn
            // 
            this.mkRoomBtn.DisabledBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(65)))), ((int)(((byte)(177)))), ((int)(((byte)(225)))));
            this.mkRoomBtn.DisabledBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(65)))), ((int)(((byte)(177)))), ((int)(((byte)(225)))));
            this.mkRoomBtn.DisabledForeColor = System.Drawing.Color.Gray;
            this.mkRoomBtn.Font = new System.Drawing.Font("한컴 말랑말랑 Regular", 16F);
            this.mkRoomBtn.HoverBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(207)))), ((int)(((byte)(255)))));
            this.mkRoomBtn.HoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(207)))), ((int)(((byte)(255)))));
            this.mkRoomBtn.HoverTextColor = System.Drawing.Color.White;
            this.mkRoomBtn.IsDerivedStyle = true;
            this.mkRoomBtn.Location = new System.Drawing.Point(868, 52);
            this.mkRoomBtn.Name = "mkRoomBtn";
            this.mkRoomBtn.NormalBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(177)))), ((int)(((byte)(225)))));
            this.mkRoomBtn.NormalColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(177)))), ((int)(((byte)(225)))));
            this.mkRoomBtn.NormalTextColor = System.Drawing.Color.White;
            this.mkRoomBtn.PressBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(147)))), ((int)(((byte)(195)))));
            this.mkRoomBtn.PressColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(147)))), ((int)(((byte)(195)))));
            this.mkRoomBtn.PressTextColor = System.Drawing.Color.White;
            this.mkRoomBtn.Size = new System.Drawing.Size(133, 53);
            this.mkRoomBtn.Style = MetroSet_UI.Enums.Style.Light;
            this.mkRoomBtn.StyleManager = null;
            this.mkRoomBtn.TabIndex = 20;
            this.mkRoomBtn.Text = "방 만들기";
            this.mkRoomBtn.ThemeAuthor = "Narwin";
            this.mkRoomBtn.ThemeName = "MetroLite";
            this.mkRoomBtn.Click += new System.EventHandler(this.mkRoomBtn_Click);
            // 
            // titleLabel
            // 
            this.titleLabel.Font = new System.Drawing.Font("한컴 말랑말랑 Bold", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.titleLabel.ForeColor = System.Drawing.SystemColors.ControlText;
            this.titleLabel.Location = new System.Drawing.Point(23, 52);
            this.titleLabel.Name = "titleLabel";
            this.titleLabel.Size = new System.Drawing.Size(164, 59);
            this.titleLabel.TabIndex = 21;
            this.titleLabel.Text = "스무고개 게임";
            this.titleLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnRoomCreate
            // 
            this.btnRoomCreate.Controls.Add(this.btnOutRoom);
            this.btnRoomCreate.Controls.Add(this.btnJoinRoom);
            this.btnRoomCreate.Controls.Add(this.btnCreateRoom);
            this.btnRoomCreate.Controls.Add(this.label2);
            this.btnRoomCreate.Controls.Add(this.label1);
            this.btnRoomCreate.Controls.Add(this.btnRefreshRoomList);
            this.btnRoomCreate.Controls.Add(this.tbRoomCount);
            this.btnRoomCreate.Controls.Add(this.tbRoomName);
            this.btnRoomCreate.Controls.Add(this.tbRoomList);
            this.btnRoomCreate.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnRoomCreate.Location = new System.Drawing.Point(20, 122);
            this.btnRoomCreate.Name = "btnRoomCreate";
            this.btnRoomCreate.Size = new System.Drawing.Size(984, 488);
            this.btnRoomCreate.TabIndex = 22;
            // 
            // btnOutRoom
            // 
            this.btnOutRoom.Location = new System.Drawing.Point(170, 371);
            this.btnOutRoom.Name = "btnOutRoom";
            this.btnOutRoom.Size = new System.Drawing.Size(102, 37);
            this.btnOutRoom.TabIndex = 8;
            this.btnOutRoom.Text = "방 나가기";
            this.btnOutRoom.UseVisualStyleBackColor = true;
            // 
            // btnJoinRoom
            // 
            this.btnJoinRoom.Location = new System.Drawing.Point(287, 282);
            this.btnJoinRoom.Name = "btnJoinRoom";
            this.btnJoinRoom.Size = new System.Drawing.Size(102, 37);
            this.btnJoinRoom.TabIndex = 7;
            this.btnJoinRoom.Text = "방 참가";
            this.btnJoinRoom.UseVisualStyleBackColor = true;
            // 
            // btnCreateRoom
            // 
            this.btnCreateRoom.Location = new System.Drawing.Point(170, 282);
            this.btnCreateRoom.Name = "btnCreateRoom";
            this.btnCreateRoom.Size = new System.Drawing.Size(102, 37);
            this.btnCreateRoom.TabIndex = 6;
            this.btnCreateRoom.Text = "방 생성";
            this.btnCreateRoom.UseVisualStyleBackColor = true;
            this.btnCreateRoom.Click += new System.EventHandler(this.btnCreateRoom_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(265, 147);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 15);
            this.label2.TabIndex = 5;
            this.label2.Text = "최대 정원";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(265, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 15);
            this.label1.TabIndex = 4;
            this.label1.Text = "방 이름";
            // 
            // btnRefreshRoomList
            // 
            this.btnRefreshRoomList.Location = new System.Drawing.Point(45, 282);
            this.btnRefreshRoomList.Name = "btnRefreshRoomList";
            this.btnRefreshRoomList.Size = new System.Drawing.Size(102, 37);
            this.btnRefreshRoomList.TabIndex = 3;
            this.btnRefreshRoomList.Text = "새로고침";
            this.btnRefreshRoomList.UseVisualStyleBackColor = true;
            this.btnRefreshRoomList.Click += new System.EventHandler(this.btnRefreshRoomList_Click);
            // 
            // tbRoomCount
            // 
            this.tbRoomCount.Location = new System.Drawing.Point(268, 165);
            this.tbRoomCount.Multiline = true;
            this.tbRoomCount.Name = "tbRoomCount";
            this.tbRoomCount.Size = new System.Drawing.Size(193, 38);
            this.tbRoomCount.TabIndex = 2;
            // 
            // tbRoomName
            // 
            this.tbRoomName.Location = new System.Drawing.Point(268, 66);
            this.tbRoomName.Multiline = true;
            this.tbRoomName.Name = "tbRoomName";
            this.tbRoomName.Size = new System.Drawing.Size(193, 38);
            this.tbRoomName.TabIndex = 1;
            // 
            // tbRoomList
            // 
            this.tbRoomList.Location = new System.Drawing.Point(9, 32);
            this.tbRoomList.Multiline = true;
            this.tbRoomList.Name = "tbRoomList";
            this.tbRoomList.Size = new System.Drawing.Size(227, 209);
            this.tbRoomList.TabIndex = 0;
            // 
            // roomListForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1024, 630);
            this.Controls.Add(this.btnRoomCreate);
            this.Controls.Add(this.titleLabel);
            this.Controls.Add(this.mkRoomBtn);
            this.Name = "roomListForm";
            this.Load += new System.EventHandler(this.roomListForm_Load);
            this.btnRoomCreate.ResumeLayout(false);
            this.btnRoomCreate.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private MetroSet_UI.Controls.MetroSetButton mkRoomBtn;
        private System.Windows.Forms.Label titleLabel;
        private System.Windows.Forms.Panel btnRoomCreate;
        private System.Windows.Forms.Button btnOutRoom;
        private System.Windows.Forms.Button btnJoinRoom;
        private System.Windows.Forms.Button btnCreateRoom;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnRefreshRoomList;
        private System.Windows.Forms.TextBox tbRoomCount;
        private System.Windows.Forms.TextBox tbRoomName;
        private System.Windows.Forms.TextBox tbRoomList;
    }
}