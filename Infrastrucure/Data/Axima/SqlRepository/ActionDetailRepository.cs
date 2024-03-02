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
using Infrastrucure.Enums;
using System.ComponentModel.Composition;

namespace Infrastrucure.Data.Axima.SqlRepository
{
    //[Export(typeof(IBaseDbRepository<ActionDetail, Guid>))]
    [ExportMetadata(nameof(eMefAttribute.exportedTpe), typeof(ActionDetail))]
    [ExportMetadata(nameof(eMefAttribute.repositoryType), Enums.eDomainSourceRepositoryType.SQL)]
    public class ActionDetailRepository : IBaseDbRepository<ActionDetail, Guid>
    {
        public SqlConnection _StoreContext;

        public ActionDetailRepository([Import("connectionString")] string connectionString)
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

        public Task<ActionDetail> ReadById(Guid id)
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

        /*
        public async Task<ActionDetail> Delete(ActionDetail entity)
        {
            using (SqlCommand cmd = new SqlCommand("deleteAction", _StoreContext))
            {
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("id", entity.Id);
                await cmd.ExecuteReaderAsync();
                return entity;
            }
        }

        public async Task<ActionDetail> Insert(ActionDetail entity)
        {
            using (SqlCommand cmd = new SqlCommand("insertAction", _StoreContext))
            {
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("id", entity.Id);
                await cmd.ExecuteReaderAsync();
                return entity;
            }
        }

        public async Task<IEnumerable<ActionDetail>> ReadAll()
        {
            using (SqlCommand cmd = new SqlCommand("readAllAction", _StoreContext))
            {
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                await cmd.ExecuteReaderAsync();
                return new List<ActionDetail>();
            }
        }

        public async Task<ActionDetail> ReadById(long id)
        {
            using (SqlCommand cmd = new SqlCommand("ReadByIdAction", _StoreContext))
            {
                if (!string.IsNullOrEmpty(_StoreContext.ConnectionString))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    await cmd.ExecuteReaderAsync();
                }
                return new ActionDetail(default, "", "", new DateTime());
            }
        }

        public async Task<ActionDetail> Update(ActionDetail entity)
        {
            using (SqlCommand cmd = new SqlCommand("ReadByIdAction", _StoreContext))
            {
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                await cmd.ExecuteReaderAsync();
                return new ActionDetail(default, "", "", new DateTime());
            }
        }
        */
    }
}
