using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ServiceCore.Models.Base;
using ServiceCore.Models.Subject;
using ServiceCore.DataAccess;
using ServiceCore.Models;
using ServiceCore.Models.User;
using Monitor2.Model;
using DevExpress.XtraGrid.Views.Grid;
using VDSoLienLac.Hubs;
using Newtonsoft.Json;
using Microsoft.AspNet.SignalR.Client;
using DevExpress.XtraEditors;
using VD.Datalayer.DataObject;
using VD.Utility;
using Firebase.Database;

namespace Monitor2
{
    public partial class UserControlSubjectRegister : UserControl,ICallBackArg
    {
        private SubjectRegisterModel currentObj;
        SubjectDAO subjectDAO = new SubjectDAO();
        ClassDAO classDAO = new ClassDAO();
        TeacherDAO teacherDAO = new TeacherDAO();
        private CCoreDao db = new CCoreDao();
        private GenerateData Render = new GenerateData();
        static SignalRHelper _helper;
        public static UserControlSubjectRegister _instance;
        public static List<ClassModel> classList = null;
        public static SubjectRegisterModel currentSubjectItem = null;

        public UserControlSubjectRegister()
        {
            InitializeComponent();
            classList = ClassModel.GetInstance().GetClassList();
        }

        public void ReloadCurrentItem()
        {
            cbxClass.SelectedItem = cbxClass.SelectedIndex;
        }

        private void UserControlSubjectRegister_Load(object sender, EventArgs e)
        {
            _instance = this;
            //cbxClassCode.DataSource = CacheCore.mClassList.Select(x => x.Code).ToList();
            BindingCbxSchoolYearItems();
            BindingCbxClassCode();

         //   GetReloadSubjectRegister();
          
            var task = Task.Run(async () => {
                _helper = SignalRHelper.GetInstance();
            });
        }

        private void BindingCbxClassCode()
        {
            //var m = new ItemsModel() { Text = "-- Tổng quan khóa học --", Value = 0 };
            //cbxClassCode.Items.Add(m);
            //cbxClassCode.SelectedIndex = 0;
            //for (int i = 0; i < CacheCore.mClassList.Count; i++)
            //{
            //    ItemsModel itemBound = new ItemsModel();
            //    itemBound.Text = CacheCore.mClassList[i].Code;
            //    itemBound.Value = CacheCore.mClassList[i].ID;
            //    cbxClassCode.Items.Add(itemBound);
            //}
            AddComboBoxItems<ClassModel>(cbxClass, classList);
            //cbxClassCode.Items.AddRange(classList.ToArray());
            //cbxClassCode.SelectedIndex = 0;
        }

        private void BindingCbxSchoolYearItems()
        {
            var resultList = SchoolYearModel.GetInstance().GetAll();
            //cbxSchoolYearCode.Items.AddRange(resultList.ToArray());
            //cbxSchoolYearCode.SelectedIndex = 0;
            AddComboBoxItems<SchoolYearModel>(cbxSchoolYearCode, resultList);
        }

        private void BindingCbxTeacherItems(int classid)
        {
            //for(int i = 0; i < CacheCore.mTeacherList.Count; i++)
            //{
            //    ItemsModel itemBound = new ItemsModel();
            //    itemBound.Text = CacheCore.mTeacherList[i].Name;
            //    itemBound.Value = CacheCore.mTeacherList[i].ID;
            //    cbxTeacher.Items.Add(itemBound);
            //}
            var resultList = TeacherModel.GetInstance().GetTeacherbySpecialize(classid);
            AddComboBoxItems<TeacherModel>(cbxTeacher, resultList);
        
        }

        private void BindingCbxSubjectItems(int classid)
        {
            var notlearnList = SubjectModel.GetInstance().GetNotLearnList(classid);
            AddComboBoxItems<SubjectModel>(cbxSubject, notlearnList);
            if(cbxSubject.Items.Count > 0)
            {
                DisplaySubjetText(cbxSubject.SelectedItem as SubjectModel);
            }
            else
            {
                ClearSubjectText();
            }
        }

        public void GetReloadSubjectRegister()
        {
            //DisplayText();
            //var selectedCode = cbxClassCode.SelectedItem as ItemsModel;
            //var valudId = Int32.Parse(selectedCode.Value.ToString());
            //gvSubjectRegister.ViewCaption = GetGridViewTitle(valudId,selectedCode.Text);
            //SubjectRegisterGridFixed(valudId);
            //var resultList = LoadSubjectRegister(CacheCore.UserID, "EMPL", valudId);
            //gcSubjectRegister.DataSource = resultList;
            //gvSubjectRegister.BestFitColumns();
            //gvSubjectRegister.FocusedRowHandle = resultList.Count - 1;
            //var row = gvSubjectRegister.GetFocusedRow();
            //if (row != null)
            //{
            //    currentObj = (SubjectRegisterModel)row;
                
            //    cbxSubjectCode.Text = "";
            //    cbxSubjectCode.Text = CacheCore.mSubjectList.FirstOrDefault(x => x.Code == currentObj.Code).Code;
            //    ReloadSubject();
            //    ReloadTeacher();
            //    LoadSChoolYear(currentObj.SchoolYearID);
            //}
            //else
            //{
            //    cbxSubjectCode.Text = "";
            //    cbxTeacher.Text = "";
            //    ClearSubjectText();
            //    ClearConfigSubjectRegister();
            //}
            //if(selectedCode.Value.ToString() == "0")
            //{
            //    tbxClassName.Text = "";
            //}
        }

