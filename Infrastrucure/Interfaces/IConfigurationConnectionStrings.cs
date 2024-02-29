using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastrucure.Interfaces
{
    public interface IConfigurationConnectionStrings
    {
        string mainConnectionString { get; }
        string secondConnectionString { get; }
    }

    public interface IConfigurationConnectionStringsReader
    {
        IConfigurationConnectionStrings ReadConfigurationConnectionStrings();
    }
}
