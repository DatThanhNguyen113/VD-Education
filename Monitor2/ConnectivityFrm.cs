using DevExpress.XtraGrid.Views.Grid;
using Monitor2.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VD.Datalayer.DataObject;
using VD.Utility;

namespace Monitor2
{
    public partial class ConnectivityFrm : Form
    {
        private CCoreDao db = new CCoreDao();
        private GenerateData Render = new GenerateData();
        private int SubjectRegisterID;
        ConnectivityModel currentObj;
        ICallBackArg callBackArg;

        public ConnectivityFrm() { }

        public ConnectivityFrm(int subjectregisterid, ICallBackArg callBack )
        {
            InitializeComponent();
            this.SubjectRegisterID = subjectregisterid;
            callBackArg = callBack;
        }
        public ConnectivityFrm(int subjectregisterid)
        {
            InitializeComponent();
            this.SubjectRegisterID = subjectregisterid;
        }

        public List<ConnectivityModel> LoadConnectivity(int id = 0)
        {
            if (id == 0)
                id = SubjectRegisterID;
            string xml = Render.GenerateXmlFromObject<object>(null, new
            {
                ID = id
            }, "2007", "");
            var ds = db.GetContextData(xml);
            var Resp = Render.ResponseMultiObject<ConnectivityModel>(ds.Tables[0]).ToList();
            return Resp;
        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            GridView view = sender as GridView;
            var row = view.GetFocusedRow();
            if(row != null)
            {
                var item = (ConnectivityModel)row;
                callBackArg.Connectivity_Clicked(item.ClassID);
                Close();
            }
        }

        private void ConnectivityFrm_Load(object sender, EventArgs e)
        {
            gridControl1.DataSource = LoadConnectivity();
            gridView1.BestFitColumns();
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {

        }
    }
}
