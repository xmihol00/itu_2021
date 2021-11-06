using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace itu.WEB.Hubs
{
    [Authorize]
    public class TaskNotificationHub : Hub
    {
        public override Task OnConnectedAsync()
        {
            string userId = Context.GetHttpContext().User.Claims.First(x => x.Type == ClaimTypes.NameIdentifier).Value;
            Groups.AddToGroupAsync(Context.ConnectionId, userId);

            return base.OnConnectedAsync();
        }
    }
}