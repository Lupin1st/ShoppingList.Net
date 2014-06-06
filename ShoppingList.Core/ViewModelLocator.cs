using Cirrious.CrossCore;
using Cirrious.MvvmCross.Plugins.Messenger;
using Cirrious.MvvmCross.ViewModels;
using ShoppingList.Core.Services;
using ShoppingList.Core.ViewModels;
using System;

namespace ShoppingList.Core {
    public class ViewModelLocator : MvxDefaultViewModelLocator {
        private ListsViewModel _listsViewModel;
        public ListsViewModel ListsViewModel {
            get {
                if (_listsViewModel == null) {
                    var messenger = Mvx.Resolve<IMvxMessenger>();
                    var stateService = Mvx.Resolve<IStateService>();
                    _listsViewModel = new ListsViewModel(messenger, stateService);
                }
                return _listsViewModel;
            }
        }

        private ProductsViewModel _productsViewModel;
        public ProductsViewModel ProductsViewModel {
            get {
                if(_productsViewModel == null) {
                    var messenger = Mvx.Resolve<IMvxMessenger>();
                    var stateService = Mvx.Resolve<IStateService>();
                    var notificationService = Mvx.Resolve<INotificationService>();
                    _productsViewModel = new ProductsViewModel(messenger, stateService, notificationService);
                }
                return _productsViewModel;
            }
        }

        private AddProductViewModel _addProductViewModel;
        public AddProductViewModel AddProductViewModel {
            get {
                if (_addProductViewModel == null) {
                    var messenger = Mvx.Resolve<IMvxMessenger>();
                    var stateService = Mvx.Resolve<IStateService>();
                    _addProductViewModel = new AddProductViewModel(messenger, stateService);
                }
                return _addProductViewModel;
            }
        }


        public override bool TryLoad(Type viewModelType,
            IMvxBundle parameterValues, IMvxBundle savedState,
            out IMvxViewModel model) {
            if (viewModelType == typeof(ListsViewModel)) {
                model = ListsViewModel;
                return true;
            } else if (viewModelType == typeof(ProductsViewModel)) {
                model = ProductsViewModel;
                return true;
            } else if (viewModelType == typeof(AddProductViewModel)) {
                model = AddProductViewModel;
                return true;
            }

            return base.TryLoad(viewModelType, parameterValues, savedState, out model);
        }
    }

}
