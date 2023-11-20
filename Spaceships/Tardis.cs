using Tregnago_Hugo_Tp2.Interfaces;
using Tregnago_Hugo_Tp2.Models;

namespace Tregnago_Hugo_Tp2.Spaceships
{
    public class Tardis : Spaceship, IAbility
    {
        private const string TARDIS_NAME = "Tardis";
        private const double TARDIS_STRUCTURE = 1.0;
        private const double TARDIS_SHIELD = 0.0;

        public Tardis() : base(TARDIS_NAME, TARDIS_STRUCTURE, TARDIS_SHIELD, false)
        {
        }

        public void UseAbility(List<Spaceship> spaceships)
        {
            if (spaceships.Count < 2)
            {
                Console.WriteLine("There is not enough spaceships on the field to swap.");
                return;
            }

            Random random = new Random();
            int index1 = random.Next(0, spaceships.Count);
            int index2 = random.Next(0, spaceships.Count);

            while (index2 == index1)
            {
                index2 = random.Next(0, spaceships.Count);
            }

            Spaceship temp = spaceships[index1];
            spaceships[index1] = spaceships[index2];
            spaceships[index2] = temp;

            Console.WriteLine($"Spaceship {spaceships[index1].Name} swapped with {spaceships[index2].Name}.");
        }
    }
}
