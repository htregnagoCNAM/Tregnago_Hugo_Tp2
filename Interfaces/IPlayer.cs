using Tregnago_Hugo_Tp2.Models;

namespace Tregnago_Hugo_Tp2.Interfaces
{
    public interface IPlayer
    {
        Spaceship BattleShip { get; set; }
        string Name { get; }
        string Alias { get; }
    }
}