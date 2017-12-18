using Android.App;
using Android.Content;
using Android.OS;

namespace Exercise6And7
{
    [Activity(Label = "SplashActivity", MainLauncher = true, Theme = "@style/SplashTheme")]
    public class SplashActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            var intent = new Intent(this, typeof(MainActivity));
            StartActivity(intent);
            Finish();
        }
    }
}