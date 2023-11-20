using Tregnago_Hugo_Tp2.Enums;
using Tregnago_Hugo_Tp2.Models;
using Tregnago_Hugo_Tp2.Weapons;

namespace Tregnago_Hugo_Tp2.Spaceships
{
    public class Dart : Spaceship
    {
        private const string DART_NAME = "Dart";
        private const double DART_STRUCTURE = 10.0;
        private const double DART_SHIELD = 3.0;

        public Dart() : base(DART_NAME, DART_STRUCTURE, DART_SHIELD, false)
        {
            AddWeapon(Const_Weapons.Laser);
        }
        public override void ReloadWeapons()
        {
            foreach (var weapon in Weapons)
            {
                if (weapon.Type == EWeaponType.Direct)
                    weapon.ReloadWeapon();
                else
                    weapon.DecreaseReloadTime();
            }
        }
    }
}
