using System;

namespace Domain
{
    public abstract class Entity<T> : Entity
    {
        public T Id { get; protected set; }

        public override bool Equals(object obj)
        {
            var other = obj as Entity<T>;
            if (other is null)
            {
                return false;
            }

            if (ReferenceEquals(this, other))
            {
                return true;
            }

            if (this.GetType() != other.GetType())
            {
                return false;
            }

            var idType = this.Id.GetType();
            if (idType == typeof(Guid))
            {
                return Guid.Parse(this.Id.ToString()) == Guid.Parse(other.Id.ToString());
            }
            else if (idType == typeof(long) || this.Id.GetType() == typeof(int))
            {
                return long.Parse(this.Id.ToString()) == long.Parse(other.Id.ToString());
            }
            else if (idType == typeof(string))
            {
                return this.Id.ToString() == other.Id.ToString();
            }

            throw new NotSupportedException("only long and guid id is supported");
        }

        public static bool operator ==(Entity<T> first, Entity<T> second)
        {
            if (first is null && second is null)
            {
                return true;
            }

            if (first is null || second is null)
            {
                return false;
            }

            return first.Equals(second);
        }

        public static bool operator !=(Entity<T> first, Entity<T> second) => !(first == second);

        public override int GetHashCode() => (this.GetType().ToString() + this.Id).GetHashCode();
    }
}