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
    public partial class Tasks : UserControl
    {

        private static Tasks _instance;
        public static Tasks Instance
        {

            get
            {
                if (_instance == null)
                    return _instance = new Tasks();
                else
                    return _instance;
            }
        }

        public Tasks()
        {
            InitializeComponent();
        }
    }
}
