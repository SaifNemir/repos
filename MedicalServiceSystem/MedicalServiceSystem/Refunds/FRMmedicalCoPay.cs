using MedicalServiceSystem.SystemSetting;
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

namespace MedicalServiceSystem.Reclaims
{
    public partial class FRMmedicalCoPay : Telerik.WinControls.UI.RadForm
    {
        public FRMmedicalCoPay()
        {
            InitializeComponent();
        }
        public int UserId = 0;
        public int LocalityId = 0;
        public int ReclaimId = 0;
        public int ServiceId = 0;
        public bool Saved = false;
        private void LoadData()
        {

            GrdMedical.DataSource = null;
            OperationNo.Clear();
            OperationNo.Focus();
            CustName.Clear();
            OperationDate.Value = PLC.getdate();
            ServerName.Clear();
            ServiceListType.Clear();
            quantity.Clear();
            Percentage.Clear();
            UnitPrice.Clear();
            MoneyPaied.Clear();
            dwasum.Clear();
            Saved = false;
        }
        private void FillGrid()
        {
            using (dbContext db = new dbContext())
            {
                var FrefMl = db.ReclaimMedicals.Where(p => p.ReclaimId == ReclaimId).Select(p => new { p.Id, p.MedicalServices.ServiceEName, p.MedicalServices.InContract, p.MedicalServices.ServiceEmPrice, p.Quantity, p.Percentages, p.ReclaimCost, p.ReclaimTotal, p.Reclaim.ReclaimStatus, p.Reclaim.ReclaimMedicalResonId }).ToList();
                GrdMedical.DataSource = FrefMl;
                if (FrefMl.Count > 0)
                {
                    MoneySum.Text = db.ReclaimMedicals.Where(p => p.ReclaimId == ReclaimId).Sum(p => p.ReclaimTotal).ToString();
                    for (int i = 0; i < FrefMl.Count; i++)
                    {
                        GrdMedical.Rows[i].Cells[0].Value = i + 1;
                    }
                    NewMedical();

                }
                else
                {
                    MoneySum.Text = 0.ToString();
                }
            }
        }
        private void NewMedical()
        {
            ServiceList.SelectedIndex = -1;
            MedicalArabic.SelectedIndex = -1;
            ServiceListType.Clear();
            quantity.Clear();
            Percentage.Clear();
            UnitPrice.Clear();
            MoneyPaied.Clear();
            ServiceList.Focus();


        }
        private void FRMmedicalCoPay_Load(object sender, EventArgs e)
        {
            using (dbContext db = new dbContext())
            {
                var ReclaimRes = db.ReclaimMedicalReasonsLists.ToList();
                ApproveReason.DataSource = ReclaimRes;
                ApproveReason.DisplayMember = "MedicalReason";
                ApproveReason.ValueMember = "Id";
                ApproveReason.SelectedIndex = -1;

                var ReqCenter = db.CenterInfos.ToList();
                RequistingParty.DataSource = ReqCenter;
                RequistingParty.ValueMember = "Id";
                RequistingParty.DisplayMember = "CenterName";
                RequistingParty.DropDownListElement.AutoCompleteSuggest.SuggestMode = Telerik.WinControls.UI.SuggestMode.Contains;
                RequistingParty.SelectedIndex = -1;

                var ExcCenter = db.CenterInfos.ToList();
                ExcutingParty.DataSource = ReqCenter;
                ExcutingParty.ValueMember = "Id";
                ExcutingParty.DisplayMember = "CenterName";
                ExcutingParty.DropDownListElement.AutoCompleteSuggest.SuggestMode = Telerik.WinControls.UI.SuggestMode.Contains;
                ExcutingParty.SelectedIndex = -1;

                var EngSer = db.MedicalServices.Where(p => p.ListType == ListType.مساهمة).ToList();
                ServiceList.DataSource = EngSer;
                ServiceList.ValueMember = "Id";
                ServiceList.DisplayMember = "ServiceEName";
                ServiceList.DropDownListElement.AutoCompleteSuggest.SuggestMode = Telerik.WinControls.UI.SuggestMode.Contains;
                ServiceList.SelectedIndex = -1;

                MedicalArabic.DataSource = EngSer;
                MedicalArabic.ValueMember = "Id";
                MedicalArabic.DisplayMember = "ServiceAName";
                MedicalArabic.DropDownListElement.AutoCompleteSuggest.SuggestMode = Telerik.WinControls.UI.SuggestMode.Contains;
                MedicalArabic.SelectedIndex = -1;
                BillStatus.DataSource = Enum.GetValues(typeof(ReclaimStatus));
                UserId = LoginForm.Default.UserId;
                LocalityId = LoginForm.Default.LocalityId;
            }
        }

