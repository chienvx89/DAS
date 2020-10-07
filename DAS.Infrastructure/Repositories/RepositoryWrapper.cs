using DAS.Domain.Interfaces;
using DAS.Domain.Interfaces.DAS;
using DAS.Infrastructure.Contexts;
using System.Threading.Tasks;

namespace DAS.Infrastructure.Repositories
{
    public class RepositoryWrapper : IDasRepositoryWrapper
    {
        #region ctor

        private readonly DASContext _repoContext;

        public RepositoryWrapper(DASContext repositoryContext)
        {
            _repoContext = repositoryContext;
        }

        #endregion ctor

        #region Properties

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

        private ICategoryRepository _category;

        public ICategoryRepository Category
        {
            get
            {
                if (_category == null)
                {
                    _category = new CategoryRepository(_repoContext);
                }
                return _category;
            }
        }

        private ICategoryTypeRepository _categoryType;

        public ICategoryTypeRepository CategoryType
        {
            get
            {
                if (_categoryType == null)
                {
                    _categoryType = new CategoryTypeRepository(_repoContext);
                }
                return _categoryType;
            }
        }

        #endregion Properties

        public async Task SaveAync()
        {
            await _repoContext.SaveChangesAsync();
        }
    }
}