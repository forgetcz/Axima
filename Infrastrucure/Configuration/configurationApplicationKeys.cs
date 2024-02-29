using Infrastrucure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastrucure.Configuration
{
    public class configurationApplicationKeys : IConfigurationAppSettings
    {
        public string MyPrivateSettings1 { get; }

        public string MyPrivateSettings2 { get; }

        public configurationApplicationKeys(string myPrivateSettings1, string myPrivateSettings2)
        {
            this.MyPrivateSettings1 = myPrivateSettings1;
            this.MyPrivateSettings2 = myPrivateSettings2;
        }
    }
}
