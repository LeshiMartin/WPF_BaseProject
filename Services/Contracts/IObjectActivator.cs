using BaseProject.InterFaces;
using System.Reflection;

namespace BaseProject.Services.Contracts
{
    public interface IObjectActivator : IService
    {
        object CreateObject(TypeInfo type);
        TModel CreateObject<TModel>(TypeInfo type) where TModel : class;
    }
}