using Domain.Abstraction;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastrucure.Repositories
{
    public class ProviderRepository : IBaseRepository<Provider, long>
    {
        public SqlConnection _StoreContext;

        public ProviderRepository(SqlConnection storeContext)
        {
            _StoreContext = storeContext;
        }
        public async Task<Provider> Delete(Provider entity)
        {
            using (SqlCommand cmd = new SqlCommand("deleteProvider", _StoreContext))
            {
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("id", entity.Id);
                await cmd.ExecuteReaderAsync();
                return entity;
            }
        }

        public async Task<Provider> Insert(Provider entity)
        {
            using (SqlCommand cmd = new SqlCommand("deleteProvider", _StoreContext))
            {
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("id", entity.Id);
                await cmd.ExecuteReaderAsync();
                return entity;
            }
        }

        public async Task<IEnumerable<Provider>> ReadAll()
        {
            using (SqlCommand cmd = new SqlCommand("deleteProvider", _StoreContext))
            {
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                await cmd.ExecuteReaderAsync();
                return new List<Provider>();
            }
        }

        public async Task<Provider> ReadById(long id)
        {
            using (SqlCommand cmd = new SqlCommand("deleteProvider", _StoreContext))
            {
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                await cmd.ExecuteReaderAsync();
                return new Provider(0, Domain.Enums.ProviderType.GoPay);
            }
        }

        public async Task<Provider> Update(Provider entity)
        {
            using (SqlCommand cmd = new SqlCommand("deleteProvider", _StoreContext))
            {
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                await cmd.ExecuteReaderAsync();
                return new Provider(0, Domain.Enums.ProviderType.GoPay);
            }
        }
    }
}
