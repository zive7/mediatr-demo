namespace Core.Contracts.ValueObjects
{
    using System.Linq;
    using System.Collections.Generic;

    public abstract class ValueObjectBase
    {
        protected abstract IEnumerable<object> GetEqualityComponents();

        public override bool Equals(object obj)
        {
            var valueObject = obj as ValueObjectBase;

            if (ReferenceEquals(valueObject, null))
            {
                return false;
            }

            if (GetType() != obj.GetType())
            {
                return false;
            }

            return GetEqualityComponents().SequenceEqual(valueObject.GetEqualityComponents());
        }

        public override int GetHashCode()
        {
            return GetEqualityComponents()
                .Aggregate(1, (current, obj) =>
                {
                    unchecked
                    {
                        return (current * 23) + (obj?.GetHashCode() ?? 0);
                    }
                });
        }

        public static bool operator ==(ValueObjectBase a, ValueObjectBase b)
        {
            if (ReferenceEquals(a, null) && ReferenceEquals(b, null))
            {
                return true;
            }

            if (ReferenceEquals(a, null) || ReferenceEquals(b, null))
            {
                return false;
            }

            return a.Equals(b);
        }

        public static bool operator !=(ValueObjectBase a, ValueObjectBase b)
        {
            return !(a == b);
        }

        public static ValueObjectBase operator +(ValueObjectBase a, ValueObjectBase b)
        {
            return a + b;
        }

        public static ValueObjectBase operator -(ValueObjectBase a, ValueObjectBase b)
        {
            return a - b;
        }
    }
}
