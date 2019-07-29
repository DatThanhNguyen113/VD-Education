namespace Monitor2
{
    partial class MusterDetail
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.defaultLookAndFeel1 = new DevExpress.LookAndFeel.DefaultLookAndFeel(this.components);
            this.gcMusterDetail = new DevExpress.XtraGrid.GridControl();
            this.gvMusterDetail = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gcolID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcolName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcolStatus = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemCheckEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            ((System.ComponentModel.ISupportInitialize)(this.gcMusterDetail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvMusterDetail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).BeginInit();
            this.SuspendLayout();
            // 
            // gcMusterDetail
            // 
            this.gcMusterDetail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcMusterDetail.Location = new System.Drawing.Point(0, 0);
            this.gcMusterDetail.MainView = this.gvMusterDetail;
            this.gcMusterDetail.Name = "gcMusterDetail";
            this.gcMusterDetail.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemCheckEdit1});
            this.gcMusterDetail.Size = new System.Drawing.Size(792, 404);
            this.gcMusterDetail.TabIndex = 0;
            this.gcMusterDetail.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvMusterDetail});
            // 
            // gvMusterDetail
            // 
            this.gvMusterDetail.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gcolID,
            this.gcolName,
            this.gcolStatus});
            this.gvMusterDetail.GridControl = this.gcMusterDetail;
            this.gvMusterDetail.Name = "gvMusterDetail";
            // 
            // gcolID
            // 
            this.gcolID.Caption = "STT";
            this.gcolID.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gcolID.FieldName = "ID";
            this.gcolID.Name = "gcolID";
            this.gcolID.OptionsColumn.AllowEdit = false;
            this.gcolID.Visible = true;
            this.gcolID.VisibleIndex = 0;
            // 
            // gcolName
            // 
            this.gcolName.Caption = "Tên HS";
            this.gcolName.FieldName = "StudentName";
            this.gcolName.Name = "gcolName";
            this.gcolName.OptionsColumn.AllowEdit = false;
            this.gcolName.Visible = true;
            this.gcolName.VisibleIndex = 1;
            // 
            // gcolStatus
            // 
            this.gcolStatus.Caption = "Tình trạng";
            this.gcolStatus.ColumnEdit = this.repositoryItemCheckEdit1;
            this.gcolStatus.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gcolStatus.FieldName = "JoinStatus";
            this.gcolStatus.Name = "gcolStatus";
            this.gcolStatus.OptionsColumn.AllowEdit = false;
            this.gcolStatus.Visible = true;
            this.gcolStatus.VisibleIndex = 2;
            // 
            // repositoryItemCheckEdit1
            // 
            this.repositoryItemCheckEdit1.AutoHeight = false;
            this.repositoryItemCheckEdit1.Name = "repositoryItemCheckEdit1";
            this.repositoryItemCheckEdit1.ValueChecked = 1;
            this.repositoryItemCheckEdit1.ValueUnchecked = 0;
            // 
            // MusterDetail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(792, 404);
            this.Controls.Add(this.gcMusterDetail);
            this.Name = "MusterDetail";
            this.Text = "Chi tiết điểm danh";
            this.Load += new System.EventHandler(this.MusterDetail_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gcMusterDetail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvMusterDetail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.LookAndFeel.DefaultLookAndFeel defaultLookAndFeel1;
        private DevExpress.XtraGrid.GridControl gcMusterDetail;
        private DevExpress.XtraGrid.Views.Grid.GridView gvMusterDetail;
        private DevExpress.XtraGrid.Columns.GridColumn gcolID;
        private DevExpress.XtraGrid.Columns.GridColumn gcolName;
        private DevExpress.XtraGrid.Columns.GridColumn gcolStatus;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEdit1;
    }
}