using System;
using System.ComponentModel;
using System.Windows;

namespace ShoppingList.WindowsDesktop {
    public partial class App : Application {
        protected override void OnActivated(EventArgs e) {
            if (!DesignerProperties.GetIsInDesignMode(new DependencyObject())) {
                ((AppContextWindowsDesktop)Resources["App"]).DoSetup();
            }

            base.OnActivated(e);
        }

        protected override void OnExit(ExitEventArgs e) {
            Core.App.SaveState();
            base.OnExit(e);
        }
    }
}
