using System;
using System.ComponentModel;
using System.Linq.Expressions;
using ShoppingList.Core.Utilities;

namespace ShoppingList.Core.Model {
    public class DataObjectBase : INotifyPropertyChanged {
        #region PropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;

        public void RaisePropertyChanged<T>(Expression<Func<T>> selector) {
            if (PropertyChanged != null) {
                PropertyChanged(this, new PropertyChangedEventArgs(PropertyHelper.GetPropertyName(selector)));
            }
        }
        #endregion
    }
}
