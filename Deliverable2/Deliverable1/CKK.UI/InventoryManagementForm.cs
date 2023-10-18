
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
using CKK.DB.UOW;
using CKK.DB.Interfaces;


namespace CKK.UI
{
    public partial class InventoryManagementForm : Form
    {
        private readonly IUnitOfWork UOW;

        public InventoryManagementForm(IUnitOfWork uow)
        {
            UOW = uow;
            InitializeComponent();
            RefreshList();
        }

        private async void RefreshList()
        {
            InventoryList.Items.Clear();
            var products = await UOW.Products.GetAllAsync();
            foreach (var item in products)
            {
                InventoryList.Items.Add(item);
            }
        }
        private async void RefreshListWithSelected(int selected)
        {
            InventoryList.Items.Clear();
            var products = await UOW.Products.GetAllAsync();
            foreach (var item in products)
            {
                InventoryList.Items.Add(item);
            }
            if(selected >= 0 && selected < InventoryList.Items.Count)
            {
                InventoryList.SetSelected(selected, true);
            }
        }

        private void SearchButton_Click(object sender, EventArgs e)
        {
            SearchResultsForm searchForm = new SearchResultsForm(UOW, SearchTextBox.Text);
            if (!searchForm.IsDisposed)
            {
                searchForm.ShowDialog();
                RefreshList();
                SearchTextBox.Text = "";
            }
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            NewItemForm newItemForm = new();
            var result = newItemForm.ShowDialog();

            //Only if the user hits the Create button will it add it to the store. 
            if (result == DialogResult.OK)
            {
                UOW.Products.AddAsync(newItemForm.Item);
                RefreshList();
            }
        }

        private async void EditButton_Click(object sender, EventArgs e)
        {
            var selected = (Product)InventoryList.SelectedItem;
            int selectedIndex = InventoryList.SelectedIndex;
            if (selected != null)
            {
                ItemEditorForm editor = new(selected);
                editor.ShowDialog();
 
                await UOW.Products.UpdateAsync(editor.Item);
                RefreshListWithSelected(selectedIndex);
            }
        }

        private void RemoveButton_Click(object sender, EventArgs e)
        {
            var selected = (Product)InventoryList.SelectedItem;
            if (selected != null)
            {
                var result = MessageBox.Show(this, "Are you sure you want to delete this item?", "Are you sure?", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);

                if (result == DialogResult.Yes)
                {
                    UOW.Products.DeleteAsync(selected.Id);
                }
            }
            RefreshList();
        }

        private void SearchTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if(SearchTextBox.Focused)
            {
                if(e.KeyCode == Keys.Enter)
                {
                    SearchButton_Click(sender, e);
                }
            }
        }

        
    }
}