        private void SubjectRegisterGridFixed(int type)
        {
            if(type == 0)
            {
                gvSubjectRegister.Columns[6].FieldName = "SubjectRegisterStatus";
                gvSubjectRegister.Columns[6].Caption = "Tình trạng khóa học";
                gvSubjectRegister.Columns[4].FieldName = "CreatedDate";
                gvSubjectRegister.Columns[4].Caption = "Ngày tạo";
                gvSubjectRegister.Columns[4].Visible = true;
                gvSubjectRegister.Columns[5].Visible = false;
            }
            else
            {
                gvSubjectRegister.Columns[6].FieldName = "MasterTimeTableStatusCode";
                gvSubjectRegister.Columns[6].Caption = "Tình trạng lớp học";
                gvSubjectRegister.Columns[4].Visible = false;
                gvSubjectRegister.Columns[5].Visible = false;
            }
        }

        private void FixedButtonByStatus(SubjectRegisterModel model)
        {
            //if(model.MasterTimeTableID > 0)
            //{
            //    btnOpenSubjectRegister.Enabled = true;
            //    if (model.MasterTimeTableID == 1)
            //        btnOpenSubjectRegister.Text = "Mở đăng kí";
            //    else if (model.MasterTimeTableID == 2)
            //        btnOpenSubjectRegister.Text = "Mở lịch học";
            //    else if (model.MasterTimeTableID == 2)
            //        btnOpenSubjectRegister.Text = "Đóng môn học";
            //}
            //else
            //{
            //    btnOpenSubjectRegister.Enabled = false;
            //}
            //switch (status)
            //{
            //    case 0:
            //        {
            //            btnOpenSubjectRegister.Text = "Mở đăng kí";
            //            break;
            //        }
            //    case 1:
            //        {
            //            btnOpenSubjectRegister.Text = "Mở lớp học";
            //            break;
            //        }
            //    case 2:
            //        {
            //            btnOpenSubjectRegister.Text = "Đóng môn học";
            //            break;
            //        }
            //}
        }

        private List<SubjectRegisterModel> LoadSubjectRegister(string userid,string context,int classid)
        {
            BaseResponseModel<object> baseResponse = subjectDAO.GetSubjectRegister(userid, context, classid);
            var listRegister = (List<SubjectRegisterModel>)baseResponse.ResponseData;
            return listRegister;
        }

        private void DisplayText()
        {
            //var classModel = CacheCore.mClassList.FirstOrDefault(x => x.Code == cbxClassCode.Text.ToString());
            //if(classModel != null)
            //{
            //    tbxClassName.Text = classModel.Name;
            //    var CareerName = CacheCore.mCareerList.FirstOrDefault(x => x.ID == classModel.CareerID).Name;
            //    tbxCareer.Text = CareerName;
            //    var SchoolName = CacheCore.mSchoolYearList.FirstOrDefault(x => x.ID == classModel.SchoolYearID);
            //}
        }

        private void GcSubjectRegister_Click(object sender, EventArgs e)
        {

        }

        private void cbxClassCode_SelectedValueChanged(object sender, EventArgs e)
        {
            GetReloadSubjectRegister();
        }

        private void cbxSubjectCode_SelectedValueChanged(object sender, EventArgs e)
        {
            ReloadSubject();
        }

        private void ReloadSubject()
        {
            var subjectcode = cbxSubject.Text.ToString();
            if(subjectcode.Length > 0)
            {
                var subjectModel = CacheCore.mSubjectList.FirstOrDefault(x => x.Code == subjectcode);
                tbxSubjectName.Text = subjectModel.Name;
                tbxCreditTotal.Text = subjectModel.TotalCredits.ToString();
                tbxCreditTheory.Text = subjectModel.TheoryCredit.ToString();
                tbxCreditPractice.Text = subjectModel.PracticeCredit.ToString();
                tbxFinal.Text = subjectModel.FinalEvaluationPercent.ToString();
                tbxSemiFinal.Text = subjectModel.SemiFinalEvaluationPercent.ToString();
                tbxDiligence.Text = subjectModel.DiligencePercent.ToString();
            }
            else
            {
                ClearSubjectText();
            }
        }

