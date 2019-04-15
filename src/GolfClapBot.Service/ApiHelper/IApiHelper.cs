using System.Threading.Tasks;

namespace GolfClapBot.Service.ApiHelper
{
    public interface IApiHelper<T>
    {
        /// <summary>
        ///     Get data from a REST api and deserialize to the specified type.
        /// </summary>
        /// <param name="baseAddress">Base address of the api.</param>
        /// <param name="endPoint">Endpoint to call.</param>
        /// <returns>Deserialized object of specified type.</returns>
        Task<T> Get(string baseAddress, string endPoint);
    }
}