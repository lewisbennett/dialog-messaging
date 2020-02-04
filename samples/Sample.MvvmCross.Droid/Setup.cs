using MvvmCross.Binding;
using MvvmCross.Binding.Bindings.Target.Construction;
using MvvmCross.Droid.Support.V7.AppCompat;
using MvvmCross.Platforms.Android.Presenters;
using Sample.MvvmCross.Droid.Binding;

namespace Sample.MvvmCross.Droid
{
    public class Setup : MvxAppCompatSetup<Core.App>
    {
        protected override void FillTargetFactories(IMvxTargetBindingFactoryRegistry registry)
        {
            MvxAppCompatSetupHelper.FillTargetFactories(registry);

            base.FillTargetFactories(registry);
        }

        protected override IMvxAndroidViewPresenter CreateViewPresenter()
        {
            return new MvxAppCompatViewPresenter(AndroidViewAssemblies);
        }

        protected override MvxBindingBuilder CreateBindingBuilder()
        {
            return new BindingBuilder();
        }
    }
}