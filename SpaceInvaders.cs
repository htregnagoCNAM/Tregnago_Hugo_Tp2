using Tregnago_Hugo_Tp2.Interfaces;
using Tregnago_Hugo_Tp2.Models;
using Tregnago_Hugo_Tp2.Spaceships;

namespace Tregnago_Hugo_Tp2
{
    public class SpaceInvaders
    {
        private List<Player> Players;
        private List<Spaceship> Spaceships;
        private Armory GeneralArmory;
        private const string SpacerDisplay = "!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!\n!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!\n";
        public SpaceInvaders()
        {
            Players = new List<Player>();
            Spaceships = new List<Spaceship>();
            GeneralArmory = new Armory();
            Init();
        }
        public static void Main()
        {
            SpaceInvaders game = new SpaceInvaders();
            game.DisplayAllPlayers();
            game.GeneralArmory.ViewArmory();
            foreach (Player player in game.Players)
                game.DisplayPlayerDetailedInformations(player);
            Console.WriteLine(SpacerDisplay);
            while(game.findPlayerShip() != -1 && game.Spaceships.Count > 1)
            {
                game.DisplayShipOrder();
                game.PlayRound();
            }
            Console.WriteLine(SpacerDisplay);
            Console.WriteLine("End of the war, states of each player");
            foreach (Player player in game.Players)
                game.DisplayPlayerDetailedInformations(player);
        }
        private void Init()
        {
            B_Wings b_Wings = new B_Wings();
            Dart dart = new Dart();
            F_18 f_18 = new F_18();
            Rocinante rocinante = new Rocinante();
            Tardis tardis = new Tardis();
            ViperMKII viper = new ViperMKII();
            List<Player> players = new List<Player>
            {
                new Player("Alice", "Johnson", b_Wings.Name.ToUpper(), b_Wings),
                new Player("Bob", "Smith", dart.Name.ToUpper(), dart),
                new Player("Charlie", "Brown", f_18.Name.ToUpper(), f_18),
                new Player("Daisy", "Thomas", rocinante.Name.ToUpper(), rocinante),
                new Player("Eve", "Williams", tardis.Name.ToUpper(), tardis),
                new Player("Hugo", "Tregnago", viper.Name.ToUpper(), viper)
            };
            Random random = new Random();
            Players = players.OrderBy(p => random.Next()).ToList();
            foreach (Player player in Players)
                Spaceships.Add(player.BattleShip);
        }
        public void PlayRound()
        {
            bool playerHasAttacked = false;
            int indexEnnemyShip = -1;
            UseAbilitiesOnShips();
            int indexPlayerShip = findPlayerShip();
            for (int i = 0; i < Spaceships.Count; i++)
            {
                if (i != indexPlayerShip)
                {
                    ConfrontTwoShips(Spaceships[i], Spaceships[indexPlayerShip]);
                    if (!playerHasAttacked && playerCanAttack(i, Spaceships.Count-1))
                    {
                        ConfrontTwoShips(Spaceships[indexPlayerShip], Spaceships[i]);
                        playerHasAttacked = true;
                        indexEnnemyShip = i;
                    }
                }
            }
            if (!Spaceships[indexEnnemyShip].IsDestroyed)
                Spaceships[indexEnnemyShip].RepairShield();
            if (!Spaceships[indexPlayerShip].IsDestroyed)
                Spaceships[indexPlayerShip].RepairShield();
            DeleteDestroyedShips();
        }
        private bool playerCanAttack(int i, int countEnnemyShips)
        {
            Random random = new Random();
            return (random.Next(0, countEnnemyShips) <= i);
        }
        private void ConfrontTwoShips(Spaceship offensiveShip, Spaceship defensiveShip)
        {
            offensiveShip.ReloadWeapons();
            offensiveShip.ShootTarget(defensiveShip);
        }
        private void UseAbilitiesOnShips()
        {
            var abilitySpaceships = Spaceships.OfType<IAbility>().ToList();
            if (abilitySpaceships.Count != 0)
                foreach (var ship in abilitySpaceships)
                    ship.UseAbility(Spaceships);
        }
        private int findPlayerShip()
        {
            return Spaceships.FindIndex(spaceship => spaceship.BelongsPlayer);
        }
        private void DeleteDestroyedShips()
        {
            Spaceships.RemoveAll(spaceship => spaceship.IsDestroyed);
        }
        public void DisplayAllPlayers()
        {
            Console.WriteLine("*-*-*-*-*-*-*-*");
            Console.WriteLine("List of all current players:");
            foreach (Player player in Players)
                Console.WriteLine(player.ToString());
            Console.WriteLine("*-*-*-*-*-*-*-*" + Environment.NewLine + Environment.NewLine);
        }
        public void DisplayPlayerDetailedInformations(Player player)
        {
            Console.WriteLine("*-*-*-*-*-*-*-*");
            Console.WriteLine($"Player : {player.ToString()}");
            player.BattleShip.ViewShip();
            Console.WriteLine("*-*-*-*-*-*-*-*" + Environment.NewLine + Environment.NewLine);
        }

        private void DisplayShipOrder()
        {
            Console.WriteLine("Ship order this turn :");
            string shipNames = string.Join(", ", Spaceships.Select(ship => ship.Name));
            Console.WriteLine(shipNames);
        }
    }
}
