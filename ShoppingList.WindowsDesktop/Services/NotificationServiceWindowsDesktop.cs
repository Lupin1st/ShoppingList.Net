using System.Threading.Tasks;
using System.Windows;
using ShoppingList.Core.Services;

namespace ShoppingList.WindowsDesktop.Services {
    public class NotificationServiceWindowsDesktop : INotificationService {

        public Task<QuestionResult> ShowMessageBox(string header, string content) {
            var messageBoxResult = MessageBox.Show(content, header, MessageBoxButton.OKCancel);

            var result = messageBoxResult == MessageBoxResult.OK
                ? QuestionResult.Ok
                : QuestionResult.Cancel;
            var task = new Task<QuestionResult>(() => result);
            task.Start();
            return task;
        }

    }
}
