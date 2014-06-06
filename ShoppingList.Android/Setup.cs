using Android.Content;
using Cirrious.CrossCore;
using Cirrious.CrossCore.Converters;
using Cirrious.CrossCore.IoC;
using Cirrious.CrossCore.Platform;
using Cirrious.MvvmCross.Droid.Platform;
using Cirrious.MvvmCross.Localization;
using Cirrious.MvvmCross.ViewModels;
using ShoppingList.Android.Utilities.Test.Core;
using ShoppingList.Core;
using ShoppingList.Core.Localization;

namespace ShoppingList.Android {
    public class Setup : MvxAndroidSetup {
        public Setup(Context applicationContext)
            : base(applicationContext) {
            App.Platform = Platform.Android;
        }

        protected override IMvxApplication CreateApp() {
            return new App(new ViewModelLocator());
        }

        protected override IMvxTrace CreateDebugTrace() {
            return new DebugTrace();
        }

        protected override void InitializeFirstChance() {
            CreatableTypes().EndingWith("ServiceAndroid")
                .AsInterfaces().RegisterAsLazySingleton();

            Mvx.RegisterSingleton<IMvxTextProvider>(
                new ResxTextProvider(LocalizationResources.ResourceManager));

            base.InitializeFirstChance();
        }

        protected override void InitializeLastChance() {
            base.InitializeLastChance();
            App.InitializeState();
        }

        protected override void FillValueConverters(IMvxValueConverterRegistry registry) {
            base.FillValueConverters(registry);
            registry.AddOrOverwrite("Language", new MvxLanguageConverter());
        }
    }
}