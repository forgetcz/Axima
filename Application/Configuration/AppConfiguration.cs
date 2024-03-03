using Application.Composition;
using Application.Interfaces;
using Infrastrucure.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;

namespace Application.Configuration
{
    /// <summary>
    /// Full application configuration, Current setting for Configuration is XML in .NET it will be JSON
    /// </summary>
    [Export(typeof(IAppConfiguration))]
    public class AppConfiguration : IAppConfiguration
    {
        /// <summary>
        /// Definition of current config type (XML for old project (.NET Framework), JSON for .NET)
        /// </summary>
        private Infrastrucure.Enums.eApplicationConfigurationRepositoryType appConfigType => Infrastrucure.Enums.eApplicationConfigurationRepositoryType.XML;

        /// <summary>
        /// Cache of application configuration setting
        /// </summary>
        private static IEnumerable<Lazy<IConfigurationRepository, IAppConfigurationMefAttributes>> ProvidersPermanent { get; set; }
        
        /// <summary>
        /// List of all aviable Configuration providers
        /// </summary>
        [ImportMany(typeof(IConfigurationRepository))]
        private IEnumerable<Lazy<IConfigurationRepository, IAppConfigurationMefAttributes>> Providers { get; set; }

        /// <summary>
        /// Double lock system for load data only for first time
        /// </summary>
        private static object LockObject { get; set; } = new object();

        /// <summary>
        /// Connection strings (connectionStrings section in config)
        /// </summary>
        private IConfigurationRepository _applicationConnectionStrings { get; set; }

        /// <summary>
        /// Connection strings (connectionStrings section in config)
        /// </summary>
        public IConfigurationRepository ApplicationConnectionStrings
        {
            get
            {
                if (_applicationConnectionStrings == null)
                {
                    _applicationConnectionStrings = ProvidersPermanent.Single(w => w.Metadata.AppConfigType == appConfigType
                       && w.Metadata.AppConfigSection == Infrastrucure.Enums.eApplicationConfigurationRepositorySection.ConnectionStrings).Value;
                }
                return _applicationConnectionStrings;
            }
        }

        /// <summary>
        /// Application Keys (appSettings section in config)
        /// </summary>
        private IConfigurationRepository _applicationKeys;
        /// <summary>
        ///  Application Keys (appSettings section in config)
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
        /// ctor -> Compose application in case it is not composed yet. Use double lock pattern for single composition
        /// </summary>
        public AppConfiguration()
        {
            if (ProvidersPermanent == null)
            {
                lock (LockObject)
                {
                    if (ProvidersPermanent == null)
                    {
                        ComposeApplication.Container.SatisfyImportsOnce(this);
                        Providers.ToList().ForEach(fe =>
                        {
                            fe.Value.LoadApplicationSection();
                        }
                        );
                        ProvidersPermanent = Providers;
                    }
                }
            }
            else
            {
                Providers = ProvidersPermanent;
            }
        }
    }
}
