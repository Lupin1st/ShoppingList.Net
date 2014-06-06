using Windows.UI.Xaml;
using Cirrious.CrossCore.WeakSubscription;
using Cirrious.MvvmCross.WindowsStore.Views;
using Windows.UI.Xaml.Controls;
using ShoppingList.Core.ViewModels;

namespace ShoppingList.Windows.Views
{
    public sealed partial class MainView : MvxStorePage
    {
        private Flyout _openFlyout = new Flyout();

        public MainView()
        {
            this.InitializeComponent();

            var addProductViewModel = ((AppContextWindowsUnified)
                Application.Current.Resources["App"]).Locator.AddProductViewModel;

            addProductViewModel.BackCommand.WeakSubscribe(
                (sender, args) => FlyoutAddProduct.Hide());
        }
    }
}
