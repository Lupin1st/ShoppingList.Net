using System.Windows;
using System.Windows.Threading;
using Cirrious.CrossCore.IoC;
using Cirrious.MvvmCross.ViewModels;
using Cirrious.MvvmCross.Views;
using Cirrious.MvvmCross.Wpf.Platform;
using Cirrious.MvvmCross.Wpf.Views;
using ShoppingList.Core;


namespace ShoppingList.WindowsDesktop {
    public class Setup
        : MvxWpfSetup {
        public Setup(Dispatcher dispatcher, IMvxWpfViewPresenter presenter)
            : base(dispatcher, presenter) {
            Core.App.Platform = Platform.WindowsDesktop;
        }

        protected override IMvxApplication CreateApp() {
            var viewModelLocator = ((AppContextWindowsDesktop)
                Application.Current.Resources["App"]).Locator;
            return new Core.App(viewModelLocator);
        }

        protected override void InitializeFirstChance() {
            CreatableTypes().EndingWith("ServiceWindowsDesktop")
                .AsInterfaces().RegisterAsLazySingleton();
            base.InitializeFirstChance();
        }

        protected override void InitializeLastChance() {
            base.InitializeLastChance();
            Core.App.InitializeState();
        }
    }
}
