using Infrastrucure.Configuration.Test;
using Infrastrucure.Interfaces; 
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Configuration
{
    public class AppConfiguration
    {
        private Infrastrucure.Enums.eApplicationConfigurationRepositoryType appConfigType => Infrastrucure.Enums.eApplicationConfigurationRepositoryType.XML;

        private static IEnumerable<Lazy<IConfigurationRepository, IAppConfigurationMefAttributes>> ProvidersPermanent { get; set; }

        [ImportMany(typeof(IConfigurationRepository))]
        private IEnumerable<Lazy<IConfigurationRepository, IAppConfigurationMefAttributes>> Providers { get; set; }

        private IConfigurationRepository _connectionStrings;
        private IConfigurationRepository ConnectionStrings
        {
            get
            {
                if (_connectionStrings == null)
                {
                    _connectionStrings = ProvidersPermanent.Single(w => w.Metadata.AppConfigType == appConfigType
                       && w.Metadata.AppConfigSection == Infrastrucure.Enums.eApplicationConfigurationRepositorySection.AppKeys).Value;
                }
                return _connectionStrings;
            }
        }

        private IConfigurationRepository _applicationKeys;
        private IConfigurationRepository ApplicationKeys
        {
            get
            {
                if (_applicationKeys == null)
                {
                    _applicationKeys = ProvidersPermanent.Single(w => w.Metadata.AppConfigType == appConfigType
                       && w.Metadata.AppConfigSection == Infrastrucure.Enums.eApplicationConfigurationRepositorySection.AppKeys).Value;
                }
                return _applicationKeys;
            }
        }

        /*private void Compose()
        {
            var dllCatalog = new DirectoryCatalog(AppDomain.CurrentDomain.BaseDirectory + "bin\\");
            var aggregateCatalog = new AggregateCatalog { Catalogs = { dllCatalog } };
            CompositionContainer container = new CompositionContainer(aggregateCatalog);
            container.ComposeParts(this);


            ProvidersPermanent = Providers;
            ConfigurationRepository.LoadApplicationSection();
            Debug.WriteLine("");
        }*/

        private void Compose()
        {
            var InfrastrucureCatalog = new DirectoryCatalog(AppDomain.CurrentDomain.BaseDirectory + "bin\\", "Infrastrucure.dll");
            var DomainCatalog = new DirectoryCatalog(AppDomain.CurrentDomain.BaseDirectory + "bin\\", "Domain.dll");
            var ApplicationCatalog = new DirectoryCatalog(AppDomain.CurrentDomain.BaseDirectory + "bin\\", "Application.dll");
            var aggregateCatalog = new AggregateCatalog { Catalogs = { InfrastrucureCatalog, DomainCatalog, ApplicationCatalog } };
            var container = new CompositionContainer(aggregateCatalog);
            container.ComposeParts(this);

            //ProvidersPermanent = Providers;
            //ConfigurationRepository.LoadApplicationSection();
            //Debug.WriteLine("");
        }

        public AppConfiguration()
        {
            if (ProvidersPermanent == null)
            {
                Compose();
                Providers.ToList().ForEach(fe =>
                    {
                        fe.Value.LoadApplicationSection();
                    }
                );
            }
        }
    }
}
