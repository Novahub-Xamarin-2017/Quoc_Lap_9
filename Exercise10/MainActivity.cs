using Android.App;
using Android.OS;
using Java.Lang;

namespace Exercise10
{
    [Activity(Label = "Exercise10", MainLauncher = true)]
    public class MainActivity : Activity
    {
        private Clock clock;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.Main);

            clock = FindViewById<Clock>(Resource.Id.clock);
            new Thread(Run).Start();
            clock.Invalidate();
        }

        private void Run()
        {
            while (true)
            {
                Thread.Sleep(200);
                RunOnUiThread(clock.PostInvalidate);
            }
        }
    }
}

