﻿using BaseFrm;
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
    public partial class PopupByBaseModal : BaseModal
    {
        public PopupByBaseModal()
        {
            InitializeComponent();
            //this.Opacity = 0; //0설정이 되어야 애니메이션 처리
        }
    }
}
