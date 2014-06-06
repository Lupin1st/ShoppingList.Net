

using ShoppingList.Core.Model;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace ShoppingList.Core.Services {
    public interface IStateService {
        ObservableCollection<DataList> Lists { get; set; }
        DataList SelectedList { get; set; }

        void Store();
        void Restore();
    }
}
