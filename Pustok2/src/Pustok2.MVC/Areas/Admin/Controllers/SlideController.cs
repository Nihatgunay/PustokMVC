using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Pustok2.Business.Services.Interfaces;
using Pustok2.Business.ViewModels;
using Pustok2.Core.Models;

namespace Pustok2.MVC.Areas.Admin.Controllers
{
	[Area("Admin")]
	public class SlideController : Controller
	{
		private readonly ISlideService _service;
		private readonly IWebHostEnvironment _webHostEnvironment;

		public SlideController(ISlideService slideService, IWebHostEnvironment webHostEnvironment)
		{
			_service = slideService;
			_webHostEnvironment = webHostEnvironment;
		}

		public async Task<IActionResult> Index()
		{
			return View(await _service.GetAllAsync());
		}

		public IActionResult Create()
		{
			return View();
		}

		
	}
}
