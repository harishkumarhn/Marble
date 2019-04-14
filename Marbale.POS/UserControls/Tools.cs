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
    public partial class Tools : UserControl
    {
        private static Tools _instance;
        public static Tools Instance
        {

            get
            {
                if (_instance == null)
                    return _instance = new Tools();
                else
                    return _instance;
            }
        }

        public Tools()
        {
            InitializeComponent();
        }
    }
}
