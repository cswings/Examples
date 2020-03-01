using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Program6
{
    public class UpdateCommand : ICommand
    {
        //Make all of your commands undoable, including macro commands
        private Receiver receiver;
        private string _id;
        private string key;
        private string value;
        private string undoValue;
        private Database db;
        public UpdateCommand(Receiver rec, string id, Database _ref)
        {
            receiver = rec;
            key = rec.DataBaseKey;
            value = rec.DataBaseValue;
            _id = id;
            db = _ref;
        }

        public void Execute()
        {
            //Update should do nothing if the key in its request does not exist
            if (db.data.ContainsKey(receiver.DataBaseKey))
            {
                undoValue = db.data[receiver.DataBaseKey];
                db.data[receiver.DataBaseKey] = receiver.DataBaseValue;
            }
            else
            {
                Console.WriteLine("Key "+receiver.DataBaseKey+" doesn't exist, can't update it");
            }
        }

        public void UnExecute()
        {
            Console.WriteLine("Undid UpdateCommand:");
            db.data[receiver.DataBaseKey] = undoValue;
            var thing = db.data;
            foreach (var thang in thing)
            {
                Console.WriteLine($"{thang.Key}| {thang.Value}");
            }
            Console.WriteLine("");
        }
    }
}