        private void BTNSearch_Click(object sender, EventArgs e)
        {
            if (OperationNo.Text.Length > 0)
            {
                using (dbContext db = new dbContext())
                {
                    var FRef = db.Reclaims.Where(p => p.ReclaimNo == OperationNo.Text.Trim() && p.RowStatus != RowStatus.Deleted).ToList();
                    if (FRef.Count > 0)
                    {
                        ReclaimId = FRef[0].Id;
                        card_no.Text = FRef[0].Subscriber.InsurNo;
                        CustName.Text = FRef[0].Subscriber.InsurName;
                        OperationDate.Value = FRef[0].ReclaimDate;
                        ServerName.Text = FRef[0].Subscriber.Server;
                        initMoney.Text = FRef[0].BillsTotal.ToString();
                        var FrefMd = db.ReclaimMedicines.Where(p => p.ReclaimId == ReclaimId).ToList();
                        dwasum.Text = FRef[0].MedicineTotal.ToString();
                        RequistingParty.SelectedValue = FRef[0].RefMedicalReqCenterId;
                        ExcutingParty.SelectedValue = FRef[0].RefMedicalExcCenterId;
                        var FrefMl = db.ReclaimMedicals.Where(p => p.ReclaimId == ReclaimId).Select(p => new { p.Id, p.MedicalServices.ServiceEName, p.MedicalServices.InContract, p.MedicalServices.ServiceEmPrice, p.ReclaimCost, p.Quantity, p.Percentages, p.ReclaimTotal, p.Reclaim.ReclaimStatus, p.Reclaim.ReclaimMedicalResonId }).ToList();
                        GrdMedical.DataSource = FrefMl;
                        if (FrefMl.Count > 0)
                        {
                            Saved = true;
                            decimal MedSum = db.ReclaimMedicals.Where(p => p.ReclaimId == ReclaimId).Sum(p => p.ReclaimTotal);
                            MoneySum.Text = MedSum.ToString();
                            BillStatus.SelectedIndex = Convert.ToInt32(FrefMl[0].ReclaimStatus);
                            ApproveReason.SelectedValue = FrefMl[0].ReclaimMedicalResonId;



                            for (int i = 0; i < FrefMl.Count; i++)
                            {
                                GrdMedical.Rows[i].Cells[0].Value = i + 1;
                            }

                        }
                    }
                }
            }
        }

        private void ServiceList_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {
            try
            {
                if (ServiceList.ContainsFocus)
                {
                    if (ServiceList.SelectedIndex != -1)
                    {
                        using (dbContext db = new dbContext())
                        {
                            ServiceId = Convert.ToInt32(ServiceList.SelectedValue);
                            var getSer = db.MedicalServices.Where(p => p.Id == ServiceId).ToList();
                            if (getSer.Count > 0)
                            {
                                ServiceListType.Text = getSer[0].ListType.ToString();
                                UnitPrice.Text = getSer[0].ServicePrice.ToString();
                                MedicalArabic.SelectedValue = getSer[0].Id;
                                Percentage.Text = 100.ToString();
                                quantity.Text = 1.ToString();
                            }
                        }
                    }
                }
            }
            catch (Exception)
            {

                return;
            }
        }

