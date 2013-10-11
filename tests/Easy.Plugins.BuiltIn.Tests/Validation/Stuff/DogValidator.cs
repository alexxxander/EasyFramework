using Easy.Plugins.BultIn.Validation;
using Easy.Plugins.Tests.Validation.Stuff;

namespace Easy.Plugins.BuiltIn.Tests.Validation.Stuff
{
    public class DogValidator:ValidationRuleSet<Mouse>
    {
        public DogValidator() {
            AddRule(d => d.Age > 10, "There's no dog so old");
        }
    }
}
