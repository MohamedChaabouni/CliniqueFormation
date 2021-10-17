using Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Data.Interfaces
{
    public interface IDbRepository
    {
        // IQueyable - IEnumerable
        // IQueryable : Query EF (Expression<Func<T>>) : SQL Query [SELECT * FROM Medecin WHERE Id = 1] -- Without result
        // IEnumerable : Execution of IQueryable -- Result
        IQueryable<T> ListNoTrack<T>(Expression<Func<T>> expression = null) where T : BaseDb;
        IQueryable<T> List<T>(Expression<Func<T>> expression = null) where T : BaseDb;
        T Get<T>(Expression<Func<T, bool>> expression = null) where T : BaseDb;
        T GetNoTrack<T>(Expression<Func<T, bool>> expression = null) where T : BaseDb;
        T TryGet<T>(Expression<Func<T, bool>> expression = null) where T : BaseDb;
        T Add<T>(T newEntity) where T : BaseDb;
        bool Delete<T>(Expression<Func<T, bool>> expression = null) where T : BaseDb;
        T Update<T>(T entity) where T : BaseDb;
    }
}
