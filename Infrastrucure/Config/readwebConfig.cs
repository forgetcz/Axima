using Infrastrucure.Enums;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastrucure.Config
{
    public static class readwebConfig
    {
        public static webConfigConnection sqlConnectionStringConfiguration()
        {
            var config = new webConfigConnection()
            {
                SqlConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings[nameof(sqlConnectionStrings.mainConn)].ConnectionString
            };
            return config;
        }
    }
}
