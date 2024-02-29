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
    public class JsonlWebConfig 
    {
        /// <summary>
        /// Read all connection strings from webconfig by XML configuration
        /// </summary>
        /// <returns></returns>
        public configurationConnectionStrings ReadConnectionStrings()
        {
            throw new ArgumentException("JSON configuration is not implemeted yet");
        }
    }
}
