using System;

namespace Domain
{
    public abstract class Entity
    {
        public bool Deleted { get; set; }
        public DateTime CreateDate { get; set; }
    }
}