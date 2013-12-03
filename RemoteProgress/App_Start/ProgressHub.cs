using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;

namespace RemoteProgress.App_Start
{
    public class ProgressHub : Hub
    {
        public async void Start()
        {
            Clients.Caller.showProgress("Started");
            await LongTask.DoTaskAsync(Context.ConnectionId);
            Clients.Caller.onCompleted("Completed");
        }
    }
}