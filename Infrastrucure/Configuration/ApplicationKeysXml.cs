using Infrastrucure.Enums;
using Infrastrucure.Interfaces;
using System;
using System.Configuration;

namespace Infrastrucure.Configuration
{
    public class ApplicationKeysXml : IConfigurationAppSettingsConfigurator
    {
        /// <summary>
        /// Read all connection strings from webconfig by XML configuration
        /// </summary>
        /// <returns></returns>
        public IConfigurationAppSettings ReadConfigurationAppSettings()
        {
            string mainConn = ConfigurationManager.AppSettings[nameof(eApplicationKeys.myPrivateSettings1)];
            string secondConn = ConfigurationManager.AppSettings[nameof(eApplicationKeys.myPrivateSettings2)];

            var config = new configurationApplicationKeys(mainConn, secondConn);

            return config;
        }
    }
}
