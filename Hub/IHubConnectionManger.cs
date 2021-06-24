using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace mcq_backend.Hub
{
    public interface IHubConnectionManager
    {
        bool AddConnection(bool isActive, string connectionId);
        void RemoveConnection(bool isActive, string connectionId);
        // HashSet<string> GetConnection(string userName);
        IEnumerable<string> UserOnline { get; }
        ObservableHashSet<string> ActiveUserOnlineObservable { get; }
    }
}