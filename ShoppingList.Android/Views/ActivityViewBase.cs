
using Android.App;
using Android.OS;
using Cirrious.CrossCore;
using Cirrious.MvvmCross.Droid.Views;
using Cirrious.MvvmCross.Plugins.Messenger;
using ShoppingList.Core;
using ShoppingList.Core.Localization;
using ShoppingList.Core.Messages;
using ShoppingList.Core.Services;
using ShoppingList.Core.ViewModels;

namespace ShoppingList.Android.Views {
    public class ActivityViewBase : MvxActivity {
        public override void OnBackPressed() {
            ((ViewModelBase)DataContext).BackCommand.Execute();
        }

        protected async override void OnSaveInstanceState(Bundle outState) {
            App.SaveState();
            base.OnSaveInstanceState(outState);
        }
    }
}
