using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentNHibernate.Mapping;


namespace MasterServer.EntitiesMapping
{
    public class GameMapping : ClassMap<Entities.Game>
    {
        public GameMapping()
        {
            Table("GAME");
            Id(x => x.id, "IDGAME").GeneratedBy.TriggerIdentity();
            Map(x => x.maxPlayerCount, "MAXPLAYERCOUNT");
            Map(x => x.currentPlayerCount, "CURRENTPLAYERCOUNT");
            Map(x => x.name, "NAME");
            HasMany(x => x.players).KeyColumn("GAME").Not.LazyLoad().Inverse().Cascade.All();
        }
    }
}
