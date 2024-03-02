using Domain.Abstraction;
using Domain.Enums;
using System;

namespace Domain.Entities.Axima
{
    /// <summary>
    /// Specific definition for Provider detail table items
    /// </summary>
    public class ActionProvider : BaseEntity<Guid>
    {
        public eActionProviderType ProviderType { get; set; }

        public ActionProvider(Guid id, eActionProviderType providerType): base(id)
        {
            this.ProviderType = providerType;
        }
    }
}
