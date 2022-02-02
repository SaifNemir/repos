using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;

namespace MedicalServiceSystem.Reclaims
{
    public partial class FRMSave : Telerik.WinControls.UI.RadForm
    {
        public FRMSave()
        {
            InitializeComponent();
        }
        private void Button1_Click(object sender, System.EventArgs e)
        {
            FRMReception.Default.OperationNo.Text = OPr.Text.Trim();
            this.Dispose();
        }
    }
}
