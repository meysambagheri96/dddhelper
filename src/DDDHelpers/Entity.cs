using System;

namespace Domain
{
    public abstract class Entity
    {
        public bool Deleted { get; protected set; }
        public DateTime CreateDate { get; protected set; }
    }
}