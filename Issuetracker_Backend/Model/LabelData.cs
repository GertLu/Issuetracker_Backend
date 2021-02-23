namespace Issuetracker_Backend.Model
{
    public record LabelData
    {
        public string Id { get; init; }
        public string Name { get; init; }
        public string RecordId { get; init; }
        public string ColorId { get; init; }
    }
}