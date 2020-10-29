using System.Windows;
using AssistToPurchaseUI.Customer;

namespace AssistToPurchaseUI.Admin
{
    /// <summary>
    /// Interaction logic for WelcomePortal.xaml
    /// </summary>
    public partial class WelcomePortal : Window
    {
        public WelcomePortal()
        {
            InitializeComponent();
        }
        private void Admin_Click(object sender, RoutedEventArgs e)
        {

            AdminLoginModel _Admin = new AdminLoginModel();
            _Admin.Show();
            Close();
        }

        private void Customer_Click(object sender, RoutedEventArgs e)
        {
            CustomerSelection _Select = new CustomerSelection();
            _Select.Show();
            Close();
        }
    }
}
