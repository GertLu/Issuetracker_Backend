using System.ComponentModel.DataAnnotations.Schema;

namespace WalletAppAPI.Models.Common
{
    public abstract record UniqueEntityData: ForeignEntityData
    {
        public string Id { get; set; }
    }
}
