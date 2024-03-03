using Domain.Entities;
using Infrastrucure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    /// <summary>
    /// Definition of ActionDetail
    /// </summary>
    public interface IDataService
    {
        IBaseDbRepository<ActionProvider, Guid> GetActionDetailRpository();
    }
}
