using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ModelDB;
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
                using (dbContext db = new dbContext())
                {
                    db.Database.CommandTimeout = 0;
                    var Fref = db.Reclaims.Where(p => p.Subscriber.InsurName.Contains(txtname.Text.Trim()) && p.RowStatus != RowStatus.Deleted && p.ReclaimDate>=PLC.getdate().AddYears(-1)).ToList();
                   // GRDSearch.DataSource = Fref;
                    if (Fref.Count > 0)
                    {
                        for (int i = 0; i < Fref.Count; i++)
                        {
                            lstName.Items.Add(Fref[i].Subscriber.InsurName);
                        }
                    }
                }
            }
            else
            {
                lstName.Items.Clear();

            }
		}

		private void lstName_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			
		}

		private void FrmSearch_Load(object sender, System.EventArgs e)
		{

		}

        private void LstName_Click(object sender, EventArgs e)
        {
            if (lstName.Items.Count > 0)
            {
                using (dbContext db = new dbContext())
                {
                    db.Database.CommandTimeout = 0;
                    var Fref = db.Reclaims.Where(p => p.Subscriber.InsurName==txtname.Text.Trim() && p.RowStatus != RowStatus.Deleted && p.ReclaimDate >= PLC.getdate().AddYears(-1)).ToList();
                   GRDSearch.DataSource = Fref;
                    if (Fref.Count > 0)
                    {
                        for (int i = 0; i < Fref.Count; i++)
                        {
                            GRDSearch.Rows[i].Cells["Coloumns1"].Value = i + 1;

                        }
                    }
                }
            }
            else
            {
                GRDSearch.Rows.Clear();
            }
        }
    }
}
