namespace Monitor2
{
    partial class UserControlClassDetails
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.textEdit1 = new DevExpress.XtraEditors.TextEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.panelControl3 = new DevExpress.XtraEditors.PanelControl();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDescription = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTotalCredits = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPracticeCredit = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTheoryCredit = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLessionNumber = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFinalEvaluationPercent = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSemiFinalEvaluationPercent = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDiligencePercent = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSubjectTypeID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSpecializeID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPiority = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl3)).BeginInit();
            this.panelControl3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.simpleButton1);
            this.panelControl1.Controls.Add(this.comboBox1);
            this.panelControl1.Controls.Add(this.textEdit1);
            this.panelControl1.Controls.Add(this.labelControl1);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(752, 59);
            this.panelControl1.TabIndex = 0;
            // 
            // simpleButton1
            // 
            this.simpleButton1.Location = new System.Drawing.Point(448, 14);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(200, 31);
            this.simpleButton1.TabIndex = 3;
            this.simpleButton1.Text = "Thêm Học Phần";
            this.simpleButton1.Click += new System.EventHandler(this.simpleButton1_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(156, 20);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(213, 21);
            this.comboBox1.TabIndex = 2;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // textEdit1
            // 
            this.textEdit1.Location = new System.Drawing.Point(375, 21);
            this.textEdit1.Name = "textEdit1";
            this.textEdit1.Size = new System.Drawing.Size(67, 20);
            this.textEdit1.TabIndex = 1;
            this.textEdit1.Visible = false;
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(79, 23);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(71, 13);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "Danh Sách Lớp";
            // 
            // panelControl3
            // 
            this.panelControl3.Controls.Add(this.gridControl1);
            this.panelControl3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl3.Location = new System.Drawing.Point(0, 59);
            this.panelControl3.Name = "panelControl3";
            this.panelControl3.Size = new System.Drawing.Size(752, 477);
            this.panelControl3.TabIndex = 1;
            // 
            // gridControl1
            // 
            this.gridControl1.DataMember = "Query";
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.Location = new System.Drawing.Point(2, 2);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(748, 473);
            this.gridControl1.TabIndex = 2;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colID,
            this.colCode,
            this.colName,
            this.colDescription,
            this.colTotalCredits,
            this.colPracticeCredit,
            this.colTheoryCredit,
            this.colLessionNumber,
            this.colFinalEvaluationPercent,
            this.colSemiFinalEvaluationPercent,
            this.colDiligencePercent,
            this.colSubjectTypeID,
            this.colSpecializeID,
            this.colPiority});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            // 
            // colID
            // 
            this.colID.FieldName = "ID";
            this.colID.Name = "colID";
            this.colID.Visible = true;
            this.colID.VisibleIndex = 0;
            // 
            // colCode
            // 
            this.colCode.Caption = "Mã Môn Học";
            this.colCode.FieldName = "Code";
            this.colCode.Name = "colCode";
            this.colCode.Visible = true;
            this.colCode.VisibleIndex = 1;
            // 
            // colName
            // 
            this.colName.Caption = "Môn Học";
            this.colName.FieldName = "Name";
            this.colName.Name = "colName";
            this.colName.Visible = true;
            this.colName.VisibleIndex = 2;
            // 
            // colDescription
            // 
            this.colDescription.Caption = "Mô Tả";
            this.colDescription.FieldName = "Description";
            this.colDescription.Name = "colDescription";
            this.colDescription.Visible = true;
            this.colDescription.VisibleIndex = 3;
            // 
            // colTotalCredits
            // 
            this.colTotalCredits.Caption = "Tổng Tín Chỉ";
            this.colTotalCredits.FieldName = "TotalCredits";
            this.colTotalCredits.Name = "colTotalCredits";
            this.colTotalCredits.Visible = true;
            this.colTotalCredits.VisibleIndex = 4;
            // 
            // colPracticeCredit
            // 
            this.colPracticeCredit.Caption = "Thực Hành";
            this.colPracticeCredit.FieldName = "PracticeCredit";
            this.colPracticeCredit.Name = "colPracticeCredit";
            this.colPracticeCredit.Visible = true;
            this.colPracticeCredit.VisibleIndex = 5;
            // 
            // colTheoryCredit
            // 
            this.colTheoryCredit.Caption = "Lý Thuyết";
            this.colTheoryCredit.FieldName = "TheoryCredit";
            this.colTheoryCredit.Name = "colTheoryCredit";
            this.colTheoryCredit.Visible = true;
            this.colTheoryCredit.VisibleIndex = 6;
            // 
            // colLessionNumber
            // 
            this.colLessionNumber.Caption = "Số Tiết Học";
            this.colLessionNumber.FieldName = "LessionNumber";
            this.colLessionNumber.Name = "colLessionNumber";
            this.colLessionNumber.Visible = true;
            this.colLessionNumber.VisibleIndex = 7;
            // 
            // colFinalEvaluationPercent
            // 
            this.colFinalEvaluationPercent.Caption = "Phần Trăm Điểm Cuối Kỳ";
            this.colFinalEvaluationPercent.FieldName = "FinalEvaluationPercent";
            this.colFinalEvaluationPercent.Name = "colFinalEvaluationPercent";
            this.colFinalEvaluationPercent.Visible = true;
            this.colFinalEvaluationPercent.VisibleIndex = 8;
            // 
            // colSemiFinalEvaluationPercent
            // 
            this.colSemiFinalEvaluationPercent.Caption = "Phần Trăm Điểm Giữa Kỳ";
            this.colSemiFinalEvaluationPercent.FieldName = "SemiFinalEvaluationPercent";
            this.colSemiFinalEvaluationPercent.Name = "colSemiFinalEvaluationPercent";
            this.colSemiFinalEvaluationPercent.Visible = true;
            this.colSemiFinalEvaluationPercent.VisibleIndex = 9;
            // 
            // colDiligencePercent
            // 
            this.colDiligencePercent.Caption = "Chuyên Cần";
            this.colDiligencePercent.FieldName = "DiligencePercent";
            this.colDiligencePercent.Name = "colDiligencePercent";
            this.colDiligencePercent.Visible = true;
            this.colDiligencePercent.VisibleIndex = 10;
            // 
            // colSubjectTypeID
            // 
            this.colSubjectTypeID.Caption = "Loại Môn Hoc";
            this.colSubjectTypeID.FieldName = "SubjectTypeID";
            this.colSubjectTypeID.Name = "colSubjectTypeID";
            this.colSubjectTypeID.Visible = true;
            this.colSubjectTypeID.VisibleIndex = 11;
            // 
            // colSpecializeID
            // 
            this.colSpecializeID.Caption = "Mã Khoa";
            this.colSpecializeID.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colSpecializeID.FieldName = "SpecializeID";
            this.colSpecializeID.Name = "colSpecializeID";
            this.colSpecializeID.Visible = true;
            this.colSpecializeID.VisibleIndex = 12;
            // 
            // colPiority
            // 
            this.colPiority.Caption = "Phân Loại";
            this.colPiority.FieldName = "Piority";
            this.colPiority.Name = "colPiority";
            this.colPiority.Visible = true;
            this.colPiority.VisibleIndex = 13;
            // 
            // UserControlClassDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panelControl3);
            this.Controls.Add(this.panelControl1);
            this.Name = "UserControlClassDetails";
            this.Size = new System.Drawing.Size(752, 536);
            this.Load += new System.EventHandler(this.UserControlClassDetails_Load);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl3)).EndInit();
            this.panelControl3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
        private System.Windows.Forms.ComboBox comboBox1;
        private DevExpress.XtraEditors.TextEdit textEdit1;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.PanelControl panelControl3;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn colID;
        private DevExpress.XtraGrid.Columns.GridColumn colCode;
        private DevExpress.XtraGrid.Columns.GridColumn colName;
        private DevExpress.XtraGrid.Columns.GridColumn colDescription;
        private DevExpress.XtraGrid.Columns.GridColumn colTotalCredits;
        private DevExpress.XtraGrid.Columns.GridColumn colPracticeCredit;
        private DevExpress.XtraGrid.Columns.GridColumn colTheoryCredit;
        private DevExpress.XtraGrid.Columns.GridColumn colLessionNumber;
        private DevExpress.XtraGrid.Columns.GridColumn colFinalEvaluationPercent;
        private DevExpress.XtraGrid.Columns.GridColumn colSemiFinalEvaluationPercent;
        private DevExpress.XtraGrid.Columns.GridColumn colDiligencePercent;
        private DevExpress.XtraGrid.Columns.GridColumn colSubjectTypeID;
        private DevExpress.XtraGrid.Columns.GridColumn colPiority;
        private DevExpress.XtraGrid.Columns.GridColumn colSpecializeID;
    }
}
