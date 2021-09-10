using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Marketplace.Core.Bl;
using Marketplace.Core.Dal;
using Marketplace.Core.Model;

namespace Marketplace.Bl
{
    /// <summary>
    /// Users' logic 
    /// </summary>
    /// <seealso cref="Marketplace.Core.Bl.IOfferBl" />
    public class OfferBl : IOfferBl
    {
        #region Fields

        private readonly IOfferRepository offerRepository;

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="OfferBl"/> class.
        /// </summary>
        /// <param name="offerRepository">The user repository.</param>
        public OfferBl(IOfferRepository offerRepository)
        {
            this.offerRepository = offerRepository;
        }

        #endregion

        #region Methods

        public async Task<IEnumerable<Offer>> GetOffersAsync()
        {
            return await this.offerRepository.GetAllOffersAsync();
        }


        public async Task CreateOfferAsync(Offer offer)
        {
            await this.offerRepository.InsertOfferAsync(offer);
        }
        /// <inheritdoc />
        #endregion
    }
}
