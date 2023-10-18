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
using CKK.DB.Interfaces;

namespace CKK.UI
{
    public partial class SearchResultsForm : Form
    {
        private readonly IUnitOfWork UOW;
        private readonly string Search;
        public SearchResultsForm(IUnitOfWork uow, string search)
        {
            UOW = uow;
            Search = search;
            InitializeComponent();
            PopulateSearchBox();
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Close();
        }

        private async void EditButton_Click(object sender, EventArgs e)
        {
            var selected = (Product)SearchResultsListBox.SelectedItem;
            var selectedIndex = SearchResultsListBox.SelectedIndex;
            if (selected != null)
            {
                ItemEditorForm editor = new(selected);
                editor.ShowDialog();
                await UOW.Products.UpdateAsync(editor.Item);
            }
        }

        private async void PopulateSearchBox()
        {
            var results = await UOW.Products.GetByNameAsync(Search);
            if(results.Count <= 0)
            {
                MessageBox.Show("There are no items that match your search");
                Close();
            }else
            {
                foreach(var item in results)
                {
                    SearchResultsListBox.Items.Add(item);
                }
            }
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            var selected = (Product)SearchResultsListBox.SelectedItem;
            var selectedIndex = SearchResultsListBox.SelectedIndex;
            if (selected != null)
            {
                var result = MessageBox.Show(this, "Are you sure you want to delete this item?", "Are you sure?", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);

                if (result == DialogResult.Yes)
                {
                    UOW.Products.DeleteAsync(selected.Id);
                    SearchResultsListBox.Items.RemoveAt(selectedIndex);
                }
            }
        }
    }
}
