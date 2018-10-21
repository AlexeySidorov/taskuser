using CoreGraphics;
using UIKit;

namespace Task3.iOS
{
    public sealed class LoadingOverlay : UIView
    {
        readonly UIActivityIndicatorView _activitySpinner;
        readonly UILabel _loadingLabel;

        public LoadingOverlay(CGRect frame, string message) : base(frame)
        {
            BackgroundColor = UIColor.Black;
            Alpha = 0.75f;
            AutoresizingMask = UIViewAutoresizing.All;

            var labelHeight = 22;
            var labelWidth = Frame.Width - 20;
            var centerX = Frame.Width / 2;
            var centerY = Frame.Height / 2;

            _activitySpinner = new UIActivityIndicatorView(UIActivityIndicatorViewStyle.WhiteLarge);
            _activitySpinner.Frame = new CGRect(
                centerX - (_activitySpinner.Frame.Width / 2),
                centerY - _activitySpinner.Frame.Height - 20,
                _activitySpinner.Frame.Width,
                _activitySpinner.Frame.Height);
            _activitySpinner.AutoresizingMask = UIViewAutoresizing.All;
            AddSubview(_activitySpinner);
            _activitySpinner.StartAnimating();

            _loadingLabel = new UILabel(new CGRect(
                centerX - (labelWidth / 2),
                centerY + 20,
                labelWidth,
                labelHeight
            ))
            {
                BackgroundColor = UIColor.Clear,
                TextColor = UIColor.White,
                Text = message,
                TextAlignment = UITextAlignment.Center,
                AutoresizingMask = UIViewAutoresizing.All
            };

            AddSubview(_loadingLabel);
        }

        public void Hide()
        {
            UIView.Animate(
                0.5, 
                () => { Alpha = 0; },
                RemoveFromSuperview
            );
        }
    }
}