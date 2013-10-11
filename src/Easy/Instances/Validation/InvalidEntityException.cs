namespace Easy.Instances.Validation
{
    public class InvalidEntityException : DomainException
    {
        public InvalidEntityException(params string[] messages):base(messages)
        {
        }
    }
}
