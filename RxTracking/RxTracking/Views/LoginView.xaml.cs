using System.Windows;
using System.Windows.Controls;
using GalaSoft.MvvmLight.Messaging;

namespace RxTracking.Views
{
    /// <summary>
    /// Description for LoginView.
    /// </summary>
    public partial class LoginView
    {
        /// <summary>
        /// Initializes a new instance of the LoginView class.
        /// </summary>
        public LoginView()
        {
            InitializeComponent();
            Messenger.Default.Register<NotificationMessage>(this, NotificationMessageReceived);
        }

        private void NotificationMessageReceived(NotificationMessage obj)
        {
            if (obj.Notification == "Open ContactView")
            {
                Messenger.Default.Unregister<NotificationMessage>("Open ContactView");
                var contact = new ContactView();                
                contact.ShowDialog();
            }
            else if (obj.Notification == "Open OrderView")
            {
                Messenger.Default.Unregister<NotificationMessage>("Open OrderView");
                var orders = new OrderView();
                orders.Show();
            }
        }

        private void passwBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if (this.DataContext != null)
            {
                { ((dynamic)this.DataContext).PASS = ((PasswordBox)sender).Password; }
            }
        }
    }
}