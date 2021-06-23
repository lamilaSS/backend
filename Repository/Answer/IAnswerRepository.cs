using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace mcq_backend.Repository.Answer
{
    public interface IAnswerRepository : IGenericRepository<Model.Answer>
    {
    }
}