using Windows.UI.Xaml.Controls;

namespace ShoppingList.Windows.Views {
    public sealed partial class ProductsView : UserControl {
        public ProductsView() {
            this.InitializeComponent();
        }

        private void Selector_OnSelectionChanged(object sender, SelectionChangedEventArgs e) {
            ((ListBox)sender).SelectedItem = null;
        }
    }
}
