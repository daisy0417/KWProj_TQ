using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ServerProgram
{
    public class ServerForm : Form
    {
        /// <summary>
        ///  Form에 로그를 출력할 때 사용할 수 있다. override 필요
        /// </summary>
        public virtual void PrintLog(string content)
        {

        }
    }
}
