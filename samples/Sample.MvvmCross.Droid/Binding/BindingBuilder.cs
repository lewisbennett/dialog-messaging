using MvvmCross.Platforms.Android.Binding;
using MvvmCross.Platforms.Android.Binding.Binders;

namespace Sample.MvvmCross.Droid.Binding
{
    public class BindingBuilder : MvxAndroidBindingBuilder
    {
        protected override IMvxAndroidViewBinderFactory CreateAndroidViewBinderFactory()
        {
            return new ViewBinderFactory();
        }
    }
}