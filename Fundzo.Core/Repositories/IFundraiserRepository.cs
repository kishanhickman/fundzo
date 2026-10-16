using System;
using System.Collections.Generic;
using Fundzo.Core.Models;

namespace Fundzo.Core.Repositories
{
    public interface IFundraiserRepository : IRepository<Fundraiser>
    {
        IQueryable<Fundraiser> GetAll();
        Task<List<Fundraiser>> GetAllFundraisers();
        Task<List<Fundraiser>> FindByName(string name);
        Task<List<Fundraiser>> FindByOwner(Guid userId);
        Task<bool> Exists(string name);
        Task UpdateDateLastModified(int id);
    }
}
