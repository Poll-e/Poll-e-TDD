using System;
using System.Threading.Tasks;
using PollE.DataAccess.Entities;
using PollE.DataAccess.Repositories;

namespace PollE.DataAccess.DataService
{
    public class CodeService: ICodeService
    {
        private readonly ICodeRepository _codeRepository;

        public CodeService(ICodeRepository codeRepository)
        {
            _codeRepository = codeRepository ?? throw new ArgumentNullException(nameof(codeRepository));
        }

        public async Task<CodeEntity> GenerateCode()
        {
            string code = String.Empty;
            Random r = new Random();
            
            for (int i = 0; i < 6; i++)
            {
                int generated = r.Next() % 10;

                code += generated.ToString();
            }
            
            //TODO Check if an existing code was generated

            return await _codeRepository.InsertCodeAsync(code);
        }
    }
}