using System.Collections.ObjectModel;
using Cirrious.MvvmCross.ViewModels;

namespace ShoppingList.Core.Model {
    public class DataModel : MvxNotifyPropertyChanged {
        public ObservableCollection<DataList> Lists { get; set; }

        public int SelectedListIndex { get; set; }
    }
}
