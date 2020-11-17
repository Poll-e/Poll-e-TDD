using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PollE.DataAccess.Entities;

namespace PollE.DataAccess.Repositories
{
    public class InMemoryCodeRepository : ICodeRepository
    {
        private readonly List<CodeEntity> _codes;
        
        public InMemoryCodeRepository()
        {
            _codes = new List<CodeEntity>();
        }

        private CodeEntity InsertCode(string code)
        {
            int id = _codes.Count;
            var entity = new CodeEntity
            {
                Id = id,
                Code = code
            };
            _codes.Add(entity);

            return entity;
        }

        public Task<CodeEntity> InsertCodeAsync(string code)
        {
            Task<CodeEntity> query = new Task<CodeEntity>( () => InsertCode(code) );
            query.Start();

            return query;
        }
    }
}