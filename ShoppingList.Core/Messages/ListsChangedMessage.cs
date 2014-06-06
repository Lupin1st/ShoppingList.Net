using Cirrious.MvvmCross.Plugins.Messenger;
using ShoppingList.Core.Model;
using System.Collections.ObjectModel;

namespace ShoppingList.Core.Messages {
    public class ListsChangedMessage : MvxMessage {
        public ObservableCollection<DataList> Lists { get; set; }

        public ListsChangedMessage(object sender, ObservableCollection<DataList> lists)
            : base(sender) {
            Lists = lists;
        }
    }
}
