using Android.Support.V7.Widget;
using Android.Views;
using MvvmCross.Binding.Droid.BindingContext;
using MvvmCross.Droid.Support.V7.RecyclerView;
using Task3.Droid.Infrastructure.Holders;
using Task3.Droid.Infrastructure.Listeners;

namespace Task3.Droid.Infrastructure.Adapters
{
    public class UserAdapter : MvxRecyclerAdapter, ICustomHolderElementClickListener
    {
        public UserAdapter(IMvxAndroidBindingContext bindingContext) : base(bindingContext)
        {
        }

        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {
            var itemBindingContext = new MvxAndroidBindingContext(parent.Context, BindingContext.LayoutInflaterHolder);
            var itemView = LayoutInflater.From(parent.Context).Inflate(Resource.Layout.item_user, parent, false);
            var holder = new UserHolder(itemView, itemBindingContext);
            holder.SetOnElementClickListener(this);

            return holder;
        }

        public override int GetItemViewType(int position)
        {
            return 0;
        }

        public void OnElementClick(object item)
        {
            if (item == null) return;

            _itemClick?.OnItemClick(item);
        }

        private ICustomItemClickListener _itemClick;

        public void SetOnItemClickListener(ICustomItemClickListener itemClickListener)
        {
            _itemClick = itemClickListener;
        }
    }
}