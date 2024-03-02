using Application.Composition;
using Application.Interfaces;
using Domain.Abstraction;
using Domain.Entities;
using Domain.Entities.Axima;
using Domain.Entities.Crd;
using Infrastrucure.Enums;
using Infrastrucure.Interfaces; 
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.Diagnostics;
using System.Linq;

namespace Application.Configuration
{
    /// <summary>
    /// Full application configuration
    /// </summary>
    public class DataRepository
    {
        [Import(typeof(IAppConfigurationConfiguration))]
        private IAppConfigurationConfiguration AppConfig { get; set; }

        private static IEnumerable<Lazy<IBaseDbRepository<CrdData, long>>> PermanentRepositorys { get; set; }

        private static object lockObject = new object();

        [ImportMany(typeof(IBaseDbRepository<,>))]
        private IEnumerable<Lazy<IBaseDbRepository<CrdData, long>, Dictionary<string, object>>> CrdRepositorys { get; set; }

        /// <summary>
        /// Connection strings
        /// </summary>
        /*private IBaseDbRepository<BaseEntity, long> _databseRepository;
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
        */
        /// <summary>
        /// Double composition, first for add Compose configuration from definned assembly
        /// </summary>
        private void ComposeConfiguraion()
        {
            ComposeApplication.Container.SatisfyImportsOnce(this);

            string mainConnectionString = AppConfig.ConnectionStrings.GetKeyValue(eSqlConnectionStrings.mainConn.ToString());

            ComposeApplication.Container.ComposeExportedValue("connectionString", mainConnectionString);
            ComposeApplication.Container.ComposeParts(this);

            ActionDetailRepositorys.ToList().ForEach(f =>
            {
                var r = f.Value.GetType(); ;
                Debug.WriteLine(f.Metadata);
            });
            CrdRepositorys.ToList().ForEach(f =>
            {
                var r = f.Value.ReadById(0).Result;
                Debug.WriteLine(f.Metadata);
            });
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
                        CrdRepositorys.ToList().ForEach(fe =>
                        {
                            var f = fe.Value;
                            //f.ReadById(0);
                        }
                        );
                        //PermanentRepositorys = Repositorys;
                    }
                    else
                    {
                        //Repositorys = PermanentRepositorys;
                    }
                }
            }
        }
    }
}
