using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Program1
{
    public abstract class Character
    {
        public WeaponBehavior Weapon;
        public Character()
        {
        }

        public void Fight()
        {

            try
            {
                Weapon.UseWeapon();
            }
            catch(Exception c)
            {
                Console.WriteLine("tries to punch");
            }
        }

        public void SetWeapon(WeaponBehavior w)
        {
            Weapon = w;
        }
    }
}