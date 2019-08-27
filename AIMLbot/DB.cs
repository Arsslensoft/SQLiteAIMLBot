using System;
using System.Collections.Generic;
using System.Text;
using AIMLbot.Utils;
using System.Data.SQLite;

namespace AIMLbot
{
   public class DB
    {
       public DB(string physical)
       {
           PhysicalPath = physical;
       }
       public XNode this[string Key]
       {
           get
           {
               XNode nd = new XNode(PhysicalPath + "@"+Key);
               nd.template = GetData(Key, "template").ToString();
               nd.word = Key;
               nd.filename = GetData(Key, "file").ToString();
               return nd;
           }
       }
       public string PhysicalPath;
       public bool ContainsKey(string Key)
       {
           return (GetKey(Key) != null);
       }
       public int Count
       {
           get { return int.Parse(GetData("", "childrens").ToString()); }
       }
       public static string Normalize(string path, bool reverse)
       {
           if (!reverse)
               return path.Replace("'", "\"");
           else
               return path.Replace("\"", "'");
       }
       object GetKey(string Key)
       {
           using (SQLiteCommand cmd = new SQLiteCommand("SELECT word FROM " + Bot.GetTable(Bot.GETMD5(PhysicalPath + "@" + Key)) + " WHERE path='" + Bot.GETMD5(PhysicalPath + "@" + Key) + "';", Bot.SDB))
           {
               return cmd.ExecuteScalar();
           }
       }
       public object GetData(string Key, string row)
       {
          
           if (Key == "" && PhysicalPath == "root")
           {
               using (SQLiteCommand cmd = new SQLiteCommand("SELECT " + row + " FROM " + Bot.GetTable(Bot.GETMD5("root@")) + " WHERE path='" + Bot.GETMD5("root@") + "';", Bot.SDB))
               {
                   object r = cmd.ExecuteScalar();
                   return r;
               }
           }
           else if (Key == "")
           {
               using (SQLiteCommand cmd = new SQLiteCommand("SELECT " + row + " FROM " + Bot.GetTable(Bot.GETMD5(PhysicalPath)) + " WHERE path = '" + Bot.GETMD5(PhysicalPath) + "';", Bot.SDB))
               {
                   object r = cmd.ExecuteScalar();
                   return r;
               }
           }
           else
           {
               using (SQLiteCommand cmd = new SQLiteCommand("SELECT " + row + " FROM " + Bot.GetTable(Bot.GETMD5(PhysicalPath + "@" + Key)) + " WHERE path = '" + Bot.GETMD5(PhysicalPath + "@" + Key) + "';", Bot.SDB))
               {
                   object r = cmd.ExecuteScalar();
                   return r;
               }
           }
       }
    }
}
