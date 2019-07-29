using ServiceCore.DataAccess;
using ServiceCore.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Monitor2
{
    public partial class MusterDetail : Form
    {
        int TimeTableID;
        public MusterDetail(int timetableID)
        {
            InitializeComponent();
            this.TimeTableID = timetableID;
        }

        private void MusterDetail_Load(object sender, EventArgs e)
        {
            var mList = MusterModel.GetInstance().GetByTimeTableID(TimeTableID);
            this.gcMusterDetail.DataSource = mList;
        }
    }
}
