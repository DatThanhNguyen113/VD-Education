using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using VD.Datalayer.DataObject;
using VD.Utility;
using ServiceCore.Models;
using DevExpress.XtraGrid.Views.Grid;
using ServiceCore.Models.Base;
using ServiceCore.DataAccess;
using ServiceCore.Models.Subject;
using Monitor2.Model;
using Firebase.Database;
using DevExpress.XtraSplashScreen;
using System.Threading;

namespace Monitor2
{
    public partial class UserControlNotification : DevExpress.XtraEditors.XtraUserControl
    {
        private CCoreDao db = new CCoreDao();
        private GenerateData Render = new GenerateData();
        private NotificationModel currentObj;
        private SubjectDAO subjectDAO = new SubjectDAO();
        private BackgroundWorker backgroundWorker;
        static SignalRHelper _helper;


        public UserControlNotification()
        {
            InitializeComponent();
            var task = Task.Run(async () => {
                _helper = SignalRHelper.GetInstance();
            });
        }

        private void UserControlNotification_Load(object sender, EventArgs e)
        {
            gcNotify.DataSource = GetNotifyList();
            gridView1.BestFitColumns();
        }

        private List<NotificationModel> GetNotifyList()
        {
            try
            {
                string xml = Render.GenerateXmlFromObject<object>(null, new
                {
                }, "2009", "COMMON");
                var ds = db.GetContextData(xml);
                var resp = Render.ResponseMultiObject<NotificationModel>(ds.Tables[0]).ToList();
                return resp;
            }
            catch (Exception ex)
            {
                return new List<NotificationModel>();
            }
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            GridView gridView = sender as GridView;
            var row = gridView.GetFocusedRow();
            if (row != null)
            {
                currentObj = (NotificationModel)row;
                DisplayGridViewText(currentObj);
                checkedListBoxObject.SelectionMode = SelectionMode.None;
            }
        }

        private void DisplayGridViewText(NotificationModel model)
        {
            edtSubject.Text = model.Subject;
            edtBody.Text = model.Body;
            var mlist = GetNotificationObjectDetail(model.ID);
            checkedListBoxObject.Items.Clear();
            foreach (var item in mlist)
            {
                var isCheck = false;
                if(item.Status == 1)
                {
                    isCheck = true;
                }
                checkedListBoxObject.Items.Add(item.ReceiverName, true);
            }
        }

        private List<NoticeDetail> GetNotificationObjectDetail(int id)
        {
            try
            {
                string xml = Render.GenerateXmlFromObject<object>(null, new
                {
                    ID = id
                }, "2009", "DETAIL::RELATE");
                var ds = db.GetContextData(xml);
                var resp = Render.ResponseMultiObject<NoticeDetail>(ds.Tables[0]).ToList();
                return resp;
            }
            catch (Exception ex)
            {
                return new List<NoticeDetail>();
            }
        }

        private void btnSend_Click(object sender, EventArgs e)
        {

            SplashScreenManager.ShowForm(typeof(ThongBaoWaitForm));
            SplashScreenManager.Default.SetWaitFormCaption("Đang Gửi Thông Báo");
            for (int i = 0; i < 100; i++) {
                Thread.Sleep(10);
            }
            if (validateForm())
            {
                backgroundWorker = new BackgroundWorker();
                backgroundWorker.WorkerReportsProgress = true;
                backgroundWorker.ProgressChanged += backgroundWorker_ProgressChanged;
                backgroundWorker.DoWork += backgroundWorker_DoWork;
                backgroundWorker.RunWorkerCompleted += backgroundWorker_RunWorkerCompleted;
                if (backgroundWorker.IsBusy)
                {
                    backgroundWorker.CancelAsync();
                }
                else
                {
                    backgroundWorker.RunWorkerAsync();
                }
            }
            SplashScreenManager.CloseForm();
        }

        private void backgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            MessageBox.Show("Thực hiện xong!");
        }

