using Marbale.Business;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Marbale.Products
{
    public partial class DiscountForm : Form
    {
        MarbaleBusiness marbaleBusiness;
        public DiscountForm()
        {
            InitializeComponent();
            marbaleBusiness = new MarbaleBusiness();
        }

        private void TransactionDiscountTab_Click(object sender, EventArgs e)
        {
            var settings = marbaleBusiness.GetAllDiscounts();
        }
    }
}
