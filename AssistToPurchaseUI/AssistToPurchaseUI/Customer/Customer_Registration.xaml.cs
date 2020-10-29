using AssistPurchase.Models;
using AssistToPurchaseUI.Admin;
using AssistToPurchaseUI.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
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

namespace AssistToPurchaseUI.Customer
{
    /// <summary>
    /// Interaction logic for Customer_Registration.xaml
    /// </summary>
    public partial class Customer_Registration : Window
    {
        public Customer_Registration()
        {
            InitializeComponent();
        }

        private void Home_Click(object sender, RoutedEventArgs e)
        {
            WelcomePortal _Welcome = new WelcomePortal();
            _Welcome.Show();
            Close();
        }

        private void Submit_Click(object sender, RoutedEventArgs e)
        {
            CustomerModel _Model = new CustomerModel
            {
                CustomerEmailId = TextBoxEmail.Text,
                CustomerName = TextBoxCustName.Text,
                CustomerPhoneNumber = TextBoxPhone.Text,
                CustomerId = TextBlockCustID.Text,
                ProductName = TextBoxProductName.Text
            };

            HttpClient client = new HttpClient();
            string apiUrl = ConfigurationManager.AppSettings["MailApi"] + "CustomerAlert/sendAlert";
            client.BaseAddress = new Uri(apiUrl);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            var serializedProduct = JsonConvert.SerializeObject(_Model);
            var content = new StringContent(serializedProduct, Encoding.UTF8, "application/json");
            HttpResponseMessage response = client.PostAsync(apiUrl, content).Result;
            if (response.IsSuccessStatusCode)
            {
                MessageBox.Show("Thank you for connecting with us.");
            }
            else
            {
                MessageBox.Show("Please try again..!");
            }
        }

        private void Reset_Click(object sender, RoutedEventArgs e)
        {
            TextBoxCustID.Text = "";
            TextBoxCustName.Text = "";
            TextBoxEmail.Text = "";
            TextBoxPhone.Text = "";
            TextBoxProductName.Text = "";
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
