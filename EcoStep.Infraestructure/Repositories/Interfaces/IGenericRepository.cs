﻿using EcoStep.Domain.Models;

namespace EcoStep.Infrastructure.Repositories.Interfaces;

public interface IGenericRepository<T> where T : BaseModel
{
    //Task<List<T>> GetAllWithPagination(PaginationDto paginationDto);
    Task<T> GetById(int? id);
    Task<T> Create(T model, CancellationToken cancellationToken);
    Task<T> Update(int id, T model);
    Task<T> SoftDelete(int id);
    Task<List<T>> UpdateList(List<T> models);



}