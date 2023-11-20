using Tregnago_Hugo_Tp2.Interfaces;
using Tregnago_Hugo_Tp2.Models;

namespace Tregnago_Hugo_Tp2.Spaceships
{
    public class F_18 : Spaceship, IAbility
    {
        private const string F_18_NAME = "F-18";
        private const double F_18_STRUCTURE = 15.0;
        private const double F_18_SHIELD = 0.0;

        public F_18() : base(F_18_NAME, F_18_STRUCTURE, F_18_SHIELD, false)
        {
        }

        public void UseAbility(List<Spaceship> spaceships)
        {
            int f_18Index = spaceships.FindIndex(ship => ship == this);

            int adjacentViper = AdjacentViper(spaceships, f_18Index);

            if (adjacentViper != -1)
            {
                spaceships[adjacentViper].TakeDamages(10);
                spaceships[f_18Index].TakeDamages(F_18_STRUCTURE + F_18_SHIELD);
                Console.WriteLine("F-18 exploded and caused 10 damages to the player's ship!");
            }
        }

        private int AdjacentViper(List<Spaceship> spaceships, int f18Index)
        {
            if (f18Index > 0)
            {
                Spaceship previousShip = spaceships[f18Index - 1];
                if (previousShip.BelongsPlayer)
                {
                    return f18Index - 1;
                }
            }

            if (f18Index < spaceships.Count - 1)
            {
                Spaceship nextShip = spaceships[f18Index + 1];
                if (nextShip.BelongsPlayer)
                {
                    return f18Index + 1;
                }
            }

            return -1;
        }

    }
}
