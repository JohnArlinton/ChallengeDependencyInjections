// <copyright company="ROSEN Swiss AG">
//  Copyright (c) ROSEN Swiss AG
//  This computer program includes confidential, proprietary
//  information and is a trade secret of ROSEN. All use,
//  disclosure, or reproduction is prohibited unless authorized in
//  writing by an officer of ROSEN. All Rights Reserved.
// </copyright>

namespace Marketplace.Api.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Marketplace.Api.Requests;
    using Marketplace.Core.Bl;
    using Marketplace.Core.Model;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Logging;

    /// <summary>
    /// Services for Users
    /// </summary>
    /// <seealso cref="Microsoft.AspNetCore.Mvc.ControllerBase" />
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        #region Fields

        private readonly ILogger<UserController> logger;

        private readonly IUserBl userBl;

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="UserController"/> class.
        /// </summary>
        /// <param name="logger">The logger.</param>
        /// <param name="userBl">The user business logic.</param>
        public UserController(ILogger<UserController> logger, IUserBl userBl)
        {
            this.logger = logger;
            this.userBl = userBl;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Gets the list of users.
        /// </summary>
        /// <returns>List of users</returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetUsers()
        {
            IEnumerable<User> result;

            try
            {
                result = await this.userBl.GetUsersAsync();
            }
            catch (Exception ex)
            {
                this.logger?.LogError(ex, ex.Message);
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Server Error.");
            }

            return this.Ok(result);
        }

        [HttpGet("{name}")]
        public async Task<ActionResult<User>> GetUser(string name)
        {
            User result;

            try
            {
                result = await this.userBl.GetUserAsync(name);
            }
            catch (Exception ex)
            {
                this.logger?.LogError(ex, ex.Message);
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Server Error.");
            }

            return this.Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<User>> PostUser(CreateUserRequest request)
        {

            if (ModelState.IsValid)
            {
                try
                {
                    var user = new User();
                    user.Username = request.Username;
                    await this.userBl.CreateUserAsync(user);
                    return this.Ok(user);
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