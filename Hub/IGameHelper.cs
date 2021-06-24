using System.Collections.Generic;
using System.Threading.Tasks;

namespace mcq_backend.Hub
{
    public interface IGameHelper
    {
        IEnumerable<string> GetOnlineUser();
        Task MatchGame(string connId);
    }
}