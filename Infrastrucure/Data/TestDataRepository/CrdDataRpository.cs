using Domain.Entities;
using Infrastrucure.Configuration;
using Infrastrucure.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastrucure.Data.Repositories.TestDataRepository
{
    [DataRepositoryExportAttributes(Enums.eDomainSourceRepositoryType.Test)]

    public class CrdDataRpository : IBaseDbRepository<CrdData, long>//IBaseDbRepository<CrdData, long>
    {
        SortedList<long, CrdData> storage = new SortedList<long, CrdData>();

        [ImportingConstructor]
        public CrdDataRpository()
        {
        }

        public Task<CrdData> Delete(CrdData entity)
        {
            if (entity.Id.HasValue)
            {
                storage.Remove(entity.Id.Value);
                entity.Id = null;
            }
            return Task.FromResult(entity);
        }

        public Task DeleteMany(IEnumerable<CrdData> entities)
        {
            foreach (var entity in entities)
            {
                if (entity.Id.HasValue)
                {
                    storage.Remove(entity.Id.Value);
                    entity.Id = null;
                }
            }

            return Task.CompletedTask;
        }

        public Task<CrdData> Insert(CrdData entity)
        {
            if (entity.Id.HasValue)
            {
                storage.Add(entity.Id.Value, entity);
            }
            else
            {
                long max = storage.Keys.Max() + 1;
                entity.Id = max;
                return Insert(entity);
            }
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
            return Task.FromResult(new CrdData(0, "", "", DateTime.Now, DateTime.Now, 0, 0, "", ""));
        }

        public Task<CrdData> Update(CrdData entity)
        {
            if (entity.Id.HasValue)
            {
                if (storage.ContainsKey(entity.Id.Value))
                {
                    storage[entity.Id.Value] = entity;
                }
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