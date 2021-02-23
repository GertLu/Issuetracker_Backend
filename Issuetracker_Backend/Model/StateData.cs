using System;

namespace Issuetracker_Backend.Model
{
    public record StateData
    {
        public string Id { get; init; }
        public string RecordId { get; init; }
        public string Name { get; init; }
        public DateTime DateStarted { get; init; }
        public DateTime DateFinished { get; init; }
        public bool FinalState { get; init; }
    }
}