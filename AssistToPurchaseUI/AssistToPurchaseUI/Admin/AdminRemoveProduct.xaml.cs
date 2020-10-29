using System;
using System.Configuration;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Windows;

namespace AssistToPurchaseUI.Admin
{
    /// <summary>
    /// Interaction logic for AdminRemoveProduct.xaml
    /// </summary>
    public partial class AdminRemoveProduct : Window
    {
        public AdminRemoveProduct()
        {
            InitializeComponent();
        }

        private void Remove_Click(object sender, RoutedEventArgs e)
        {
            if (ProductNameDel.Text.Length == 0)
            {
                ErrorMesg.Text = "Please enter Product number";
                ProductNameDel.Focus();
            }
            else
            {
                var _Delete = ProductNameDel.Text;
                HttpClient client = new HttpClient();
                string apiUrl = ConfigurationManager.AppSettings["MailApi"] + "MonitoringProduct/delete/" + _Delete ;
                client.BaseAddress = new Uri(apiUrl);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                //var serializedProduct = JsonConvert.SerializeObject(_Delete);
                //var content = new StringContent(serializedProduct, Encoding.UTF8, "application/json");
                HttpResponseMessage response = client.DeleteAsync(apiUrl).Result;
                if (response.IsSuccessStatusCode)
                {
                    //var msg = Convert.ToString(response.Content);
                    MessageBox.Show("Product "+_Delete+" Removed succesfully");
                }
                else
                {
                    MessageBox.Show("Product Not Found.. !");
                }
            }
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
