using System;
using Android.Content;
using Android.Graphics;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Java.Util;

namespace Exercise10
{
    public class Clock : View
    {
        private readonly Paint paint = new Paint();

        private const int BorderThin = 20;
        private const int HourNeedleThin = 15;
        private const int MinuteNeedleThin = 10;
        private const int SecondNeedleThin = 5;
        private const int HourDividerThin = 5;
        private const int MinuteDividerThin = 2;

        private const int HourDividerLength = 50;
        private const int MinuteDividerLength = 20;

        private const int CenterCircleRadius = 20;

        private const int Hour = 12;
        private const int Minute = 60;
        private const int TextSize = 60;

        private int valueType;
        private Color borderColor, needleColor;
        private int currentHour, currentMinute, currentSecond;

        public Color BorderColor
        {
            get => borderColor;
            set
            {
                borderColor = value;
                Invalidate();
            }
        }

        public Color NeedleColor
        {
            get => needleColor;
            set
            {
                needleColor = value; 
                Invalidate();
            }
        }
        
        protected Clock(IntPtr javaReference, JniHandleOwnership transfer) : base(javaReference, transfer)
        {
        }

        public Clock(Context context) : this(context, null)
        {
        }

        public Clock(Context context, IAttributeSet attrs) : this(context, attrs, 0)
        {
        }

        public Clock(Context context, IAttributeSet attrs, int defStyleAttr) : this(context, attrs, defStyleAttr, 0)
        {
        }

        public Clock(Context context, IAttributeSet attrs, int defStyleAttr, int defStyleRes) : base(context, attrs, defStyleAttr, defStyleRes)
        {
            var typedArray = context.ObtainStyledAttributes(attrs, Resource.Styleable.Clock);
            borderColor = typedArray.GetColor(Resource.Styleable.Clock_border_color, Color.Azure);
            needleColor = typedArray.GetColor(Resource.Styleable.Clock_needle_color, Color.Gray);
            UpdateClock();
            valueType = Hour;
        }

        public override void Draw(Canvas canvas)
        {
            base.Draw(canvas);
            var xCenter = canvas.Width/2;
            var yCenter = canvas.Height/2;
            var radius = Math.Min(xCenter, yCenter) - BorderThin/2;
            paint.Flags = PaintFlags.AntiAlias;
            UpdateClock();

            // draw hour needle
            DrawNeedle(xCenter, yCenter, (int) (radius * 0.45), currentHour, Hour, Color.Black, HourNeedleThin, canvas);

            // draw munite needle
            DrawNeedle(xCenter, yCenter, (int) (radius * 0.55), currentMinute, Minute, Color.Black, MinuteNeedleThin, canvas);

            // draw second needle
            DrawNeedle(xCenter, yCenter, (int) (radius * 0.6), currentSecond, Minute, Color.Black, SecondNeedleThin, canvas);

            // draw hour number
            DrawHourNumbers(xCenter, yCenter, (int)(radius * 0.75), Color.Black, TextSize, canvas);

            // draw hour divider
            DrawDivider(xCenter, yCenter, radius, Hour, Color.Black, HourDividerThin, HourDividerLength, canvas);
            
            // draw minute divider
            DrawDivider(xCenter, yCenter, radius, Minute, Color.Black, MinuteDividerThin, MinuteDividerLength, canvas);

            // draw center circle
            DrawCenterCircle(xCenter, yCenter, CenterCircleRadius, Color.Black, canvas);

            // draw outer circle 
            DrawCircle(xCenter, yCenter, radius, borderColor, BorderThin, canvas);
        }

        public void UpdateClock()
        {
            var now = Calendar.GetInstance(Locale.Default);
            currentHour = now.Get(CalendarField.HourOfDay);
            currentMinute = now.Get(CalendarField.Minute);
            currentSecond = now.Get(CalendarField.Second);
        }

        private void DrawHourNumbers(int xCenter, int yCenter, int radius, Color color, int size, Canvas canvas)
        {
            paint.Color = color;
            paint.TextSize = size;
            paint.StrokeWidth = 5;
            paint.TextAlign = Paint.Align.Center;
            valueType = Hour;
            for (var i = 1; i <= 12; i++)
            {
                canvas.DrawText(i + "", GetX(xCenter, radius, i), GetY(yCenter, radius, i) + size / 2f, paint);
            }
        }

        private void DrawCircle(int xCenter, int yCenter, int radius, Color color, int thin, Canvas canvas)
        {
            paint.SetStyle(Paint.Style.Stroke);
            paint.StrokeWidth = thin;
            paint.Color = color;
            canvas.DrawCircle(xCenter, yCenter, radius, paint);
        }

        private void DrawCenterCircle(int xCenter, int yCenter, int radius, Color color, Canvas canvas)
        {
            paint.Color = color;
            paint.SetStyle(Paint.Style.Fill);
            canvas.DrawCircle(xCenter,yCenter,radius,paint);
        }

        private void DrawDivider(int xCenter, int yCenter, int radius, int type, Color color, int thin, int length, Canvas canvas)
        {
            paint.Color = color;
            paint.StrokeWidth = thin;
            valueType = type;
            for (var i = 0; i < type; i++)
            {
                var rStart = radius - BorderThin / 2;
                var rEnd = rStart - length;
                canvas.DrawLine(
                    GetX(xCenter, rStart, i),
                    GetY(yCenter, rStart, i),
                    GetX(xCenter, rEnd, i),
                    GetY(yCenter, rEnd, i),
                    paint);
            }
        }

        private void DrawNeedle(int xCenter, int yCenter, int length, int value, int type, Color color, int thin, Canvas canvas)
        {
            paint.Color = color;
            paint.StrokeWidth = thin;
            valueType = type;
            canvas.DrawLine(xCenter, yCenter, GetX(xCenter, length, value), GetY(yCenter, length, value), paint);
        }

        private float GetY(int yCenter, int r, int value) =>
            (float) (yCenter - Math.Cos(value * 2 * Math.PI / valueType) * r);

        private float GetX(int xCenter, int r, int value) =>
            (float) (xCenter + Math.Sin(value * 2 * Math.PI / valueType) * r);
    }
}