using ModelDB;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;
using Microsoft.VisualBasic;
using MedicalServiceSystem.SystemSetting;

namespace MedicalServiceSystem.Reclaims
{
    public partial class FRMReception : Telerik.WinControls.UI.RadForm
    {
        public FRMReception()
        {
            InitializeComponent();
        }
        public int UserId = 0;
        public int LocalityId = 0;
        public int ReclaimId = 0;
        public int ClientId = 0;
        public string ReNo = "";
        private void card_no_TextChanged(object sender, EventArgs e)
        {
            if (InsuranceNo.Text.Length == 0)
            {
                CustName.Clear();
                ServerName.Clear();
            }
        }

        private void PartMoney_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            if ((!(char.IsControl(e.KeyChar))) && (!(char.IsDigit(e.KeyChar))) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }

        private void Button6_Click(object sender, EventArgs e)
        {
            ClearFields();
        }
        private void ClearFields()
        {
            chsave.Checked = false;
            OperationDate.Value = PLC.getdate();
            OperationNo.Clear();
            InsuranceNo.Clear();
            CustName.Clear();
            ServerName.Clear();
            money.Clear();
            Phone.Clear();
            moneywritten.Clear();
            medicalNote.Clear();
            CenterList.Text = "";
            PartMoney.Clear();
            ReclaimId = 0;
            ClientId = 0;
            money.Enabled = false;
            BillNo.Clear();
            GrdBill.Rows.Clear();
            InsuranceNo.Focus();
        }

        private void Reception_Load(object sender, EventArgs e)
        {
            OperationDate.Value = PLC.getdate();
            UserId = LoginForm.Default.UserId;
            LocalityId = LoginForm.Default.LocalityId;
            BillDate.Value = PLC.getdate();
            using (dbContext db = new dbContext())
            {
                var Gcenter = db.CenterInfos.ToList();
                CenterList.DataSource = Gcenter;
                CenterList.ValueMember = "Id";
                CenterList.DisplayMember = "CenterName";
                CenterList.SelectedIndex = -1;
                CenterList.DropDownListElement.AutoCompleteSuggest.SuggestMode = Telerik.WinControls.UI.SuggestMode.Contains;
            }
        }

