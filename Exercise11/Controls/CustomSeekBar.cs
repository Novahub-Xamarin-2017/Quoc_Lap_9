using System;
using Android.Content;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;
using Com.Lilarcor.Cheeseknife;

namespace Exercise11.Controls
{
    public class CustomSeekBar : LinearLayout
    {
        [InjectView(Resource.Id.tvValue)] private TextView tvValue;

        [InjectView(Resource.Id.seekbar)] private SeekBar seekBar;

        [InjectOnClick(Resource.Id.btnInc)]
        void IncrementValue(object sender, EventArgs e)
        {
            value += 5;
            UpdateValues();
        }

        [InjectOnClick(Resource.Id.btnDes)]
        void DescrementValue(object sender, EventArgs e)
        {
            value -= 5;
            UpdateValues();
        }

        [InjectOnClick(Resource.Id.btnUpdate)]
        void Update(object sender, EventArgs e)
        {
            UpdateValues();
        }

        private void UpdateValues()
        {
            tvValue.Text = value + "";
            seekBar.SetProgress(value, true);
        }

        private int value;

        public int Value
        {
            get => value;
            set
            {
                this.value = value; 
                Invalidate();
            }
        }

        protected CustomSeekBar(IntPtr javaReference, JniHandleOwnership transfer) : base(javaReference, transfer)
        {
        }

        public CustomSeekBar(Context context) : this(context, null)
        {
        }

        public CustomSeekBar(Context context, IAttributeSet attrs) : this(context, attrs, 0)
        {
        }

        public CustomSeekBar(Context context, IAttributeSet attrs, int defStyleAttr) : this(context, attrs, defStyleAttr, 0)
        {
        }

        public CustomSeekBar(Context context, IAttributeSet attrs, int defStyleAttr, int defStyleRes) : base(context, attrs, defStyleAttr, defStyleRes)
        {
            var inflater = (LayoutInflater) context.GetSystemService(Context.LayoutInflaterService);
            var view = inflater.Inflate(Resource.Layout.custom_seek_bar, this);
            Cheeseknife.Inject(this, view);
            value = 50;
            seekBar.ProgressChanged += (sender, e) => {
                if (!e.FromUser) return;
                value = e.Progress;
                UpdateValues();
            };
        }

    }
}