using CKK.Logic.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CKK.UI
{
    public partial class NewItemForm : Form
    {
        public Product Item { get; private set; }
        public NewItemForm()
        {
            InitializeComponent();
        }

        private void CreateButton_Click(object sender, EventArgs e)
        {
            var prod = new Product();
            prod.Name =(NameTextBox.Text);
            prod.Price = (PriceTextBox.Value);
            prod.Quantity = (int)QuantityTextBox.Value;
            Item = prod;
            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
