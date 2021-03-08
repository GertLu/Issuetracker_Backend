using System;
using WalletAppAPI.Models.Common;

namespace Issuetracker_Backend.Model
{
    public record StateData : NamedEntityData
    {
        public string RecordId { get; init; }
        public DateTime DateStarted { get; init; }
        public DateTime DateFinished { get; init; }
        public bool FinalState { get; init; }
    }
}