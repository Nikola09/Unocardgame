using FluentNHibernate.Mapping;
using System.Linq;

namespace Cards.EntitiesMapping
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
            Map(x => x.status, "STATUS");
            HasMany(x => x.players).KeyColumn("GAME").Not.LazyLoad().Inverse().Cascade.All();
        }
    }
}
