using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IOC_Ex02
{
    class Program
    {
        static void Main(string[] args)
        {

            Monster m1 = new Monster("小怪", 30);
            Monster m3 = new Monster("中怪", 50);
            Monster m4 = new Monster("Boss", 1000);

            Roles role = new Roles();
            role.Weapon = WeaponType.WoodenSword;
            RolesServices rs = new RolesServices(role);
            rs.AttackMonster(m1);
            rs.AttackMonster(m1);
            rs.AttackMonster(m1);

            role.Weapon = WeaponType.IconSword;

            rs.AttackMonster(m3);
            rs.AttackMonster(m3);
            rs.AttackMonster(m3);

            role.Weapon = WeaponType.MagicSword;
            rs.AttackMonster(m4);
            rs.AttackMonster(m4);
            rs.AttackMonster(m4);
            rs.AttackMonster(m4);
            rs.AttackMonster(m4);


            Console.ReadKey();
        }

    }
}
