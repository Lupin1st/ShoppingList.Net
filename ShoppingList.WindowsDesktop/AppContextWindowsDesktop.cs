using System.ComponentModel;
using Cirrious.CrossCore;
using Cirrious.CrossCore.IoC;
using Cirrious.MvvmCross.Plugins.Messenger;
using Cirrious.MvvmCross.ViewModels;
using ShoppingList.Core;
using ShoppingList.Core.Services;
using ShoppingList.Core.Services.Common;
using ShoppingList.Core.Services.Design;
using ShoppingList.WindowsDesktop.Presenter;
using System.Windows;

namespace ShoppingList.WindowsDesktop {
    public class AppContextWindowsDesktop {
        private bool _setupComplete;
        private Core.App _app;
        private readonly object _lockObject = new object();

        public AppContextWindowsDesktop() {
            if (DesignerProperties.GetIsInDesignMode(new DependencyObject()))
                DoDesignSetup();
        }

        public void DoDesignSetup() {
            if (_app == null) {
                LoadMvxAssemblyResources();
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

        public void DoSetup() {
            lock (_lockObject) {
                if (_setupComplete) return;
                _setupComplete = true;
            }

            LoadMvxAssemblyResources();
            Locator = new ViewModelLocator();
            var presenter = new SplitViewPresenter(Application.Current.MainWindow);
            var setup = new Setup(Application.Current.Dispatcher, presenter);
            setup.Initialize();

            var start = Mvx.Resolve<IMvxAppStart>();
            start.Start();
        }

        private static void LoadMvxAssemblyResources() {
            for (var i = 0; ; i++) {
                string key = "MvxAssemblyImport" + i;
                var data = Application.Current.TryFindResource(key);
                if (data == null)
                    return;
            }
        }

        public ViewModelLocator Locator { get; private set; }
    }
}
