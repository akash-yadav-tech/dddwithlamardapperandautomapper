using System;
using System.Data;
using System.Data.SqlClient;
using AutoMapper;
using POC.Core.Repository;

namespace POC.Infrastructure.Repository.Dapper
{
    public class UnitOfWork : IUnitOfWork
    {
        private IDbConnection _connection;
        private IDbTransaction _transaction;
        private IBreedRepository _breedRepository;
        private ICatRepository _catRepository;
        private bool _disposed;

        private readonly IMapper _mapper;
        // private readonly IConnectionFactory _connectionFactory;

        // public UnitOfWork(string connectionString)  //string connectionString
        public UnitOfWork(IConnectionFactory connectionFactory, IMapper mapper)  //string connectionString
        {
            _connection = connectionFactory.Create();
            _connection.Open();
            _transaction = _connection.BeginTransaction();
            this._mapper = mapper;
        }

        public IBreedRepository BreedRepository
        {
            get { return _breedRepository ?? (_breedRepository = new BreedRepository(_transaction,_mapper)); }
        }

        // public ICatRepository CatRepository
        // {
        //     get { return _catRepository ?? (_catRepository = new CatRepository(_transaction)); }
        // }

        public void Commit()
        {
            try
            {
                _transaction.Commit();
            }
            catch
            {
                _transaction.Rollback();
                throw;
            }
            finally
            {
                _transaction.Dispose();
                _transaction = _connection.BeginTransaction();
                resetRepositories();
            }
        }

        private void resetRepositories()
        {
            _breedRepository = null;
            _catRepository = null;
        }

        public void Dispose()
        {
            dispose(true);
            GC.SuppressFinalize(this);
        }

        private void dispose(bool disposing)
        {
            if (!_disposed)
            {
                if(disposing)
                {
                    if (_transaction != null)
                    {
                        _transaction.Dispose();
                        _transaction = null;
                    }
                    if(_connection != null)
                    {
                        _connection.Dispose();
                        _connection = null;
                    }
                }
                _disposed = true;
            }
        }

        ~UnitOfWork()
        {
            dispose(false);
        }
    }
}
