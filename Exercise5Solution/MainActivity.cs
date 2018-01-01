using Android.App;
using Android.Widget;
using Android.OS;
using Android.Views;
using Com.Lilarcor.Cheeseknife;

namespace Exercise5Solution
{
    [Activity(Label = "Exercise5Solution", MainLauncher = true)]
    public class MainActivity : Activity
    {
        [InjectView(Resource.Id.toolbar)] private Toolbar toolbar;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            Cheeseknife.Inject(this);
            SetActionBar(toolbar);
        }

        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            MenuInflater.Inflate(Resource.Menu.menu, menu);
            return base.OnCreateOptionsMenu(menu);
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            Toast.MakeText(this, "Action selected: " + item.TitleFormatted,
                ToastLength.Short).Show();
            return base.OnOptionsItemSelected(item);
        }
    }
}

