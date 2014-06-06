using System;
using System.Threading.Tasks;
using Windows.UI.Popups;
using ShoppingList.Core.Localization;
using ShoppingList.Core.Services;

namespace ShoppingList.Windows.Services {
    public class NotificationServiceUnifiedWindows : INotificationService {
        public async Task<QuestionResult> ShowMessageBox(string header, string content) {
            var messageDialog = new MessageDialog(content, header);

            messageDialog.Commands.Add(new UICommand(LocalizationResources.Ok));
            messageDialog.Commands.Add(new UICommand(LocalizationResources.Cancel));

            messageDialog.DefaultCommandIndex = 0;
            messageDialog.CancelCommandIndex = 1;

            try {
                var command = await messageDialog.ShowAsync();
                return command.Label == LocalizationResources.Ok ? QuestionResult.Ok : QuestionResult.Cancel;
            } catch (Exception e) {

                throw;
            }
        }
    }
}
