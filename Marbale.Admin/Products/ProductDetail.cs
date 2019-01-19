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
using Marbale.BusinessObject;

namespace Marbale.Products
{
    public partial class ProductDetail : Form
    {
        ProductBusiness productBusiness;

        public ProductDetail()
        {
            InitializeComponent();
            productBusiness = new ProductBusiness();
        }

        private void ProductDetail_Load(object sender, EventArgs e)
        {

        }

        private void btn_Save_Click(object sender, EventArgs e)
        {
            Product product = new Product() 
            {
                Active = this.chk_pActive.Checked,
                AutoGenerateCardNumber = this.chk_agCard.Checked,
                Category = this.cmb_pCty.SelectedText,
                DisplayGroup = this.txt_dg.Text,
                DisplayInPOS = this.chk_dip.Checked,
                Price = Convert.ToInt32(this.txt_price.Text),
                EffectivePrice = Convert.ToInt32(this.txt_efectivePrice.Text),
                FaceValue = Convert.ToInt32(this.txt_faceValue.Text),
                FinalPrice = Convert.ToInt32(this.txt_finalprice.Text),
                Name = this.txt_pName.Text,
                OnlyVIP = this.chk_VIP.Checked,
                POSCounter = this.cmb_pCounter.SelectedText,
                TaxInclusive = this.chk_taxInx.Checked,
                TaxPercentage = Convert.ToInt32(this.txt_taxPer.Text)               
               
            };

            productBusiness.AddProduct(product);
        }

        private void btn_refresh_Click(object sender, EventArgs e)
        {

        }

        private void btn_new_Click(object sender, EventArgs e)
        {

        }

        private void btn_close_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
