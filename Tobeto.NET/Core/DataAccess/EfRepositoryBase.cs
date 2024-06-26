﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.DataAccess
{

    // Constraints = Kısıt
    // public class EfRepositoryBase<TEntity, TContext> : IRepository<TEntity>

    public class EfRepositoryBase<TEntity, TContext> : IRepository<TEntity>, IAsyncRepository<TEntity>

    where TContext : DbContext
        where TEntity : Entity
    {
        private readonly TContext Context;  //DI ları redonly yapıyoruz set edilsin istemiyoruz.

        public EfRepositoryBase(TContext context)
        {
            Context = context;
        }


        public void Add(TEntity entity)
        {
            Context.Add(entity);
            Context.SaveChanges();
        }

        public void Delete(TEntity entity)
        {
            Context.Remove(entity);
            Context.SaveChanges();
        }
        public void Update(TEntity entity)
        {
            Context.Update(entity);
            Context.SaveChanges();

        }

        // Filter ✅
        // OrderBy ?
        //public List<TEntity> GetList(Expression<Func<TEntity, bool>>? predicate)
        public List<TEntity> GetList(Expression<Func<TEntity, bool>>? predicate = null)


        {
            IQueryable<TEntity> data = Context.Set<TEntity>();

            if (predicate != null)
                data = data.Where(predicate);

            return data.ToList();

        }

        //public TEntity GetById(int id)
        //{
        //    return Context.Set<TEntity>().FirstOrDefault(i => i.Id == id);
        //}

        // Filter ✅
        // OrderBy ?
        public TEntity? Get(Expression<Func<TEntity, bool>> predicate)
        {
            IQueryable<TEntity> data = Context.Set<TEntity>();

            return data.FirstOrDefault(predicate);
        }
        public async Task<TEntity?> GetAsync(Expression<Func<TEntity, bool>> predicate)
        {
            IQueryable<TEntity> data = Context.Set<TEntity>();

            return await data.FirstOrDefaultAsync(predicate);
        }

        public async Task<List<TEntity>> GetListAsync(Expression<Func<TEntity, bool>>? predicate = null)
        {
            IQueryable<TEntity> data = Context.Set<TEntity>();

            if (predicate != null)
                data = data.Where(predicate);

            return await data.ToListAsync();
        }

        public async Task AddAsync(TEntity entity)
        {
            await Context.AddAsync(entity);
            await Context.SaveChangesAsync();
        }

        public async Task UpdateAsync(TEntity entity)
        {
            Context.Update(entity);
            await Context.SaveChangesAsync();
        }

        public async Task DeleteAsync(TEntity entity)
        {
            Context.Remove(entity);
            await Context.SaveChangesAsync();
        }
    }
}
