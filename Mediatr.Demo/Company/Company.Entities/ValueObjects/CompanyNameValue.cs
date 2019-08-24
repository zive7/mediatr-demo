namespace Company.Entities.ValueObjects
{
    using Core.Contracts.Exceptions;
    using Core.Contracts.ValueObjects;

    public sealed class CompanyNameValue : ValueObject<CompanyNameValue>
    {
        private const int MAX_LENGTH = 150;

        public string Value { get; }

        private CompanyNameValue(string value)
        {
            Value = value;
        }

        public static CompanyNameValue Create(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new NotAcceptableException("Company name is not valid");
            }

            if(name.Length > MAX_LENGTH)
            {
                throw new NotAcceptableException($"Company name cannot be greater than {MAX_LENGTH} characters");
            }

            return new CompanyNameValue(name);
        }

        public static implicit operator string(CompanyNameValue obj)
        {
            return obj.Value;
        }

        public static explicit operator CompanyNameValue(string value)
        {
            return Of(value);
        }

        private static CompanyNameValue Of(string value)
        {
            return Create(value);
        }
        protected override bool EqualsCore(CompanyNameValue other)
        {
            return Value == other.Value;
        }

        protected override int GetHashCodeCore()
        {
            unchecked
            {
                int hashCode = Value.GetHashCode();
                return hashCode;
            }
        }
    }
}