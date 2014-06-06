using Android.App;
using Android.OS;
using ShoppingList.Core.Localization;

namespace ShoppingList.Android.Views {
    [Activity]
    public class AddProductView : ActivityViewBase {
        protected override void OnCreate(Bundle bundle) {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.AddProductView);
            ActionBar.Title = LocalizationResources.NewProduct;
        }
    }
}