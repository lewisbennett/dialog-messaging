using MvvmCross.Binding.BindingContext;
using MvvmCross.Platforms.Ios.Presenters.Attributes;
using MvvmCross.Platforms.Ios.Views;
using Sample.MvvmCross.Core;

namespace Sample.MvvmCross.iOS
{
    [MvxRootPresentation(WrapInNavigationController = true)]
    public partial class MainViewController : MvxViewController<MainViewModel>
    {
        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            Title = "Sample.MvvmCross.iOS";

            // Bind the TouchUpInside event of the buttons to the ViewModel's click commands.
            var bindingSet = this.CreateBindingSet<MainViewController, MainViewModel>();

            bindingSet.Bind(ActionSheetButton).To(viewModel => viewModel.ActionSheetButtonClickCommand);
            bindingSet.Bind(ActionSheetBottomButton).To(viewModel => viewModel.ActionSheetBottomButtonClickCommand);
            bindingSet.Bind(AlertButton).To(viewModel => viewModel.AlertButtonClickCommand);
            bindingSet.Bind(ConfirmButton).To(viewModel => viewModel.ConfirmButtonClickCommand);
            bindingSet.Bind(DeleteButton).To(viewModel => viewModel.DeleteButtonClickCommand);
            bindingSet.Bind(LoadingButton).To(viewModel => viewModel.LoadingButtonClickCommand);
            bindingSet.Bind(LoginButton).To(viewModel => viewModel.LoginButtonClickCommand);
            bindingSet.Bind(PromptButton).To(viewModel => viewModel.PromptButtonClickCommand);
            bindingSet.Bind(SnackbarButton).To(viewModel => viewModel.SnackbarButtonClickCommand);
            bindingSet.Bind(ToastButton).To(viewModel => viewModel.ToastButtonClickCommand);

            bindingSet.Apply();
        }

        public MainViewController()
            : base("Main", null)
        {
        }
    }
}