using Microsoft.AspNet.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Web;

namespace RemoteProgress.App_Start
{
    public class LongTask
    {

        public static Task DoTaskAsync(string connectionId)
        {
            return Task.Factory.StartNew(DoTask, connectionId);
        }

        private static void DoTask(object state)
        {
            string connectionId = state as String;
            var hubContext = GlobalHost.ConnectionManager.GetHubContext<ProgressHub>();

            for (int i = 10; i <= 100; i += 10)
            {
                Thread.Sleep(1000);

                hubContext.Clients.Client(connectionId).showProgress(i.ToString());
            }
            Thread.Sleep(1000);
        }
    }
}