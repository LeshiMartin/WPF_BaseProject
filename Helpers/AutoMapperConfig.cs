using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace BaseProject.Helpers
{
    //public class CustomMapperConfiguration : IMapperConfiguration
    //{
    //    public Action<IMapperConfigurationExpression> GetConfiguration()
    //    {
    //        Action<IMapperConfigurationExpression> action;    
    //        return action;
    //    }

    //    /// <summary>
    //    /// Order of this mapper implementation
    //    /// </summary>
    //    public int Order
    //    {
    //        get { return 0; }
    //    }
    //}

    /// <summary>
    /// AutoMapper configuration
    /// </summary>
    public static class AutoMapperConfiguration
    {
        private static MapperConfiguration _mapperConfiguration;
        private static IMapper _mapper;

        /// <summary>
        /// Initialize mapper
        /// </summary>
        /// <param name="configurationActions">Configuration actions</param>
        public static void Init(List<Action<IMapperConfigurationExpression>> configurationActions)
        {
            if (configurationActions == null)
                throw new ArgumentNullException(nameof(configurationActions));

            _mapperConfiguration = new MapperConfiguration(cfg =>
            {
                foreach (var ca in configurationActions)
                    ca(cfg);
            });

            _mapper = _mapperConfiguration.CreateMapper();
        }

        /// <summary>
        /// Mapper
        /// </summary>
        public static IMapper Mapper
        {
            get
            {
                return _mapper;
            }
        }

        /// <summary>
        /// Mapper configuration
        /// </summary>
        public static MapperConfiguration MapperConfiguration
        {
            get
            {
                return _mapperConfiguration;
            }
        }
    }

    public static class AutoMapperConfig
    {
        /// <summary>
        /// Maps to.
        /// </summary>
        /// <typeparam name="TSource">The type of the t source.</typeparam>
        /// <typeparam name="TDestination">The type of the t destination.</typeparam>
        /// <param name="source">The source.</param>
        /// <returns>TDestination.</returns>
        public static TDestination MapTo<TSource, TDestination>(this TSource source)
        {
            return AutoMapperConfiguration.Mapper.Map<TSource, TDestination>(source);
        }

        /// <summary>
        /// Maps to.
        /// </summary>
        /// <typeparam name="TSource">The type of the t source.</typeparam>
        /// <typeparam name="TDestination">The type of the t destination.</typeparam>
        /// <param name="source">The source.</param>
        /// <param name="destination">The destination.</param>
        /// <returns>TDestination.</returns>
        public static TDestination MapTo<TSource, TDestination>(this TSource source, TDestination destination)
        {
            return AutoMapperConfiguration.Mapper.Map(source, destination);
        }

        public static MapperConfiguration MapConfig => AutoMapperConfiguration.MapperConfiguration;

        public static IMapper Mapper => AutoMapperConfiguration.Mapper;
        #region ToEntity



        #endregion


    }
}
