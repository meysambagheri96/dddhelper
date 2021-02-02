using System;

namespace Domain
{
    public class DomainValidationException : Exception
    {
        public DomainValidationException(string message) : base(message)
        {
        }

        public virtual string PropertyName { get; set; }
    }
}