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
    public partial class FrmSearch : Telerik.WinControls.UI.RadForm
    {
        public FrmSearch()
        {
            InitializeComponent();
        }
		private void txtname_TextChanged(object sender, System.EventArgs e)
		{
			if (!string.IsNullOrEmpty(txtname.Text))
			{
			}
			else
			{
				lstName.Items.Clear();

			}
		}

		private void lstName_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if (lstName.Items.Count > 0)
			{

			}
			else
			{
				GRDSearch.Rows.Clear();
			}
		}

		private void FrmSearch_Load(object sender, System.EventArgs e)
		{

		}
	}
}
