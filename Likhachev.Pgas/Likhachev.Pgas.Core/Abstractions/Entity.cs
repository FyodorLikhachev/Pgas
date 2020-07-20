using System;
using System.Collections.Generic;
using System.Text;

namespace Likhachev.Pgas.Core.Abstractions
{
    public abstract class Entity : IHasId
    {
        public int Id { get; protected set; }

        public override bool Equals(object anotherObject)
        {
            if (!(anotherObject is Entity anotherEntity))
                return false;

            return OrmCacheEquals(this, anotherEntity) || DefaultEquals(this, anotherEntity);
        }

        public override int GetHashCode()
        {
            // It's OK only for persisted HasIdBase.

            return Id.GetHashCode();
        }


        public static bool operator ==(Entity entity, Entity anotherEntity)
        {
            if (ReferenceEquals(entity, null) && ReferenceEquals(anotherEntity, null))
                return true;

            if (ReferenceEquals(entity, null) || ReferenceEquals(anotherEntity, null))
                return false;

            return entity.Equals(anotherEntity);
        }

        public static bool operator !=(Entity entity, Entity anotherEntity)
        {
            if (ReferenceEquals(entity, null) && ReferenceEquals(anotherEntity, null))
                return false;

            if (ReferenceEquals(entity, null) || ReferenceEquals(anotherEntity, null))
                return true;

            return !entity.Equals(anotherEntity);
        }

        private static bool OrmCacheEquals(object entity, object anotherEntity) =>
            ReferenceEquals(entity, anotherEntity);

        private static bool DefaultEquals(IHasId entity, IHasId anotherEntity)
        {
            if (entity.Id.Equals(default) || anotherEntity.Id.Equals(default))
                return false;

            if (!entity.Id.Equals(anotherEntity.Id))
                return false;

            Type entity1Type = entity.GetType();
            Type entity2Type = anotherEntity.GetType();

            return entity1Type == entity2Type ||
                   entity1Type.IsSubclassOf(entity2Type) ||
                   entity2Type.IsSubclassOf(entity1Type);
        }
    }
}
