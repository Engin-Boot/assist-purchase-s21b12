using Newtonsoft.Json;
using System;
using System.Configuration;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Windows;

namespace AssistToPurchaseUI.Admin
{
    /// <summary>
    /// Interaction logic for UpdateService.xaml
    /// </summary>
    public partial class UpdateService : Window
    {
        public UpdateService()
        {
            InitializeComponent();
        }
        private void Submit_Click(object sender, RoutedEventArgs e)
        {
            if (ProductNumberTextBox.Text.Length == 0)
            {
                errormessage.Text = "Enter Product Number.";
                ProductNumberTextBox.Focus();
            }
            else
            {
                var _Model = new Models.MonitoringProducts
                {
                    ProductNumber = ProductNumberTextBox.Text,
                    ProductName = ProductNameTextBox.Text,
                    ProductDescription = ProductDescriptionTextBox.Text,
                    ScalableMeasurement = ScalableMeasurementTextBox.Text,
                    ScreenSize = ScreenSizeTextBox.Text,
                    SummarizeDataSupport = SummarizeDataSupportTextBox.Text,
                    WearableMonitor = WearableMonitorTextBox.Text,
                    ConnectivitySupport = ConnectivitySupportTextBox.Text,
                    AlarmManagement = AlarmManagementTextBox.Text,
                    Compact = CompactTextBox.Text,
                    Cost = CostTextBox.Text,
                    TouchScreen = TouchScreenTextBox.Text
                };

                HttpClient client = new HttpClient();
                string apiUrl = ConfigurationManager.AppSettings["MailApi"] + "MonitoringProduct/update/"+_Model.ProductNumber;
                client.BaseAddress = new Uri(apiUrl);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                //How to send mutliple var in client request ?? like here update we need to send PNumber and _Model
                var serializedProduct = JsonConvert.SerializeObject(_Model);
                var content = new StringContent(serializedProduct, Encoding.UTF8, "application/json");
                HttpResponseMessage response = client.PutAsync(apiUrl, content).Result;
                if (response.IsSuccessStatusCode)
                {
                    //var msg = Convert.ToString(response.Content);
                    MessageBox.Show("Product "+_Model.ProductNumber+" Updated Successfully");
                }
                else
                {
                    MessageBox.Show("Update Failed...");
                }
            }
        }

        private void Reset_Click(object sender, RoutedEventArgs e)
        {
            ProductNumberTextBox.Text = "";
            ProductNameTextBox.Text = "";
            ProductDescriptionTextBox.Text = "";
            TouchScreenTextBox.Text = "";
            WearableMonitorTextBox.Text = "";
            AlarmManagementTextBox.Text = "";
            CostTextBox.Text = "";
            ScreenSizeTextBox.Text = "";
            ConnectivitySupportTextBox.Text = "";
            SummarizeDataSupportTextBox.Text = "";
            ScalableMeasurementTextBox.Text = "";
            CompactTextBox.Text = "";
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Selection_Click(object sender, RoutedEventArgs e)
        {
            AdminSelectionPortal _Select = new AdminSelectionPortal();
            _Select.Show();
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
