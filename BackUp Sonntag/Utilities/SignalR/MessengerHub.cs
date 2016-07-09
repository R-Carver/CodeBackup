using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;

namespace WebApplication1.Utilities.SignalR
{   
    [HubName("MessengerHub")]
    public class MessengerHub : Hub
    {
        private readonly Messenger _messenger;

        public MessengerHub() : this(Messenger.Instance) { }

        public MessengerHub(Messenger messenger)
        {
            _messenger = messenger;
        }

        public override Task OnConnected()
        {
            
            var test = Context.User.Identity.Name;
            return base.OnConnected();
        }


        public void showNewContractMessage()
        {
            _messenger.UpdateMessenger();
        }

    }
}