        private void BtnCreateSubjectRegister_Click(object sender, EventArgs e)
        {
            //var boundTeacherItem = cbxTeacher.SelectedItem as ItemsModel;
            //SubjectRegisterModel model = new SubjectRegisterModel();
            //model.TeacherID = boundTeacherItem.Value.ToString();
            //model.StartLearnDate = DateTime.Parse(dtpStartDate.Text.ToString());
            //model.EndLearnDate = DateTime.Parse(dtpEndDate.Text.ToString());
            //var boundSubjectItem = cbxSubjectCode.SelectedItem as ItemsModel;
            //model.SubjectID = Int32.Parse(boundSubjectItem.Value.ToString());
            //model.ExpectedStudentNumber = Int32.Parse(tbxExpectNumber.Text.ToString());
            //var boundSchoolYearItem = cbxSchoolYearCode.SelectedItem as ItemsModel;
            //model.SchoolYearID = Int32.Parse(boundSchoolYearItem.Value.ToString());
            //BaseResponseModel<object> baseResponse = subjectDAO.CreateSubjectRegister(model);
            //MessageBox.Show(baseResponse.ResponseMessage);
            //if (baseResponse.Result > 0)
            //{
            //    cbxClassCode.SelectedIndex = 0;
            //    GetReloadSubjectRegister();
            //}
            //var boundSchoolYearItem = cbxSchoolYearCode.SelectedItem as ItemsModel;
            //var boundTeacherItem = cbxTeacher.SelectedItem as ItemsModel;
            //NewCoursefrm newCoursefrm = new NewCoursefrm(cbxSubjectCode.Text, Int32.Parse(boundSchoolYearItem.Value.ToString()),Int32.Parse(tbxExpectNumber.Text), boundTeacherItem.Value.ToString());
            //newCoursefrm.ShowDialog();
            if((cbxSubject.SelectedItem as SubjectModel).Piority > 1)
            {
                if (!SubjectModel.GetInstance().CheckExistLowPioritySubject((cbxClass.SelectedItem as ClassModel).ID))
                {
                    DialogResult dialogResult = MessageBox.Show("Vẫn còn có môn học cơ bản chưa được mở. \n Bạn có chắc mở môn học nâng cao này ?", "Cảnh báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                    if(dialogResult == DialogResult.Cancel)
                    {
                        return;
                    }
                }
            }

            MasterTimeTableModel model = new MasterTimeTableModel();
            model.SubjectID = (cbxSubject.SelectedItem as SubjectModel).ID;
            model.SchoolYearID = (cbxSchoolYearCode.SelectedItem as SchoolYearModel).ID;
            model.TeacherID = (cbxTeacher.SelectedItem as TeacherModel).ID;
            model.ClassID = (cbxClass.SelectedItem as ClassModel).ID;
            model.ExpectedNumber = Int32.Parse(tbxExpectNumber.Value.ToString());
            var result = subjectDAO.AddMasterTimeTable(model);
            if(result.Result > 0)
            {
                BindingCbxSubjectItems((cbxClass.SelectedItem as ClassModel).ID);
                LoadTripleList((cbxClass.SelectedItem as ClassModel).ID, (cbxSchoolYearCode.SelectedItem as SchoolYearModel).ID);
                //DialogResult dialogResult = MessageBox.Show("Tạo khóa học thành công!. \n Bạn có muốn tạo ngay thời khóa biểu ?", "Chuyển hướng", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                //if (dialogResult == DialogResult.OK)
                //{
                    
                //}
            }
        }

        private void cbxSubject_SelectedIndexChanged(object sender, EventArgs e)
        {
            DisplaySubjetText(cbxSubject.SelectedItem as SubjectModel);
        }

        private void BtnOpenSubjectRegister_Click(object sender, EventArgs e)
        {
            string subject = "",body="";
            XtraMessageBoxArgs messageArgs = new XtraMessageBoxArgs();
            messageArgs.Caption = "Thông báo";
            if(currentObj == null)
            {
                return;
            }
            if (currentObj.MasterTimeTableID == 0)
            {
                messageArgs.Text = "Bạn chắc chắn muốn đóng khóa học này chứ ?";
            }
            else
            {
                messageArgs.Text = "Bạn chắc chắn muốn thay đổi tình trạng cho lớp học này chứ ?";
            }

           

            messageArgs.Buttons = new DialogResult[] { DialogResult.OK, DialogResult.Cancel };
            var xMessage = XtraMessageBox.Show(messageArgs);
            switch (xMessage)
            {
                case DialogResult.OK:
                    {
                        BaseResponseModel<object> mResp = null;
                        if (currentObj.MasterTimeTableID == 0)
                        {
                            mResp = subjectDAO.UpdateSubjectRegisterStatus(CacheCore.UserID, currentObj.ID, -1, "SUBJECT");
                        }
                        else
                        {
                            var mStatus = currentObj.MasterTimeTableStatusID;
                            if(mStatus > 0)
                            {
                                if(mStatus == 1)
                                {
                                    subject = "[VDADMIN]: Môn hoc mới";
                                    body = string.Format("{0} hiện tại đã mở cho các bạn sinh viên của lớp {1} đăng kí. Hãy nhanh chóng đăng kí trước khi hết thời hạn!", tbxSubjectName.Text, cbxClass.SelectedText);
                                    mStatus = 2;
                                }
                                else if(mStatus == 2)
                                {
                                    mStatus = 3;
                                }
                                else if (mStatus == 3)
                                {
                                    mStatus = -1;
                                }
                                mResp = subjectDAO.UpdateSubjectRegisterStatus(CacheCore.UserID, currentObj.MasterTimeTableID, mStatus, "MASTER");
                            }
                        }
                        if (mResp.Result > 0)
                        {
                            GetReloadSubjectRegister();
                        }
                        break;
                    }
                case DialogResult.Cancel:
                    {
                        break;
                    }
            }

            initSendNotice(subject, body);


            //var status = currentObj.StatusID;
            //switch (status)
            //{
            //    case 0:
            //        {
            //            if (ckbNotify.Checked == true)
            //            {
            //                SendSignalMessage(0, StandardMessage.openSubjectTitle, StandardMessage.openSubjectBody, StandardMessage.openSubjectContent, cbxClassCode.Text);
            //            }
            //            status = 1;
            //            break;
            //        }
            //    case 1:
            //        {
            //            status = 2;
            //            break;
            //        }
            //    case 2:
            //        {
            //            if (ckbNotify.Checked == true)
            //            {
            //                SendSignalMessage(0, StandardMessage.closeSubjectTitle, StandardMessage.closeSubjectBody, StandardMessage.closeSubjectContent, cbxClassCode.Text);
            //            }
            //            status = -1;
            //            break;
            //        }
            //    default: break;
            //}

            //BaseResponseModel<object> baseResponse = subjectDAO.UpdateSubjectRegisterStatus(CacheCore.UserID, currentObj.ID, status);
            //MessageBox.Show(baseResponse.ResponseMessage);
            //if (baseResponse.Result > 0)
            //{
            //    GetReloadSubjectRegister();
            //}
        }

       public void initSendNotice(string subject, string body)
        {
            //if (currentObj.MasterTimeTableID > 0 && ckbNotify.Checked)
            //{
            //    //Task.Run(async () => {

            //    //});
            //    var id = SetNotifyMasterRow(subject, body, 0);
            //    if (id > 0)
            //    {
            //        var classid = ((ItemsModel)cbxClass.SelectedItem).Value;
            //        var mList = GetSutdentInSection(0,classid.ToString());
            //        foreach (var item in mList)
            //        {
            //            var mResult = SetNotifyDetailRow(id, item.ID,"");
            //            SendSectionNotice(subject, body, 0, item.ID, mResult);
                        
            //            if (mResult < 0)
            //            {
            //                break;
            //            }
            //        }
            //    }
            //}
        }

        private void GvSubjectRegister_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            GridView view = sender as GridView;
            var row = view.GetFocusedRow();
            if(row != null)
            {
                currentObj = (SubjectRegisterModel)row;
                FixedButtonByStatus(currentObj);
                cbxSubject.Text = "";
                cbxSubject.Text = CacheCore.mSubjectList.FirstOrDefault(x => x.Code == currentObj.Code).Code;
                ReloadSubject();
            }
        }

