using BaseProject.InterFaces;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace BaseProject.Helpers
{
    public static class UtilityHelper
    {

        public static IEnumerable<TypeInfo> GetTypeInfos<TType>() where TType : IInterface
        {
            return typeof(TType).GetTypeInfo().Assembly.DefinedTypes
                                .Where(type => type.ImplementedInterfaces.Any(x => x == typeof(TType)));
        }
    }
}
