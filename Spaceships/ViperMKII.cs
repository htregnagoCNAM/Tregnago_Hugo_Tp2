using Tregnago_Hugo_Tp2.Models;
using Tregnago_Hugo_Tp2.Weapons;

namespace Tregnago_Hugo_Tp2.Spaceships
{
    public class ViperMKII : Spaceship
    {
        private const string VIPERMKII_NAME = "ViperMKII";
        private const double VIPERMKII_STRUCTURE = 10.0;
        private const double VIPERMKII_SHIELD = 15.0;

        public ViperMKII() : base(VIPERMKII_NAME, VIPERMKII_STRUCTURE, VIPERMKII_SHIELD, true)
        {
            AddWeapon(Const_Weapons.Mitrailleuse);
            AddWeapon(Const_Weapons.EMG);
            AddWeapon(Const_Weapons.Missile);
        }

        public override void ShootTarget(Spaceship target)
        {
            Console.WriteLine(Environment.NewLine + $"{Name} is attacking {target.Name}");
            Console.WriteLine($"Before : Structure {target.CurrentStructure} Shield {target.CurrentShield}");
            Weapon? weapon = GetRandomAvailableWeaponToUse();
            if (weapon != null)
            {
                target.TakeDamages(weapon.Shoot());
            }
            else
            {
                Console.WriteLine("No weapon is available!");
            }
            Console.WriteLine($"After : Structure {target.CurrentStructure} Shield {target.CurrentShield}" + Environment.NewLine);
        }

        private Weapon? GetRandomAvailableWeaponToUse()
        {
            List<Weapon> reloadedWeapons = GetAllReloadedWeapons();
            if (reloadedWeapons.Count > 0)
            {
                Random random = new Random();
                int randomIndex = random.Next(0, reloadedWeapons.Count);
                return reloadedWeapons[randomIndex];
            }
            return null;
        }
        private List<Weapon> GetAllReloadedWeapons()
        {
            var reloadedWeapons = new List<Weapon>();
            foreach (Weapon weapon in Weapons)
                if(weapon.IsReload)
                    reloadedWeapons.Add(weapon);
            return reloadedWeapons;
        }
    }
}
