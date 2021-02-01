namespace Domain
{
    public class EntityNotFoundException : DomainValidationException
    {
        public EntityNotFoundException(string message) : base(message)
        {
        }
    }
}