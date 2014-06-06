using Cirrious.MvvmCross.Localization;
using Cirrious.MvvmCross.ViewModels;
using Microsoft.VisualBasic;
using ShoppingList.Core.Localization;

namespace ShoppingList.Core.ViewModels {
    public abstract class ViewModelBase : MvxViewModel {
        protected ViewModelBase() {
            BackCommand = new MvxCommand(BackAction);
        }

        public IMvxLanguageBinder TextSource {
            get {
                return new MvxLanguageBinder("", "");
            }
        }

        public MvxCommand BackCommand { get; private set; }
        protected virtual void BackAction() {
            Close(this);
        }
    }
}
