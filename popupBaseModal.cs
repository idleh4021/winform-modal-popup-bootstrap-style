﻿using System;
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
    public partial class popupBaseModal : BaseModal
    {
        public popupBaseModal() //: base()
        {
            InitializeComponent();
            this.Opacity = 0.0;
        }
    }
}
