using Microsoft.EntityFrameworkCore;
using Pustok2.Business.Services.Interfaces;
using Pustok2.Business.ViewModels;
using Pustok2.Core.Models;
using Pustok2.Core.Repositories;

namespace Pustok2.Business.Services.Implementations
{
    public class GenreService : IGenreService
    {
        private readonly IGenreRepository _repository;

        public GenreService(IGenreRepository repository)
        {
            _repository = repository;
        }
        public async Task CreateAsync(CreateGenreVM genreVM)
        {
            var entity = new Genre()
            {
                Name = genreVM.Name,
                Createdtime = DateTime.Now,
                Updatedtime = DateTime.Now,
            };
            await _repository.CreateAsync(entity);
            await _repository.CommitAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await _repository.GetByIdAsync(id);
            if(entity == null)
            {
                throw new NullReferenceException();
            }
            _repository.Delete(entity);
            await _repository.CommitAsync();
        }

        public async Task<ICollection<Genre>> GetAllAsync()
        {
            return await _repository.GetAll(null).ToListAsync();
        }

        public async Task<Genre> GetByIdAsync(int id)
        {
            var entity = await _repository.GetByIdAsync(id);
            if (entity == null)
            {
                throw new NullReferenceException();
            }

            return entity;
        }

        public async Task UpdateAsync(int id, UpdateGenreVM genreVM)
        {
            var entity = await _repository.GetByIdAsync(id);
            if (entity == null)
            {
                throw new NullReferenceException();
            }
            entity.Name = genreVM.Name;
            entity.Updatedtime = DateTime.Now;

            await _repository.CommitAsync();
        }
    }
}
