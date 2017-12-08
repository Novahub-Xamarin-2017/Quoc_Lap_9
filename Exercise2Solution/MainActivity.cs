using System;
using Android.App;
using Android.OS;
using Android.Widget;
using Com.Lilarcor.Cheeseknife;

namespace Exercise2Solution
{
    [Activity(Label = "Exercise2Solution", MainLauncher = true)]
    public class MainActivity : Activity
    {
        [InjectView(Resource.Id.etA)] private EditText etA;
        [InjectView(Resource.Id.etB)] private EditText etB;
        [InjectView(Resource.Id.etC)] private EditText etC;
        [InjectView(Resource.Id.tvResult)] private TextView tvResult;

        [InjectOnClick(Resource.Id.btSolve)]
        void OnClickBtSolve(object sender, EventArgs e)
        {
            var numberA = double.Parse(etA.Text);
            var numberB = double.Parse(etB.Text);
            var numberC = double.Parse(etC.Text);
            var result = SolveQuadricEquation(numberA, numberB, numberC);
            tvResult.Text = result;
        }

        private string SolveQuadricEquation(double a, double b, double c)
        {
            if (a.Equals(0))
            {
                return b.Equals(0) ? (c.Equals(0) ? "Infinite solutions" : "No solution") : $"x = {-b / a}";
            }
            var delta = b * b - 4 * a * c;
            return delta > 0
                ? $"x1 = {(-b + Math.Sqrt(delta)) / 2 / a}, x2 = {(-b - Math.Sqrt(delta)) / 2 / a} "
                : (delta < 0 ? "No solutions" : $"x = {-b / 2 / a}");
        }

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);
            Cheeseknife.Inject(this);
        }
    }
}

