using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pjTest
{
    public partial class LoginForm : MetroFramework.Forms.MetroForm
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        public void txtBox()
        {
            // Create an instance of the TextBox control
            nameTxtBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
        }

        private void loginBtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            MainForm main = new MainForm();
            main.ShowDialog();
            this.Close();
        }

        private void nameTxtBox_Click(object sender, EventArgs e)
        {
            nameTxtBox.BackColor = Color.Pink;
            nameTxtBox.BackColor = SystemColors.Control;
        }
    }
}
