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
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void TextBox_Enter(object sender, EventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            textBox.TextAlign = HorizontalAlignment.Left;
        }

        private void TextBox_Leave(object sender, EventArgs e)
        {
           TextBox textBox = (TextBox)sender;
           textBox.TextAlign = HorizontalAlignment.Center;            
        }
        private void LoginButton_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
