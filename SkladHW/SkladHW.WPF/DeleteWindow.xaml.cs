using SkladHW.DataAccess;
using SkladHW.Models;
using System.Linq;
using System.Windows;

namespace SkladHW.WPF
{
    public partial class DeleteWindow : Window
    {
        private string name;
        public DeleteWindow()
        {
            InitializeComponent();
        }
        public void DeleteProductButton(object sender, RoutedEventArgs e)
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

            using (var context = new ProductContext())
            {
                var product = context.Products.Where(prod => prod.NameProduct.Contains(name)).FirstOrDefault();
                var deletedProduct = new DeletedProduct
                {
                    ProductId = product.Id,
                    NameProduct = product.NameProduct,
                    PriceProduct = product.PriceProduct
                };
                context.DeletedProducts.Add(deletedProduct);
                context.SaveChanges();

                for(int i = 0; i < context.Products.ToList().Count; i++)
                {
                    if(context.Products.ToList()[i].NameProduct == name)
                    {
                        context.Products.ToList().RemoveAt(i);
                        break;
                    }
                }
                
                context.SaveChanges();
                MessageBox.Show("продукт удален");
            }
            Close();
        }

        public bool CheckName (string name)
        {
            using(var context = new ProductContext())
            {
                var productNameCheck = context.Products.Where(prod => prod.NameProduct.Contains(nameProduct.Text)).FirstOrDefault();
                if (productNameCheck != null)
                    return true;
            }
            return false;
        }
    }
}
