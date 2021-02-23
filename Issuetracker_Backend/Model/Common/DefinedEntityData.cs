using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WalletAppAPI.Models.Common;

namespace Issuetracker_Backend.Model.Common
{
    public abstract record DefinedEntityData :NamedEntityData
    {
        public string Description { get; init; }
    }
}
