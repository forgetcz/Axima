using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastrucure.Interfaces
{
    public interface IConfigurationRepository
    {
        void LoadApplicationSection();
        string GetKeyValue(string key);
    }
}
