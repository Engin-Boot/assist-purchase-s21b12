using AssistToPurchaseUI.Admin;
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

namespace AssistToPurchaseUI.Customer
{
    /// <summary>
    /// Interaction logic for CustomerSelection.xaml
    /// </summary>
    public partial class CustomerSelection : Window
    {
        public CustomerSelection()
        {
            InitializeComponent();
        }

        private void Contact_Click(object sender, RoutedEventArgs e)
        {
            Customer_Registration _CustReg = new Customer_Registration();
            _CustReg.Show();
            Close();
        }

        private void Details_Click(object sender, RoutedEventArgs e)
        {
            MonitoringSystems obj = new MonitoringSystems();
           // ProductDetails _Product = new ProductDetails();
            obj.Show();
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
