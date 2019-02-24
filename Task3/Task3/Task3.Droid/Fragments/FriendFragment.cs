using Android.Graphics;
using Android.OS;
using Android.Support.V7.Content.Res;
using Android.Support.V7.Widget;
using Android.Views;
using MvvmCross.Binding.Droid.BindingContext;
using MvvmCross.Droid.Support.V7.RecyclerView;
using MvvmCross.Droid.Views.Attributes;
using Task3.Domain.Models;
using Task3.Droid.Infrastructure.Adapters;
using Task3.Droid.Infrastructure.Listeners;
using Task3.ViewModels;

namespace Task3.Droid.Fragments
{
    [MvxFragmentPresentation(typeof(SplashViewModel), Resource.Id.container, true)]
    public class FriendsFragment : BaseFragment<FriendViewModel>, ICustomItemClickListener
    {
        private MvxRecyclerView _recycleView;
        private View _circleView;
        protected override int FragmentId => Resource.Layout.FriendsScreen;

        /// <summary>
        /// View Created
        /// </summary>
        /// <param name="container"></param>
        /// <param name="savedInstanceState"></param>
        /// <param name="inflater"></param>
        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            var view = base.OnCreateView(inflater, container, savedInstanceState);
            InitViews(view);
            SetTitle("Friend");
            InitData();

            return view;
        }

        private void InitViews(View view)
        {
            _recycleView = view.FindViewById<MvxRecyclerView>(Resource.Id.friend_list);
            _circleView = view.FindViewById<View>(Resource.Id.circle);
        }

        private void InitData()
        {
            var adapter = new UserAdapter((IMvxAndroidBindingContext)BindingContext);
            adapter.SetOnItemClickListener(this);
            _recycleView.SetLayoutManager(new LinearLayoutManager(Activity));
            _recycleView.HasFixedSize = true;
            _recycleView.SetAdapter(adapter);

            var drawable = AppCompatResources.GetDrawable(Activity, Resource.Drawable.circle_drawable);
            if (drawable != null)
            {
                drawable.SetColorFilter(GetColor(ViewModel.StatusColor), PorterDuff.Mode.SrcAtop);
                _circleView.Background = drawable;
            }
        }

        public void OnItemClick(object item)
        {
            ViewModel?.SelectUserСommand.Execute(item);
        }

        private Color GetColor(ColorType color)
        {
            switch (color)
            {
                case ColorType.Blue:
                    return Color.Blue;
                case ColorType.Brown:
                    return Color.Brown;
                case ColorType.Green:
                    return Color.Green;

                default: return Color.Transparent;
            }
        }
    }
}