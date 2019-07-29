using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceCore.Models.Base
{
    public class BaseDBResult
    {
        public int ID { get; set; }
        public string Code { get; set; }
        public string Message { get; set; }
        public string Description { get; set; }
    }
}
