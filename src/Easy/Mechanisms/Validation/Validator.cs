using Easy.Mechanisms.Validation.Expressions;

namespace Easy.Mechanisms.Validation
{
    public static class Validator
    {
        public static ThisExpression<T> This<T>(T obj)
        {
            return new ThisExpression<T>(obj);
        }
    }
}
