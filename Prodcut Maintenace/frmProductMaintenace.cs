using ProductMaintenance;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Prodcut_Maintenace
{
    public partial class frmProductMaintenace : Form
    {
        public frmProductMaintenace()
        {
            InitializeComponent();
        }
         public List<Product> products = null;
        private void Form1_Load(object sender, EventArgs e)
        {
            products = ProductDB.GetProducts();
            FillProductListBox();
        }
        private void FillProductListBox()
        {
            lisProduct.Items.Clear();
            foreach (Product p in products)
            {
                lisProduct.Items.Add(p.GetDisplayText("\t"));
            }
        }

       
        private void btnDeleteProduct_Click(object sender, EventArgs e)
        {
            int i = lisProduct.SelectedIndex;
            if(i != -1)
            {
                Product product = products[i];
                string message = "Are you sure you want to delete " + product.Description + "?";
                DialogResult button = MessageBox.Show(message ,"Confirm Delete",MessageBoxButtons.YesNo);
                if(button == DialogResult.Yes)
                {
                    products.Remove(product);
                    ProductDB.SaveProducts(products);
                    FillProductListBox() ;
                }
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAddproduct_Click(object sender, EventArgs e)
        {
            frmNewProduct newProductForm = new frmNewProduct();
            Product product = newProductForm.GetNewProduct();

            if (product!= null)
            {
                products.Add(product);
                ProductDB.SaveProducts(products);
                FillProductListBox();
            }
        }
    }
}
