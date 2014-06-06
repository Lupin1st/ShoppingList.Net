using System;
using Cirrious.CrossCore;
using Cirrious.CrossCore.Platform;
using Cirrious.MvvmCross.Plugins.File;
using Cirrious.MvvmCross.Plugins.Messenger;
using Newtonsoft.Json;
using ShoppingList.Core.Messages;
using ShoppingList.Core.Model;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace ShoppingList.Core.Services.Common {
    public class StateService : IStateService {
        private const string StateSavePath = "state.json";
        private DataModel _model;

        public ObservableCollection<DataList> Lists {
            get { return _model != null ? _model.Lists : null; }
            set {
                _model.Lists = value;
                var messenger = Mvx.Resolve<IMvxMessenger>();
                messenger.Publish(new ListsChangedMessage(this, _model.Lists));
            }
        }

        public DataList SelectedList {
            get { return _model != null ? Lists[_model.SelectedListIndex] : null; }
            set {
                _model.SelectedListIndex = Lists.IndexOf(value);
                var messenger = Mvx.Resolve<IMvxMessenger>();
                messenger.Publish(new SelectedListChangedMessage(this, value));
            }
        }

        public void Store() {
            var serializer = Mvx.Resolve<IMvxJsonConverter>();
            var content = serializer.SerializeObject(_model);
            var fileStore = Mvx.Resolve<IMvxFileStore>();
            fileStore.WriteFile(StateSavePath, content);
        }

        public void Restore() {
            try {
                var fileStore = Mvx.Resolve<IMvxFileStore>();
                var content = "";
                var stateOk = fileStore.TryReadTextFile(StateSavePath, out content);

                if (stateOk) {
                    var serializer = Mvx.Resolve<IMvxJsonConverter>();
                    _model = serializer.DeserializeObject<DataModel>(content); // TODO: Try catch ?
                }

                if (_model == null)
                    InitializeFirstTimeUse();
            } catch (Exception) {
                InitializeFirstTimeUse();
            }

            var messenger = Mvx.Resolve<IMvxMessenger>();
            messenger.Publish(new ListsChangedMessage(this, Lists));
            messenger.Publish(new SelectedListChangedMessage(this, SelectedList));
        }


        private void InitializeFirstTimeUse() {
            var list1 = new DataList {
                Name = "Supermarket",
                Products = new ObservableCollection<DataProduct>
                {
                    new DataProduct {Amount = "5", Name = "Apples", Bought = false},
                    new DataProduct {Amount = "6", Name = "Bananas", Bought = true},
                    new DataProduct {Amount = "12", Name = "Oranges", Bought = false},
                }
            };

            var list2 = new DataList {
                Name = "Tools Store",
                Products = new ObservableCollection<DataProduct>
                {
                    new DataProduct {Amount = "1", Name = "Hammer", Bought = false},
                    new DataProduct {Amount = "100", Name = "Nails", Bought = true}
                }
            };

            var list3 = new DataList {
                Name = "Electronics Store",
                Products = new ObservableCollection<DataProduct>
                {
                    new DataProduct {Amount = "1", Name = "Surface Pro", Bought = false},
                    new DataProduct {Amount = "1", Name = "Galaxy S*", Bought = true},
                    new DataProduct {Amount = "2", Name = "Lumia 930", Bought = false},
                }
            };

            var lists = new ObservableCollection<DataList> { list1, list2, list3 };

            _model = new DataModel { Lists = lists, SelectedListIndex = 1 };
        }
    }
}
