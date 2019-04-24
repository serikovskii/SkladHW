using SkladHW.DataAccess;
using SkladHW.Models;
using System.Linq;
using System.Windows;

namespace SkladHW.WPF
{
    public partial class UpdateWindow : Window
    {
        private string name;
        private string newName;
        private int newPrice;
        private int choice;
        public UpdateWindow()
        {
            InitializeComponent();
        }
        public void UpdateProductButton(object sender, RoutedEventArgs e)
        {
            

            if (nameProduct.Text.Length == 0)
            {
                MessageBox.Show("норм вводи");
                return;
            }
            else if (!CheckName(nameProduct.Text))
            {
                MessageBox.Show("продукта такого нет");
                return;
            }
            else
                name = nameProduct.Text;

            if (newNameProduct.Text.Length == 0 && newPriceProduct.Text.Length == 0)
            {
                MessageBox.Show("что то одно введи");
                return; 
            }
            else if (newPriceProduct.Text.Length != 0 && newNameProduct.Text.Length == 0)
            {
                newPrice = int.Parse(newPriceProduct.Text);
                choice = 1;
            }
            else if (newPriceProduct.Text.Length == 0 && newNameProduct.Text.Length != 0)
            {
                newName = newNameProduct.Text;
                choice = 2;
            }
            else
            {
                newName = newNameProduct.Text;
                newPrice = int.Parse(newPriceProduct.Text);
                choice = 3;
            }


            using (var context = new ProductContext())
            {
                var product = context.Products.Where(prod => prod.NameProduct.Contains(name)).FirstOrDefault();
                UpdatedProduct updatedProduct;
                switch (choice)
                {
                    case 1:
                        updatedProduct = new UpdatedProduct
                        {
                            NameProduct = product.NameProduct,
                            PriceProduct = newPrice,
                            OldPriceProduct = product.PriceProduct
                        };
                        context.UpdatedProducts.Add(updatedProduct);
                        break;
                    case 2:
                        updatedProduct = new UpdatedProduct
                        {
                            NameProduct = newName,
                            PriceProduct = product.PriceProduct,
                            OldNameProduct = product.NameProduct
                        };
                        context.UpdatedProducts.Add(updatedProduct);
                        break;
                    case 3:
                        updatedProduct = new UpdatedProduct
                        {
                            PriceProduct = newPrice,
                            OldPriceProduct = product.PriceProduct,
                            NameProduct = newName,
                            OldNameProduct = product.NameProduct
                        };
                        context.UpdatedProducts.Add(updatedProduct);
                        break;

                }
                
                context.SaveChanges();

                MessageBox.Show("продукт изменен");
            }
            Close();
        }

        public bool CheckName(string name)
        {
            using (var context = new ProductContext())
            {
                var productNameCheck = context.Products.Where(prod => prod.NameProduct.Contains(nameProduct.Text)).FirstOrDefault();
                if (productNameCheck != null)
                    return true;
            }
            return false;
        }
    }
}
