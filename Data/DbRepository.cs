using AutoMapper;
using Data.Interfaces;
using Domains;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Data
{
    public class DbRepository : IDbRepository // struct, class
    {
        private readonly ApplicationDbContext Db;
        private readonly IMapper mapper;

        public DbRepository(ApplicationDbContext Db, IMapper mapper)
        {
            this.Db = Db;
            this.mapper = mapper;
        }

        public IQueryable<T> ListNoTrack<T>(Expression<Func<T>> expression) where T : BaseDb 
        {
            return Db.Set<T>()
                .AsQueryable()
                .AsNoTracking();
        }
        public IQueryable<T> List<T>(Expression<Func<T>> expression) where T : BaseDb
        {
            return Db.Set<T>()
                .AsQueryable();
        }

        public T GetNoTrack<T>(Expression<Func<T, bool>> expression) where T : BaseDb
        {
            return Db.Set<T>()
                .AsNoTracking()
                .FirstOrDefault(expression);
        }
        public T Get<T>(Expression<Func<T, bool>> expression) where T : BaseDb
        {
            return Db.Set<T>()
                .AsNoTracking()
                .FirstOrDefault(expression);
        }
        public T TryGet<T>(Expression<Func<T, bool>> expression) where T : BaseDb
        {
            var p = Get(expression);
            if (p is null)
            {
                throw new NullReferenceException(nameof(p));
            }
            return p;
        }

        public T Add<T>(T newEntity) where T : BaseDb
        {
            var persisted = Db.Set<T>().Add(newEntity);
            Db.SaveChanges();
            return TryGet<T>(x => x.Id == newEntity.Id);
        }

        public bool Delete<T>(Expression<Func<T, bool>> expression) where T : BaseDb
        {
            var entity = TryGet(expression);
            Db.Remove(entity);
            Db.SaveChanges();
            return true;
        }

        public T Update<T>(T entity) where T : BaseDb
        {
            var entityToUpdate = TryGet<T>(x => x.Id == entity.Id);

            entityToUpdate = mapper.Map<T>(entity);
            
            Db.Update(entityToUpdate);
            Db.SaveChanges();
            
            return entityToUpdate;
        }

        #region Delegate
        //public int C()
        //{
        //    // delegate : (a) => a * 2 ; predicate : a
        //    return A((x) => x + 2);
        //}
        //public int B()
        //{
        //    // delegate : (a) => a * 2 ; predicate : a
        //    return A((a) => a * 2);
        //}
        //public int A(Func<int, int> a)
        //{
        //    //...
        //    var result = a(1);
        //    // ...
        //    return result;
        //}
        #endregion
    }
}
