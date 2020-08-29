using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Reservatio.Models;
using Reservatio.Models.Exceptions;

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
                throw new ArgumentNullException("A entidade informada não deve ser nula");

            await Ctx.Set<TEntity>().AddAsync(entity);
            await Ctx.SaveChangesAsync();
            Ctx.Entry(entity).State = EntityState.Detached;

            return entity.Id;
        }

        public async Task<IEnumerable<long>> CreateMany(IList<TEntity> entities)
        {
            if (entities.Any(e => e == null))
                throw new ArgumentNullException("As entidades informadas não devem ser nulas");

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
                throw new ArgumentNullException("É necessário informar um filtro de busca não nulo");

            return await Ctx.Set<TEntity>()
                .AsNoTracking()
                .Where(filter)
                .FirstOrDefaultAsync();
        }

        public async Task<TEntity> Update(TEntity entity)
        {
            if (entity == null)
                throw new ArgumentNullException("A entidade informada não deve ser nula");

            if (entity.Id <= 0)
                throw new ArgumentException("É necessário informar um identificador não nulo positivo");

            if (!await Exist(e => e.Id == entity.Id))
                throw new EntityNotFoundException("Não foi encontrado nenhum registro com o identificador informado");

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
                throw new ArgumentException("É necessário informar um identificador não nulo positivo");
            if (entities.Any(e => e == null))
                throw new ArgumentNullException("As entidades informadas não devem ser nulas");

            if (!entities.Any(e => Exist(ee => ee.Id == e.Id).Result))
                throw new EntityNotFoundException("Não foi encontrado nenhum registro com o identificador informado");

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
                throw new ArgumentException("É necessário informar um identificador não nulo positivo");

            var entity = await Find(e => e.Id == id);

            if (entity != null)
                await Remove(entity);
            else
                throw new EntityNotFoundException("Não foi encontrado nenhum registro com o identificador informado");
        }

        public virtual async Task Remove(TEntity entity)
        {
            if (entity == null)
                throw new ArgumentNullException("As entidades informadas não devem ser nulas");

            if (entity.Id <= 0)
                throw new ArgumentException("É necessário informar um identificador não nulo positivo");

            Ctx.Set<TEntity>().Remove(entity);
            await Ctx.SaveChangesAsync();
        }

        public virtual async Task RemoveMany(IList<TEntity> entities)
        {
            if (entities.Any(e => e.Id <= 0))
                throw new ArgumentException("É necessário informar um identificador não nulo positivo");
            if (entities.Any(e => e == null))
                throw new ArgumentNullException("As entidades informadas não devem ser nulas");
            if (!entities.Any(e => Exist(ee => ee.Id == e.Id).Result))
                throw new EntityNotFoundException("Não foi encontrado nenhum registro com o identificador informado");

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
