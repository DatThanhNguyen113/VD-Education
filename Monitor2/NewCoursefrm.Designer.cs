namespace Monitor2
{
    partial class NewCoursefrm
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
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.gcClass = new DevExpress.XtraGrid.GridControl();
            this.gvClass = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gcolClassCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcolClassName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcolStatus = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemCheckEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.groupControl2 = new DevExpress.XtraEditors.GroupControl();
            this.cbxEndWeek = new DevExpress.XtraEditors.ComboBoxEdit();
            this.cbxStartWeek = new DevExpress.XtraEditors.ComboBoxEdit();
            this.dpEnđate = new DevExpress.XtraEditors.DateEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.dpStartDate = new DevExpress.XtraEditors.DateEdit();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.groupControl3 = new DevExpress.XtraEditors.GroupControl();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.ckThursday = new DevExpress.XtraEditors.CheckEdit();
            this.ckSunday = new DevExpress.XtraEditors.CheckEdit();
            this.ckMonday = new DevExpress.XtraEditors.CheckEdit();
            this.ckSaturday = new DevExpress.XtraEditors.CheckEdit();
            this.ckTuesday = new DevExpress.XtraEditors.CheckEdit();
            this.ckFriday = new DevExpress.XtraEditors.CheckEdit();
            this.ckWednesday = new DevExpress.XtraEditors.CheckEdit();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.btnOK = new DevExpress.XtraEditors.SimpleButton();
            this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
            this.btnRefesh = new DevExpress.XtraEditors.SimpleButton();
            this.groupControl8 = new DevExpress.XtraEditors.GroupControl();
            this.lbTeacher = new DevExpress.XtraEditors.LabelControl();
            this.lbSubjectName = new DevExpress.XtraEditors.LabelControl();
            this.lbSubjectCode = new DevExpress.XtraEditors.LabelControl();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcClass)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvClass)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).BeginInit();
            this.groupControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cbxEndWeek.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbxStartWeek.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dpEnđate.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dpEnđate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dpStartDate.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dpStartDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl3)).BeginInit();
            this.groupControl3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ckThursday.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ckSunday.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ckMonday.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ckSaturday.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ckTuesday.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ckFriday.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ckWednesday.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl8)).BeginInit();
            this.groupControl8.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.gcClass);
            this.groupControl1.Location = new System.Drawing.Point(12, 57);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(582, 131);
            this.groupControl1.TabIndex = 0;
            this.groupControl1.Text = "Đối tượng";
            // 
            // gcClass
            // 
            this.gcClass.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcClass.Enabled = false;
            this.gcClass.Location = new System.Drawing.Point(2, 20);
            this.gcClass.MainView = this.gvClass;
            this.gcClass.Name = "gcClass";
            this.gcClass.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemCheckEdit1});
            this.gcClass.Size = new System.Drawing.Size(578, 109);
            this.gcClass.TabIndex = 0;
            this.gcClass.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvClass});
            // 
            // gvClass
            // 
            this.gvClass.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gcolClassCode,
            this.gcolClassName,
            this.gcolStatus});
            this.gvClass.GridControl = this.gcClass;
            this.gvClass.Name = "gvClass";
            this.gvClass.OptionsView.AnimationType = DevExpress.XtraGrid.Views.Base.GridAnimationType.AnimateFocusedItem;
            this.gvClass.OptionsView.BestFitMode = DevExpress.XtraGrid.Views.Grid.GridBestFitMode.Full;
            this.gvClass.OptionsView.ShowGroupPanel = false;
            // 
            // gcolClassCode
            // 
            this.gcolClassCode.Caption = "Mã lớp";
            this.gcolClassCode.FieldName = "Code";
            this.gcolClassCode.Name = "gcolClassCode";
            this.gcolClassCode.Visible = true;
            this.gcolClassCode.VisibleIndex = 0;
            // 
            // gcolClassName
            // 
            this.gcolClassName.Caption = "Tên lớp";
            this.gcolClassName.FieldName = "Name";
            this.gcolClassName.Name = "gcolClassName";
            this.gcolClassName.Visible = true;
            this.gcolClassName.VisibleIndex = 1;
            // 
            // gcolStatus
            // 
            this.gcolStatus.Caption = "Chọn";
            this.gcolStatus.ColumnEdit = this.repositoryItemCheckEdit1;
            this.gcolStatus.FieldName = "Status";
            this.gcolStatus.Name = "gcolStatus";
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
            // groupControl2
            // 
            this.groupControl2.Controls.Add(this.cbxEndWeek);
            this.groupControl2.Controls.Add(this.cbxStartWeek);
            this.groupControl2.Controls.Add(this.dpEnđate);
            this.groupControl2.Controls.Add(this.labelControl2);
            this.groupControl2.Controls.Add(this.dpStartDate);
            this.groupControl2.Controls.Add(this.labelControl4);
            this.groupControl2.Controls.Add(this.labelControl3);
            this.groupControl2.Controls.Add(this.labelControl1);
            this.groupControl2.Location = new System.Drawing.Point(12, 194);
            this.groupControl2.Name = "groupControl2";
            this.groupControl2.Size = new System.Drawing.Size(582, 86);
            this.groupControl2.TabIndex = 1;
            this.groupControl2.Text = "Thời gian dự kiến";
            // 
            // cbxEndWeek
            // 
            this.cbxEndWeek.Location = new System.Drawing.Point(434, 29);
            this.cbxEndWeek.Name = "cbxEndWeek";
            this.cbxEndWeek.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cbxEndWeek.Size = new System.Drawing.Size(100, 20);
            this.cbxEndWeek.TabIndex = 2;
            this.cbxEndWeek.SelectedIndexChanged += new System.EventHandler(this.cbxEndWeek_SelectedIndexChanged);
            // 
            // cbxStartWeek
            // 
            this.cbxStartWeek.Location = new System.Drawing.Point(110, 29);
            this.cbxStartWeek.Name = "cbxStartWeek";
            this.cbxStartWeek.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cbxStartWeek.Size = new System.Drawing.Size(100, 20);
            this.cbxStartWeek.TabIndex = 2;
            this.cbxStartWeek.SelectedIndexChanged += new System.EventHandler(this.cbxStartWeek_SelectedIndexChanged);
            // 
            // dpEnđate
            // 
            this.dpEnđate.EditValue = null;
            this.dpEnđate.Location = new System.Drawing.Point(434, 55);
            this.dpEnđate.Name = "dpEnđate";
            this.dpEnđate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dpEnđate.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dpEnđate.Properties.DisplayFormat.FormatString = "dd-MM-yyyy";
            this.dpEnđate.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dpEnđate.Properties.EditFormat.FormatString = "dd-MM-yyyy";
            this.dpEnđate.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dpEnđate.Properties.Mask.EditMask = "dd-MM-yyyy";
            this.dpEnđate.Size = new System.Drawing.Size(100, 20);
            this.dpEnđate.TabIndex = 1;
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(344, 58);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(65, 13);
            this.labelControl2.TabIndex = 0;
            this.labelControl2.Text = "Ngày bắt đầu";
            // 
            // dpStartDate
            // 
            this.dpStartDate.EditValue = null;
            this.dpStartDate.Location = new System.Drawing.Point(110, 55);
            this.dpStartDate.Name = "dpStartDate";
            this.dpStartDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dpStartDate.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dpStartDate.Properties.DisplayFormat.FormatString = "dd-MM-yyyy";
            this.dpStartDate.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dpStartDate.Properties.EditFormat.FormatString = "dd-MM-yyyy";
            this.dpStartDate.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dpStartDate.Properties.Mask.EditMask = "dd-MM-yyyy";
            this.dpStartDate.Size = new System.Drawing.Size(100, 20);
            this.dpStartDate.TabIndex = 1;
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(344, 32);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(66, 13);
            this.labelControl4.TabIndex = 0;
            this.labelControl4.Text = "Tuần kết thúc";
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(20, 32);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(64, 13);
            this.labelControl3.TabIndex = 0;
            this.labelControl3.Text = "Tuần bắt đầu";
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(20, 58);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(65, 13);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "Ngày bắt đầu";
            // 
            // groupControl3
            // 
            this.groupControl3.Controls.Add(this.splitContainer1);
            this.groupControl3.Location = new System.Drawing.Point(12, 286);
            this.groupControl3.Name = "groupControl3";
            this.groupControl3.Size = new System.Drawing.Size(582, 277);
            this.groupControl3.TabIndex = 2;
            this.groupControl3.Text = "Thời gian trong tuần";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(2, 20);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.ckThursday);
            this.splitContainer1.Panel1.Controls.Add(this.ckSunday);
            this.splitContainer1.Panel1.Controls.Add(this.ckMonday);
            this.splitContainer1.Panel1.Controls.Add(this.ckSaturday);
            this.splitContainer1.Panel1.Controls.Add(this.ckTuesday);
            this.splitContainer1.Panel1.Controls.Add(this.ckFriday);
            this.splitContainer1.Panel1.Controls.Add(this.ckWednesday);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.AutoScroll = true;
            this.splitContainer1.Panel2.Controls.Add(this.flowLayoutPanel1);
            this.splitContainer1.Size = new System.Drawing.Size(578, 255);
            this.splitContainer1.SplitterDistance = 36;
            this.splitContainer1.TabIndex = 3;
            // 
            // ckThursday
            // 
            this.ckThursday.Location = new System.Drawing.Point(251, 12);
            this.ckThursday.Name = "ckThursday";
            this.ckThursday.Properties.Caption = "Thứ 5";
            this.ckThursday.Size = new System.Drawing.Size(75, 19);
            this.ckThursday.TabIndex = 2;
            this.ckThursday.CheckedChanged += new System.EventHandler(this.ckThursday_CheckedChanged);
            // 
            // ckSunday
            // 
            this.ckSunday.Location = new System.Drawing.Point(494, 12);
            this.ckSunday.Name = "ckSunday";
            this.ckSunday.Properties.Caption = "Chủ nhật";
            this.ckSunday.Size = new System.Drawing.Size(75, 19);
            this.ckSunday.TabIndex = 2;
            this.ckSunday.CheckedChanged += new System.EventHandler(this.ckSunday_CheckedChanged);
            // 
            // ckMonday
            // 
            this.ckMonday.Location = new System.Drawing.Point(8, 12);
            this.ckMonday.Name = "ckMonday";
            this.ckMonday.Properties.Caption = "Thứ 2";
            this.ckMonday.Size = new System.Drawing.Size(75, 19);
            this.ckMonday.TabIndex = 2;
            this.ckMonday.CheckedChanged += new System.EventHandler(this.ckMonday_CheckedChanged);
            // 
            // ckSaturday
            // 
            this.ckSaturday.Location = new System.Drawing.Point(413, 12);
            this.ckSaturday.Name = "ckSaturday";
            this.ckSaturday.Properties.Caption = "Thứ 7";
            this.ckSaturday.Size = new System.Drawing.Size(75, 19);
            this.ckSaturday.TabIndex = 2;
            this.ckSaturday.CheckedChanged += new System.EventHandler(this.ckSaturday_CheckedChanged);
            // 
            // ckTuesday
            // 
            this.ckTuesday.Location = new System.Drawing.Point(89, 12);
            this.ckTuesday.Name = "ckTuesday";
            this.ckTuesday.Properties.Caption = "Thứ 3";
            this.ckTuesday.Size = new System.Drawing.Size(75, 19);
            this.ckTuesday.TabIndex = 2;
            this.ckTuesday.CheckedChanged += new System.EventHandler(this.ckTuesday_CheckedChanged);
            // 
            // ckFriday
            // 
            this.ckFriday.Location = new System.Drawing.Point(332, 12);
            this.ckFriday.Name = "ckFriday";
            this.ckFriday.Properties.Caption = "Thứ 6";
            this.ckFriday.Size = new System.Drawing.Size(75, 19);
            this.ckFriday.TabIndex = 2;
            this.ckFriday.CheckedChanged += new System.EventHandler(this.ckFriday_CheckedChanged);
            // 
            // ckWednesday
            // 
            this.ckWednesday.Location = new System.Drawing.Point(170, 12);
            this.ckWednesday.Name = "ckWednesday";
            this.ckWednesday.Properties.Caption = "Thứ 4";
            this.ckWednesday.Size = new System.Drawing.Size(75, 19);
            this.ckWednesday.TabIndex = 2;
            this.ckWednesday.CheckedChanged += new System.EventHandler(this.ckWednesday_CheckedChanged);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoScroll = true;
            this.flowLayoutPanel1.AutoSize = true;
            this.flowLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(578, 215);
            this.flowLayoutPanel1.TabIndex = 1;
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(401, 569);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(91, 25);
            this.btnOK.TabIndex = 3;
            this.btnOK.Text = "Đồng ý";
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(501, 569);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(91, 25);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Text = "Thoát";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnRefesh
            // 
            this.btnRefesh.Location = new System.Drawing.Point(304, 569);
            this.btnRefesh.Name = "btnRefesh";
            this.btnRefesh.Size = new System.Drawing.Size(91, 25);
            this.btnRefesh.TabIndex = 3;
            this.btnRefesh.Text = "Làm mới";
            // 
            // groupControl8
            // 
            this.groupControl8.Appearance.BackColor = System.Drawing.Color.White;
            this.groupControl8.Appearance.Options.UseBackColor = true;
            this.groupControl8.Controls.Add(this.lbTeacher);
            this.groupControl8.Controls.Add(this.lbSubjectName);
            this.groupControl8.Controls.Add(this.lbSubjectCode);
            this.groupControl8.Location = new System.Drawing.Point(12, 2);
            this.groupControl8.Name = "groupControl8";
            this.groupControl8.Size = new System.Drawing.Size(582, 49);
            this.groupControl8.TabIndex = 4;
            this.groupControl8.Text = "Thông tin khóa học";
            // 
            // lbTeacher
            // 
            this.lbTeacher.Appearance.Font = new System.Drawing.Font("Yu Gothic UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTeacher.Appearance.Options.UseFont = true;
            this.lbTeacher.Location = new System.Drawing.Point(433, 23);
            this.lbTeacher.Name = "lbTeacher";
            this.lbTeacher.Size = new System.Drawing.Size(53, 17);
            this.lbTeacher.TabIndex = 0;
            this.lbTeacher.Text = "Năm học";
            // 
            // lbSubjectName
            // 
            this.lbSubjectName.Appearance.Font = new System.Drawing.Font("Yu Gothic UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbSubjectName.Appearance.Options.UseFont = true;
            this.lbSubjectName.Location = new System.Drawing.Point(241, 23);
            this.lbSubjectName.Name = "lbSubjectName";
            this.lbSubjectName.Size = new System.Drawing.Size(51, 17);
            this.lbSubjectName.TabIndex = 0;
            this.lbSubjectName.Text = "Tên môn";
            // 
            // lbSubjectCode
            // 
            this.lbSubjectCode.Appearance.Font = new System.Drawing.Font("Yu Gothic UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbSubjectCode.Appearance.Options.UseFont = true;
            this.lbSubjectCode.Location = new System.Drawing.Point(49, 23);
            this.lbSubjectCode.Name = "lbSubjectCode";
            this.lbSubjectCode.Size = new System.Drawing.Size(49, 17);
            this.lbSubjectCode.TabIndex = 0;
            this.lbSubjectCode.Text = "Mã môn";
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(14, 569);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(284, 23);
            this.progressBar1.TabIndex = 5;
            // 
            // NewCoursefrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(609, 606);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.groupControl8);
            this.Controls.Add(this.btnRefesh);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.groupControl3);
            this.Controls.Add(this.groupControl2);
            this.Controls.Add(this.groupControl1);
            this.Name = "NewCoursefrm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Tạo lịch học";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.NewCoursefrm_FormClosing);
            this.Load += new System.EventHandler(this.NewCoursefrm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gcClass)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvClass)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).EndInit();
            this.groupControl2.ResumeLayout(false);
            this.groupControl2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cbxEndWeek.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbxStartWeek.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dpEnđate.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dpEnđate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dpStartDate.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dpStartDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl3)).EndInit();
            this.groupControl3.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ckThursday.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ckSunday.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ckMonday.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ckSaturday.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ckTuesday.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ckFriday.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ckWednesday.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl8)).EndInit();
            this.groupControl8.ResumeLayout(false);
            this.groupControl8.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.LookAndFeel.DefaultLookAndFeel defaultLookAndFeel1;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraGrid.GridControl gcClass;
        private DevExpress.XtraGrid.Views.Grid.GridView gvClass;
        private DevExpress.XtraGrid.Columns.GridColumn gcolClassCode;
        private DevExpress.XtraGrid.Columns.GridColumn gcolClassName;
        private DevExpress.XtraGrid.Columns.GridColumn gcolStatus;
        private DevExpress.XtraEditors.GroupControl groupControl2;
        private DevExpress.XtraEditors.ComboBoxEdit cbxEndWeek;
        private DevExpress.XtraEditors.ComboBoxEdit cbxStartWeek;
        private DevExpress.XtraEditors.DateEdit dpEnđate;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.DateEdit dpStartDate;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.GroupControl groupControl3;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private DevExpress.XtraEditors.CheckEdit ckThursday;
        private DevExpress.XtraEditors.CheckEdit ckSunday;
        private DevExpress.XtraEditors.CheckEdit ckMonday;
        private DevExpress.XtraEditors.CheckEdit ckSaturday;
        private DevExpress.XtraEditors.CheckEdit ckTuesday;
        private DevExpress.XtraEditors.CheckEdit ckFriday;
        private DevExpress.XtraEditors.CheckEdit ckWednesday;
        private DevExpress.XtraEditors.SimpleButton btnOK;
        private DevExpress.XtraEditors.SimpleButton btnCancel;
        private DevExpress.XtraEditors.SimpleButton btnRefesh;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEdit1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private DevExpress.XtraEditors.GroupControl groupControl8;
        private DevExpress.XtraEditors.LabelControl lbTeacher;
        private DevExpress.XtraEditors.LabelControl lbSubjectName;
        private DevExpress.XtraEditors.LabelControl lbSubjectCode;
        private System.Windows.Forms.ProgressBar progressBar1;
    }
}