using System;

namespace Issuetracker_Backend.Model
{
    public record RecordStateData
    {
        public string RecordId { get; init; }
        public string StateId { get; init; }
        public DateTime DateStarted { get; init; }
        public DateTime DateFinished { get; init; }
    }
}