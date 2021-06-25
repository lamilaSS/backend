using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;

namespace mcq_backend.Hub
{
    public class GameHub : Microsoft.AspNetCore.SignalR.Hub
    {
        private readonly IHubConnectionManager _connectionManager;
        private readonly IGameHelper _gameHelper;

        public GameHub(IHubConnectionManager connectionManager, IGameHelper gameHelper)
        {
            _connectionManager = connectionManager;
            _gameHelper = gameHelper;
            // _addConnection();
        }

        public override async Task OnConnectedAsync()
        {
            var connId = GetConnectionId();
            _addConnection(connId);
            await base.OnConnectedAsync();
        }

        public string GetConnectionId()
        {
            var httpCtx = this.Context.GetHttpContext();
            // var username = httpCtx.Request.Query["userName"];
            // if (string.IsNullOrEmpty(username.ToString())) return "";
            return Context.ConnectionId;
        }

        public async Task FindMatch()
        {
            await _gameHelper.MatchGame(Context.ConnectionId);
        }

        private void _addConnection(string connId)
        {
            _connectionManager.AddConnection(false, connId);

        }

        public async Task SendNuke(string usr, string msg)
        {
            var id = Context.ConnectionId;
            await Clients.All.SendAsync("ReceiveMessage", usr, msg + " " + id);
        }
    }
}