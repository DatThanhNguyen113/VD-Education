using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Web;

namespace VDSoLienLac.Principal
{
    public class VDClaimIdentity : IIdentity
    {
        public VDClaimIdentity(string m, IEnumerable<Claim> Claims)
        {
            if (Claims.Count() > 0)
            {
                this.IsAuthenticated = true;
                this.AuthenticationType = "Forms";
                this.Name = m;
                this.Claims = Claims;
            }
        }

        public string Name { get; set; }
        public string AuthenticationType { get; set; }
        public bool IsAuthenticated { get; set; }
        public IEnumerable<Claim> Claims { get; set; }

        public Claim FindFirst(string key)
        {
            if (Claims.Count() > 0)
            {
                return Claims.FirstOrDefault(x => x.Type == key);
            }

            return null;
        }
    }
}