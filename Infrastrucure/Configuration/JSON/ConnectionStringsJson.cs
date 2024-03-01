using Infrastrucure.Configuration.Test;
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
    public class JsonlWebConfig : IConfigurationRepository
    {
        /// <summary>
        /// Memory storage for connection strings
        /// </summary>
        private SortedList<string, string> keysValues = new SortedList<string, string>();

        /// <summary>
        /// Get requested connection string form storage
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public string GetKeyValue(string key)
        {
            return keysValues[key];
        }

        /// <summary>
        /// Read all connection strings from webconfig by XML configuration
        /// </summary>
        /// <returns></returns>
        public void LoadApplicationSection()
        {
            throw new NotImplementedException("JSON configuration is not implemeted here");
        }
    }
}
