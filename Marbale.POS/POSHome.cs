using Marbale.Business;
using System;
using System.Windows.Forms;

namespace Marbale.POS
{
    public partial class POSHome : Form
    {
        POSBusiness posBussiness;
        public POSHome()
        {
            posBussiness = new POSBusiness();  
            InitializeComponent();
        }

        private void POSHome_Load(object sender, EventArgs e)
        {
          //  var produts = posBussiness.GetProductsByScreenGroup("POS");
        }
    }
}
