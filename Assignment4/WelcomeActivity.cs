using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Database;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;


namespace Assignment4
{
    [Activity(Label = "WelcomeAcitivity")]
    public class WelcomeActivity : Activity
    {
        DBHelper MyDBInstance;
        EditText myfirstname, mylastname, myage, myemail, mypassword;
        Button MyEdit;


        private const string ColumnFName = "f_name";
        private const string ColumnLName = "l_name";
        private const string ColumnAge = "age";
        private const string ColumnEmail = "email";
        private const string ColumnPassword = "password";
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.activity_welcome);
            myfirstname = FindViewById<EditText>(Resource.Id.firstname1);
            mylastname = FindViewById<EditText>(Resource.Id.lastname1);
            myage = FindViewById<EditText>(Resource.Id.age1);
            myemail = FindViewById<EditText>(Resource.Id.email1);
            mypassword = FindViewById<EditText>(Resource.Id.password1);
            MyEdit = FindViewById<Button>(Resource.Id.Edit);

            var usernameValue = Intent.GetStringExtra("username");
            myfirstname.Text = usernameValue;

            MyDBInstance = new DBHelper(this);
            ICursor result = MyDBInstance.SelectMyValues(usernameValue);
            while (result.MoveToNext())
            {

                myfirstname.Text = result.GetString(0).ToString();
                mylastname.Text = result.GetString(1).ToString();
                myage.Text = result.GetString(2).ToString();
                myemail.Text = result.GetString(3).ToString();
                mypassword.Text = result.GetString(4).ToString();

            }
            MyEdit.Click += EditValue;

            Button userlistbutton = FindViewById<Button>(Resource.Id.listofuser);
            userlistbutton.Click += delegate {
                StartActivity(typeof(UserListActivity));
            };

        }

        void EditValue(object sender, System.EventArgs e)
        {

            MyDBInstance.UpdateMyValue(myfirstname.Text, mylastname.Text, myage.Text, myemail.Text, mypassword.Text);
            Toast.MakeText(this, "Update Successfull!", ToastLength.Long).Show();

        }
    }
}