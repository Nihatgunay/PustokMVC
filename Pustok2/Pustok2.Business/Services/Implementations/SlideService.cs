using Microsoft.EntityFrameworkCore;
using Pustok2.Business.Services.Interfaces;
using Pustok2.Business.Utilities.Extensions;
using Pustok2.Business.ViewModels;
using Pustok2.Core.Models;
using Pustok2.Core.Repositories;

namespace Pustok2.Business.Services.Implementations
{
	public class SlideService : ISlideService
	{
		private readonly ISlideRepository _repository;

		public SlideService(ISlideRepository repository)
		{
			_repository = repository;
		}
		public async Task CreateAsync(CreateSlideVM slideVM, string imageUrl)
		{
			Slide slide = new Slide
			{
				Title = slideVM.Title,
				Subtitle = slideVM.Subtitle,
				ImageUrl = imageUrl, 
				Createdtime = DateTime.Now,
				Updatedtime = DateTime.Now,
				IsDeleted = false
			};

			await _repository.CreateAsync(slide);
			await _repository.CommitAsync();
		}

		public async Task DeleteAsync(int id)
		{
			var entity = await _repository.GetByIdAsync(id);
			if (entity == null)
			{
				throw new NullReferenceException();
			}
			_repository.Delete(entity);
			await _repository.CommitAsync();
		}

		public async Task<ICollection<Slide>> GetAllAsync()
		{
			return await _repository.GetAll(null).ToListAsync();
		}

		public async Task<Slide> GetByIdAsync(int id)
		{
			var entity = await _repository.GetByIdAsync(id);
			if (entity == null)
			{
				throw new NullReferenceException();
			}

			return entity;
		}

		public async Task UpdateAsync(int id, UpdateSlideVM updateVM, string? imageUrl)
		{
			var entity = await _repository.GetByIdAsync(id);
			if (entity == null)
			{
				throw new NullReferenceException();
			}

			entity.Title = updateVM.Title;
			entity.Subtitle = updateVM.Subtitle;

			if (!string.IsNullOrEmpty(imageUrl))
			{
				entity.ImageUrl = imageUrl;
			}

			entity.Updatedtime = DateTime.Now;

			await _repository.CommitAsync();
		}

	}
}
