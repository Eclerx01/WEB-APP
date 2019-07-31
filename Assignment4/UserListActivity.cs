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
    [Activity(Label = "UserListActivity")]
    public class UserListActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.user_list_layout);

            ListView listView = FindViewById<ListView>(Resource.Id.listViewUser);
            List<string> userArray = new List<string>();

            DBHelper myDBHelper = new DBHelper(this);

            ICursor result = myDBHelper.getUserList();

            while (result.MoveToNext())
            {

                userArray.Add(result.GetString(0).ToString() + " " + result.GetString(1).ToString());

            }

            ArrayAdapter adapter = new ArrayAdapter(this, Android.Resource.Layout.SimpleExpandableListItem1, userArray); // Context
            listView.Adapter = adapter;
        }
    }
}