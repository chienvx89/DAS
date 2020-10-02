using DAS.Domain.Interfaces;
using DAS.Domain.Interfaces.DAS;
using DAS.Infrastructure.Contexts;
using System.Threading.Tasks;

namespace DAS.Infrastructure.Repositories
{
    public class RepositoryWrapper : IDasRepositoryWrapper
    {
        private DASContext _repoContext;
        private IUserRepository _user;

        public IUserRepository User
        {
            get
            {
                if (_user == null)
                {
                    _user = new UserRepository(_repoContext);
                }
                return _user;
            }
        }

        public RepositoryWrapper(DASContext repositoryContext)
        {
            _repoContext = repositoryContext;
        }

        public async Task SaveAync()
        {
            await _repoContext.SaveChangesAsync();
        }
    }
}