using System;
using System.Windows.Forms;
using System.Data;
//using System.Data.sql;
using System.Data.SqlClient;
using ModelDB;
using System.Linq;
using MedicalServiceSystem.Reports;

namespace MedicalServiceSystem
{

    public partial class FRMreportChronics : Telerik.WinControls.UI.RadForm
    {
        internal FRMreportChronics()
        {
            InitializeComponent();
        }
        public int UserId = 0;
        public int LocalityId = 0;
        private void SimpleButton1_Click(object sender, System.EventArgs e)
        {


        }

        private void reports_FormClosed(object sender, System.Windows.Forms.FormClosedEventArgs e)
        {
            ;
        }

        private void reports_Load(object sender, System.EventArgs e)
        {
            d_start.Value = PLC.getdate();
            d_end.Value = PLC.getdate();
            UserId = SystemSetting.LoginForm.Default.UserId;
            LocalityId = SystemSetting.LoginForm.Default.LocalityId;


        }

        [Obsolete]
        private void Rd_books_CheckedChanged(object sender, EventArgs e)
        {
            if (rd_books.Checked)
            {
                using (dbContext db = new dbContext())
                {
                    var GetDet = db.Database.SqlQuery<ReportForAll>("SELECT dbo.ChronicsBooks.BookNo AS Row1, dbo.ChronicsBooks.BookDate AS Row13, dbo.ChronicsBooks.DocNo AS Row2, dbo.Subscribers.InsurName AS Row6, dbo.Subscribers.InsurNo AS Row7,  dbo.CenterInfoes.CenterName AS Row8, dbo.ChronicBookTypes.BookType AS Row9 FROM  dbo.ChronicsBooks INNER JOIN dbo.CenterInfoes ON dbo.ChronicsBooks.CenterId = dbo.CenterInfoes.Id INNER JOIN dbo.Chronics INNER JOIN dbo.ChronicBooksDetails ON dbo.Chronics.Id = dbo.ChronicBooksDetails.ChronicId ON dbo.ChronicsBooks.Id = dbo.ChronicBooksDetails.BookId INNER JOIN dbo.Subscribers ON dbo.ChronicsBooks.SubscriberId = dbo.Subscribers.Id INNER JOIN dbo.Localities ON dbo.ChronicsBooks.LocalityId = dbo.Localities.Id INNER JOIN dbo.Users ON dbo.ChronicsBooks.UserId = dbo.Users.Id INNER JOIN  dbo.ChronicBookTypes ON dbo.ChronicsBooks.BookTypeId = dbo.ChronicBookTypes.Id where dbo.ChronicsBooks.BookDate between '" + d_start.Value + "' and '" + d_end.Value + "' and  dbo.ChronicsBooks.LocalityId=" + LocalityId + " GROUP BY dbo.ChronicsBooks.BookNo, dbo.ChronicsBooks.BookDate, dbo.ChronicsBooks.DocNo, dbo.Subscribers.InsurName, dbo.Subscribers.InsurNo, dbo.CenterInfoes.CenterName, dbo.ChronicBookTypes.BookType").ToList();
                    //MessageBox.Show(GetDet.Count.ToString());
                    if (GetDet.Count > 0)
                    {

                        RPTChronicBooksDetails Rdet = new RPTChronicBooksDetails();
                        Rdet.DataSource = GetDet;
                        Rdet.Locality.Value = db.Localities.Where(p => p.Id == LocalityId).ToList()[0].LocalityName;
                        Rdet.StartDate.Value = d_start.Value.Date.ToShortDateString();
                        Rdet.EndDate.Value = d_end.Value.Date.ToShortDateString();
                        RptiewChronics.ReportSource = Rdet;
                        RptiewChronics.RefreshReport();
                        RptiewChronics.Show();
                    }
                }

            }
        }

