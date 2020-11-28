using System;
using System.Threading.Tasks;
using PaninApi.Abstractions.Models;

namespace PaninApi.Abstractions.Services
{
    public interface ICoffeeShopService
    {
        /// <summary>
        /// Retrieves a barman from his email.
        /// </summary>
        /// <param name="email">Barman's email</param>
        /// <returns>The barman if exists, null otherwise.</returns>
        /// <exception cref="ArgumentNullException"></exception>
        Task<Barman> GetBarmanAsync(string email);
    }
}