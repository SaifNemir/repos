using ModelDB;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Telerik.Reporting.Processing;
using Telerik.WinControls;
using System.Linq;
using System.IO;
using MedicalServiceSystem.SystemSetting;

namespace MedicalServiceSystem.Reclaims
{
    public partial class FRMmedicine : Telerik.WinControls.UI.RadForm
    {
        public FRMmedicine()
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

            GrdDwa.DataSource = null;
            OperationNo.Clear();
            OperationNo.Focus();
            CustName.Clear();
            dwalist.SelectedIndex = -1;
            OperationDate.Value = PLC.getdate();
            ServerName.Clear();
            ServiceListType.Clear();
            quantity.Clear();
            Percentage.Clear();
            UnitPrice.Clear();
            MoneyPaied.Clear();
            medicalsum.Clear();
            approvereason.SelectedIndex = -1;
            RequistingParty.SelectedIndex = -1;
            ExcutingParty.SelectedIndex = -1;
            Saved = false;
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
                card_no.Focus();
                return;
            }
            if (GrdDwa.RowCount == 0)
            {
                MessageBox.Show("لا توجد بيانات لأدوية مدخلة", "النظام", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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
                    GetReclaim[0].ReclaimTotal = Convert.ToDecimal(MoneySum.Text) + Convert.ToDecimal(medicalsum.Text);
                    GetReclaim[0].RefMedicalReqCenterId = Convert.ToInt32(RequistingParty.SelectedValue);
                    GetReclaim[0].RefMedicalExcCenterId = Convert.ToInt32(ExcutingParty.SelectedValue);
                    db.SaveChanges();
                    Saved = true;
                    MessageBox.Show("لقد تم حفظ بيانات الخدمات الطبية", "النظام", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void Button7_Click(object sender, EventArgs e)
        {

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
                        RequistingParty.SelectedValue = FRef[0].RefMedicineReqCenterId;
                        ExcutingParty.SelectedValue = FRef[0].RefMedicineExcCenterId;
                        var FrefMd = db.ReclaimMedicals.Where(p => p.ReclaimId == ReclaimId).ToList();
                        medicalsum.Text = FRef[0].MedicineTotal.ToString();
                        var FrefMl = db.ReclaimMedicines.Where(p => p.ReclaimId == ReclaimId).Select(p => new { p.Id, p.MedicineForReclaim.Generic_name, p.MedicineForReclaim.InContract, p.MedicineForReclaim.UnitCost, p.Quantity, p.Percentages, p.Reclaim.ReclaimStatus, p.Reclaim.ReclaimMedicineResonId }).ToList();
                        GrdDwa.DataSource = FrefMl;
                        string CardNo = card_no.Text;
                        var FrHistoryMc = db.ReclaimMedicines.Where(p => p.Reclaim.Subscriber.InsurNo == CardNo).Select(p=> new {p.Reclaim.ReclaimNo,ServiceName=p.MedicineForReclaim.Generic_name,p.Reclaim.ReclaimDate, System = "النظام" }).ToList();
                        var FrHistoryMd= db.ReclaimMedicals.Where(p => p.Reclaim.Subscriber.InsurNo == CardNo).Select(p => new { p.Reclaim.ReclaimNo, ServiceName = p.MedicalServices.ServiceAName, p.Reclaim.ReclaimDate }).ToList();
                       
                        FRMpatienthistory.Default.Grid_service.DataSource = FrHistoryMc;
                        if (FrHistoryMc.Count > 0)
                        {
                            for (int i = 0; i < FrHistoryMc.Count; i++)
                            {
                                FRMpatienthistory.Default.Grid_service.Rows[i].Cells[0].Value = i + 1;
                            }
                           
                        }

                        FRMpatienthistory.Default.ShowDialog();
                        if (FrefMl.Count > 0)
                        {
                            Saved = true;
                            decimal MedSum = db.ReclaimMedicals.Where(p => p.ReclaimId == ReclaimId).Sum(p => p.ReclaimTotal);
                            MoneySum.Text = MedSum.ToString();
                            BillStatus.SelectedIndex = Convert.ToInt32(FrefMl[0].ReclaimStatus);
                            approvereason.SelectedValue = FrefMl[0].ReclaimMedicineResonId;

                            for (int i = 0; i < FrefMl.Count; i++)
                            {
                                GrdDwa.Rows[i].Cells[0].Value = i + 1;
                            }

                        }
                    }
                }
            }
        }

