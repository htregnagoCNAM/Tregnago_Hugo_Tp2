using Tregnago_Hugo_Tp2.Enums;
using Tregnago_Hugo_Tp2.Interfaces;

namespace Tregnago_Hugo_Tp2.Models
{
    public class Weapon : IWeapon
    {
        public string Name { get; set; }
        public EWeaponType Type { get; set; }
        public double MinDamage { get; set; }
        public double MaxDamage { get; set; }
        public double AverageDamage { get { return (MinDamage + MaxDamage) / 2; } }
        public double ReloadTime { get; set; }
        public double TimeBeforReload { get; set; }
        public bool IsReload { get; private set; }
        private Random random = new Random();

        public Weapon(string name, double minDamage, double maxDamage, EWeaponType type, double reloadTime)
        {
            Name = name;
            MinDamage = minDamage;
            MaxDamage = maxDamage;
            Type = type;
            ReloadTime = reloadTime;
            TimeBeforReload = reloadTime;
            IsReload = true;
        }

        public double Shoot()
        {
            if (!IsReload)
                return 0.0;
            else
                return CalculateDamage();
        }

        private double CalculateDamage()
        {
            double damage = 0.0;
            switch (Type)
            {
                case EWeaponType.Direct:
                    damage = CalculateDamageDirect(); break;
                case EWeaponType.Explosive:
                    damage = CalculateDamageExplosive(); break;
                case EWeaponType.Guided:
                    damage = CalculateDamageGuided(); break;
            }
            if (damage != 0.0)
            {
                Console.WriteLine($"{damage} was rolled!");
                IsReload = false;
                TimeBeforReload = ReloadTime;
            }
            else
                Console.WriteLine("No damage rolled!");
            return damage;
        }
        private double CalculateDamageDirect()
        {
            if (random.Next(0, 10) == 0)
                return 0.0;
            return AverageDamage;
        }
        private double CalculateDamageExplosive()
        {
            if (random.Next(0, 4) == 0)
                return 0.0;
            double damage = AverageDamage;
            ReloadTime *= 2;
            MinDamage *= 2;
            MaxDamage *= 2;
            return damage;
        }
        private double CalculateDamageGuided()
        {
            return MinDamage;
        }
        public void DecreaseReloadTime(double time = 1.0)
        {
            TimeBeforReload -= time;
            if (TimeBeforReload < 0.0)
            {
                IsReload = true;
                TimeBeforReload = 0.0;
            }
        }
        public void ReloadWeapon()
        {
            IsReload = true;
            TimeBeforReload = 0.0;
        }
        public override bool Equals(object? obj)
        {
            if (obj == null || GetType() != obj.GetType())
                return false;

            Weapon otherWeapon = (Weapon)obj;
            return Name == otherWeapon.Name &&
                MinDamage == otherWeapon.MinDamage &&
                MaxDamage == otherWeapon.MaxDamage &&
                Type == otherWeapon.Type;
        }

        public override int GetHashCode()
        {
            throw new NotImplementedException();
        }
    }
}
