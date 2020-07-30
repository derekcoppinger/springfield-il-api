using System;
// using System.Data.SQLite;

namespace CityOfSpringfield.Data.Context
{
    public class Repository
    {
        public static string DbFile
        {
            get { return Environment.CurrentDirectory + ".."; }
        }

        // public static SQLiteConnection SimpleDbConnection()
        // {
        //     return new SQLiteConnection("Data Source=" + DbFile);
        // }
    }
}