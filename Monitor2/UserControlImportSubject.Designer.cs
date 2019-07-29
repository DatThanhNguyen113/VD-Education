namespace Monitor2
{
    partial class UserControlImportSubject
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
            this.components = new System.ComponentModel.Container();
            DevExpress.DataAccess.Sql.CustomSqlQuery customSqlQuery1 = new DevExpress.DataAccess.Sql.CustomSqlQuery();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UserControlImportSubject));
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButton2 = new DevExpress.XtraEditors.SimpleButton();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.sqlDataSource1 = new DevExpress.DataAccess.Sql.SqlDataSource(this.components);
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
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // simpleButton1
            // 
            this.simpleButton1.Appearance.ForeColor = System.Drawing.Color.Blue;
            this.simpleButton1.Appearance.Options.UseForeColor = true;
            this.simpleButton1.Dock = System.Windows.Forms.DockStyle.Top;
            this.simpleButton1.Location = new System.Drawing.Point(0, 0);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(800, 44);
            this.simpleButton1.TabIndex = 0;
            this.simpleButton1.Text = "Import Excel File";
            this.simpleButton1.Click += new System.EventHandler(this.simpleButton1_Click);
            // 
            // simpleButton2
            // 
            this.simpleButton2.Appearance.ForeColor = System.Drawing.Color.Blue;
            this.simpleButton2.Appearance.Options.UseForeColor = true;
            this.simpleButton2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.simpleButton2.Location = new System.Drawing.Point(0, 346);
            this.simpleButton2.Name = "simpleButton2";
            this.simpleButton2.Size = new System.Drawing.Size(800, 44);
            this.simpleButton2.TabIndex = 1;
            this.simpleButton2.Text = "Export To Excel File";
            this.simpleButton2.Click += new System.EventHandler(this.simpleButton2_Click);
            // 
            // gridControl1
            // 
            this.gridControl1.DataMember = "Query";
            this.gridControl1.DataSource = this.sqlDataSource1;
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.Location = new System.Drawing.Point(0, 44);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(800, 302);
            this.gridControl1.TabIndex = 2;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // sqlDataSource1
            // 
            this.sqlDataSource1.ConnectionName = "defaultConnection";
            this.sqlDataSource1.Name = "sqlDataSource1";
            customSqlQuery1.Name = "Query";
            customSqlQuery1.Sql = "select * from Subject";
            this.sqlDataSource1.Queries.AddRange(new DevExpress.DataAccess.Sql.SqlQuery[] {
            customSqlQuery1});
            this.sqlDataSource1.ResultSchemaSerializable = resources.GetString("sqlDataSource1.ResultSchemaSerializable");
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
            this.colSubjectTypeID});
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
            this.colCode.FieldName = "Code";
            this.colCode.Name = "colCode";
            this.colCode.Visible = true;
            this.colCode.VisibleIndex = 1;
            // 
            // colName
            // 
            this.colName.FieldName = "Name";
            this.colName.Name = "colName";
            this.colName.Visible = true;
            this.colName.VisibleIndex = 2;
            // 
            // colDescription
            // 
            this.colDescription.FieldName = "Description";
            this.colDescription.Name = "colDescription";
            this.colDescription.Visible = true;
            this.colDescription.VisibleIndex = 3;
            // 
            // colTotalCredits
            // 
            this.colTotalCredits.FieldName = "TotalCredits";
            this.colTotalCredits.Name = "colTotalCredits";
            this.colTotalCredits.Visible = true;
            this.colTotalCredits.VisibleIndex = 4;
            // 
            // colPracticeCredit
            // 
            this.colPracticeCredit.FieldName = "PracticeCredit";
            this.colPracticeCredit.Name = "colPracticeCredit";
            this.colPracticeCredit.Visible = true;
            this.colPracticeCredit.VisibleIndex = 5;
            // 
            // colTheoryCredit
            // 
            this.colTheoryCredit.FieldName = "TheoryCredit";
            this.colTheoryCredit.Name = "colTheoryCredit";
            this.colTheoryCredit.Visible = true;
            this.colTheoryCredit.VisibleIndex = 6;
            // 
            // colLessionNumber
            // 
            this.colLessionNumber.FieldName = "LessionNumber";
            this.colLessionNumber.Name = "colLessionNumber";
            this.colLessionNumber.Visible = true;
            this.colLessionNumber.VisibleIndex = 7;
            // 
            // colFinalEvaluationPercent
            // 
            this.colFinalEvaluationPercent.FieldName = "FinalEvaluationPercent";
            this.colFinalEvaluationPercent.Name = "colFinalEvaluationPercent";
            this.colFinalEvaluationPercent.Visible = true;
            this.colFinalEvaluationPercent.VisibleIndex = 8;
            // 
            // colSemiFinalEvaluationPercent
            // 
            this.colSemiFinalEvaluationPercent.FieldName = "SemiFinalEvaluationPercent";
            this.colSemiFinalEvaluationPercent.Name = "colSemiFinalEvaluationPercent";
            this.colSemiFinalEvaluationPercent.Visible = true;
            this.colSemiFinalEvaluationPercent.VisibleIndex = 9;
            // 
            // colDiligencePercent
            // 
            this.colDiligencePercent.FieldName = "DiligencePercent";
            this.colDiligencePercent.Name = "colDiligencePercent";
            this.colDiligencePercent.Visible = true;
            this.colDiligencePercent.VisibleIndex = 10;
            // 
            // colSubjectTypeID
            // 
            this.colSubjectTypeID.FieldName = "SubjectTypeID";
            this.colSubjectTypeID.Name = "colSubjectTypeID";
            this.colSubjectTypeID.Visible = true;
            this.colSubjectTypeID.VisibleIndex = 11;
            // 
            // UserControlImportSubject
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gridControl1);
            this.Controls.Add(this.simpleButton2);
            this.Controls.Add(this.simpleButton1);
            this.Name = "UserControlImportSubject";
            this.Size = new System.Drawing.Size(800, 390);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton simpleButton1;
        private DevExpress.XtraEditors.SimpleButton simpleButton2;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.DataAccess.Sql.SqlDataSource sqlDataSource1;
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
    }
}
