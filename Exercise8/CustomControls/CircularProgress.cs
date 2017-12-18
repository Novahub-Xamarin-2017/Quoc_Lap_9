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

            paint.Color = hightlightColor;
            paint.Flags = PaintFlags.AntiAlias;
            paint.SetStyle(Paint.Style.Stroke);
            paint.StrokeWidth = Thin;
            canvas.DrawCircle(halfWidth, halfHeight, Math.Min(halfWidth, halfHeight)- Thin, paint);

            paint.Color = normalColor;
            var size = Math.Min(canvas.Width, canvas.Height) - 2*Thin;
            var x = (halfWidth > halfHeight ? halfWidth - halfHeight: 0) + Thin;
            var y = (halfWidth > halfHeight ? 0 : halfHeight - halfWidth) + Thin;
            canvas.DrawArc(x, y, x+ size, y+ size,270, (float) 360*(100-value)/100, false, paint );

            paint.Color = hightlightColor;
            paint.TextSize = size/2.5f;
            paint.SetStyle(Paint.Style.Fill);
            var textBound = new Rect();
            paint.GetTextBounds(value + "%",0,value.ToString().Length+1,textBound);
            canvas.DrawText(value+ "%",halfWidth - textBound.Width()/2f,halfHeight + textBound.Height()/2f,paint);
        }

    }

}