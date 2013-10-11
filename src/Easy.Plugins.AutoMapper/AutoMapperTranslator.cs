using AutoMapper;
using Easy.Plugins.Contracts.Translation;

namespace Easy.Plugins.AutoMapper
{
    public class AutoMapperTranslator : ITranslator
    {
        public T1 Translate<T, T1>(T p0)
        {
            return Mapper.Map<T, T1>(p0);
        }

        public T1 Translate<T, T1>(T p0, T1 obj1)
        {
            return Mapper.Map(p0,obj1);
        }
    }
}


