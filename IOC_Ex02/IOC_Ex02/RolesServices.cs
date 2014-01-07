using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IOC_Ex02
{
    public class RolesServices
    {
        Roles roles;
        public RolesServices(Roles roles)
        {
            this.roles = roles;
        }
        Random _random = new Random();

        public void AttackMonster(Monster model)
        {
            //Output(model.Name, model.HP);
            //Console.WriteLine("开始攻击");

            if (model.HP <= 0)
            {
                Console.WriteLine("怪物" + model.Name + "已死亡");
                return;
            }

            switch (roles.Weapon)
            {
                case WeaponType.WoodenSword:
                    {
                        model.HP -= 20;
                        Output(model.Name, 20);

                        break;
                    }
                case WeaponType.IconSword:
                    {
                        model.HP -= 30;
                        Output(model.Name, 30);

                        break;
                    }
                case WeaponType.MagicSword:
                    {
                        int loss = _random.NextDouble() < 0.5 ? 100 : 200;
                        model.HP -= loss;
                        if (200 == loss)
                        {
                            Console.WriteLine("出现暴击");
                        }

                        Output(model.Name, loss);
                        break;
                    }
                default:
                    break;
            }

            if (model.HP <= 0)
            {
                Console.WriteLine("怪物" + model.Name + "已死亡");
                return;
            }
        }

        public void Output(string name, int hp)
        {
            Console.WriteLine("攻击成功，怪物" + name + "损失" + hp + "HP");
        }
    }
}
