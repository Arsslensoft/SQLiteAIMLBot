using System;
using AIMLbot;
using AIMLbot.Utils;
using System.Collections.Generic;
using System.Data.SQLite;

namespace ConsoleBot
{
    class Program
    {
        static void Main(string[] args)
        {
            Bot myBot = new Bot();
            myBot.loadSettings();
            User myUser = new User("consoleUser", myBot);
            myBot.isAcceptingUserInput = false;
            myBot.loadAIMLFromFiles();
            myBot.isAcceptingUserInput = true;
            while (true)
            {
                Console.Write("You: ");
      
                string input = Console.ReadLine();
                if (input.ToLower() == "quit")
                {
                    break;
                }
                else
                {
                    Request r = new Request(input, myUser, myBot);
                    Result res = myBot.Chat(r);
                    Console.WriteLine("Bot: " + res.Output);
                }
            }
            Bot.str.Close();
            //Console.WriteLine("INSERTING");
            //Add("root", myBot.Graphmaster);
            Bot.SDB.Close();
        }
        static long i = 0;
        //static void Add(string path, Node node)
        //{
        //    Console.Clear();
        //    i++;
        //    Console.Write(i);
        //    foreach (KeyValuePair<string, Node> pair in node.children)
        //    {
        //        Insert(path, pair.Value);
        //        Add(path + "@" + pair.Key, pair.Value);
        //    }
        //}
        //static void Insert(string path, Node node)
        //{
        //    using (SQLiteTransaction trans = Bot.SDB.BeginTransaction())
        //    {
        //        using (SQLiteCommand cmd = Bot.SDB.CreateCommand())
        //        {
        //            cmd.CommandText = string.Format("INSERT INTO " + Bot.GetTable(Bot.GETMD5(path + "@" + node.word)) + " (path, word, template, childrens, file) VALUES('{0}', '{1}', '{2}', {3},'{4}');", Bot.GETMD5(path + "@" + node.word), DB.Normalize(node.word, false), DB.Normalize(node.template, false), node.NumberOfChildNodes, DB.Normalize(node.filename, false));
        //            cmd.ExecuteNonQuery();
        //        }

        //        trans.Commit();
        //    }
        //}
    }
}
