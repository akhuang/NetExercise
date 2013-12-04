using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IOC_Ex02
{
    public class Roles
    {
        public string Name { get; set; }
        public WeaponType Weapon { get; set; }
    }

    public class Monster
    {
        public Monster(string name, int hp)
        {
            Name = name;
            HP = hp;
        }
        public string Name { get; set; }
        public int HP { get; set; }
    }

    public enum WeaponType
    {
        WoodenSword = 1,
        IconSword = 2,
        MagicSword = 3
    }
}
