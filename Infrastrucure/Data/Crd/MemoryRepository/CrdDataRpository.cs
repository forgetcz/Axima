using Domain.Entities;
using Domain.Entities.Crd;
using Infrastrucure.Classes;
using Infrastrucure.Configuration;
using Infrastrucure.Enums;
using Infrastrucure.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastrucure.Data.Crd.MemoryRepository
{
    [Export(typeof(IBaseDbRepository<CrdData, long>))]
    [ExportMetadata(nameof(eMefAttribute.exportedTpe), typeof(CrdData))]
    [ExportMetadata(nameof(eMefAttribute.repositoryType), Enums.eDomainSourceRepositoryType.Memory)]

    public class CrdDataRpository : MemoryRepository<CrdData, long>
    {
       
    }
}