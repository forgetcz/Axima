using Infrastrucure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastrucure.Configuration
{
    /// <summary>
    /// Summary for all connection strings need in application
    /// </summary>
    public class configurationConnectionStrings : IConfigurationConnectionStrings
    {
        public string mainConnectionString { get; }
        public string secondConnectionString { get; }

        public configurationConnectionStrings(string mainConnectionString, string secondConnectionString)
        {
            this.mainConnectionString = mainConnectionString;
            this.secondConnectionString = secondConnectionString;
        }
    }
}
