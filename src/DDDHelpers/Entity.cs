using System;

namespace Domain
{
    public abstract class Entity
    {
        public bool Deleted { get; protected set; }
        public DateTime CreateDate { get; protected set; }
        public long CreatedBy { get; protected set; }

        public void SetDeleted() => this.Deleted = true;
        public void UndoDeleted() => this.Deleted = false;
    }
}