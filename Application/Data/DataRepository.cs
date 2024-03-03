using Domain.Abstraction;
using Infrastrucure.Enums;
using Infrastrucure.Interfaces; 
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.Linq;

namespace Application.Configuration
{
    /// <summary>
    /// Full application configuration
    /// </summary>
    public class DataRepository
    {
        private Infrastrucure.Enums.eDomainSourceRepositoryType DomainSourceRepositoryType => Infrastrucure.Enums.eDomainSourceRepositoryType.SQL;

        private static IEnumerable<Lazy<IBaseDbRepository<BaseEntity, long>, IDataRepositoryMefAttributes>> PermanentRepositorys { get; set; }

        private static object lockObject = new object();

        [ImportMany(typeof(IBaseDbRepository<BaseEntity, long>))]
        private IEnumerable<Lazy<IBaseDbRepository<BaseEntity, long>, IDataRepositoryMefAttributes>> Repositorys { get; set; }

        /// <summary>
        /// Connection strings
        /// </summary>
        private IBaseDbRepository<BaseEntity, long> _databseRepository;
        private IBaseDbRepository<BaseEntity, long> DatabseRepository
        {
            get
            {
                if (_databseRepository == null)
                {
                    _databseRepository = PermanentRepositorys.Single(w => w.Metadata.DomainSourceRepositoryType == DomainSourceRepositoryType).Value;
                }
                return _databseRepository;
            }
        }

        /// <summary>
        /// Compose configuration from definned assembly
        /// </summary>
        private void ComposeConfiguraion()
        {
            AppConfiguration appConfiguration = new AppConfiguration();

            var InfrastrucureCatalog = new DirectoryCatalog(AppDomain.CurrentDomain.BaseDirectory + "bin\\", "Infrastrucure.dll");
            var DomainCatalog = new DirectoryCatalog(AppDomain.CurrentDomain.BaseDirectory + "bin\\", "Domain.dll");
            var ApplicationCatalog = new DirectoryCatalog(AppDomain.CurrentDomain.BaseDirectory + "bin\\", "Application.dll");
            var aggregateCatalog = new AggregateCatalog { Catalogs = { InfrastrucureCatalog, DomainCatalog, ApplicationCatalog } };
            var container = new CompositionContainer(aggregateCatalog);
            string mainConnectionString = appConfiguration.ConnectionStrings.GetKeyValue(eSqlConnectionStrings.mainConn.ToString());
            container.ComposeExportedValue("connectionString", mainConnectionString);
            container.ComposeParts(this);
        }

        /// <summary>
        /// Compose application in case it is not composed yet. Use double lock pattern for single creation
        /// </summary>
        public DataRepository()
        {
            if (PermanentRepositorys == null)
            {
                lock (lockObject)
                {
                    if (PermanentRepositorys == null)
                    {
                        ComposeConfiguraion();
                        Repositorys.ToList().ForEach(fe =>
                        {
                            fe.Value.ReadAll();
                        }
                        );
                        PermanentRepositorys = Repositorys;
                    }
                    else
                    {
                        Repositorys = PermanentRepositorys;
                    }
                }
            }
        }
    }
}
