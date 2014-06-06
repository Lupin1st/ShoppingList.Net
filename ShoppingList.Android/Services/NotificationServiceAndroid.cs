using Android.App;
using Cirrious.CrossCore;
using Cirrious.CrossCore.Droid.Platform;
using ShoppingList.Core.Localization;
using ShoppingList.Core.Services;
using System.Threading.Tasks;

namespace ShoppingList.Android.Services {
    public class NotificationServiceAndroid : INotificationService {
        private bool _isLocked = false;
        private QuestionResult _result;

        public Task<QuestionResult> ShowMessageBox(string header, string content) {
            var topActivity = Mvx.Resolve<IMvxAndroidCurrentTopActivity>().Activity;

            _isLocked = true;
            var task = new Task<QuestionResult>(WaitForResult);
            task.Start();

            var builder = new AlertDialog.Builder(topActivity);
            builder.SetTitle(header);
            builder.SetMessage(content);
            builder.SetCancelable(true);
            builder.SetNegativeButton(LocalizationResources.Cancel, delegate {
                _result = QuestionResult.Cancel;
                _isLocked = false;
            });
            builder.SetPositiveButton(LocalizationResources.Ok, delegate {
                _result = QuestionResult.Ok;
                _isLocked = false;
            });
            builder.Show();

            return task;
        }

        private QuestionResult WaitForResult() {
            while (_isLocked) Task.Delay(100);
            _isLocked = false;
            return _result;
        }
    }
}
