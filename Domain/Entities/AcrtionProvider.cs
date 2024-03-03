using Domain.Abstraction;
using Domain.Enums;

namespace Domain.Entities
{
    /// <summary>
    /// Specific definition for Provider detail table items
    /// </summary>
    public class AcrtionProvider : BaseEntity
    {
        public eActionProviderType ProviderType { get; set; }

        public AcrtionProvider(long id, eActionProviderType providerType): base(id)
        {
            this.ProviderType = providerType;
        }
    }
}
