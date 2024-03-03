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

    public class CrdDataRpository1 : IBaseDbRepository<CrdData, long>//IBaseDbRepository<CrdData, long>
    {
        SortedList<long, CrdData> storage = new SortedList<long, CrdData>();

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