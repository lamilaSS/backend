using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace mcq_backend.Hub
{
    public class HubConnectionManager : IHubConnectionManager
    {
        //Hashset becuz no duplicate
        // private static Dictionary<string, HashSet<string>> _userMap = new Dictionary<string, HashSet<string>>();
        // private static HashSet<string> _userMap;
        private static HashSet<string> _userPool;
        private static ObservableHashSet<string> _activeUserPool;

        public HubConnectionManager()
        {
            _userPool = new HashSet<string>();
            _activeUserPool = new ObservableHashSet<string>();
        }

        public void AddConnection(bool isActive, string connectionId)
        {
            //Only hashset becuz no username yet

            if (isActive)
            {
                lock (_activeUserPool)
                {
                    // if (!_userMap.ContainsKey(userName))
                    // {
                    //     _userMap[userName] = new HashSet<string>();
                    // }
                    //
                    // _userMap[userName].Add(connectionId);
                    if (_activeUserPool != null)
                    {
                        _activeUserPool.Add(connectionId);
                        Console.WriteLine($"{connectionId} added!");
                    }

                    _activeUserPool = new ObservableHashSet<string> {connectionId};

            

                }
            }

            lock (_userPool)
            {
                // if (!_userMap.ContainsKey(userName))
                // {
                //     _userMap[userName] = new HashSet<string>();
                // }
                //
                // _userMap[userName].Add(connectionId);

                if (_userPool != null)
                {
                    _userPool.Add(connectionId);
                    Console.WriteLine($"{connectionId} added!");
                }
                _userPool = new HashSet<string>() {connectionId};


            }
        }

        public void RemoveConnection(bool isActive, string connectionId)
        {
            if (isActive)
            {
                lock (_activeUserPool)
                {
                    // if (!_userMap.ContainsKey(userName))
                    // {
                    //     _userMap[userName] = new HashSet<string>();
                    // }
                    //
                    // _userMap[userName].Add(connectionId);

                    foreach (var connId in _activeUserPool.Where(connId => _activeUserPool.Remove(connectionId)))
                    {
                        break;
                    }
                }
            }

            lock (_userPool)
            {
                // foreach (var username in _userMap.Keys.Where(username => _userMap.ContainsKey(username))
                //     .Where(username => _userMap[username].Contains(connectionId)))
                // {
                //     _userMap[username].Remove(connectionId);
                //     break;
                // }

                foreach (var connId in _userPool.Where(connId => _userPool.Remove(connectionId)))
                {
                    break;
                }
            }
        }

        // public HashSet<string> GetConnection(string userName)
        // {
        //     var conn = new HashSet<string>();
        //     try
        //     {
        //         lock (_userMap)
        //         {
        //             conn = _userMap[userName];
        //         }
        //     }
        //     catch (Exception e)
        //     {
        //         Console.WriteLine(e);
        //         conn = null;
        //     }
        //
        //     return conn;
        // }
        //Get the user connect to da hub
        public IEnumerable<string> UserOnline
        {
            get
            {
                if (_userPool == null) return Enumerable.Empty<string>();
                lock (_userPool)
                {
                    return _userPool.AsEnumerable();
                }
            }
        }

        public ObservableHashSet<string> ActiveUserOnlineObservable
        {
            get
            {
                if (_activeUserPool == null) return new ObservableHashSet<string>();
                lock (_activeUserPool)
                {
                    return _activeUserPool;
                }
            }
        }
    }
}