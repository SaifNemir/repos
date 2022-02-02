﻿using System.Windows.Forms;

namespace MedicalServiceSystem.Reclaims
{
    partial class FrmMedicalGroup
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
            this.components = new System.ComponentModel.Container();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn1 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn2 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn3 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn4 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewImageColumn gridViewImageColumn1 = new Telerik.WinControls.UI.GridViewImageColumn();
            Telerik.WinControls.UI.GridViewImageColumn gridViewImageColumn2 = new Telerik.WinControls.UI.GridViewImageColumn();
            Telerik.WinControls.UI.GridViewCheckBoxColumn gridViewCheckBoxColumn1 = new Telerik.WinControls.UI.GridViewCheckBoxColumn();
            Telerik.WinControls.UI.TableViewDefinition tableViewDefinition1 = new Telerik.WinControls.UI.TableViewDefinition();
            this.GRDGroup = new Telerik.WinControls.UI.RadGridView();
            this.PictureBox1 = new System.Windows.Forms.PictureBox();
            this.ToolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.Button2 = new Telerik.WinControls.UI.RadButton();
            this.office2010BlueTheme1 = new Telerik.WinControls.Themes.Office2010BlueTheme();
            ((System.ComponentModel.ISupportInitialize)(this.GRDGroup)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GRDGroup.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Button2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // GRDGroup
            // 
            this.GRDGroup.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.GRDGroup.BackColor = System.Drawing.Color.LightSteelBlue;
            this.GRDGroup.Cursor = System.Windows.Forms.Cursors.Default;
            this.GRDGroup.Font = new System.Drawing.Font("Sakkal Majalla", 12F);
            this.GRDGroup.ForeColor = System.Drawing.Color.Black;
            this.GRDGroup.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.GRDGroup.Location = new System.Drawing.Point(-3, 51);
            // 
            // 
            // 
            this.GRDGroup.MasterTemplate.AllowAddNewRow = false;
            this.GRDGroup.MasterTemplate.AllowDeleteRow = false;
            gridViewTextBoxColumn1.EnableExpressionEditor = false;
            gridViewTextBoxColumn1.FieldName = "Id";
            gridViewTextBoxColumn1.HeaderText = "Column1";
            gridViewTextBoxColumn1.IsVisible = false;
            gridViewTextBoxColumn1.Name = "Id";
            gridViewTextBoxColumn1.ReadOnly = true;
            gridViewTextBoxColumn1.Width = 84;
            gridViewTextBoxColumn2.EnableExpressionEditor = false;
            gridViewTextBoxColumn2.HeaderText = "م";
            gridViewTextBoxColumn2.Name = "Serial";
            gridViewTextBoxColumn2.ReadOnly = true;
            gridViewTextBoxColumn2.Width = 43;
            gridViewTextBoxColumn3.EnableExpressionEditor = false;
            gridViewTextBoxColumn3.FieldName = "MainGroupEnglishName";
            gridViewTextBoxColumn3.HeaderText = "اسم المجموعة انجليزي";
            gridViewTextBoxColumn3.Name = "SerEName";
            gridViewTextBoxColumn3.ReadOnly = true;
            gridViewTextBoxColumn3.Width = 250;
            gridViewTextBoxColumn4.EnableExpressionEditor = false;
            gridViewTextBoxColumn4.FieldName = "MainGroupArabicName";
            gridViewTextBoxColumn4.HeaderText = "اسم المجموعة عربي";
            gridViewTextBoxColumn4.Name = "SerANAme";
            gridViewTextBoxColumn4.ReadOnly = true;
            gridViewTextBoxColumn4.Width = 250;
            gridViewImageColumn1.AllowFiltering = false;
            gridViewImageColumn1.EnableExpressionEditor = false;
            gridViewImageColumn1.HeaderText = "تعديل";
            gridViewImageColumn1.Name = "BtnEditing";
            gridViewImageColumn1.Width = 80;
            gridViewImageColumn2.AllowFiltering = false;
            gridViewImageColumn2.EnableExpressionEditor = false;
            gridViewImageColumn2.HeaderText = "تفعيل/إلغاء تفعيل";
            gridViewImageColumn2.Name = "BtnDeleting";
            gridViewImageColumn2.Width = 120;
            gridViewCheckBoxColumn1.EnableExpressionEditor = false;
            gridViewCheckBoxColumn1.FieldName = "IsEnabled";
            gridViewCheckBoxColumn1.HeaderText = "IsEnabled";
            gridViewCheckBoxColumn1.IsVisible = false;
            gridViewCheckBoxColumn1.MinWidth = 20;
            gridViewCheckBoxColumn1.Name = "IsEnabled";
            gridViewCheckBoxColumn1.ReadOnly = true;
            gridViewCheckBoxColumn1.Width = 70;
            this.GRDGroup.MasterTemplate.Columns.AddRange(new Telerik.WinControls.UI.GridViewDataColumn[] {
            gridViewTextBoxColumn1,
            gridViewTextBoxColumn2,
            gridViewTextBoxColumn3,
            gridViewTextBoxColumn4,
            gridViewImageColumn1,
            gridViewImageColumn2,
            gridViewCheckBoxColumn1});
            this.GRDGroup.MasterTemplate.EnableFiltering = true;
            this.GRDGroup.MasterTemplate.ViewDefinition = tableViewDefinition1;
            this.GRDGroup.Name = "GRDGroup";
            this.GRDGroup.ReadOnly = true;
            this.GRDGroup.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.GRDGroup.ShowGroupPanel = false;
            this.GRDGroup.Size = new System.Drawing.Size(800, 568);
            this.GRDGroup.TabIndex = 0;
            this.GRDGroup.ThemeName = "Office2010Blue";
            this.GRDGroup.VirtualMode = true;
            this.GRDGroup.CellFormatting += new Telerik.WinControls.UI.CellFormattingEventHandler(this.GRDGroup_CellFormatting);
            this.GRDGroup.CommandCellClick += new Telerik.WinControls.UI.CommandCellClickEventHandler(this.GRDGroup_CommandCellClick);
            // 
            // PictureBox1
            // 
            this.PictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.PictureBox1.Location = new System.Drawing.Point(798, -1);
            this.PictureBox1.Name = "PictureBox1";
            this.PictureBox1.Size = new System.Drawing.Size(87, 61);
            this.PictureBox1.TabIndex = 10;
            this.PictureBox1.TabStop = false;
            // 
            // Button2
            // 
            this.Button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Button2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Button2.Font = new System.Drawing.Font("Sakkal Majalla", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Button2.ImeMode = System.Windows.Forms.ImeMode.Katakana;
            this.Button2.Location = new System.Drawing.Point(638, -2);
            this.Button2.Name = "Button2";
            this.Button2.Size = new System.Drawing.Size(159, 47);
            this.Button2.TabIndex = 3;
            this.Button2.Text = "اضافة مجموعة جديدة";
            this.Button2.ThemeName = "Office2010Blue";
            this.ToolTip1.SetToolTip(this.Button2, "اضافة مجموعة للمستخدمين");
            this.Button2.Click += new System.EventHandler(this.Button2_Click);
            // 
            // FrmMedicalGroup
            // 
            this.BackColor = System.Drawing.Color.LightSteelBlue;
            this.ClientSize = new System.Drawing.Size(795, 620);
            this.Controls.Add(this.Button2);
            this.Controls.Add(this.GRDGroup);
            this.Font = new System.Drawing.Font("Sakkal Majalla", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "FrmMedicalGroup";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.Text = " اعدادات المجموعة الرئيسية للخدمة الطبية";
            this.ThemeName = "Office2010Blue";
            this.Load += new System.EventHandler(this.FrmGroup_Load);
            ((System.ComponentModel.ISupportInitialize)(this.GRDGroup.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GRDGroup)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Button2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        internal Telerik.WinControls.UI.RadGridView GRDGroup;
        internal PictureBox PictureBox1;
        internal ToolTip ToolTip1;
        internal Telerik.WinControls.UI.RadButton Button2;
        internal Telerik.WinControls.UI.GridViewTextBoxColumn Id;
        internal Telerik.WinControls.UI.GridViewTextBoxColumn Serial;
        internal Telerik.WinControls.UI.GridViewTextBoxColumn SerEName;
        internal Telerik.WinControls.UI.GridViewTextBoxColumn SerANAme;
        internal Telerik.WinControls.UI.GridViewImageColumn BtnEditing;
        internal Telerik.WinControls.UI.GridViewImageColumn BtnDeleting;
        internal Telerik.WinControls.UI.GridViewCheckBoxColumn IsEnabled;
        private Telerik.WinControls.Themes.Office2010BlueTheme office2010BlueTheme1;
        private static FrmMedicalGroup _Default;
        public static FrmMedicalGroup Default
        {
            get
            {
                if (_Default == null)
                    _Default = new FrmMedicalGroup();

                return _Default;
            }
        }
    }

}