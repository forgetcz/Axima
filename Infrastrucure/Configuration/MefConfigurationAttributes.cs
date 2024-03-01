using Infrastrucure.Enums;
using Infrastrucure.Interfaces;
using System;
using System.Collections.Generic;
using System.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastrucure.Configuration
{
    /// <summary>
    /// Metadata attribute for composition of application configuration
    /// </summary>
    [MetadataAttribute]
    [AttributeUsage(AttributeTargets.Class)]
    public class ConfigurationAttributes : ExportAttribute, IApplicationConfigurationMetadata
    {
        /// <summary>
        /// JSON/XML
        /// </summary>
        public eApplicationConfigurationRepositoryType ConfigurationType { get; set; }

        /// <summary>
        /// AppKeys, ConnectionStrings
        /// </summary>
        public eApplicationConfigurationRepositorySection ConfigurationSource { get; set; }

        public ConfigurationAttributes(eApplicationConfigurationRepositoryType configurationType, eApplicationConfigurationRepositorySection configurationSource)
           // : base(typeof(IApplicationConfigurationMethods))
        {
            ConfigurationType = configurationType;
            ConfigurationSource = configurationSource;
        }
    }
}
