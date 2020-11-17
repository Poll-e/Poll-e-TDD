using System.Threading.Tasks;
using PollE.DataAccess.Entities;

namespace PollE.DataAccess.DataService
{
    public interface ICodeService
    {
        public Task<CodeEntity> GenerateCode();
    }
}