        private void backgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            if (!backgroundWorker.CancellationPending)
            {
                if(radioGroupObject.SelectedIndex == 0)
                {
                    //NotificationModel noticeModel = new NotificationModel();
                    //noticeModel.Subject = edtSubject.Text;
                    //noticeModel.Body = edtBody.Text;
                    //noticeModel.Type = 1;
                    //noticeModel.Path = ".Notification";
                    foreach(var item in checkedListBoxObject.CheckedItems)
                    {
                        var rowItem = item as ClassModel;
                        UserControlSubjectRegister userControlSubject = new UserControlSubjectRegister();
                        userControlSubject.SendNoticeToSubjectRegister(edtSubject.Text, edtBody.Text, 1, "", 0, 0, rowItem.ID) ;
                    }
                    //UserControlSubjectRegister userControlSubject = new UserControlSubjectRegister();
                    //var id = userControlSubject.SetNotifyMasterRow(edtSubject.Text, edtBody.Text, 0);
                    //foreach (var classItem in checkedListBoxObject.CheckedItems)
                    //{
                    //   var classid = ((ItemsModel)classItem).Value;
                    //    if (id > 0)
                    //    {
                    //        var mList = userControlSubject.GetSutdentInSection(0, classid.ToString());
                    //        foreach (var item in mList)
                    //        {
                    //            var mResult = userControlSubject.SetNotifyDetailRow(id, item.ID);
                    //            userControlSubject.SendSectionNotice(edtSubject.Text, edtBody.Text, 1, item.ID, mResult);
                                
                    //            if (mResult < 1)
                    //            {
                    //                break;
                    //            }
                    //        }
                    //    }
                    //}
                }
                else
                {
                    foreach (var item in checkedListBoxObject.CheckedItems)
                    {
                        var rowItem = item as SubjectRegisterModel;
                        UserControlSubjectRegister userControlSubject = new UserControlSubjectRegister();
                        userControlSubject.SendNoticeToSubjectRegister(edtSubject.Text, edtBody.Text, 1, "", 2, rowItem.ID);
                    }
                    //var id = userControlSubject.SetNotifyMasterRow(edtSubject.Text, edtBody.Text, 0);
                    //foreach (var classItem in checkedListBoxObject.CheckedItems)
                    //{
                    //    var subjectId = ((ItemsModel)classItem).Value;
                    //    ConnectivityFrm connectivityFrm = new ConnectivityFrm();
                    //    var connectList = connectivityFrm.LoadConnectivity(Int32.Parse(subjectId.ToString()));

                    //    foreach (var bigItem in connectList)
                    //    {
                    //        if (id > 0)
                    //        {
                    //            var mList = userControlSubject.GetSutdentInSection(0, bigItem.ClassID.ToString());
                    //            foreach (var item in mList)
                    //            {
                    //                var mResult = userControlSubject.SetNotifyDetailRow(id, item.ID);
                    //                userControlSubject.SendSectionNotice(edtSubject.Text, edtBody.Text, 1, item.ID, mResult);

                    //                if (mResult < 1)
                    //                {
                    //                    break;
                    //                }
                    //            }
                    //        }
                    //    }
                    //}

                }
                //else
                //{

                //    string xml = Render.GenerateXmlFromObject<object>(null, new
                //    {
                //        ID = SubjectRegisterID
                //    }, "2007", "");
                //    var ds = db.GetContextData(xml);
                //    var Resp = Render.ResponseMultiObject<ConnectivityModel>(ds.Tables[0]).ToList();
                //    return Resp;
                //}
            }
        }

        private void sendFireBase(NotificationModel model)
        {
            var firebaseClient = new FirebaseClient("https://doantn-23158.firebaseio.com/");
            firebaseClient.Child("Notification").PostAsync(model);
        }

        private void backgroundWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            throw new NotImplementedException();
        }

        private bool validateForm()
        {
            if(edtSubject.Text.Length < 1)
            {
                MessageBox.Show("Tiêu đề thông báo không thể để trống");
                return false;
            }
            if(edtBody.Text.Length < 1)
            {
                MessageBox.Show("Nội dung thông báo không thể để trống");
                return false;
            }
            return true;
        }

        private void radioGroupObject_SelectedIndexChanged(object sender, EventArgs e)
        {
            checkedListBoxObject.Items.Clear();
            if(radioGroupObject.SelectedIndex == 0)
            {
                var mlist = ClassModel.GetInstance().GetClassList();
                checkedListBoxObject.Items.AddRange(mlist.ToArray());
            }
            else
            {
                var mlist = SubjectRegisterModel.GetInstance().GetAll();
                checkedListBoxObject.Items.AddRange(mlist.ToArray());
            }
        }

        private void tạoMớiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            checkedListBoxObject.SelectionMode = SelectionMode.One;
            edtSubject.Text = "";
            edtBody.Text = "";
            checkedListBoxObject.Items.Clear();
            if (radioGroupObject.SelectedIndex == 0)
            {
                foreach (var item in CacheCore.mClassList)
                {
                    ItemsModel itemBound = new ItemsModel();
                    itemBound.Text = item.Code;
                    itemBound.Value = item.ID;
                    checkedListBoxObject.Items.Add(itemBound);
                }
            }
            else if (radioGroupObject.SelectedIndex == 1)
            {
                BaseResponseModel<object> baseResponse = subjectDAO.GetSubjectRegister(CacheCore.UserID, "EMPL", 0);
                var listRegister = (List<SubjectRegisterModel>)baseResponse.ResponseData;
                foreach (var item in listRegister)
                {
                    ItemsModel itemBound = new ItemsModel();
                    itemBound.Text = item.Name;
                    itemBound.Value = item.ID;
                    checkedListBoxObject.Items.Add(itemBound);
                }
            }
            
            checkedListBoxObject.Enabled = true;
        }
    }

    public class NoticeDetail
    {
        public string ReceiverName { get; set; }
        public int Status { get; set; }
    }

    public class SubStudent
    {
        public int ID { get; set; }
    }
}
