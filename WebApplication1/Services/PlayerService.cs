using WebApplication1.Model;
using Newtonsoft.Json;

namespace WebApplication1.Services
{
    public class PlayerService
    {
        private const string FilePath = "players.json";
        private List<Player> _players;

        public PlayerService()
        {
            LoadPlayers();
        }

        //va chercher le fichier json et en extrait les données sous forme de string
        private void LoadPlayers()
        {
            if(File.Exists(FilePath))
            {
                var json = File.ReadAllText(FilePath);
                var players = JsonConvert.DeserializeObject<List<Player>>(json);
                _players = players ?? new List<Player>();
            }
            else
            {
                _players = new List<Player>();
            }
        }

        //utilise un string des données et le met en forme au format Json avant d'enregistrer
        private void SavePlayers()
        {
            var json = JsonConvert.SerializeObject( _players, Formatting.Indented);
            File.WriteAllText(FilePath, json);
        }

        // récupère les informations de la classe player
        public IEnumerable<Player> GetPlayers() => _players;

        // mets à jour l'id du joueur
        public Player GetPlayer(int id) =>_players.FirstOrDefault(p => p.Id == id);

        public void AddPlayer(Player player)
        {
            player.Id = _players.Count > 0 ? _players.Max(p => p.Id) + 1 : 1; 
            _players.Add(player);
            SavePlayers();
        }

        public void UpdatePlayer(Player player)
        {
            var index = _players.FindIndex(p => p.Id == player.Id);
            if (index != -1)
            {
                _players[index] = player;
                SavePlayers();
            }
        }

        public void DeletePlayer(int id)
        { 
            var player = GetPlayer(id);
            if (player != null)
            {
                _players.Remove(player);
                SavePlayers();
            }
        }
    }
}
