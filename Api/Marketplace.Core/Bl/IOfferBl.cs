using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Marketplace.Core.Model;

namespace Marketplace.Core.Bl
{
    /// <summary>
    /// Contract for the Offer logic
    /// </summary>
    public interface IOfferBl
    {
        #region Methods

        Task<IEnumerable<Offer>> GetOffersAsync();

        Task CreateOfferAsync(Offer offer);
        #endregion

    }
}
