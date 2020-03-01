using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Program6
{
    public class Database //the invoker
    {
        private static Database _instance = new Database();
        private static readonly object _lockObj = new object();
        public string idHolder = "";
        private static Dictionary<string, Database> dbs = new Dictionary<string, Database>();

        public Dictionary<string, string> data = new Dictionary<string, string>();
        //List<string> dataBases = new List<string>();
        private bool macro = false;
        private List<ICommand> _commands = new List<ICommand>();
        private static List<ICommand> _commands2 = new List<ICommand>();
        //private List<string> _order_commands = new List<string>();

       
        public static Database GetInstance(string id)
        {
            if (_instance.idHolder != id)
            {
                _instance = null;
                if (_instance == null)
                {
                    lock (_lockObj)
                    {
                        if (_instance == null)
                        {
                            if (dbs.Count < 1)
                            {
                                _instance = new Database();
                                //_instance.dataBases.Add(id);
                                _instance.idHolder = id;
                                dbs.Add(id, _instance);
                            }
                            if (!dbs.ContainsKey(id))
                            {
                                _instance = new Database();
                               // _instance.dataBases.Add(id);
                                _instance.idHolder = id;
                                dbs.Add(id, _instance);
                            }
                            else
                            {
                                //return reference to object
                                _instance = dbs[id];                               
                            }
                        };
                    }
                }
            }
            return _instance;
        }
      
        public void Display()
        {
            Console.WriteLine("");
            Console.WriteLine("Contents of Databases:");
            foreach(var thing in dbs)
            {
                Console.WriteLine($"Database {thing.Key}:");
                foreach(var thang in thing.Value.data)
                {
                    Console.WriteLine($"{thang.Key}| {thang.Value}");
                }
                Console.WriteLine("");
            }

        }

        public void Add(ICommand add)
        {
            if (macro == true)
            {
                _commands.Add(add);
            }
            else
            {
                add.Execute();
            }
            _commands2.Add(add);
     
        }   

        public void Update(ICommand update)
        {
            if (macro == true)
            {
                _commands.Add(update);
            }
            else
            {
                update.Execute();
            }
            _commands2.Add(update);
        }

        public void Remove(ICommand remove)
        {
            if (macro == true)
            {
                _commands.Add(remove);
            }
            else
            {
                remove.Execute();
            }
            _commands2.Add(remove);
        }     

        public void BeginMacro()
        {
            macro = true;
            ICommand begin = new BeginCommand();
            begin.Execute();
            
            _commands2.Add(begin);
        }

        public void EndMacro()
        {
            macro = false;
            ICommand end = new EndCommand();
            end.Execute();            
            _commands2.Add(end);
            foreach(ICommand command in _commands)
            {
                command.Execute();
            }
        }

        public void Undo()
        {
            //undo everything
            for(int i = _commands2.Count-1; i >= 0; i--)
            {
                ICommand command = _commands2[i] as ICommand;
                command.UnExecute();
            }
            Display();
        }
    }
}