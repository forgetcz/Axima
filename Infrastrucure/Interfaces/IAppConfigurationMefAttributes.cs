using Infrastrucure.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastrucure.Interfaces
{
    /// <summary>
    /// Definition of methods using for meta data attributes 
    /// </summary>
    interface IAppConfigurationMefAttributes
    {
        /// <summary>
        /// Type of app config : XML/JSON
        /// </summary>
        eApplicationConfigurationType appConfigType { get; }
    }
}
