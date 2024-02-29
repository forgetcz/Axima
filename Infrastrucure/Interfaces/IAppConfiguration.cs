using Infrastrucure.Classes.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastrucure.Interfaces
{
    /// <summary>
    /// Definition of properties for webConfig or AppConfig (read connection string)
    /// </summary>
    public interface IAppConfiguration
    {
        ConfigurationConnectionStrings ReadConnectionStrings();
    }
}
