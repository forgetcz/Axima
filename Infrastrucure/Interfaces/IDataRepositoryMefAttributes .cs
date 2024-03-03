using Infrastrucure.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastrucure.Interfaces
{
    /// <summary>
    /// Definition of methods using for meta data attributes (SQL, FireBird, FileSystem, Mongo)
    /// </summary>
    public interface IDataRepositoryMefAttributes
    {
        /// <summary>
        /// Attributes definition for database source of domain (SQL, FireBird, FileSystem, Mongo)
        /// </summary>
        eDomainSourceRepositoryType DomainSourceRepositoryType { get; }
    }
}
