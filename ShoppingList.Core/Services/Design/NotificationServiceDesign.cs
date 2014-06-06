
using System.Threading.Tasks;

namespace ShoppingList.Core.Services.Design {
    public class NotificationServiceDesign : INotificationService {
        public Task<QuestionResult> ShowMessageBox(string header, string content) {
            return Task.Run(() => QuestionResult.Cancel);
        }
    }
}
