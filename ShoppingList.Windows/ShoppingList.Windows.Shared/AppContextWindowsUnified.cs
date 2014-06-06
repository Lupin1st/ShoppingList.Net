using Windows.ApplicationModel;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Cirrious.CrossCore;
using Cirrious.CrossCore.IoC;
using Cirrious.MvvmCross.Plugins.Messenger;
using Cirrious.MvvmCross.ViewModels;
using ShoppingList.Core;
using ShoppingList.Core.Services;
using ShoppingList.Core.Services.Common;
using ShoppingList.Core.Services.Design;


namespace ShoppingList.Windows {
    public class AppContextWindowsUnified {
        private bool _setupComplete;
        private Core.App _app;
        private readonly object _lockObject = new object();

        public AppContextWindowsUnified() {
            if (DesignMode.DesignModeEnabled)
                DoDesignSetup();
        }

        public void DoDesignSetup() {
            if (_app == null) {
                MvxSimpleIoCContainer.Initialize();

                Mvx.RegisterSingleton<INotificationService>(
                    new NotificationServiceDesign());
                Mvx.RegisterSingleton<IMvxMessenger>(
                    new MvxMessengerHub());

                Locator = new ViewModelLocator();
                _app = new Core.App(Locator);
                _app.Initialize();

                var stateService = new StateService();
                Mvx.RegisterSingleton<IStateService>(stateService);
                stateService.Restore();
            }
        }

        public void DoSetup(Frame rootFrame) {
            lock (_lockObject) {
                if (_setupComplete) return;
                _setupComplete = true;
            }
            Locator = new ViewModelLocator();
            var setup = new Setup(rootFrame);
            setup.Initialize();

            var start = Mvx.Resolve<IMvxAppStart>();
            start.Start();
        }

        public ViewModelLocator Locator { get; private set; }
    }
}
