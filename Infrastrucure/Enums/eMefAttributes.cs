using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastrucure.Enums
{
    /// <summary>
    /// Attributes definition for App config type (JOSN, XML)
    /// </summary>
    public enum eApplicationConfigurationType { JOSN, XML }

    public enum eConfigurationSource { AppKeys, ConnectionStrings}
}
