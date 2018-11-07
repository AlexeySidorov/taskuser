using Android.Support.V4.Widget;
using Android.Support.V7.Widget;

namespace Task3.Droid.Infrastructure.Navigates
{
    public interface INavigationActivity
    {
        /// <summary>
        /// Drawer layout base view
        /// </summary>
        DrawerLayout DrawerLayout { get; set; }

        /// <summary>
        /// Toolbar base view      
        /// </summary>
        Toolbar Toolbar { get; set; }
    }
}