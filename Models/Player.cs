using Tregnago_Hugo_Tp2.Interfaces;

namespace Tregnago_Hugo_Tp2.Models
{
    public class Player : IPlayer
    {
        private string FirstName { get; }
        private string LastName { get; }
        public string Alias { get; }
        public string Name { get; private set; }
        public Spaceship BattleShip { get; set; }

        public Player(string firstName, string lastName, string alias, Spaceship ship)
        {
            FirstName = FormatName(firstName);
            LastName = FormatName(lastName);
            Alias = alias;
            BattleShip = ship;
            Name = $"{FirstName} {LastName}";
        }

        public static string FormatName(string name)
        {
            if (name.Length == 0)
                return name;
            name = name.ToLower();
            return char.ToUpper(name[0]) + name.Substring(1);
        }

        public override string ToString()
        {
            return $"{Alias} ({Name})";
        }

        public override bool Equals(object? obj)
        {
            if (obj == null || GetType() != obj.GetType())
                return false;

            Player otherPlayer = (Player)obj;
            return Alias == otherPlayer.Alias;
        }

        public override int GetHashCode()
        {
            return Alias.GetHashCode();
        }
    }
}
