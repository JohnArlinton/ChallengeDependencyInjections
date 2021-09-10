// <copyright company="ROSEN Swiss AG">
//  Copyright (c) ROSEN Swiss AG
//  This computer program includes confidential, proprietary
//  information and is a trade secret of ROSEN. All use,
//  disclosure, or reproduction is prohibited unless authorized in
//  writing by an officer of ROSEN. All Rights Reserved.
// </copyright>

namespace Marketplace.Dal.Repositories
{
    using System.Threading.Tasks;
    using Marketplace.Core.Dal;
    using Marketplace.Core.Model;
    using Microsoft.EntityFrameworkCore;

    public class UserRepository : IUserRepository
    {
        #region Fields

        private MarketplaceContext context;

        #endregion

        #region Constructors

        public UserRepository()
        {
            this.context = new MarketplaceContext();
        }

        #endregion

        #region Methods

        /// <inheritdoc />
        public async Task<User[]> GetAllUsersAsync()
        {
            var list = await this.context.Users.Include(x => x.Offers).ToArrayAsync();
            foreach(var item in list)
            {
                if(item.Offers != null)
                {
                    foreach(var i in item.Offers)
                    {
                        i.User = null;
                    }
                }
            }
            return list;
        }

        public async Task<User> GetOneUserAsync(string name)
        {
            return await this.context.Users.FirstOrDefaultAsync(x => x.Username == name);
        }

        public async Task InsertUserAsync(User user)
        {
            this.context.Add(user);
            await this.context.SaveChangesAsync();
        }

        #endregion
    }
}