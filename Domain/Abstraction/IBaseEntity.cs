using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Abstraction
{
    /// <summary>
    /// Base definition for each Entity from database
    /// </summary>
    interface IBaseEntity
    {
        long Id { get; set; }
    }
}
