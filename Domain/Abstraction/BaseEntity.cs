using Domain.Interfaces;
using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Abstraction
{
    /// <summary>
    /// Base (core) database entity definition
    /// </summary>
    public abstract class BaseEntity : IBaseEntity
    {
        public long Id { get; set; }

        public BaseEntity(long id)
        {
            Id = id;
        }
    }
}
