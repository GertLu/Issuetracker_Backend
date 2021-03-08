using Issuetracker_Backend.Model.Common;

namespace Issuetracker_Backend.Model
{
    public record TableStateData : NamedEntityData
    {
        public string TableId { get; init; }
        public bool FinalState { get; init; }
    }
}
