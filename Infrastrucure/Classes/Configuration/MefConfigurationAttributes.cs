using Infrastrucure.Enums;
using Infrastrucure.Interfaces;
using System;
using System.Collections.Generic;
using System.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastrucure.Classes
{
    /// <summary>
    /// Metadata attribute for composition of application configuration
    /// </summary>
    [MetadataAttribute]
    [AttributeUsage(AttributeTargets.Class)]
    public class ConfigurationAttributes : ExportAttribute, IConfigurationMetadata
    {
        public eApplicationConfigurationType ConfigurationType { get; }

        public eConfigurationSource ConfigurationSource { get; }

        public ConfigurationAttributes(eApplicationConfigurationType configurationType, eConfigurationSource configurationSource)
        {
            this.ConfigurationType = configurationType;
            this.ConfigurationSource = configurationSource;
        }
    }
}
