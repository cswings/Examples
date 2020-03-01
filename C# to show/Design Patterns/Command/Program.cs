using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace Program6
{
    class Program
    {
        static TextReader input = Console.In;
        static void Main(string[] args)
        {
            string command = "";
            string dbID = "";
            string lastDbID = "";
            string key = "";
            string value = "";
            int howMany = 0;
            if (args.Any())
            {
                var path = args[0];
                if (File.Exists(path))
                {
                    string[] lines = File.ReadAllLines(path);

                    foreach(string line in lines)
                    {
                        string[] words = line.Split(' ');
                        howMany = words.Length;
                        //<command> <database id> <key> [<value>]             
                        command = words[0];
                        if(command == "B" || command == "E")
                        {
                            Database deb = Database.GetInstance(lastDbID);
                            if (command == "B")
                            {
                                deb.BeginMacro();
                            }
                            else
                            {
                                deb.EndMacro();
                            }
                            continue;
                        }
                        dbID = words[1];
                        Database db = Database.GetInstance(dbID);
                        if (lastDbID != dbID)
                        {
                            lastDbID = dbID;
                        }
                        
                        key = words[2];
                        if (howMany > 4)
                        {
                            //combine the additional values into one
                            value = words[3] + " " + words[4];
                        }
                        else if (howMany > 3)
                        {
                            value = words[3];
                        }
                        else
                        {
                            value = "";
                        }
                        
                        Receiver receiver = new Receiver(key, value);
                        switch (command)
                        {
                            case "A":
                                AddCommand add = new AddCommand(receiver, dbID, db);
                                db.Add(add);
                                break;                            
                            case "R":
                                RemoveCommand remove = new RemoveCommand(receiver, dbID, db);
                                db.Remove(remove);
                                break;                            
                            case "U":
                                UpdateCommand update = new UpdateCommand(receiver, dbID, db);
                                db.Update(update);
                                break;
                            default:
                                break;
                        }                  
                    }
                    Database db2 = Database.GetInstance(lastDbID);
                    db2.Display();
                    db2.Undo();
                    Console.ReadKey();
                }
                else
                {
                    Console.WriteLine("Incorrect file!");
                    Console.ReadKey();
                    return;
                }
            }
            else
            {
                Console.WriteLine("No file name passed!");
                Console.ReadKey();
                return;
            }         
        }
    }
}
