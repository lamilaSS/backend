using System.Threading.Tasks;
using mcq_backend.Dataset.Game;

namespace mcq_backend.Service.Game
{
    public interface IGameService
    {
        Task<AiLaTyPhuGameDataset> CreateALTPGameSession(string userId);
        
    }
}