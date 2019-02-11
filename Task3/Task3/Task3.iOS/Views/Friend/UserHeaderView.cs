using CoreGraphics;
using UIKit;

namespace Task3.iOS.Views.Friend
{
    public sealed class UserHeaderView : UIView
    {
        private ItemView _blockEmail;
        private ItemView _blockPhone;
        private ItemView _blockDate;
        private ItemView _blockAddress;
        private ItemView _blockAbout;
        private UILabel _blockTitleList;
        private ItemView _blockName;
        private ItemView _blockAge;
        private UIView _containerView;
        private UIImageView _img;

        public UserHeaderView()
        {
            InitView();
            ConstraintUpdate();
        }

        private void InitView()
        {
            _containerView = new UIView { TranslatesAutoresizingMaskIntoConstraints = false };
            BackgroundColor = UIColor.Blue;

            _blockName = new ItemView();
            _blockAge = new ItemView();

            _containerView.AddSubviews(_blockName, _blockAge);

            _img = new UIImageView();
            _img.BackgroundColor = UIColor.Green;
            _img.TranslatesAutoresizingMaskIntoConstraints = false;
            _img.Image = UIImage.FromBundle("Banan");
            _img.AutoresizingMask = UIViewAutoresizing.FlexibleTopMargin | UIViewAutoresizing.FlexibleRightMargin;

            _containerView.AddSubview(_img);

            AddSubview(_containerView);

            //_blockDate = new ItemView();
            //AddSubview(_blockDate);

            //_blockEmail = new ItemView();
            //AddSubview(_blockEmail);

            //_blockPhone = new ItemView();
            //AddSubview(_blockPhone);

            //_blockAddress = new ItemView();
            //AddSubview(_blockAddress);

            //_blockAbout = new ItemView();
            //_blockAbout.SetLabelCountLine(0);
            //AddSubview(_blockAbout);

            //_blockTitleList = new UILabel();
            //_blockTitleList.Text = "dsfdsf dsf dsf dsf ds f ds fds ";
            // AddSubview(_blockTitleList);
        }

        private void ConstraintUpdate()
        {
            _containerView.TopAnchor.ConstraintEqualTo(TopAnchor, 5).Active = true;
            _containerView.LeftAnchor.ConstraintEqualTo(LeftAnchor, 0).Active = true;
            _containerView.RightAnchor.ConstraintEqualTo(RightAnchor, 0).Active = true;
            _containerView.HeightAnchor.ConstraintEqualTo(90).Active = true;

            _img.TopAnchor.ConstraintEqualTo(_containerView.TopAnchor, 10).Active = true;
            //NSLayoutConstraint.Create(_img, NSLayoutAttribute.Leading, NSLayoutRelation.Equal, _containerView, NSLayoutAttribute.LeadingMargin, 1.0f, 0.0f).Active = true;
            NSLayoutConstraint.Create(_img, NSLayoutAttribute.Trailing, NSLayoutRelation.Equal, _containerView, NSLayoutAttribute.TrailingMargin, 1.0f, 0.0f).Active = true;
            _img.WidthAnchor.ConstraintEqualTo(90).Active = true;
            _img.HeightAnchor.ConstraintEqualTo(90).Active = true;

            _blockName.TopAnchor.ConstraintEqualTo(_containerView.TopAnchor, 5).Active = true;
            _blockName.LeadingAnchor.ConstraintEqualTo(_containerView.LeadingAnchor, 0).Active = true;
            _blockName.TrailingAnchor.ConstraintEqualTo(_img.LeadingAnchor, -12).Active = true;
            _blockName.HeightAnchor.ConstraintEqualTo(25).Active = true;

            _blockAge.TopAnchor.ConstraintEqualTo(_blockName.BottomAnchor, 30).Active = true;
            _blockAge.LeadingAnchor.ConstraintEqualTo(_containerView.LeadingAnchor, 0).Active = true;
            _blockAge.TrailingAnchor.ConstraintEqualTo(_img.LeadingAnchor, -12).Active = true;
            _blockAge.HeightAnchor.ConstraintEqualTo(25).Active = true;

            //_blockDate.TopAnchor.ConstraintEqualTo(_containerView.BottomAnchor, 30).Active = true;
            //_blockDate.LeadingAnchor.ConstraintEqualTo(LeadingAnchor, 0).Active = true;
            //_blockDate.TrailingAnchor.ConstraintEqualTo(TrailingAnchor, 0).Active = true;
            //_blockDate.HeightAnchor.ConstraintEqualTo(25).Active = true;

            //_blockEmail.TopAnchor.ConstraintEqualTo(_blockDate.BottomAnchor, 30).Active = true;
            //_blockEmail.LeadingAnchor.ConstraintEqualTo(LeadingAnchor, 0).Active = true;
            //_blockEmail.TrailingAnchor.ConstraintEqualTo(TrailingAnchor, 0).Active = true;
            //_blockEmail.HeightAnchor.ConstraintEqualTo(25).Active = true;

            //_blockPhone.TopAnchor.ConstraintEqualTo(_blockEmail.BottomAnchor, 30).Active = true;
            //_blockPhone.LeadingAnchor.ConstraintEqualTo(LeadingAnchor, 0).Active = true;
            //_blockPhone.TrailingAnchor.ConstraintEqualTo(TrailingAnchor, 0).Active = true;
            //_blockPhone.HeightAnchor.ConstraintEqualTo(25).Active = true;

            //_blockAddress.TopAnchor.ConstraintEqualTo(_blockPhone.BottomAnchor, 30).Active = true;
            //_blockAddress.LeadingAnchor.ConstraintEqualTo(LeadingAnchor, 0).Active = true;
            //_blockAddress.TrailingAnchor.ConstraintEqualTo(TrailingAnchor, 0).Active = true;
            //_blockAddress.HeightAnchor.ConstraintEqualTo(25).Active = true;

            //_blockAbout.TopAnchor.ConstraintEqualTo(_blockAddress.BottomAnchor, 30).Active = true;
            //_blockAbout.LeadingAnchor.ConstraintEqualTo(LeadingAnchor, 0).Active = true;
            //_blockAbout.TrailingAnchor.ConstraintEqualTo(TrailingAnchor, 0).Active = true;
        }
    }
}