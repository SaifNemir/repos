using Telerik.WinControls.UI;

namespace MedicalServiceSystem.Reclaims
{
    partial class FRMpatienthistory
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }



        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            Telerik.WinControls.UI.GridViewCommandColumn gridViewCommandColumn1 = new Telerik.WinControls.UI.GridViewCommandColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn1 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn2 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn3 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn4 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn5 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn6 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn7 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn8 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn9 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn10 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn11 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn12 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn13 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn14 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.TableViewDefinition tableViewDefinition1 = new Telerik.WinControls.UI.TableViewDefinition();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn15 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn16 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn17 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn18 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.TableViewDefinition tableViewDefinition2 = new Telerik.WinControls.UI.TableViewDefinition();
            this.Grid_service = new Telerik.WinControls.UI.RadGridView();
            this.grid_transfer = new Telerik.WinControls.UI.RadGridView();
            this.Button1 = new Telerik.WinControls.UI.RadButton();
            this.Label1 = new Telerik.WinControls.UI.RadLabel();
            this.Totals = new Telerik.WinControls.UI.RadTextBox();
            this.office2010BlueTheme1 = new Telerik.WinControls.Themes.Office2010BlueTheme();
            ((System.ComponentModel.ISupportInitialize)(this.Grid_service)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Grid_service.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grid_transfer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grid_transfer.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Button1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Totals)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // Grid_service
            // 
            this.Grid_service.AutoScroll = true;
            this.Grid_service.BackColor = System.Drawing.Color.White;
            this.Grid_service.Cursor = System.Windows.Forms.Cursors.Default;
            this.Grid_service.Font = new System.Drawing.Font("Sakkal Majalla", 12F);
            this.Grid_service.ForeColor = System.Drawing.Color.Black;
            this.Grid_service.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.Grid_service.Location = new System.Drawing.Point(0, 0);
            this.Grid_service.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            // 
            // 
            // 
            this.Grid_service.MasterTemplate.AllowAddNewRow = false;
            this.Grid_service.MasterTemplate.AllowDeleteRow = false;
            gridViewCommandColumn1.HeaderText = "عرض";
            gridViewCommandColumn1.Name = "Show";
            gridViewTextBoxColumn1.DataType = typeof(int);
            gridViewTextBoxColumn1.EnableExpressionEditor = false;
            gridViewTextBoxColumn1.HeaderText = "م";
            gridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1";
            gridViewTextBoxColumn2.EnableExpressionEditor = false;
            gridViewTextBoxColumn2.FieldName = "ReclaimNo";
            gridViewTextBoxColumn2.HeaderText = "رقم المعاملة";
            gridViewTextBoxColumn2.IsVisible = false;
            gridViewTextBoxColumn2.Name = "ReclaimNo";
            gridViewTextBoxColumn2.Width = 78;
            gridViewTextBoxColumn3.FieldName = "ApproveCode";
            gridViewTextBoxColumn3.HeaderText = "كود التصديق";
            gridViewTextBoxColumn3.Name = "ApproveCode";
            gridViewTextBoxColumn3.Width = 120;
            gridViewTextBoxColumn4.EnableExpressionEditor = false;
            gridViewTextBoxColumn4.FieldName = "ServiceName";
            gridViewTextBoxColumn4.HeaderText = "الخدمة";
            gridViewTextBoxColumn4.Name = "ServiceName";
            gridViewTextBoxColumn4.Width = 250;
            gridViewTextBoxColumn5.FieldName = "Quantity";
            gridViewTextBoxColumn5.HeaderText = "المطلوب";
            gridViewTextBoxColumn5.Name = "Quantity";
            gridViewTextBoxColumn5.Width = 60;
            gridViewTextBoxColumn6.FieldName = "ApprovedQuantity";
            gridViewTextBoxColumn6.HeaderText = "المصدق";
            gridViewTextBoxColumn6.Name = "ApprovedQuantity";
            gridViewTextBoxColumn6.Width = 60;
            gridViewTextBoxColumn7.EnableExpressionEditor = false;
            gridViewTextBoxColumn7.FieldName = "Cost";
            gridViewTextBoxColumn7.HeaderText = "التكلفة";
            gridViewTextBoxColumn7.Name = "ReclaimCost";
            gridViewTextBoxColumn7.ReadOnly = true;
            gridViewTextBoxColumn7.Width = 78;
            gridViewTextBoxColumn8.DataType = typeof(System.DateTime);
            gridViewTextBoxColumn8.EnableExpressionEditor = false;
            gridViewTextBoxColumn8.FieldName = "ReclaimDate";
            gridViewTextBoxColumn8.HeaderText = "التاريخ";
            gridViewTextBoxColumn8.Name = "ReclaimDate";
            gridViewTextBoxColumn8.ReadOnly = true;
            gridViewTextBoxColumn8.Width = 100;
            gridViewTextBoxColumn9.FieldName = "UserName";
            gridViewTextBoxColumn9.HeaderText = "الطبيب";
            gridViewTextBoxColumn9.Name = "UserName";
            gridViewTextBoxColumn9.Width = 120;
            gridViewTextBoxColumn10.FieldName = "System";
            gridViewTextBoxColumn10.HeaderText = "النظام";
            gridViewTextBoxColumn10.Name = "column1";
            gridViewTextBoxColumn10.Width = 80;
            gridViewTextBoxColumn11.FieldName = "RequestParty";
            gridViewTextBoxColumn11.HeaderText = "الجهة الطالبة";
            gridViewTextBoxColumn11.Name = "RequestParty";
            gridViewTextBoxColumn11.Width = 150;
            gridViewTextBoxColumn12.FieldName = "ExcuteParty";
            gridViewTextBoxColumn12.HeaderText = "الجهة المنفذة";
            gridViewTextBoxColumn12.Name = "ExcuteParty";
            gridViewTextBoxColumn12.Width = 150;
            gridViewTextBoxColumn13.FieldName = "Atachment";
            gridViewTextBoxColumn13.HeaderText = "ملاحظات";
            gridViewTextBoxColumn13.Name = "Atachment";
            gridViewTextBoxColumn13.Width = 120;
            gridViewTextBoxColumn14.FieldName = "Id";
            gridViewTextBoxColumn14.HeaderText = "column2";
            gridViewTextBoxColumn14.IsVisible = false;
            gridViewTextBoxColumn14.Name = "Id";
            this.Grid_service.MasterTemplate.Columns.AddRange(new Telerik.WinControls.UI.GridViewDataColumn[] {
            gridViewCommandColumn1,
            gridViewTextBoxColumn1,
            gridViewTextBoxColumn2,
            gridViewTextBoxColumn3,
            gridViewTextBoxColumn4,
            gridViewTextBoxColumn5,
            gridViewTextBoxColumn6,
            gridViewTextBoxColumn7,
            gridViewTextBoxColumn8,
            gridViewTextBoxColumn9,
            gridViewTextBoxColumn10,
            gridViewTextBoxColumn11,
            gridViewTextBoxColumn12,
            gridViewTextBoxColumn13,
            gridViewTextBoxColumn14});
            this.Grid_service.MasterTemplate.EnableFiltering = true;
            this.Grid_service.MasterTemplate.ViewDefinition = tableViewDefinition1;
            this.Grid_service.Name = "Grid_service";
            this.Grid_service.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Grid_service.ShowGroupPanel = false;
            this.Grid_service.Size = new System.Drawing.Size(1294, 538);
            this.Grid_service.TabIndex = 24;
            this.Grid_service.ThemeName = "Office2010Blue";
            this.Grid_service.RowFormatting += new Telerik.WinControls.UI.RowFormattingEventHandler(this.Grid_service_RowFormatting);
            this.Grid_service.CommandCellClick += new Telerik.WinControls.UI.CommandCellClickEventHandler(this.Grid_service_CommandCellClick);
            // 
            // grid_transfer
            // 
            this.grid_transfer.Location = new System.Drawing.Point(6, 83);
            this.grid_transfer.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            // 
            // 
            // 
            this.grid_transfer.MasterTemplate.AllowAddNewRow = false;
            this.grid_transfer.MasterTemplate.AllowDeleteRow = false;
            gridViewTextBoxColumn15.HeaderText = "م";
            gridViewTextBoxColumn15.Name = "Column5";
            gridViewTextBoxColumn15.ReadOnly = true;
            gridViewTextBoxColumn16.HeaderText = "رقم الخدمة";
            gridViewTextBoxColumn16.Name = "DataGridViewTextBoxColumn5";
            gridViewTextBoxColumn16.ReadOnly = true;
            gridViewTextBoxColumn16.Width = 250;
            gridViewTextBoxColumn17.HeaderText = "التكلفة";
            gridViewTextBoxColumn17.Name = "Column6";
            gridViewTextBoxColumn17.ReadOnly = true;
            gridViewTextBoxColumn17.Width = 200;
            gridViewTextBoxColumn18.HeaderText = "التاريخ";
            gridViewTextBoxColumn18.Name = "DataGridViewTextBoxColumn6";
            gridViewTextBoxColumn18.ReadOnly = true;
            gridViewTextBoxColumn18.Width = 150;
            this.grid_transfer.MasterTemplate.Columns.AddRange(new Telerik.WinControls.UI.GridViewDataColumn[] {
            gridViewTextBoxColumn15,
            gridViewTextBoxColumn16,
            gridViewTextBoxColumn17,
            gridViewTextBoxColumn18});
            this.grid_transfer.MasterTemplate.ViewDefinition = tableViewDefinition2;
            this.grid_transfer.Name = "grid_transfer";
            this.grid_transfer.ReadOnly = true;
            this.grid_transfer.Size = new System.Drawing.Size(887, 455);
            this.grid_transfer.TabIndex = 25;
            // 
            // Button1
            // 
            this.Button1.Font = new System.Drawing.Font("Sakkal Majalla", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Button1.Image = global::MedicalServiceSystem.Properties.Resources.icons8_logout_rounded_left_32;
            this.Button1.Location = new System.Drawing.Point(13, 542);
            this.Button1.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.Button1.Name = "Button1";
            this.Button1.Size = new System.Drawing.Size(183, 31);
            this.Button1.TabIndex = 26;
            this.Button1.Text = "رجوع إلى الشاشة السابقة";
            this.Button1.TextAlignment = System.Drawing.ContentAlignment.MiddleRight;
            this.Button1.ThemeName = "Office2010Blue";
            this.Button1.Click += new System.EventHandler(this.Button1_Click);
            // 
            // Label1
            // 
            this.Label1.BackColor = System.Drawing.Color.Transparent;
            this.Label1.Font = new System.Drawing.Font("Sakkal Majalla", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label1.ForeColor = System.Drawing.Color.Maroon;
            this.Label1.Location = new System.Drawing.Point(446, 547);
            this.Label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(84, 31);
            this.Label1.TabIndex = 29;
            this.Label1.Text = "اجمـــــــالي المبلغ";
            this.Label1.TextAlignment = System.Drawing.ContentAlignment.TopRight;
            this.Label1.ThemeName = "Office2010Blue";
            // 
            // Totals
            // 
            this.Totals.Font = new System.Drawing.Font("Sakkal Majalla", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Totals.Location = new System.Drawing.Point(256, 544);
            this.Totals.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.Totals.Name = "Totals";
            this.Totals.ReadOnly = true;
            this.Totals.Size = new System.Drawing.Size(167, 32);
            this.Totals.TabIndex = 28;
            this.Totals.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.Totals.ThemeName = "Office2010Blue";
            // 
            // FRMpatienthistory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1292, 579);
            this.Controls.Add(this.Label1);
            this.Controls.Add(this.Totals);
            this.Controls.Add(this.Button1);
            this.Controls.Add(this.Grid_service);
            this.Controls.Add(this.grid_transfer);
            this.Font = new System.Drawing.Font("Sakkal Majalla", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(6);
            this.MaximizeBox = false;
            this.Name = "FRMpatienthistory";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "";
            this.ThemeName = "Office2010Blue";
            this.Load += new System.EventHandler(this.FRMpatienthistory_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Grid_service.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Grid_service)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grid_transfer.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grid_transfer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Button1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Label1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Totals)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        internal Telerik.WinControls.UI.RadGridView Grid_service;
        internal Telerik.WinControls.UI.RadGridView grid_transfer;
        internal Telerik.WinControls.UI.RadButton Button1;
        internal Telerik.WinControls.UI.GridViewTextBoxColumn Column5;
        internal Telerik.WinControls.UI.GridViewTextBoxColumn DataGridViewTextBoxColumn5;
        internal Telerik.WinControls.UI.GridViewTextBoxColumn Column6;
        internal Telerik.WinControls.UI.GridViewTextBoxColumn DataGridViewTextBoxColumn6;
        internal Telerik.WinControls.UI.GridViewTextBoxColumn DataGridViewTextBoxColumn1;
        internal Telerik.WinControls.UI.GridViewTextBoxColumn Column8;
        internal Telerik.WinControls.UI.GridViewTextBoxColumn DataGridViewTextBoxColumn2;
        internal Telerik.WinControls.UI.GridViewTextBoxColumn Column7;
        internal Telerik.WinControls.UI.GridViewTextBoxColumn Column9;
        internal Telerik.WinControls.UI.RadLabel Label1;
        internal Telerik.WinControls.UI.RadTextBox Totals;
        private Telerik.WinControls.Themes.Office2010BlueTheme office2010BlueTheme1;

        //private static FRMpatienthistory _Default;
        //public static FRMpatienthistory Default
        //{
        //    get
        //    {
        //        if (_Default == null)
        //            _Default = new FRMpatienthistory();

        //        return _Default;
        //    }
        //}
    }

}