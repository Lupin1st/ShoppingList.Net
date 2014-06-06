using Android.App;
using Android.OS;
using ShoppingList.Core;
using ShoppingList.Core.Localization;

namespace ShoppingList.Android.Views {
    [Activity]
    public class ListsView : ActivityViewBase {
        protected override void OnCreate(Bundle bundle) {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.ListsView);
            ActionBar.Title = LocalizationResources.Lists;
        }

        protected override void OnSaveInstanceState(Bundle outState) {
            App.SaveState();
            base.OnSaveInstanceState(outState);
        }
    }
}