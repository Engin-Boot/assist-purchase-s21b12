using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace AssistToPurchaseUI.Admin
{
    /// <summary>
    /// Interaction logic for AdminLoginModel.xaml
    /// </summary>
    public partial class AdminLoginModel : Window
    {
        public AdminLoginModel()
        {
            InitializeComponent();
        }

        private void Home_Click(object sender, RoutedEventArgs e)
        {
            WelcomePortal _Portal = new WelcomePortal();
            _Portal.Show();
            Close();
        }

        private void Login_Click(object sender, RoutedEventArgs e)
        {
            if(Id.Text == "admin" && Password.Password =="1234")
            {
                AdminSelectionPortal _Select = new AdminSelectionPortal();
                _Select.Show();
                Close();
            }
            else
            {
                MessageBox.Show("Please enter correct Id or Password");
            }
        }
    }
}
