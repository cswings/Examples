using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Program1
{
    public class SwordBehavior : WeaponBehavior
    {
        public void UseWeapon()
        {
            Console.WriteLine("Swings the sword");
        }
    }
}