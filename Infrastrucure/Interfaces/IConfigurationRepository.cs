using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastrucure.Interfaces
{
    /// <summary>
    /// Repository definition for Configuration (LoadApplicationSection,GetKeyValue)
    /// </summary>
    public interface IConfigurationRepository
    {
        /// <summary>
        /// Load configuration section (connectionstring, application keys)
        /// </summary>
        void LoadApplicationSection();

        /// <summary>
        /// Return value from config section 
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        string GetKeyValue(string key);
    }
}
