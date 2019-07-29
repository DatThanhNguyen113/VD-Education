using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monitor2
{
    public interface ICallBackArg
    {
        void Connectivity_Clicked(int classid);

        void TimeTable_Created(int subjectregisterid,string subjectname);
    }
}
