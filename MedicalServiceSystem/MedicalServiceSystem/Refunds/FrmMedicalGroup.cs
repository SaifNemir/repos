﻿using ModelDB;
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
    public partial class FrmMedicalGroup : Telerik.WinControls.UI.RadForm
    {
        public FrmMedicalGroup()
        {
            InitializeComponent();
        }
        private void FrmGroup_Load(object sender, EventArgs e)
        {
            LoadData();

        }
        public void LoadData()
        {
            using (dbContext db = new dbContext())
            {
                var GetGroup = db.MedicalMainGroups.ToList();
                GRDGroup.DataSource = GetGroup;
                if (GRDGroup.RowCount > 0)
                {
                    for (int i = 0; i <= GRDGroup.RowCount - 1; i++)
                    {
                        GRDGroup.Rows[i].Cells["Serial"].Value = i + 1;
                    }
                }
            }
        }

        private void GRDGroup_CommandCellClick(object sender, GridViewCellEventArgs e)
        {
            if (GRDGroup.RowCount > 0)
            {
                int GroupId = Convert.ToInt32(GRDGroup.CurrentRow.Cells["Id"].Value.ToString());
                if (e.ColumnIndex == GRDGroup.Columns["BtnEditing"].Index)
                {
                    //flag = 1;
                    FrmAddGroup FrmAddGroup = new FrmAddGroup();
                    FrmAddGroup.GroupEname.Text = (GRDGroup.CurrentRow.Cells["SerEName"].Value).ToString();
                    FrmAddGroup.GroupAName.Text = (GRDGroup.CurrentRow.Cells["SerANAme"].Value).ToString();
                    //FrmAddGroup.GroupCode.Text = GRDGroup.CurrentRow.Cells("SerCode").Value
                    FrmAddGroup.groupId = Convert.ToInt32(GRDGroup.CurrentRow.Cells["Id"].Value);

                    // FrmAddGroup.flag1 = 1;
                    FrmAddGroup.ShowDialog();
                }
                else if (e.ColumnIndex == GRDGroup.Columns["BtnDeleting"].Index)
                {
                    //flag = 0;
                    if (Convert.ToBoolean(GRDGroup.CurrentRow.Cells["IsEnabled"].Value) == true)
                    {
                        DialogResult a1 = 0;
                        a1 = MessageBox.Show("سوف يتم الغاء تفعيل هذه المجموعة!", "النظام", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);

                        if (a1 == System.Windows.Forms.DialogResult.OK)
                        {
                            using (dbContext db = new dbContext())
                            {
                                var Fgroup = db.MedicalMainGroups.Where(p => p.Id == GroupId).ToList();
                                if (Fgroup[0].IsEnabled == true)
                                {
                                    Fgroup[0].IsEnabled = false;
                                }
                                else
                                {
                                    Fgroup[0].IsEnabled = true;
                                }
                                db.SaveChanges();

                            }

                        }

                    }
                }
            }
        }

        private void GRDGroup_CellFormatting(object sender, CellFormattingEventArgs e)
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

        private void Button2_Click(object sender, EventArgs e)
        {

        }
    }
}