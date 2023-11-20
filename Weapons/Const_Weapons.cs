using Tregnago_Hugo_Tp2.Enums;
using Tregnago_Hugo_Tp2.Models;

namespace Tregnago_Hugo_Tp2.Weapons
{
    public class Const_Weapons
    {
        public static Weapon Laser = new Weapon("Laser", 2, 3, EWeaponType.Direct, 2);
        public static Weapon Hammer = new Weapon("Hammer", 1, 8, EWeaponType.Explosive, 1.5);
        public static Weapon Torpille = new Weapon("Torpille", 3, 3, EWeaponType.Guided, 2);
        public static Weapon Mitrailleuse = new Weapon("Mitrailleuse", 6, 8, EWeaponType.Direct, 1);
        public static Weapon EMG = new Weapon("EMG", 1, 7, EWeaponType.Explosive, 1.5);
        public static Weapon Missile = new Weapon("Missile", 4, 100, EWeaponType.Guided, 4);
    }
}
