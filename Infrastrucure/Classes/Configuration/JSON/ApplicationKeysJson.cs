using Infrastrucure.Enums;
using Infrastrucure.Interfaces;
using System;
using System.Configuration;

namespace Infrastrucure.Classes.Configuration.JSON
{
    /// <summary>
    /// Application Keys from config
    /// </summary>
    /// 
    [ConfigurationAttributes(eApplicationConfigurationType.JOSN, eConfigurationSource.ConnectionStrings)]
    public class ApplicationKeysJson : IConfigurationAppSettingsReader
    {
        /// <summary>
        /// Read all connection strings from webconfig by XML configuration
        /// </summary>
        /// <returns></returns>
        public IConfigurationAppSettings ReadConfigurationAppSettings()
        {
            throw new ArgumentException("JSON configuration is not implemeted here");
        }
    }
}
