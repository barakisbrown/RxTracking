using System.Windows;
using System.Windows.Controls;
using GalaSoft.MvvmLight.Messaging;

namespace RxTracking.Views
{
    /// <summary>
    /// Description for UserDetails.
    /// </summary>
    public partial class UserDetails
    {
        /// <summary>
        /// Initializes a new instance of the UserDetails class.
        /// </summary>
        public UserDetails()
        {
            InitializeComponent();
            Messenger.Default.Register<NotificationMessage>(this, NotificationMessageRecieved);
        }

        private void passwordBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if (this.DataContext != null)
            {
                {
                    ((dynamic)this.DataContext).Password = ((PasswordBox)sender).Password; 
                }
            }
        }

        private void passwordBox1_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if (this.DataContext != null)
            {
                {
                    ((dynamic)this.DataContext).VerifyPassword = ((PasswordBox)sender).Password; 
                }
            }
        }

        private void NotificationMessageRecieved(NotificationMessage obj)
        {
            if (obj.Notification == "CANCEL")
            {
                Close();
            }
            else if (obj.Notification == "SUBMIT")
            {
                Close();
            }
        }
    }
}