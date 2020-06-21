using Autofac;
using Autofac.Core;
using BaseProject.InterFaces;
using System;
using System.Reflection;

namespace BaseProject.Services
{
    public static class EngineContext
    {
        private static ILifetimeScope _rootScope;

        public static void Start()
        {
            var builder = new ContainerBuilder();
            var assemblies = new[] { Assembly.GetExecutingAssembly() };

            builder.RegisterAssemblyTypes(assemblies)
                  .Where(t => typeof(IService).IsAssignableFrom(t))
                  .SingleInstance()
                  .AsImplementedInterfaces();
            builder.RegisterAssemblyTypes(assemblies)
                .Where(t => typeof(IViewModel).IsAssignableFrom(t))
                .AsImplementedInterfaces();


            _rootScope = builder.Build();
        }


        public static void Stop()
        {
            _rootScope.Dispose();
        }

        public static T Resolve<T>()
        {
            if (_rootScope == null)
            {
                throw new Exception("EngineContext hasn't been started!");
            }

            return _rootScope.Resolve<T>(Array.Empty<Parameter>());
        }

        public static T Resolve<T>(Parameter[] parameters)
        {
            if (_rootScope == null)
            {
                throw new Exception("EngineContext hasn't been started!");
            }

            return _rootScope.Resolve<T>(parameters);
        }
    }
}