        private void tạoTKBToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //TimeTable timeTable = new TimeTable(currentObj.ID,currentObj.StartLearnDate,currentObj.EndLearnDate,tbxSubjectName.Text.ToString(),cbxSubjectCode.Text);
            //timeTable.Show();
            if(currentObj.StatusID == 0)
            {
                var boundSchoolYearItem = cbxSchoolYearCode.SelectedItem as ItemsModel;
                var boundTeacherItem = cbxTeacher.SelectedItem as ItemsModel;
                //NewCoursefrm newCoursefrm = new NewCoursefrm(cbxSubject.Text, cbxTeacher.Text, currentObj.ID);
                //newCoursefrm.ShowDialog();
            }
            else {
                XtraMessageBoxArgs args = new XtraMessageBoxArgs();
                args.Caption = "Thông báo";
                args.Text = "Khóa học này đã tồn tại TKB";
                args.Showing += Args_Showing;
                XtraMessageBox.Show(args).ToString();
            }
        }

        private void Args_Showing(object sender, XtraMessageShowingArgs e)
        {
            //bold message caption 
            e.Form.Appearance.FontStyleDelta = FontStyle.Bold;
            //increased button height and font size 
            MessageButtonCollection buttons = e.Buttons as MessageButtonCollection;
            SimpleButton btn = buttons[System.Windows.Forms.DialogResult.OK] as SimpleButton;
            if (btn != null)
            {
                btn.Appearance.FontSizeDelta = 15;
                btn.Height += 10;
            }
        }

        private void cbxSchoolYearCode_SelectedValueChanged(object sender, EventArgs e)
        {
            var item = CacheCore.mSchoolYearList.FirstOrDefault(x => x.Code == cbxSchoolYearCode.Text);
        }

        //protected void SendSignalMessage(int type,string title,string message,string Content,string obj)
        //{
        //    var jObj = JsonConvert.SerializeObject(new { title = title, message = message, content = Content });
        //    hub.Invoke("sendNotify", 1, jObj, obj,null).Wait();
        //}

        public  void SendSectionNotice(string subject,string body,int type,string key,int id,string path = ".SubjectRegister")
        {
            try
            {
                NotificationModel model = new NotificationModel();
                model.ID = id;
                model.Subject = subject;
                model.Body = body;
                model.Type = type;
                model.Path = path;
                model.ReceiverName = key;
                model.CreateDate = DateTime.Now;
                if(_helper == null)
                {
                    _helper = SignalRHelper.GetInstance();
                }
                 _helper.InvokeMessage("sendNoticeToSpecify", model, key);
                Task firebaseTask = new Task(() => sendFireBase(model));
                firebaseTask.Start();
            }
            catch
            {
                MessageBox.Show("Xảy ra lỗi trong quá trình gửi thông báo! Vui lòng thử lại");
            }
        }

        private void sendFireBase(NotificationModel model)
        {
            var firebaseClient = new FirebaseClient("https://doantn-23158.firebaseio.com/");
            firebaseClient.Child("Notification").PostAsync(model);
        }

        public List<CurrentStudentModel> GetSutdentInSection(int masterid,string classid = "")
        {
            string xml = Render.GenerateXmlFromObject<object>(null, new
            {
                MasterTimetableID = masterid,
                ClassID = classid
            }, "2010", "");
            var ds = db.GetContextData(xml);
            var resp = Render.ResponseMultiObject<CurrentStudentModel>(ds.Tables[0]).ToList();
            return resp;
        }

