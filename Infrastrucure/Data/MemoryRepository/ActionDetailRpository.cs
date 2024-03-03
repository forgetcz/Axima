using Domain.Entities;
using Infrastrucure.Classes;
using Infrastrucure.Enums;
using Infrastrucure.Interfaces;
using System;
using System.ComponentModel.Composition;

namespace Infrastrucure.Data.MemoryRepository
{
    [Export(typeof(IBaseDbRepository<ActionDetail, Guid>))]
    [ExportMetadata(nameof(eMefAttribute.exportedTpe), typeof(ActionDetail))]
    [ExportMetadata(nameof(eMefAttribute.repositoryType), Enums.eDomainSourceRepositoryType.Memory)]

    public class ActionDetailRpository : MemoryRepository<ActionDetail, Guid>
    {
       
    }
}