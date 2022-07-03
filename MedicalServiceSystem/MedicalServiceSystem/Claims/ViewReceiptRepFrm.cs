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

namespace MedicalServiceSystem.Claims
{
    public partial class ViewReceiptRepFrm : Telerik.WinControls.UI.RadForm
    {
        public ViewReceiptRepFrm()
        {
            InitializeComponent();
        }
        public int _RecId = 0;
        private void ViewReceiptRepFrm_Load(object sender, EventArgs e)
        {
            dbContext db = new dbContext();
            var q = db.ClmReceiptClaimsDet.Where(p => p.RowStatus != RowStatus.Deleted && p.Status == Status.Active && p.ReceiptId == _RecId)
                .Select(p => new
                {
                    MedFile = 0,
                    MedCount = 0,
                    MedCost = 0,
                    MedVisit = 0,
                    DawaFile = p.CountOfBoxFile,
                    DawaCount = p.CountOfOrneks,
                    DawaCost = p.TotalOfClaims,
                    DawaVisit= p.CountOfOrneks,
                    FileName = p.FileName,
                    CenterName = p.ClmReceiptClaims.CenterInfo.CenterName,
                    Sorted = db.ClmSortedDeg .Where (s=> s.Id== p.ClmReceiptClaims.Sorted).Select(s=>s.Name).FirstOrDefault (),
                    Entered = db.ClmSortedDeg.Where(s => s.Id == p.ClmReceiptClaims.DataEntery).Select(s => s.Name).FirstOrDefault() ,
                    ReceiptDate = p.ClmReceiptClaims.ReceiptDate,
                    TimeIn = p.ClmReceiptClaims.TimeIn,
                    TimeOut = p.ClmReceiptClaims.TimeOut,
                    NextDate = p.ClmReceiptClaims.NextDate,
                    ErrorCount = 0,
                    ErrorPercent = 0,
                    NextTime = p.ClmReceiptClaims.NextDate,
                    ContactName = p.ClmReceiptClaims.ContactName,
                    TellNo = p.ClmReceiptClaims.ContactTell
                }) .ToList();
            if (q.Count >0)
            {
                Claims.ClmReceiptReport rep = new ClmReceiptReport();
                rep.DataSource = q;
                reportViewer1.ReportSource = rep;
                reportViewer1.RefreshReport();
            }
            
        }
    }
}
