using Domain.Abstraction;
using Domain.Enums;

namespace Domain.Entities.Axima
{
    /// <summary>
    /// Specific definition for Provider detail table items
    /// </summary>
    public class AcrtionProvider : BaseEntity<string>
    {
        public eActionProviderType ProviderType { get; set; }

        public AcrtionProvider(string id, eActionProviderType providerType): base(id)
        {
            this.ProviderType = providerType;
        }
    }
}
