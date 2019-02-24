
namespace Task3.Droid.Infrastructure.Navigates
{
    public interface IBackPressedListener
    {
        /// <summary>
        /// Back pressed
        /// </summary>
        /// <returns></returns>
        void OnBackPressed();

        /// <summary>
        /// Base back pressed
        /// </summary>
        bool IsBaseBackPressed { get; set; }
    }
}