using Android.OS;
using Android.Support.V7.Widget;
using Android.Views;
using MvvmCross.Binding.Droid.BindingContext;
using MvvmCross.Droid.Support.V7.RecyclerView;
using MvvmCross.Droid.Views.Attributes;
using Task3.Droid.Infrastructure.Adapters;
using Task3.Droid.Infrastructure.Listeners;
using Task3.ViewModels;

namespace Task3.Droid.Fragments
{
    [MvxFragmentPresentation(typeof(SplashViewModel), Resource.Id.container, true)]
    public class UsersFragment : BaseFragment<UsersViewModel>, ICustomItemClickListener
    {
        private MvxRecyclerView _recycleView;

        protected override int FragmentId => Resource.Layout.UsersScreen;

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
            SetTitle("Users");
            InitData();

            HasOptionsMenu = true;

            return view;
        }

        private void InitViews(View view)
        {
            _recycleView = view.FindViewById<MvxRecyclerView>(Resource.Id.user_list);
        }

        private void InitData()
        {
            var adapter = new UserAdapter((IMvxAndroidBindingContext)BindingContext);
            adapter.SetOnItemClickListener(this);
            _recycleView.SetLayoutManager(new LinearLayoutManager(Activity));
            _recycleView.HasFixedSize = true;
            _recycleView.SetAdapter(adapter);
        }

        public void OnItemClick(object item)
        {
            ViewModel?.SelectUserСommand.Execute(item);
        }

        public override void OnCreateOptionsMenu(IMenu menu, MenuInflater inflater)
        {
            inflater.Inflate(Resource.Menu.user_fragment_menu, menu);
            base.OnCreateOptionsMenu(menu, inflater);
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            switch (item.ItemId)
            {
                case Resource.Id.refresh_users:
                    {
                        ViewModel.UploadUsesСommand.Execute(null);
                        break;
                    }

                default:
                    return base.OnOptionsItemSelected(item);
            }

            return true;
        }
    }
}