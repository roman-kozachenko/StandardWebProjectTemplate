using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DevBridge.Templates.WebProject.DataEntities.Entities;

namespace DevBridge.Templates.WebProject.DataEntities.Mappings
{
    public class CommentMap : PersistentEntityMapBase<Comment>
    {
        public CommentMap()
        {
            Id(f => f.Id).GeneratedBy.Identity();

            Map(f => f.UserId).Not.Nullable();
            Map(f => f.Text).Not.Nullable();

            References(f => f.Article).Not.Nullable();
            References(f => f.ParentComment).Nullable();

            HasMany(f => f.Likes).Cascade.Delete();
        }
    }
}
