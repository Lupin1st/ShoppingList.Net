using Cirrious.CrossCore;
using Cirrious.CrossCore.Platform;
using Cirrious.MvvmCross.ViewModels;
using Cirrious.MvvmCross.WindowsStore.Platform;
using Cirrious.MvvmCross.WindowsStore.Views;
using ShoppingList.Core;
using ShoppingList.Core.Services;
using ShoppingList.Windows.Presenter;
using ShoppingList.Windows.Services;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace ShoppingList.Windows {
    public class Setup : MvxStoreSetup {
        public Setup(Frame rootFrame)
            : base(rootFrame) {
            Core.App.Platform = Platform.WindowsDesktop;
        }

        protected override IMvxApplication CreateApp() {
            var viewModelLocator = ((AppContextWindowsUnified)
                Application.Current.Resources["App"]).Locator;

            return new Core.App(viewModelLocator);
        }

        protected override IMvxTrace CreateDebugTrace() {
            return new DebugTrace();
        }

        protected override void InitializeFirstChance() {
            Mvx.RegisterSingleton<INotificationService>(
                new NotificationServiceUnifiedWindows());
            base.InitializeFirstChance();
        }

        protected override void InitializeLastChance() {
            base.InitializeLastChance();

            var stateService = Mvx.Resolve<IStateService>();
            stateService.Restore();
        }

        public static void RegisterServicesDesignStatic() {
            Mvx.RegisterSingleton<INotificationService>(
                new NotificationServiceUnifiedWindows());
        }

        public static void RestoreStateDesignStatic() {
            var stateService = Mvx.Resolve<IStateService>();
            stateService.Restore();
        }



#if WINDOWS_APP
        protected override IMvxStoreViewPresenter CreateViewPresenter(Frame rootFrame) {
            return new MainViewPresenter(rootFrame);
        }
#endif
    }
}