        private void dwalist_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {
            try
            {
                if (dwalist.ContainsFocus)
                {
                    if (dwalist.SelectedIndex != -1)
                    {
                        using (dbContext db = new dbContext())
                        {
                            ServiceId = Convert.ToInt32(dwalist.SelectedValue);
                            var getSer = db.MedicineForReclaims.Where(p => p.Id == ServiceId).ToList();
                            if (getSer.Count > 0)
                            {
                                if (getSer[0].InContract == true)
                                {
                                    ServiceListType.Text = "داخل العقد";
                                }
                                else
                                {
                                    ServiceListType.Text = "خارج العقد";
                                }
                                UnitPrice.Text = getSer[0].UnitCost.ToString();
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
        private void FillGrid()
        {
            using (dbContext db = new dbContext())
            {
                var FrefMl = db.ReclaimMedicines.Where(p => p.ReclaimId == ReclaimId).Select(p => new { p.Id, p.MedicineForReclaim.Generic_name, p.MedicineForReclaim.InContract, p.MedicineForReclaim.UnitCost, p.Quantity, p.Percentages, p.Reclaim.ReclaimStatus, p.Reclaim.ReclaimMedicineResonId }).ToList();
                GrdDwa.DataSource = FrefMl;
                if (FrefMl.Count > 0)
                {
                    MoneySum.Text = db.ReclaimMedicines.Where(p => p.ReclaimId == ReclaimId).Sum(p => p.ReclaimTotal).ToString();
                    for (int i = 0; i < FrefMl.Count; i++)
                    {
                        GrdDwa.Rows[i].Cells[0].Value = i + 1;
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
            dwalist.SelectedIndex = -1;
            ServiceListType.Clear();
            quantity.Clear();
            Percentage.Clear();
            UnitPrice.Clear();
            MoneyPaied.Clear();
            dwalist.Focus();


        }
        private void FRMmedicine_Load(object sender, EventArgs e)
        {
            UserId = LoginForm.Default.UserId;
            LocalityId = LoginForm.Default.LocalityId;
            using (dbContext db = new dbContext())
            {
                var ReclaimRes = db.ReclaimMedicineReasonsLists.ToList();
                approvereason.DataSource = ReclaimRes;
                approvereason.DisplayMember = "MedicineReason";
                approvereason.ValueMember = "Id";
                approvereason.SelectedIndex = -1;

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

                var EngSer = db.MedicineForReclaims.ToList();
                dwalist.DataSource = EngSer;
                dwalist.ValueMember = "Id";
                dwalist.DisplayMember = "Generic_name";
                dwalist.DropDownListElement.AutoCompleteSuggest.SuggestMode = Telerik.WinControls.UI.SuggestMode.Contains;
                dwalist.SelectedIndex = -1;
                BillStatus.DataSource = Enum.GetValues(typeof(ReclaimStatus));
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
            if (dwalist.SelectedIndex == -1 )
            {
                MessageBox.Show("يجب اختيار الدواء", "النظام", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                dwalist.Focus();
                return;
            }
            if (quantity.Text.Length == 0)
            {
                MessageBox.Show("يجب ادخال عدد مرات تلقي الخدمة", "النظام", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                quantity.Focus();
                return;
            }
            if (approvereason.SelectedIndex == -1)
            {
                MessageBox.Show("يجب اختيار سبب الاسترداد", "النظام", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                approvereason.Focus();
                return;
            }
            decimal MedSum = Convert.ToDecimal(MoneySum.Text) + Convert.ToDecimal(MoneyPaied.Text) + Convert.ToDecimal(medicalsum.Text);
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
                    GetReclaim[0].ReclaimMedicalResonId = Convert.ToInt32(approvereason.SelectedValue);


                    var ChkReclaim = db.ReclaimMedicines.Where(p => p.ReclaimId == ReclaimId && p.MedicineId == ServiceId).ToList();
                    if (ChkReclaim.Count == 0)
                    {
                        ReclaimMedicine rm = new ReclaimMedicine();
                        rm.ReclaimId = ReclaimId;
                        rm.MedicineId= ServiceId;
                        rm.Quantity = Convert.ToInt32(quantity.Text);
                        rm.ReclaimCost = Convert.ToDecimal(UnitPrice);
                        rm.ReclaimTotal = Convert.ToDecimal(MoneyPaied.Text);
                        rm.Percentages = Convert.ToInt32(Percentage.Text);
                        rm.UserId = UserId;
                        db.ReclaimMedicines.Add(rm);
                    }
                    db.SaveChanges();
                    FillGrid();

                }
            }
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            if (GrdDwa.RowCount > 0)
            {
                int ReclaimMedId = Convert.ToInt32(GrdDwa.CurrentRow.Cells[1].Value);
                DialogResult a = 0;
                a = MessageBox.Show("سوف يتم حذف بيانات هذا الدواء", "النظام", MessageBoxButtons.YesNo, MessageBoxIcon.None, MessageBoxDefaultButton.Button2);
                if (a == DialogResult.Yes)
                {
                    using (dbContext db = new dbContext())
                    {
                        var GetMed = db.ReclaimMedicines.Where(p => p.Id == ReclaimMedId).ToList();
                        db.ReclaimMedicines.Remove(GetMed[0]);
                        db.SaveChanges();
                        FillGrid();
                    }
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
                a = MessageBox.Show("سوف يتم حذف بيانات كل الأدوية المدخلة", "النظام", MessageBoxButtons.YesNo, MessageBoxIcon.None, MessageBoxDefaultButton.Button2);
                if (a == DialogResult.Yes)
                {
                    var GetReclaim = db.ReclaimMedicines.Where(p => p.ReclaimId == ReclaimId).ToList();
                    if (GetReclaim.Count > 0)
                    {
                        db.Database.ExecuteSqlCommand("delete from ReclaimMedicines where ReclaimId=" + ReclaimId + "");
                        db.SaveChanges();
                        Saved = false;
                        MessageBox.Show("لقد تم حذف بيانات كل الأدوية المدخلة", "النظام", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadData();
                    }
                }
            }
        }

        private void UnitPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((!(char.IsControl(e.KeyChar))) && (!(char.IsDigit(e.KeyChar))) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }

        private void quantity_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((!(char.IsControl(e.KeyChar))) && (!(char.IsDigit(e.KeyChar))) )
            {
                e.Handled = true;
            }
        }

        private void Percentage_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((!(char.IsControl(e.KeyChar))) && (!(char.IsDigit(e.KeyChar))) )
            {
                e.Handled = true;
            }
        }

        private void UnitPrice_TextChanged(object sender, EventArgs e)
        {
            try
            {
                MoneyPaied.Text = Convert.ToDecimal(Convert.ToDecimal(UnitPrice.Text) * Convert.ToInt32(quantity.Text) * Convert.ToInt32(Percentage.Text) / 100).ToString();
            }
            catch (Exception)
            {


            }
        }

        private void quantity_TextChanged(object sender, EventArgs e)
        {
            try
            {
                MoneyPaied.Text = Convert.ToDecimal(Convert.ToDecimal(UnitPrice.Text) * Convert.ToInt32(quantity.Text) * Convert.ToInt32(Percentage.Text) / 100).ToString();
            }
            catch (Exception)
            {


            }
        }

        private void Percentage_TextChanged(object sender, EventArgs e)
        {
            try
            {
                MoneyPaied.Text = Convert.ToDecimal(Convert.ToDecimal(UnitPrice.Text) * Convert.ToInt32(quantity.Text) * Convert.ToInt32(Percentage.Text) / 100).ToString();
            }
            catch (Exception)
            {


            }
        }

        private void Button8_Click(object sender, EventArgs e)
        {
            if (Saved == false)
            {
                MessageBox.Show("لم يتم حفظ بيانات لهذه المماملة", "النظام", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            try
            {
                using (dbContext db = new dbContext())
                {
                    var FrHistoryMc = db.ReclaimMedicines.Where(p => p.Reclaim.ReclaimNo == OperationNo.Text.Trim()).Select(p => new { p.Reclaim.ReclaimNo, ServiceName = p.MedicineForReclaim.Generic_name, p.Reclaim.ReclaimDate, p.Percentages, p.ReclaimCost, p.ReclaimTotal, p.Reclaim.BillsTotal, p.Reclaim.Subscriber.Server, p.Reclaim.Subscriber.ClientId, InContract = (p.MedicineForReclaim.InContract == true ? "داخل العقد" : "خارج العقد"), ServiceGroup = "أدوية" }).ToList();
                    var FrHistoryMd = db.ReclaimMedicals.Where(p => p.Reclaim.ReclaimNo == OperationNo.Text.Trim()).Select(p => new { p.Reclaim.ReclaimNo, ServiceName = p.MedicalServices.ServiceAName, p.Reclaim.ReclaimDate, p.Percentages, p.ReclaimCost, p.ReclaimTotal, p.Reclaim.BillsTotal, p.Reclaim.Subscriber.Server, p.Reclaim.Subscriber.ClientId, InContract = (p.MedicalServices.InContract == true ? "داخل العقد" : "خارج العقد"), ServiceGroup = "خدمات طبية" }).ToList();
                    var FrHistory = FrHistoryMc.Union(FrHistoryMd).ToList();
                    if (FrHistory.Count > 0)
                    {
                        Estrdad Estr = new Estrdad();
                        Estr.DataSource = FrHistory;
                        double TotalOfMoney = Convert.ToDouble(FrHistory[0].BillsTotal);
                        Estr.MoneyWritten.Value = PLC.NumToStr(TotalOfMoney).ToString();
                        Estr.FormName.Value = "استمارة أ";
                        var GetInfo = db.CompanySettings.FirstOrDefault();
                        Estr.ComanyName.Value = GetInfo.CompanyName;
                        Estr.ManagementName.Value = GetInfo.Management;
                        Estr.DepartmentName.Value = GetInfo.Department;
                        Byte[] MyData = new byte[0];
                        MyData = (Byte[])GetInfo.LogoPath1;
                        MemoryStream stream = new MemoryStream(MyData);
                        stream.Position = 0;
                        Estr.CompanyLogo.Value = Image.FromStream(stream);

                        Byte[] MyData1 = new byte[0];
                        MyData1 = (Byte[])GetInfo.LogoPath2;
                        MemoryStream stream1 = new MemoryStream(MyData1);
                        stream1.Position = 0;
                        Estr.IsoLogo.Value = Image.FromStream(stream1);
                        ReportProcessor pr = new ReportProcessor();
                        PrintDialog pg = new PrintDialog();
                        pr.PrintReport(Estr, pg.PrinterSettings);
                    }
                }
            }
            catch (Exception)
            {

                return;
            }
      
            }
    }
}
