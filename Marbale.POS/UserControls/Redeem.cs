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
    public partial class Redeem : UserControl
    {
        private static Redeem _instance;
        public static Redeem Instance
        {

            get
            {
                if (_instance == null)
                    return _instance = new Redeem();
                else
                    return _instance;
            }
        }

        public Redeem()
        {
            InitializeComponent();
        }
    }
}
