using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DevBridge.Templates.WebProject.DataEntities.Entities;

namespace DevBridge.Templates.WebProject.DataEntities.Mappings
{
    public class LikeMap : EntityMapBase<Like>
    {
        public LikeMap()
        {
            Id(f => f.Id).GeneratedBy.Identity();

            Map(f => f.UserId).Not.Nullable();

            References(f => f.Comment).Not.Nullable();
        }
    }
}
