using System;
using POC.Core.Repository;

namespace POC.Core.Repository
{
    public interface IUnitOfWork : IDisposable
    {
        IBreedRepository BreedRepository { get; }
        // ICatRepository CatRepository { get; }

        void Commit();
    }
}