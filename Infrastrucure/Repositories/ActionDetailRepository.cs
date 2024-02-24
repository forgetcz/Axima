using Domain.Abstraction;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Infrastrucure.Repositories
{
    public class ActionDetailRepository : IBaseRepository<ActionDetail, long>
    {
        public SqlConnection _StoreContext;

        public ActionDetailRepository(SqlConnection storeContext)
        {
            _StoreContext = storeContext;
        }

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
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                await cmd.ExecuteReaderAsync();
                return new ActionDetail(0, "", "", new DateTime());
            }
        }

        public async Task<ActionDetail> Update(ActionDetail entity)
        {
            using (SqlCommand cmd = new SqlCommand("ReadByIdAction", _StoreContext))
            {
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                await cmd.ExecuteReaderAsync();
                return new ActionDetail(0, "", "", new DateTime());
            }
        }
    }
}
