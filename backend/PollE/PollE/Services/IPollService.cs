using System.Threading.Tasks;
using PollE.Controllers.DTOs;
using PollE.DataAccess.Entities;

namespace PollE.DataAccess.DataService
{
    public interface IPollService
    {
        public Task<Poll> GetPollByCode(string code);
        
        public Task<PollCreated> CreatePoll(PollCreate pollCreate);

    }
}