using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DAS.Domain.Interfaces.DAS
{
    public interface IDasRepositoryWrapper
    {
        IUserRepository User { get; }

        Task SaveAync();
    }
}