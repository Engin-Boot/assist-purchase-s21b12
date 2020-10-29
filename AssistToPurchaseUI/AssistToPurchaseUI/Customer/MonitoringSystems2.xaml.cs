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

        private async void ScrCost_Click(object sender, RoutedEventArgs e)
        {

            HttpClient client = new HttpClient();

            string CostPropertyValue;
            string CostValue;
            //BelowPrice.Text = "";
            //AbovePrice.Text = "";
            if (BelowPrice.Text != null)
            {
                CostPropertyValue = "BelowPrice";
                CostValue = BelowPrice.Text;
            }
            else
            {
                CostPropertyValue = "AbovePrice";
                CostValue = AbovePrice.Text;
            }

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
                    _ListModel.Add(new ProductSample() { ProductNumber = item.ProductNumber, ProductName = item.ProductName });
                }
                DataGrid2.ItemsSource = _ListModel;
            }
            else
            {
                MessageBox.Show("Unable to get details");
            }
            ContactUstext.Visibility = Visibility.Visible;
            BelowPrice.Text = "";
            AbovePrice.Text = "";
            //CostPropertyValue = "";
            //CostValue = "";
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

        private async void ScreenFilter_Click(object sender, RoutedEventArgs e)
        {
            HttpClient client = new HttpClient();

            string PropertyValue;
            string Value;
            if(BelowScreenSize.Text != null)
            {
                PropertyValue = "BelowScreenSize";
                Value = BelowScreenSize.Text;
            }
            else
            {
                PropertyValue = "AboveScreenSize";
                Value = AboveScreenSize.Text;
            }

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
                List<ProductSample> _ModelList = new List<ProductSample>();

                foreach (var item in deserialized)
                {
                    _ModelList.Add(new ProductSample() { ProductNumber = item.ProductNumber, ProductName = item.ProductName });
                }
                DataGrid2.ItemsSource = _ModelList;
            }
            else
            {
                MessageBox.Show("Unable to get details");
            }
        }
    }
}
