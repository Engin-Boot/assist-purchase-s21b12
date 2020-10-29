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

namespace AssistToPurchaseUI.Admin
{
    /// <summary>
    /// Interaction logic for AdminGetResult.xaml
    /// </summary>
    public partial class AdminGetResult : Window
    {
        public AdminGetResult()
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

            HttpResponseMessage response = client.GetAsync(apiUrl).Result;

            if (response.IsSuccessStatusCode)
            {
               
                var customerJsonString = await response.Content.ReadAsStringAsync();
                var deserialized = JsonConvert.DeserializeObject<IEnumerable<MonitoringProducts>>(custome‌​rJsonString);
                List<ProductSample> _ProductList = new List<ProductSample>();

                foreach (var item in deserialized)
                {
                    _ProductList.Add(new ProductSample() { ProductNumber = item.ProductNumber, ProductName = item.ProductName,
                        ProductDescription = item.ProductDescription });
                }
                ProductDataGrid.ItemsSource = _ProductList;
            }
            else
            {
                MessageBox.Show("Unable to get details");
            }

        }

        private void Home_Click(object sender, RoutedEventArgs e)
        {
            WelcomePortal _Welcome = new WelcomePortal();
            _Welcome.Show();
            Close();
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            AdminSelectionPortal _Select = new AdminSelectionPortal();
            _Select.Show();
            Close();
        }
    }
}
