using System.Collections.ObjectModel;

namespace ShoppingList.Core.Model {
    public class DataModel : DataObjectBase {
        public ObservableCollection<DataList> Lists { get; set; }

        public int SelectedListIndex { get; set; }
    }
}
