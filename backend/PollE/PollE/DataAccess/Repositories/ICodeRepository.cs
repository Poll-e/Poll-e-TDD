using System.Threading.Tasks;
using PollE.DataAccess.Entities;

namespace PollE.DataAccess.Repositories
{
    public interface ICodeRepository
    {
        public Task<CodeEntity> InsertCodeAsync(string code);

    }
}