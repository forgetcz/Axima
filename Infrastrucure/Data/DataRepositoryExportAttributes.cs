using Domain.Abstraction;
using Infrastrucure.Enums;
using Infrastrucure.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastrucure.Configuration
{
    [MetadataAttribute]
    [AttributeUsage(AttributeTargets.Class)]
    public class DataRepositoryExportAttributes : ExportAttribute, IDataRepositoryMefAttributes
    {
        /// <summary>
        /// SQL, FireBird, FileSystem, Mongo,...
        /// </summary>
        public eDomainSourceRepositoryType DomainSourceRepositoryType { get; }

        public DataRepositoryExportAttributes(eDomainSourceRepositoryType domainSourceRepositoryType)
            : base(typeof(IBaseDbRepository<BaseEntity, long>))
        {
            DomainSourceRepositoryType = domainSourceRepositoryType;
        }
    }
}
