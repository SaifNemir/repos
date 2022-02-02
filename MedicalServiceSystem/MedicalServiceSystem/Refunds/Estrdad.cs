using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using Telerik.Reporting;
using Telerik.Reporting.Drawing;

namespace MedicalServiceSystem.Reclaims
{
    /// <summary>
    /// Summary description for Estrdad.
    /// </summary>
    public partial class Estrdad : Telerik.Reporting.Report
    {
        public Estrdad()
        {
            //
            // Required for telerik Reporting designer support
            //
            InitializeComponent();

            //
            // TODO: Add any constructor code after InitializeComponent call
            //
        }

        private void textBox35_ItemDataBound(object sender, EventArgs e)
        {
            MoneyPaiedWritten.Value = PLC.NumToStr(Convert.ToDouble(textBox35.Value));
        }
    }
}