        private void BTNSearch_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(InsuranceNo.Text))
            {
                using (dbContext db = new dbContext())
                {
                    var ser = db.Subscribers.Where(p => p.InsurNo == InsuranceNo.Text).Take(1).ToList();
                    if (ser.Count > 0)
                    {
                        if (InsuranceNo.Text.Length == 9 && !InsuranceNo.Text.Contains("/"))
                        {
                            if (PLC.conNew.State == (System.Data.ConnectionState)1)
                            {
                                PLC.conNew.Close();
                            }
                            PLC.conNew.Open();
                            string srr = "select top 1 * from Cards where InsuranceNo=" + InsuranceNo.Text + " and RowStatus<>2";
                            SqlDataAdapter dasearch = new SqlDataAdapter(srr, PLC.conNew);
                            DataTable dtsearch = new DataTable();
                            dtsearch.Clear();
                            dasearch.Fill(dtsearch);
                            if (dtsearch.Rows.Count > 0)
                            {
                                //int Clint = Convert.ToInt32(dtsearch.Rows[0]["ClientId"]);
                                //string Srcl = "select top 1 * from Contracts where ClientId=" + Clint + " and RowStatus<>2";
                                //SqlDataAdapter daclient = new SqlDataAdapter(Srcl, PLC.conNew);
                                //DataTable dtclient = new DataTable();
                                //dtclient.Clear();
                                //daclient.Fill(dtclient);
                                //if (Convert.ToInt32(dtclient.Rows[0]["contractStatus"]) == 1)
                                //{
                                //    MessageBox.Show("عقد المخدم الذي يتبع له هذا المشترك موقوف :" + (char)13 + "واسم العقد هو" + " " + dtclient.Rows[0]["Description"]+" "+ dtclient.Rows[0]["ClientId"], "النظام", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                                //    this.Cursor = Cursors.Default;
                                //    return;
                                //}
                                if (Convert.ToInt32(dtsearch.Rows[0]["Status"]) == 1)
                                {
                                    MessageBox.Show("هذا المشترك موقوف وسبب الايقاف هو :" + (char)13 + dtsearch.Rows[0]["Comment"], "النظام", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                                    this.Cursor = Cursors.Default;
                                    return;
                                }
                            }
                        }
                        if (ser[0].IsStoped == false)
                        {
                            this.Cursor = Cursors.WaitCursor;
                          
                            CustName.Text = ser[0].InsurName;
                            Birthdate.Value = ser[0].BirthDate;
                            sex.Text = ser[0].Gender;
                            Phone.Text = ser[0].PhoneNo;
                            ServerName.Text = ser[0].Server;
                            this.Cursor = Cursors.Default;
                        }
                        else
                        {
                            MessageBox.Show("هذا المشترك موقوف وسبب الايقاف هو :" + (char)13 + ser[0].Notes, "النظام", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                            return;
                        }
                    }
                    else
                    {
                        this.Cursor = Cursors.WaitCursor;
                        string str111 = null;
                        str111 = InsuranceNo.Text;
                        if (str111.Contains("/"))
                        {
                            int leng = str111.Length;
                            string r1 = "";
                            int a1 = 0;
                            for (var i = 1; i <= leng; i++)
                            {
                                string Ostr = str111.Substring(i - 1, 1);
                                if (char.IsDigit(Convert.ToChar(Ostr)))
                                {
                                    r1 = r1 + Ostr;

                                }
                                else
                                {
                                    a1 = i;
                                    break;
                                }
                            }
                            int corNo = 0;
                            int recNo = 0;
                            int cardSer = 0;
                            int cardNo = 0;
                            corNo = Convert.ToInt32(r1);
                            string r2 = "";
                            int a2 = a1 + 1;
                            for (var i = a2; i <= leng; i++)
                            {
                                string Ostr = str111.Substring(i - 1, 1);
                                if (char.IsDigit(Convert.ToChar(Ostr)))
                                {
                                    r2 = r2 + Ostr;

                                }
                                else
                                {
                                    a2 = i;
                                    break;
                                }
                            }
                            recNo = Convert.ToInt32(r2);
                            string r3 = "";
                            int a3 = a2 + 1;
                            for (var i = a3; i <= leng; i++)
                            {
                                string Ostr = str111.Substring(i - 1, 1);
                                if (char.IsDigit(Convert.ToChar(Ostr)))
                                {
                                    r3 = r3 + Ostr;

                                }
                                else
                                {
                                    a3 = i;
                                    break;
                                }
                            }
                            cardSer = Convert.ToInt32(r3);
                            string r4 = "";
                            int a4 = a3 + 1;
                            // messagebox.show(a4)
                            for (var i = a4; i <= leng; i++)
                            {
                                string Ostr = str111.Substring(i - 1, 1);
                                if (char.IsDigit(Convert.ToChar(Ostr)))
                                {
                                    r4 = r4 + Ostr;

                                }
                                else
                                {
                                    break;
                                }
                            }
                            cardNo = Convert.ToInt32(r4);
                            if (PLC.conOld.State == (System.Data.ConnectionState)1)
                            {
                                PLC.conOld.Close();
                            }
                            PLC.conOld.Open();
                            string srr = "select top 1 * from data where cor_no=" + corNo + " and rec_no=" + recNo + " and card_no=" + cardNo + " and card_ser=" + cardSer + "";
                            SqlDataAdapter dasearch = new SqlDataAdapter(srr, PLC.conNew);
                            DataTable dtsearch = new DataTable();
                            dtsearch.Clear();
                            dasearch.Fill(dtsearch);
                            if (dtsearch.Rows.Count > 0)
                            {

                                DateTime date1 = Convert.ToDateTime(dtsearch.Rows[0]["STOP_CARD"]);
                                // MsgBox(date1.Date)
                                string stri1 = null;
                                string str2 = null;
                                if (Convert.IsDBNull(dtsearch.Rows[0]["name_3"]) == false)
                                {
                                    stri1 = Convert.ToString(dtsearch.Rows[0]["name_3"]).Trim(' ');
                                }
                                else
                                {
                                    stri1 = ".";
                                }
                                if (Convert.IsDBNull(dtsearch.Rows[0]["name_4"]) == false)
                                {
                                    str2 = Convert.ToString(dtsearch.Rows[0]["name_4"]).Trim(' ');
                                }
                                else
                                {
                                    str2 = ".";
                                }
                                CustName.Text = Convert.ToString(dtsearch.Rows[0]["name_1"]).Trim() + " " + Convert.ToString(dtsearch.Rows[0]["name_2"]).Trim() + " " + stri1 + " " + str2;
                                sex.Text = Convert.ToString(dtsearch.Rows[0]["sex"]).Trim();
                                if (Convert.IsDBNull(dtsearch.Rows[0]["phone"]) == false)
                                {
                                    Phone.Text = dtsearch.Rows[0]["phone"].ToString();
                                }
                                else
                                {
                                    Phone.Text = "";
                                }
                                //Info4 = Convert.ToString(dtsearch.Rows[0]["l_add"]).Trim(' ');
                                Birthdate.Value = Convert.ToDateTime(dtsearch.Rows[0]["birth_date"]);

                                //Birthdate.Value = dtsearch.Rows(0)("birth_date")
                                String Rec_No = corNo.ToString() + "/" + recNo.ToString();
                                string serv = "select top1 * from corpration where cor_no=" + corNo + " and rec_no=" + recNo + "";
                                SqlDataAdapter DaServ = new SqlDataAdapter(serv, PLC.conOld);
                                DataTable dtServ = new DataTable();
                                dtServ.Clear();
                                DaServ.Fill(dtServ);
                                if (dtServ.Rows.Count > 0)
                                {
                                    ServerName.Text = Convert.ToString(dtServ.Rows[0]["COR_NAME"]).Trim();
                                }

                                this.AcceptButton = null;
                                PLC.conOld.Close();
                                Subscriber Sc = new Subscriber();

                                Sc.PhoneNo = Phone.Text;
                                Sc.InsurNo = InsuranceNo.Text;
                                Sc.InsurName = CustName.Text;
                                Sc.Gender = sex.Text;
                                Sc.Server = ServerName.Text;
                                Sc.ClientId = Rec_No;
                                Sc.BirthDate = BillDate.Value;
                                Sc.localityId = LocalityId;
                                db.Subscribers.Add(Sc);
                                db.SaveChanges();
                                this.Cursor = Cursors.Default;
                            }
                            else
                            {
                                this.Cursor = Cursors.Default;
                                MessageBox.Show("لا توجد بيانات", "النظام", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                return;
                            }
                        }
                        else
                        {
                            if (PLC.conNew.State == (System.Data.ConnectionState)1)
                            {
                                PLC.conNew.Close();
                            }
                            PLC.conNew.Open();
                            string srr = "select top 1 * from Cards where InsuranceNo=" + InsuranceNo.Text + " and RowStatus<>2";
                            SqlDataAdapter dasearch = new SqlDataAdapter(srr, PLC.conNew);
                            DataTable dtsearch = new DataTable();
                            dtsearch.Clear();
                            dasearch.Fill(dtsearch);
                            if (dtsearch.Rows.Count > 0)
                            {

                                //DateTime date1 = Convert.ToDateTime(dtsearch.Rows[0]["STOP_CARD"]);
                                // MsgBox(date1.Date)
                                string stri1 = null;
                                string str2 = null;
                                if (dtsearch.Rows[0]["Thirdname"] == null)
                                {
                                    stri1 = dtsearch.Rows[0]["Thirdname"].ToString().Trim();
                                }
                                else
                                {
                                    stri1 = ".";
                                }
                                if (dtsearch.Rows[0]["Fourthname"] == null)
                                {
                                    str2 = dtsearch.Rows[0]["Fourthname"].ToString().Trim();
                                }
                                else
                                {
                                    str2 = ".";
                                }
                                CustName.Text = Convert.ToString(dtsearch.Rows[0]["Firstname"]).Trim() + " " + Convert.ToString(dtsearch.Rows[0]["Secondname"]).Trim() + " " + stri1 + " " + str2;
                                sex.Text = Convert.ToString(dtsearch.Rows[0]["Gender"]).Trim();
                                if (dtsearch.Rows[0]["Phone"] == null)
                                {
                                    Phone.Text = dtsearch.Rows[0]["Phone"].ToString();
                                }
                                else
                                {
                                    Phone.Text = "";
                                }
                                //Info4 = Convert.ToString(dtsearch.Rows[0]["l_add"]).Trim(' ');
                                Birthdate.Value = Convert.ToDateTime(dtsearch.Rows[0]["Birthdate"]);
                                //Birthdate.Value = dtsearch.Rows(0)("birth_date")
                                ClientId = Convert.ToInt32(dtsearch.Rows[0]["ClientId"].ToString());
                                string serv = "select top 1 * from Clients where Id=" + ClientId + "";
                                SqlDataAdapter DaServ = new SqlDataAdapter(serv, PLC.conNew);
                                DataTable dtServ = new DataTable();
                                dtServ.Clear();
                                DaServ.Fill(dtServ);
                                if (dtServ.Rows.Count > 0)
                                {
                                    ServerName.Text = Convert.ToString(dtServ.Rows[0]["ArabicClientName"]).Trim();
                                }
                                this.AcceptButton = null;
                                PLC.conOld.Close();
                                Subscriber Sc = new Subscriber();
                                Sc.PhoneNo = Phone.Text;
                                Sc.InsurNo = InsuranceNo.Text.Trim();
                                Sc.InsurName = CustName.Text;
                                Sc.Gender = sex.Text;
                                Sc.Server = ServerName.Text;
                                Sc.ClientId = ClientId.ToString();
                                Sc.BirthDate = BillDate.Value;
                                Sc.localityId = LocalityId;
                                db.Subscribers.Add(Sc);
                                db.SaveChanges();
                                this.Cursor = Cursors.Default;
                            }
                            else
                            {
                                this.Cursor = Cursors.Default;
                                MessageBox.Show("لا توجد بيانات", "النظام", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                return;
                            }
                        }

                    }

                }
            }
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(CenterList.Text))
            {

                if (string.IsNullOrEmpty(CustName.Text))
                {
                    MessageBox.Show("يجب ادخال بيانات المشترك أولاً", "النظام", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    InsuranceNo.Focus();
                    return;
                }
                if (GrdBill.RowCount > 0)
                {
                    for (int i = 0; i < GrdBill.RowCount; i++)
                    {
                        if (GrdBill.Rows[i].Cells[3].Value.ToString() == BillNo.Text && GrdBill.Rows[i].Cells[1].Value.ToString() == CenterList.Text)
                        {
                            return;
                        }
                    }
                }
                GrdBill.Rows.Add(GrdBill.RowCount + 1, CenterList.Text, Convert.ToDouble(PartMoney.Text), BillNo.Text, BillDate.Value,CenterList.SelectedValue.ToString());
                if (GrdBill.RowCount > 0)
                {
                    double a = 0;
                    for (int i = 0; i < GrdBill.RowCount; i++)
                    {
                        a += Convert.ToDouble(GrdBill.Rows[i].Cells[2].Value);
                    }
                    money.Text = a.ToString();
                    CenterList.Text = "";
                    CenterList.Focus();
                    PartMoney.Clear();
                    BillNo.Clear();
                }
            }
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            if (GrdBill.RowCount > 0)
            {

                GrdBill.Rows.RemoveAt(GrdBill.CurrentRow.Index);
            }


            if (GrdBill.RowCount > 0)
            {
                double a = 0;
                for (int i = 0; i < GrdBill.RowCount; i++)
                {
                    a += Convert.ToDouble(GrdBill.Rows[i].Cells[2].Value);
                }
                money.Text = a.ToString();
            }
            else
            {
                money.Clear();
            }
        }

        private void money_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(money.Text))
                {
                    moneywritten.Text = PLC.NumToStr(Convert.ToDouble(money.Text));
                }
                else if (money.Text == "0")
                {
                    moneywritten.Text = "";
                }
                else
                {
                    moneywritten.Text = "";
                }
            }
            catch (Exception)
            {

            }
        }

