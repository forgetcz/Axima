using Infrastrucure.Enums;
using Infrastrucure.Interfaces;
using System;
using System.Configuration;

namespace Infrastrucure.Configuration
{
    public class ApplicationKeysJson : IConfigurationAppSettingsConfigurator
    {
        /// <summary>
        /// Read all connection strings from webconfig by XML configuration
        /// </summary>
        /// <returns></returns>
        public IConfigurationAppSettings ReadConfigurationAppSettings()
        {
            throw new ArgumentException("JSON configuration is not implemeted yet");
        }
    }
}
