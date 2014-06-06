using Android.App;
using Android.OS;
using ShoppingList.Core.Localization;

namespace ShoppingList.Android.Views {
    [Activity]
    public class ProductsView : ActivityViewBase {
        protected override void OnCreate(Bundle bundle) {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.ProductsView);
            ActionBar.Title = LocalizationResources.Products;
        }
    }
}