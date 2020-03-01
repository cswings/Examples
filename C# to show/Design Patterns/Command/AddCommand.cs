using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Program6
{
    public class AddCommand : ICommand
    {
        //Make all of your commands undoable, including macro commands
        private Receiver receiver;
        private string _id;
        private Database db;
        private string key;
        private string value;
        public AddCommand(Receiver rec, string id, Database _ref)
        {
            receiver = rec;
            _id = id;
            db = _ref;
        }

        public void Execute()
        {
            // Do not allow an Add command to modify a 
            //record whose key already exists
            if (!db.data.ContainsKey(receiver.DataBaseKey))
            {
                db.data.Add(receiver.DataBaseKey, receiver.DataBaseValue);
            }
            else
            {
                Console.WriteLine("Key "+receiver.DataBaseKey + " already exists, can't add it in");
            }
        }

        public void UnExecute()
        {
            Console.WriteLine("Undid AddCommand:");
            var last = db.data.Keys.Last();
            db.data.Remove(last);
            var thing = db.data;
            foreach(var thang in thing)
            {
                Console.WriteLine($"{thang.Key}| {thang.Value}");
            }
            Console.WriteLine("");
        }
    }
}