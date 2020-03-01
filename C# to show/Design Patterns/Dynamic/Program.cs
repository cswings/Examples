using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Program1
{
    class Program
    {
        static void Main(string[] args)
        {

            var king = new King();        
            king.Fight();
            king.SetWeapon(new SwordBehavior());
            king.Fight();
            var knight = new Knight();
            knight.SetWeapon(new AxeBehavior());
            knight.Fight();
            var queen = new Queen();
            queen.SetWeapon(new KnifeBehavior());
            queen.Fight();
            var troll = new Troll();
            troll.SetWeapon(new BowAndArrow());
            troll.Fight();

            Console.ReadKey();
        }
    }
}
