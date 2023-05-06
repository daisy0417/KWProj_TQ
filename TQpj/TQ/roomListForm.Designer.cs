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
            this.panel1 = new System.Windows.Forms.Panel();
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
            this.mkRoomBtn.PressBorderColor = System.Drawing.Color.RoyalBlue;
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
            // panel1
            // 
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(20, 122);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(984, 488);
            this.panel1.TabIndex = 22;
            // 
            // roomListForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1024, 630);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.titleLabel);
            this.Controls.Add(this.mkRoomBtn);
            this.Name = "roomListForm";
            this.ResumeLayout(false);

        }

        #endregion

        private MetroSet_UI.Controls.MetroSetButton mkRoomBtn;
        private System.Windows.Forms.Label titleLabel;
        private System.Windows.Forms.Panel panel1;
    }
}