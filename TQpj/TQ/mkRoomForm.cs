using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TQ
{
    public partial class mkRoomForm : MetroFramework.Forms.MetroForm
    {
        public mkRoomForm()
        {
            InitializeComponent();
        }

        private void mkRoomBtn_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(peopleTxtBox.Text) || string.IsNullOrEmpty(roomTxtBox.Text))
            {
                MessageBox.Show("이름과 IP를 정확히 입력해주세요.", "Login Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                this.Hide();
                GameForm gF = new GameForm();
                gF.ShowDialog();
                this.Close();

            }

        }
        private void peopleTxtBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            // 숫자와 백스페이스만 입력 가능
            if (!(char.IsDigit(e.KeyChar) || e.KeyChar == Convert.ToChar(Keys.Back)))
            {
                e.Handled = true;
            }
        }


        private void peopleTxtBox_TextChanged(object sender, EventArgs e)
        {
            if (Convert.ToInt32(peopleTxtBox.Text) > 5)
            {
                peopleTxtBox.Text = "0";
                MessageBox.Show("최대 접속 인원은 5명입니다.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
    }
}
