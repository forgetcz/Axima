using Infrastrucure.Enums;
using Infrastrucure.Interfaces;
using System;
using System.Collections.Generic;
using System.Composition;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastrucure.Classes.Configuration.XML
{
    /// <summary>
    /// Configuration keys from config
    /// </summary>
    /// 
    [ConfigurationAttributes(eApplicationConfigurationType.XML, eConfigurationSource.ConnectionStrings)]
    public class XmlWebConfig : IConfigurationConnectionStringsReader
    {
        /// <summary>
        /// Read all connection strings from webconfig by XML configuration
        /// </summary>
        /// <returns></returns>
        public IConfigurationConnectionStrings ReadConfigurationConnectionStrings()
        {
            string mainConn = ConfigurationManager.ConnectionStrings[nameof(eSqlConnectionStrings.mainConn)].ConnectionString;
            string secondConn = ConfigurationManager.ConnectionStrings[nameof(eSqlConnectionStrings.secondConn)].ConnectionString;

            var config = new ConfigurationConnectionStrings(mainConn, secondConn);

            return config;
        }
    }
}
