using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DevBridge.Templates.WebProject.DataEntities.Entities
{
    public class Comment : PersistentEntityBase<Comment>
    {
        public virtual Guid UserId { get; set; }
        public virtual string Text { get; set; }
        public virtual Article Article { get; set; }
        public virtual Comment ParentComment { get; set; }

        public virtual IList<Comment> Comments { get; set; }
        public virtual IList<Like> Likes { get; set; }
    }
}
