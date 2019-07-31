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

namespace Assignment4
{

    [Activity(Label = "Register")]
    public class Register : Activity
    {
        EditText myFirstName, myLastName, age, email, password;
        Button register;
        Android.App.AlertDialog.Builder myAlert;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.activity_register);

            DBHelper myDBHelper = new DBHelper(this);

            myFirstName = FindViewById<EditText>(Resource.Id.firstname);
            myLastName = FindViewById<EditText>(Resource.Id.lastname);
            age = FindViewById<EditText>(Resource.Id.age);
            email = FindViewById<EditText>(Resource.Id.email);
            password = FindViewById<EditText>(Resource.Id.password);

            myAlert = new Android.App.AlertDialog.Builder(this);
            myAlert.SetTitle("Error");
            myAlert.SetMessage("Please Enter Your all details");
            myAlert.SetPositiveButton("OK", OkAction);

            Dialog myDialog = myAlert.Create();

            register = FindViewById<Button>(Resource.Id.signup);
            register.Click += delegate {
                if (myFirstName.Text == "" || myLastName.Text == "" || age.Text == "" || email.Text == "" || password.Text == "")
                {
                    myDialog.Show();
                }
                else
                {
                    myDBHelper.insertValue(myFirstName.Text, myLastName.Text, age.Text, email.Text, password.Text);
                    Toast.MakeText(this, "Register Successfull!", ToastLength.Long).Show();
                    StartActivity(typeof(MainActivity));
                }
            };
        }

        private void OkAction(object sender, DialogClickEventArgs e)
        {

            System.Console.WriteLine("OK Button Cliked");

        }
    }
}