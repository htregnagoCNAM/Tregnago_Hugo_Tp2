using Tregnago_Hugo_Tp2.Enums;
using Tregnago_Hugo_Tp2.Models;
using Tregnago_Hugo_Tp2.Weapons;

namespace Tregnago_Hugo_Tp2.Spaceships
{
    public class B_Wings : Spaceship
    {
        private const string B_WINGS_NAME = "B-Wings";
        private const double B_WINGS_STRUCTURE = 30.0;
        private const double B_WINGS_SHIELD = 0.0;

        public B_Wings() : base(B_WINGS_NAME, B_WINGS_STRUCTURE, B_WINGS_SHIELD, false)
        {
            AddWeapon(Const_Weapons.Hammer);
        }

        public override void ReloadWeapons()
        {
            foreach (var weapon in Weapons)
            {
                if (weapon.Type == EWeaponType.Explosive)
                {
                    weapon.ReloadWeapon();
                }
                else
                {
                    weapon.DecreaseReloadTime();
                }
            }
        }
    }
}
