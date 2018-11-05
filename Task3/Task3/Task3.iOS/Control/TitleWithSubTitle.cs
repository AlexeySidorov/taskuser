using Task3.iOS.Infrastructure.Extensions;
using UIKit;

namespace Task3.iOS.Control
{
    public sealed class TitleWithSubTitle : UIView
    {
        public TitleWithSubTitle()
        {
            TranslatesAutoresizingMaskIntoConstraints = false;
            InitView();
        }

        private void InitView()
        {
            var title = new UILabel
            {
                TranslatesAutoresizingMaskIntoConstraints = false,
                TextColor = UIColor.Clear.FromHex("#8F8E94"),
                Font = UIFont.MonospacedDigitSystemFontOfSize(12, UIFontWeight.Regular)
            };

            var subTitle = new UILabel
            {
                TranslatesAutoresizingMaskIntoConstraints = false,
                TextColor = UIColor.Clear.FromHex("#000000"),
                Font = UIFont.MonospacedDigitSystemFontOfSize(15, UIFontWeight.Regular)
            };

            title.Text = "asdfsdfdsfdfdsfdsfdf";
            subTitle.Text = "asdfsdfdsfdfdsfdsfdf";

            var stackLayout = new UIStackView
            {
                TranslatesAutoresizingMaskIntoConstraints = false,
                Axis = UILayoutConstraintAxis.Vertical,
                Spacing = 4f
            };

            AddSubview(stackLayout);

            stackLayout.AddArrangedSubview(title);
            stackLayout.AddArrangedSubview(subTitle);

            stackLayout.LeftAnchor.ConstraintEqualTo(LeftAnchor).Active = true;
            stackLayout.RightAnchor.ConstraintEqualTo(RightAnchor).Active = true;
            stackLayout.CenterYAnchor.ConstraintEqualTo(CenterYAnchor).Active = true;
        }
    }
}