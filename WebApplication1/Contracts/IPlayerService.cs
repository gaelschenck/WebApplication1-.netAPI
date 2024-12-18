using WebApplication1.Model;

namespace WebApplication1.Services
{
    public interface IPlayerService
    {
        void AddPlayer(Player player);
        void DeletePlayer(int id);
        Player GetPlayer(int id);
        IEnumerable<Player> GetPlayers();
        void UpdatePlayer(Player player);
    }
}