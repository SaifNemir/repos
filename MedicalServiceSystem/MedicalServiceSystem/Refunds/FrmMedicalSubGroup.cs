using ModelDB;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;
using Telerik.WinControls.UI;

namespace MedicalServiceSystem.Reclaims
{
    public partial class FrmMedicalSubGroup : Telerik.WinControls.UI.RadForm
    {
        public FrmMedicalSubGroup()
        {
            InitializeComponent();
        }
        private void FrmSubGroup_Load(object sender, EventArgs e)
        {
            using (dbContext db = new dbContext())
            {
                var Fgroup = db.MedicalMainGroups.ToList();
                TxtGrp.DataSource = Fgroup;
                TxtGrp.ValueMember = "Id";
                TxtGrp.DisplayMember = "MainGroupArabicName";
                TxtGrp.SelectedIndex = 0;
            }
        }
        public void LoadData()
        {
            try
            {
                int GroupId = Convert.ToInt32(TxtGrp.SelectedValue.ToString());
                using (dbContext db = new dbContext())
                {
                    var GetGroup = db.MedicalSubGroups.Where(p => p.MainGroupId == GroupId).ToList();
                    GRDSubGroup.DataSource = GetGroup;
                    if (GRDSubGroup.RowCount > 0)
                    {
                        for (int i = 0; i <= GRDSubGroup.RowCount - 1; i++)
                        {
                            GRDSubGroup.Rows[i].Cells["Serial"].Value = i + 1;
                        }
                    }
                }

            }
            catch (Exception ex)
            {

            }

        }

        private void TxtGrp_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {
            LoadData();
        }

        private void GRDSubGroup_CommandCellClick(object sender, GridViewCellEventArgs e)
        {
            if (GRDSubGroup.RowCount > 0)
            {
                int SubGroupId = Convert.ToInt32(GRDSubGroup.CurrentRow.Cells["Id"].Value);
                if (e.ColumnIndex == GRDSubGroup.Columns["BtnEditing"].Index)
                {

                    FrmAddSubGroup FrmAddSubGroup = new FrmAddSubGroup();
                    //flag = 1;

                    FrmAddSubGroup.GroupEname.Text = (GRDSubGroup.CurrentRow.Cells["SerEName"].Value).ToString();
                    FrmAddSubGroup.GroupAName.Text = (GRDSubGroup.CurrentRow.Cells["SerANAme"].Value).ToString();
                    // FrmAddSubGroup.GroupCode.Text = GRDSubGroup.CurrentRow.Cells("SerCode").Value
                    FrmAddSubGroup.SubGroupId = Convert.ToInt32(GRDSubGroup.CurrentRow.Cells["Id"].Value.ToString());
                    FrmAddSubGroup.GroupId = Convert.ToInt32(TxtGrp.SelectedValue.ToString());
                    // FrmAddSubGroup.flag = 1;
                    FrmAddSubGroup.ShowDialog();
                }
                else if (e.ColumnIndex == GRDSubGroup.Columns["BtnDeleting"].Index)
                {
                    // flag = 0;

                    DialogResult a1 = 0;
                    a1 = MessageBox.Show("سوف يتم إلغاء تفعيل هذه المجموعة الفرعية", "النظام", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);

                    if (a1 == System.Windows.Forms.DialogResult.OK)
                    {
                        using (dbContext db = new dbContext())
                        {
                            var Fsubgroup = db.MedicalSubGroups.Where(p => p.Id == SubGroupId).ToList();
                            if (Fsubgroup[0].IsEnabled == true)
                            {
                                Fsubgroup[0].IsEnabled = false;
                            }
                            else
                            {
                                Fsubgroup[0].IsEnabled = true;
                            }
                            db.SaveChanges();
                        }
                    }
                }
            }
        }

        private void GRDSubGroup_CellFormatting(object sender, CellFormattingEventArgs e)
        {
            if (Convert.ToBoolean(e.Row.Cells["IsEnabled"].Value) == false)
            {
                e.CellElement.BackColor = Color.LightYellow;
            }
            else
            {
                e.CellElement.BackColor = Color.White;
            }

        }
    }
}
