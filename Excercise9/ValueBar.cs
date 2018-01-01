using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using Android.Content;
using Android.Graphics;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Color = Android.Graphics.Color;

namespace Excercise9
{
    public class ValueBar : View
    {
        private readonly Paint paint = new Paint();
        private readonly Color titleColor;
        private List<double> values;
        private string title;

        public List<double> Values
        {
            get => values;
            set
            {
                values = value;
                Invalidate();
            }
        }
        
        public string Title
        {
            get => title;
            set
            {
                title = value; 
                Invalidate();
            }
        }

        protected ValueBar(IntPtr javaReference, JniHandleOwnership transfer) : base(javaReference, transfer)
        {
        }

        public ValueBar(Context context) : this(context,null)
        {
        }

        public ValueBar(Context context, IAttributeSet attrs) : this(context, attrs,0)
        {
        }

        public ValueBar(Context context, IAttributeSet attrs, int defStyleAttr) : this(context, attrs, defStyleAttr,0)
        {
        }

        public ValueBar(Context context, IAttributeSet attrs, int defStyleAttr, int defStyleRes) : base(context, attrs, defStyleAttr, defStyleRes)
        {
            var typedArray = context.ObtainStyledAttributes(attrs, Resource.Styleable.ValueBar);
            title = typedArray.GetString(Resource.Styleable.ValueBar_title);
            titleColor = typedArray.GetColor(Resource.Styleable.ValueBar_titleColor, Color.Azure);
            values = new List<double>() {10, 6, 3, 2, 1};
        }


        public override void Draw(Canvas canvas)
        {
            base.Draw(canvas);
            DrawChart(0, 0, canvas.Width, canvas.Height * 4 / 5, canvas);
            DrawText(0, canvas.Height * 4 / 5, canvas.Width, canvas.Height / 5, canvas);
        }
        
        private void DrawChart(int x, int y, int width, int height, Canvas canvas)
        {
            var widthUnit = width / 10 * 8 / values.Max();
            var random = new Random();
            const int margin = 20;
            const int space = 10;
            var barHeight = (height - space * (values.Count - 1) - margin * 2) / values.Count;
            for (var i = 0; i < values.Count; i++)
            {
                paint.Color = Color.Rgb(random.Next(256), random.Next(256), random.Next(256));
                var left = x + margin;
                var top = y + margin + (barHeight + space) * i;
                var right = x + (float)(values[i] * widthUnit + left);
                var bottom = y + barHeight + top;
                canvas.DrawRect(left, top, right, bottom, paint);
            }
        }

        private void DrawText(int x, int y, int width, int height, Canvas canvas)
        {
            paint.Color = titleColor;
            paint.TextSize = height / 2f;
            paint.TextAlign = Paint.Align.Center;
            var textBound = new Rect();
            paint.GetTextBounds(title, 0, title.Length, textBound);
            canvas.DrawText(title, x + width / 2f, y + height / 2 + textBound.Height() / 2, paint);
        }

    }
}