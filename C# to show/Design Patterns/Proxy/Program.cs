using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Program11
{
    class Program
    {
        static void Main(string[] args)
        {
            Database db = new Database("db.dat");
            Test(db);
            Database userdb = new Database("userdb.dat");
            SecureDB sdb = new SecureDB(db, userdb);
            Test(sdb);

            CacheDB cdb = new CacheDB(sdb);
            Test(cdb);
            cdb.Inspect();

            try
            {
                Database db2 = new Database("noname.dat");
            }
            catch(Exception x)
            {
                Console.WriteLine($"{x.Message}");
            }

            Console.ReadKey();
        }

        static void Test(IDatabase db)
        {
            Console.WriteLine($"{db.Get("one")}");
            Console.WriteLine($"{db.Get("two")}");
            Console.WriteLine($"{db.Exists("two")}");
            Console.WriteLine($"{db.Get("three")}");
            Console.WriteLine($"{db.Get("four")}");
            Console.WriteLine($"{db.Get("five")}");
            Console.WriteLine($"{db.Get("six")}");
            Console.WriteLine($"{db.Get("one")}");
            Console.WriteLine($"{db.Get("seven")}");
            Console.WriteLine(""); ;
        }
    }
}
