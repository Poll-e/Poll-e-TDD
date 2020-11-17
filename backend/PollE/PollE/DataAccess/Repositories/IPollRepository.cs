using System.Threading.Tasks;
using PollE.DataAccess.Entities;

namespace PollE.DataAccess.Repositories
{
    public interface IPollRepository
    {
        public Task<PollEntity> GetPollByCodeAsync(string code);

        public Task InsertPollAsync(PollEntity poll);
    }
}