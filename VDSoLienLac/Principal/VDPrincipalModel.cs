using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Web;

namespace VDSoLienLac.Principal
{
    public class VDPrincipalModel : VDIPrincipal
    {
        public string Id { get; set; }
        public string UserName { get; set; }
        public string ClassCode { get; set; }

        public IIdentity Identity { get; private set; }
        public bool IsInRole(string role) { return false; }

        public VDPrincipalModel(string m, IEnumerable<Claim> Claims)
        {
            GenericIdentity genericIdentity = new GenericIdentity("");
            this.Identity = new VDClaimIdentity(m,Claims);
        }

        public VDPrincipalModel(string m,IEnumerable<Claim> Claims, string ClassCode)
        {
            GenericIdentity genericIdentity = new GenericIdentity("");
            this.Identity = new VDClaimIdentity(m, Claims);
            this.ClassCode = ClassCode;
        }
    }
}