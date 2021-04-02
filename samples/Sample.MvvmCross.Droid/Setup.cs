using MvvmCross.Binding;
using MvvmCross.Platforms.Android.Core;
using Sample.MvvmCross.Droid.Binding;

namespace Sample.MvvmCross.Droid
{
    public class Setup : MvxAndroidSetup<Core.App>
    {
        protected override MvxBindingBuilder CreateBindingBuilder()
        {
            return new BindingBuilder();
        }
    }
}