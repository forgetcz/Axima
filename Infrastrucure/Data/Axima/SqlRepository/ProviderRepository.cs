using Domain.Interfaces;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infrastrucure.Interfaces;
using Domain.Entities.Axima;

namespace Infrastrucure.Data.Repositories.SqlStoredProcedures
{
    public class ProviderRepository //: IBaseDbRepository<AcrtionProvider, long>
    {
        public SqlConnection _StoreContext;

        public ProviderRepository(SqlConnection storeContext)
        {
            _StoreContext = storeContext;
        }
        public async Task<AcrtionProvider> Delete(AcrtionProvider entity)
        {
            using (SqlCommand cmd = new SqlCommand("deleteProvider", _StoreContext))
            {
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("id", entity.Id);
                await cmd.ExecuteReaderAsync();
                return entity;
            }
        }

        public async Task<AcrtionProvider> Insert(AcrtionProvider entity)
        {
            using (SqlCommand cmd = new SqlCommand("deleteProvider", _StoreContext))
            {
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("id", entity.Id);
                await cmd.ExecuteReaderAsync();
                return entity;
            }
        }

        public async Task<IEnumerable<AcrtionProvider>> ReadAll()
        {
            using (SqlCommand cmd = new SqlCommand("deleteProvider", _StoreContext))
            {
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                await cmd.ExecuteReaderAsync();
                return new List<AcrtionProvider>();
            }
        }

        public async Task<AcrtionProvider> ReadById(long id)
        {
            using (SqlCommand cmd = new SqlCommand("deleteProvider", _StoreContext))
            {
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                await cmd.ExecuteReaderAsync();
                return new AcrtionProvider("", Domain.Enums.eActionProviderType.GoPay);
            }
        }

        public async Task<AcrtionProvider> Update(AcrtionProvider entity)
        {
            using (SqlCommand cmd = new SqlCommand("deleteProvider", _StoreContext))
            {
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                await cmd.ExecuteReaderAsync();
                return new AcrtionProvider("", Domain.Enums.eActionProviderType.GoPay);
            }
        }
    }
}
