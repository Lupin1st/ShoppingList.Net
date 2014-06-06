using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cirrious.MvvmCross.Plugins.Messenger;
using ShoppingList.Core.Model;

namespace ShoppingList.Core.Messages {
    public class SelectedListChangedMessage : MvxMessage {
        public DataList List { get; set; }

        public SelectedListChangedMessage(object sender, DataList list)
            : base(sender) {
            List = list;
        }
    }
}
