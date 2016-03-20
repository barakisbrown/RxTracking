using System.Windows;
using System.Windows.Controls;

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