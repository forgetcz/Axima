using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastrucure.Interfaces
{
    /// <summary>
    /// Summary for all application keys need in application
    /// </summary>
    public interface IConfigurationAppSettings
    {
        string MyPrivateSettings1 { get; }
        string MyPrivateSettings2 { get; }
    }

    public interface IConfigurationAppSettingsConfigurator
    {
        IConfigurationAppSettings ReadConfigurationAppSettings();
    }
}
