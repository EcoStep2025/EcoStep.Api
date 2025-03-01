using System.Security.Cryptography.X509Certificates;
using EcoStep.Domain.Models;
using EcoStep.Infrastructure.Data;
using EcoStep.Infrastructure.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace EcoStep.Infrastructure.Repositories.Classes;

public  class UserRepository : GenericRepository<User>, IUserRepository
{
    public UserRepository(ApplicationDbContext options) : base(options)
    {
        
    }

    public async Task<User?> getUserByFirebaseId(string firebaseId)
    {
        User? userDb = await _dbSet.Where(x => x.FirebaseId == firebaseId)
            .Include(x => x.Country)
            .Include(x => x.Province)
            .Include(x => x.Gender)
            .FirstOrDefaultAsync();

        return userDb;
    }

    public async Task<User> GetByEmail(string email)
    {
        User? userDataInDb = await _dbSet.FirstOrDefaultAsync(x => x.Email == email);

        return userDataInDb!;
    }

    public async Task<User> GetByFirebaseId(string firebaseId)
    {
        User? userDataInDb = await _dbSet.FirstOrDefaultAsync(x => x.FirebaseId == firebaseId);

        return userDataInDb!;
    }

}