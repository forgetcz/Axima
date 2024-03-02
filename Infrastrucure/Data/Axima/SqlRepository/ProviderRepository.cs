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
using System.ComponentModel.Composition;
using Infrastrucure.Enums;

namespace Infrastrucure.Data.Axima.SqlRepository
{
    //[Export(typeof(IBaseDbRepository<ActionProvider, Guid>))]
    [ExportMetadata(nameof(eMefAttribute.exportedTpe), typeof(ActionProvider))]
    [ExportMetadata(nameof(eMefAttribute.repositoryType), Enums.eDomainSourceRepositoryType.SQL)]
    public class ProviderRepository : IBaseDbRepository<ActionProvider, Guid>
    {
        public SqlConnection _StoreContext;

        [ImportingConstructor]
        public ProviderRepository([Import("connectionString")] string connectionString)
        {
            _StoreContext = new SqlConnection(connectionString);
        }

        public Task<ActionProvider> Delete(ActionProvider entity)
        {
            throw new NotImplementedException();
        }

        public Task DeleteMany(IEnumerable<ActionProvider> entities)
        {
            throw new NotImplementedException();
        }

        public Task<ActionProvider> Insert(ActionProvider entity)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<ActionProvider>> InsertMany(IEnumerable<ActionProvider> entities)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<ActionProvider>> ReadAll()
        {
            throw new NotImplementedException();
        }

        public Task<ActionProvider> ReadById(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<ActionProvider> Update(ActionProvider entity)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<ActionProvider>> UpdateMany(IEnumerable<ActionProvider> entities)
        {
            throw new NotImplementedException();
        }

        /*
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
                return new AcrtionProvider(default, Domain.Enums.eActionProviderType.GoPay);
            }
        }

        public async Task<AcrtionProvider> Update(AcrtionProvider entity)
        {
            using (SqlCommand cmd = new SqlCommand("deleteProvider", _StoreContext))
            {
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                await cmd.ExecuteReaderAsync();
                return new AcrtionProvider(default, Domain.Enums.eActionProviderType.GoPay);
            }
        }
        */
    }
}
