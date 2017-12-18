using System;
using System.Globalization;
using Android.App;
using Android.OS;
using Android.Widget;
using Com.Lilarcor.Cheeseknife;

namespace Exercise4Solution
{
    [Activity(Label = "Exercise4Solution", MainLauncher = true)]
    public class MainActivity : Activity
    {
        private double result;
        private double entry;
        private Operator lastOperator;

        [InjectView(Resource.Id.tvResult)] private TextView tvResult;

        [InjectOnClick(Resource.Id.btnNum0)]
        private void OnClickBtnNum0(object sender, EventArgs e)
        {
            AppendNumberToEntry(((Button)sender).Tag + "");
        }
        
        [InjectOnClick(Resource.Id.btnNum1)]
        private void OnClickBtnNum1(object sender, EventArgs e)
        {
            AppendNumberToEntry(((Button)sender).Tag + "");
        }

        [InjectOnClick(Resource.Id.btnNum2)]
        private void OnClickBtnNu2(object sender, EventArgs e)
        {
            AppendNumberToEntry(((Button)sender).Tag + "");
        }

        [InjectOnClick(Resource.Id.btnNum3)]
        private void OnClickBtnNum3(object sender, EventArgs e)
        {
            AppendNumberToEntry(((Button)sender).Tag + "");
        }

        [InjectOnClick(Resource.Id.btnNum4)]
        private void OnClickBtnNum4(object sender, EventArgs e)
        {
            AppendNumberToEntry(((Button)sender).Tag + "");
        }

        [InjectOnClick(Resource.Id.btnNum5)]
        private void OnClickBtnNum5(object sender, EventArgs e)
        {
            AppendNumberToEntry(((Button)sender).Tag + "");
        }

        [InjectOnClick(Resource.Id.btnNum6)]
        private void OnClickBtnNum6(object sender, EventArgs e)
        {
            AppendNumberToEntry(((Button)sender).Tag + "");
        }

        [InjectOnClick(Resource.Id.btnNum7)]
        private void OnClickBtnNum7(object sender, EventArgs e)
        {
            AppendNumberToEntry(((Button)sender).Tag + "");
        }

        [InjectOnClick(Resource.Id.btnNum8)]
        private void OnClickBtnNum8(object sender, EventArgs e)
        {
            AppendNumberToEntry(((Button)sender).Tag + "");
        }

        [InjectOnClick(Resource.Id.btnNum9)]
        private void OnClickBtnNum9(object sender, EventArgs e)
        {
            AppendNumberToEntry(((Button)sender).Tag + "");
        }

        [InjectOnClick(Resource.Id.btnSolve)]
        private void OnClickBtnSolve(object sender, EventArgs e)
        {
            Solve(Operator.Solve);
        }

        [InjectOnClick(Resource.Id.btnAdd)]
        private void OnClickBtnAdd(object sender, EventArgs e)
        {
            Solve(Operator.Add);
        }

        [InjectOnClick(Resource.Id.btnSub)]
        private void OnClickBtnSub(object sender, EventArgs e)
        {
            Solve(Operator.Sub);
        }

        [InjectOnClick(Resource.Id.btnMul)]
        private void OnClickBtnMul(object sender, EventArgs e)
        {
            Solve(Operator.Mul);
        }

        [InjectOnClick(Resource.Id.btnDiv)]
        private void OnClickBtnDiv(object sender, EventArgs e)
        {
            Solve(Operator.Div);
        }

        [InjectOnClick(Resource.Id.btnRemainer)]
        private void OnClickBtnRemainder(object sender, EventArgs e)
        {
            Solve(Operator.Remainder);
        }

        [InjectOnClick(Resource.Id.btnClear)]
        private void OnClickBtnClear(object sender, EventArgs e)
        {
            tvResult.Text = "0";
            result = 0;
            entry = 0;
        }

        [InjectOnClick(Resource.Id.btnClearEntry)]
        private void OnClickBtnClearEntry(object sender, EventArgs e)
        {
            tvResult.Text = "0";
            entry = 0;
        }

        [InjectOnClick(Resource.Id.btnBackspace)]
        private void OnClickBtnBackspace(object sender, EventArgs e)
        {
            var entryText = entry.ToString(CultureInfo.InvariantCulture);
            entryText = entryText.Remove(entryText.Length - 1);
            entry = Convert.ToDouble(entryText);
            tvResult.Text = entryText;
        }

        [InjectOnClick(Resource.Id.btnPoint)]
        private void OnClickBtnPoint(object sender, EventArgs e)
        {
            if (!tvResult.Text.Contains("."))
            {
                tvResult.Text = entry + ".";
            }
        }

        [InjectOnClick(Resource.Id.btnChangeStatus)]
        private void OnClickBtnChangeStatus(object sender, EventArgs e)
        {
            entry = entry > 0 ? -entry : entry;
            tvResult.Text = entry + "";
        }

        [InjectOnClick(Resource.Id.btnSquareRoot)]
        private void OnClickBtnSquareRoot(object sender, EventArgs e)
        {
            if (entry >= 0)
            {
                entry = Math.Sqrt(entry);
                tvResult.Text = entry + "";
                entry = 0;
            }
            else
            {
                entry = 0;
                result = 0;
                tvResult.Text = "Invalid input";
            }
        }

        [InjectOnClick(Resource.Id.btnQuare)]
        private void OnClickBtnSquare(object sender, EventArgs e)
        {
            entry = entry * entry;
            tvResult.Text = entry + "";
            entry = 0;
        }

        [InjectOnClick(Resource.Id.btnInverse)]
        private void OnClickBtnInverse(object sender, EventArgs e)
        {
            entry = 1.0 / entry;
            tvResult.Text = entry + "";
            entry = 0;
        }

        private void Solve(Operator o)
        {
            switch (lastOperator)
            {
                case Operator.Add:
                    result += Convert.ToDouble(tvResult.Text);
                    break;
                case Operator.Sub:
                    result -= Convert.ToDouble(tvResult.Text);
                    break;
                case Operator.Mul:
                    result *= Convert.ToDouble(tvResult.Text);
                    break;
                case Operator.Div:
                    result /= Convert.ToDouble(tvResult.Text);
                    break;
                case Operator.Remainder:
                    result = result % Convert.ToDouble(tvResult.Text);
                    break;
                case Operator.Solve:
                    if (tvResult.Text != "0")
                    {
                        result = Convert.ToDouble(tvResult.Text);
                    }
                    break;
                case Operator.Point:
                    break;
            }
            entry = 0;
            lastOperator = o;
            tvResult.Text = Convert.ToString(result, CultureInfo.InvariantCulture);
        }

        private void AppendNumberToEntry(string number)
        {
            entry = Convert.ToDouble(tvResult.Text.Contains(".") || tvResult.Text == "Invalid input"
                ? entry + number
                : tvResult.Text + number);
            tvResult.Text = entry + "";
        }


        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            result = 0;
            entry = 0;
            lastOperator = Operator.Add;
            Cheeseknife.Inject(this);
            
        }
    }
}

