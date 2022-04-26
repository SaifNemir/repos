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
    public partial class FRMStopSubscriber : Telerik.WinControls.UI.RadForm
    {
        public FRMStopSubscriber()
        {
            InitializeComponent();
        }
		public string UserName = "";
		private void Button1_Click(object sender, System.EventArgs e)
		{
            if (card_no.Text.Length == 0)
            {
                MessageBox.Show("يجب ادخال بيانات المشترك", "النظام", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                card_no.Focus();
                return;
            }
            if (ful_name.Text.Length == 0)
            {
                MessageBox.Show("يجب ادخال بيانات المشترك", "النظام", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                card_no.Focus();
                return;
            }
            if (StopCause.Text.Length == 0)
            {
                MessageBox.Show("يجب سبب ايقاف المشترك المشترك", "النظام", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                StopCause.Focus();
                return;
            }
            using (dbContext db = new dbContext())
            {
                var Ssc = db.Subscribers.Where(p => p.InsurNo == card_no.Text).ToList();
                if (Ssc.Count > 0)
                {
                    Ssc[0].IsStoped = true;
                    Ssc[0].Notes = StopCause.Text.Trim();
                    db.SaveChanges();
                    MessageBox.Show("لقد تم ايقاف المشترك", "النظام", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
            }
            
                this.Close();
		}

		private void patienthistory_Load(object sender, System.EventArgs e)
		{
            using (dbContext db = new dbContext())
            {
                var Ssc = db.Subscribers.Where(p => p.InsurNo == card_no.Text).ToList();
                if (Ssc.Count > 0)
                {
                    StopCause.Text = Ssc[0].Notes;

                }
            }
            }

		private void grid_transfer_CellContentClick(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
		{

		}

		private void grid_transfer_Click(object sender, System.EventArgs e)
		{

		}

		private void card_ser_TextChanged(object sender, EventArgs e)
		{

		}

		private void Label6_Click(object sender, EventArgs e)
		{

		}

        private void RadButton1_Click(object sender, EventArgs e)
        {
            if (card_no.Text.Length == 0)
            {
                MessageBox.Show("يجب ادخال بيانات المشترك", "النظام", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                card_no.Focus();
                return;
            }
            if (ful_name.Text.Length == 0)
            {
                MessageBox.Show("يجب ادخال بيانات المشترك", "النظام", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                card_no.Focus();
                return;
            }
            if (StopCause.Text.Length == 0)
            {
                MessageBox.Show("يجب سبب ايقاف المشترك المشترك", "النظام", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                StopCause.Focus();
                return;
            }
            using (dbContext db = new dbContext())
            {
                var Ssc = db.Subscribers.Where(p => p.InsurNo == card_no.Text).ToList();
                if (Ssc.Count > 0)
                {
                    Ssc[0].IsStoped = false;
                    Ssc[0].Notes = StopCause.Text.Trim();
                    db.SaveChanges();
                    MessageBox.Show("لقد تم إلغاءايقاف المشترك", "النظام", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
            }

            this.Close();
        }
    }
}
