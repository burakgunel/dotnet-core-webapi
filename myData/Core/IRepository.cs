using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace myData.Core
{
    public interface IRepository<TEntity> where TEntity : Entity
    {
        TEntity Create(TEntity item);
        IList<TEntity> Get();

        IList<TEntity> GetPagedList(int pageNumber, int pageLimit, Expression<Func<TEntity, object>> orderBy);
    }




}
