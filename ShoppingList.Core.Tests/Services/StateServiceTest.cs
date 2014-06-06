using ShoppingList.Core.Model;
using ShoppingList.Core.Services;
using System.Collections.ObjectModel;

namespace ShoppingList.Core.Tests.Services
{
    class StateServiceTest : IStateService
    {
        private readonly DataList _selectedList;

        public ObservableCollection<DataList> Lists {
            get { return new ObservableCollection<DataList>(); }
            set { }
        }

        public DataList SelectedList {
            get { return _selectedList; }
            set { }
        }

        public void Restore() {
            /* no action here */
        }

        public void Store() {
            /* no action here */
        }

        public StateServiceTest() {
            Lists = new ObservableCollection<DataList>();
            _selectedList = new DataList { Products = new ObservableCollection<DataProduct>() };
            Lists.Add(_selectedList);
        }
    }
}
