﻿using Application.Interfaces;
using Domain.Repositories.Base;

namespace Application.Services
{
    public class BaseService<T> : IBaseService<T> where T : class
    {
        private readonly IRepository<T> iRepository;

        public BaseService(IRepository<T> pRepository)
        {
            iRepository = pRepository;
        }

        public async Task<T> AddAsync(T pInput)
        {
            return await iRepository.AddAsync(pInput);
        }

        public async Task DeleteAsync(int pId)
        {
            T? mEntity = await iRepository.GetByIdAsync(pId);

            if (mEntity != null)
            {
                await iRepository.DeleteAsync(mEntity);
            }
        }

        public IQueryable<T> GetAllAsync()
        {
            return iRepository.AsQueryable();
        }

        public async Task<T?> GetByIdAsync(int pId)
        {
            return await iRepository.GetByIdAsync(pId);
        }

        public async Task<T> UpdateAsync(T pInput)
        {
            return await iRepository.UpdateAsync(pInput);
        }
    }
}