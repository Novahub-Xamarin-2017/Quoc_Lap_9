using System;
using Android.Content;
using Android.Graphics;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;

namespace Exercise12.Controls
{
    public class CircularImageView : ImageView
    {
        private const int BorderWidth = 25;
        private readonly Paint paint = new Paint();
        private readonly Color bgColor;
        private readonly Color borderColor;

        protected CircularImageView(IntPtr javaReference, JniHandleOwnership transfer) : base(javaReference, transfer)
        {
        }

        public CircularImageView(Context context) : this(context, null)
        {
        }

        public CircularImageView(Context context, IAttributeSet attrs) : this(context, attrs, 0)
        {
        }

        public CircularImageView(Context context, IAttributeSet attrs, int defStyleAttr) : this(context, attrs, defStyleAttr, 0)
        {
        }

        public CircularImageView(Context context, IAttributeSet attrs, int defStyleAttr, int defStyleRes) : base(context, attrs, defStyleAttr, defStyleRes)
        {
            var typedArray = context.ObtainStyledAttributes(attrs, Resource.Styleable.CircularImageView);
            bgColor = typedArray.GetColor(Resource.Styleable.CircularImageView_bg_color, Color.Rgb(240, 240, 240));
            borderColor = typedArray.GetColor(Resource.Styleable.CircularImageView_border_color, Color.White);
        }

        public override void Draw(Canvas canvas)
        {
            base.Draw(canvas);
            var xCenter = canvas.Width / 2;
            var yCenter = canvas.Height / 2;
            var radius = Math.Min(xCenter, yCenter) * 0.9;
            paint.Flags = PaintFlags.AntiAlias;
            DrawBackGround(xCenter, yCenter, radius, bgColor, canvas);
            DrawBorder(xCenter, yCenter, radius, borderColor, BorderWidth, canvas);
        }

        private void DrawBackGround(int xCenter, int yCenter, double radius, Color color, Canvas canvas)
        {
            paint.SetStyle(Paint.Style.Stroke);
            paint.StrokeWidth = (float)((Math.Max(xCenter, yCenter) - radius) * 2);
            paint.Color = color;
            canvas.DrawCircle(xCenter, yCenter, Math.Max(xCenter, yCenter), paint);
        }

        private void DrawBorder(int xCenter, int yCenter, double radius, Color color, int borderWidth, Canvas canvas)
        {
            paint.SetStyle(Paint.Style.Stroke);
            paint.StrokeWidth = borderWidth;
            paint.Color = color;
            SetLayerType(LayerType.Software,paint);
            paint.SetShadowLayer(16f,0f,4f,Color.Black);
            canvas.DrawCircle(xCenter,yCenter,(float) radius,paint);
        }
    }
}