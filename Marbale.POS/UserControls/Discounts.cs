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
    public partial class Discounts : UserControl
    {

        private static Discounts _instance;
        public static Discounts Instance
        {

            get
            {
                if (_instance == null)
                    return _instance = new Discounts();
                else
                    return _instance;
            }
        }

        public Discounts()
        {
            InitializeComponent();
        }
    }
}
