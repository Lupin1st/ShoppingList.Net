
using System.Threading.Tasks;

namespace ShoppingList.Core.Services {
    public enum QuestionResult { Ok, Cancel }

    public interface INotificationService {
        Task<QuestionResult> ShowMessageBox(string header, string content);
    }
}
