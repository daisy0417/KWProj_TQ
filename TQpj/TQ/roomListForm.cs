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
    public partial class roomListForm : MetroFramework.Forms.MetroForm
    {
        public roomListForm()
        {
            InitializeComponent();
        }

        private void mkRoomBtn_Click(object sender, EventArgs e)
        {
            mkRoomForm mkRF = new mkRoomForm();
            this.Hide();
            mkRF.ShowDialog();
            this.Close();
        }

      

    }
}
