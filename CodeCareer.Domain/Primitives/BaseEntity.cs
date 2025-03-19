using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeCareer.Primitives
{
    public abstract class BaseEntity
    {

        protected BaseEntity(Guid id)
        {
            this.Id = id;
        }

        public Guid Id { get; set; }
    }
}
