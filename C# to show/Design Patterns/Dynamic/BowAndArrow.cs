using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Program1
{
    public class BowAndArrow : WeaponBehavior
    {
        public void UseWeapon()
        {
            Console.WriteLine("Shoots an arrow");
        }
    }
}