using Infrastrucure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastrucure.Classes.Configuration
{
    /// <summary>
    /// Definition of all keys from Application Keys
    /// </summary>
    public class ConfigurationApplicationKeys : IConfigurationAppSettings
    {
        public string MyPrivateSettings1 { get; }

        public string MyPrivateSettings2 { get; }

        public ConfigurationApplicationKeys(string myPrivateSettings1, string myPrivateSettings2)
        {
            MyPrivateSettings1 = myPrivateSettings1;
            MyPrivateSettings2 = myPrivateSettings2;
        }
    }
}
