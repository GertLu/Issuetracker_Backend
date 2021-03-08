namespace Issuetracker_Backend.Model.Common
{
    public abstract record DefinedEntityData : NamedEntityData
    {
        public string Description { get; init; }
    }
}