        public int SetNotifyMasterRow(string subject, string body,int type,string path)
        {
            string xml = Render.GenerateXmlFromObject<object>("INSERT", new
            {
                Subject = subject,
                Body = body,
                Type = type,
                Path = path
            }, "2009", "COMMON");
            var ds = db.ExecuteAction(xml);
            var resp = Render.ResponseObject<BaseDBResult>(ds.Tables[0]);
            return resp.ID;
        }

        public int SetNotifyDetailRow(int masterid,string receiverid,string path)
        {
            string xml = Render.GenerateXmlFromObject<object>("INSERT", new
            {
                DetailID = masterid,
                ReceiverID = receiverid,
                Path = path
            }, "2009", "DETAIL");
            var ds = db.ExecuteAction(xml);
            var resp = Render.ResponseObject<BaseDBResult>(ds.Tables[0]);
            return resp.ID;
        }

        private void xemTKBToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NewTimeTablefrm newTimeTablefrm = new NewTimeTablefrm(currentObj.MasterTimeTableID);
            newTimeTablefrm.ShowDialog();
        }

        private string GetGridViewTitle(int type,string code)
        {
            if(type == 0)
            {
                return string.Format("Danh sách các khóa học đang hiện hành");
            }
            else
            {
                return string.Format("Danh sách các môn học của lớp {0}", code);
            }
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {
            //if(currentObj.MasterTimeTableID == 0)
            //{
            //    if(currentObj.StatusID == 0)
            //    {
            //        contextMenuStrip1.Items[0].Enabled = true;
            //        contextMenuStrip1.Items[1].Enabled = false;
            //        contextMenuStrip1.Items[2].Enabled = false;
            //    }
            //    else if (currentObj.StatusID == 1)
            //    {
            //        contextMenuStrip1.Items[0].Enabled = false;
            //        contextMenuStrip1.Items[1].Enabled = false;
            //        contextMenuStrip1.Items[2].Enabled = true;
            //    }
            //}
            //else
            //{
            //    contextMenuStrip1.Items[0].Enabled = false;
            //    contextMenuStrip1.Items[1].Enabled = true;
            //contextMenuStrip1.Items[2].Enabled = true;
            //}
        }

        private void xemLiênKếtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ConnectivityFrm model = new ConnectivityFrm(currentObj.ID,this);
            model.ShowDialog();
        }

        public void Connectivity_Clicked(int classid)
        {
            //var list = cbxClass.Items.Cast<ItemsModel>().ToList();
            //var item = list.FirstOrDefault(x => Int32.Parse(x.Value.ToString()) == classid);
            //if(item != null)
            //{
            //    cbxClass.SelectedItem = item;
            //}
            for(int i = 0; i < cbxClass.Items.Count;i++)
            {
                var current = cbxClass.Items[i] as ClassModel;
                if(current.ID == classid)
                {
                    cbxClass.SelectedIndex = i;
                    return;
                }
            }
        }

        private void cbxSubjectCode_DrawItem(object sender, DrawItemEventArgs e)
        {
            //if (e.Index < 0) { return; } // added this line thanks to Andrew's comment
            //string text = CacheCore.mSubjectList.FirstOrDefault(x => x.Code == cbxSubjectCode.GetItemText(cbxSubjectCode.Items[e.Index])).Name;
            //e.DrawBackground();
            //using (SolidBrush br = new SolidBrush(e.ForeColor))
            //{ e.Graphics.DrawString(cbxSubjectCode.GetItemText(cbxSubjectCode.Items[e.Index]), e.Font, br, e.Bounds); }
            //if ((e.State & DrawItemState.Selected) == DrawItemState.Selected)
            //{ toolTip1.Show(text, cbxSubjectCode, e.Bounds.Right, e.Bounds.Bottom); }
            //e.DrawFocusRectangle();
        }

        private void cbxSubjectCode_DropDownClosed(object sender, EventArgs e)
        {
            toolTip1.Hide(cbxSubject);
        }

        private void DisplayClassText(ClassModel model)
        {
            tbxClassName.Text = model.Name;
            tbxDepartment.Text = model.DepartmentName;
            tbxSpecialize.Text = model.SpecializeName;
        }

        private void DisplaySubjetText(SubjectModel model)
        {
            tbxSubjectName.Text = model.Name;
            tbxCreditTotal.Text = model.TotalCredits.ToString();
            tbxCreditTheory.Text = model.TheoryCredit.ToString();
            tbxCreditPractice.Text = model.PracticeCredit.ToString();
            tbxFinal.Text = model.FinalEvaluationPercent.ToString();
            tbxSemiFinal.Text = model.SemiFinalEvaluationPercent.ToString();
            tbxDiligence.Text = model.DiligencePercent.ToString();
        }

        private void ClearSubjectText()
        {
            tbxSubjectName.Text = "";
            tbxCreditTotal.Text = "";
            tbxCreditTheory.Text = "";
            tbxCreditPractice.Text = "";
            tbxFinal.Text = "";
            tbxSemiFinal.Text = "";
            tbxDiligence.Text = "";
        }

        private void LoadTripleList(int classid,int schoolyearid)
        {
            //var resultList = LoadSubjectRegister(CacheCore.UserID, "EMPL", classid);
            var resultList = SubjectRegisterModel.GetInstance().GetByClass(classid, schoolyearid);
            gcLearnedSubject.DataSource = resultList.Where(x => x.StatusID == -1);
            gcLearningSubject.DataSource = resultList.Where(x => x.StatusID == 3);
            gcRepairLearningSubject.DataSource = resultList.Where(x => x.StatusID > -1 && x.StatusID < 3);
        }


        private void AddComboBoxItems<T>(System.Windows.Forms.ComboBox cbx, List<T> objects)
        {
            cbx.Items.Clear();
            foreach(var item in objects)
            {
                cbx.Items.Add(item);
            }
            if (cbx.Items.Count > 0)
                cbx.SelectedIndex = 0;
            else
                cbx.Text = "";
        }

        private void cbxClass_SelectedIndexChanged(object sender, EventArgs e)
        {
            var selectedItem = cbxClass.SelectedItem as ClassModel;
            DisplayClassText(selectedItem);
           
            BindingCbxSubjectItems(selectedItem.ID);
            BindingCbxTeacherItems(selectedItem.ID);
            if(tabPane1.SelectedPageIndex == 0)
            {
                radioGroupSubjectRegisterSelection.SelectedIndex = 0;

                var mList = SubjectRegisterModel.GetInstance().GetBySpecialize((cbxClass.SelectedItem as ClassModel).SpecializeID,(cbxSchoolYearCode.SelectedItem as SchoolYearModel).ID);
                gcSubjectRegister.DataSource = mList;
            }
            else
            {
                LoadTripleList(selectedItem.ID, (cbxSchoolYearCode.SelectedItem as SchoolYearModel).ID);
            }
        }

        private void tabPane1_SelectedPageIndexChanged(object sender, EventArgs e)
        {
            if(tabPane1.SelectedPageIndex == 0)
            {
                radioGroupSubjectRegisterSelection.SelectedIndex = 0;
            }
            else
            {
                LoadTripleList((cbxClass.SelectedItem as ClassModel).ID, (cbxSchoolYearCode.SelectedItem as SchoolYearModel).ID);
            }
        }

        private void contextMenuStrip2_Opening(object sender, CancelEventArgs e)
        {

        }

        private void thêmLớpHọcToolStripMenuItem_Click(object sender, EventArgs e)
        {  
            var row = gvSubjectRegister.GetFocusedRow();
            if(row != null)
            {
                var item = cbxClass.SelectedItem as ClassModel;
                var model = (SubjectRegisterModel)row;
                FrmAddClass frmAddClass = new FrmAddClass(model.ID,item.SpecializeID);
                frmAddClass.ShowDialog();
            } 
        }

        private void SetUpSubMenuStrip(ToolStripItem item,SubjectRegisterModel currentObj)
        {
            if (item != null && item is ToolStripMenuItem)
            {
                var owner = ((ToolStripMenuItem)item).DropDownItems;

                foreach (ToolStripItem i in ((ToolStripMenuItem)item).DropDownItems)
                {
                    
                }
                if (owner != null)
                {
                    var row = gvSubjectRegister.GetFocusedRow();
                    switch (currentObj.StatusID)
                    {
                        case 0:
                            {
                                owner[0].Enabled = true;
                                owner[1].Enabled = false;
                                owner[2].Enabled = false;
                                owner[3].Enabled = false;
                                break;
                            }
                        case 1:
                            {
                                owner[0].Enabled = false;
                                owner[1].Enabled = true;
                                owner[2].Enabled = false;
                                owner[3].Enabled = false;
                                break;
                            }
                        case 2:
                            {
                                owner[0].Enabled = false;
                                owner[1].Enabled = false;
                                owner[2].Enabled = true;
                                owner[3].Enabled = false;
                                break;
                            }
                        case 3:
                            {
                                owner[0].Enabled = false;
                                owner[1].Enabled = false;
                                owner[2].Enabled = false;
                                owner[3].Enabled = true;
                                break;
                            }
                        case -1:
                            {
                                owner[0].Enabled = false;
                                owner[1].Enabled = false;
                                owner[2].Enabled = false;
                                owner[3].Enabled = false;
                                break;
                            }
                    }
                }
            }
        }


        public bool IsHaveTimeTable(int subjectregister = 0, int mastertimetable = 0)
        {
            try
            {
                string xml = Render.GenerateXmlFromObject<object>("INSERT", new
                {
                    MasterTimeTableID = mastertimetable,
                    SubjectRegisterID = subjectregister
                }, "2016", "", "13");
                var ds = db.ExecuteAction(xml);
                var resp = Render.ResponseObject<BaseResult>(ds.Tables[0]);
                if (resp.ID > 0)
                    return true;
                else
                    return false;
            }
            catch
            {
                return false;
            }
        }

        #region repair learn subjects section
        private void contextMenuStripLearningSubject_Opening(object sender, CancelEventArgs e)
        {


        }

        private void gvRepairLearningSubject_PopupMenuShowing(object sender, PopupMenuShowingEventArgs e)
        {
            if (e.HitInfo.InRow)
            {
                GridView view = sender as GridView;
                var row = view.GetFocusedRow();
                if (row != null)
                {
                    var model = (SubjectRegisterModel)row;
                    if (model != null)
                    {
                        currentSubjectItem = model;
                        var checkedResult = IsHaveTimeTable(model.ID);
                        if (checkedResult)
                        {
                            contextMenuStripRepairLearningSubject.Items[1].Enabled = true;
                        }
                        else
                        {
                            contextMenuStripRepairLearningSubject.Items[1].Enabled = false;
                        }

                        SetUpSubMenuStrip(contextMenuStripRepairLearningSubject.Items[0], model);
                    }
                }
            }
            else
            {
                currentSubjectItem = null;
            }
        }

        private void mởKhóaHọcToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (currentSubjectItem != null &&  currentSubjectItem.UpdateStatus(1))
            {
                LoadTripleList((cbxClass.SelectedItem as ClassModel).ID, (cbxSchoolYearCode.SelectedItem as SchoolYearModel).ID);
                MessageBox.Show("Thay đổi tình trạng khóa học thành công!");
                if (ckbNotify.Checked)
                {
                    string subject = $"[VDADMIN]: Thông báo mở khóa học môn {currentSubjectItem.Name}";
                    string body = $"Khóa học môn {currentSubjectItem.Name} hiện tại đã mở. Các bạn sinh viên hãy nhanh chóng đăng kí trước khi quá hạn!";
                    SendNoticeToSubjectRegister(subject, body,0,null,1, currentSubjectItem.ID);
                }
            }
        }

        private void cậpNhậtĐangHọcToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (currentSubjectItem != null && currentSubjectItem.UpdateStatus(3))
            {
                LoadTripleList((cbxClass.SelectedItem as ClassModel).ID,(cbxSchoolYearCode.SelectedItem as SchoolYearModel).ID);
                MessageBox.Show("Thay đổi tình trạng khóa học thành công!");

                string subject = $"[VDADMIN]: Khóa học mới đã bắt đầu";
                string body = $"Khóa học môn {currentSubjectItem.Name} hiện tại đã bắt đầu. Đừng bỏ lỡ buổi học nào nhé!";
                SendNoticeToSubjectRegister(subject, body, 1, null, 2, currentSubjectItem.ID);
            }
        }

        private void tạoLịchHọcToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (currentSubjectItem != null)
            {


                NewCoursefrm newCoursefrm = new NewCoursefrm(currentSubjectItem.Code, currentSubjectItem.TeacherName, currentSubjectItem.ID, this);
                newCoursefrm.ShowDialog();
            }
        }

        private void xemLiênKếtToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (currentSubjectItem != null)
            {
                ConnectivityFrm connectivityFrm = new ConnectivityFrm(currentSubjectItem.ID, this);
                connectivityFrm.ShowDialog();
            }
        }

        private void xemThờiKhóaBiểuToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (currentSubjectItem != null)
            {
                NewTimeTablefrm newTimeTablefrm = new NewTimeTablefrm(currentSubjectItem.ID,currentSubjectItem.StatusID);

                newTimeTablefrm.ShowDialog();
            }
        }

        private void thêmLớpHọcToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (currentSubjectItem != null)
            {
                FrmAddClass frmAddClass = new FrmAddClass((cbxClass.SelectedItem as ClassModel).SpecializeID, currentSubjectItem.ID);
                frmAddClass.ShowDialog();
            }
        }

        private void đóngMônHọcToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (currentSubjectItem != null && currentSubjectItem.UpdateStatus(-1))
            {
                if (tabPane1.SelectedPageIndex == 0)
                {
                    radioGroupSubjectRegisterSelection.SelectedIndex = 0;

                    var mList = SubjectRegisterModel.GetInstance().GetBySpecialize((cbxClass.SelectedItem as ClassModel).SpecializeID, (cbxSchoolYearCode.SelectedItem as SchoolYearModel).ID);
                    gcSubjectRegister.DataSource = mList;
                }
                else
                {
                    LoadTripleList((cbxClass.SelectedItem as ClassModel).ID, (cbxSchoolYearCode.SelectedItem as SchoolYearModel).ID);
                }
                MessageBox.Show("Thay đổi tình trạng khóa học thành công!");
            }
        }

        #endregion


        #region Learning subjects section

        private void gvLearningsubject_PopupMenuShowing(object sender, PopupMenuShowingEventArgs e)
        {
            if (e.HitInfo.InRow)
            {
                GridView view = sender as GridView;
                var row = view.GetFocusedRow();
                if (row != null)
                {
                    var model = (SubjectRegisterModel)row;
                    if (model != null)
                    {
                        currentSubjectItem = model;
                    }
                }
            }
            else
            {
                currentSubjectItem = null;
            }
        }

        private void đóngMônHọcToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (currentSubjectItem != null && currentSubjectItem.UpdateStatus(-1))
            {
                LoadTripleList((cbxClass.SelectedItem as ClassModel).ID, (cbxSchoolYearCode.SelectedItem as SchoolYearModel).ID);
                MessageBox.Show("Thay đổi tình trạng khóa học thành công!");
            }
        }

        private void xemChiTiếtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (currentSubjectItem != null)
            {
                ConnectivityFrm connectivityFrm = new ConnectivityFrm(currentSubjectItem.ID, this);
                connectivityFrm.ShowDialog();
            }
        }

        private void xemThờiKhóaBiểuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (currentSubjectItem != null)
            {
                NewTimeTablefrm newTimeTablefrm = new NewTimeTablefrm(currentSubjectItem.ID,currentSubjectItem.StatusID);
                newTimeTablefrm.ShowDialog();
            }
        }

        #endregion

        #region Notice by condition
        public void SendNoticeToSubjectRegister(string subject,string body,int type,string Path,int sendtype = 0,int _subjectregisterid = 0,int classid = 0,string studentid = "")
        {
            if (string.IsNullOrEmpty(Path))
            {
                Path = ".SubjectRegister";
            }
            List<StudentModel> mList = null;
            if(sendtype == 0)
            {
                mList = StudentModel.GetInstace().GetStudentByClass(classid);
            }
            else if(sendtype == 1)
            {
                mList = StudentModel.GetInstace().GetStudentBySubjectRegister(_subjectregisterid);
            }
            else if(sendtype == 2)
            {
                mList = StudentModel.GetInstace().GetStudentByRegisted(_subjectregisterid);
            }
            else if(sendtype == 3)
            {
                mList = new List<StudentModel>() { new StudentModel() { ID = studentid } };
            }

            var id = SetNotifyMasterRow(subject, body, type, Path);
            if (id > 0)
            {
                foreach (var item in mList)
                {
                    var mResult = SetNotifyDetailRow(id, item.ID,Path);
                    SendSectionNotice(subject, body, type, item.ID, mResult, Path);

                    if (mResult < 0)
                    {
                        break;
                    }
                }
            }
        }


        #endregion

        #region all specialize subjectregister
        private void radioGroupSubjectRegisterSelection_SelectedIndexChanged(object sender, EventArgs e)
        {
            List<SubjectRegisterModel> mList = null;
            if(radioGroupSubjectRegisterSelection.SelectedIndex == 0)
            {
                mList = SubjectRegisterModel.GetInstance().GetBySpecialize((cbxClass.SelectedItem as ClassModel).SpecializeID,(cbxSchoolYearCode.SelectedItem as SchoolYearModel).ID);
            }
            else
            {
                mList = SubjectRegisterModel.GetInstance().GetAll((cbxSchoolYearCode.SelectedItem as SchoolYearModel).ID);
            }
            gcSubjectRegister.DataSource = mList;
        }

        private void gvSubjectRegister_PopupMenuShowing(object sender, PopupMenuShowingEventArgs e)
        {
            if (e.HitInfo.InRow)
            {
                GridView view = sender as GridView;
                var row = view.GetFocusedRow();
                if (row != null)
                {
                    var model = (SubjectRegisterModel)row;
                    if (model != null)
                    {
                        currentSubjectItem = model;
                        var checkedResult = IsHaveTimeTable(model.ID);
                        if (checkedResult)
                        {
                            contextMenuStripRepairLearningSubject.Items[1].Enabled = true;
                        }
                        else
                        {
                            contextMenuStripRepairLearningSubject.Items[1].Enabled = false;
                        }

                        SetUpSubMenuStrip(contextMenuStripRepairLearningSubject.Items[0], model);
                    }
                }
            }
            else
            {
                currentSubjectItem = null;
            }
        }

        private void xemLiênKếtToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            ConnectivityFrm connectivityFrm = new ConnectivityFrm(currentSubjectItem.ID,this);
            connectivityFrm.ShowDialog();
        }




        #endregion

        private void cbxSchoolYearCode_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbxClass.Items.Count > 0)
            {
                if (tabPane1.SelectedPageIndex == 0)
                {
                    radioGroupSubjectRegisterSelection.SelectedIndex = 0;

                    var mList = SubjectRegisterModel.GetInstance().GetBySpecialize((cbxClass.SelectedItem as ClassModel).SpecializeID, (cbxSchoolYearCode.SelectedItem as SchoolYearModel).ID);
                    gcSubjectRegister.DataSource = mList;
                }
                else
                {
                    LoadTripleList((cbxClass.SelectedItem as ClassModel).ID, (cbxSchoolYearCode.SelectedItem as SchoolYearModel).ID);
                }
            }
        }

        public void TimeTable_Created(int subjectregisterid, string subjectname)
        {
            if (tabPane1.SelectedPageIndex == 0)
            {
                radioGroupSubjectRegisterSelection.SelectedIndex = 0;

                var mList = SubjectRegisterModel.GetInstance().GetBySpecialize((cbxClass.SelectedItem as ClassModel).SpecializeID, (cbxSchoolYearCode.SelectedItem as SchoolYearModel).ID);
                gcSubjectRegister.DataSource = mList;
            }
            else
            {
                LoadTripleList((cbxClass.SelectedItem as ClassModel).ID, (cbxSchoolYearCode.SelectedItem as SchoolYearModel).ID);
            }

            string subject = "[VDADMIN]: Thời khóa biểu mới";
            string body = $"Môn học [{subjectname}] đã có thời khóa biểu. Các bạn hãy kiểm tra ngay nhé!";
            SendNoticeToSubjectRegister(subject, body, 0, ".TimeTable", 2, subjectregisterid);
        }

        private void checkButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioGroupSubjectRegisterSelection.SelectedIndex == 0)
            {
                var mList = SubjectRegisterModel.GetInstance().GetBySpecialize((cbxClass.SelectedItem as ClassModel).SpecializeID, (cbxSchoolYearCode.SelectedItem as SchoolYearModel).ID);
                gcSubjectRegister.DataSource = mList;
            }
            else
            {
                var mList = SubjectRegisterModel.GetInstance().GetAll((cbxSchoolYearCode.SelectedItem as SchoolYearModel).ID);
                gcSubjectRegister.DataSource = mList;
            }

        }
    }

    public class CurrentStudentModel
    {
        public string ID { get; set; }
        public string Name { get; set; }
    }
}
