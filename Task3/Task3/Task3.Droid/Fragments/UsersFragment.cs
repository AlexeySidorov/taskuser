using MvvmCross.Droid.Views.Attributes;
using Task3.ViewModels;

namespace Task3.Droid.Fragments
{
    [MvxFragmentPresentation(typeof(SplashViewModel), Resource.Id.container, true)]
    public class UsersFragment : BaseFragment<UsersViewModel>
    {
        protected override int FragmentId => Resource.Layout.UsersScreen;
    }
}