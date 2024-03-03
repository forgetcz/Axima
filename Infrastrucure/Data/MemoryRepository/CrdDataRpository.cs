using Domain.Entities;
using Infrastrucure.Classes;
using Infrastrucure.Enums;
using Infrastrucure.Interfaces;
using System.ComponentModel.Composition;

namespace Infrastrucure.Data.MemoryRepository
{
    [Export(typeof(IBaseDbRepository<CrdData, long>))]
    [ExportMetadata(nameof(eMefAttribute.exportedTpe), typeof(CrdData))]
    [ExportMetadata(nameof(eMefAttribute.repositoryType), Enums.eDomainSourceRepositoryType.Memory)]

    public class CrdDataRpository : MemoryRepository<CrdData, long>
    {
       
    }
}