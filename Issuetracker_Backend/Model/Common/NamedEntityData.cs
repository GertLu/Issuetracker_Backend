namespace WalletAppAPI.Models.Common
{
    public abstract record NamedEntityData : UniqueEntityData
    {
        public string Name { get; set; }
    }
}
