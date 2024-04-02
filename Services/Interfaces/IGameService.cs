using GameZone.Models;

namespace GameZone.Services.Interfaces
{
	public interface IGameService
	{
		Task Create(CreateGameFromViewModel model);
		IEnumerable<Game> GetGames();
		Game? GetById(int id);
		Task<Game?> Update(EditGameFromViewModel model);
		bool Delete(int id);
	}
}
