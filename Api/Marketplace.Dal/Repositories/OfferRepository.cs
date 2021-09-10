using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Marketplace.Core.Dal;
using Marketplace.Core.Model;
using Microsoft.EntityFrameworkCore;

namespace Marketplace.Dal.Repositories
{
    public class OfferRepository : IOfferRepository
    {
        #region Fields

        private readonly MarketplaceContext context;

        #endregion

        #region Constructors
        public OfferRepository()
        {
            this.context = new MarketplaceContext();
        }

        #endregion


        #region Methods

        /// <inheritdoc />

        public async Task<Offer[]> GetAllOffersAsync()
        {
            return await this.context.Offers.ToArrayAsync();
        }

        public async Task InsertOfferAsync(Offer offer)
        {
            this.context.Add(offer);
            await this.context.SaveChangesAsync();
        }

        #endregion
    }
}
