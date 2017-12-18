using System;
using Android.App;
using Android.Content;
using Android.OS;
using Com.Lilarcor.Cheeseknife;

namespace Exercise6And7
{
    [Activity(Label = "Login", Theme = "@style/MyTheme")]
    public class MainActivity : Activity
    {
        [InjectOnClick(Resource.Id.btnRegister)]
        private void StartActivityRegister(object sender, EventArgs e)
        {
            var intent = new Intent(this, typeof(Register));
            StartActivity(intent);
        }

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.Main);
            Cheeseknife.Inject(this);
        }
    }
}

