using System;
using System.Collections.Generic;
using Fundzo.Core.Models;

namespace Fundzo.Core.Repositories
{
    public interface IDonationRepository : IRepository<Donation>
    {
        Task<List<Donation>> GetByFundraiser(int fundraiserId);
        Task<List<Donation>> GetByUser(Guid userId);
        Task<List<Donation>> GetByUserAndFundraiser(Guid userId, int fundraiserId);
        Task<List<Donation>> GetAllAsync();
    }
}
