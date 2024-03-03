using Domain.Entities;
using Infrastrucure.Enums;
using Infrastrucure.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace Infrastrucure.Data.SqlRepository
{
    //[Export(typeof(IBaseDbRepository<ActionDetail, long>))]
    [ExportMetadata(nameof(eMefAttribute.exportedTpe), typeof(ActionDetail))]
    [ExportMetadata(nameof(eMefAttribute.repositoryType), Enums.eDomainSourceRepositoryType.SQL)]
    public class ActionDetailRpository : IBaseDbRepository<ActionDetail, Guid>
    {
        public SqlConnection _StoreContext;

        [ImportingConstructor]

        public ActionDetailRpository([Import("connectionString")] string connectionString)
        {
            _StoreContext = new SqlConnection(connectionString);
        }

        public Task<ActionDetail> Delete(ActionDetail entity)
        {
            throw new NotImplementedException();
        }

        public Task DeleteMany(IEnumerable<ActionDetail> entities)
        {
            throw new NotImplementedException();
        }

        public Task<ActionDetail> Insert(ActionDetail entity)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<ActionDetail>> InsertMany(IEnumerable<ActionDetail> entities)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<ActionDetail>> ReadAll()
        {
            throw new NotImplementedException();
        }

        public Task<ActionDetail> ReadById(long id)
        {
            throw new NotImplementedException();
        }

        public Task<ActionDetail> Update(ActionDetail entity)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<ActionDetail>> UpdateMany(IEnumerable<ActionDetail> entities)
        {
            throw new NotImplementedException();
        }
    }
}
