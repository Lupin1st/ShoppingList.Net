using Windows.UI.Xaml.Controls;
using ShoppingList.Core.ViewModels;

namespace ShoppingList.Windows.Views {
    public sealed partial class AddProductView : UserControl {
        readonly AddProductViewModel _viewModel;

        public AddProductView() {
            this.InitializeComponent();

            _viewModel = DataContext as AddProductViewModel;
        }

        private void TextBoxName_OnTextChanged(object sender, TextChangedEventArgs e)
        {
            _viewModel.Name = ((TextBox) sender).Text;
        }
    }
}
