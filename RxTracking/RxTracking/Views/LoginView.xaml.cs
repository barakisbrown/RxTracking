namespace RxTracking.Views
{
    using System.Windows;
    using System.Windows.Controls;
    using GalaSoft.MvvmLight.Messaging;

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

        /// <summary>
        /// This function allows me to open other views from here and to keep the MVVM pattern intact.
        /// Notifications Received
        ///     A. ContactView - Opens the ContactView so that a new user and enters his information
        ///     B. OrderView --> Opens the main app which is the Orderview
        ///     C. Exit      --> Exit the App
        /// </summary>
        /// <param name="obj"></param>
        private void NotificationMessageReceived(NotificationMessage obj)
        {
            if (obj.Notification == "ContactView")
            {
                UserTxtBox.Text = string.Empty;
                PasswordBox.Password = string.Empty;
                Messenger.Default.Unregister<NotificationMessage>("ContactView");
                var user = new UserDetails();                
                user.ShowDialog();
            }
            else if (obj.Notification == "OrderView")
            {
                Messenger.Default.Unregister<NotificationMessage>("OrderView");
                var orders = new OrderView();
                orders.Show();
            }
            else if (obj.Notification == "Exit")
            {
                Messenger.Default.Unregister<NotificationMessage>("Exit");
                DataContext = null;
                Close();
            }
        }

        private void passwBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if (DataContext != null)
            {
                { ((dynamic)DataContext).Pass = ((PasswordBox)sender).Password; }
            }
        }
    }
}