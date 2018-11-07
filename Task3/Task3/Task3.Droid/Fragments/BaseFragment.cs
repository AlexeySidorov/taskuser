using System;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using Android.OS;
using Android.Support.V7.Widget;
using Android.Views;
using MvvmCross.Binding.Droid.BindingContext;
using MvvmCross.Core.ViewModels;
using MvvmCross.Droid.Support.V4;
using MvvmCross.Droid.Support.V7.AppCompat;
using MvvmCross.Platform;
using MvvmCross.Platform.Droid.Platform;
using Task3.Droid.Infrastructure.Managers;
using Task3.Droid.Infrastructure.Navigates;

namespace Task3.Droid.Fragments
{
    public abstract class BaseFragment : MvxFragment
    {
        private Toolbar _toolbar;

        /// <summary>
        /// Activity
        /// </summary>
        public MvxAppCompatActivity ParentActivity => (MvxAppCompatActivity) Activity;

        /// <summary>
        /// Id layout fragment
        /// </summary>
        protected abstract int FragmentId { get; }


        [SuppressMessage("ReSharper", "SuspiciousTypeConversion.Global")]
        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            // ReSharper disable once UnusedVariable
            var ignore = base.OnCreateView(inflater, container, savedInstanceState);
            var view = this.BindingInflate(FragmentId, null);

            _toolbar = ((INavigationActivity) ParentActivity).Toolbar;

            if (_toolbar != null)
                InitMainButtonToolBar();

            return view;
        }

        private void InitMainButtonToolBar()
        {
            ParentActivity.SetSupportActionBar(_toolbar);
        }

        /// <summary>
        /// Back pressed
        /// </summary>
        [SuppressMessage("ReSharper", "SuspiciousTypeConversion.Global")]
        public virtual void OnBackPressed()
        {
            var fm = ParentActivity.SupportFragmentManager;
            var backPressedListener = fm.Fragments.OfType<IBackPressedListener>().FirstOrDefault();

            if (backPressedListener != null && !backPressedListener.IsBaseBackPressed)
                backPressedListener.OnBackPressed();
            else
                Mvx.Resolve<IMvxAndroidCurrentTopActivity>().Activity.OnBackPressed();
        }

        /// <summary>
        /// ToolBar click
        /// </summary>
        /// <param name="view"></param>
        public virtual void ToolBarClick(View view)
        {
            KeyboardManager.HideKeyboard(ParentActivity, _toolbar);
        }

        private void ToolbarOnClick(object sender, EventArgs eventArgs)
        {
            ToolBarClick(_toolbar);
        }

        /// <summary>
        /// Pause
        /// </summary>
        public override void OnPause()
        {
            KeyboardManager.HideKeyboard(ParentActivity, _toolbar);
            base.OnPause();
            _toolbar.Click -= ToolbarOnClick;
        }

        /// <summary>
        /// Resume
        /// </summary>
        public override void OnResume()
        {
            base.OnResume();
            _toolbar.Click += ToolbarOnClick;
        }

        /// <summary>
        /// Title
        /// </summary>
        /// <param name="title"></param>
        public void SetTitle(string title)
        {
            _toolbar.Title = title;
        }

        /// <summary>
        /// Title
        /// </summary>
        /// <param name="titleId"></param>
        public void SetTitle(int titleId)
        {
            _toolbar.SetTitle(titleId);
        }

        /// <summary>
        /// Показать скрыть тулбар
        /// </summary>
        /// <param name="isVisible"></param>
        public void SetVisibleToolBar(bool isVisible)
        {
            _toolbar.Visibility = isVisible ? ViewStates.Visible : ViewStates.Gone;
        }

        /// <summary>
        /// Кастомная вью
        /// </summary>
        /// <param name="view"></param>
        public void SetToolbarTitleCustomView(View view)
        {
            _toolbar.AddView(view);
        }

        /// <summary>
        /// Кастомная вью
        /// </summary>
        /// <param name="view"></param>
        public void RemoveToolbarTitleCustomView(View view)
        {
            _toolbar.RemoveView(view);
        }
    }

    public abstract class BaseFragment<TViewModel> : BaseFragment where TViewModel : class, IMvxViewModel
    {
        /// <summary>
        /// View model
        /// </summary>
        public new TViewModel ViewModel
        {
            get => (TViewModel) base.ViewModel;
            set => base.ViewModel = value;
        }
    }

    public class ToolbarNavigationClickListner : Java.Lang.Object, View.IOnClickListener
    {
        private readonly Action _backClick;

        public ToolbarNavigationClickListner(Action backClick)
        {
            _backClick = backClick;
        }

        /// <summary>
        /// Обработка клика 
        /// </summary>
        /// <param name="v"></param>
        public void OnClick(View v)
        {
            _backClick?.Invoke();
        }
    }
}