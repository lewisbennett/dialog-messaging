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

            var set = this.CreateBindingSet<MainViewController, MainViewModel>();

            set.Bind(ActionSheetButton).To(viewModel => viewModel.ActionSheetButtonClickCommand);
            set.Bind(ActionSheetBottomButton).To(viewModel => viewModel.ActionSheetBottomButtonClickCommand);
            set.Bind(AlertButton).To(viewModel => viewModel.AlertButtonClickCommand);
            set.Bind(ConfirmButton).To(viewModel => viewModel.ConfirmButtonClickCommand);
            set.Bind(DeleteButton).To(viewModel => viewModel.DeleteButtonClickCommand);
            set.Bind(LoadingButton).To(viewModel => viewModel.LoadingButtonClickCommand);
            set.Bind(PromptButton).To(viewModel => viewModel.PromptButtonClickCommand);
            set.Bind(SnackbarButton).To(viewModel => viewModel.SnackbarButtonClickCommand);
            set.Bind(ToastButton).To(viewModel => viewModel.ToastButtonClickCommand);

            set.Apply();
        }

        public MainViewController ()
            : base ("Main", null)
        {
        }
    }
}