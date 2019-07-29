using ServiceCore.DataAccess;
using ServiceCore.Models.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceCore.Hash
{
   public class StudentBL
    {
        //student
        public List<StudentModel> GetUserList()
        {
            try
            {
                StudentDAO objUserda = new StudentDAO(); // Creating object of Dataccess
                return objUserda.GetUserList(); // calling Method of DataAccess
            }
            catch
            {
                throw;
            }
        }
    }
}
