using System;
using System.Collections.Generic;

namespace interfaces
{
    class Program
    {
        static void Main(string[] args)
        {
            Warrior warrior = new Warrior
            {
                Weapon = new Axe("Super axe")
            };

            Mage mage = new Mage
            {
                Weapon = new Staff("GREATE STAFF", 100)
            };

            warrior.Move();
            warrior.Hit();
            mage.Move();
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
    abstract class Character
    {
        private static Dictionary<ProfessionSet, double> professionMoveSpeedDictionary = new Dictionary<ProfessionSet, double>
        {
            { ProfessionSet.Commoner, MoveSpeedSet.Commoner },
            { ProfessionSet.Knight, MoveSpeedSet.Knight },
            { ProfessionSet.Berserker, MoveSpeedSet.Berserker },
            { ProfessionSet.Elementalist, MoveSpeedSet.Elementalist },
            { ProfessionSet.Necromancer, MoveSpeedSet.Necromancer },
            { ProfessionSet.Healer, MoveSpeedSet.Healer },
            { ProfessionSet.Sniper, MoveSpeedSet.Sniper },
            { ProfessionSet.Hunter, MoveSpeedSet.Hunter },
            { ProfessionSet.Assassin, MoveSpeedSet.Assassin },
            { ProfessionSet.Ranger, MoveSpeedSet.Ranger },
        };

        abstract public ClassNameSet ClassName { get; }
        abstract protected double ClassMoveSpeed { get; }//на случай, если от класса скорость движения тоже будет зависеть

        public ProfessionSet Profession { get; private set; }
        public IWeapon Weapon { get; set; }
        public double MoveSpeed => ClassMoveSpeed * ProfessionMoveSpeed;
        protected double ProfessionMoveSpeed { get; private set; }

        public Character(ProfessionSet profession)
        {
            Profession = profession;
            ProfessionMoveSpeed = professionMoveSpeedDictionary[profession];
        }
        public void Move()
        {
            Console.WriteLine("{0}-{1} moves by {2} meters", ClassName, Profession, MoveSpeed.ToString("F"));
        }
        public void Hit()
        {
            Console.WriteLine("{0}-{1} deal {2} damage with the {3}", ClassName, Profession, Weapon.Name, Weapon.Damage);
        }

    }

    class Warrior : Character
    {
        public override ClassNameSet ClassName => ClassNameSet.Warrior;
        protected override double ClassMoveSpeed => 1.05;

        public Warrior() : base(ProfessionSet.Knight)
        {
            Weapon = new Axe();
        }
    }

    class Mage : Character
    {
        public override ClassNameSet ClassName => ClassNameSet.Mage;
        protected override double ClassMoveSpeed => 0.9;
        public Mage() : base(ProfessionSet.Elementalist)
        {
            Weapon = new Staff();
        }
    }

    class Staff : IWeapon
    {
        public string Name { get; set; }
        public double Damage { get; set; }
        public Staff() : this("Generic staff") { }
        public Staff(string name) : this(name, 7d) { }
        public Staff(string name, double damage)
        {
            Name = name;
            Damage = damage;
        }
    }

    class Axe : IWeapon
    {
        public string Name { get; set; }
        public double Damage { get; set; }

        public Axe() : this("Generic axe") { }
        public Axe(string name) : this(name, 15d) { }
        public Axe(string name, double damage)
        {
            Name = name;
            Damage = damage;
        }
    }

    interface IWeapon
    {
        string Name { get; }
        double Damage { get; }
    }
}
