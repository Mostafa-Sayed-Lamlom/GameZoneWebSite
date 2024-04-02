namespace GameZone.Controllers
{
	public class GamesController : Controller
	{
		#region Fields
		private readonly ICategoryService _categoryService;
		private readonly IDeviceService _deviceService;
		private readonly IGameService _gameService;
		#endregion
		#region Constructors
		public GamesController(ICategoryService categoryService,
							   IDeviceService deviceService,
							   IGameService gameService)
		{
			_categoryService = categoryService;
			_deviceService = deviceService;
			_gameService = gameService;

		}
		#endregion
		#region Handel Functions
		public IActionResult Index()
		{
			var games = _gameService.GetGames();
			return View(games);
		}
		public IActionResult Details(int id)
		{
			var game = _gameService.GetById(id);
			if (game is null) return NotFound();
			return View(game);
		}

		[HttpGet]
		public IActionResult Create()
		{
			CreateGameFromViewModel createGameFromViewModel = new()
			{
				Categories = _categoryService.GetCategoreis(),
				Devices = _deviceService.GetDevices()
			};
			return View(createGameFromViewModel);
		}
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Create(CreateGameFromViewModel model)
		{
			if (!ModelState.IsValid)
			{
				model.Categories = _categoryService.GetCategoreis();
				model.Devices = _deviceService.GetDevices();
				return View(model);
			}
			await _gameService.Create(model);
			return RedirectToAction(nameof(Index));
		}

		[HttpGet]
		public IActionResult Edit(int id)
		{
			var game = _gameService.GetById(id);

			if (game is null)
				return NotFound();

			EditGameFromViewModel viewModel = new()
			{
				Id = id,
				Name = game.Name,
				Description = game.Description,
				CategoryId = game.CategoryId,
				SelectedDevices = game.Devices.Select(d => d.DeviceId).ToList(),
				Categories = _categoryService.GetCategoreis(),
				Devices = _deviceService.GetDevices(),
				CurrentCover = game.Cover
			};

			return View(viewModel);
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Edit(EditGameFromViewModel model)
		{
			if (!ModelState.IsValid)
			{
				model.Categories = _categoryService.GetCategoreis();
				model.Devices = _deviceService.GetDevices();
				return View(model);
			}

			var game = await _gameService.Update(model);

			if (game is null)
				return BadRequest();

			return RedirectToAction(nameof(Index));
		}

		[HttpDelete]
		public IActionResult Delete(int id)
		{
			var isDeleted = _gameService.Delete(id);

			return isDeleted ? Ok() : BadRequest();
		}
		#endregion

	}
}
