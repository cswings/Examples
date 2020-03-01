using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Program6
{
    public class RemoveCommand : ICommand
    {
        //Make all of your commands undoable, including macro commands
        private Receiver receiver;
        private string _id;
        private Database db;
        private string key;
        private string value;
        public RemoveCommand(Receiver rec, string id, Database _ref)
        {
            receiver = rec;
            _id = id;
            db = _ref;
        }

        public void Execute()
        {
            if (db.data.ContainsKey(receiver.DataBaseKey))
            {
                key = receiver.DataBaseKey;
                value = db.data[key];
                db.data.Remove(receiver.DataBaseKey);
            }
            else
            {
                Console.WriteLine("Key "+receiver.DataBaseKey+" doesn't exist, can't remove it");
            }
        }

        public void UnExecute()
        {
            Console.WriteLine("Undid RemoveCommand:");
            db.data.Add(key, value);
            var thing = db.data;
            foreach(var thang in thing)
            {
                Console.WriteLine($"{thang.Key}| {thang.Value}");
            }
            Console.WriteLine("");
        }
    }
}