using Domain.Abstraction;
using Domain.Entities;
using Domain.Entities.Crd;
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

namespace Infrastrucure.Data.Crd.SqlRepository
{
    //[Export(typeof(IBaseDbRepository<CrdData, long>))]
    //[ExportMetadata(nameof(eMefAttribute.exportedTpe), typeof(CrdData))]
    //[ExportMetadata(nameof(eMefAttribute.repositoryType), Enums.eDomainSourceRepositoryType.SQL)]
    public class CrdDataRpository : IBaseDbRepository<CrdData, long>
    {
        public SqlConnection _StoreContext;

        [ImportingConstructor]

        public CrdDataRpository([Import("connectionString")] string connectionString)
        {
            _StoreContext = new SqlConnection(connectionString);
        }

        public Task<CrdData> Delete(CrdData entity)
        {
            throw new NotImplementedException();
        }

        public Task DeleteMany(IEnumerable<CrdData> entities)
        {
            throw new NotImplementedException();
        }

        public Task<CrdData> Insert(CrdData entity)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<CrdData>> InsertMany(IEnumerable<CrdData> entities)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<CrdData>> ReadAll()
        {
            throw new NotImplementedException();
        }

        public Task<CrdData> ReadById(long id)
        {
            throw new NotImplementedException();
        }

        public Task<CrdData> Update(CrdData entity)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<CrdData>> UpdateMany(IEnumerable<CrdData> entities)
        {
            throw new NotImplementedException();
        }
    }
}
