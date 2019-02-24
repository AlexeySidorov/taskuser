using System;
using Foundation;
using MvvmCross.Core.ViewModels;
using MvvmCross.iOS.Views;
using UIKit;

namespace Task3.iOS.Views
{
    public abstract class BaseView<TViewModel> : MvxViewController<TViewModel> where TViewModel : class, IMvxViewModel
    {

        /// <summary>
        /// Инициализация 
        /// </summary>
        protected BaseView()
        {
            Initialize();
        }

        /// <summary>
        /// Инициализация 
        /// </summary>
        /// <param name="nibName">Name of the nib.</param>
        /// <param name="bundle">The bundle.</param>
        protected BaseView(string nibName, NSBundle bundle)
            : base(nibName, bundle)
        {
            Initialize();
        }

        /// <summary>
        /// Инициализация 
        /// </summary>
        /// <param name="handle"></param>
        protected BaseView(IntPtr handle) : base(handle)
        {
            Initialize();
        }

        /// <summary>
        /// Инициализация 
        /// </summary>
        private void Initialize()
        {
            EdgesForExtendedLayout = UIRectEdge.None;

            if (HandlesKeyboardNotifications)
            {
                NSNotificationCenter.DefaultCenter.AddObserver(UIKeyboard.WillHideNotification, OnKeyboardNotification);
                NSNotificationCenter.DefaultCenter.AddObserver(UIKeyboard.WillShowNotification, OnKeyboardNotification);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public virtual bool HandlesKeyboardNotifications => false;

        /// <summary>
		/// This is how orientation is setup on iOS 6
		/// </summary>
		public override bool ShouldAutorotate()
        {
            return true;
        }

        /// <summary>
        /// This is how orientation is setup on iOS 6
        /// </summary>
        public override UIInterfaceOrientationMask GetSupportedInterfaceOrientations()
        {
            return UIInterfaceOrientationMask.All;
        }

        private void OnKeyboardNotification(NSNotification notification)
        {
            if (!IsViewLoaded)
                return;

            //Check if the keyboard is becoming visible
            var visible = notification.Name == UIKeyboard.WillShowNotification;

            //Start an animation, using values from the keyboard
            UIView.BeginAnimations("AnimateForKeyboard");
            UIView.SetAnimationBeginsFromCurrentState(true);
            UIView.SetAnimationDuration(UIKeyboard.AnimationDurationFromNotification(notification));
            UIView.SetAnimationCurve((UIViewAnimationCurve)UIKeyboard.AnimationCurveFromNotification(notification));

            //Pass the notification, calculating keyboard height, etc.
            var landscape = InterfaceOrientation == UIInterfaceOrientation.LandscapeLeft || InterfaceOrientation == UIInterfaceOrientation.LandscapeRight;
            if (visible)
            {
                var keyboardFrame = UIKeyboard.FrameEndFromNotification(notification);
                OnKeyboardChanged(true, landscape ? keyboardFrame.Width : keyboardFrame.Height);
            }
            else
            {
                var keyboardFrame = UIKeyboard.FrameBeginFromNotification(notification);
                OnKeyboardChanged(false, landscape ? keyboardFrame.Width : keyboardFrame.Height);
            }

            //Commit the animation
            UIView.CommitAnimations();
        }

        /// <summary>
        /// Override this method to apply custom logic when the keyboard is shown/hidden
        /// </summary>
        /// <param name='visible'>
        /// If the keyboard is visible
        /// </param>
        /// <param name='height'>
        /// Calculated height of the keyboard (width not generally needed here)
        /// </param>
        protected virtual void OnKeyboardChanged(bool visible, nfloat height)
        {

        }
    }
}
