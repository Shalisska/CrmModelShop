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
        CrmContext db;

        public Catalog(DbSet<T> set, CrmContext _db)
        {
            InitializeComponent();
            db = _db;
            var res = db.Set(typeof(T)).ToListAsync();
            var res1 = res.Result;
            dataGridView.DataSource = set.Local.ToBindingList();
        }

        private void Catalog_Load(object sender, EventArgs e)
        {

        }

        private void Add_Click(object sender, EventArgs e)
        {
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
        }
    }
}
