using Easy.Mechanisms.Translation.Expressions;

namespace Easy.Mechanisms.Translation
{
    public static class Translate
    {
        public static ToExpression<T> This<T>(T obj)
        {
            return new ToExpression<T>(obj);
        }
    }
}