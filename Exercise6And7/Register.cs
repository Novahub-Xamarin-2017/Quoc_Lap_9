using System;
using Android.App;
using Android.OS;
using Android.Views;
using Com.Lilarcor.Cheeseknife;

namespace Exercise6And7
{
    [Activity(Label = "Register", Theme = "@style/MyTheme")]
    public class Register : Activity
    {
        [InjectOnClick(Resource.Id.btnLogin)]
        private void ReturnToMain(object sender, EventArgs e)
        {
            Finish();
        }


        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.Register);
            ActionBar.SetHomeButtonEnabled(true);
            ActionBar.SetDisplayHomeAsUpEnabled(true);
            Cheeseknife.Inject(this);
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            switch (item.ItemId)
            {
                case Android.Resource.Id.Home:
                    Finish();
                    return true;
                default:
                    return base.OnOptionsItemSelected(item);
            }
        }
    }
}