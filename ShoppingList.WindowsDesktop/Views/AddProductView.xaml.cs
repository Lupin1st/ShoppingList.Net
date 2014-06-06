using System.Windows;
using System.Windows.Controls;
using Cirrious.MvvmCross.Wpf.Views;
using ShoppingList.Core.Services;
using ShoppingList.Core.ViewModels;

namespace ShoppingList.WindowsDesktop.Views {
    public partial class AddProductView : MvxWpfView {
        public AddProductView() {
            InitializeComponent();
        }

        private void TextBoxName_OnTextChanged(object sender, TextChangedEventArgs e) {
            var viewModel = (AddProductViewModel)DataContext;
            viewModel.Name = ((TextBox)sender).Text;
        }
    }
}
