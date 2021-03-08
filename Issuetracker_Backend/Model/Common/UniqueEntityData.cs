namespace Issuetracker_Backend.Model.Common
{
    public abstract record UniqueEntityData : ForeignEntityData
    {
        public string Id { get; set; }
    }
}
