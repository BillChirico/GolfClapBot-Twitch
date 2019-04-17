using System.Threading.Tasks;
using GolfClapBot.Domain.Integrations.Fortnite;

namespace GolfClapBot.Service.Integrations.Fortnite
{
    public interface IFortniteApi
    {
        /// <summary>
        ///     Get Fortnite stats from the tracker network.
        /// </summary>
        /// <returns>Fortnite stats.</returns>
        Task<FortniteStats> Get();
    }
}