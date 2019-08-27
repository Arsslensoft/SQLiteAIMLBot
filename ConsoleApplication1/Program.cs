using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SQLite;
using System.Windows.Forms;

namespace ConsoleApplication1
{
    class Program
    {
        internal static string BuildConString(string dbfile, int cachesize, int version, int maxpagecount, int pagesize, bool pooling, bool Sync)
        {
            SQLiteConnectionStringBuilder wdbcons = new SQLiteConnectionStringBuilder();
            wdbcons.CacheSize = cachesize;
            wdbcons.DataSource = dbfile;
            wdbcons.Version = version;
            wdbcons.MaxPageCount = maxpagecount;
            wdbcons.PageSize = pagesize;
            wdbcons.Pooling = pooling;
            wdbcons.JournalMode = SQLiteJournalModeEnum.Off;
            if (Sync)
            {
                wdbcons.SyncMode = SynchronizationModes.Full;
            }
            else
            {
                wdbcons.SyncMode = SynchronizationModes.Off;
            }
            wdbcons.FailIfMissing = true;
            return wdbcons.ConnectionString;
        }
        static void Main(string[] args)
          {
              System.Data.SQLite.SQLiteConnection SDB = new SQLiteConnection();
              SDB.ConnectionString = BuildConString(@"D:\AIML\ConsoleBot\bin\Debug\AIML.aidb", 16384, 3, 300000, 300000, true, false);
              SDB.Open();
              using (SQLiteCommand cmd = new SQLiteCommand("CREATE VIRTUAL TABLE A USING fts4(path TEXT, word TEXT, template TEXT, childrens INTEGER, file TEXT);", SDB))
              {
                  cmd.ExecuteNonQuery();
                  cmd.CommandText = "CREATE VIRTUAL TABLE B USING fts4(path TEXT, word TEXT, template TEXT, childrens INTEGER, file TEXT);";
                  cmd.ExecuteNonQuery();
                  cmd.CommandText = "CREATE VIRTUAL TABLE C USING fts4(path TEXT, word TEXT, template TEXT, childrens INTEGER, file TEXT);";
                  cmd.ExecuteNonQuery();
                  cmd.CommandText = "CREATE VIRTUAL TABLE D USING fts4(path TEXT, word TEXT, template TEXT, childrens INTEGER, file TEXT);";
                  cmd.ExecuteNonQuery();
                  cmd.CommandText = "CREATE VIRTUAL TABLE E USING fts4(path TEXT, word TEXT, template TEXT, childrens INTEGER, file TEXT);";
                  cmd.ExecuteNonQuery();
                  cmd.CommandText = "CREATE VIRTUAL TABLE F USING fts4(path TEXT, word TEXT, template TEXT, childrens INTEGER, file TEXT);";
                  cmd.ExecuteNonQuery();

                  cmd.CommandText = "CREATE VIRTUAL TABLE ZERO USING fts4(path TEXT, word TEXT, template TEXT, childrens INTEGER, file TEXT);";
                  cmd.ExecuteNonQuery();
                  cmd.CommandText = "CREATE VIRTUAL TABLE ONE USING fts4(path TEXT, word TEXT, template TEXT, childrens INTEGER, file TEXT);";
                  cmd.ExecuteNonQuery();
                  cmd.CommandText = "CREATE VIRTUAL TABLE TWO USING fts4(path TEXT, word TEXT, template TEXT, childrens INTEGER, file TEXT);";
                  cmd.ExecuteNonQuery();
                  cmd.CommandText = "CREATE VIRTUAL TABLE THREE USING fts4(path TEXT, word TEXT, template TEXT, childrens INTEGER, file TEXT);";
                  cmd.ExecuteNonQuery();
                  cmd.CommandText = "CREATE VIRTUAL TABLE FOUR USING fts4(path TEXT, word TEXT, template TEXT, childrens INTEGER, file TEXT);";
                  cmd.ExecuteNonQuery();
                  cmd.CommandText = "CREATE VIRTUAL TABLE FIVE USING fts4(path TEXT, word TEXT, template TEXT, childrens INTEGER, file TEXT);";
                  cmd.ExecuteNonQuery();
                  cmd.CommandText = "CREATE VIRTUAL TABLE SIX USING fts4(path TEXT, word TEXT, template TEXT, childrens INTEGER, file TEXT);";
                  cmd.ExecuteNonQuery();
                  cmd.CommandText = "CREATE VIRTUAL TABLE SEVEN USING fts4(path TEXT, word TEXT, template TEXT, childrens INTEGER, file TEXT);";
                  cmd.ExecuteNonQuery();
                  cmd.CommandText = "CREATE VIRTUAL TABLE EIGHT USING fts4(path TEXT, word TEXT, template TEXT, childrens INTEGER, file TEXT);";
                  cmd.ExecuteNonQuery();
                  cmd.CommandText = "CREATE VIRTUAL TABLE NINE USING fts4(path TEXT, word TEXT, template TEXT, childrens INTEGER, file TEXT);";
                  cmd.ExecuteNonQuery();
           

              }
              //using (SQLiteTransaction trans = SDB.BeginTransaction())
              //{
              //    using (SQLiteCommand cmd = SDB.CreateCommand())
              //    {
              //        cmd.CommandText = "INSERT INTO ROOT (path, word, template, childrens, file) VALUES('root', '', '', 2193,'');";
              //        cmd.ExecuteNonQuery();
              //    }

              //    trans.Commit();
              //}
              SDB.Close();
              Console.Read();
        }
    }
}
