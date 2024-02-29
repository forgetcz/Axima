using Domain.Abstraction;
using Domain.Enums;

namespace Domain.Entities
{
    /// <summary>
    /// Specific definition for Provider detail table items
    /// </summary>
    public class Provider : BaseEntity
    {
        public ProviderType ProviderType { get; set; }

        public Provider(long id, ProviderType providerType): base(id)
        {
            this.ProviderType = providerType;
        }
    }
}
