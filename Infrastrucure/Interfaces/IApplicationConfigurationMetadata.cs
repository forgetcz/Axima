using Infrastrucure.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastrucure.Interfaces
{
    /// <summary>
    /// Definition of IConfigurationMetadata ConfigurationType: (JSON/XML) & App config section (AppKeys, ConnectionStrings)
    /// </summary>
    public interface IApplicationConfigurationMetadata
    {
        eApplicationConfigurationRepositoryType ConfigurationType{ get; set; }
        eApplicationConfigurationRepositorySection ConfigurationSource { get; set; }
    }
}
