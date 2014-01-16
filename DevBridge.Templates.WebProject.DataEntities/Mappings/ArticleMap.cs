using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DevBridge.Templates.WebProject.DataEntities.Entities;

namespace DevBridge.Templates.WebProject.DataEntities.Mappings
{
    public class ArticleMap : PersistentEntityMapBase<Article>
    {
        public ArticleMap()
        {
            Id(f => f.Id).GeneratedBy.Identity();

            Map(f => f.UserId).Not.Nullable();
            Map(f => f.Title).Not.Nullable();
            Map(f => f.Text).Not.Nullable().Length(65535);

            HasMany(f => f.Comments).Cascade.Delete();
        }
    }
}
