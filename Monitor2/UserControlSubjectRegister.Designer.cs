using DevExpress.XtraEditors;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Grid;

namespace Monitor2
{
    partial class UserControlSubjectRegister
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UserControlSubjectRegister));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.groupControl22 = new DevExpress.XtraEditors.GroupControl();
            this.ckbNotify = new System.Windows.Forms.CheckBox();
            this.groupControl21 = new DevExpress.XtraEditors.GroupControl();
            this.groupControl17 = new DevExpress.XtraEditors.GroupControl();
            this.groupControl18 = new DevExpress.XtraEditors.GroupControl();
            this.tbxFinal = new System.Windows.Forms.TextBox();
            this.groupControl19 = new DevExpress.XtraEditors.GroupControl();
            this.tbxDiligence = new System.Windows.Forms.TextBox();
            this.groupControl20 = new DevExpress.XtraEditors.GroupControl();
            this.tbxSemiFinal = new System.Windows.Forms.TextBox();
            this.groupControl13 = new DevExpress.XtraEditors.GroupControl();
            this.groupControl14 = new DevExpress.XtraEditors.GroupControl();
            this.tbxCreditTotal = new System.Windows.Forms.TextBox();
            this.groupControl16 = new DevExpress.XtraEditors.GroupControl();
            this.tbxCreditPractice = new System.Windows.Forms.TextBox();
            this.groupControl15 = new DevExpress.XtraEditors.GroupControl();
            this.tbxCreditTheory = new System.Windows.Forms.TextBox();
            this.groupControl12 = new DevExpress.XtraEditors.GroupControl();
            this.groupControl10 = new DevExpress.XtraEditors.GroupControl();
            this.cbxTeacher = new System.Windows.Forms.ComboBox();
            this.groupControl11 = new DevExpress.XtraEditors.GroupControl();
            this.tbxExpectNumber = new System.Windows.Forms.NumericUpDown();
            this.groupControl3 = new DevExpress.XtraEditors.GroupControl();
            this.groupControl9 = new DevExpress.XtraEditors.GroupControl();
            this.tbxSubjectName = new System.Windows.Forms.TextBox();
            this.groupControl8 = new DevExpress.XtraEditors.GroupControl();
            this.cbxSubject = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.groupControl2 = new DevExpress.XtraEditors.GroupControl();
            this.groupControl5 = new DevExpress.XtraEditors.GroupControl();
            this.tbxClassName = new System.Windows.Forms.TextBox();
            this.groupControl7 = new DevExpress.XtraEditors.GroupControl();
            this.tbxSpecialize = new System.Windows.Forms.TextBox();
            this.groupControl6 = new DevExpress.XtraEditors.GroupControl();
            this.tbxDepartment = new System.Windows.Forms.TextBox();
            this.groupControl4 = new DevExpress.XtraEditors.GroupControl();
            this.cbxClass = new System.Windows.Forms.ComboBox();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.cbxSchoolYearCode = new System.Windows.Forms.ComboBox();
            this.btnCreateSubjectRegister = new DevExpress.XtraEditors.SimpleButton();
            this.tabPane1 = new DevExpress.XtraBars.Navigation.TabPane();
            this.tabNavigationPage1 = new DevExpress.XtraBars.Navigation.TabNavigationPage();
            this.panel2 = new System.Windows.Forms.Panel();
            this.gcSubjectRegister = new DevExpress.XtraGrid.GridControl();
            this.contextMenuStripRepairLearningSubject = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tạoThờiKhóaBiểuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mởKhóaHọcToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tạoLịchHọcToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cậpNhậtĐangHọcToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.đóngMônHọcToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.xemThờiKhóaBiểuToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.xemLiênKếtToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.thêmLớpHọcToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.gvSubjectRegister = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gcolCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcolSubjectName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcolTeacherCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcolTeacherName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcolStartDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcolEndDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcolStatus = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcolExpectStudent = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcolCurrentStudent = new DevExpress.XtraGrid.Columns.GridColumn();
            this.panel1 = new System.Windows.Forms.Panel();
            this.checkButton1 = new DevExpress.XtraEditors.CheckButton();
            this.radioGroupSubjectRegisterSelection = new DevExpress.XtraEditors.RadioGroup();
            this.tabNavigationPage22 = new DevExpress.XtraBars.Navigation.TabNavigationPage();
            this.gcLearnedSubject = new DevExpress.XtraGrid.GridControl();
            this.gvLearnedSubject = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn15 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn16 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn17 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn18 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn19 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn20 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn21 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn24 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcLearningSubject = new DevExpress.XtraGrid.GridControl();
            this.contextMenuStripLearningSubject = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.xemThờiKhóaBiểuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.xemChiTiếtToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.đóngMônHọcToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gvLearningsubject = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn8 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn9 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn10 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn11 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn12 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn13 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn14 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn23 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcRepairLearningSubject = new DevExpress.XtraGrid.GridControl();
            this.gvRepairLearningSubject = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn7 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn22 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl22)).BeginInit();
            this.groupControl22.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl21)).BeginInit();
            this.groupControl21.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl17)).BeginInit();
            this.groupControl17.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl18)).BeginInit();
            this.groupControl18.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl19)).BeginInit();
            this.groupControl19.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl20)).BeginInit();
            this.groupControl20.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl13)).BeginInit();
            this.groupControl13.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl14)).BeginInit();
            this.groupControl14.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl16)).BeginInit();
            this.groupControl16.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl15)).BeginInit();
            this.groupControl15.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl12)).BeginInit();
            this.groupControl12.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl10)).BeginInit();
            this.groupControl10.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl11)).BeginInit();
            this.groupControl11.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbxExpectNumber)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl3)).BeginInit();
            this.groupControl3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl9)).BeginInit();
            this.groupControl9.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl8)).BeginInit();
            this.groupControl8.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).BeginInit();
            this.groupControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl5)).BeginInit();
            this.groupControl5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl7)).BeginInit();
            this.groupControl7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl6)).BeginInit();
            this.groupControl6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl4)).BeginInit();
            this.groupControl4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tabPane1)).BeginInit();
            this.tabPane1.SuspendLayout();
            this.tabNavigationPage1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcSubjectRegister)).BeginInit();
            this.contextMenuStripRepairLearningSubject.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvSubjectRegister)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radioGroupSubjectRegisterSelection.Properties)).BeginInit();
            this.tabNavigationPage22.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcLearnedSubject)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvLearnedSubject)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcLearningSubject)).BeginInit();
            this.contextMenuStripLearningSubject.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvLearningsubject)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcRepairLearningSubject)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvRepairLearningSubject)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.pictureBox1);
            this.splitContainer1.Panel1.Controls.Add(this.groupControl22);
            this.splitContainer1.Panel1.Controls.Add(this.groupControl21);
            this.splitContainer1.Panel1.Controls.Add(this.groupControl12);
            this.splitContainer1.Panel1.Controls.Add(this.groupControl3);
            this.splitContainer1.Panel1.Controls.Add(this.groupControl2);
            this.splitContainer1.Panel1.Controls.Add(this.groupControl1);
            this.splitContainer1.Panel1.Controls.Add(this.btnCreateSubjectRegister);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.tabPane1);
            this.splitContainer1.Size = new System.Drawing.Size(857, 525);
            this.splitContainer1.SplitterDistance = 211;
            this.splitContainer1.TabIndex = 1;
            // 
            // groupControl22
            // 
            this.groupControl22.Controls.Add(this.ckbNotify);
            this.groupControl22.Location = new System.Drawing.Point(537, 119);
            this.groupControl22.Name = "groupControl22";
            this.groupControl22.Size = new System.Drawing.Size(142, 88);
            this.groupControl22.TabIndex = 13;
            this.groupControl22.Text = "Tác vụ";
            // 
            // ckbNotify
            // 
            this.ckbNotify.AutoSize = true;
            this.ckbNotify.Checked = true;
            this.ckbNotify.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ckbNotify.Location = new System.Drawing.Point(5, 26);
            this.ckbNotify.Name = "ckbNotify";
            this.ckbNotify.Size = new System.Drawing.Size(94, 17);
            this.ckbNotify.TabIndex = 0;
            this.ckbNotify.Text = "Gửi thông báo";
            this.ckbNotify.UseVisualStyleBackColor = true;
            // 
            // groupControl21
            // 
            this.groupControl21.Controls.Add(this.groupControl17);
            this.groupControl21.Controls.Add(this.groupControl13);
            this.groupControl21.Location = new System.Drawing.Point(231, 119);
            this.groupControl21.Name = "groupControl21";
            this.groupControl21.Size = new System.Drawing.Size(300, 88);
            this.groupControl21.TabIndex = 12;
            this.groupControl21.Text = "Thông số môn học";
            // 
            // groupControl17
            // 
            this.groupControl17.Controls.Add(this.groupControl18);
            this.groupControl17.Controls.Add(this.groupControl19);
            this.groupControl17.Controls.Add(this.groupControl20);
            this.groupControl17.Location = new System.Drawing.Point(6, 22);
            this.groupControl17.Name = "groupControl17";
            this.groupControl17.Size = new System.Drawing.Size(140, 61);
            this.groupControl17.TabIndex = 11;
            this.groupControl17.Text = "Tỉ lệ điểm";
            // 
            // groupControl18
            // 
            this.groupControl18.Controls.Add(this.tbxFinal);
            this.groupControl18.Location = new System.Drawing.Point(1, 18);
            this.groupControl18.Name = "groupControl18";
            this.groupControl18.Size = new System.Drawing.Size(46, 43);
            this.groupControl18.TabIndex = 0;
            this.groupControl18.Text = "CK";
            // 
            // tbxFinal
            // 
            this.tbxFinal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbxFinal.Location = new System.Drawing.Point(2, 20);
            this.tbxFinal.Name = "tbxFinal";
            this.tbxFinal.Size = new System.Drawing.Size(42, 21);
            this.tbxFinal.TabIndex = 1;
            // 
            // groupControl19
            // 
            this.groupControl19.Controls.Add(this.tbxDiligence);
            this.groupControl19.Location = new System.Drawing.Point(93, 18);
            this.groupControl19.Name = "groupControl19";
            this.groupControl19.Size = new System.Drawing.Size(46, 43);
            this.groupControl19.TabIndex = 0;
            this.groupControl19.Text = "CC";
            // 
            // tbxDiligence
            // 
            this.tbxDiligence.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbxDiligence.Location = new System.Drawing.Point(2, 20);
            this.tbxDiligence.Name = "tbxDiligence";
            this.tbxDiligence.Size = new System.Drawing.Size(42, 21);
            this.tbxDiligence.TabIndex = 1;
            // 
            // groupControl20
            // 
            this.groupControl20.Controls.Add(this.tbxSemiFinal);
            this.groupControl20.Location = new System.Drawing.Point(47, 18);
            this.groupControl20.Name = "groupControl20";
            this.groupControl20.Size = new System.Drawing.Size(46, 43);
            this.groupControl20.TabIndex = 0;
            this.groupControl20.Text = "GK";
            // 
            // tbxSemiFinal
            // 
            this.tbxSemiFinal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbxSemiFinal.Location = new System.Drawing.Point(2, 20);
            this.tbxSemiFinal.Name = "tbxSemiFinal";
            this.tbxSemiFinal.Size = new System.Drawing.Size(42, 21);
            this.tbxSemiFinal.TabIndex = 1;
            // 
            // groupControl13
            // 
            this.groupControl13.Controls.Add(this.groupControl14);
            this.groupControl13.Controls.Add(this.groupControl16);
            this.groupControl13.Controls.Add(this.groupControl15);
            this.groupControl13.Location = new System.Drawing.Point(152, 22);
            this.groupControl13.Name = "groupControl13";
            this.groupControl13.Size = new System.Drawing.Size(140, 61);
            this.groupControl13.TabIndex = 11;
            this.groupControl13.Text = "Tín chỉ";
            // 
            // groupControl14
            // 
            this.groupControl14.Controls.Add(this.tbxCreditTotal);
            this.groupControl14.Location = new System.Drawing.Point(1, 18);
            this.groupControl14.Name = "groupControl14";
            this.groupControl14.Size = new System.Drawing.Size(46, 43);
            this.groupControl14.TabIndex = 0;
            this.groupControl14.Text = "Tổng";
            // 
            // tbxCreditTotal
            // 
            this.tbxCreditTotal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbxCreditTotal.Location = new System.Drawing.Point(2, 20);
            this.tbxCreditTotal.Name = "tbxCreditTotal";
            this.tbxCreditTotal.Size = new System.Drawing.Size(42, 21);
            this.tbxCreditTotal.TabIndex = 1;
            // 
            // groupControl16
            // 
            this.groupControl16.Controls.Add(this.tbxCreditPractice);
            this.groupControl16.Location = new System.Drawing.Point(93, 18);
            this.groupControl16.Name = "groupControl16";
            this.groupControl16.Size = new System.Drawing.Size(46, 43);
            this.groupControl16.TabIndex = 0;
            this.groupControl16.Text = "TH";
            // 
            // tbxCreditPractice
            // 
            this.tbxCreditPractice.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbxCreditPractice.Location = new System.Drawing.Point(2, 20);
            this.tbxCreditPractice.Name = "tbxCreditPractice";
            this.tbxCreditPractice.Size = new System.Drawing.Size(42, 21);
            this.tbxCreditPractice.TabIndex = 1;
            // 
            // groupControl15
            // 
            this.groupControl15.Controls.Add(this.tbxCreditTheory);
            this.groupControl15.Location = new System.Drawing.Point(47, 18);
            this.groupControl15.Name = "groupControl15";
            this.groupControl15.Size = new System.Drawing.Size(46, 43);
            this.groupControl15.TabIndex = 0;
            this.groupControl15.Text = "LT";
            // 
            // tbxCreditTheory
            // 
            this.tbxCreditTheory.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbxCreditTheory.Location = new System.Drawing.Point(2, 20);
            this.tbxCreditTheory.Name = "tbxCreditTheory";
            this.tbxCreditTheory.Size = new System.Drawing.Size(42, 21);
            this.tbxCreditTheory.TabIndex = 1;
            // 
            // groupControl12
            // 
            this.groupControl12.Controls.Add(this.groupControl10);
            this.groupControl12.Controls.Add(this.groupControl11);
            this.groupControl12.Location = new System.Drawing.Point(457, 3);
            this.groupControl12.Name = "groupControl12";
            this.groupControl12.Size = new System.Drawing.Size(222, 113);
            this.groupControl12.TabIndex = 11;
            this.groupControl12.Text = "Chi tiết";
            // 
            // groupControl10
            // 
            this.groupControl10.Controls.Add(this.cbxTeacher);
            this.groupControl10.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupControl10.Location = new System.Drawing.Point(2, 20);
            this.groupControl10.Name = "groupControl10";
            this.groupControl10.Size = new System.Drawing.Size(218, 46);
            this.groupControl10.TabIndex = 9;
            this.groupControl10.Text = "Giáo viên";
            // 
            // cbxTeacher
            // 
            this.cbxTeacher.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cbxTeacher.FormattingEnabled = true;
            this.cbxTeacher.Location = new System.Drawing.Point(2, 20);
            this.cbxTeacher.Name = "cbxTeacher";
            this.cbxTeacher.Size = new System.Drawing.Size(214, 21);
            this.cbxTeacher.TabIndex = 0;
            // 
            // groupControl11
            // 
            this.groupControl11.Controls.Add(this.tbxExpectNumber);
            this.groupControl11.Location = new System.Drawing.Point(0, 67);
            this.groupControl11.Name = "groupControl11";
            this.groupControl11.Size = new System.Drawing.Size(222, 46);
            this.groupControl11.TabIndex = 10;
            this.groupControl11.Text = "Số lượng dự kiến";
            // 
            // tbxExpectNumber
            // 
            this.tbxExpectNumber.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbxExpectNumber.Location = new System.Drawing.Point(2, 20);
            this.tbxExpectNumber.Minimum = new decimal(new int[] {
            15,
            0,
            0,
            0});
            this.tbxExpectNumber.Name = "tbxExpectNumber";
            this.tbxExpectNumber.Size = new System.Drawing.Size(218, 21);
            this.tbxExpectNumber.TabIndex = 0;
            this.tbxExpectNumber.Value = new decimal(new int[] {
            15,
            0,
            0,
            0});
            // 
            // groupControl3
            // 
            this.groupControl3.Controls.Add(this.groupControl9);
            this.groupControl3.Controls.Add(this.groupControl8);
            this.groupControl3.Controls.Add(this.label6);
            this.groupControl3.Location = new System.Drawing.Point(231, 3);
            this.groupControl3.Name = "groupControl3";
            this.groupControl3.Size = new System.Drawing.Size(222, 113);
            this.groupControl3.TabIndex = 8;
            this.groupControl3.Text = "Môn học";
            // 
            // groupControl9
            // 
            this.groupControl9.Controls.Add(this.tbxSubjectName);
            this.groupControl9.Location = new System.Drawing.Point(2, 67);
            this.groupControl9.Name = "groupControl9";
            this.groupControl9.Size = new System.Drawing.Size(218, 46);
            this.groupControl9.TabIndex = 12;
            this.groupControl9.Text = "Tên môn";
            // 
            // tbxSubjectName
            // 
            this.tbxSubjectName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbxSubjectName.Location = new System.Drawing.Point(2, 20);
            this.tbxSubjectName.Name = "tbxSubjectName";
            this.tbxSubjectName.Size = new System.Drawing.Size(214, 21);
            this.tbxSubjectName.TabIndex = 8;
            // 
            // groupControl8
            // 
            this.groupControl8.Controls.Add(this.cbxSubject);
            this.groupControl8.Location = new System.Drawing.Point(0, 19);
            this.groupControl8.Name = "groupControl8";
            this.groupControl8.Size = new System.Drawing.Size(222, 46);
            this.groupControl8.TabIndex = 11;
            this.groupControl8.Text = "Mã môn";
            // 
            // cbxSubject
            // 
            this.cbxSubject.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cbxSubject.FormattingEnabled = true;
            this.cbxSubject.Location = new System.Drawing.Point(2, 20);
            this.cbxSubject.Name = "cbxSubject";
            this.cbxSubject.Size = new System.Drawing.Size(218, 21);
            this.cbxSubject.TabIndex = 0;
            this.cbxSubject.SelectedIndexChanged += new System.EventHandler(this.cbxSubject_SelectedIndexChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 50);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(52, 13);
            this.label6.TabIndex = 6;
            this.label6.Text = "TÊN MÔN";
            // 
            // groupControl2
            // 
            this.groupControl2.Controls.Add(this.groupControl5);
            this.groupControl2.Controls.Add(this.groupControl7);
            this.groupControl2.Controls.Add(this.groupControl6);
            this.groupControl2.Controls.Add(this.groupControl4);
            this.groupControl2.Location = new System.Drawing.Point(3, 3);
            this.groupControl2.Name = "groupControl2";
            this.groupControl2.Size = new System.Drawing.Size(222, 159);
            this.groupControl2.TabIndex = 7;
            this.groupControl2.Text = "LỚP";
            // 
            // groupControl5
            // 
            this.groupControl5.Controls.Add(this.tbxClassName);
            this.groupControl5.Location = new System.Drawing.Point(2, 64);
            this.groupControl5.Name = "groupControl5";
            this.groupControl5.Size = new System.Drawing.Size(220, 44);
            this.groupControl5.TabIndex = 9;
            this.groupControl5.Text = "Tên lớp";
            // 
            // tbxClassName
            // 
            this.tbxClassName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbxClassName.Location = new System.Drawing.Point(2, 20);
            this.tbxClassName.Name = "tbxClassName";
            this.tbxClassName.Size = new System.Drawing.Size(216, 21);
            this.tbxClassName.TabIndex = 8;
            // 
            // groupControl7
            // 
            this.groupControl7.Controls.Add(this.tbxSpecialize);
            this.groupControl7.Location = new System.Drawing.Point(107, 110);
            this.groupControl7.Name = "groupControl7";
            this.groupControl7.Size = new System.Drawing.Size(115, 44);
            this.groupControl7.TabIndex = 9;
            this.groupControl7.Text = "Ngành";
            // 
            // tbxSpecialize
            // 
            this.tbxSpecialize.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbxSpecialize.Location = new System.Drawing.Point(2, 20);
            this.tbxSpecialize.Name = "tbxSpecialize";
            this.tbxSpecialize.Size = new System.Drawing.Size(111, 21);
            this.tbxSpecialize.TabIndex = 0;
            // 
            // groupControl6
            // 
            this.groupControl6.Controls.Add(this.tbxDepartment);
            this.groupControl6.Location = new System.Drawing.Point(0, 110);
            this.groupControl6.Name = "groupControl6";
            this.groupControl6.Size = new System.Drawing.Size(103, 44);
            this.groupControl6.TabIndex = 9;
            this.groupControl6.Text = "Ban";
            // 
            // tbxDepartment
            // 
            this.tbxDepartment.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbxDepartment.Location = new System.Drawing.Point(2, 20);
            this.tbxDepartment.Name = "tbxDepartment";
            this.tbxDepartment.Size = new System.Drawing.Size(99, 21);
            this.tbxDepartment.TabIndex = 0;
            // 
            // groupControl4
            // 
            this.groupControl4.Controls.Add(this.cbxClass);
            this.groupControl4.Location = new System.Drawing.Point(0, 19);
            this.groupControl4.Name = "groupControl4";
            this.groupControl4.Size = new System.Drawing.Size(222, 44);
            this.groupControl4.TabIndex = 9;
            this.groupControl4.Text = "Mã lớp";
            // 
            // cbxClass
            // 
            this.cbxClass.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cbxClass.FormattingEnabled = true;
            this.cbxClass.Location = new System.Drawing.Point(2, 20);
            this.cbxClass.Name = "cbxClass";
            this.cbxClass.Size = new System.Drawing.Size(218, 21);
            this.cbxClass.TabIndex = 0;
            this.cbxClass.SelectedIndexChanged += new System.EventHandler(this.cbxClass_SelectedIndexChanged);
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.cbxSchoolYearCode);
            this.groupControl1.Location = new System.Drawing.Point(3, 163);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(222, 44);
            this.groupControl1.TabIndex = 6;
            this.groupControl1.Text = "NĂM HỌC";
            // 
            // cbxSchoolYearCode
            // 
            this.cbxSchoolYearCode.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cbxSchoolYearCode.FormattingEnabled = true;
            this.cbxSchoolYearCode.Location = new System.Drawing.Point(2, 20);
            this.cbxSchoolYearCode.Name = "cbxSchoolYearCode";
            this.cbxSchoolYearCode.Size = new System.Drawing.Size(218, 21);
            this.cbxSchoolYearCode.TabIndex = 7;
            this.cbxSchoolYearCode.SelectedIndexChanged += new System.EventHandler(this.cbxSchoolYearCode_SelectedIndexChanged);
            // 
            // btnCreateSubjectRegister
            // 
            this.btnCreateSubjectRegister.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCreateSubjectRegister.Location = new System.Drawing.Point(693, 158);
            this.btnCreateSubjectRegister.Name = "btnCreateSubjectRegister";
            this.btnCreateSubjectRegister.Size = new System.Drawing.Size(145, 42);
            this.btnCreateSubjectRegister.TabIndex = 3;
            this.btnCreateSubjectRegister.Text = "Tạo Môn Học";
            this.btnCreateSubjectRegister.Click += new System.EventHandler(this.BtnCreateSubjectRegister_Click);
            // 
            // tabPane1
            // 
            this.tabPane1.Controls.Add(this.tabNavigationPage1);
            this.tabPane1.Controls.Add(this.tabNavigationPage22);
            this.tabPane1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabPane1.Location = new System.Drawing.Point(0, 0);
            this.tabPane1.Name = "tabPane1";
            this.tabPane1.Pages.AddRange(new DevExpress.XtraBars.Navigation.NavigationPageBase[] {
            this.tabNavigationPage1,
            this.tabNavigationPage22});
            this.tabPane1.RegularSize = new System.Drawing.Size(857, 310);
            this.tabPane1.SelectedPage = this.tabNavigationPage22;
            this.tabPane1.Size = new System.Drawing.Size(857, 310);
            this.tabPane1.TabIndex = 0;
            this.tabPane1.Text = "tabPane1";
            this.tabPane1.SelectedPageIndexChanged += new System.EventHandler(this.tabPane1_SelectedPageIndexChanged);
            // 
            // tabNavigationPage1
            // 
            this.tabNavigationPage1.Caption = "Thông tin khóa học";
            this.tabNavigationPage1.Controls.Add(this.panel2);
            this.tabNavigationPage1.Controls.Add(this.panel1);
            this.tabNavigationPage1.Name = "tabNavigationPage1";
            this.tabNavigationPage1.Size = new System.Drawing.Size(839, 265);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.gcSubjectRegister);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 23);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(839, 242);
            this.panel2.TabIndex = 3;
            // 
            // gcSubjectRegister
            // 
            this.gcSubjectRegister.ContextMenuStrip = this.contextMenuStripRepairLearningSubject;
            this.gcSubjectRegister.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcSubjectRegister.Location = new System.Drawing.Point(0, 0);
            this.gcSubjectRegister.MainView = this.gvSubjectRegister;
            this.gcSubjectRegister.Name = "gcSubjectRegister";
            this.gcSubjectRegister.Size = new System.Drawing.Size(839, 242);
            this.gcSubjectRegister.TabIndex = 1;
            this.gcSubjectRegister.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvSubjectRegister});
            // 
            // contextMenuStripRepairLearningSubject
            // 
            this.contextMenuStripRepairLearningSubject.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tạoThờiKhóaBiểuToolStripMenuItem,
            this.xemThờiKhóaBiểuToolStripMenuItem1,
            this.xemLiênKếtToolStripMenuItem1,
            this.thêmLớpHọcToolStripMenuItem1});
            this.contextMenuStripRepairLearningSubject.Name = "contextMenuStripRepairLearningSubject";
            this.contextMenuStripRepairLearningSubject.Size = new System.Drawing.Size(178, 92);
            // 
            // tạoThờiKhóaBiểuToolStripMenuItem
            // 
            this.tạoThờiKhóaBiểuToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mởKhóaHọcToolStripMenuItem,
            this.tạoLịchHọcToolStripMenuItem,
            this.cậpNhậtĐangHọcToolStripMenuItem,
            this.đóngMônHọcToolStripMenuItem1});
            this.tạoThờiKhóaBiểuToolStripMenuItem.Name = "tạoThờiKhóaBiểuToolStripMenuItem";
            this.tạoThờiKhóaBiểuToolStripMenuItem.Size = new System.Drawing.Size(177, 22);
            this.tạoThờiKhóaBiểuToolStripMenuItem.Text = "Cập nhật tình trạng";
            // 
            // mởKhóaHọcToolStripMenuItem
            // 
            this.mởKhóaHọcToolStripMenuItem.Name = "mởKhóaHọcToolStripMenuItem";
            this.mởKhóaHọcToolStripMenuItem.Size = new System.Drawing.Size(175, 22);
            this.mởKhóaHọcToolStripMenuItem.Text = "Mở khóa học";
            this.mởKhóaHọcToolStripMenuItem.Click += new System.EventHandler(this.mởKhóaHọcToolStripMenuItem_Click);
            // 
            // tạoLịchHọcToolStripMenuItem
            // 
            this.tạoLịchHọcToolStripMenuItem.Name = "tạoLịchHọcToolStripMenuItem";
            this.tạoLịchHọcToolStripMenuItem.Size = new System.Drawing.Size(175, 22);
            this.tạoLịchHọcToolStripMenuItem.Text = "Tạo lịch học";
            this.tạoLịchHọcToolStripMenuItem.Click += new System.EventHandler(this.tạoLịchHọcToolStripMenuItem_Click);
            // 
            // cậpNhậtĐangHọcToolStripMenuItem
            // 
            this.cậpNhậtĐangHọcToolStripMenuItem.Name = "cậpNhậtĐangHọcToolStripMenuItem";
            this.cậpNhậtĐangHọcToolStripMenuItem.Size = new System.Drawing.Size(175, 22);
            this.cậpNhậtĐangHọcToolStripMenuItem.Text = "Cập nhật đang học";
            this.cậpNhậtĐangHọcToolStripMenuItem.Click += new System.EventHandler(this.cậpNhậtĐangHọcToolStripMenuItem_Click);
            // 
            // đóngMônHọcToolStripMenuItem1
            // 
            this.đóngMônHọcToolStripMenuItem1.Name = "đóngMônHọcToolStripMenuItem1";
            this.đóngMônHọcToolStripMenuItem1.Size = new System.Drawing.Size(175, 22);
            this.đóngMônHọcToolStripMenuItem1.Text = "Đóng môn học";
            this.đóngMônHọcToolStripMenuItem1.Click += new System.EventHandler(this.đóngMônHọcToolStripMenuItem1_Click);
            // 
            // xemThờiKhóaBiểuToolStripMenuItem1
            // 
            this.xemThờiKhóaBiểuToolStripMenuItem1.Name = "xemThờiKhóaBiểuToolStripMenuItem1";
            this.xemThờiKhóaBiểuToolStripMenuItem1.Size = new System.Drawing.Size(177, 22);
            this.xemThờiKhóaBiểuToolStripMenuItem1.Text = "Xem thời khóa biểu";
            this.xemThờiKhóaBiểuToolStripMenuItem1.Click += new System.EventHandler(this.xemThờiKhóaBiểuToolStripMenuItem1_Click);
            // 
            // xemLiênKếtToolStripMenuItem1
            // 
            this.xemLiênKếtToolStripMenuItem1.Name = "xemLiênKếtToolStripMenuItem1";
            this.xemLiênKếtToolStripMenuItem1.Size = new System.Drawing.Size(177, 22);
            this.xemLiênKếtToolStripMenuItem1.Text = "Xem liên kết";
            this.xemLiênKếtToolStripMenuItem1.Click += new System.EventHandler(this.xemLiênKếtToolStripMenuItem1_Click);
            // 
            // thêmLớpHọcToolStripMenuItem1
            // 
            this.thêmLớpHọcToolStripMenuItem1.Name = "thêmLớpHọcToolStripMenuItem1";
            this.thêmLớpHọcToolStripMenuItem1.Size = new System.Drawing.Size(177, 22);
            this.thêmLớpHọcToolStripMenuItem1.Text = "Thêm lớp học";
            this.thêmLớpHọcToolStripMenuItem1.Click += new System.EventHandler(this.thêmLớpHọcToolStripMenuItem1_Click);
            // 
            // gvSubjectRegister
            // 
            this.gvSubjectRegister.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gcolCode,
            this.gcolSubjectName,
            this.gcolTeacherCode,
            this.gcolTeacherName,
            this.gcolStartDate,
            this.gcolEndDate,
            this.gcolStatus,
            this.gcolExpectStudent,
            this.gcolCurrentStudent});
            this.gvSubjectRegister.GridControl = this.gcSubjectRegister;
            this.gvSubjectRegister.Name = "gvSubjectRegister";
            this.gvSubjectRegister.OptionsView.GroupDrawMode = DevExpress.XtraGrid.Views.Grid.GroupDrawMode.Standard;
            this.gvSubjectRegister.OptionsView.ShowGroupPanel = false;
            this.gvSubjectRegister.OptionsView.ShowViewCaption = true;
            this.gvSubjectRegister.ViewCaption = "Danh sách khóa học / lớp học";
            this.gvSubjectRegister.PopupMenuShowing += new DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventHandler(this.gvSubjectRegister_PopupMenuShowing);
            // 
            // gcolCode
            // 
            this.gcolCode.Caption = "Mã MH";
            this.gcolCode.FieldName = "Code";
            this.gcolCode.Name = "gcolCode";
            this.gcolCode.Visible = true;
            this.gcolCode.VisibleIndex = 0;
            // 
            // gcolSubjectName
            // 
            this.gcolSubjectName.Caption = "Tên MH";
            this.gcolSubjectName.FieldName = "Name";
            this.gcolSubjectName.Name = "gcolSubjectName";
            this.gcolSubjectName.Visible = true;
            this.gcolSubjectName.VisibleIndex = 1;
            // 
            // gcolTeacherCode
            // 
            this.gcolTeacherCode.Caption = "Mã GV";
            this.gcolTeacherCode.FieldName = "TeacherCode";
            this.gcolTeacherCode.Name = "gcolTeacherCode";
            this.gcolTeacherCode.Visible = true;
            this.gcolTeacherCode.VisibleIndex = 2;
            // 
            // gcolTeacherName
            // 
            this.gcolTeacherName.Caption = "Tên GV";
            this.gcolTeacherName.FieldName = "TeacherName";
            this.gcolTeacherName.Name = "gcolTeacherName";
            this.gcolTeacherName.Visible = true;
            this.gcolTeacherName.VisibleIndex = 3;
            // 
            // gcolStartDate
            // 
            this.gcolStartDate.Caption = "Ngày BĐ";
            this.gcolStartDate.DisplayFormat.FormatString = "dd/MM/yyyy";
            this.gcolStartDate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.gcolStartDate.FieldName = "StartLearnDate";
            this.gcolStartDate.Name = "gcolStartDate";
            this.gcolStartDate.Visible = true;
            this.gcolStartDate.VisibleIndex = 5;
            // 
            // gcolEndDate
            // 
            this.gcolEndDate.Caption = "Ngày KT";
            this.gcolEndDate.DisplayFormat.FormatString = "dd/MM/yyyy";
            this.gcolEndDate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.gcolEndDate.FieldName = "EndLearnDate";
            this.gcolEndDate.Name = "gcolEndDate";
            this.gcolEndDate.Visible = true;
            this.gcolEndDate.VisibleIndex = 6;
            // 
            // gcolStatus
            // 
            this.gcolStatus.Caption = "Tình Trạng";
            this.gcolStatus.FieldName = "SubjectRegisterStatus";
            this.gcolStatus.Name = "gcolStatus";
            this.gcolStatus.Visible = true;
            this.gcolStatus.VisibleIndex = 4;
            // 
            // gcolExpectStudent
            // 
            this.gcolExpectStudent.Caption = "SL(dự kiến)";
            this.gcolExpectStudent.FieldName = "ExpectedStudentNumber";
            this.gcolExpectStudent.Name = "gcolExpectStudent";
            this.gcolExpectStudent.Visible = true;
            this.gcolExpectStudent.VisibleIndex = 7;
            // 
            // gcolCurrentStudent
            // 
            this.gcolCurrentStudent.Caption = "SL(hiện tại)";
            this.gcolCurrentStudent.FieldName = "CurrentStudentNumber";
            this.gcolCurrentStudent.Name = "gcolCurrentStudent";
            this.gcolCurrentStudent.Visible = true;
            this.gcolCurrentStudent.VisibleIndex = 8;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.checkButton1);
            this.panel1.Controls.Add(this.radioGroupSubjectRegisterSelection);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(839, 23);
            this.panel1.TabIndex = 2;
            // 
            // checkButton1
            // 
            this.checkButton1.Dock = System.Windows.Forms.DockStyle.Left;
            this.checkButton1.Location = new System.Drawing.Point(0, 0);
            this.checkButton1.Name = "checkButton1";
            this.checkButton1.Size = new System.Drawing.Size(75, 23);
            this.checkButton1.TabIndex = 1;
            this.checkButton1.Text = "Làm mới";
            this.checkButton1.CheckedChanged += new System.EventHandler(this.checkButton1_CheckedChanged);
            // 
            // radioGroupSubjectRegisterSelection
            // 
            this.radioGroupSubjectRegisterSelection.Dock = System.Windows.Forms.DockStyle.Right;
            this.radioGroupSubjectRegisterSelection.Location = new System.Drawing.Point(524, 0);
            this.radioGroupSubjectRegisterSelection.Name = "radioGroupSubjectRegisterSelection";
            this.radioGroupSubjectRegisterSelection.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.RadioGroupItem[] {
            new DevExpress.XtraEditors.Controls.RadioGroupItem(0, "Trong cùng Khoa", true, 0),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(1, "Tất cả", true, 1)});
            this.radioGroupSubjectRegisterSelection.Size = new System.Drawing.Size(315, 23);
            this.radioGroupSubjectRegisterSelection.TabIndex = 0;
            this.radioGroupSubjectRegisterSelection.SelectedIndexChanged += new System.EventHandler(this.radioGroupSubjectRegisterSelection_SelectedIndexChanged);
            // 
            // tabNavigationPage22
            // 
            this.tabNavigationPage22.Caption = "Thông tin môn học";
            this.tabNavigationPage22.Controls.Add(this.gcLearnedSubject);
            this.tabNavigationPage22.Controls.Add(this.gcLearningSubject);
            this.tabNavigationPage22.Controls.Add(this.gcRepairLearningSubject);
            this.tabNavigationPage22.Name = "tabNavigationPage22";
            this.tabNavigationPage22.Size = new System.Drawing.Size(839, 265);
            // 
            // gcLearnedSubject
            // 
            this.gcLearnedSubject.Location = new System.Drawing.Point(559, 0);
            this.gcLearnedSubject.MainView = this.gvLearnedSubject;
            this.gcLearnedSubject.Name = "gcLearnedSubject";
            this.gcLearnedSubject.Size = new System.Drawing.Size(280, 287);
            this.gcLearnedSubject.TabIndex = 0;
            this.gcLearnedSubject.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvLearnedSubject});
            // 
            // gvLearnedSubject
            // 
            this.gvLearnedSubject.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn15,
            this.gridColumn16,
            this.gridColumn17,
            this.gridColumn18,
            this.gridColumn19,
            this.gridColumn20,
            this.gridColumn21,
            this.gridColumn24});
            this.gvLearnedSubject.GridControl = this.gcLearnedSubject;
            this.gvLearnedSubject.Name = "gvLearnedSubject";
            this.gvLearnedSubject.OptionsView.ColumnAutoWidth = false;
            this.gvLearnedSubject.OptionsView.ShowGroupPanel = false;
            this.gvLearnedSubject.OptionsView.ShowViewCaption = true;
            this.gvLearnedSubject.ViewCaption = "Các môn đã học";
            // 
            // gridColumn15
            // 
            this.gridColumn15.Caption = "Giáo Viên";
            this.gridColumn15.FieldName = "TeacherName";
            this.gridColumn15.Name = "gridColumn15";
            this.gridColumn15.Visible = true;
            this.gridColumn15.VisibleIndex = 0;
            // 
            // gridColumn16
            // 
            this.gridColumn16.Caption = "Mã môn";
            this.gridColumn16.FieldName = "Code";
            this.gridColumn16.Name = "gridColumn16";
            this.gridColumn16.Visible = true;
            this.gridColumn16.VisibleIndex = 1;
            // 
            // gridColumn17
            // 
            this.gridColumn17.Caption = "Tên Môn";
            this.gridColumn17.FieldName = "Name";
            this.gridColumn17.Name = "gridColumn17";
            this.gridColumn17.Visible = true;
            this.gridColumn17.VisibleIndex = 2;
            // 
            // gridColumn18
            // 
            this.gridColumn18.Caption = "Tổng Tín chỉ";
            this.gridColumn18.FieldName = "TotalCredits";
            this.gridColumn18.Name = "gridColumn18";
            this.gridColumn18.Visible = true;
            this.gridColumn18.VisibleIndex = 3;
            // 
            // gridColumn19
            // 
            this.gridColumn19.Caption = "TC.Lí Thuyết";
            this.gridColumn19.FieldName = "TheoryCredit";
            this.gridColumn19.Name = "gridColumn19";
            this.gridColumn19.Visible = true;
            this.gridColumn19.VisibleIndex = 4;
            // 
            // gridColumn20
            // 
            this.gridColumn20.Caption = "TC.Thực Hành";
            this.gridColumn20.FieldName = "PracticeCredit";
            this.gridColumn20.Name = "gridColumn20";
            this.gridColumn20.Visible = true;
            this.gridColumn20.VisibleIndex = 5;
            // 
            // gridColumn21
            // 
            this.gridColumn21.Caption = "Năm học";
            this.gridColumn21.FieldName = "SchoolYearName";
            this.gridColumn21.Name = "gridColumn21";
            this.gridColumn21.Visible = true;
            this.gridColumn21.VisibleIndex = 6;
            // 
            // gridColumn24
            // 
            this.gridColumn24.Caption = "Tình trạng";
            this.gridColumn24.FieldName = "SubjectRegisterStatus";
            this.gridColumn24.Name = "gridColumn24";
            this.gridColumn24.Visible = true;
            this.gridColumn24.VisibleIndex = 7;
            // 
            // gcLearningSubject
            // 
            this.gcLearningSubject.ContextMenuStrip = this.contextMenuStripLearningSubject;
            this.gcLearningSubject.Location = new System.Drawing.Point(280, 0);
            this.gcLearningSubject.MainView = this.gvLearningsubject;
            this.gcLearningSubject.Name = "gcLearningSubject";
            this.gcLearningSubject.Size = new System.Drawing.Size(280, 287);
            this.gcLearningSubject.TabIndex = 0;
            this.gcLearningSubject.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvLearningsubject});
            // 
            // contextMenuStripLearningSubject
            // 
            this.contextMenuStripLearningSubject.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.xemThờiKhóaBiểuToolStripMenuItem,
            this.xemChiTiếtToolStripMenuItem,
            this.đóngMônHọcToolStripMenuItem});
            this.contextMenuStripLearningSubject.Name = "contextMenuStripLearningSubject";
            this.contextMenuStripLearningSubject.Size = new System.Drawing.Size(178, 70);
            this.contextMenuStripLearningSubject.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStripLearningSubject_Opening);
            // 
            // xemThờiKhóaBiểuToolStripMenuItem
            // 
            this.xemThờiKhóaBiểuToolStripMenuItem.Name = "xemThờiKhóaBiểuToolStripMenuItem";
            this.xemThờiKhóaBiểuToolStripMenuItem.Size = new System.Drawing.Size(177, 22);
            this.xemThờiKhóaBiểuToolStripMenuItem.Text = "Xem thời khóa biểu";
            this.xemThờiKhóaBiểuToolStripMenuItem.Click += new System.EventHandler(this.xemThờiKhóaBiểuToolStripMenuItem_Click);
            // 
            // xemChiTiếtToolStripMenuItem
            // 
            this.xemChiTiếtToolStripMenuItem.Name = "xemChiTiếtToolStripMenuItem";
            this.xemChiTiếtToolStripMenuItem.Size = new System.Drawing.Size(177, 22);
            this.xemChiTiếtToolStripMenuItem.Text = "Xem liên kết";
            this.xemChiTiếtToolStripMenuItem.Click += new System.EventHandler(this.xemChiTiếtToolStripMenuItem_Click);
            // 
            // đóngMônHọcToolStripMenuItem
            // 
            this.đóngMônHọcToolStripMenuItem.Name = "đóngMônHọcToolStripMenuItem";
            this.đóngMônHọcToolStripMenuItem.Size = new System.Drawing.Size(177, 22);
            this.đóngMônHọcToolStripMenuItem.Text = "Đóng môn học";
            this.đóngMônHọcToolStripMenuItem.Click += new System.EventHandler(this.đóngMônHọcToolStripMenuItem_Click);
            // 
            // gvLearningsubject
            // 
            this.gvLearningsubject.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn8,
            this.gridColumn9,
            this.gridColumn10,
            this.gridColumn11,
            this.gridColumn12,
            this.gridColumn13,
            this.gridColumn14,
            this.gridColumn23});
            this.gvLearningsubject.GridControl = this.gcLearningSubject;
            this.gvLearningsubject.Name = "gvLearningsubject";
            this.gvLearningsubject.OptionsView.ColumnAutoWidth = false;
            this.gvLearningsubject.OptionsView.ShowGroupPanel = false;
            this.gvLearningsubject.OptionsView.ShowViewCaption = true;
            this.gvLearningsubject.ViewCaption = "Các môn đang học";
            this.gvLearningsubject.PopupMenuShowing += new DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventHandler(this.gvLearningsubject_PopupMenuShowing);
            // 
            // gridColumn8
            // 
            this.gridColumn8.Caption = "Giáo Viên";
            this.gridColumn8.FieldName = "TeacherName";
            this.gridColumn8.Name = "gridColumn8";
            this.gridColumn8.Visible = true;
            this.gridColumn8.VisibleIndex = 0;
            // 
            // gridColumn9
            // 
            this.gridColumn9.Caption = "Mã môn";
            this.gridColumn9.FieldName = "Code";
            this.gridColumn9.Name = "gridColumn9";
            this.gridColumn9.Visible = true;
            this.gridColumn9.VisibleIndex = 1;
            // 
            // gridColumn10
            // 
            this.gridColumn10.Caption = "Tên Môn";
            this.gridColumn10.FieldName = "Name";
            this.gridColumn10.Name = "gridColumn10";
            this.gridColumn10.Visible = true;
            this.gridColumn10.VisibleIndex = 2;
            // 
            // gridColumn11
            // 
            this.gridColumn11.Caption = "Tổng Tín chỉ";
            this.gridColumn11.FieldName = "TotalCredits";
            this.gridColumn11.Name = "gridColumn11";
            this.gridColumn11.Visible = true;
            this.gridColumn11.VisibleIndex = 3;
            // 
            // gridColumn12
            // 
            this.gridColumn12.Caption = "TC.Lí Thuyết";
            this.gridColumn12.FieldName = "TheoryCredit";
            this.gridColumn12.Name = "gridColumn12";
            this.gridColumn12.Visible = true;
            this.gridColumn12.VisibleIndex = 4;
            // 
            // gridColumn13
            // 
            this.gridColumn13.Caption = "TC.Thực Hành";
            this.gridColumn13.FieldName = "PracticeCredit";
            this.gridColumn13.Name = "gridColumn13";
            this.gridColumn13.Visible = true;
            this.gridColumn13.VisibleIndex = 5;
            // 
            // gridColumn14
            // 
            this.gridColumn14.Caption = "Năm học";
            this.gridColumn14.FieldName = "SchoolYearName";
            this.gridColumn14.Name = "gridColumn14";
            this.gridColumn14.Visible = true;
            this.gridColumn14.VisibleIndex = 6;
            // 
            // gridColumn23
            // 
            this.gridColumn23.Caption = "Tình trạng";
            this.gridColumn23.FieldName = "SubjectRegisterStatus";
            this.gridColumn23.Name = "gridColumn23";
            this.gridColumn23.Visible = true;
            this.gridColumn23.VisibleIndex = 7;
            // 
            // gcRepairLearningSubject
            // 
            this.gcRepairLearningSubject.ContextMenuStrip = this.contextMenuStripRepairLearningSubject;
            this.gcRepairLearningSubject.Location = new System.Drawing.Point(0, 0);
            this.gcRepairLearningSubject.MainView = this.gvRepairLearningSubject;
            this.gcRepairLearningSubject.Name = "gcRepairLearningSubject";
            this.gcRepairLearningSubject.Size = new System.Drawing.Size(280, 287);
            this.gcRepairLearningSubject.TabIndex = 0;
            this.gcRepairLearningSubject.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvRepairLearningSubject});
            // 
            // gvRepairLearningSubject
            // 
            this.gvRepairLearningSubject.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn3,
            this.gridColumn1,
            this.gridColumn2,
            this.gridColumn4,
            this.gridColumn5,
            this.gridColumn6,
            this.gridColumn7,
            this.gridColumn22});
            this.gvRepairLearningSubject.GridControl = this.gcRepairLearningSubject;
            this.gvRepairLearningSubject.Name = "gvRepairLearningSubject";
            this.gvRepairLearningSubject.OptionsView.ColumnAutoWidth = false;
            this.gvRepairLearningSubject.OptionsView.ShowGroupPanel = false;
            this.gvRepairLearningSubject.OptionsView.ShowHorizontalLines = DevExpress.Utils.DefaultBoolean.True;
            this.gvRepairLearningSubject.OptionsView.ShowViewCaption = true;
            this.gvRepairLearningSubject.ViewCaption = "Các môn đang chờ học";
            this.gvRepairLearningSubject.PopupMenuShowing += new DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventHandler(this.gvRepairLearningSubject_PopupMenuShowing);
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "Giáo Viên";
            this.gridColumn3.FieldName = "TeacherName";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 2;
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "Mã môn";
            this.gridColumn1.FieldName = "Code";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 0;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "Tên Môn";
            this.gridColumn2.FieldName = "Name";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 1;
            // 
            // gridColumn4
            // 
            this.gridColumn4.Caption = "Tổng Tín chỉ";
            this.gridColumn4.FieldName = "TotalCredits";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 3;
            // 
            // gridColumn5
            // 
            this.gridColumn5.Caption = "TC.Lí Thuyết";
            this.gridColumn5.FieldName = "TheoryCredit";
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.Visible = true;
            this.gridColumn5.VisibleIndex = 4;
            // 
            // gridColumn6
            // 
            this.gridColumn6.Caption = "TC.Thực Hành";
            this.gridColumn6.FieldName = "PracticeCredit";
            this.gridColumn6.Name = "gridColumn6";
            this.gridColumn6.Visible = true;
            this.gridColumn6.VisibleIndex = 5;
            // 
            // gridColumn7
            // 
            this.gridColumn7.Caption = "Năm học";
            this.gridColumn7.FieldName = "SchoolYearName";
            this.gridColumn7.Name = "gridColumn7";
            this.gridColumn7.Visible = true;
            this.gridColumn7.VisibleIndex = 6;
            // 
            // gridColumn22
            // 
            this.gridColumn22.Caption = "Tình trạng";
            this.gridColumn22.FieldName = "SubjectRegisterStatus";
            this.gridColumn22.Name = "gridColumn22";
            this.gridColumn22.Visible = true;
            this.gridColumn22.VisibleIndex = 7;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(693, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(145, 149);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 14;
            this.pictureBox1.TabStop = false;
            // 
            // UserControlSubjectRegister
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.splitContainer1);
            this.Name = "UserControlSubjectRegister";
            this.Size = new System.Drawing.Size(857, 525);
            this.Load += new System.EventHandler(this.UserControlSubjectRegister_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl22)).EndInit();
            this.groupControl22.ResumeLayout(false);
            this.groupControl22.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl21)).EndInit();
            this.groupControl21.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl17)).EndInit();
            this.groupControl17.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl18)).EndInit();
            this.groupControl18.ResumeLayout(false);
            this.groupControl18.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl19)).EndInit();
            this.groupControl19.ResumeLayout(false);
            this.groupControl19.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl20)).EndInit();
            this.groupControl20.ResumeLayout(false);
            this.groupControl20.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl13)).EndInit();
            this.groupControl13.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl14)).EndInit();
            this.groupControl14.ResumeLayout(false);
            this.groupControl14.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl16)).EndInit();
            this.groupControl16.ResumeLayout(false);
            this.groupControl16.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl15)).EndInit();
            this.groupControl15.ResumeLayout(false);
            this.groupControl15.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl12)).EndInit();
            this.groupControl12.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl10)).EndInit();
            this.groupControl10.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl11)).EndInit();
            this.groupControl11.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tbxExpectNumber)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl3)).EndInit();
            this.groupControl3.ResumeLayout(false);
            this.groupControl3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl9)).EndInit();
            this.groupControl9.ResumeLayout(false);
            this.groupControl9.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl8)).EndInit();
            this.groupControl8.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).EndInit();
            this.groupControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl5)).EndInit();
            this.groupControl5.ResumeLayout(false);
            this.groupControl5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl7)).EndInit();
            this.groupControl7.ResumeLayout(false);
            this.groupControl7.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl6)).EndInit();
            this.groupControl6.ResumeLayout(false);
            this.groupControl6.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl4)).EndInit();
            this.groupControl4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tabPane1)).EndInit();
            this.tabPane1.ResumeLayout(false);
            this.tabNavigationPage1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gcSubjectRegister)).EndInit();
            this.contextMenuStripRepairLearningSubject.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gvSubjectRegister)).EndInit();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.radioGroupSubjectRegisterSelection.Properties)).EndInit();
            this.tabNavigationPage22.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gcLearnedSubject)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvLearnedSubject)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcLearningSubject)).EndInit();
            this.contextMenuStripLearningSubject.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gvLearningsubject)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcRepairLearningSubject)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvRepairLearningSubject)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.ComboBox cbxTeacher;
        private SimpleButton btnCreateSubjectRegister;
        private System.Windows.Forms.CheckBox ckbNotify;
        private System.Windows.Forms.ToolTip toolTip1;
        private GroupControl groupControl3;
        private System.Windows.Forms.TextBox tbxDiligence;
        private System.Windows.Forms.TextBox tbxSemiFinal;
        private System.Windows.Forms.TextBox tbxFinal;
        private System.Windows.Forms.TextBox tbxCreditPractice;
        private System.Windows.Forms.TextBox tbxCreditTheory;
        private System.Windows.Forms.TextBox tbxCreditTotal;
        private System.Windows.Forms.TextBox tbxSubjectName;
        private System.Windows.Forms.Label label6;
        private GroupControl groupControl2;
        private System.Windows.Forms.TextBox tbxClassName;
        private GroupControl groupControl1;
        private System.Windows.Forms.ComboBox cbxSchoolYearCode;
        private DevExpress.XtraBars.Navigation.TabPane tabPane1;
        private DevExpress.XtraBars.Navigation.TabNavigationPage tabNavigationPage1;
        private GridControl gcSubjectRegister;
        private GridView gvSubjectRegister;
        private GridColumn gcolCode;
        private GridColumn gcolSubjectName;
        private GridColumn gcolTeacherCode;
        private GridColumn gcolTeacherName;
        private GridColumn gcolStartDate;
        private GridColumn gcolEndDate;
        private GridColumn gcolStatus;
        private GridColumn gcolExpectStudent;
        private GridColumn gcolCurrentStudent;
        private DevExpress.XtraBars.Navigation.TabNavigationPage tabNavigationPage22;
        private GridControl gcLearnedSubject;
        private GridView gvLearnedSubject;
        private GridControl gcLearningSubject;
        private GridView gvLearningsubject;
        private GridControl gcRepairLearningSubject;
        private GridView gvRepairLearningSubject;
        private GroupControl groupControl9;
        private GroupControl groupControl8;
        private GroupControl groupControl5;
        private GroupControl groupControl7;
        private System.Windows.Forms.TextBox tbxSpecialize;
        private GroupControl groupControl6;
        private System.Windows.Forms.TextBox tbxDepartment;
        private GroupControl groupControl4;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripLearningSubject;
        private System.Windows.Forms.ToolStripMenuItem đóngMônHọcToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripRepairLearningSubject;
        private System.Windows.Forms.ToolStripMenuItem tạoThờiKhóaBiểuToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem xemThờiKhóaBiểuToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem xemThờiKhóaBiểuToolStripMenuItem1;
        private System.Windows.Forms.ComboBox cbxSubject;
        private System.Windows.Forms.ComboBox cbxClass;
        private GridColumn gridColumn1;
        private GridColumn gridColumn2;
        private GridColumn gridColumn3;
        private GridColumn gridColumn8;
        private GridColumn gridColumn4;
        private GridColumn gridColumn5;
        private GridColumn gridColumn6;
        private GridColumn gridColumn7;
        private GridColumn gridColumn9;
        private GridColumn gridColumn10;
        private GridColumn gridColumn11;
        private GridColumn gridColumn12;
        private GridColumn gridColumn13;
        private GridColumn gridColumn14;
        private GridColumn gridColumn15;
        private GridColumn gridColumn16;
        private GridColumn gridColumn17;
        private GridColumn gridColumn18;
        private GridColumn gridColumn19;
        private GridColumn gridColumn20;
        private GridColumn gridColumn21;
        private System.Windows.Forms.ToolStripMenuItem xemChiTiếtToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mởKhóaHọcToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tạoLịchHọcToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cậpNhậtĐangHọcToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem xemLiênKếtToolStripMenuItem1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel1;
        private RadioGroup radioGroupSubjectRegisterSelection;
        private GridColumn gridColumn24;
        private GridColumn gridColumn23;
        private GridColumn gridColumn22;
        private GroupControl groupControl12;
        private GroupControl groupControl14;
        private GroupControl groupControl13;
        private GroupControl groupControl16;
        private GroupControl groupControl15;
        private GroupControl groupControl10;
        private GroupControl groupControl11;
        private GroupControl groupControl21;
        private GroupControl groupControl17;
        private GroupControl groupControl18;
        private GroupControl groupControl19;
        private GroupControl groupControl20;
        private GroupControl groupControl22;
        private System.Windows.Forms.ToolStripMenuItem thêmLớpHọcToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem đóngMônHọcToolStripMenuItem1;
        private CheckButton checkButton1;
        private System.Windows.Forms.NumericUpDown tbxExpectNumber;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}
