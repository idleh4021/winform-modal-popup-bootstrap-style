using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ModalPopup
{

    public partial class BaseModal : Form
    {
        private bool enabledShowingAnimation = true;
        public bool EnabledShowingAnimation { get => enabledShowingAnimation; set { enabledShowingAnimation = value; InitShowingAnimation(); } }
        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn(int nLeftRect, int nTopRect, int nRightRect, int nBottomRect, int nWidthEllipse, int nHeightEllipse);

        Form modalBackground = new Form();

        public Form BasedForm;

        public BaseModal()
        {
            InitializeComponent();
            if (this.DesignMode) return;
            this.FormBorderStyle =FormBorderStyle.None;
            InitShowingAnimation();
            InitModalBackGround();
        }

        private void InitShowingAnimation()
        {
            if (enabledShowingAnimation)
            {
                this.Opacity = 0d;
                timerShow.Interval = 1;
                timerShow.Enabled = true;
            }
            else
            {
                this.Opacity = 100d;
            }
        }

        private void InitModalBackGround()
        {
            modalBackground.StartPosition = FormStartPosition.Manual;
            modalBackground.FormBorderStyle = FormBorderStyle.None;
            modalBackground.Opacity = .50d;
            modalBackground.BackColor = Color.Black;
            //modalBackground.Size = this.Size;
            //modalBackground.Location = this.Location;
            modalBackground.ShowInTaskbar = false;
        }

        private void timerShow_Tick(object sender, EventArgs e)
        {
            if (this.Opacity >= 1)
            {
                timerShow.Stop();
            }
            else { Opacity += .09; }
        }

        private void BaseModal_Load(object sender, EventArgs e)
        {
            if (this.DesignMode) return;
            this.Owner = modalBackground;
            //FormRadius();
            //this.Location = new Point()
            this.StartPosition = FormStartPosition.CenterParent;
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, this.Width, this.Height, 20, 20));
            if (this.BasedForm != null)
            {
               
                    modalBackground.Size = BasedForm.Size;
                    modalBackground.Location = BasedForm.Location;
              
            }
            else
            {
                modalBackground.WindowState = FormWindowState.Maximized;

            }
            
            //this.Parent = modalBackground;
            modalBackground.Show();
            this.Location = new Point((this.Owner.Location.X + (this.Owner.Width / 2) - (this.Width / 2)), (this.Owner.Location.Y + (this.Owner.Height / 2) - (this.Height / 2)));
        }

        private void BaseModal_FormClosed(object sender, FormClosedEventArgs e)
        {
                // modalBackground.Close();
                modalBackground.Dispose();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
