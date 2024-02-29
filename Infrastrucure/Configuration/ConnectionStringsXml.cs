using Infrastrucure.Enums;
using Infrastrucure.Interfaces;
using System;
using System.Collections.Generic;
using System.Composition;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastrucure.Configuration
{
    public class XmlWebConfig 
    {
        /// <summary>
        /// Read all connection strings from webconfig by XML configuration
        /// </summary>
        /// <returns></returns>
        public configurationConnectionStrings ReadConnectionStrings()
        {
            string mainConn = ConfigurationManager.ConnectionStrings[nameof(eSqlConnectionStrings.mainConn)].ConnectionString;
            string secondConn = ConfigurationManager.ConnectionStrings[nameof(eSqlConnectionStrings.secondConn)].ConnectionString;

            var config = new configurationConnectionStrings(mainConn, secondConn);

            return config;
           
        }
    }
}
