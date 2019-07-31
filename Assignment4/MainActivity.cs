using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Runtime;
using Android.Widget;
using Android.Content;
namespace Assignment4
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : Activity
    {
        EditText myUserName;
        EditText myPassword;
        Button mylogin, mySignup;
        Android.App.AlertDialog.Builder myAlert;

        DBHelper myDBHelper;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);
            myDBHelper = new DBHelper(this);

            myUserName = FindViewById<EditText>(Resource.Id.editText1);
            myPassword = FindViewById<EditText>(Resource.Id.editText2);
            mylogin = FindViewById<Button>(Resource.Id.button1);
            mySignup = FindViewById<Button>(Resource.Id.button2);



            mylogin.Click += myButtonClick;

            myAlert = new Android.App.AlertDialog.Builder(this);


            mySignup.Click += delegate {

                Intent registerPage = new Intent(this, typeof(Register));

                StartActivity(registerPage);

            };

        }



        void myButtonClick(object sender, System.EventArgs e)
        {

            //Inform the user with some Alert Message

            myAlert.SetTitle("Error");
            myAlert.SetMessage("Please Enter valid User Name or Password");
            myAlert.SetPositiveButton("OK", OkAction);

            Dialog myDialog = myAlert.Create();

            if (!myDBHelper.checkIFEmailExist(myUserName.Text, myPassword.Text))
            {

                myDialog.Show();
            }
            else
            {
                Toast.MakeText(this, "Login Successfull!", ToastLength.Long).Show();
                Intent intent = new Intent(this, typeof(WelcomeActivity));
                intent.PutExtra("username", myUserName.Text);
                StartActivity(intent);
            }
        }


        private void OkAction(object sender, DialogClickEventArgs e)
        {

            System.Console.WriteLine("OK Button Cliked");

        }


        private void CancelAction(object sender, DialogClickEventArgs e)
        {

            System.Console.WriteLine("OK Button Cliked");

        }




    }
}