        private void Rd_center_CheckedChanged(object sender, EventArgs e)
        {
            if (rd_center.Checked)
            {
                using (dbContext db = new dbContext())
                {
                    var GetCent = db.Database.SqlQuery<ReportForAll>("SELECT dbo.CenterInfoes.CenterName AS Row6, COUNT(dbo.ChronicsBooks.BookNo) AS Row1 FROM dbo.CenterInfoes INNER JOIN dbo.ChronicsBooks ON dbo.CenterInfoes.Id = dbo.ChronicsBooks.CenterId   INNER JOIN dbo.Localities ON dbo.ChronicsBooks.LocalityId = dbo.Localities.Id  WHERE (dbo.ChronicsBooks.BookDate BETWEEN '" + d_start.Value + "' and '" + d_end.Value + "')  and (dbo.ChronicsBooks.LocalityId = " + LocalityId + ")GROUP BY dbo.CenterInfoes.CenterName, dbo.ChronicsBooks.BookDate").ToList();
                    if (GetCent.Count > 0)
                    {

                        RPTChronicAll Rdet = new RPTChronicAll();
                        Rdet.DataSource = GetCent;
                        Rdet.Locality.Value = db.Localities.Where(p => p.Id == LocalityId).ToList()[0].LocalityName;
                        Rdet.StartDate.Value = d_start.Value.Date.ToShortDateString();
                        Rdet.EndDate.Value = d_end.Value.Date.ToShortDateString();
                        Rdet.ReportTitle.Value = rd_center.Text;
                        Rdet.ReportٍSubject.Value = "اسم المــركز";
                        Rdet.ReportٍSubject1.Value = "اسم المــركز";
                        Rdet.Frequency.Value = "عدد الدفاتر";
                        Rdet.Frequency1.Value = "عدد الدفاتر";
                        RptiewChronics.ReportSource = Rdet;
                        RptiewChronics.RefreshReport();
                        RptiewChronics.Show();
                    }
                }
            }
        }

        private void Rd_chronic_CheckedChanged(object sender, EventArgs e)
        {
            if (rd_chronic.Checked)
            {
                using (dbContext db = new dbContext())
                {
                    var GetCent = db.Database.SqlQuery<ReportForAll>("SELECT dbo.Chronics.ChronicName AS Row6, COUNT(dbo.ChronicsBooks.BookNo) AS Row1 FROM dbo.ChronicsBooks INNER JOIN dbo.ChronicBooksDetails ON dbo.ChronicsBooks.Id = dbo.ChronicBooksDetails.BookId INNER JOIN dbo.Chronics ON dbo.ChronicBooksDetails.ChronicId = dbo.Chronics.Id   INNER JOIN dbo.Localities ON dbo.ChronicsBooks.LocalityId = dbo.Localities.Id  WHERE (dbo.ChronicsBooks.BookDate BETWEEN '" + d_start.Value + "' and '" + d_end.Value + "')  and (dbo.ChronicsBooks.LocalityId = " + LocalityId + ") GROUP BY dbo.ChronicsBooks.BookDate, dbo.Chronics.ChronicName").ToList();
                    if (GetCent.Count > 0)
                    {

                        RPTChronicAll Rdet = new RPTChronicAll();
                        Rdet.DataSource = GetCent;
                        Rdet.Locality.Value = db.Localities.Where(p => p.Id == LocalityId).ToList()[0].LocalityName;
                        Rdet.StartDate.Value = d_start.Value.Date.ToShortDateString();
                        Rdet.EndDate.Value = d_end.Value.Date.ToShortDateString();
                        Rdet.ReportTitle.Value = rd_chronic.Text;
                        Rdet.ReportٍSubject.Value = "اسم المــرض";
                        Rdet.ReportٍSubject1.Value = "اسم المــرض";
                        Rdet.Frequency.Value = "التردد";
                        Rdet.Frequency1.Value = "التردد";
                        RptiewChronics.ReportSource = Rdet;
                        RptiewChronics.RefreshReport();
                        RptiewChronics.Show();
                    }
                }
            }
        }

        private void RDLocal_CheckedChanged(object sender, EventArgs e)
        {
            if (RDLocal.Checked)
            {
                using (dbContext db = new dbContext())
                {
                    var GetCent = db.Database.SqlQuery<ReportForAll>("SELECT dbo.Localities.LocalityName AS Row6, COUNT(dbo.ChronicsBooks.BookNo) AS Row1 FROM dbo.ChronicsBooks INNER JOIN dbo.Localities ON dbo.ChronicsBooks.LocalityId = dbo.Localities.Id WHERE (dbo.ChronicsBooks.BookDate BETWEEN '" + d_start.Value + "' and '" + d_end.Value + "') and (dbo.ChronicsBooks.LocalityId = " + LocalityId + ")  GROUP BY dbo.ChronicsBooks.BookDate, dbo.Localities.LocalityName").ToList();
                    if (GetCent.Count > 0)
                    {

                        RPTChronicAll Rdet = new RPTChronicAll();
                        Rdet.DataSource = GetCent;
                        Rdet.Locality.Value = db.Localities.Where(p => p.Id == LocalityId).ToList()[0].LocalityName;
                        Rdet.StartDate.Value = d_start.Value.Date.ToShortDateString();
                        Rdet.EndDate.Value = d_end.Value.Date.ToShortDateString();
                        Rdet.ReportTitle.Value = RDLocal.Text;
                        Rdet.ReportٍSubject.Value = "اسم الادارة";
                        Rdet.ReportٍSubject1.Value = "اسم الادارة";
                        Rdet.Frequency.Value = "عدد الدفاتر المستخرجة";
                        Rdet.Frequency1.Value = "عدد الدفاتر المستخرجة";
                        RptiewChronics.ReportSource = Rdet;
                        RptiewChronics.RefreshReport();
                        RptiewChronics.Show();
                    }
                }
            }
        }

