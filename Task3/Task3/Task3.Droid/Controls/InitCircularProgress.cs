using Android.Content;
using Android.Graphics;
using Android.Util;
using Android.Views;
using Android.Widget;

namespace Task3.Droid.Controls
{
    public class InitCircularProgress : FrameLayout, CircularProgressBar.IOnProgressChangeListener
    {
        private CircularProgressBar _mCircularProgressBar;
        private TextView _mRateText;
        private int _maxValue;

        public InitCircularProgress(Context context) : base(context)
        {
            Init();
        }

        public InitCircularProgress(Context context, IAttributeSet attrs) : base(context, attrs)
        {
            Init();
        }

        private void Init()
        {
            _mCircularProgressBar = new CircularProgressBar(Context);
            AddView(_mCircularProgressBar);

            var lp = new LayoutParams(ViewGroup.LayoutParams.MatchParent, ViewGroup.LayoutParams.MatchParent)
            {
                Gravity = GravityFlags.Center
            };

            _mCircularProgressBar.LayoutParameters = lp;
            _mRateText = new TextView(Context);
            AddView(_mRateText);

            _mRateText.LayoutParameters = lp;
            _mRateText.Gravity = GravityFlags.Center;
            _mCircularProgressBar.SetOnProgressChangeListener(this);
        }

        public void SetMax(int max)
        {
            _mCircularProgressBar.SetMax(max);
            _maxValue = max;
        }

        public void SetProgress(int progress)
        {
            _mCircularProgressBar.SetProgress(progress);
        }

        public CircularProgressBar GetCircularProgressBar()
        {
            return _mCircularProgressBar;
        }

        public void SetTextSize(float size)
        {
            _mRateText.SetTextSize(ComplexUnitType.Dip, size);
        }

        public void SetTextColor(Color color)
        {
            _mRateText.SetTextColor(color);
        }

        public void SetTextTypeFaceBold()
        {
            _mRateText.Typeface = Typeface.DefaultBold;
        }

        public void OnChange(int duration, int progress, float rate)
        {
            _mRateText.Text = ((int) (rate * _maxValue)).ToString();
        }
    }
}