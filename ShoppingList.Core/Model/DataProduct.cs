namespace ShoppingList.Core.Model {
    public class DataProduct : DataObjectBase {
        private string _name;
        private string _amount;
        private bool _bought;

        public string Name {
            get { return _name; }
            set {
                _name = value;
                RaisePropertyChanged(() => Name);
            }
        }

        public string Amount {
            get { return _amount; }
            set {
                _amount = value;
                RaisePropertyChanged(() => Amount);
            }
        }

        public bool Bought {
            get { return _bought; }
            set {
                _bought = value;
                RaisePropertyChanged(() => Bought);
            }
        }
    }
}
