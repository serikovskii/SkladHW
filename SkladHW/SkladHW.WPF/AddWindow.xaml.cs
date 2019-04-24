using SkladHW.DataAccess;
using SkladHW.Models;
using System.Windows;

namespace SkladHW.WPF
{
    public partial class AddWindow : Window
    {
        public string name;
        public int price;
        public AddWindow()
        {
            InitializeComponent();
        }

        public void AddProductButton(object sender, RoutedEventArgs e)
        {
            if (nameProduct.Text.Length == 0)
            {
                MessageBox.Show("норм вводи");
                return;
            }
            else
                name = nameProduct.Text;

            if (priceProduct.Text.Length == 0)
            {
                MessageBox.Show("норм вводи");
                return;
            }
            else
                price = int.Parse(priceProduct.Text);

            using(var context = new ProductContext())
            {
                var product = new Product
                {
                    NameProduct=name, PriceProduct = price
                };
                context.Products.Add(product);
                context.SaveChanges();
                MessageBox.Show("продукт добавлен");
            }
            Close();
        }
    }
}
