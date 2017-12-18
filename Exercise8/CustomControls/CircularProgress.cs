using System;
using Android.Content;
using Android.Graphics;
using Android.Runtime;
using Android.Util;
using Android.Views;

namespace Exercise8.CustomControls
{
    public class CircularProgress : View
    {
        private int value;
        private readonly Color hightlightColor, normalColor;
        private const int Thin = 40;
        private readonly Paint paint = new Paint();

        public int Value
        {
            get => value;
            set
            {
                this.value = value;
                Invalidate();
            }
        }

        protected CircularProgress(IntPtr javaReference, JniHandleOwnership transfer) : base(javaReference, transfer)
        {

        }

        public CircularProgress(Context context) : this(context, null)
        {
        }

        public CircularProgress(Context context, IAttributeSet attrs) : this(context, attrs, 0)
        {
        }

        public CircularProgress(Context context, IAttributeSet attrs, int defStyleAttr) : this(context, attrs,
            defStyleAttr, 0)
        {
        }

        public CircularProgress(Context context, IAttributeSet attrs, int defStyleAttr, int defStyleRes) : base(context,
            attrs, defStyleAttr, defStyleRes)
        {
            var typeArray = context.ObtainStyledAttributes(attrs, Resource.Styleable.CircularProgress);
            value = typeArray.GetInteger(Resource.Styleable.CircularProgress_value,0);
            hightlightColor = typeArray.GetColor(Resource.Styleable.CircularProgress_hightligh_color, Color.Red);
            normalColor = typeArray.GetColor(Resource.Styleable.CircularProgress_normal_color, Color.Azure);
        }

        public override void Draw(Canvas canvas)
        {
            var halfWidth = (float)canvas.Width/2;
            var halfHeight = (float)canvas.Height/2;
            base.Draw(canvas);
            
            paint.Flags = PaintFlags.AntiAlias;
            paint.SetStyle(Paint.Style.Stroke);
            paint.StrokeWidth = Thin;
            DrawArc(halfWidth, halfHeight, normalColor, 100, canvas);
            DrawArc(halfWidth,halfHeight, hightlightColor, value,canvas);

            paint.Color = hightlightColor;
            paint.TextSize = Math.Min(canvas.Width, canvas.Height) / 2.5f;
            paint.SetStyle(Paint.Style.Fill);
            var textBound = new Rect();
            paint.GetTextBounds(value + "%", 0, value.ToString().Length + 1, textBound);
            canvas.DrawText(value+ "%",halfWidth - textBound.Width()/2f,halfHeight + textBound.Height()/2f,paint);
        }

        private void DrawArc(float xCenter, float yCenter, Color color, int mValue, Canvas canvas)
        {
            paint.Color = color;
            var size = Math.Min(canvas.Width, canvas.Height) - 2 * Thin;
            var x = (xCenter > yCenter ? xCenter - yCenter : 0) + Thin;
            var y = (xCenter > yCenter ? 0 : yCenter - xCenter) + Thin;
            var startAngle = 270 > 360 * mValue / 100 ? 270 - 360 * mValue / 100 : 90 + 360 * mValue / 100;
            canvas.DrawArc(x, y, x + size, y + size, startAngle, (float)360 * mValue / 100, false, paint);
        }
    }

}