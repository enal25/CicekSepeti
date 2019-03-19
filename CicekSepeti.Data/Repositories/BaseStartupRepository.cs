using CicekSepeti.Data.Abstract;
using Common;
using Microsoft.Extensions.Options;

namespace CicekSepeti.Data.Repositories
{
    public class BaseStartupRepository : IBaseStartupRepository
    {
        public IOptions<Settings> settings { get; set; }
        
        public BaseStartupRepository(IOptions<Settings> settings)
        {
            this.settings = settings;
        }

    }
}
