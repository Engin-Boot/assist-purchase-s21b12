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
    /// Interaction logic for MonitoringSystems.xaml
    /// </summary>
    public partial class MonitoringSystems : Window
    {
        public MonitoringSystems()
        {
            InitializeComponent();
        }

        private async void Products_Click(object sender, RoutedEventArgs e)
        {
            //MonitoringProducts _Model = new MonitoringProducts();
            HttpClient client = new HttpClient();
            string apiUrl = ConfigurationManager.AppSettings["MailApi"] + "MonitoringProduct/all";
            client.BaseAddress = new Uri(apiUrl);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            //var serializedProduct = JsonConvert.SerializeObject(_Model);
            //var content = new StringContent(serializedProduct, Encoding.UTF8, "application/json");
            HttpResponseMessage response = client.GetAsync(apiUrl).Result;

            if (response.IsSuccessStatusCode)
            {
                //Console.WriteLine("Request Message Information:- \n\n" + response.RequestMessage + "\n");
                //Console.WriteLine("Response Message Header \n\n" + response.Content.Headers + "\n");
                // Get the response
                var customerJsonString = await response.Content.ReadAsStringAsync();
                //Console.WriteLine("Your response data is: " + customerJsonString);

                // Deserialise the data (include the Newtonsoft JSON Nuget package if you don't already have it)
                var deserialized = JsonConvert.DeserializeObject<IEnumerable<MonitoringProducts>>(custome‌​rJsonString);
                // Do something with it
                //DataGridTextColumn textColumn1 = new DataGridTextColumn();
                //textColumn1.Header = "ProductNumber";

                //DataGridTextColumn textColumn2 = new DataGridTextColumn();
                //textColumn2.Header = "ProductName";
                //ProductDataGrid.Columns.Add(textColumn1);
                //ProductDataGrid.Columns.Add(textColumn2);
                List<ProductSample> _ProductList = new List<ProductSample>();

           
                foreach (var item in deserialized)
                {
                    //ProductDataGrid.Items.Add(item.ProductNumber);
                    //ProductDataGrid.Items.Add(item.ProductName);
                    _ProductList.Add(new ProductSample() { ProductNumber = item.ProductNumber, ProductName = item.ProductName,
                        WearableMonitor = item.WearableMonitor, TouchScreen = item.TouchScreen, Connectivity = item.ConnectivitySupport, Compact = item.Compact});
                }
                ProductDataGrid.ItemsSource = _ProductList;
            }
            else
            {
                MessageBox.Show("Unable to get details");
            }
            //ComboTextBox.Visibility = Visibility.Visible;
            //GetFilteredProducts.Visibility = Visibility.Visible;

        }

        private void Home_Click(object sender, RoutedEventArgs e)
        {
            WelcomePortal _Welcome = new WelcomePortal();
            _Welcome.Show();
            Close();
        }

        private void Contactus_Click(object sender, RoutedEventArgs e)
        {
            Customer_Registration _Registration = new Customer_Registration();
            _Registration.Show();
            Close();
        }

        private async void ApplyFilters_Click(object sender, RoutedEventArgs e)
        {
            HttpClient client = new HttpClient();
            string apiUrl = ConfigurationManager.AppSettings["MailApi"] + "MonitoringProduct/all";
            client.BaseAddress = new Uri(apiUrl);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage response = client.GetAsync(apiUrl).Result;

            if (response.IsSuccessStatusCode)
            {
                var customerJsonString = await response.Content.ReadAsStringAsync();
                
                var deserialized = JsonConvert.DeserializeObject<IEnumerable<MonitoringProducts>>(custome‌​rJsonString);
                
                List<ProductSample> _ProductList = new List<ProductSample>();

                string monitor = ShouldHaveWearableMonitor.Text;
                string touch = IsTouchScreenRequired.Text;
                string connectivity = ShouldProvideConnectivitySupport.Text;
                string compact = ShouldBeCompact.Text;

                foreach (var item in deserialized)
                {
                    bool conditionOne = helper(item.WearableMonitor, monitor, item.TouchScreen, touch);
                    bool conditionTwo = helper(item.Compact, compact, item.ConnectivitySupport, connectivity);
                    bool final = conditionOne & conditionTwo;
                    if (final)
                        _ProductList.Add(new ProductSample() { ProductNumber = item.ProductNumber, ProductName = item.ProductName,
                            WearableMonitor = item.WearableMonitor , TouchScreen = item.TouchScreen, 
                            Connectivity = item.ConnectivitySupport, Compact = item.Compact});
                }
                ProductDataGrid.ItemsSource = _ProductList;
            }
            else
            {
                MessageBox.Show("Unable to get details");
            }
        }

        private void GetInTouch_Click(object sender, RoutedEventArgs e)
        {
            Customer_Registration _getInTouch = new Customer_Registration();
            _getInTouch.Show();
            Close();
        }

        bool helper(string str1, string str2, string str3, string str4)
        {
            return str1 == str2 && str3 == str4;
        }

        private void GetMore_Click(object sender, RoutedEventArgs e)
        {
            MonitoringSystems2 _Monitor = new MonitoringSystems2();
            _Monitor.Show();
            Close();
        }
    }
}
