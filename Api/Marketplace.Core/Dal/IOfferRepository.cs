using System;
namespace Marketplace.Core.Dal
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Marketplace.Core.Model;

    /// <summary>
    /// Contract for the Offer data access
    /// </summary>
    public interface IOfferRepository
    {
        #region Methods

        /// <summary>
        /// Gets all offers asynchronous.
        /// </summary>
        /// <returns>Array of offers</returns>
        Task<Offer[]> GetAllOffersAsync();

        Task InsertOfferAsync(Offer offer);

        #endregion
    }
}
