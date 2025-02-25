using Refuge.Application.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Refuge.Application.Abstractions.Repositories
{
    public interface ICatRepository
    {
        List<Cat> FindWhere(Expression<Func<Cat, bool>> predicate);
        Cat? FindOne(params object[] ids);
        Cat Add(Cat cat);
        Cat Update(Cat cat);
        Cat Remove(Cat cat);
    }
}
