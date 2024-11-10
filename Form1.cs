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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public int parentX, parentY;

        private void button2_Click(object sender, EventArgs e)
        {
            Modal modal = new Modal(this);
            modal.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            popupTest pop = new popupTest();
            Modal modal = new Modal(pop, this);
            modal.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Modal modal = new Modal();
            modal.ShowDialog();
            //Form modalBackground = new Form();
            //using(Modal modal = new ModalPopup.Modal(this))
            //using (Modal modal = new ModalPopup.Modal())
            //{
            //    //modalBackground.StartPosition = FormStartPosition.Manual;
            //    //modalBackground.FormBorderStyle = FormBorderStyle.None;
            //    //modalBackground.Opacity = .50d;
            //    //modalBackground.BackColor = Color.Black;
            //    //modalBackground.Size = this.Size;
            //    //modalBackground.Location = this.Location;
            //    //modalBackground.ShowInTaskbar = false;
            //    //modalBackground.Show();
            //    //modal.Owner = modalBackground;

            //    //parentX = this.Location.X;
            //    //parentY = this.Location.Y;
            //    modal.EnabledShowingAnimation = true;
            //    modal.ShowDialog();
            //   // modalBackground.Dispose();
            //}
            
        }


    }
}
