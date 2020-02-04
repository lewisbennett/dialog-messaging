using MvvmCross.Platforms.Android.Binding.Binders;

namespace Sample.MvvmCross.Droid.Binding
{
    public class ViewBinderFactory : IMvxAndroidViewBinderFactory
    {
        public IMvxAndroidViewBinder Create(object source)
        {
            return new ViewBinder(source);
        }
    }
}