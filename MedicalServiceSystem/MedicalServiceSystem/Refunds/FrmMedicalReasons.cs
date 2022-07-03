﻿
using ModelDB;
using System;
using System.Linq;
using System.Windows.Forms;

namespace MedicalServiceSystem
{
    public partial class FrmMedicalReasons : Form
    {
        public int ChronicId = 0;
        public FrmMedicalReasons()
        {
            InitializeComponent();
        }

        private void AddNewItem_Load(object sender, EventArgs e)
        {
            using (dbContext db = new dbContext())
            {

                FillCombo();

            }
        }

        public void FillCombo()
        {

            using (dbContext db = new dbContext())
            {
                var Tlist = db.ReclaimMedicalReasonsLists.Select(p => new { p.Id, p.MedicineReason, p.Activated }).ToList();

                ChronicList.DataSource = Tlist;
                ChronicList.DisplayMember = "MedicineReason";
                ChronicList.ValueMember = "Id";
                ChronicList.SelectedIndex = -1;
                ChronicList.DropDownListElement.AutoCompleteSuggest.SuggestMode = Telerik.WinControls.UI.SuggestMode.Contains;
                GrdTrades.DataSource = Tlist;
                
            }
        }

        private void Savebtn_Click(object sender, EventArgs e)
        {
            if (ChronicList.Text == "")
            {
                MessageBox.Show("أدخل السبب أولاً");
                ChronicList.Focus();
                return;
            }

            using (dbContext db = new dbContext())
            {
                if (ChronicId == 0)
                {
                    ReclaimMedicineReasonsList tr = new ReclaimMedicineReasonsList();
                    tr.MedicineReason = ChronicList.Text.Trim();
                    tr.Activated = 1;
                    db.ReclaimMedicalReasonsLists.Add(tr);
                    db.SaveChanges();
                    FillCombo();
                    radButton1.PerformClick();
                    MessageBox.Show("لقد تم حفظ البيانات", "System", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if (ChronicId > 0)
                {
                    var Gtrade = db.ReclaimMedicalReasonsLists.Where(p => p.Id == ChronicId).ToList();
                    if (Gtrade.Count > 0)
                    {
                        Gtrade[0].MedicineReason = ChronicList.Text.Trim();
                        db.SaveChanges();
                        FillCombo();
                        radButton1.PerformClick();
                        MessageBox.Show("لقد تم حفظ البيانات", "System", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            //if (flag==1)
            //{
            //    bool iscool;
            //    if (IsCold.Checked == true)
            //    {
            //        iscool = true;
            //    }
            //    else
            //    {
            //        iscool = false;
            //    }
            //    ItemCommand cmd = new ItemCommand(new StockContext());
            //    var Distinct = cmd.GetList().Any(p => p.ItemName.Contains(nametxt.Text));
            //    if (Distinct == false)
            //    {
            //    cmd.Add(new Item()
            //    {
            //        ItemName = nametxt.Text,
            //        GenericId = int.Parse(Gnamelist.SelectedValue.ToString()),
            //        SmallUnitId = int.Parse(ulist.SelectedValue.ToString()),
            //        LargeUnitId= 1,
            //        UseTypeId=1,
            //        SupplierId= int.Parse(SuppList.SelectedValue.ToString()),
            //        CriticalQty= int.Parse(Qtytxt.Text),
            //        UserId = 1,
            //        RowStatus = RowStatus.Active,
            //        IsCold =iscool

            //    });
            //        if (cmd.Commit())
            //        {
            //            MessageBox.Show("saved");
            //            Fill();
            //        }
            //        else
            //        {
            //            MessageBox.Show("not saved");
            //        }
            //    }
            //    else
            //    {
            //        MessageBox.Show("Record Already Exist!!");
            //    }
            //    nametxt.Text = string.Empty;
            //    Gnamelist.SelectedIndex = 0;
            //    ulist.SelectedIndex = 0;
            // // UTypelist.SelectedIndex = 0;
            //    SuppList.SelectedIndex = 0;
            //    Qtytxt.Text = string.Empty;
            //   // this.Close();
            //}
            //else
            //{
            //    ItemCommand cmd = new ItemCommand(new StockContext());
            //    int id = int.Parse(IDtxt.Text);
            //    int GenericId = int.Parse(Gnamelist.SelectedValue.ToString());
            //    int SmallUnitId = int.Parse(ulist.SelectedValue.ToString());
            //    int UseTypeId = 1;
            //    int SupplierId = int.Parse(SuppList.SelectedValue.ToString());
            //    var q = cmd.FindById(id);

            //    cmd.Edit(q);
            //    q.ItemName = nametxt.Text;
            //    q.GenericId = GenericId;
            //    q.SmallUnitId = SmallUnitId;
            //    q.LargeUnitId =1;
            //    q.UseTypeId = UseTypeId;
            //    q.SupplierId = SupplierId;
            //    q.UserId = 1;
            //    q.RowStatus = RowStatus.Edit;
            //    if (IsCold.Checked == true)
            //    {
            //        q.IsCold = true;
            //    }
            //    else
            //    {
            //        q.IsCold = false;
            //    }

            //    if (cmd.Commit())
            //    {
            //        MessageBox.Show("Updated");
            //        flag = 1;
            //        nametxt.Text = string.Empty;
            //        Gnamelist.SelectedIndex = 0;
            //        ulist.SelectedIndex = 0;
            //        // UTypelist.SelectedIndex = 0;
            //        SuppList.SelectedIndex = 0;
            //        Qtytxt.Text = string.Empty;
            //        IsCold.Checked = false;
            //        Fill();
            //        //  ItemGrid.cu = ItemGrid.Rows[ItemGrid.RowCount - 1].Cells[0];

            //    }
            //    else
            //    {
            //        MessageBox.Show("Not Updated");
            //    }

            //}
        }

        public void RefreshGrid()
        {
            //ItemFrm f = (ItemFrm)Application.OpenForms["ItemFrm"];
            //f.Fill();
        }
        public void Fill()
        {
            //ItemGrid.DataSource = "";
            //ItemCommand cmd = new ItemCommand(new StockContext());
            //var Grid = cmd.GetList().Where
            //                        (p => (p.RowStatus != RowStatus.Deleted && p.RowStatus != RowStatus.suspend)).ToList();

            //ItemGrid.DataSource = Grid;
            //ItemGrid.Columns["Id"].HeaderText = "ID";
            //ItemGrid.Columns["Id"].Width = 80;
            //ItemGrid.Columns["ItemName"].HeaderText = "Generic Name";
            //ItemGrid.Columns["ItemName"].Width = 150;
            //ItemGrid.Columns["GenericId"].HeaderText = "Generic Type Id";
            //ItemGrid.Columns["GenericId"].Width = 100;
            //ItemGrid.Columns["Generic"].IsVisible = false;
            //ItemGrid.Columns["SmallUnitId"].HeaderText = "Unit Id";
            //ItemGrid.Columns["SmallUnitId"].Width = 80;
            //ItemGrid.Columns["SmallUnits"].IsVisible = false;
            //ItemGrid.Columns["LargeUnitId"].IsVisible = false;
            //ItemGrid.Columns["UseTypeId"].IsVisible = false;
            //ItemGrid.Columns["UseType"].IsVisible = false;
            //ItemGrid.Columns["SupplierId"].HeaderText = "Supplier Id";
            //ItemGrid.Columns["SupplierId"].Width = 80;
            //ItemGrid.Columns["Suppliers"].IsVisible = false;
            //ItemGrid.Columns["CriticalQty"].HeaderText = "Critical Qty";
            //ItemGrid.Columns["CriticalQty"].Width = 80;
            //ItemGrid.Columns["UserId"].IsVisible = false;
            //ItemGrid.Columns["ItemStatus"].IsVisible = false;
            //ItemGrid.Columns["RowStatus"].IsVisible = false;
            //ItemGrid.Columns["IsCold"].HeaderText = "Is Cold";
            //ItemGrid.Columns["IsCold"].Width = 80;
            //ItemGrid.Columns["PharmSaleDetails"].IsVisible = false;



        }

        private void ItemGrid_CommandCellClick(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {
            if (GrdTrades.RowCount > 0)
            {
                using (dbContext db = new dbContext())
                {
                    ChronicId = Convert.ToInt32(e.Row.Cells["Id"].Value);
                    if (GrdTrades.CurrentColumn.Name == "Delete")
                    {


                        var gtrade = db.ReclaimMedicalReasonsLists.Where(p => p.Id == ChronicId).ToList();
                        if (gtrade.Count > 0)
                        {
                            if (gtrade[0].Activated == true)
                            {
                                gtrade[0].Activated = false;
                                db.SaveChanges();
                            }
                            else if (gtrade[0].Activated == false)
                            {
                                gtrade[0].Activated = true;
                                db.SaveChanges();
                            }
                            FillCombo();
                        }
                    }


                    else if (GrdTrades.CurrentColumn.Name == "Edit")
                    {
                        //  var form = new AddNewItem();
                        var Gtrade = db.ReclaimMedicalReasonsLists.Where(p => p.Id == ChronicId).ToList();
                        if (Gtrade.Count > 0)
                        {

                            ChronicList.SelectedValue = Gtrade[0].Id;
                            ChronicId = Gtrade[0].Id;
                        }

                    }
                }
            }
        }

        private void radButton1_Click(object sender, EventArgs e)
        {
            ChronicId = 0;
            ChronicList.SelectedIndex = -1;
        }

        private void TradeName_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {
            if (ChronicList.ContainsFocus)
            {
                if (ChronicList.SelectedIndex != -1)
                {
                    ChronicId = Convert.ToInt32(ChronicList.SelectedValue.ToString());

                }
                else
                {
                    ChronicId = 0;
                }
            }
        }

        private void TradeName_TextChanged(object sender, EventArgs e)
        {
            if (ChronicList.ContainsFocus)
            {
                if (ChronicList.Text.Length > 0)
                {
                    // TradeId = Convert.ToInt32(TradeName.SelectedValue.ToString());
                    using (dbContext db = new dbContext())
                    {
                        var gtrade = db.ReclaimMedicalReasonsLists.Where(p => p.MedicineReason == ChronicList.Text).ToList();
                        if (gtrade.Count > 0)
                        {
                            ChronicId = gtrade[0].Id;
                        }
                    }

                }
                else
                {
                    ChronicId = 0;
                }
            }
        }

        private void GrdTrades_CellFormatting(object sender, Telerik.WinControls.UI.CellFormattingEventArgs e)
        {
          
        }

        private void radButton2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void GrdTrades_RowFormatting(object sender, Telerik.WinControls.UI.RowFormattingEventArgs e)
        {
            if (GrdTrades.RowCount > 0)
            {
                if (Convert.ToBoolean(e.RowElement.RowInfo.Cells["Activated"].Value) == false)
                {
                    e.RowElement.DrawFill = true;
                    e.RowElement.BackColor = System.Drawing.Color.Gray;
                }
                else if (Convert.ToBoolean(e.RowElement.RowInfo.Cells["Activated"].Value) == true)
                {
                    e.RowElement.DrawFill = true;
                    e.RowElement.BackColor = System.Drawing.Color.White;
                }
            }
        }
    }
}

