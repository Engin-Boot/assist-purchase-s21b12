using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using AssistToPurchaseUI.Models;
using System.Net.Http;
using System.Net.Http.Headers;
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
using AssistToPurchaseUI.Admin;

namespace AssistToPurchaseUI.Customer
{
    /// <summary>
    /// Interaction logic for ProductDetails.xaml
    /// </summary>
    public partial class ProductDetails : Window
    {
        public ProductDetails()
        {
            InitializeComponent();
        }       
        private void AboutUs_Click(object sender, RoutedEventArgs e)
        {
            AboutUsTextBox.Visibility = Visibility.Visible;
            
        }

        private void ContactUs_Click(object sender, RoutedEventArgs e)
        {
            Customer_Registration _Registration = new Customer_Registration();
            _Registration.Show();
            Close();
        }

        private void GetDetails_Click(object sender, RoutedEventArgs e)
        {
            MonitoringSystems _System = new MonitoringSystems();
            _System.Show();
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
