using Cirrious.MvvmCross.Plugins.Messenger;
using Cirrious.MvvmCross.ViewModels;
using ShoppingList.Core.Messages;
using ShoppingList.Core.Model;
using ShoppingList.Core.Services;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace ShoppingList.Core.ViewModels {
    public class ListsViewModel : ViewModelBase {
        #region Private members

        private MvxSubscriptionToken _listsChangedToken;
        private MvxSubscriptionToken _selectedListChangedToken;

        private readonly IMvxMessenger _messenger;
        private readonly IStateService _stateService;

        private DataList _selectedList;
        private ObservableCollection<DataList> _lists;


        #endregion

        #region Properties

        public ObservableCollection<DataList> Lists {
            get {
                return _lists;
            }
            set {
                if (_lists == value)
                    return;

                _lists = value;
                RaisePropertyChanged(() => Lists);
            }
        }

        public DataList SelectedList {
            get { return _selectedList; }
            set {
                if (_selectedList == value)
                    return;

                _selectedList = value;
                _stateService.SelectedList = _selectedList;
                RaisePropertyChanged(() => SelectedList);

                if (_selectedList != null)
                    ShowViewModel<ProductsViewModel>();
            }
        }

        #endregion

        #region Commands and Actions

        public ICommand SelectedListChangedCommand { get; private set; }
        private void SelectedListChangedAction(DataList list) {
            SelectedList = list;
        }

        #endregion

        #region Message handlers

        private void ListsChangedMessageAction(ListsChangedMessage message) {
            Lists = message.Lists;
        }

        private void SelectedListChangedMessageAction(SelectedListChangedMessage message) {
            SelectedList = message.List;
        }

        #endregion

        public ListsViewModel(IMvxMessenger messenger, IStateService stateService)
        {
            _messenger = messenger;
            _stateService = stateService;

            SelectedListChangedCommand = new MvxCommand<DataList>(SelectedListChangedAction);

            _listsChangedToken = _messenger.SubscribeOnMainThread<ListsChangedMessage>(ListsChangedMessageAction);
            _selectedListChangedToken = _messenger.SubscribeOnMainThread<SelectedListChangedMessage>(SelectedListChangedMessageAction);

            Lists = _stateService.Lists;
            SelectedList = _stateService.SelectedList;
        }
    }
}
