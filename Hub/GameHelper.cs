using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using mcq_backend.Helper.Exception;
using Microsoft.AspNetCore.SignalR;

namespace mcq_backend.Hub
{
    public class GameHelper : IGameHelper
    {
        IHubContext<GameHub> HubContext { get; }
        private readonly IHubConnectionManager _connectionManager;
        private int _idx = -1;
        private IList _poolIsland;

        public GameHelper(IHubConnectionManager connectionManager)
        {
            _connectionManager = connectionManager;
        }

        public IEnumerable<string> GetOnlineUser()
        {
            return _connectionManager.UserOnline;
        }

        public async Task MatchGame(string connId)
        {
            var isAdd = _connectionManager.AddConnection(true, connId);
            if (!isAdd) throw new MatchmakingException(MatchmakingState.JOIN_POOL, "Cannot join pool to find game!");
            var listOfUserOnline = _connectionManager.ActiveUserOnlineObservable;
            if (!listOfUserOnline.Any())
                throw new MatchmakingException(MatchmakingState.EMPTY_POOL, "There is an error in the pool!");
            var s = new Stopwatch();
            s.Start();
            //Assume only 2 players
            //No status (ingame) yet
            while (s.Elapsed < TimeSpan.FromSeconds(120))
            {
                listOfUserOnline.CollectionChanged += _collectionChanged;
                if (_idx == -1) continue;
                if (!(_poolIsland?.Count > 1) || _poolIsland?.Count % 2 != 0) continue;
                //
                var gameId = Guid.NewGuid();
                var gameIdAsString = gameId.ToString();
                await AddToGroup(_poolIsland[0]?.ToString(), gameIdAsString);
                await AddToGroup(_poolIsland[1]?.ToString(), gameIdAsString);
                break;
            }
            s.Stop();
        }

        private void _collectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.Action != NotifyCollectionChangedAction.Add) return;
            _idx = e.NewStartingIndex;
            _poolIsland = e.NewItems;

        }

        internal async Task AddToGroup(string connId, string groupName)
        {
            await HubContext.Groups.AddToGroupAsync(connId, groupName);

            await HubContext.Clients.Group(groupName).SendAsync("SendNuke",
                $"{connId} has joined the group {groupName}.");
        }

        internal async Task RemoveFromGroup(string connId, string groupName)
        {
            await HubContext.Groups.RemoveFromGroupAsync(connId, groupName);

            await HubContext.Clients.Group(groupName)
                .SendAsync("SendNuke", $"{connId} has left the group {groupName}.");
        }
    }
}