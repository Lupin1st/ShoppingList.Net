using Windows.UI.Xaml.Controls;
using Cirrious.MvvmCross.ViewModels;
using Cirrious.MvvmCross.WindowsStore.Views;
using ShoppingList.Windows.Views;


namespace ShoppingList.Windows.Presenter {
    public class MainViewPresenter : MvxStoreViewPresenter {
        private readonly Frame _rootFrame;

        public MainViewPresenter(Frame rootFrame)
            : base(rootFrame) {
            _rootFrame = rootFrame;
        }

        public override void ChangePresentation(MvxPresentationHint hint) {}

        public override void Close(IMvxViewModel viewModel) {}

        public override void Show(MvxViewModelRequest request) {
            if (_rootFrame.Content == null)
                _rootFrame.Navigate(typeof(MainView), request);
        }
    }
}
