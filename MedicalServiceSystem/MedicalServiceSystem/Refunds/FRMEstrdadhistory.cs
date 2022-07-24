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
            if (defaultInstance == null)
                defaultInstance = this;
        }

        #region Default Instance

        private static FRMEstrdadhistory defaultInstance;

        /// <summary>
        /// Added by the VB.Net to C# Converter to support default instance behavour in C#
        /// </summary>
        public static FRMEstrdadhistory Default
        {
            get
            {
                if (defaultInstance == null)
                {
                    defaultInstance = new FRMEstrdadhistory();
                    defaultInstance.FormClosed += new FormClosedEventHandler(defaultInstance_FormClosed);
                }

                return defaultInstance;
            }
            set
            {
                defaultInstance = value;
            }
        }

        static void defaultInstance_FormClosed(object sender, FormClosedEventArgs e)
        {
            defaultInstance = null;
        }

        #endregion

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
