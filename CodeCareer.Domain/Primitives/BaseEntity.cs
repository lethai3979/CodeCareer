using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeCareer.Primitives
{
    public abstract class BaseEntity<EntityId> where EntityId : Primitives.EntityId
    {

        protected BaseEntity(EntityId id)
        {
            this.Id = id;
        }

        public EntityId Id { get; set; }
    }
}
