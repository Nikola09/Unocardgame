using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentNHibernate.Mapping;

namespace Cards.EntitiesMapping
{
    public class PlayerMapping : ClassMap<Entities.Player>
    {
        public PlayerMapping()
        {
            Table("PLAYER");
            Id(x => x.id, "IDPLAYER").GeneratedBy.TriggerIdentity();
            Map(x => x.username, "USERNAME");
            Map(x => x.password, "PASSWORD");
            Map(x => x.winCount, "WINCOUNT");
            References(x => x.game).Column("GAME").Not.LazyLoad();
        }
    }
}
