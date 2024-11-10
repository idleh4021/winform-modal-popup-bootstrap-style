using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ModalPopup
{
    public partial class Modal : Form
    {
        int timerInterval;
        public Modal()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (this.Opacity >= 1)
            {
                timer1.Stop();
            }
            else { Opacity += .03; }
        }

        private void Modal_Load(object sender, EventArgs e)
        {
            //this.Location = new Point()
        }
    }
}
