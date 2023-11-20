using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;

namespace Expander
{
    public partial class MainWindow : Window
    {
        public ObservableCollection<Product> products { get; set; }

        public MainWindow()
        {
            InitializeComponent();
            products = new ObservableCollection<Product>();
            productListBox.ItemsSource = products;
        }

        private void AddProduct_Click(object sender, RoutedEventArgs e)
        {
            string productName = productNameTextBox.Text;
            string productInfo = productInfoTextBox.Text;

            if (!string.IsNullOrEmpty(productName))
            {
                products.Add(new Product { Name = productName, AdditionalInfo = productInfo });
                productNameTextBox.Clear();
                productInfoTextBox.Clear();
            }
        }
        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            Button deleteButton = (Button)sender;
            Product product = (Product)deleteButton.DataContext;

            products.Remove(product);
        }
    }
    public class Product
    {
        public string? Name { get; set; }
        public string? AdditionalInfo { get; set; }
    }
}
