using Lamar;
using POC.Core.Configuration;
using AutoMapper;
using POC.Infrastructure.Repository.Dapper.Models;
using Portal.Models;
using POC.Core;
using POC.Core.Services;
using POC.Core.Logging;
using Portal.Controllers;
using POC.Infrastructure.Logging.Serilog;
using System.Data;
using System.Data.SqlClient;
using POC.Core.Repository;
using POC.Infrastructure.Repository.Dapper;

namespace Portal
{
    public class ApplicationServiceRegistry : ServiceRegistry
    {
        public ApplicationServiceRegistry()
        {
            RegisterDependencies();
            RegisterAutoMapper();
        }

        private void RegisterDependencies()
        {
            Scan(scan =>
            {
                scan.TheCallingAssembly();
                scan.WithDefaultConventions();
                scan.AssembliesFromApplicationBaseDirectory();
            });
            //  services.AddScoped<IDbConnection>(provider => new SqlConnection(Configuration["ConnectionStrings:DevConnection"]));

            // For<IDbConnection>().Use()
            // For<IUnitOfWork>().Use(
            //     new UnitOfWork(new SqlConnection(
            //    "Server=INFARSZC90892;Database=DapperDB;User ID=sa;Password=Peter@Parker;Integrated Security=True;")));
            // For<IUnitOfWork>().Use<UnitOfWork>().Scoped();
            // For<IDbConnection>().
            // Use(new SqlConnection("Server=INFARSZC90892;Database=DapperDB;User ID=sa;Password=Peter@Parker;Integrated Security=True;")).Scoped();
            // For<IConnectionFactory>().Use(new ConnectionFactory("Server=INFARSZC90892;Database=DapperDB;User ID=sa;Password=Peter@Parker;Integrated Security=True;"));

            For<IUnitOfWork>().Use<UnitOfWork>().Scoped();

            ForConcreteType<EmployeeController>().Configure
            .Scoped()
            .Ctor<IEmployeeService>().Is<EmployeeService>()
            .Transient();
            
            For<ILoggingService>().Use<LoggingService>().Singleton();

            ForSingletonOf<ISettingsProvider>().Use<SettingsProvider>();

            ForConcreteType<HomeController>().Configure
           .Scoped()
           .Ctor<IEmployeeService>().Is<NewEmployeeService>()
           .Transient();
        }

        private void RegisterAutoMapper()
        {
            var config = new MapperConfiguration(cfg =>
          {
              cfg.AddProfile<DomainToRepositoryMappingProfile>();
              cfg.AddProfile<DomainToDtoMappingProfile>();
          });

            IMapper _mapper = config.CreateMapper();

            For<IMapper>().Use(_mapper);
        }
    }
}
