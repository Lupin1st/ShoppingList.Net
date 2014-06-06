
using Cirrious.MvvmCross.Plugins.Messenger;
using ShoppingList.Core.Services;

namespace ShoppingList.Core.Messages {
    public class MessageDialogResultMessage : MvxMessage {
        public MessageDialogToken Token { get; private set; }

        public QuestionResult Result { get; private set; }

        public MessageDialogResultMessage(object sender, MessageDialogToken token, QuestionResult result)
            : base(sender) {
            Token = token;
            Result = result;
        }
    }
}
