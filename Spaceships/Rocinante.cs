using Tregnago_Hugo_Tp2.Models;
using Tregnago_Hugo_Tp2.Weapons;

namespace Tregnago_Hugo_Tp2.Spaceships
{
    public class Rocinante : Spaceship
    {
        private const string ROCINANTE_NAME = "Rocinante";
        private const double ROCINANTE_STRUCTURE = 3.0;
        private const double ROCINANTE_SHIELD = 5.0;

        public Rocinante() : base(ROCINANTE_NAME, ROCINANTE_STRUCTURE, ROCINANTE_SHIELD, false)
        {
            AddWeapon(Const_Weapons.Torpille);
        }

        public override void TakeDamages(double damages)
        {
            Random random = new Random();
            if (random.Next(0, 2) == 0)
            {
                Console.WriteLine("The Rocinante dodged the shot!");
            }
            else
            {
                base.TakeDamages(damages);
            }
        }
    }
}
