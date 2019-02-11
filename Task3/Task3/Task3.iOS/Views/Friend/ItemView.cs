using UIKit;

namespace Task3.iOS.Views.Friend
{
    public sealed class ItemView : UIView
    {
        private UILabel _title;
        private UILabel _label;

        public ItemView()
        {
            TranslatesAutoresizingMaskIntoConstraints = false;
            InitView();
            ConstraintUpdate();
        }

        private void InitView()
        {
            _title = new UILabel
            {
                TranslatesAutoresizingMaskIntoConstraints = false,
                TextColor = UIColor.LightGray,
                Font = UIFont.SystemFontOfSize(12, UIFontWeight.Medium)
            };

            _title.Text = "Master tapok";

            _label = new UILabel
            {
                TranslatesAutoresizingMaskIntoConstraints = false,
                TextColor = UIColor.Black,
                Font = UIFont.SystemFontOfSize(15, UIFontWeight.Medium)
            };

            _label.Text = "Second ";

            AddSubviews(_title, _label);
        }

        private void ConstraintUpdate()
        {
            _title.TopAnchor.ConstraintEqualTo(TopAnchor, 5).Active = true;
            _title.LeadingAnchor.ConstraintEqualTo(LeadingAnchor, 0).Active = true;
            _title.TrailingAnchor.ConstraintEqualTo(TrailingAnchor, 0).Active = true;

            _label.TopAnchor.ConstraintEqualTo(_title.BottomAnchor, 2).Active = true;
            _label.LeadingAnchor.ConstraintEqualTo(LeadingAnchor, 0).Active = true;
            _label.TrailingAnchor.ConstraintEqualTo(TrailingAnchor, 0).Active = true;
        }

        public void SetLabelCountLine(int count)
        {
            _label.LineBreakMode = UILineBreakMode.WordWrap;
            _label.Lines = count;
        }
    }
}