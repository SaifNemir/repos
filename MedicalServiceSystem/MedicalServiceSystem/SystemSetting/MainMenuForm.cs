using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ModelDB;
using Telerik.WinControls.UI;
using MedicalServiceSystem.SystemSetting;
using MedicalServiceSystem.Reclaims;

namespace MedicalServiceSystem
{
    public partial class MainMenuForm : Telerik.WinControls.UI.RadRibbonForm
    {
        public MainMenuForm()
        {
            InitializeComponent();
            this.IsMdiContainer = true;

        }



        //private void AddPaysheet_Click(object sender, EventArgs e)
        //{
        //    PaysheetForm form = new PaysheetForm();
        //    form.MdiParent = this;
        //    form.WindowState = FormWindowState.Maximized;
        //    form.Show();



        //}

        //private void NewClient_Click(object sender, EventArgs e)
        //{
        //    ClientForm form = new ClientForm();
        //    form.MdiParent = this;
        //    form.WindowState = FormWindowState.Maximized;
        //    form.Show();
        //    //Forms.ClientShow();

        //}



        //private void NewContract_Click(object sender, EventArgs e)
        //{
        //    ContractForm form = new ContractForm();
        //    form.MdiParent = this;
        //    form.WindowState = FormWindowState.Maximized;
        //    form.Show();
        //}

        //private void NewCard_Click(object sender, EventArgs e)
        //{
        //    CardForm form = new CardForm();
        //    form.MdiParent = this;
        //    form.WindowState = FormWindowState.Maximized;
        //    form.Show();
        //}

        //private void NewSubSector_Click(object sender, EventArgs e)
        //{
        //    SubSectorForm form = new SubSectorForm();
        //    form.MdiParent = this;
        //    form.WindowState = FormWindowState.Maximized;
        //    form.Show();
        //}

        //private void NewArea_Click(object sender, EventArgs e)
        //{
        //    AreaForm form = new AreaForm();
        //    form.MdiParent = this;
        //    form.WindowState = FormWindowState.Maximized;
        //    form.Show();
        //}

        //private void Target_Click(object sender, EventArgs e)
        //{
        //    TargetForm form = new TargetForm();
        //    form.MdiParent = this;
        //    form.WindowState = FormWindowState.Maximized;
        //    form.Show();
        //}

        //private void PaysheetAccountingReviewBTN_Click(object sender, EventArgs e)
        //{
        //    PaysheetAccountReviewFRM form = new PaysheetAccountReviewFRM();
        //    form.MdiParent = this;
        //    form.WindowState = FormWindowState.Maximized;
        //    form.Show();
        //}

        //private void PaysheetReviewBTN_Click(object sender, EventArgs e)
        //{
        //    PaysheetReviewFRM form = new PaysheetReviewFRM();
        //    form.MdiParent = this;
        //    form.WindowState = FormWindowState.Maximized;
        //    form.Show();
        //}

        //private void reviewCardBTN_Click(object sender, EventArgs e)
        //{
        //    CardRevisionFrm form = new CardRevisionFrm();
        //    form.MdiParent = this;
        //    form.WindowState = FormWindowState.Maximized;
        //    form.Show();
        //}

        //private void printCardBTN_Click(object sender, EventArgs e)
        //{
        //    PrintCardFrm form = new PrintCardFrm();
        //    form.MdiParent = this;
        //    form.WindowState = FormWindowState.Maximized;
        //    form.Show();
        //}

        //private void radRibbonBarGroup10_Click(object sender, EventArgs e)
        //{

        //}

        //private void radButtonElement1_Click(object sender, EventArgs e)
        //{
        //    PaySheetStatusFRM.Default.ShowDialog();
        //}

