using Be.Khunly.EFRepository;
using Refuge.Application.Abstractions.Repositories;
using Refuge.Application.Entities;
namespace Refuge.DAL.Repositories
{
    public class CatRepository(RefugeContext ctx)
        : RepositoryBase<Cat>(ctx), ICatRepository
    {
    }
}
