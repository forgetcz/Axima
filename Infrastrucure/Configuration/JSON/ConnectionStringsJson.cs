using Infrastrucure.Enums;
using Infrastrucure.Interfaces;
using System;
using System.Collections.Generic;
using System.Composition;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastrucure.Configuration.JSON
{
    /// <summary>
    /// Configuration keys from config
    /// </summary>
    [ConfigurationAttributes(eApplicationConfigurationType.JOSN, eConfigurationSource.ConnectionStrings)]
    public class JsonlWebConfig : IConfigurationConnectionStringsReader
    {
        /// <summary>
        /// Read all connection strings from webconfig by XML configuration
        /// </summary>
        /// <returns></returns>
        public IConfigurationConnectionStrings ReadConfigurationConnectionStrings()
        {
            throw new NotImplementedException("JSON configuration is not implemeted here");
        }
    }
}
