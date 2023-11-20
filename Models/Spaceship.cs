using Tregnago_Hugo_Tp2.Exceptions;
using Tregnago_Hugo_Tp2.Interfaces;

namespace Tregnago_Hugo_Tp2.Models
{
    public abstract class Spaceship : ISpaceship
    {
        private const int MAX_WEAPONS = 3;

        public string Name { get; set; }
        public double Structure { get; set; }
        public double Shield { get; set; }
        public bool IsDestroyed { get { return CurrentStructure <= 0; } }
        public int MaxWeapons { get { return MAX_WEAPONS; } }
        public List<Weapon> Weapons { get; }
        public double AverageDamages
        {
            get
            {
                if (Weapons.Count == 0)
                {
                    return 0.0;
                }

                double totalAverageDamage = Weapons.Sum(weapon => weapon.AverageDamage);
                return totalAverageDamage / Weapons.Count;
            }
        }
        public double CurrentStructure { get; set; }
        public double CurrentShield { get; set; }
        public bool BelongsPlayer { get; }
        public Armory SpaceshipArmory { get; set; }
        public Spaceship(string name, double structure, double shield, bool belongsPlayer)
        {
            Name = name;
            Structure = structure;
            Shield = shield;
            Weapons = new List<Weapon>();
            CurrentStructure = structure;
            CurrentShield = shield;
            BelongsPlayer = belongsPlayer;
            SpaceshipArmory = new Armory();
        }
        public virtual void TakeDamages(double damages)
        {
            if (CurrentShield > 0)
            {
                if (CurrentShield >= damages)
                {
                    CurrentShield -= damages;
                }
                else
                {
                    double remainingDamage = damages - CurrentShield;
                    CurrentShield = 0;
                    CurrentStructure -= remainingDamage;
                }
            }
            else
            {
                CurrentStructure -= damages;
            }
            if (CurrentStructure <= 0)
            {
                CurrentStructure = 0;
            }
        }
        public void RepairShield(double repair = 2.0)
        {
            CurrentShield += repair;
            if (CurrentShield > Shield)
                CurrentShield = Shield;
        }
        public virtual void ShootTarget(Spaceship target)
        {
            Console.WriteLine(Environment.NewLine + $"{Name} is attacking {target.Name}");
            Console.WriteLine($"Before : Structure {target.CurrentStructure} Shield {target.CurrentShield}");
            foreach(Weapon weapon in Weapons)
                if (weapon.IsReload)
                    target.TakeDamages(weapon.Shoot());
            Console.WriteLine($"After : Structure {target.CurrentStructure} Shield {target.CurrentShield}" + Environment.NewLine);
        }
        public virtual void ReloadWeapons()
        {
            foreach (Weapon weapon in Weapons)
                if (!(weapon.IsReload))
                {
                    weapon.DecreaseReloadTime();
                }
        }
        public void AddWeapon(Weapon weapon)
        {
            if (!SpaceshipArmory.Weapons.Contains(weapon))
                throw new ArmoryException("This spaceship cannot add a weapon not inside his armory.");
            if (Weapons.Count < MAX_WEAPONS)
                Weapons.Add(weapon);
            else
                Console.WriteLine("You have reached max weapon capacity!");
        }
        public void RemoveWeapon(Weapon weapon)
        {
            bool removed = Weapons.Remove(weapon);
            if (!removed)
                Console.WriteLine("This weapon was not found on the spaceship.");
        }
        public void ClearWeapons()
        {
            Weapons.Clear();
        }
        public void ViewShip()
        {
            Console.WriteLine("*-*-*-*-*-*-*-*");
            Console.WriteLine("Spaceship Information:");
            Console.WriteLine($"Name: {Name}");
            Console.WriteLine($"Max Structure: {Structure}");
            Console.WriteLine($"Max Shield: {Shield}");
            Console.WriteLine($"Current Structure: {CurrentStructure}");
            Console.WriteLine($"Current Shield: {CurrentShield}");
            Console.WriteLine($"Is Destroyed: {IsDestroyed}");
            ViewWeapons();
            Console.WriteLine($"Average damage of all weapons inside the ship: {AverageDamages}");
            Console.WriteLine("*-*-*-*-*-*-*-*");
        }
        public void ViewWeapons()
        {
            Console.WriteLine("Weapons on the spaceship:");
            if (Weapons.Count == 0)
                Console.WriteLine("Currently none.");
            else
                foreach (var weapon in Weapons)
                    ViewDetailedWeapon(weapon);
        }
        private void ViewDetailedWeapon(Weapon weapon)
        {
            Console.WriteLine($"Name: {weapon.Name}, Type: {weapon.Type}, Damage: {weapon.MinDamage}-{weapon.MaxDamage}, ReloadTime: {weapon.ReloadTime}");
        }
    }
}
