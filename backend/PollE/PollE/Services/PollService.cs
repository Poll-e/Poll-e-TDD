using System;
using System.Threading.Tasks;
using PollE.Controllers.DTOs;
using PollE.DataAccess.Entities;
using PollE.DataAccess.Repositories;

namespace PollE.DataAccess.DataService
{
    public class PollService : IPollService
    {
        private readonly IPollRepository _pollRepository;
        private readonly ICodeService _codeService;

        public PollService(IPollRepository pollRepository, ICodeService codeService)
        {
            _pollRepository = pollRepository ?? throw new ArgumentNullException(nameof(pollRepository));
            _codeService = codeService ?? throw new ArgumentNullException(nameof(codeService));
        }
        
        public async Task<Poll> GetPollByCode(string code)
        {
            var poll = await _pollRepository.GetPollByCodeAsync(code);
            
            return new Poll
            {
                Title = poll.Title,
                Code = poll.Code.Code,
                Category = poll.Category.Name
            };
        }

        public async Task<PollCreated> CreatePoll(PollCreate pollCreate)
        {
            //TODO Category Repository
            var generatedCode = await _codeService.GenerateCode();
            int catId = 1;
            
            var poll = new PollEntity
            {
                Title = pollCreate.Title,
                Category = new CategoryEntity
                {
                    Id = catId,
                    Name = pollCreate.Category
                },
                Code = generatedCode
            };
            
            await _pollRepository.InsertPollAsync(poll);

            return new PollCreated
            {
                Code = generatedCode.Code
            };
        }
    }
}