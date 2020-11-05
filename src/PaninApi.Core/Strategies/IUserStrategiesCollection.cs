using System.Collections.Generic;

namespace PaninApi.Core.Strategies
{
    /// <summary>
    /// 
    /// </summary>
    public interface IUserStrategiesCollection : IEnumerable<>
    {
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TUserStrategy"></typeparam>
        void Add<TUserStrategy>();
    }
}