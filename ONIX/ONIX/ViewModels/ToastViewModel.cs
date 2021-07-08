using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using ToastNotifications;
using ToastNotifications.Core;
using ToastNotifications.Lifetime;
using ToastNotifications.Lifetime.Clear;
using ToastNotifications.Messages;
using ToastNotifications.Position;

namespace ONIX.ViewModels
{
    class ToastViewModel : INotifyPropertyChanged
    {
        private readonly Notifier MessageNotifier;

        public ToastViewModel()
        {
            MessageNotifier = new Notifier(cfg =>
            {
                cfg.PositionProvider = new PrimaryScreenPositionProvider(
                    corner: Corner.BottomRight,
                    offsetX: 0,
                    offsetY: 0);

                cfg.LifetimeSupervisor = new TimeAndCountBasedLifetimeSupervisor(
                    notificationLifetime: TimeSpan.FromSeconds(5),
                    maximumNotificationCount: MaximumNotificationCount.FromCount(10));

                cfg.Dispatcher = Application.Current.Dispatcher;

                cfg.DisplayOptions.TopMost = false;
            });

            MessageNotifier.ClearMessages(new ClearAll());
        }

        public void OnUnloaded()
        {
            MessageNotifier.Dispose();
        }

        public void ShowInformation(string message)
        {
            MessageNotifier.ShowInformation(message);
        }

        public void ShowSuccess(string message)
        {
            MessageNotifier.ShowSuccess(message);
        }

        internal void ClearMessages(string msg)
        {
            MessageNotifier.ClearMessages(new ClearByMessage(msg));
        }

        public void ShowError(string message)
        {
            MessageNotifier.ShowError(message);
        }


        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName = null)
        {
            var handler = PropertyChanged;
            if (handler != null)
                handler.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public void ClearAll()
        {
            MessageNotifier.ClearMessages(new ClearAll());
        }
    }
}
