using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace VDSoLienLac.Principal
{
    interface VDIPrincipal : IPrincipal
    {
        string Id { get; set; }
        string UserName { get; set; }
    }
}
