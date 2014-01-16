using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DevBridge.Templates.WebProject.DataEntities.Entities
{
    public class Like : EntityBase<Like>
    {
        public virtual Guid UserId { get; set; }
        public virtual Comment Comment { get; set; }
    }
}