        private void Button8_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(OperationNo.Text))
            {
                using (dbContext db = new dbContext())
                {
                    db.Database.CommandTimeout= 0;
                    var Fref = db.Reclaims.Where(p => p.ReclaimNo == OperationNo.Text.Trim() && p.RowStatus != RowStatus.Deleted).ToList();
                    if (Fref.Count > 0)
                    {
                        this.AcceptButton = null;
                        OperationDate.Value = Fref[0].ReclaimDate;
                        InsuranceNo.Text = Fref[0].Subscriber.InsurNo;
                        CustName.Text = Fref[0].Subscriber.InsurName;
                        ServerName.Text = Fref[0].Subscriber.Server;
                        sex.Text = Fref[0].Subscriber.Gender;
                        Birthdate.Value = Fref[0].Subscriber.BirthDate;
                        money.Text = Fref[0].BillsTotal.ToString();
                        Phone.Text = Fref[0].Subscriber.PhoneNo;
                        medicalNote.Text = Fref[0].Notes;
                        ReclaimId = Fref[0].Id;
                        //int RefId = Fref[0].Id;
                        var Fbill = db.ReclaimBills.Where(p => p.ReclaimId == ReclaimId).ToList(); ;
                        if (Fbill.Count > 0)
                        {
                            GrdBill.Rows.Clear();
                            for (int i = 0; i < Fbill.Count; i++)
                            {
                                GrdBill.Rows.Add(i + 1, Fbill[i].CenterInfo.CenterName, Fbill[i].BillTotal, Fbill[i].BillNo, Fbill[i].BillDate, Fbill[i].ServiceProviderId);
                            }
                        }
                        chsave.Checked = true;
                    }
                    else
                    {
                        MessageBox.Show("لا توجد بيانات", "النظام", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        OperationNo.Clear();
                        OperationNo.Focus();
                        return;
                    }
                }
            }
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            if (GrdBill.RowCount > 0)
            {
                if (OperationNo.Text.Length == 0)
                {

                    using (dbContext db = new dbContext())
                    {
                        ModelDB.Reclaim Rf = new ModelDB.Reclaim();
                        Rf.ReclaimDate = OperationDate.Value;
                        int SubId = db.Subscribers.Where(p => p.InsurNo == InsuranceNo.Text).ToList()[0].Id;
                        Rf.SubscriberId = SubId;
                        Rf.BillsTotal = Convert.ToDecimal(money.Text);
                        Rf.ReclaimTotal = 0;
                        Rf.MedicalTotal = 0;
                        Rf.MedicineTotal = 0;
                        Rf.Notes = medicalNote.Text.Trim();
                        Rf.UserId = UserId;
                        Rf.DateIn = OperationDate.Value;
                        Rf.LocalityId = LocalityId;
                        Rf.ReclaimMedicalResonId = 0;
                        Rf.ReclaimMedicineResonId = 0;
                        db.Reclaims.Add(Rf);
                        db.SaveChanges();
                        int GId = db.Reclaims.Where(p => p.UserId == UserId).Max(p => p.Id);
                        ReclaimId = GId;
                        string ltr = db.Localities.Where(p => p.Id == LocalityId).ToList()[0].LocalityLetter;
                         ReNo = ltr + GId.ToString();
                        OperationNo.Text = ReNo;
                        var RNo = db.Reclaims.Where(p => p.Id == GId).FirstOrDefault();
                        RNo.ReclaimNo = ReNo;
                        db.SaveChanges();
                        for (int i = 0; i < GrdBill.RowCount; i++)
                        {
                            ReclaimBills Reb = new ReclaimBills();
                            Reb.ReclaimId = GId;
                            Reb.ServiceProviderId = Convert.ToInt32(GrdBill.Rows[i].Cells["CenterId"].Value);
                            Reb.BillNo = GrdBill.Rows[i].Cells["BillNo"].Value.ToString();
                            Reb.BillDate = Convert.ToDateTime(GrdBill.Rows[i].Cells["BillDate"].Value);
                            Reb.BillTotal = Convert.ToDecimal(GrdBill.Rows[i].Cells["Money"].Value);
                            db.ReclaimBills.Add(Reb);
                            db.SaveChanges();
                        }
                        FRMSave.Default.OPr.Text = ReNo;
                        FRMSave.Default.ShowDialog();

                    }



                }
                else
                {
                    using (dbContext db = new dbContext())
                    {
                        if (ReclaimId > 0)
                        {
                            var Fref = db.Reclaims.Where(p => p.Id == ReclaimId).ToList();
                            if (Fref.Count > 0)
                            {
                                Fref[0].BillsTotal = Convert.ToDecimal(money.Text);
                                Fref[0].ReclaimTotal = 0;
                                Fref[0].Notes = medicalNote.Text.Trim();
                                Fref[0].UpdateDate = OperationDate.Value;
                                Fref[0].UpdateUser = UserId;
                            }
                            db.Database.ExecuteSqlCommand("delete from ReclaimBills where ReclaimId=" + ReclaimId + " ");
                            for (int i = 0; i < GrdBill.RowCount; i++)
                            {
                                ReclaimBills Reb = new ReclaimBills();
                                Reb.ReclaimId = ReclaimId;
                                Reb.ServiceProviderId = Convert.ToInt32(GrdBill.Rows[i].Cells["CenterId"].Value);
                                Reb.BillNo = GrdBill.Rows[i].Cells["BillNo"].Value.ToString();
                                Reb.BillDate = Convert.ToDateTime(GrdBill.Rows[i].Cells["BillDate"].Value);
                                Reb.BillTotal = Convert.ToDecimal(GrdBill.Rows[i].Cells["Money"].Value);
                                db.ReclaimBills.Add(Reb);
                                db.SaveChanges();
                            }
                            MessageBox.Show("لقد تم حفظ التعديل ", "النظام", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }

                        else
                        {
                            MessageBox.Show("لا توجد بيانات للتعديل", "النظام", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            return;
                        }
                    }

                }
            }
            else
            {
                MessageBox.Show("لا توجد بيانات للحفظ", "النظام", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
        }

        private void Button3_Click(object sender, EventArgs e)
        {

            if (ReclaimId > 0)
            {
                DateTime date1 = OperationDate.Value;
                DateTime date2 = PLC.getdate();
                int Datedif =(int)DateAndTime.DateDiff (DateInterval.Day, date1, date2);
                if (Datedif <= 30)
                {
                    using (dbContext db = new dbContext())
                    {
                        DialogResult a = 0;
                        a = MessageBox.Show("سوف يتم حذف بيانات العملية", "النظام", MessageBoxButtons.YesNo, MessageBoxIcon.None, MessageBoxDefaultButton.Button2);
                        if (a == DialogResult.Yes)
                        {
                            db.Database.ExecuteSqlCommand("update  Reclaims set RowStatus=2 , UserDeleted =" + UserId + ",DeleteDate=GetDate() where Id=" + ReclaimId + "");
                            db.Database.ExecuteSqlCommand("delete from ReclaimBills where ReclaimId=" + ReclaimId + "");
                            db.Database.ExecuteSqlCommand("delete from ReclaimMedicals where ReclaimId=" + ReclaimId + "");
                            db.Database.ExecuteSqlCommand("delete from ReclaimMedicines where ReclaimId=" + ReclaimId + "");
                            //SqlCommand cmddel2 = new SqlCommand("delete from treatmentdetails where operationno='" + OperationNo.Text + "'  ", PLC.con);
                            //cmddel2.ExecuteNonQuery();
                            ClearFields();
                            MessageBox.Show("لقد تم حذف البيانات", "النظام", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }
                    }

                }
                else
                {
                    MessageBox.Show("لا يمكن حذف معاملة بعد 30 يوماً من ادخالها", "النظام", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            else
            {
                MessageBox.Show("لا توجد بيانات للحذف", "النظام", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void Button7_Click(object sender, EventArgs e)
        {
            FrmSearch frs = new FrmSearch();
            frs.ShowDialog();
        }

        private void BTNStop_Click(object sender, EventArgs e)
        {
            if (InsuranceNo.Text.Length == 0)
            {
                MessageBox.Show("يجب ادخال بيانات المشترك", "النظام", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                InsuranceNo.Focus();
                return;
            }
            if (CustName.Text.Length == 0)
            {
                MessageBox.Show("يجب ادخال بيانات المشترك", "النظام", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                CustName.Focus();
                return;
            }
            FRMStopSubscriber.Default.card_no.Text = InsuranceNo.Text;
            FRMStopSubscriber.Default.ful_name.Text = CustName.Text;
            FRMStopSubscriber.Default.ShowDialog();
        }
    }
}