        private void MedicalArabic_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {
            try
            {
                if (MedicalArabic.ContainsFocus)
                {
                    if (MedicalArabic.SelectedIndex != -1)
                    {
                        using (dbContext db = new dbContext())
                        {
                            ServiceId = Convert.ToInt32(MedicalArabic.SelectedValue);
                            var getSer = db.MedicalServices.Where(p => p.Id == ServiceId).ToList();
                            if (getSer.Count > 0)
                            {
                                ServiceListType.Text = getSer[0].ListType.ToString();
                                UnitPrice.Text = getSer[0].ServicePrice.ToString();
                                ServiceList.SelectedValue = getSer[0].Id;
                                Percentage.Text = 100.ToString();
                                quantity.Text = 1.ToString();
                            }
                        }
                    }
                }
            }
            catch (Exception)
            {

                return;
            }
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            if (OperationNo.Text.Length == 0)
            {
                MessageBox.Show("لا توجد بيانات لهذه المماملة", "النظام", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                OperationNo.Focus();
                return;
            }
            if (card_no.Text.Length == 0)
            {
                MessageBox.Show("لا توجد بيانات لهذه المماملة", "النظام", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                OperationNo.Focus();
                return;
            }
            if (ServiceList.SelectedIndex == -1 || MedicalArabic.SelectedIndex == -1)
            {
                MessageBox.Show("يجب اختيار الخدمة الطبية", "النظام", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                ServiceList.Focus();
                return;
            }
            if (quantity.Text.Length == 0)
            {
                MessageBox.Show("يجب ادخال عدد مرات تلقي الخدمة", "النظام", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                quantity.Focus();
                return;
            }
            if (ApproveReason.SelectedIndex == -1)
            {
                MessageBox.Show("يجب اختيار سبب الاسترداد", "النظام", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                ApproveReason.Focus();
                return;
            }
            decimal MedSum = Convert.ToDecimal(MoneySum.Text) + Convert.ToDecimal(MoneyPaied.Text) + Convert.ToDecimal(dwasum.Text);
            if (MedSum > Convert.ToDecimal(initMoney.Text))
            {
                MessageBox.Show("المبلغ المدخل أكبر من اجمالي الفاتورة", "النظام", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                NewMedical();
                return;
            }
            using (dbContext db = new dbContext())
            {

                var GetReclaim = db.Reclaims.Where(p => p.Id == ReclaimId).ToList();
                if (GetReclaim.Count > 0)
                {
                    GetReclaim[0].ReclaimStatus = (ReclaimStatus)Enum.Parse(typeof(ReclaimStatus), BillStatus.SelectedText);
                    GetReclaim[0].ReclaimMedicalResonId = Convert.ToInt32(ApproveReason.SelectedValue);


                    var ChkReclaim = db.ReclaimMedicals.Where(p => p.ReclaimId == ReclaimId && p.MedicalId == ServiceId).ToList();
                    if (ChkReclaim.Count == 0)
                    {
                        ReclaimMedical rm = new ReclaimMedical();
                        rm.ReclaimId = ReclaimId;
                        rm.MedicalId = ServiceId;
                        rm.Quantity = Convert.ToInt32(quantity.Text);
                        rm.ReclaimCost = Convert.ToDecimal(UnitPrice);
                        rm.ReclaimTotal = Convert.ToDecimal(MoneyPaied.Text);
                        rm.Percentages = Convert.ToInt32(Percentage.Text);
                        rm.UserId = UserId;
                        db.ReclaimMedicals.Add(rm);
                    }
                    db.SaveChanges();
                    FillGrid();

                }
            }
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            if (GrdMedical.RowCount > 0)
            {
                int ReclaimMedId = Convert.ToInt32(GrdMedical.CurrentRow.Cells[1].Value);
                DialogResult a = 0;
                a = MessageBox.Show("سوف يتم حذف الخدمة الطبية", "النظام", MessageBoxButtons.YesNo, MessageBoxIcon.None, MessageBoxDefaultButton.Button2);
                if (a == DialogResult.Yes)
                {
                    using (dbContext db = new dbContext())
                    {
                        var GetMed = db.ReclaimMedicals.Where(p => p.Id == ReclaimMedId).ToList();
                        db.ReclaimMedicals.Remove(GetMed[0]);
                        db.SaveChanges();
                        FillGrid();
                    }
                }
            }
        }

        private void Button6_Click(object sender, EventArgs e)
        {
            OperationNo.Enabled = true;
            OperationNo.Clear();
            OperationNo.Focus();
            LoadData();
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            if (OperationNo.Text.Length == 0)
            {
                MessageBox.Show("لا توجد بيانات لهذه المماملة", "النظام", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                OperationNo.Focus();
                return;
            }
            if (card_no.Text.Length == 0)
            {
                MessageBox.Show("لا توجد بيانات لهذه المماملة", "النظام", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                OperationNo.Focus();
                return;
            }
            if (GrdMedical.RowCount == 0)
            {
                MessageBox.Show("لا توجد بيانات لخدمات طبية مدخلة", "النظام", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                NewMedical();
                return;
            }
            if (RequistingParty.SelectedIndex == -1)
            {
                MessageBox.Show("يجب اختيار الجهة الطالبة للخدمة أولا", "النظام", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                RequistingParty.Focus();
                return;
            }
            if (ExcutingParty.SelectedIndex == -1)
            {
                MessageBox.Show("يجب اختيار الجهة المنفذة للخدمة أولا", "النظام", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                ExcutingParty.Focus();
                return;
            }
            using (dbContext db = new dbContext())
            {
                var GetReclaim = db.Reclaims.Where(p => p.Id == ReclaimId).ToList();
                if (GetReclaim.Count > 0)
                {
                    GetReclaim[0].MedicalTotal = Convert.ToDecimal(MoneySum.Text);
                    GetReclaim[0].ReclaimTotal = Convert.ToDecimal(MoneySum.Text) + Convert.ToDecimal(dwasum.Text);
                    GetReclaim[0].RefMedicalReqCenterId = Convert.ToInt32(RequistingParty.SelectedValue);
                    GetReclaim[0].RefMedicalExcCenterId = Convert.ToInt32(ExcutingParty.SelectedValue);
                    db.SaveChanges();
                    Saved = true;
                    MessageBox.Show("لقد تم حفظ بيانات الخدمات الطبية", "النظام", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            if (Saved == false)
            {
                MessageBox.Show("لم يتم حفظ بيانات لهذه المماملة", "النظام", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            using (dbContext db = new dbContext())
            {
                DialogResult a = 0;
                a = MessageBox.Show("سوف يتم حذف بيانات كل الخدمات الطبية المدخلة", "النظام", MessageBoxButtons.YesNo, MessageBoxIcon.None, MessageBoxDefaultButton.Button2);
                if (a == DialogResult.Yes)
                {
                    var GetReclaim = db.ReclaimMedicals.Where(p => p.ReclaimId == ReclaimId).ToList();
                    if (GetReclaim.Count > 0)
                    {
                        db.Database.ExecuteSqlCommand("delete from ReclaimMedicals where ReclaimId=" + ReclaimId + "");
                        db.SaveChanges();
                        Saved = false;
                        MessageBox.Show("لقد تم حذف بيانات كل الخدمات الطبية المدخلة", "النظام", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadData();
                    }
                }
            }
        }
    }
    }
