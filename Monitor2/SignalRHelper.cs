using Microsoft.AspNet.SignalR.Client;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Monitor2
{
    public class SignalRHelper
    {
        private static SignalRHelper _instance;
        private static object _asyncLock = new object();
        private static HubConnection hubConnection;
        private static IHubProxy hubProxy;

        public static SignalRHelper GetInstance()
        {
            if(_instance == null)
            {
                lock (_asyncLock)
                {
                    _instance = new SignalRHelper();
                    InitConnection();
                }
            }
            return _instance;
        }

        private static IHubProxy InitConnection(string hubname = "")
        {
            if(hubConnection == null)
            {
                lock (_asyncLock)
                {
                    if(hubname.Length < 1)
                    {
                        hubname = "notify";
                    }
                    var hubip = ConfigurationManager.AppSettings["HubIP"].ToString();
                    hubConnection = new HubConnection(hubip);
                    hubProxy = hubConnection.CreateHubProxy(hubname);
                    hubConnection.Start().Wait();
                }
            }
            return hubProxy;
            //var hubip = ConfigurationManager.AppSettings["HubIP"].ToString();
            //var hubConnection = new HubConnection(hubip);
            //var hub = hubConnection.CreateHubProxy(hubname);
            //hubConnection.Start().Wait();
            //return hub;
        }

        public int InvokeMessage(string methodname, params object[] param)
        {
            hubConnection.TransportConnectTimeout = TimeSpan.FromSeconds(1);
            System.Net.ServicePointManager.Expect100Continue = false;
            ServicePointManager.DefaultConnectionLimit = 100;
            if (hubConnection == null ||  hubProxy == null)
            {
                hubProxy = InitConnection();
            }
            if(hubConnection.State == ConnectionState.Disconnected)
            {
                 hubConnection.Start().Wait();
            }
            if (hubConnection.State == ConnectionState.Connected)
            {
                try
                {
                    WaitFor(hubConnection.Start().ContinueWith(x => hubProxy.Invoke(methodname, param)));
                     //hubProxy.Invoke(methodname, param).Wait();
                    return 1;
                }
                catch(Exception ex)
                {
                    throw ex;
                }
            }
            return 0;
        }

        static void WaitFor(Task task)
        {
            var trigger = new ManualResetEventSlim(false);
            task.ContinueWith(t => trigger.Set());
            trigger.Wait();
        }
    }
}
