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
    /// Interaction logic for MonitoringSystems2.xaml
    /// </summary>
    public partial class MonitoringSystems2 : Window
    {
        public MonitoringSystems2()
        {
            InitializeComponent();
        }

        private void BelowPrice_Click(object sender, RoutedEventArgs e)
        {

            string CostPropertyValue;
            string CostValue;
            //BelowPrice.Text = "";
            //AbovePrice.Text = "";
            CostPropertyValue = "BelowPrice";
            CostValue = Price.Text;
            ScreenCostFilter(CostPropertyValue, CostValue);
            /*
            var Url = "ClientQuestions/MonitoringProducts/" + CostPropertyValue + "/" + CostValue;
            string apiUrl = ConfigurationManager.AppSettings["MailApi"] + Url;
            //string apiUrl = ConfigurationManager.AppSettings["MailApi"] + "ClientQuestions/MonitoringProducts/TouchScreen/YES";
            client.BaseAddress = new Uri(apiUrl);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            
            HttpResponseMessage response2 = client.GetAsync(apiUrl).Result;

            if (response2.IsSuccessStatusCode)
            {

                var customerJsonString = await response2.Content.ReadAsStringAsync();
                var deserialized = JsonConvert.DeserializeObject<IEnumerable<MonitoringProducts>>(custome‌​rJsonString);
                List<ProductSample> _ListModel = new List<ProductSample>();

                foreach (var item in deserialized)
                {
                    _ListModel.Add(new ProductSample() { ProductNumber = item.ProductNumber, ProductName = item.ProductName,
                    Cost = item.Cost, ScreenSize = item.ScreenSize});
                }
                DataGrid2.ItemsSource = _ListModel;
            }
            else
            {
                MessageBox.Show("Unable to get details");
            } */

            ContactUstext.Visibility = Visibility.Visible;

        }

        private void AbovePrice_Click(object sender, RoutedEventArgs e)
        {
            string PropertyValue;
            string Value;
            PropertyValue = "AbovePrice";
            Value = Price.Text;
            ScreenCostFilter(PropertyValue, Value);

            ContactUstext.Visibility = Visibility.Visible;
            //Price.Text = "";
            //Price.Text = "";

        }
        private void BelowScreenSize_Click(object sender, RoutedEventArgs e)
        {

            string PropertyValue;
            string Value;
            PropertyValue = "BelowScreenSize";
            Value = ScreenSize.Text;
            ScreenCostFilter(PropertyValue, Value);
        }

        private void AboveScreenSize_Click(object sender, RoutedEventArgs e)
        {
            string PropertyValue;
            string Value;

            PropertyValue = "AboveScreenSize";
            Value = ScreenSize.Text;
            ScreenCostFilter(PropertyValue, Value);
        }

        private async void ScreenCostFilter(string PropertyValue, string Value)
        {
            HttpClient client = new HttpClient();
            var Url = "ClientQuestions/MonitoringProducts/" + PropertyValue + "/" + Value;
            string apiUrl = ConfigurationManager.AppSettings["MailApi"] + Url;
            //string apiUrl = ConfigurationManager.AppSettings["MailApi"] + "ClientQuestions/MonitoringProducts/TouchScreen/YES";
            client.BaseAddress = new Uri(apiUrl);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage response = client.GetAsync(apiUrl).Result;

            if (response.IsSuccessStatusCode)
            {

                var customerJsonString = await response.Content.ReadAsStringAsync();
                var deserialized = JsonConvert.DeserializeObject<IEnumerable<MonitoringProducts>>(custome‌​rJsonString);
                List<MonitoringProducts> _ModelList = new List<MonitoringProducts>();

                foreach (var item in deserialized)
                {
                    _ModelList.Add(new MonitoringProducts()
                    {
                        ProductNumber = item.ProductNumber,
                        ProductName = item.ProductName,
                        Cost = item.Cost,
                        ScreenSize = item.ScreenSize
                    });
                }
                DataGrid2.ItemsSource = _ModelList;
            }
            else
            {
                MessageBox.Show("Unable to get details");
            }
        }

        private void Contactus_Click(object sender, RoutedEventArgs e)
        {
            Customer_Registration _Registration = new Customer_Registration();
            _Registration.Show();
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
