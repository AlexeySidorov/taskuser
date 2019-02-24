using System;
using Android.Runtime;
using Android.Support.V7.Widget;
using Android.Views;
using MvvmCross.Binding.BindingContext;
using MvvmCross.Binding.Droid.BindingContext;
using MvvmCross.Droid.Support.V7.RecyclerView;
using Task3.Domain.Models;
using Task3.Droid.Infrastructure.Converters;
using Task3.Droid.Infrastructure.Listeners;

namespace Task3.Droid.Infrastructure.Holders
{
    public class UserHolder : MvxRecyclerViewHolder, View.IOnClickListener
    {
        private ICustomHolderElementClickListener _itemClick;

        public UserHolder(IntPtr javaReference, JniHandleOwnership transfer) : base(javaReference, transfer)
        {
        }

        public UserHolder(View itemView, IMvxAndroidBindingContext context) : base(itemView, context)
        {
            var userName = itemView.FindViewById<AppCompatTextView>(Resource.Id.name_user);
            var email = itemView.FindViewById<AppCompatTextView>(Resource.Id.email_user);
            var status = itemView.FindViewById<AppCompatImageView>(Resource.Id.icon_status_user);

            itemView.SetOnClickListener(this);

            this.DelayBind(() =>
            {
                var set = this.CreateBindingSet<UserHolder, User>();
                set.Bind(userName).To(x => x.Name);
                set.Bind(email).To(x => x.Email);
                set.Bind(status).To(x => x.IsActive).For("DrawableId").WithConversion(new UserStatusConvertor());
                set.Apply();
            });
        }

        public void SetOnElementClickListener(ICustomHolderElementClickListener elementClickListener)
        {
            _itemClick = elementClickListener;
        }

        public void OnClick(View v)
        {
            _itemClick?.OnElementClick(DataContext);
        }
    }
}