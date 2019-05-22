using CrmBl.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CrmUi
{
    public partial class Catalog<T> : Form
        where T : class
    {
        CrmContext _db;
        DbSet<T> _set;

        public Catalog(DbSet<T> set, CrmContext db)
        {
            InitializeComponent();
            _db = db;
            _set = set;
            _set.Load();
            dataGridView.DataSource = _set.Local.ToBindingList();
        }

        private void Catalog_Load(object sender, EventArgs e)
        {

        }

        private void Add_Click(object sender, EventArgs e)
        {
            //switch (typeof(T))
            //{
            //    case var type when type == typeof(Product):
            //        break;
            //}

            if (typeof(T) == typeof(Product))
            {

            }
            else if (typeof(T) == typeof(Seller))
            {
            }
            else if(typeof(T) == typeof(Customer))
            {

            }
            else if (typeof(T) == typeof(Check))
            {

            }
        }

        private void Change_Click(object sender, EventArgs e)
        {
            var id = dataGridView.SelectedRows[0].Cells[0].Value;

            if (typeof(T) == typeof(Product))
            {
                var product = _set.Find(id) as Product;

                if (product != null)
                {
                    var form = new ProductForm(product);
                    if (form.ShowDialog() == DialogResult.OK)
                    {
                        product = form.Product;
                        _db.SaveChanges();
                        dataGridView.Update();
                    }
                }
            }
            else if (typeof(T) == typeof(Seller))
            {
                var seller = _set.Find(id) as Seller;

                if (seller != null)
                {
                    var form = new SellerForm(seller);
                    if (form.ShowDialog() == DialogResult.OK)
                    {
                        seller = form.Seller;
                        _db.SaveChanges();
                        dataGridView.Update();
                    }
                }
            }
            else if (typeof(T) == typeof(Customer))
            {
                var customer = _set.Find(id) as Customer;

                if (customer != null)
                {
                    var form = new CustomerForm(customer);
                    if (form.ShowDialog() == DialogResult.OK)
                    {
                        customer = form.Customer;
                        _db.SaveChanges();
                        dataGridView.Update();
                    }
                }
            }
        }
    }
}
