using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using Fundzo.Core.Repositories;



namespace Fundzo.Data.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        public FundzoContext FundzoContext { get; }
        public DbSet<TEntity> Entities { get; }

        public Repository(FundzoContext context)
        {
            FundzoContext = context;
            Entities = FundzoContext.Set<TEntity>();
        }

        /// <summary>
        /// Retrieve List of Entities.
        /// </summary>
        public virtual IQueryable<TEntity> GetAll()
        {
            try
            {
                return FundzoContext.Set<TEntity>();
            }
            catch (Exception ex)
            {
                throw new Exception($"Couldn't retrieve entities: {ex.Message}");
            }
        }
        /// <summary>
        /// Retrieve List of Entities with Linq Expression, order and property search.
        /// </summary>
        public virtual IEnumerable<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, string includeProperties = "")
        {
            IQueryable<TEntity> query = Entities;

            try
            {
                if (filter != null)
                {
                    query = query.Where(filter);
                }

                foreach (var includeProperty in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeProperty);
                }

                if (orderBy != null)
                {
                    return orderBy(query).ToList();
                }
                else
                {
                    return query.ToList();
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Couldn't retrieve entities: {ex.Message}");
            }
        }
        public virtual async Task<TEntity> FindById(int id)
        {
            if (id == null)
            {
                throw new ArgumentNullException($"{nameof(TEntity)} id must not be null");
            }

            try
            {
                return await Entities.FindAsync(id);
            }
            catch (Exception ex)
            {
                throw new Exception($"Couldn't retrieve entities with id {id}: {ex.Message}");
            }
        }
        /// <summary>
        /// Insert Entity into DB.
        /// </summary>
        public virtual async Task<TEntity> CreateAsync(TEntity entity, bool saveChanges = true)
        {
            if (entity == null)
            {
                throw new ArgumentNullException($"{nameof(TEntity)} entity must not be null");
            }

            try
            {
                await Entities.AddAsync(entity);

                if (saveChanges) 
                    await Save();

                return entity;
            }
            catch (Exception ex)
            {
                throw new Exception($"{nameof(entity)} could not be inserted: {ex.Message}");
            }
        }
        /// <summary>
        /// Update Entity in DB.
        /// </summary>
        public virtual async Task<TEntity> UpdateAsync(TEntity entity, bool saveChanges = true)
        {
            if (entity == null)
            {
                throw new ArgumentNullException($"{nameof(UpdateAsync)} entity must not be null");
            }

            try
            {
                Entities.Update(entity);

                if (saveChanges)
                    await Save();

                return entity;
            }
            catch (Exception ex)
            {
                throw new Exception($"{nameof(entity)} could not be updated: {ex.Message}");
            }
        }
        /// <summary>
        /// Save changes to context.
        /// </summary>
        public virtual async Task Save()
        {
            await FundzoContext.SaveChangesAsync();
        }
        /// <summary>
        /// Delete by Id.
        /// </summary>
        public virtual async Task<TEntity> DeleteAsync(int id, bool saveChanges = true)
        {
            if (id == null)
            {
                throw new ArgumentNullException($"{nameof(TEntity)} id must not be null");
            }

            try
            {
                TEntity entity = FundzoContext.Set<TEntity>().Find(id);
                Entities.Remove(entity);

                if (saveChanges)
                    await Save();

                return entity;
            }
            catch (Exception ex)
            {
                throw new Exception($"{nameof(TEntity)} id({id}), could not be deleted: {ex.Message}");
            }
        }

        /// <summary>
        /// Delete by Entity.
        /// </summary>
        public virtual async Task<TEntity> DeleteAsync(TEntity entity, bool saveChanges = true)
        {
            if (entity == null)
            {
                throw new ArgumentNullException($"{nameof(TEntity)} entity must not be null");
            }

            try
            {
                if (FundzoContext.Entry(entity).State == EntityState.Detached)
                {
                    Entities.Attach(entity);
                }
                Entities.Remove(entity);

                if (saveChanges)
                    await Save();

                return entity;
            }
            catch (Exception ex)
            {
                throw new Exception($"{nameof(TEntity)} could not be deleted: {ex.Message}");
            } 
        }

    }

}