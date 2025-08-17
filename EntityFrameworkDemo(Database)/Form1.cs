using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EntityFrameworkDemo_Database_
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        ProductDal _productDal = new ProductDal();
        private void Form1_Load(object sender, EventArgs e)
        {
            LoadProducts();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            _productDal.Add(new Product 
            {
                Name = tbxName.Text,
                UnitPrice = Convert.ToDecimal(tbxUnitPrice.Text),
                StockAmount = Convert.ToInt32(tbxStockAmount.Text)
            });
            MessageBox.Show("Added!");
            LoadProducts();

        }

        private void LoadProducts() 
        {
            dgwProducts.DataSource = _productDal.GetAll();
        }

        //LINQ
        private void SearchProducts(string key)
        {
            //veritabanından gelen veriler geldikten sonra gelen verileri filtreleme
            //var result = _productDal.GetAll().Where(p=>p.Name.ToLower().Contains(key.ToLower())).ToList();
            
            //veritabanından direkt listeleme
            var result = _productDal.GetByName(key);
            dgwProducts.DataSource = result;
        }

        private void SearchProductsById(string key)
        {
            var product = _productDal.GetById(Convert.ToInt32(key));
            if (product != null)
            {
                tbxNameUpdate.Text = product.Name;
                tbxUnitPriceUpdate.Text = product.UnitPrice.ToString();
                tbxStockAmountUpdate.Text = product.StockAmount.ToString();
                //data grid wievde görünmesi için liste olması şartmış
                dgwProducts.DataSource = new List<Product> { product };
            }
            else
            {
                MessageBox.Show("No product found with Id = {0}",product.Id.ToString());
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            _productDal.Update(new Product 
            {
                Id = Convert.ToInt32(dgwProducts.CurrentRow.Cells[0].Value.ToString()),
                Name = tbxNameUpdate.Text,
                UnitPrice = Convert.ToDecimal(tbxUnitPriceUpdate.Text),
                StockAmount = Convert.ToInt32(tbxStockAmountUpdate.Text)
            });
            MessageBox.Show("Updated!");
            LoadProducts();
        }

        private void dgwProducts_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            tbxNameUpdate.Text = dgwProducts.CurrentRow.Cells[1].Value.ToString();
            tbxUnitPriceUpdate.Text = dgwProducts.CurrentRow.Cells[2].Value.ToString();
            tbxStockAmountUpdate.Text = dgwProducts.CurrentRow.Cells[3].Value.ToString();
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            _productDal.Delete(new Product
            {
                Id = Convert.ToInt32(dgwProducts.CurrentRow.Cells[0].Value)
            });
            MessageBox.Show("Deleted!");
            LoadProducts();
        }

        private void tbxSearch_TextChanged(object sender, EventArgs e)
        {
            SearchProducts(tbxSearch.Text);
        }

        private void btnGetById_Click(object sender, EventArgs e)
        {
            SearchProductsById(tbxSearch.Text);
            
        }
    }
}
