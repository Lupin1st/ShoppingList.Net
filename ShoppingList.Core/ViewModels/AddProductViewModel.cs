using Cirrious.MvvmCross.Plugins.Messenger;
using Cirrious.MvvmCross.ViewModels;
using ShoppingList.Core.Messages;
using ShoppingList.Core.Model;
using ShoppingList.Core.Services;

namespace ShoppingList.Core.ViewModels {
    public class AddProductViewModel : ViewModelBase {
        #region Private members

        private MvxSubscriptionToken _selectedListChangedToken;

        private readonly IMvxMessenger _messenger;
        private readonly IStateService _stateService;

        private DataList _list;
        private string _name;
        private string _amount;

        #endregion

        #region Properties

        public DataList List {
            get { return _list; }
            set {
                _list = value;
                RaisePropertyChanged(() => List);
            }
        }

        public string Name {
            get { return _name; }
            set {
                _name = value;
                RaisePropertyChanged(() => Name);
                SaveProductCommand.RaiseCanExecuteChanged();
            }
        }

        public string Amount {
            get { return _amount; }
            set {
                _amount = value;
                RaisePropertyChanged(() => Amount);
            }
        }

        #endregion

        #region Commands and Actions

public MvxCommand SaveProductCommand { get; private set; }
private void SaveProductAction() {
    List.Products.Add(new DataProduct {
        Amount = Amount,
        Name = Name
    });

    Amount = "";
    Name = "";
}

private bool SaveProductCanExecute() {
    return Name != null && Name.Length >= 2;
}

        #endregion

        #region Message handlers

        private void SelectedListChangedMessageAction(
            SelectedListChangedMessage message) {
            List = message.List;
        }

        #endregion

        public AddProductViewModel(IMvxMessenger messenger, IStateService stateService)
        {
            _messenger = messenger;
            _stateService = stateService;

            SaveProductCommand = new MvxCommand(SaveProductAction,
            SaveProductCanExecute);

            _selectedListChangedToken = _messenger.
                SubscribeOnMainThread<SelectedListChangedMessage>(
                SelectedListChangedMessageAction);

            List = _stateService.SelectedList;
        }
    }
}
