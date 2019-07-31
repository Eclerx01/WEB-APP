using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.Database.Sqlite;
using Android.Database;


namespace Assignment4
{
    [Activity(Label = "DBHelper")]
    public class DBHelper : SQLiteOpenHelper
    {
        private static string _DatabaseName = "mydatabase.db";
        private const string TableName = "user";
        private const string ColumnFName = "f_name";
        private const string ColumnLName = "l_name";
        private const string ColumnAge = "age";
        private const string ColumnEmail = "email";
        private const string ColumnPassword = "password";

        public const string CreateUserTableQuery = "CREATE TABLE " +
        TableName + " ( " + ColumnFName + " TEXT,"
            + ColumnLName + " TEXT,"
            + ColumnAge + " TEXT,"
            + ColumnEmail + " TEXT,"
            + ColumnPassword + " TEXT)";  //Step: 1 - 4



        SQLiteDatabase myDBObj; // Step: 1 - 5
        Context myContext; // Step: 1 - 6


        public DBHelper(Context context) : base(context, name: _DatabaseName, factory: null, version: 1) //Step 2;
        {
            myContext = context;
            myDBObj = WritableDatabase; // Step:3 create a DB objects
        }

        internal ICursor SelectMyValues(string usernameValue)
        {
            String sqlQuery = "Select * from " + TableName + " Where " + ColumnEmail + " = '" + usernameValue + "'";

            ICursor result = myDBObj.RawQuery(sqlQuery, null);
            return result;
        }

        internal ICursor getUserList()
        {
            String sqlQuery = "Select * from " + TableName;

            ICursor result = myDBObj.RawQuery(sqlQuery, null);
            return result;
        }

        public override void OnCreate(SQLiteDatabase db)  // Step: 1 - 2:1
        {

            db.ExecSQL(CreateUserTableQuery);  // Step: 4

        }


        public void insertValue(String fnameValue, string lnameValue, string ageValue, string emailValue, string passwordValue)
        {
            //insert into users value(id, name, email)


            String insertSQL = "insert into " + TableName + " values ('" + fnameValue + "'," + "'" + lnameValue + "'" + "," + "'" + ageValue + "', '" + emailValue + "','" + passwordValue + "');";

            System.Console.WriteLine("Insert SQL " + insertSQL);
            myDBObj.ExecSQL(insertSQL);

        }

        internal void UpdateMyValue(String fnameValue, string lnameValue, string ageValue, string emailValue, string passwordValue)
        {
            String updateSQL = "update " + TableName + " set " + ColumnFName + " = '" + fnameValue + "', " + ColumnLName + " = '" + lnameValue + "', " + ColumnAge + " = '" + ageValue + "', " + ColumnEmail + " = '" + emailValue + "', " + ColumnPassword + " = '" + passwordValue + "' Where " + ColumnEmail + " = '" + emailValue + "';";

            System.Console.WriteLine("Update SQL " + updateSQL);
            myDBObj.ExecSQL(updateSQL);
        }

        public Boolean checkIFEmailExist(String email, String password)
        {

            String sqlQuery = "Select * from " + TableName + " Where " + ColumnEmail + " = '" + email + "' AND " + ColumnPassword + " = '" + password + "'";

            ICursor result = myDBObj.RawQuery(sqlQuery, null);

            if (result.Count > 0)
            {

                System.Console.WriteLine(" Email found ");
                return true;
            }
            else
            {
                System.Console.WriteLine(" Email not found ");
                return false;
            }


        }


        public override void OnUpgrade(SQLiteDatabase db, int oldVersion, int newVersion) // Step: 1 - 2:2
        {
            throw new NotImplementedException();
        }
    }
}


