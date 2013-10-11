using System.Collections.Generic;

namespace Easy.Plugins.Contracts.Validation
{
    public interface IValidator
    {
        List<string> Validate<T>(T obj);
    }
}