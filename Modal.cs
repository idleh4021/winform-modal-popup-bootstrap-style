﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ModalPopup
{
    public partial class Modal : Form
    {
        private bool enabledShowingAnimation = true;
        public bool EnabledShowingAnimation { get => enabledShowingAnimation; set { enabledShowingAnimation = value; InitShowingAnimation(); } }

        [DllImport("Gdi32.dll",EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn(int nLeftRect,int nTopRect,int nRightRect,int nBottomRect,int nWidthEllipse ,int nHeightEllipse);

        Form modalBackground = new Form();

        Form _owner = null;
        //public Modal()
        //{
        //    InitializeComponent();
        //    InitShowingAnimation();
          

        //}

        /// <summary>
        /// 
        /// </summary>
        /// <param name="owner">Modal폼을 소유하는 폼을 설정합니다. Null인경우 윈도우를 기준합니다. </param>
        public Modal(Form owner = null)
        {
            InitializeComponent();
            InitShowingAnimation();
            InitModalBackGround();
            this.FormBorderStyle = FormBorderStyle.None;
            _owner = owner;

        }

        public Modal(Form ChildForm, Form owner = null)
        {
            InitializeComponent();
            InitShowingAnimation();
            InitModalBackGround();
            this.FormBorderStyle = FormBorderStyle.None;
            _owner = owner;
            AddChildForm(ChildForm);
        }

        private void AddChildForm(Form childForm)
        {
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None; // 테두리 제거
            childForm.Dock = DockStyle.Fill;           // 부모 패널에 맞게 채움

            // 부모 패널에 자식 폼 추가
            panel1.Controls.Clear();           // 기존 폼 제거 (필요시)
            panel1.Controls.Add(childForm);    // 자식 폼 추가
            childForm.Show();                          // 
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

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (this.Opacity >= 1)
            {
                timerShow.Stop();
            }
            else { Opacity += .09; }
        }

        private void Modal_Load(object sender, EventArgs e)
        {
            //FormRadius();
            //this.Location = new Point()
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0,0,this.Width,this.Height,20,20));
            if (_owner != null)
            {
                    modalBackground.Size = _owner.Size; 
                    modalBackground.Location = _owner.Location;
            }
            else
            {
                modalBackground.WindowState = FormWindowState.Maximized;
                
            }
            this.Owner = modalBackground;
            //this.Parent = modalBackground;
            modalBackground.Show();
            this.Location = new Point((this.Owner.Location.X + (this.Owner.Width / 2) - (this.Width / 2)), (this.Owner.Location.Y + (this.Owner.Height / 2) - (this.Height / 2)));
        }

        private void FormRadius()
        {
            int cornerRadius = 20; // 모서리 둥근 정도를 설정 (숫자가 클수록 더 둥글게)
            var path = new GraphicsPath();
            path.StartFigure();

            // 각 모서리에 둥근 부분 설정
            path.AddArc(new Rectangle(0, 0, cornerRadius, cornerRadius), 180, 90);
            path.AddArc(new Rectangle(this.Width - cornerRadius, 0, cornerRadius, cornerRadius), 270, 90);
            path.AddArc(new Rectangle(this.Width - cornerRadius, this.Height - cornerRadius, cornerRadius, cornerRadius), 0, 90);
            path.AddArc(new Rectangle(0, this.Height - cornerRadius, cornerRadius, cornerRadius), 90, 90);
            path.CloseFigure();

            // Region 속성에 둥근 모서리 적용
            this.Region = new Region(path);
        }

        private void Modal_FormClosed(object sender, FormClosedEventArgs e)
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
