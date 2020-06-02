using System;

namespace interfaces
{
    class Program
    {
        static void Main(string[] args)
        {
            Warrior warrior = new Warrior();
            warrior.Weapon = new Axe("Super axe");

            Mage mage = new Mage();
            mage.Weapon = new Staff("GREATE STAFF", 100);

            warrior.Hit();
            mage.Hit();

            Console.ReadLine();
        }
    }

    enum ClassNameSet : byte
    {
        Travaller, Warrior, Mage, Archer, Rogue
    }
    enum ProfessionSet : byte
    {
        Commoner, Knight, Berserker, Elementalist, Necromancer, Healer, Sniper, Hunter, Assassin, Ranger
    }
    public struct MoveSpeedSet
    {
        public const double Commoner = 0.9;
        public const double Knight = 0.7;
        public const double Berserker = 1.3;
        public const double Elementalist = 1.1;
        public const double Necromancer = 1.1;
        public const double Healer = 1.1; 
        public const double Sniper = 2.0;
        public const double Hunter = 2.2;
        public const double Assassin = 3.0;
        public const double Ranger = 2.8;
    }
    class Character : ICharacter
    {
        public ClassNameSet ClassName { get; set; }
        public ProfessionSet Profession { get; set; }
        public double MoveSpeed { get; set; }

        public Character()
        {
            ClassName = ClassNameSet.Travaller;
            Profession = ProfessionSet.Commoner;
            MoveSpeed = MoveSpeedSet.Commoner;
        }
        public Character(ClassNameSet className)
        {
            ClassName = className;
            switch (className)
            {
                case ClassNameSet.Warrior:
                    Profession = ProfessionSet.Knight;
                    break;
                case ClassNameSet.Mage:
                    Profession = ProfessionSet.Elementalist;
                    break;
                case ClassNameSet.Archer:
                    Profession = ProfessionSet.Hunter;
                    break;
                case ClassNameSet.Rogue:
                    Profession = ProfessionSet.Ranger;
                    break;
            }
            switch (Profession)
            {
                case ProfessionSet.Knight:
                    MoveSpeed = MoveSpeedSet.Knight;
                    break;
                case ProfessionSet.Elementalist:
                    MoveSpeed = MoveSpeedSet.Elementalist;
                    break;
                case ProfessionSet.Hunter:
                    MoveSpeed = MoveSpeedSet.Hunter;
                    break;
                case ProfessionSet.Ranger:
                    MoveSpeed = MoveSpeedSet.Ranger;
                    break;
            }
        }
        public Character(ClassNameSet className, ProfessionSet profession)
        {
            ClassName = className;
            Profession = profession;
            switch (Profession)
            {
                case ProfessionSet.Knight:
                    MoveSpeed = MoveSpeedSet.Knight;
                    break;
                case ProfessionSet.Berserker:
                    MoveSpeed = MoveSpeedSet.Berserker;
                    break;
                case ProfessionSet.Elementalist:
                    MoveSpeed = MoveSpeedSet.Elementalist;
                    break;
                case ProfessionSet.Necromancer:
                    MoveSpeed = MoveSpeedSet.Necromancer;
                    break;
                case ProfessionSet.Healer:
                    MoveSpeed = MoveSpeedSet.Healer;
                    break;
                case ProfessionSet.Sniper:
                    MoveSpeed = MoveSpeedSet.Sniper;
                    break;
                case ProfessionSet.Hunter:
                    MoveSpeed = MoveSpeedSet.Hunter;
                    break;
                case ProfessionSet.Assassin:
                    MoveSpeed = MoveSpeedSet.Assassin;
                    break;
                case ProfessionSet.Ranger:
                    MoveSpeed = MoveSpeedSet.Ranger;
                    break;
            }
        }
        public void Move()
        {

        }
        public void Hit()
        {
            Console.WriteLine("{0} deal {1} damage with the {2}");
        }
    }

    class Warrior
    {
        public IWeapon Weapon { get; set; }
        public Warrior()
        {
            Weapon = new Axe();
        }
        public void Hit()
        {
            Console.WriteLine("Warrior attack, using {0} with damage {1} ", Weapon.Name, Weapon.Damage);
        }
    }

    class Mage
    {
        public IWeapon Weapon { get; set; }
        public Mage()
        {
            Weapon = new Staff();
        }
        public void Hit()
        {
            Console.WriteLine("Mage attack using " + Weapon.Name + " with damage " + Weapon.Damage);
        }
    }

    class Staff : IWeapon
    {
        public string Name { get; set; }
        public double Damage { get; set; }
        public Staff()
        {
            Name = "Generic staff";
            Damage = 7.0;
        }
        public Staff(string name) : this()
        {
            Name = name;
        }
        public Staff(string name, double damage) : this()
        {
            Name = name;
            Damage = damage;
        }
    }

    class Axe : IWeapon
    {
        public string Name { get; set; }
        public double Damage { get; set; }

        public Axe()
        {
            Name = "Generic axe";
            Damage = 15.0;
        }
        public Axe(string name) : this()
        {
            Name = name;
        }
        public Axe(string name, double damage) : this()
        {
            Name = name;
            Damage = damage;
        }
    }

    interface IWeapon
    {
        string Name { get; set; }
        double Damage { get; set; }
    }

    interface ICharacter
    {
        ClassNameSet ClassName { get; set; }
        ProfessionSet Profession { get; set; }
        double MoveSpeed { get; set; }
    }
}
