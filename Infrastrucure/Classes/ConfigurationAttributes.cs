using Infrastrucure.Enums;
using System;
using System.Collections.Generic;
using System.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastrucure.Classes
{
    /// <summary>
    /// Definition of IConfigurationMetadata (JSON/XML)
    /// </summary>
    public interface IConfigurationMetadata
    {
        eMefAttributes.eApplicationConfigurationType Source { get; }
    }

    /// <summary>
    /// Metadata attribute for composition of application configuration
    /// </summary>
    [MetadataAttribute]
    [AttributeUsage(AttributeTargets.Class)]
    public class ConfigurationAttributes : ExportAttribute, IConfigurationMetadata
    {
        public eMefAttributes.eApplicationConfigurationType Source { get; }

        public ConfigurationAttributes(eMefAttributes.eApplicationConfigurationType Source)
        {
            this.Source = Source;
        }
    }
}
