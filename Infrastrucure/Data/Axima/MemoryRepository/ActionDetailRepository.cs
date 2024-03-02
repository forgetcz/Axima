using Domain.Interfaces;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Infrastrucure.Interfaces;
using Domain.Entities.Axima;
using System.ComponentModel.Composition;
using Infrastrucure.Enums;
using Infrastrucure.Classes;

namespace Infrastrucure.Data.Repositories.MemoryRepository
{
    //[Export(typeof(IBaseDbRepository<ActionDetail, Guid>))]
    [ExportMetadata(nameof(eMefAttribute.exportedTpe), typeof(ActionDetail))]
    [ExportMetadata(nameof(eMefAttribute.repositoryType), Enums.eDomainSourceRepositoryType.Memory)]
    public class ActionDetailRepository : MemoryRepository<ActionDetail, Guid>
    {

    }
}