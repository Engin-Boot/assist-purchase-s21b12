using System.Windows;

namespace AssistToPurchaseUI.Admin
{
    /// <summary>
    /// Interaction logic for AdminSelectionPortal.xaml
    /// </summary>
    public partial class AdminSelectionPortal : Window
    {
        public AdminSelectionPortal()
        {
            InitializeComponent();
        }
        private void Add_Service(object sender, RoutedEventArgs e)
        {
            AdminAddService Admin = new AdminAddService();
            Admin.Show();
            Close();
        }

        private void Update_Service(object sender, RoutedEventArgs e)
        {
            UpdateService _Update = new UpdateService();
            _Update.Show();
            Close();
        }

        private void Delete_Service(object sender, RoutedEventArgs e)
        {
            AdminRemoveProduct Remove = new AdminRemoveProduct();
            Remove.Show();
            Close();
        }

        private void Home_Click(object sender, RoutedEventArgs e)
        {
            WelcomePortal _Welcome = new WelcomePortal();
            _Welcome.Show();
            Close();
        }
    }
}
