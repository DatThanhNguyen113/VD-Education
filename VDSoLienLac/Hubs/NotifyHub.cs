using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;
using ServiceCore.Models;
using VDSoLienLac.Filters;
using VDSoLienLac.Models;

namespace VDSoLienLac.Hubs
{
    [HubName("notify")]
    public class NotifyHub : Hub
    {
        public NotifyHub()
        {
            System.Net.ServicePointManager.Expect100Continue = false;
            ServicePointManager.DefaultConnectionLimit = 100;
        }

        public static Dictionary<string, List<ConnectionModel>> connectionManager = new Dictionary<string, List<ConnectionModel>>();
        public IHubContext contex = GlobalHost.ConnectionManager.GetHubContext<NotifyHub>();
        public void Hello()
        {
            Clients.All.hello();
        }

        
        public void sendNotify(int type, string message, dynamic obj, dynamic obj2 = null)
        {
            if (type == 1)
            {
                if (connectionManager.ContainsKey(obj))
                {
                    var mValue = (List<ConnectionModel>)connectionManager[obj];
                    if (mValue.Count > 0)
                    {
                        foreach (var item in mValue)
                        {
                            Clients.Client(item.ConnectionID).broadcastNotice(message);
                        }
                    }
                }
            }
            else if (type == 2)
            {
                if (obj2 != null)
                {
                    var mValue = (List<ConnectionModel>)connectionManager[obj2];
                    var item = mValue.FirstOrDefault(x => x.UserID == obj);
                    if (item != null)
                    {
                        contex.Clients.Client(item.ConnectionID).broadcastNotice(message);
                    }
                }
            }
        }

        public void sendNoticeGroup(NotificationModel model,string key)
        {
            if (connectionManager.ContainsKey(key))
            {
                foreach (var item in connectionManager[key])
                {
                    Clients.Client(item.ConnectionID).broadcastSpecify(model);
                }
            }
        }

        public void sendNoticeToSpecify(NotificationModel model,string key)
        {
            foreach (var item in connectionManager)
            {
                foreach (var subitem in item.Value)
                {
                    if (subitem.UserID == key)
                    {
                        Clients.Client(subitem.ConnectionID).broadcastSpecify(model);
                    }
                }
            }
            //if (connectionManager.ContainsKey(key))
            //{

            //    //List<ConnectionModel> mList;
            //    //if(connectionManager.TryGetValue(key, out mList))
            //    //{
            //    //    if(mList != null && mList.Count > 0)
            //    //    {
            //    //        foreach (var item in mList)
            //    //        {

            //    //        }
            //    //    }
            //    //}
            //}
        }

        public void AddConnection(string className,string connectionid)
        {
            if (Context.Request.Url.Query.Contains("access_token"))
            {
                var mQuery = Context.Request.Url.Query.Split('&');
                if(mQuery.Length >= 3)
                {
                    var userid = ValidateJwt(mQuery[2].Substring(13));
                    if(userid.Length > 0)
                    {
                        if (connectionManager.ContainsKey(className))
                        {
                            //var mList = connectionManager[className];
                            //var item = mList.FirstOrDefault(x => x.UserID == userid);
                            //if (item == null)
                            //{
                            //    connectionManager[className].Add(new ConnectionModel() { ConnectionID = connectionid, UserID = userid });
                            //    connectionManager[className] = mList;
                            //}
                            //else
                            //{
                            //    var index = mList.IndexOf(item);
                            //    item.ConnectionID = connectionid;
                            //    connectionManager[className][index] = item;
                            //}
                            connectionManager[className].Add(new ConnectionModel() { ConnectionID = connectionid, UserID = userid });
                        }
                        else
                        {
                            connectionManager.Add(className, new List<ConnectionModel>() { new ConnectionModel() { ConnectionID = connectionid, UserID = userid } });
                        }
                    }
                }
            }
        }

        public void RemoveConnection(string connection)
        {
            foreach (var pair in connectionManager)
            {
                var item = pair.Value.FirstOrDefault(x => x.ConnectionID == connection);
                if (item != null)
                {
                    connectionManager[pair.Key].Remove(item);
                }
            }
        }

        protected  string ValidateJwt(string token)
        {
            string userid = "";
            var simplePrinciple = JwtManager.GetPrincipal(token);
            var identity = simplePrinciple?.Identity as ClaimsIdentity;
            if(identity != null && identity.IsAuthenticated)
            {
                var usernameClaim = identity.FindFirst(ClaimTypes.Name);
                var useridClaim = identity.FindFirst(ClaimTypes.PrimarySid);
                userid = useridClaim?.Value;
                if (string.IsNullOrEmpty(userid))
                    return "";

            }
            return userid;
        }

        public override Task OnDisconnected(bool stopCalled)
        {
            var conn = Context.ConnectionId;
            foreach(var item in connectionManager)
            {
                for(int i = 0; i < item.Value.Count; i++)
                {
                    if (item.Value[i].ConnectionID == conn)
                    {
                        item.Value.RemoveAt(i);
                        break;
                    }
                }  
            }
            return base.OnDisconnected(stopCalled);
        }

    }
}