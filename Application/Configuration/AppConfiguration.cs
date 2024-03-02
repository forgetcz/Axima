using Application.Composition;
using Application.Interfaces;
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
    /// <summary>
    /// Full application configuration
    /// </summary>
    [Export(typeof(IAppConfiguration))]
    public class AppConfiguration : IAppConfiguration
    {
        /// <summary>
        /// Definition of current config type (XML for old project (.NET Framework), JSON for .NET(old CORE))
        /// </summary>
        private Infrastrucure.Enums.eApplicationConfigurationRepositoryType appConfigType => Infrastrucure.Enums.eApplicationConfigurationRepositoryType.XML;

        /// <summary>
        /// Cache of application configuration setting
        /// </summary>
        private static IEnumerable<Lazy<IConfigurationRepository, IAppConfigurationMefAttributes>> ProvidersPermanent { get; set; }
        
        [ImportMany(typeof(IConfigurationRepository))]
        private IEnumerable<Lazy<IConfigurationRepository, IAppConfigurationMefAttributes>> Providers { get; set; }

        /// <summary>
        /// Double lock system for load data only for first time
        /// </summary>
        private static object lockObject = new object();

        /// <summary>
        /// Connection strings
        /// </summary>
        private IConfigurationRepository _connectionStrings;
        /// <summary>
        /// Connection strings
        /// </summary>
        public IConfigurationRepository ConnectionStrings
        {
            get
            {
                if (_connectionStrings == null)
                {
                    _connectionStrings = ProvidersPermanent.Single(w => w.Metadata.AppConfigType == appConfigType
                       && w.Metadata.AppConfigSection == Infrastrucure.Enums.eApplicationConfigurationRepositorySection.ConnectionStrings).Value;
                }
                return _connectionStrings;
            }
        }

        /// <summary>
        /// Application Keys
        /// </summary>
        private IConfigurationRepository _applicationKeys;
        /// <summary>
        /// Application Keys
        /// </summary>
        public IConfigurationRepository ApplicationKeys
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

        /// <summary>
        /// Compose application in case it is not composed yet. Use double lock pattern for single composition
        /// </summary>
        public AppConfiguration()
        {
            if (ProvidersPermanent == null)
            {
                lock (lockObject)
                {
                    if (ProvidersPermanent == null)
                    {
                        ComposeApplication.Container.SatisfyImportsOnce(this);
                        ProvidersPermanent = Providers;
                        Providers.ToList().ForEach(fe =>
                        {
                            fe.Value.LoadApplicationSection();
                        }
                        );
                        ProvidersPermanent = Providers;
                    }
                    else
                    {
                        Providers = ProvidersPermanent;
                    }
                }
            }
        }
    }
}
