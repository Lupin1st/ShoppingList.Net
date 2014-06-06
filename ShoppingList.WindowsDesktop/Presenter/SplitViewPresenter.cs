using Cirrious.MvvmCross.ViewModels;
using Cirrious.MvvmCross.Wpf.Views;
using ShoppingList.WindowsDesktop.Views;
using System.Windows;
using System.Windows.Controls;

namespace ShoppingList.WindowsDesktop.Presenter {
    public class SplitViewPresenter : MvxWpfViewPresenter {
        private readonly ContentControl _contentControl;

        public SplitViewPresenter(ContentControl contentControl) {
            _contentControl = contentControl;
        }

        private Window _openDialog;
        private Grid _mainGrid;
        public override void Present(FrameworkElement frameworkElement) {
            if (_mainGrid == null) {
                _mainGrid = new Grid();
                _mainGrid.ColumnDefinitions.Add(new ColumnDefinition());
                _mainGrid.ColumnDefinitions.Add(new ColumnDefinition());

                var grid1 = new Grid();
                grid1.SetValue(Grid.ColumnProperty, 0);

                var grid2 = new Grid();
                grid2.SetValue(Grid.ColumnProperty, 1);

                _mainGrid.Children.Add(grid1);
                _mainGrid.Children.Add(grid2);

                _contentControl.Content = _mainGrid;
            } else {
                _mainGrid = (Grid)_contentControl.Content;
            }

            var leftGrid = (Grid)_mainGrid.Children[0];
            var rightGrid = (Grid)_mainGrid.Children[1];

            if (frameworkElement.GetType() == typeof(ListsView)) {
                leftGrid.Children.Clear();
                leftGrid.Children.Add(frameworkElement);
                if (_openDialog != null) {
                    _openDialog.Close();
                    _openDialog = null;
                }
            }

            if (frameworkElement.GetType() == typeof(ProductsView)) {
                rightGrid.Children.Clear();
                rightGrid.Children.Add(frameworkElement);
                if (_openDialog != null) {
                    _openDialog.Close();
                    _openDialog = null;
                }

            }

            if (frameworkElement.GetType() == typeof(AddProductView)) {
                _openDialog = new Window { Content = frameworkElement, Title = "ShoppingList"};
                _openDialog.Width = frameworkElement.Width + 20;
                _openDialog.Height = frameworkElement.Height + 30;
                _openDialog.Show();
            }
        }

        public override void ChangePresentation(MvxPresentationHint hint) {
            if (hint is MvxClosePresentationHint && _openDialog != null) {
                _openDialog.Close();
                _openDialog = null;
            }

            base.ChangePresentation(hint);
        }
    }
}
