using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;
using MedicalServiceSystem.SystemSetting;
using ModelDB;
using System.Linq;
namespace MedicalServiceSystem.Reclaims
{
    public partial class FRMMedicinePricing : Telerik.WinControls.UI.RadForm
    {
        public int MedicineId = 0;
        public int UserId = 0;
        public int LocalityId = 0;
        public FRMMedicinePricing()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            AddNew();
        }
        private void AddNew()
        {
            // ListName.SelectedIndex = 0;
            UU.Clear();
            MedicineId = 0;
            GenericName.Focus();
        }

        private void FRMMedicineSetting_Load(object sender, EventArgs e)
        {
            UserId = LoginForm.Default.UserId;
            LocalityId = LoginForm.Default.LocalityId;
            using (dbContext db = new dbContext())
            {
                var Mlist = db.MedicineLists.ToList();
                ListName.DataSource = Mlist;
                ListName.DisplayMember = "ListName";
                ListName.ValueMember = "Id";
                ListName.SelectedIndex = -1;

                AddNew();

            }
        }

        private void ListName_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {
            if (ListName.SelectedIndex != -1)
            {
                int LId = Convert.ToInt32(ListName.SelectedValue.ToString());
                using (dbContext db = new dbContext())
                {
                    var Mlst =db.MedicineListPrices.Where(p => p.ListId == LId).Select(p => new { p.Id, p.Medicine.Generic_name, p.Medicine.Unit.Unit_Name, p.Medicine.PL, p.Medicine.HICKS_DC, p.Medicine.NOTE, p.Medicine.DDD, p.Medicine.U, p.Medicine.Adm_R }).ToList();
                    GRDMedicine.DataSource = Mlst;
                }
            }
        }

        private void ATCclassification_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {

        }

        private void GenericName_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {
            if (GenericName.ContainsFocus)
            {
                if (GenericName.SelectedIndex != -1)
                {
                    MedicineId = Convert.ToInt32(GenericName.SelectedValue.ToString());
                    int ListId = Convert.ToInt32(ListName.SelectedValue.ToString());
                    using (dbContext db = new dbContext())
                    {
                        var Getgeneric = db.MedicineListPrices.Where(p => p.GenericId == MedicineId && p.ListId == ListId).ToList();
                        if (Getgeneric.Count > 0)
                        {
                            UU.Text = Getgeneric[0].GenericPrice.ToString();
                        }
                    }
                }
            }
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            if (GenericName.SelectedIndex == -1)
            {
                MessageBox.Show("Enter Generic Name first!", "System", MessageBoxButtons.OK, MessageBoxIcon.Error);
                GenericName.Focus();
                return;
            }
            if (UU.Text.Length == 0)
            {
                MessageBox.Show("Enter Generic Price first!", "System", MessageBoxButtons.OK, MessageBoxIcon.Error);
                UU.Focus();
                return;
            }
            using (dbContext db = new dbContext())
            {
                MedicineId = Convert.ToInt32(GenericName.SelectedValue.ToString());
                int ListId = Convert.ToInt32(ListName.SelectedValue.ToString());
                var getPrice = db.MedicineListPrices.Where(p => p.ListId == ListId && p.GenericId == MedicineId).ToList();
                if (getPrice.Count > 0)
                {
                    getPrice[0].GenericPrice = Convert.ToDecimal(UU.Text);
                    db.SaveChanges();
                    MessageBox.Show("Price has been Edited", "System", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }

        }

        private void Button4_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void GRDMedicine_CommandCellClick(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {
            if (GRDMedicine.CurrentColumn.Name == "Edit")
            {
                MedicineId = Convert.ToInt32(e.Row.Cells["Id"].ToString());
                int ListId = Convert.ToInt32(ListName.SelectedValue.ToString());
                using (dbContext db = new dbContext())
                {
                    var getPrice = db.MedicineListPrices.Where(p => p.ListId == ListId && p.GenericId == MedicineId).ToList();
                    if (getPrice.Count > 0)
                    {
                        GenericName.SelectedValue = MedicineId;
                        if (getPrice[0].GenericPrice.ToString() != null)
                        {
                            UU.Text = getPrice[0].GenericPrice.ToString();
                        }
                        else
                        {
                            UU.Text = "0";
                        }
                    }
                }
            }
        }
    }
}