        private void RDBookTYP_CheckedChanged(object sender, EventArgs e)
        {
            if (RDBookTYP.Checked)
            {
                using (dbContext db = new dbContext())
                {
                    var GetCent = db.Database.SqlQuery<ReportForAll>("SELECT  dbo.ChronicBookTypes.BookType AS Row6, COUNT(BookNo) AS Row1 FROM dbo.ChronicsBooks   INNER JOIN  dbo.ChronicBookTypes ON dbo.ChronicsBooks.BookTypeId = dbo.ChronicBookTypes.Id  WHERE (BookDate BETWEEN '" + d_start.Value + "' and '" + d_end.Value + "')  and (dbo.ChronicsBooks.LocalityId = " + LocalityId + ") GROUP BY BookDate, BookType").ToList();

                    if (GetCent.Count > 0)
                    {

                        RPTChronicAll Rdet = new RPTChronicAll();
                        Rdet.DataSource = GetCent;
                        Rdet.Locality.Value = db.Localities.Where(p => p.Id == LocalityId).ToList()[0].LocalityName;
                        Rdet.StartDate.Value = d_start.Value.Date.ToShortDateString();
                        Rdet.EndDate.Value = d_end.Value.Date.ToShortDateString();
                        Rdet.ReportTitle.Value = RDUsers.Text;
                        Rdet.ReportٍSubject.Value = "نوع الدفتـــر";
                        Rdet.ReportٍSubject1.Value = "نوع الدفتـــر";
                        Rdet.Frequency.Value = "عدد الدفاتر المستخرجة";
                        Rdet.Frequency1.Value = "عدد الدفاتر المستخرجة";
                        RptiewChronics.ReportSource = Rdet;
                        RptiewChronics.RefreshReport();
                        RptiewChronics.Show();

                    }
                }
            }
        }

        private void RDUsers_CheckedChanged(object sender, EventArgs e)
        {
            if (RDUsers.Checked)
            {
                using (dbContext db = new dbContext())
                {
                    var GetCent = db.Database.SqlQuery<ReportForAll>("SELECT dbo.Users.FullName AS Row6, COUNT(dbo.ChronicsBooks.BookNo) AS Row1 FROM dbo.ChronicsBooks INNER JOIN dbo.Users ON dbo.ChronicsBooks.UserId = dbo.Users.Id   WHERE (dbo.ChronicsBooks.BookDate  BETWEEN '" + d_start.Value + "' and '" + d_end.Value + "')  and (dbo.ChronicsBooks.LocalityId = " + LocalityId + ") GROUP BY dbo.ChronicsBooks.BookDate, dbo.Users.FullName").ToList();
                    if (GetCent.Count > 0)
                    {

                        RPTChronicAll Rdet = new RPTChronicAll();
                        Rdet.DataSource = GetCent;
                        Rdet.Locality.Value = db.Localities.Where(p => p.Id == LocalityId).ToList()[0].LocalityName;
                        Rdet.StartDate.Value = d_start.Value.Date.ToShortDateString();
                        Rdet.EndDate.Value = d_end.Value.Date.ToShortDateString();
                        Rdet.ReportTitle.Value = RDUsers.Text;
                        Rdet.ReportٍSubject.Value = "اسم المستخدم";
                        Rdet.ReportٍSubject1.Value = "اسم المستخدم";
                        Rdet.Frequency.Value = "عدد الدفاتر المستخرجة";
                        Rdet.Frequency1.Value = "عدد الدفاتر المستخرجة";
                        RptiewChronics.ReportSource = Rdet;
                        RptiewChronics.RefreshReport();
                        RptiewChronics.Show();

                    }
                }
            }
        }
    }
}