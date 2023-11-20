using Tregnago_Hugo_Tp2.Enums;
using Tregnago_Hugo_Tp2.Weapons;

namespace Tregnago_Hugo_Tp2.Models
{
    public class Armory
    {
        public List<Weapon> Weapons { get; private set; }

        public Armory()
        {
            Weapons = new List<Weapon>();
            Init();
        }

        private void Init()
        {
            Weapons.Add(Const_Weapons.Laser);
            Weapons.Add(Const_Weapons.Hammer);
            Weapons.Add(Const_Weapons.Torpille);
            Weapons.Add(Const_Weapons.Mitrailleuse);
            Weapons.Add(Const_Weapons.EMG);
            Weapons.Add(Const_Weapons.Missile);
        }

        public void ViewArmory()
        {
            Console.WriteLine("*-*-*-*-*-*-*-*");
            Console.WriteLine("Detailed list of armory weapons:");
            foreach (var weapon in Weapons)
            {
                ViewDetailedWeapon(weapon);
            }
            Console.WriteLine("*-*-*-*-*-*-*-*" + Environment.NewLine + Environment.NewLine);
        }
        public void ViewDirectWeapons()
        {
            Console.WriteLine("*-*-*-*-*-*-*-*");
            Console.WriteLine("Detailed list of armory direct weapons:");
            foreach (var weapon in Weapons)
            {
                if (weapon.Type == EWeaponType.Direct)
                    ViewDetailedWeapon(weapon);
            }
            Console.WriteLine("*-*-*-*-*-*-*-*");
        }
        public void ViewExplosiveWeapons()
        {
            Console.WriteLine("*-*-*-*-*-*-*-*");
            Console.WriteLine("Detailed list of armory explosive weapons:");
            foreach (var weapon in Weapons)
            {
                if (weapon.Type == EWeaponType.Explosive)
                    ViewDetailedWeapon(weapon);
            }
            Console.WriteLine("*-*-*-*-*-*-*-*");
        }
        public void ViewGuidedWeapons()
        {
            Console.WriteLine("*-*-*-*-*-*-*-*");
            Console.WriteLine("Detailed list of armory guided weapons:");
            foreach (var weapon in Weapons)
            {
                if (weapon.Type == EWeaponType.Guided)
                    ViewDetailedWeapon(weapon);
            }
            Console.WriteLine("*-*-*-*-*-*-*-*");
        }
        private void ViewDetailedWeapon(Weapon weapon)
        {
            Console.WriteLine($"Name: {weapon.Name}, Type: {weapon.Type}, Damage: {weapon.MinDamage}-{weapon.MaxDamage}");
        }
    }
}