        private void MainMenuForm_Load(object sender, EventArgs e)
        {
            using (dbContext db = new dbContext())
            {
               //nam.Text = LogFRM.Default.UserName.Text;


                string username =LoginForm .Default.FulName;
                if (username != "Admin")
                {
                  //  usernamelbl.Text = LoginForm.Default.FulName;
                    int UserId = LoginForm.Default.UserId;
                    var usp = (from uspr in db.UserPermissions
                               join us in db.Users on
                                   uspr.UserId equals us.Id
                               join frm in db.SysForms on uspr.FormId equals frm.Id
                               where us.Id == UserId
                               select new
                               {
                                   FormName = frm.FormName
                               }).ToList();
                    if (usp.Count > 0)
                    {
                        for (int i = 0; i <= usp.Count - 1; i++)
                        {
                            foreach (RibbonTab tab in radRibbonBar1.CommandTabs)
                            {
                                foreach (RadRibbonBarGroup buto in tab.Items)
                                {
                                    for (int j = 0; j <= buto.Items.Count - 1; j++)
                                    {

                                        // Interaction.MsgBox(usp[i].FormName.ToString());
                                        if (usp[i].FormName.ToString() == buto.Items[j].Name.ToString())
                                        {
                                            buto.Items[j].Enabled = true;
                                        }

                                    }
                                }


                            }
                        }
                    }
                    else
                    {
                        var ugp = (from ups in db.GroupPermissions
                                   join us in db.UserGroups on
                                       ups.GroupId equals us.Id
                                   join usr in db.Users on
                                       us.Id equals usr.GroupId
                                   join frm in db.SysForms on ups.FormId equals frm.Id
                                   where usr.Id == UserId
                                   select new
                                   {
                                       FormName = frm.FormName
                                   }).ToList();
                        //Interaction.MsgBox(usp.Count.ToString());
                        if (ugp.Count > 0)
                        {

                            for (int i = 0; i <= ugp.Count - 1; i++)
                            {
                                foreach (RibbonTab tab in radRibbonBar1.CommandTabs)
                                {
                                    foreach (RadRibbonBarGroup buto in tab.Items)
                                    {
                                        for (int j = 0; j <= buto.Items.Count - 1; j++)
                                        {

                                            // Interaction.MsgBox(usp[i].FormName.ToString());
                                            if (ugp[i].FormName.ToString() == buto.Items[j].Name.ToString())
                                            {
                                                buto.Items[j].Enabled = true;
                                            }

                                        }
                                    }


                                }
                            }
                        }
                    }
                }
                else
                {

                    foreach (RibbonTab tab in radRibbonBar1.CommandTabs)
                    {
                        foreach (RadRibbonBarGroup buto in tab.Items)
                        {
                            for (int j = 0; j <= buto.Items.Count - 1; j++)
                            {

                                // Interaction.MsgBox(usp[i].FormName.ToString());

                                buto.Items[j].Enabled = true;


                            }



                        }
                    }
                }
            }
        }

        private void FRMApproveMedicine_Click(object sender, EventArgs e)
        {
            FRMApproveMedicine form = new FRMApproveMedicine();
            form.MdiParent = this;
            form.WindowState = FormWindowState.Maximized;
            form.Show();
        }

        private void FrmAppMedicineTyp_Click(object sender, EventArgs e)
        {
            FrmAppMedicineTyp form = new FrmAppMedicineTyp();
            form.MdiParent = this;
            form.WindowState = FormWindowState.Maximized;
            form.Show();
        }

        private void FrmPharmacist_Click(object sender, EventArgs e)
        {
            FrmPharmacist form = new FrmPharmacist();
            form.MdiParent = this;
            form.WindowState = FormWindowState.Maximized;
            form.Show();
        }

        private void UserFRM_Click(object sender, EventArgs e)
        {
            UserFRM form = new UserFRM();
            form.MdiParent = this;
            form.WindowState = FormWindowState.Maximized;
            form.Show();
        }

        private void UserGroup_Click(object sender, EventArgs e)
        {
            UserGroupFRM form = new UserGroupFRM();
            form.MdiParent = this;
            form.WindowState = FormWindowState.Maximized;
            form.Show();
        }

        private void UserPermissionsFRM_Click(object sender, EventArgs e)
        {
            UserPermissionsFRM form = new UserPermissionsFRM();
            form.MdiParent = this;
            form.WindowState = FormWindowState.Maximized;
            form.Show();
        }

        private void GroupPermissionsFRM_Click(object sender, EventArgs e)
        {
            GroupPermissionsFRM form = new GroupPermissionsFRM();
            form.MdiParent = this;
            form.WindowState = FormWindowState.Maximized;
            form.Show();
        }

        private void CompanyConfig_Click(object sender, EventArgs e)
        {
            CompanyConfig form = new CompanyConfig();
            form.MdiParent = this;
            form.WindowState = FormWindowState.Maximized;
            form.Show();
        }

        private void ChangePassFrm_Click(object sender, EventArgs e)
        {
            ChangePassFrm form = new ChangePassFrm();
            form.MdiParent = this;
            form.WindowState = FormWindowState.Maximized;
            form.Show();
        }

        private void RadButtonElement7_Click(object sender, EventArgs e)
        {
            FrmChronics form = new FrmChronics();
            form.MdiParent = this;
            form.WindowState = FormWindowState.Maximized;
            form.Show();
        }

        private void FRMBookInfo_Click(object sender, EventArgs e)
        {
            FRMBookInfo form = new FRMBookInfo();
            form.MdiParent = this;
            form.WindowState = FormWindowState.Maximized;
            form.Show();
        }

        private void FRMreportChronics_Click(object sender, EventArgs e)
        {
            FRMreportChronics form = new FRMreportChronics();
            form.MdiParent = this;
            form.WindowState = FormWindowState.Maximized;
            form.Show();
        }
    }
}
