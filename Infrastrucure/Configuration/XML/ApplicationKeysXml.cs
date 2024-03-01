using Infrastrucure.Configuration.Test;
using Infrastrucure.Enums;
using Infrastrucure.Interfaces;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Configuration;

namespace Infrastrucure.Configuration.XML
{
    /// <summary>
    /// Application Keys from config
    /// </summary>
    /// 
    [Test.ConfigurationRepositoryExportAttributes(eApplicationConfigurationRepositoryType.XML, eApplicationConfigurationRepositorySection.AppKeys)]
    public class ApplicationKeysXml : IConfigurationRepository
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
            string myPrivateSettings1 = ConfigurationManager.AppSettings[nameof(eApplicationKeys.myPrivateSettings1)];
            string myPrivateSettings2 = ConfigurationManager.AppSettings[nameof(eApplicationKeys.myPrivateSettings2)];

            keysValues.Add(nameof(eApplicationKeys.myPrivateSettings1), myPrivateSettings1);
            keysValues.Add(nameof(eApplicationKeys.myPrivateSettings2), myPrivateSettings2);
        }
    }
}
