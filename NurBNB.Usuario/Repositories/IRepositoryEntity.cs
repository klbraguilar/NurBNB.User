using Restaurant.SharedKernel.Core;
using System.Threading.Tasks;

namespace NurBNB.Usuario.Domain.Repositories;

public interface IRepositoryEntity<T, in TId> where T : Entity
{
    Task<T?> FindByIdAsync(TId id);

    Task CreateAsync(T obj);

}
