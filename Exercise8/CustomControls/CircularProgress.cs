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
        private int value = 0;

        private const int Thin = 10;
        private readonly Paint paint = new Paint();

        public int Value
        {
            get => value;
            set
            {
                this.value = value;
                this.Invalidate();
            }
        }

        protected CircularProgress(IntPtr javaReference, JniHandleOwnership transfer) : base(javaReference, transfer)
        {

        }

        public CircularProgress(Context context) : base(context, null)
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

        }

        public override void Draw(Canvas canvas)
        {
            var halfWidth = (float)canvas.Width/2;
            var halfHeight = (float)canvas.Height/2;

            base.Draw(canvas);

            paint.Color = Color.Rgb(191, 221, 210);
            paint.Flags = PaintFlags.AntiAlias;
            paint.SetStyle(Paint.Style.Stroke);
            paint.StrokeWidth = Thin;
            canvas.DrawCircle(halfWidth, halfHeight, Math.Min(halfWidth, halfHeight), paint);

            paint.Color = Color.Rgb(3, 150, 75);

            var size = Math.Min(canvas.Width, canvas.Height);
            var x = halfWidth > halfHeight ? halfWidth - halfHeight: 0;
            var y = halfWidth > halfHeight ? 0 : halfHeight - halfWidth;

            canvas.DrawArc(x, y, x+ size, y+ size, 0,(float) (360 * value/100.0), false, paint );
        }
    }

}