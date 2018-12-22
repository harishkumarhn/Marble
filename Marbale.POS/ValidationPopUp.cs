using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Marbale.POS
{
    public partial class ValidationPopUp : Form
    {


        public string ValidationText
        {
            get
            {
                return this.lblValidationLabel.Text;
            }
            set
            {
                this.lblValidationLabel.Text = value;
            }
        }
        public ValidationPopUp()
        {
            InitializeComponent();
        }

        private void Ok_validation_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
