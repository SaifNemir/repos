using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;

namespace MedicalServiceSystem.Reclaims
{
    public partial class FRMEstrdadhistory : Telerik.WinControls.UI.RadForm
    {
        public FRMEstrdadhistory()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Grid_service_RowFormatting(object sender, Telerik.WinControls.UI.RowFormattingEventArgs e)
        {
            if (Grid_service.RowCount > 0)
            {
                //foreach (var dr in GrdFulPaysheet.Rows)
                //{
                if (e.RowElement.RowInfo.Cells["column1"].Value.ToString() == "الاسترداد")
                {
                    e.RowElement.DrawFill = true;
                    e.RowElement.BackColor = Color.LightBlue;
                }
                else
                {
                    e.RowElement.DrawFill = true;
                    e.RowElement.BackColor = Color.White;
                }
            }
        }

        private void FRMEstrdadhistory_Load(object sender, EventArgs e)
        {

        }
    }
}
