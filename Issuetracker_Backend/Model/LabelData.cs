using Issuetracker_Backend.Model.Common;

namespace Issuetracker_Backend.Model
{
    public record LabelData : NamedEntityData
    {
        public string RecordId { get; init; }
        public string ColorId { get; init; }
    }
}