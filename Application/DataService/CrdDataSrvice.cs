using Application.Composition;
using Application.Interfaces;
using Domain.Entities;
using Infrastrucure.Enums;
using Infrastrucure.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;

namespace Application.Data
{
    /// <summary>
    /// Compose Data repository 
    /// </summary>
    /// 
    [Export(typeof(IDataService))]
    public class ActionDetailRepository : IDataService
    {
        [Import(typeof(IAppConfiguration))]
        private IAppConfiguration AppConfig { get; set; }

        /// <summary>
        /// Current settings for load 
        /// </summary>
        private eDomainSourceRepositoryType CurrentType = eDomainSourceRepositoryType.Memory;

        private static IEnumerable<Lazy<IBaseDbRepository<ActionProvider, Guid>, Dictionary<string, object>>> ActionProviderPermanentRepositorys { get; set; }

        private static object lockObject = new object();

        /// <summary>
        /// List of all requested implementation of AcrtionProvider repositoryes
        /// </summary>
        [ImportMany(typeof(IBaseDbRepository<,>))]
        private IEnumerable<Lazy<IBaseDbRepository<ActionProvider, Guid>, Dictionary<string, object>>> actionProviderRepositorys { get; set; }

        [Export(typeof(IBaseDbRepository<ActionProvider, Guid>))]
        public IBaseDbRepository<ActionProvider, Guid> GetActionDetailRpository()
        {
            IBaseDbRepository<ActionProvider, Guid> res = null;
            var crd = actionProviderRepositorys.ToList();
            crd.ForEach(f =>
            {
                if (f.Metadata.ContainsKey(nameof(eMefAttribute.repositoryType)))
                {
                    var key = f.Metadata[nameof(eMefAttribute.repositoryType)].ToString();
                    if (key == CurrentType.ToString())
                    {
                        res = f.Value;
                    }
                }
            });

            return res;
        }

        /// <summary>
        /// Double composition, first for add AppConfig, second for compose rest of (add connection string for database) assembly 
        /// </summary>
        private void ComposeConfiguraion()
        {
            ComposeApplication.Container.SatisfyImportsOnce(this);

            string mainConnectionString = AppConfig.ApplicationConnectionStrings.GetKeyValue(eSqlConnectionStrings.mainConn.ToString());

            ComposeApplication.Container.ComposeExportedValue("connectionString", mainConnectionString);
            ComposeApplication.Container.SatisfyImportsOnce(this);
        }
        
        /// <summary>
        /// Compose application in case it is not composed yet. Use double lock pattern for single creation
        /// </summary>
        public ActionDetailRepository()
        {
            if (ActionProviderPermanentRepositorys == null)
            {
                lock (lockObject)
                {
                    if (ActionProviderPermanentRepositorys == null)
                    {
                        ComposeConfiguraion();
                        ActionProviderPermanentRepositorys = actionProviderRepositorys;
                    }
                }
            }
            else
            {
                actionProviderRepositorys = ActionProviderPermanentRepositorys;
            }
        }
    }
}
