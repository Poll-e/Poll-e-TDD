using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PollE.DataAccess.Entities;

namespace PollE.DataAccess.Repositories
{
    public class InMemoryPollRepository : IPollRepository
    {
        private readonly List<PollEntity> _polls;
        
        public InMemoryPollRepository()
        {
            _polls = new List<PollEntity>();
        }

        private PollEntity GetPollByCode(string code)
        {
            return _polls.SingleOrDefault(poll => poll.Code.Code == code);
        }
        
        private void InsertPoll(PollEntity poll)
        {
            _polls.Add(poll);
        }

        public Task<PollEntity> GetPollByCodeAsync(string code)
        {
            Task<PollEntity> query = new Task<PollEntity>( () => GetPollByCode(code) );
            query.Start();

            return query;
        }

        public Task InsertPollAsync(PollEntity poll)
        {
            poll.Id = _polls.Count;
            Task query = new Task( () => InsertPoll(poll) );
            query.Start();

            return query;
        }
    }
}