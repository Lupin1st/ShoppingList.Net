using Cirrious.MvvmCross.Plugins.Messenger;
using Cirrious.MvvmCross.ViewModels;
using ShoppingList.Core.Localization;
using ShoppingList.Core.Messages;
using ShoppingList.Core.Model;
using ShoppingList.Core.Services;
using ShoppingList.Core.Utilities;
using System.Collections.Specialized;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppingList.Core.ViewModels {
    public class ProductsViewModel : ViewModelBase {

        #region Private members

        private readonly MvxSubscriptionToken _selectedListChangedToken;

        private readonly IMvxMessenger _messenger;
        private readonly IStateService _stateService;
        private readonly INotificationService _notificationService;
        private DataList _list;


        #endregion

        #region Properties

        public DataList List {
            get {
                return _list;

            }
            set {
                _list = value;

                RaisePropertyChanged(() => List);

                if (_list != null)
                    _list.Products.CollectionChanged += ProductsOnCollectionChanged;
            }
        }

        #endregion

        #region Commands and Actions

public MvxCommand AddProductCommand { get; private set; }
private void AddProductAction() {
    ShowViewModel<AddProductViewModel>();
}

public AsyncCommand CleanupCommand { get; private set; }
private async Task CleanupAction(object parameter) {
    var result = await _notificationService.ShowMessageBox(
        LocalizationResources.DeleteBought,
        LocalizationResources.CleanupMessageBody);

    if (result == QuestionResult.Ok) {
        var productsToDelete = List.Products.Where(
            product => product.Bought).ToArray();

        Dispatcher.RequestMainThreadAction(() => {
            foreach (var product in productsToDelete) {
                List.Products.Remove(product);
            }
        });
    }
}

protected override void BackAction() {
    _messenger.Publish(new SelectedListChangedMessage(this, null));
    Close(this);
}

        #endregion

        #region Message handlers

        private void SelectedListChangedMessageAction(SelectedListChangedMessage message) {
            List = message.List;
        }

        #endregion

        public ProductsViewModel(IMvxMessenger messenger, IStateService stateService, INotificationService notificationService)
        {
            _messenger = messenger;
            _stateService = stateService;
            _notificationService = notificationService;

            AddProductCommand = new MvxCommand(AddProductAction);
            CleanupCommand = new AsyncCommand(CleanupAction, () => { /* no action  */ });

            _selectedListChangedToken = _messenger.SubscribeOnMainThread<
                SelectedListChangedMessage>(SelectedListChangedMessageAction);

            List = _stateService.SelectedList;
        }

        private void ProductsOnCollectionChanged(object sender,
            NotifyCollectionChangedEventArgs notifyCollectionChangedEventArgs) {
            AddProductCommand.RaiseCanExecuteChanged();
        }
    }
}
