namespace Issuetracker_Backend.Model.Common
{
    public abstract record NamedEntityData : UniqueEntityData
    {
        public string Name { get; set; }
    }
}
