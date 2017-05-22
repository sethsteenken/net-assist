using System;

namespace NetAssist.Domain
{
    public abstract class Entity<TId> : IEntity<TId>, IEquatable<Entity<TId>>
    {
        public TId Id { get; protected set; }

        public virtual bool IsNew => object.Equals(this.Id, default(TId));

        protected Entity(TId id)
        {
            if (object.Equals(id, default(TId)))
                throw new ArgumentException(string.Format("The Identifier of type {0} cannot be the type's default value.", typeof(TId)), "id");

            this.Id = id;
        }

        protected Entity() { }

        public override bool Equals(object obj)
        {
            var entity = obj as Entity<TId>;
            if (entity != null)
                return this.Equals(entity);

            return base.Equals(obj);
        }

        public override int GetHashCode() => Id.GetHashCode();

        public bool Equals(Entity<TId> other)
        {
            if (other == null)
                return false;

            return this.Id.Equals(other.Id);
        }

        public static bool operator ==(Entity<TId> x, Entity<TId> y)
        {
            if (Equals(null, x) && Equals(null, y))
                return true;

            if (Equals(null, x))
                return false;

            return x.Equals(y);
        }

        public static bool operator !=(Entity<TId> x, Entity<TId> y)
        {
            return !(x == y);
        }
    }
}
