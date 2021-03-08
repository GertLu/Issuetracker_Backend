using System;
using WalletAppAPI.Models.Common;

namespace Issuetracker_Backend.Model
{
    public record RecordData: UniqueEntityData
    {
        public string Title { get; init; }
        public string Description { get; init; }
        public StateData State { get; init; }
        public DateTime DueDate  { get; init; }
        public string TableId { get; init; }
    }
}
