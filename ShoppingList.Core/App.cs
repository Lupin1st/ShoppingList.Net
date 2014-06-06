using System.Dynamic;
using Cirrious.CrossCore;
using Cirrious.CrossCore.IoC;
using Cirrious.MvvmCross.Localization;
using Cirrious.MvvmCross.ViewModels;
using ShoppingList.Core.Services;
using ShoppingList.Core.ViewModels;
using System.Threading.Tasks;

namespace ShoppingList.Core
{
    public enum Platform {Android, WindowsDesktop, Windows}

    public class App : MvxApplication
    {
        public static Platform Platform { get; set; }

        private readonly ViewModelLocator _viewModelLocator;
        public App(ViewModelLocator viewModelLocator)
        {
            _viewModelLocator = viewModelLocator;
        }

        public override void Initialize()
        {
            CreatableTypes()
                .EndingWith("Service")
                .AsInterfaces()
                .RegisterAsLazySingleton();

            RegisterAppStart<ListsViewModel>();
        }

        public static void InitializeState()
        {
            var sateService = Mvx.Resolve<IStateService>();
            sateService.Restore();
        }

        public static void SaveState()
        {
            var sateService = Mvx.Resolve<IStateService>();
            sateService.Store();
        }

        protected override IMvxViewModelLocator CreateDefaultViewModelLocator()
        {
            return _viewModelLocator;
        }
    }
}