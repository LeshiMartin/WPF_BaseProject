using BaseProject.Services.Contracts;
using System;
using System.Reflection;

namespace BaseProject.Services.Implementations
{
    public class ObjectActivator : IObjectActivator
    {
        public object CreateObject(TypeInfo type)
        {
            return Activator.CreateInstance(type);
        }
        public TModel CreateObject<TModel>(TypeInfo type) where TModel : class
        {
            return Activator.CreateInstance(type) as TModel;
        }
    }
}
