using EcoStep.Domain.Models;

namespace EcoStep.Infrastructure.Repositories.Interfaces;

public interface IUserRepository : IGenericRepository<User>
{
    Task<User?> getUserByFirebaseId(string firebaseId);
    Task<User> GetByEmail(string email);
    Task<User> GetByFirebaseId(string firebaseId);
}