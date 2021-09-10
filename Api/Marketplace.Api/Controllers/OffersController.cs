using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Marketplace.Api.Requests;
using Marketplace.Core.Bl;
using Marketplace.Core.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Marketplace.Api.Controllers
{
    /// <summary>
    /// Services for Users
    /// </summary>
    /// <seealso cref="Microsoft.AspNetCore.Mvc.ControllerBase" />
    [ApiController]
    [Route("api/[controller]")]
    public class OffersController : ControllerBase
    {

        #region Fields

        private readonly ILogger<OffersController> logger;

        private readonly IOfferBl offerBl;

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="OffersController"/> class.
        /// </summary>
        /// <param name="logger">The logger.</param>
        /// <param name="offerBl">The offer business logic.</param>
        public OffersController(ILogger<OffersController> logger, IOfferBl offerBl)
        {
            this.logger = logger;
            this.offerBl = offerBl;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Gets the list of offers.
        /// </summary>
        /// <returns>List of offers</returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Offer>>> GetOffers()
        {
            IEnumerable<Offer> result;

            try
            {
                result = await this.offerBl.GetOffersAsync();
            }
            catch (Exception ex)
            {
                this.logger?.LogError(ex, ex.Message);
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Server Error.");
            }

            return this.Ok(result);
        }


        [HttpPost]
        public async Task<ActionResult<IEnumerable<Offer>>> PostOffers(CreateOfferRequest request)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var offer = new Offer();
                    offer.CategoryId = request.categoryId;
                    offer.Description = request.description;
                    offer.Location = request.location;
                    offer.PictureUrl = request.pictureUrl;
                    offer.UserId = request.userId;
                    offer.Title = request.title;

                    await this.offerBl.CreateOfferAsync(offer);
                  
                    return this.Ok(offer);
                }
                catch (Exception ex)
                {
                    this.logger?.LogError(ex, ex.Message);
                    return this.StatusCode(StatusCodes.Status500InternalServerError, "Server Error.");
                }
            }
            return this.StatusCode(StatusCodes.Status400BadRequest, "Model is not valid");
        }

        #endregion
    }
}
