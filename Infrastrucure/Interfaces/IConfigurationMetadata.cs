using Infrastrucure.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastrucure.Interfaces
{
    /// <summary>
    /// Definition of IConfigurationMetadata (JSON/XML)
    /// </summary>
    public interface IConfigurationMetadata
    {
        eApplicationConfigurationType ConfigurationType{ get; }
        eConfigurationSource ConfigurationSource { get; }
    }
}
