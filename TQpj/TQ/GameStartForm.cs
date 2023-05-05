using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TQ;

namespace TQ
{
    public partial class GameStartForm : MetroFramework.Forms.MetroForm
    {
        private string name;
        public string Value
        {
            get { return this.name; }
            set { this.name = value; }
        }

        public GameStartForm()
        {
            InitializeComponent();
        }

        private void GameStartForm_Load(object sender, EventArgs e)
        {
            //this.textBox1.Text = SendValue;
            txtBox1.Text = string.Format("{0} 님 환영합니다.", Value);
            //MessageBox.Show(name,"name");
        }

        private void gameStartBtn_Click(object sender, EventArgs e)
        {
            roomListForm rlForm = new roomListForm();
            this.Hide();
            rlForm.ShowDialog();
            this.Close();
        }
    }
}
