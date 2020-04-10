using System;
using Android.App;
using Android.OS;
using Android.Runtime;
using Android.Support.Design.Widget;
using Android.Support.V7.App;
using Android.Views;
using Android.Widget;

namespace TipCalculator
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme.NoActionBar", MainLauncher = true)] // Note that this activity is the Main Launcher
    public class MainActivity : AppCompatActivity
    {
        EditText inputBill;
        Button calculateButton;
        TextView outputTip;
        TextView outputTotal;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState); // We must call the base version of onCreate
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            // Takes the xml file as an argument and instantiates the UI for the activity
            // Uses android:id values to access the views in the UI
            SetContentView(Resource.Layout.activity_main);
            // SetContent View does 2 things: 1, parses the XML and instantiates the layouts and views
            // 2, Displays the result to the user

            // Look up each of the four views and store references to them
            inputBill = FindViewById<EditText>(Resource.Id.inputBill);
            calculateButton = FindViewById<Button>(Resource.Id.calculateButton);
            outputTip = FindViewById<TextView>(Resource.Id.outputTip);
            outputTotal = FindViewById<TextView>(Resource.Id.outputTotal);

            // Subscribe a handler to the calculate Button
            calculateButton.Click += OnCalculateClick;
            
            Android.Support.V7.Widget.Toolbar toolbar = FindViewById<Android.Support.V7.Widget.Toolbar>(Resource.Id.toolbar);
            SetSupportActionBar(toolbar);    
            
            
        }

        /// <summary>
        /// Handles the user clicking the Calculate button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void OnCalculateClick(object sender, EventArgs e)
        {
            string userInput = inputBill.Text;
            // Try to convert the input to a double
            double bill = 0;
            try
            {
                bill = double.Parse(userInput);
                // Calculate the tip and total
                var tip = bill * 0.15;
                var total = bill + tip;

                // Assign these values to the appropriate TextViews
                outputTip.Text = tip.ToString();
                outputTotal.Text = total.ToString();
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);               
            }
        }
        /*
        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            MenuInflater.Inflate(Resource.Menu.menu_main, menu);
            return true;
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            int id = item.ItemId;
            if (id == Resource.Id.action_settings)
            {
                return true;
            }

            return base.OnOptionsItemSelected(item);
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
        */
	}
}

