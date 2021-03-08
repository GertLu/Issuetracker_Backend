using Issuetracker_Backend.Model.Common;
using System;

namespace Issuetracker_Backend.Model
{
    public record RecordData : UniqueEntityData
    {
        public string Title { get; init; }
        public string Description { get; init; }
        public string StateId { get; init; }
        public DateTime DueDate { get; init; }
        public string TableId { get; init; }
    }
}
