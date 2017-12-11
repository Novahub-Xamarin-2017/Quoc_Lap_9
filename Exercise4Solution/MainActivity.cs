using System;
using System.Collections.Generic;
using System.Globalization;
using Android.App;
using Android.OS;
using Android.Widget;
using Com.Lilarcor.Cheeseknife;
using Java.Util.Functions;

namespace Exercise4Solution
{
    [Activity(Label = "Exercise4Solution", MainLauncher = true)]
    public class MainActivity : Activity
    {
        private double result;
        private double entry;
        private Operator lastOperator;
        private bool pointNumberFlag;

        [InjectView(Resource.Id.tvResult)] private TextView tvResult;

        [InjectOnClick(Resource.Id.btnNum0)]
        private void OnClickBtnNum0(object sender, EventArgs e)
        {
            AppendNumberToEntry("0");
        }
        
        [InjectOnClick(Resource.Id.btnNum1)]
        private void OnClickBtnNum1(object sender, EventArgs e)
        {
            AppendNumberToEntry("1");
        }

        [InjectOnClick(Resource.Id.btnNum2)]
        private void OnClickBtnNu2(object sender, EventArgs e)
        {
            AppendNumberToEntry("2");
        }

        [InjectOnClick(Resource.Id.btnNum3)]
        private void OnClickBtnNum3(object sender, EventArgs e)
        {
            AppendNumberToEntry("3");
        }

        [InjectOnClick(Resource.Id.btnNum4)]
        private void OnClickBtnNum4(object sender, EventArgs e)
        {
            AppendNumberToEntry("4");
        }

        [InjectOnClick(Resource.Id.btnNum5)]
        private void OnClickBtnNum5(object sender, EventArgs e)
        {
            AppendNumberToEntry("5");
        }

        [InjectOnClick(Resource.Id.btnNum6)]
        private void OnClickBtnNum6(object sender, EventArgs e)
        {
            AppendNumberToEntry("6");
        }

        [InjectOnClick(Resource.Id.btnNum7)]
        private void OnClickBtnNum7(object sender, EventArgs e)
        {
            AppendNumberToEntry("7");
        }

        [InjectOnClick(Resource.Id.btnNum8)]
        private void OnClickBtnNum8(object sender, EventArgs e)
        {
            AppendNumberToEntry("8");
        }

        [InjectOnClick(Resource.Id.btnNum9)]
        private void OnClickBtnNum9(object sender, EventArgs e)
        {
            AppendNumberToEntry("9");
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
            if (!pointNumberFlag)
            {
                pointNumberFlag = true;
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
            tvResult.Text = Math.Sqrt(entry) + "";
            entry = 0;
            pointNumberFlag = false;
        }

        [InjectOnClick(Resource.Id.btnSquare)]
        private void OnClickBtnSquare(object sender, EventArgs e)
        {
            tvResult.Text = entry * entry + "";
            entry = 0;
            pointNumberFlag = false;
        }

        [InjectOnClick(Resource.Id.btnInverse)]
        private void OnClickBtnInverse(object sender, EventArgs e)
        {
            tvResult.Text = 1.0 / entry + "";
            entry = 0;
            pointNumberFlag = false;
        }

        private void Solve(Operator o)
        {
            switch (lastOperator)
            {
                case Operator.Add:
                    result += entry;
                    break;
                case Operator.Sub:
                    result -= entry;
                    break;
                case Operator.Mul:
                    result *= entry;
                    break;
                case Operator.Div:
                    result /= entry;
                    break;
                case Operator.Remainder:
                    result = result % entry;
                    break;
                case Operator.Solve:
                    if (!entry.Equals(0))
                    {
                        result = entry;
                    }
                    break;
                case Operator.Point:
                    break;
            }
            entry = 0;
            pointNumberFlag = false;
            lastOperator = o;
            tvResult.Text = Convert.ToString(result, CultureInfo.InvariantCulture);
        }

        private void AppendNumberToEntry(string number)
        {
            entry = Convert.ToDouble(pointNumberFlag ? tvResult.Text + number : entry + number);
            tvResult.Text = entry + "";
        }


        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            result = 0;
            entry = 0;
            pointNumberFlag = false;
            lastOperator = Operator.Add;
            Cheeseknife.Inject(this);
            
        }
    }
}

