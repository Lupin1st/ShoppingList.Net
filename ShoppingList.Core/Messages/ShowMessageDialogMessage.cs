
using Cirrious.MvvmCross.Plugins.Messenger;

namespace ShoppingList.Core.Messages {
    public enum MessageDialogToken { CleanupProducts }

    public class ShowMessageDialogMessage : MvxMessage {
        public MessageDialogToken Token { get; private set; }

        public string Header { get; private set; }

        public string Content { get; private set; }

        public ShowMessageDialogMessage(object sender, MessageDialogToken token, string header, string content)
            : base(sender) {
            Token = token;
            Header = header;
            Content = content;
        }
    }
}
