using Android.Content;
using Android.Graphics;
using Android.Util;
using Android.Views;

namespace Task3.Droid.Controls
{
    public class CircularProgressBar : View
    {
        private int _mDuration;
        private int _mProgress;
        private readonly Paint _mPaint = new Paint();
        private readonly RectF _mRectF = new RectF();
        private Color _mBackgroundColor;
        private Color _mPrimaryColor;
        private float _mStrokeWidth;

        private IOnProgressChangeListener _mOnChangeListener;

        public interface IOnProgressChangeListener
        {
            void OnChange(int duration, int progress, float rate);
        }

        public void SetOnProgressChangeListener(IOnProgressChangeListener l)
        {
            _mOnChangeListener = l;
        }

        public CircularProgressBar(Context context) : base(context)
        {
        }

        public CircularProgressBar(Context context, IAttributeSet attrs) : base(context, attrs)
        {
        }

        public void SetMax(int max)
        {
            if (max < 0)
                max = 0;

            _mDuration = max;
        }

        public int GetMax()
        {
            return _mDuration;
        }

        public void SetProgress(int progress)
        {
            if (progress > _mDuration)
            {
                progress = _mDuration;
            }

            _mProgress = progress;
            _mOnChangeListener?.OnChange(_mDuration, progress, GetRateOfProgress());

            Invalidate();
        }

        public int GetProgress()
        {
            return _mProgress;
        }

        public void setBackgroundColor(Color color)
        {
            _mBackgroundColor = color;
        }

        public void SetPrimaryColor(Color color)
        {
            _mPrimaryColor = color;
        }

        public void SetCircleWidth(float width)
        {
            _mStrokeWidth = width;
        }

        protected override void OnDraw(Canvas canvas)
        {
            base.OnDraw(canvas);
            var halfWidth = Width / 2;
            var halfHeight = Height / 2;
            var radius = halfWidth < halfHeight ? halfWidth : halfHeight;
            var halfStrokeWidth = _mStrokeWidth / 2;

            _mPaint.Color = _mBackgroundColor;
            _mPaint.Dither = true;
            _mPaint.Flags = PaintFlags.AntiAlias;
            _mPaint.AntiAlias = true;
            _mPaint.StrokeWidth = _mStrokeWidth;
            _mPaint.SetStyle(Paint.Style.Stroke);
            canvas.DrawCircle(halfWidth, halfHeight, radius - halfStrokeWidth, _mPaint);

            _mPaint.Color = _mPrimaryColor;
            _mRectF.Top = halfHeight - radius + halfStrokeWidth;
            _mRectF.Bottom = halfHeight + radius - halfStrokeWidth;
            _mRectF.Left = halfWidth - radius + halfStrokeWidth;
            _mRectF.Right = halfWidth + radius - halfStrokeWidth;
            canvas.DrawArc(_mRectF, -90, GetRateOfProgress() * 360, false, _mPaint);
            canvas.Save();
        }

        private float GetRateOfProgress()
        {
            return (float)_mProgress / _mDuration;
        }
    }
}