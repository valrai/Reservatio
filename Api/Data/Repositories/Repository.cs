using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Reservatio.Models;
using Reservatio.Models.Exceptions;
using Reservatio.Resources;

namespace Reservatio.Data.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : Entity
    {
        protected readonly AppDbContext Ctx;

        public Repository(AppDbContext ctx)
        {
            Ctx = ctx;
        }

        public async Task<long> Create(TEntity entity)
        {
            if (entity == null)
                throw new ArgumentNullException(ExceptionMessagesResource.Informed_entities_must_not_be_null_);

            await Ctx.Set<TEntity>().AddAsync(entity);
            await Ctx.SaveChangesAsync();
            Ctx.Entry(entity).State = EntityState.Detached;

            return entity.Id;
        }

        public async Task<IEnumerable<long>> CreateMany(IList<TEntity> entities)
        {
            if (entities.Any(e => e == null))
                throw new ArgumentNullException(ExceptionMessagesResource.Informed_entities_must_not_be_null_);

            await Ctx.AddRangeAsync(entities);
            await Ctx.SaveChangesAsync();
            foreach (var entity in entities)
                Ctx.Entry(entity).State = EntityState.Detached;

            return entities.Select(t => t.Id);
        }

        public virtual async Task<IEnumerable<TEntity>> FindAll(Expression<Func<TEntity, bool>> filter = null)
        {
            if (filter != null)
            {
                return await Ctx.Set<TEntity>()
                    .AsNoTracking()
                    .Where(filter)
                    .ToListAsync();
            }

            return await Ctx.Set<TEntity>()
                .AsNoTracking()
                .ToListAsync();
        }

        public virtual async Task<TEntity> Find(Expression<Func<TEntity, bool>> filter = null)
        {
            if (filter == null)
                throw new ArgumentNullException(ExceptionMessagesResource.You_must_enter_a_non_null_search_filter_);

            return await Ctx.Set<TEntity>()
                .AsNoTracking()
                .Where(filter)
                .FirstOrDefaultAsync();
        }

        public async Task<TEntity> Update(TEntity entity)
        {
            if (entity == null)
                throw new ArgumentNullException(ExceptionMessagesResource.Informed_entities_must_not_be_null_);

            if (entity.Id <= 0)
                throw new ArgumentException(ExceptionMessagesResource.You_must_enter_a_positive_non_null_identifier_);

            if (!await Exist(e => e.Id == entity.Id))
                throw new EntityNotFoundException(ExceptionMessagesResource.No_record_was_found_with_the_given_identifier_);

            Ctx.Set<TEntity>()
                .Update(entity);
            await Ctx
                .SaveChangesAsync();
            Ctx.Entry(entity).State = EntityState.Detached;

            return entity;
        }

        public async Task<IEnumerable<TEntity>> UpdateMany(IList<TEntity> entities)
        {
            if (entities.Any(e => e.Id <= 0))
                throw new ArgumentException(ExceptionMessagesResource.You_must_enter_a_positive_non_null_identifier_);
            if (entities.Any(e => e == null))
                throw new ArgumentNullException(ExceptionMessagesResource.The_informed_entity_must_not_be_null_);

            if (!entities.Any(e => Exist(ee => ee.Id == e.Id).Result))
                throw new EntityNotFoundException(ExceptionMessagesResource.No_record_was_found_with_the_given_identifier_);

            Ctx.Set<TEntity>()
                .UpdateRange(entities);
            await Ctx
                .SaveChangesAsync();
            foreach (var entity in entities)
                Ctx.Entry(entity).State = EntityState.Detached;

            return entities;
        }

        public virtual async Task Remove(long id)
        {
            if (id <= 0)
                throw new ArgumentException(ExceptionMessagesResource.You_must_enter_a_positive_non_null_identifier_);

            var entity = await Find(e => e.Id == id);

            if (entity != null)
                await Remove(entity);
            else
                throw new EntityNotFoundException(ExceptionMessagesResource.No_record_was_found_with_the_given_identifier_);
        }

        public virtual async Task Remove(TEntity entity)
        {
            if (entity == null)
                throw new ArgumentNullException(ExceptionMessagesResource.Informed_entities_must_not_be_null_);

            if (entity.Id <= 0)
                throw new ArgumentException(ExceptionMessagesResource.No_record_was_found_with_the_given_identifier_);

            Ctx.Set<TEntity>().Remove(entity);
            await Ctx.SaveChangesAsync();
        }

        public virtual async Task RemoveMany(IList<TEntity> entities)
        {
            if (entities.Any(e => e.Id <= 0))
                throw new ArgumentException(ExceptionMessagesResource.You_must_enter_a_positive_non_null_identifier_);
            if (entities.Any(e => e == null))
                throw new ArgumentNullException(ExceptionMessagesResource.Informed_entities_must_not_be_null_);
            if (!entities.Any(e => Exist(ee => ee.Id == e.Id).Result))
                throw new EntityNotFoundException(ExceptionMessagesResource.No_record_was_found_with_the_given_identifier_);

            Ctx.Set<TEntity>().RemoveRange(entities);
            await Ctx.SaveChangesAsync();
        }

        public async Task<bool> Exist(Expression<Func<TEntity, bool>> filter = null)
        {
            if (filter != null)
                return await Ctx.Set<TEntity>().AnyAsync(filter);

            return await Ctx.Set<TEntity>().AnyAsync();
        }
    }
}
