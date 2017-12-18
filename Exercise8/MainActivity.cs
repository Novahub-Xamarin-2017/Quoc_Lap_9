using Android.App;
using Android.Widget;
using Android.OS;
using Exercise8.CustomControls;

namespace Exercise8
{
    [Activity(Label = "Exercise8", MainLauncher = true)]
    public class MainActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            var progressCtrol = FindViewById<CircularProgress>(Resource.Id.progressControl);

            progressCtrol.Value = 75;
        }
    }
}

