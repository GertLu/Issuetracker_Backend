using WalletAppAPI.Models.Common;

namespace Issuetracker_Backend.Model
{
    public record LabelData : NamedEntityData
    {
        public string RecordId { get; init; }
        public string ColorCode { get; init; }
    }
}