using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Marbale.POS.UserControls
{
    public partial class Products : UserControl
    {

        private static Products _instance;
        public static Products Instance
        {

            get
            {
                if (_instance == null)
                   return _instance = new Products();
                else
                    return _instance;
            }
        }


        public Products()
        {
            InitializeComponent();
        }
    }
}
