using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DevBridge.Templates.WebProject.DataEntities.Entities
{
    public class Article : PersistentEntityBase<Article>
    {
        public virtual Guid UserId { get; set; }
        public virtual string Title { get; set; }
        public virtual string Text { get; set; }

        public virtual IList<Comment> Comments { get; set; }
    }
}
