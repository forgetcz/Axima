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

namespace Infrastrucure.Data.Crd.MemoryRepository
{
    [Export(typeof(IBaseDbRepository<CrdData, long>))]
    [ExportMetadata(nameof(eMefAttribute.exportedTpe), typeof(CrdData))]
    [ExportMetadata(nameof(eMefAttribute.repositoryType), Enums.eDomainSourceRepositoryType.Memory)]

    public class CrdDataRpository : IBaseDbRepository<CrdData, long>
    {
        SortedList<long, CrdData> storage = new SortedList<long, CrdData>();

        [ImportingConstructor]
        public CrdDataRpository()
        {
        }

        public Task<CrdData> Delete(CrdData entity)
        {
            if (storage.Remove(entity.Id))
            {
                entity.Id = -1;
            }
            return Task.FromResult(entity);
        }

        public Task DeleteMany(IEnumerable<CrdData> entities)
        {
            foreach (var entity in entities)
            {
                storage.Remove(entity.Id);
                entity.Id = -1;
            }

            return Task.CompletedTask;
        }

        public Task<CrdData> Insert(CrdData entity)
        {
            storage.Add(entity.Id, entity);
            return Task.FromResult(entity);
        }

        public async Task<IEnumerable<CrdData>> InsertMany(IEnumerable<CrdData> entities)
        {
            List<CrdData> result = new List<CrdData>();
            foreach (var entity in entities)
            {
                var updatedEntity = await Insert(entity);
            }
            return result;
        }

        public Task<IEnumerable<CrdData>> ReadAll()
        {
            return Task.FromResult(storage.Values.AsEnumerable());
        }

        public Task<CrdData> ReadById(long id)
        {
            if (storage.ContainsKey(id))
            {
                var entity = storage[id];
                return Task.FromResult(entity);
            }
            return Task.FromResult(new CrdData(-1, "", "", DateTime.Now, DateTime.Now, 0, 0, "", ""));
        }

        public Task<CrdData> Update(CrdData entity)
        {
            if (storage.ContainsKey(entity.Id))
            {
                storage[entity.Id] = entity;
            }
            return Task.FromResult(entity);
        }

        public async Task<IEnumerable<CrdData>> UpdateMany(IEnumerable<CrdData> entities)
        {
            List<CrdData> result = new List<CrdData>();
            foreach (var entity in entities)
            {
                var res = await Update(entity);
                result.Add(res);
            }
            return result;
        }
    }
}