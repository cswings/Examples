using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Program1
{
    public class KnifeBehavior : WeaponBehavior
    {
        public void UseWeapon()
        {
            Console.WriteLine("Sneakily stabs with a knife");
        }
    }
}